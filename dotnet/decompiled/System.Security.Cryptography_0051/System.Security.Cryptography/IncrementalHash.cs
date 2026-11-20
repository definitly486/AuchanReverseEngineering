namespace System.Security.Cryptography;

public sealed class IncrementalHash : IDisposable
{
	private readonly HashAlgorithmName _algorithmName;

	private HashProvider _hash;

	private HMACCommon _hmac;

	private bool _disposed;

	public int HashLengthInBytes { get; }

	private IncrementalHash(HashAlgorithmName name, HashProvider hash)
	{
		_algorithmName = name;
		_hash = hash;
		HashLengthInBytes = _hash.HashSizeInBytes;
	}

	private IncrementalHash(HashAlgorithmName name, HMACCommon hmac)
	{
		_algorithmName = new HashAlgorithmName("HMAC" + name.Name);
		_hmac = hmac;
		HashLengthInBytes = _hmac.HashSizeInBytes;
	}

	public void AppendData(byte[] data)
	{
		ArgumentNullException.ThrowIfNull(data, "data");
		AppendData(new ReadOnlySpan<byte>(data));
	}

	public void AppendData(ReadOnlySpan<byte> data)
	{
		ObjectDisposedException.ThrowIf(_disposed, this);
		if (_hash != null)
		{
			_hash.AppendHashData(data);
		}
		else
		{
			_hmac.AppendHashData(data);
		}
	}

	public byte[] GetHashAndReset()
	{
		ObjectDisposedException.ThrowIf(_disposed, this);
		byte[] array = new byte[HashLengthInBytes];
		GetHashAndResetCore(array);
		return array;
	}

	public int GetHashAndReset(Span<byte> destination)
	{
		ObjectDisposedException.ThrowIf(_disposed, this);
		if (destination.Length < HashLengthInBytes)
		{
			throw new ArgumentException("Argument_DestinationTooShort", "destination");
		}
		return GetHashAndResetCore(destination);
	}

	public bool TryGetHashAndReset(Span<byte> destination, out int bytesWritten)
	{
		ObjectDisposedException.ThrowIf(_disposed, this);
		if (destination.Length < HashLengthInBytes)
		{
			bytesWritten = 0;
			return false;
		}
		bytesWritten = GetHashAndResetCore(destination);
		return true;
	}

	private int GetHashAndResetCore(Span<byte> destination)
	{
		if (_hash == null)
		{
			return _hmac.FinalizeHashAndReset(destination);
		}
		return _hash.FinalizeHashAndReset(destination);
	}

	public void Dispose()
	{
		_disposed = true;
		if (_hash != null)
		{
			_hash.Dispose();
			_hash = null;
		}
		if (_hmac != null)
		{
			_hmac.Dispose(disposing: true);
			_hmac = null;
		}
	}

	public static IncrementalHash CreateHash(HashAlgorithmName hashAlgorithm)
	{
		ArgumentException.ThrowIfNullOrEmpty(hashAlgorithm.Name, "hashAlgorithm");
		CheckSha3Support(hashAlgorithm.Name);
		return new IncrementalHash(hashAlgorithm, HashProviderDispenser.CreateHashProvider(hashAlgorithm.Name));
	}

	public static IncrementalHash CreateHMAC(HashAlgorithmName hashAlgorithm, byte[] key)
	{
		ArgumentNullException.ThrowIfNull(key, "key");
		return CreateHMAC(hashAlgorithm, (ReadOnlySpan<byte>)key);
	}

	public static IncrementalHash CreateHMAC(HashAlgorithmName hashAlgorithm, ReadOnlySpan<byte> key)
	{
		ArgumentException.ThrowIfNullOrEmpty(hashAlgorithm.Name, "hashAlgorithm");
		CheckSha3Support(hashAlgorithm.Name);
		return new IncrementalHash(hashAlgorithm, new HMACCommon(hashAlgorithm.Name, key, -1));
	}

	private static void CheckSha3Support(string hashAlgorithmName)
	{
		switch (hashAlgorithmName)
		{
		case "SHA3-256":
			if (!SHA3_256.IsSupported)
			{
				throw new PlatformNotSupportedException();
			}
			break;
		case "SHA3-384":
			if (!SHA3_384.IsSupported)
			{
				throw new PlatformNotSupportedException();
			}
			break;
		case "SHA3-512":
			if (!SHA3_512.IsSupported)
			{
				throw new PlatformNotSupportedException();
			}
			break;
		}
	}
}
