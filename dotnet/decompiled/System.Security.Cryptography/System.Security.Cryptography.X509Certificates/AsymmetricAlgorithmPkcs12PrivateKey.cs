namespace System.Security.Cryptography.X509Certificates;

internal sealed class AsymmetricAlgorithmPkcs12PrivateKey : Pkcs12Key
{
	private readonly AsymmetricAlgorithm _key;

	internal override AsymmetricAlgorithm Key => _key;

	internal AsymmetricAlgorithmPkcs12PrivateKey(ReadOnlySpan<byte> pkcs8, Func<AsymmetricAlgorithm> factory)
	{
		_key = factory();
		try
		{
			_key.ImportPkcs8PrivateKey(pkcs8, out var _);
		}
		catch (Exception ex)
		{
			_key.Dispose();
			if (ex is PlatformNotSupportedException inner)
			{
				throw new CryptographicException("Cryptography_NotValidPrivateKey", inner);
			}
			throw;
		}
	}

	internal override bool TryExportSubjectPublicKeyInfo(Span<byte> destination, out int bytesWritten)
	{
		return _key.TryExportSubjectPublicKeyInfo(destination, out bytesWritten);
	}
}
