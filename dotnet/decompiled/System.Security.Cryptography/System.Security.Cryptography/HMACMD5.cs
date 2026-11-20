using System.Runtime.Versioning;

namespace System.Security.Cryptography;

public class HMACMD5 : HMAC
{
	[UnsupportedOSPlatform("browser")]
	public static int HashData(ReadOnlySpan<byte> key, ReadOnlySpan<byte> source, Span<byte> destination)
	{
		if (!TryHashData(key, source, destination, out var bytesWritten))
		{
			throw new ArgumentException("Argument_DestinationTooShort", "destination");
		}
		return bytesWritten;
	}

	[UnsupportedOSPlatform("browser")]
	public static bool TryHashData(ReadOnlySpan<byte> key, ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
	{
		if (destination.Length < 16)
		{
			bytesWritten = 0;
			return false;
		}
		bytesWritten = HashProviderDispenser.OneShotHashProvider.MacData("MD5", key, source, destination);
		return true;
	}
}
