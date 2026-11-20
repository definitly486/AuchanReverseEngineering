using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Asn1;
using Internal.Cryptography;

namespace System.Security.Cryptography.X509Certificates;

internal static class X509Pal
{
	private sealed class AndroidX509Pal : IX509Pal
	{
		public ECDsa DecodeECDsaPublicKey(ICertificatePal certificatePal)
		{
			if (certificatePal == null)
			{
				throw new NotSupportedException("NotSupported_KeyAlgorithm");
			}
			return new ECDsaImplementation.ECDsaAndroid(DecodeECPublicKey(certificatePal));
		}

		public ECDiffieHellman DecodeECDiffieHellmanPublicKey(ICertificatePal certificatePal)
		{
			if (certificatePal == null)
			{
				throw new NotSupportedException("NotSupported_KeyAlgorithm");
			}
			return new ECDiffieHellmanImplementation.ECDiffieHellmanAndroid(DecodeECPublicKey(certificatePal));
		}

		public AsymmetricAlgorithm DecodePublicKey(Oid oid, byte[] encodedKeyValue, byte[] encodedParameters, ICertificatePal certificatePal)
		{
			string value = oid.Value;
			if (!(value == "1.2.840.10040.4.1"))
			{
				if (value == "1.2.840.113549.1.1.1")
				{
					if (certificatePal != null)
					{
						SafeRsaHandle safeRsaHandle = new SafeRsaHandle();
						Marshal.InitHandle(safeRsaHandle, GetPublicKey(certificatePal, global::Interop.AndroidCrypto.PAL_KeyAlgorithm.RSA));
						return new RSAImplementation.RSAAndroid(safeRsaHandle);
					}
					return DecodeRsaPublicKey(encodedKeyValue);
				}
				throw new NotSupportedException("NotSupported_KeyAlgorithm");
			}
			if (certificatePal != null)
			{
				SafeDsaHandle safeDsaHandle = new SafeDsaHandle();
				Marshal.InitHandle(safeDsaHandle, GetPublicKey(certificatePal, global::Interop.AndroidCrypto.PAL_KeyAlgorithm.DSA));
				return new DSAImplementation.DSAAndroid(safeDsaHandle);
			}
			return DecodeDsaPublicKey(encodedKeyValue, encodedParameters);
		}

		public string X500DistinguishedNameDecode(byte[] encodedDistinguishedName, X500DistinguishedNameFlags flag)
		{
			return X500NameEncoder.X500DistinguishedNameDecode(encodedDistinguishedName, printOid: true, flag);
		}

		public string X500DistinguishedNameFormat(byte[] encodedDistinguishedName, bool multiLine)
		{
			return X500NameEncoder.X500DistinguishedNameDecode(encodedDistinguishedName, printOid: true, multiLine ? X500DistinguishedNameFlags.UseNewLines : X500DistinguishedNameFlags.None, multiLine);
		}

		public X509ContentType GetCertContentType(ReadOnlySpan<byte> rawData)
		{
			if (rawData.IsEmpty)
			{
				throw new CryptographicException();
			}
			X509ContentType x509ContentType = global::Interop.AndroidCrypto.X509GetContentType(rawData);
			if (x509ContentType != X509ContentType.Unknown)
			{
				return x509ContentType;
			}
			if (X509CertificateLoader.IsPkcs12(rawData))
			{
				return X509ContentType.Pfx;
			}
			throw new CryptographicException("Cryptography_UnknownCertContentType");
		}

		private static SafeEcKeyHandle DecodeECPublicKey(ICertificatePal pal)
		{
			SafeEcKeyHandle safeEcKeyHandle = new SafeEcKeyHandle();
			Marshal.InitHandle(safeEcKeyHandle, GetPublicKey(pal, global::Interop.AndroidCrypto.PAL_KeyAlgorithm.EC));
			return safeEcKeyHandle;
		}

		private static nint GetPublicKey(ICertificatePal pal, global::Interop.AndroidCrypto.PAL_KeyAlgorithm algorithm)
		{
			nint num = global::Interop.AndroidCrypto.X509GetPublicKey(((AndroidCertificatePal)pal).SafeHandle, algorithm);
			if (num == IntPtr.Zero)
			{
				throw new CryptographicException();
			}
			return num;
		}

		private static RSA DecodeRsaPublicKey(byte[] encodedKeyValue)
		{
			RSA rSA = RSA.Create();
			try
			{
				rSA.ImportRSAPublicKey(new ReadOnlySpan<byte>(encodedKeyValue), out var _);
				return rSA;
			}
			catch (Exception)
			{
				rSA.Dispose();
				throw;
			}
		}

		private static DSA DecodeDsaPublicKey(byte[] encodedKeyValue, byte[] encodedParameters)
		{
			SubjectPublicKeyInfoAsn subjectPublicKeyInfoAsn = new SubjectPublicKeyInfoAsn
			{
				Algorithm = new AlgorithmIdentifierAsn
				{
					Algorithm = "1.2.840.10040.4.1",
					Parameters = encodedParameters.ToNullableMemory()
				},
				SubjectPublicKey = encodedKeyValue
			};
			AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
			subjectPublicKeyInfoAsn.Encode(asnWriter);
			DSA dSA = DSA.Create();
			DSA dSA2 = dSA;
			try
			{
				asnWriter.Encode(dSA, delegate(DSA dsa, ReadOnlySpan<byte> encoded)
				{
					dsa.ImportSubjectPublicKeyInfo(encoded, out var _);
				});
				dSA2 = null;
				return dSA;
			}
			finally
			{
				dSA2?.Dispose();
			}
		}
	}

	internal static IX509Pal Instance { get; } = BuildSingleton();

	private static IX509Pal BuildSingleton()
	{
		return new AndroidX509Pal();
	}
}
