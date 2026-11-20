using System.Buffers.Binary;
using System.Security.Cryptography.Pkcs;
using Internal.Cryptography;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Cryptography.X509Certificates;

internal abstract class UnixExportProvider : IExportPal, IDisposable
{
	private static readonly Oid s_Pkcs12X509CertBagTypeOid = new Oid("1.2.840.113549.1.9.22.1", null);

	protected ICertificatePalCore _singleCertPal;

	protected X509Certificate2Collection _certs;

	internal UnixExportProvider(ICertificatePalCore singleCertPal)
	{
		_singleCertPal = singleCertPal;
	}

	internal UnixExportProvider(X509Certificate2Collection certs)
	{
		_certs = certs;
	}

	public void Dispose()
	{
		_singleCertPal = null;
		_certs = null;
	}

	protected abstract byte[] ExportPkcs7();

	protected abstract byte[] ExportPkcs8(ICertificatePalCore certificatePal, PbeParameters pbeParameters, ReadOnlySpan<char> password);

	public byte[] Export(X509ContentType contentType, SafePasswordHandle password)
	{
		switch (contentType)
		{
		case X509ContentType.Cert:
			return ExportX509Der();
		case X509ContentType.Pfx:
			return ExportPkcs12(Helpers.Windows3desPbe, password);
		case X509ContentType.Pkcs7:
			return ExportPkcs7();
		case X509ContentType.SerializedCert:
		case X509ContentType.SerializedStore:
			throw new PlatformNotSupportedException("Cryptography_Unix_X509_SerializedExport");
		default:
			throw new CryptographicException("Cryptography_X509_InvalidContentType");
		}
	}

	private byte[] ExportX509Der()
	{
		if (_singleCertPal != null)
		{
			return _singleCertPal.RawData;
		}
		if (_certs.Count == 0)
		{
			return null;
		}
		return _certs[0].RawData;
	}

	public byte[] ExportPkcs12(PbeParameters exportParameters, SafePasswordHandle password)
	{
		bool success = false;
		try
		{
			password.DangerousAddRef(ref success);
			ReadOnlySpan<char> password2 = password.DangerousGetSpan();
			int localKeyIdCounter = 1;
			Pkcs12Builder pkcs12Builder = new Pkcs12Builder();
			Pkcs12SafeContents pkcs12SafeContents = new Pkcs12SafeContents();
			Pkcs12SafeContents pkcs12SafeContents2 = new Pkcs12SafeContents();
			if (_singleCertPal != null)
			{
				AddCertPalToSafeContents(pkcs12SafeContents, pkcs12SafeContents2, _singleCertPal, password2, ref localKeyIdCounter);
			}
			else
			{
				for (int num = _certs.Count - 1; num >= 0; num--)
				{
					X509Certificate2 x509Certificate = _certs[num];
					AddCertPalToSafeContents(pkcs12SafeContents, pkcs12SafeContents2, x509Certificate.Pal, password2, ref localKeyIdCounter);
				}
			}
			pkcs12Builder.AddSafeContentsEncrypted(pkcs12SafeContents, password2, exportParameters);
			pkcs12Builder.AddSafeContentsUnencrypted(pkcs12SafeContents2);
			pkcs12Builder.SealWithMac(password2, exportParameters.HashAlgorithm, exportParameters.IterationCount);
			return pkcs12Builder.Encode();
		}
		finally
		{
			if (success)
			{
				password.DangerousRelease();
			}
		}
		void AddCertPalToSafeContents(Pkcs12SafeContents certContainer, Pkcs12SafeContents keyContainer, ICertificatePalCore certificatePal, ReadOnlySpan<char> password3, ref int reference)
		{
			Pkcs12CertBag pkcs12CertBag = new Pkcs12CertBag(s_Pkcs12X509CertBagTypeOid, PkcsHelpers.EncodeOctetString(certificatePal.RawData));
			if (certificatePal.HasPrivateKey)
			{
				Span<byte> obj = stackalloc byte[4];
				BinaryPrimitives.WriteInt32LittleEndian(obj, reference);
				Pkcs9LocalKeyId asnEncodedData = new Pkcs9LocalKeyId(obj);
				Pkcs12ShroudedKeyBag pkcs12ShroudedKeyBag = new Pkcs12ShroudedKeyBag(ExportPkcs8(certificatePal, exportParameters, password3), skipCopy: true);
				pkcs12CertBag.Attributes.Add(asnEncodedData);
				pkcs12ShroudedKeyBag.Attributes.Add(asnEncodedData);
				keyContainer.AddSafeBag(pkcs12ShroudedKeyBag);
				reference++;
			}
			certContainer.AddSafeBag(pkcs12CertBag);
		}
	}
}
