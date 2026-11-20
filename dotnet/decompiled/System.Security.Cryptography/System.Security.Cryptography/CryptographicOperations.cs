using System.Runtime.CompilerServices;
using Internal.Cryptography;

namespace System.Security.Cryptography;

public static class CryptographicOperations
{
	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static bool FixedTimeEquals(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
	{
		if (left.Length != right.Length)
		{
			return false;
		}
		int length = left.Length;
		int num = 0;
		for (int i = 0; i < length; i++)
		{
			num |= left[i] - right[i];
		}
		return num == 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void ZeroMemory(Span<byte> buffer)
	{
		buffer.Clear();
	}

	public static byte[] HashData(HashAlgorithmName hashAlgorithm, ReadOnlySpan<byte> source)
	{
		byte[] array = new byte[CheckHashAndGetLength(hashAlgorithm)];
		HashProviderDispenser.OneShotHashProvider.HashData(hashAlgorithm.Name, source, array);
		return array;
	}

	public static int HashData(HashAlgorithmName hashAlgorithm, ReadOnlySpan<byte> source, Span<byte> destination)
	{
		if (!TryHashData(hashAlgorithm, source, destination, out var bytesWritten))
		{
			throw new ArgumentException("Argument_DestinationTooShort", "destination");
		}
		return bytesWritten;
	}

	public static bool TryHashData(HashAlgorithmName hashAlgorithm, ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
	{
		int num = CheckHashAndGetLength(hashAlgorithm);
		if (destination.Length < num)
		{
			bytesWritten = 0;
			return false;
		}
		bytesWritten = HashProviderDispenser.OneShotHashProvider.HashData(hashAlgorithm.Name, source, destination);
		return true;
	}

	private static int CheckHashAndGetLength(HashAlgorithmName hashAlgorithm)
	{
		ArgumentException.ThrowIfNullOrEmpty(hashAlgorithm.Name, "hashAlgorithm");
		switch (hashAlgorithm.Name)
		{
		case "SHA256":
			return 32;
		case "SHA1":
			return 20;
		case "SHA512":
			return 64;
		case "SHA384":
			return 48;
		case "SHA3-256":
			if (!HashProviderDispenser.HashSupported("SHA3-256"))
			{
				throw new PlatformNotSupportedException();
			}
			return 32;
		case "SHA3-384":
			if (!HashProviderDispenser.HashSupported("SHA3-384"))
			{
				throw new PlatformNotSupportedException();
			}
			return 48;
		case "SHA3-512":
			if (!HashProviderDispenser.HashSupported("SHA3-512"))
			{
				throw new PlatformNotSupportedException();
			}
			return 64;
		case "MD5":
			if (Helpers.HasMD5)
			{
				return 16;
			}
			break;
		}
		throw new CryptographicException(System.SR.Format("Cryptography_UnknownHashAlgorithm", hashAlgorithm.Name));
	}
}
