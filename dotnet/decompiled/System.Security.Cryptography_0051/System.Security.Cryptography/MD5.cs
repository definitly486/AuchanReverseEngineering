using System.Runtime.Versioning;

namespace System.Security.Cryptography;

public abstract class MD5 : HashAlgorithm
{
	private sealed class Implementation : MD5
	{
		private readonly HashProvider _hashProvider;

		public Implementation()
		{
			_hashProvider = HashProviderDispenser.CreateHashProvider("MD5");
			HashSizeValue = _hashProvider.HashSizeInBytes * 8;
		}

		protected sealed override void HashCore(byte[] array, int ibStart, int cbSize)
		{
			_hashProvider.AppendHashData(array, ibStart, cbSize);
		}

		protected sealed override byte[] HashFinal()
		{
			return _hashProvider.FinalizeHashAndReset();
		}

		public sealed override void Initialize()
		{
			_hashProvider.Reset();
		}

		protected sealed override void Dispose(bool disposing)
		{
			_hashProvider.Dispose(disposing);
			base.Dispose(disposing);
		}
	}

	protected MD5()
	{
		HashSizeValue = 128;
	}

	[UnsupportedOSPlatform("browser")]
	public static MD5 Create()
	{
		return new Implementation();
	}

	[UnsupportedOSPlatform("browser")]
	public static byte[] HashData(byte[] source)
	{
		ArgumentNullException.ThrowIfNull(source, "source");
		return HashData(new ReadOnlySpan<byte>(source));
	}

	[UnsupportedOSPlatform("browser")]
	public static byte[] HashData(ReadOnlySpan<byte> source)
	{
		byte[] array = GC.AllocateUninitializedArray<byte>(16);
		HashData(source, array.AsSpan());
		return array;
	}

	[UnsupportedOSPlatform("browser")]
	public static int HashData(ReadOnlySpan<byte> source, Span<byte> destination)
	{
		if (!TryHashData(source, destination, out var bytesWritten))
		{
			throw new ArgumentException("Argument_DestinationTooShort", "destination");
		}
		return bytesWritten;
	}

	[UnsupportedOSPlatform("browser")]
	public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
	{
		if (destination.Length < 16)
		{
			bytesWritten = 0;
			return false;
		}
		bytesWritten = HashProviderDispenser.OneShotHashProvider.HashData("MD5", source, destination);
		return true;
	}
}
