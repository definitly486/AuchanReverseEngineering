namespace System.Security.Cryptography;

public abstract class SHA512 : HashAlgorithm
{
	public static byte[] HashData(byte[] source)
	{
		ArgumentNullException.ThrowIfNull(source, "source");
		return HashData(new ReadOnlySpan<byte>(source));
	}

	public static byte[] HashData(ReadOnlySpan<byte> source)
	{
		byte[] array = GC.AllocateUninitializedArray<byte>(64);
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
		if (destination.Length < 64)
		{
			bytesWritten = 0;
			return false;
		}
		bytesWritten = HashProviderDispenser.OneShotHashProvider.HashData("SHA512", source, destination);
		return true;
	}
}
