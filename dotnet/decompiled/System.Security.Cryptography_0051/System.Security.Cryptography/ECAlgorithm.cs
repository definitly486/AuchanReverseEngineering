using System.Formats.Asn1;

namespace System.Security.Cryptography;

public abstract class ECAlgorithm : AsymmetricAlgorithm
{
	private static readonly string[] s_validOids = new string[1] { "1.2.840.10045.2.1" };

	private protected static readonly KeySizes[] s_defaultKeySizes = new KeySizes[2]
	{
		new KeySizes(256, 384, 128),
		new KeySizes(521, 521, 0)
	};

	public virtual ECParameters ExportParameters(bool includePrivateParameters)
	{
		throw new NotSupportedException("NotSupported_SubclassOverride");
	}

	public virtual void ImportParameters(ECParameters parameters)
	{
		throw new NotSupportedException("NotSupported_SubclassOverride");
	}

	public unsafe override bool TryExportEncryptedPkcs8PrivateKey(ReadOnlySpan<char> password, PbeParameters pbeParameters, Span<byte> destination, out int bytesWritten)
	{
		ArgumentNullException.ThrowIfNull(pbeParameters, "pbeParameters");
		PasswordBasedEncryption.ValidatePbeParameters(pbeParameters, password, ReadOnlySpan<byte>.Empty);
		ECParameters ecParameters = ExportParameters(includePrivateParameters: true);
		fixed (byte* d = ecParameters.D)
		{
			try
			{
				AsnWriter pkcs8Writer = EccKeyFormatHelper.WritePkcs8PrivateKey(ecParameters);
				return KeyFormatHelper.WriteEncryptedPkcs8(password, pkcs8Writer, pbeParameters).TryEncode(destination, out bytesWritten);
			}
			finally
			{
				CryptographicOperations.ZeroMemory(ecParameters.D);
			}
		}
	}

	public unsafe override bool TryExportPkcs8PrivateKey(Span<byte> destination, out int bytesWritten)
	{
		ECParameters ecParameters = ExportParameters(includePrivateParameters: true);
		fixed (byte* d = ecParameters.D)
		{
			try
			{
				return EccKeyFormatHelper.WritePkcs8PrivateKey(ecParameters).TryEncode(destination, out bytesWritten);
			}
			finally
			{
				CryptographicOperations.ZeroMemory(ecParameters.D);
			}
		}
	}

	public override bool TryExportSubjectPublicKeyInfo(Span<byte> destination, out int bytesWritten)
	{
		return EccKeyFormatHelper.WriteSubjectPublicKeyInfo(ExportParameters(includePrivateParameters: false)).TryEncode(destination, out bytesWritten);
	}

	public unsafe override void ImportPkcs8PrivateKey(ReadOnlySpan<byte> source, out int bytesRead)
	{
		KeyFormatHelper.ReadPkcs8(s_validOids, source, (KeyFormatHelper.KeyReader<ECParameters>)EccKeyFormatHelper.FromECPrivateKey, out int bytesRead2, out ECParameters ret);
		fixed (byte* d = ret.D)
		{
			try
			{
				ImportParameters(ret);
				bytesRead = bytesRead2;
			}
			finally
			{
				CryptographicOperations.ZeroMemory(ret.D);
			}
		}
	}

	public override void ImportSubjectPublicKeyInfo(ReadOnlySpan<byte> source, out int bytesRead)
	{
		KeyFormatHelper.ReadSubjectPublicKeyInfo(s_validOids, source, (KeyFormatHelper.KeyReader<ECParameters>)EccKeyFormatHelper.FromECPublicKey, out int bytesRead2, out ECParameters ret);
		ImportParameters(ret);
		bytesRead = bytesRead2;
	}
}
