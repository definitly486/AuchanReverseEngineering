using System.Diagnostics.CodeAnalysis;

namespace System.Security.Cryptography;

public abstract class AsymmetricAlgorithm : IDisposable
{
	private delegate bool TryExportPbe<T>(ReadOnlySpan<T> password, PbeParameters pbeParameters, Span<byte> destination, out int bytesWritten);

	private delegate bool TryExport(Span<byte> destination, out int bytesWritten);

	protected int KeySizeValue;

	[MaybeNull]
	protected KeySizes[] LegalKeySizesValue;

	public virtual int KeySize
	{
		get
		{
			return KeySizeValue;
		}
		set
		{
			if (!value.IsLegalSize(LegalKeySizes))
			{
				throw new CryptographicException("Cryptography_InvalidKeySize");
			}
			KeySizeValue = value;
		}
	}

	public virtual KeySizes[] LegalKeySizes => (KeySizes[])LegalKeySizesValue.Clone();

	public void Clear()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void Dispose()
	{
		Clear();
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public virtual void ImportPkcs8PrivateKey(ReadOnlySpan<byte> source, out int bytesRead)
	{
		throw new NotImplementedException("NotSupported_SubclassOverride");
	}

	public virtual void ImportSubjectPublicKeyInfo(ReadOnlySpan<byte> source, out int bytesRead)
	{
		throw new NotImplementedException("NotSupported_SubclassOverride");
	}

	public virtual byte[] ExportEncryptedPkcs8PrivateKey(ReadOnlySpan<char> password, PbeParameters pbeParameters)
	{
		return ExportArray(password, pbeParameters, TryExportEncryptedPkcs8PrivateKey);
	}

	public virtual byte[] ExportPkcs8PrivateKey()
	{
		return ExportArray(TryExportPkcs8PrivateKey);
	}

	public virtual bool TryExportEncryptedPkcs8PrivateKey(ReadOnlySpan<char> password, PbeParameters pbeParameters, Span<byte> destination, out int bytesWritten)
	{
		throw new NotImplementedException("NotSupported_SubclassOverride");
	}

	public virtual bool TryExportPkcs8PrivateKey(Span<byte> destination, out int bytesWritten)
	{
		throw new NotImplementedException("NotSupported_SubclassOverride");
	}

	public virtual bool TryExportSubjectPublicKeyInfo(Span<byte> destination, out int bytesWritten)
	{
		throw new NotImplementedException("NotSupported_SubclassOverride");
	}

	private unsafe static byte[] ExportArray<T>(ReadOnlySpan<T> password, PbeParameters pbeParameters, TryExportPbe<T> exporter)
	{
		int minimumLength = 4096;
		while (true)
		{
			byte[] array = System.Security.Cryptography.CryptoPool.Rent(minimumLength);
			int bytesWritten = 0;
			minimumLength = array.Length;
			fixed (byte* ptr = array)
			{
				try
				{
					if (exporter(password, pbeParameters, array, out bytesWritten))
					{
						return new ReadOnlySpan<byte>(array, 0, bytesWritten).ToArray();
					}
				}
				finally
				{
					System.Security.Cryptography.CryptoPool.Return(array, bytesWritten);
				}
				minimumLength = checked(minimumLength * 2);
			}
		}
	}

	private unsafe static byte[] ExportArray(TryExport exporter)
	{
		int minimumLength = 4096;
		while (true)
		{
			byte[] array = System.Security.Cryptography.CryptoPool.Rent(minimumLength);
			int bytesWritten = 0;
			minimumLength = array.Length;
			fixed (byte* ptr = array)
			{
				try
				{
					if (exporter(array, out bytesWritten))
					{
						return new ReadOnlySpan<byte>(array, 0, bytesWritten).ToArray();
					}
				}
				finally
				{
					System.Security.Cryptography.CryptoPool.Return(array, bytesWritten);
				}
				minimumLength = checked(minimumLength * 2);
			}
		}
	}
}
