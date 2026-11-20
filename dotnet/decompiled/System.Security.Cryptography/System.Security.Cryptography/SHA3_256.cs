namespace System.Security.Cryptography;

public abstract class SHA3_256 : HashAlgorithm
{
	public static bool IsSupported { get; } = HashProviderDispenser.HashSupported("SHA3-256");

	public static byte[] HashData(ReadOnlySpan<byte> source)
	{
		byte[] array = new byte[32];
		HashData(source, array.AsSpan());
		return array;
	}

	public static int HashData(ReadOnlySpan<byte> source, Span<byte> destination)
	{
		if (!TryHashData(source, destination, out var bytesWritten))
		{
			throw new ArgumentException("Argument_DestinationTooShort", "destination");
		}
		return bytesWritten;
	}

	public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
	{
		CheckSha3Support();
		if (destination.Length < 32)
		{
			bytesWritten = 0;
			return false;
		}
		bytesWritten = HashProviderDispenser.OneShotHashProvider.HashData("SHA3-256", source, destination);
		return true;
	}

	private static void CheckSha3Support()
	{
		if (!IsSupported)
		{
			throw new PlatformNotSupportedException();
		}
	}
}
