using System.Formats.Asn1;
using System.Runtime.Versioning;

namespace System.Security.Cryptography;

public abstract class DSA : AsymmetricAlgorithm
{
	public abstract DSAParameters ExportParameters(bool includePrivateParameters);

	public abstract void ImportParameters(DSAParameters parameters);

	[UnsupportedOSPlatform("browser")]
	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("tvos")]
	public static DSA Create()
	{
		return CreateCore();
	}

	public override bool TryExportEncryptedPkcs8PrivateKey(ReadOnlySpan<char> password, PbeParameters pbeParameters, Span<byte> destination, out int bytesWritten)
	{
		ArgumentNullException.ThrowIfNull(pbeParameters, "pbeParameters");
		PasswordBasedEncryption.ValidatePbeParameters(pbeParameters, password, ReadOnlySpan<byte>.Empty);
		AsnWriter pkcs8Writer = WritePkcs8();
		return KeyFormatHelper.WriteEncryptedPkcs8(password, pkcs8Writer, pbeParameters).TryEncode(destination, out bytesWritten);
	}

	public override bool TryExportPkcs8PrivateKey(Span<byte> destination, out int bytesWritten)
	{
		return WritePkcs8().TryEncode(destination, out bytesWritten);
	}

	public override bool TryExportSubjectPublicKeyInfo(Span<byte> destination, out int bytesWritten)
	{
		return WriteSubjectPublicKeyInfo().TryEncode(destination, out bytesWritten);
	}

	private unsafe AsnWriter WritePkcs8()
	{
		DSAParameters dsaParameters = ExportParameters(includePrivateParameters: true);
		fixed (byte* x = dsaParameters.X)
		{
			try
			{
				return DSAKeyFormatHelper.WritePkcs8(in dsaParameters);
			}
			finally
			{
				CryptographicOperations.ZeroMemory(dsaParameters.X);
			}
		}
	}

	private AsnWriter WriteSubjectPublicKeyInfo()
	{
		return DSAKeyFormatHelper.WriteSubjectPublicKeyInfo(ExportParameters(includePrivateParameters: false));
	}

	public unsafe override void ImportPkcs8PrivateKey(ReadOnlySpan<byte> source, out int bytesRead)
	{
		DSAKeyFormatHelper.ReadPkcs8(source, out var bytesRead2, out var key);
		fixed (byte* x = key.X)
		{
			try
			{
				ImportParameters(key);
			}
			finally
			{
				CryptographicOperations.ZeroMemory(key.X);
			}
		}
		bytesRead = bytesRead2;
	}

	public override void ImportSubjectPublicKeyInfo(ReadOnlySpan<byte> source, out int bytesRead)
	{
		DSAKeyFormatHelper.ReadSubjectPublicKeyInfo(source, out var bytesRead2, out var key);
		ImportParameters(key);
		bytesRead = bytesRead2;
	}

	private static DSAImplementation.DSAAndroid CreateCore()
	{
		return new DSAImplementation.DSAAndroid();
	}
}
