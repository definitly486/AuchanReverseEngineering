namespace System.Security.Cryptography;

public abstract class SHA384 : HashAlgorithm
{
	public static byte[] HashData(ReadOnlySpan<byte> source)
	{
		byte[] array = GC.AllocateUninitializedArray<byte>(48);
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
		if (destination.Length < 48)
		{
			bytesWritten = 0;
			return false;
		}
		bytesWritten = HashProviderDispenser.OneShotHashProvider.HashData("SHA384", source, destination);
		return true;
	}
}
