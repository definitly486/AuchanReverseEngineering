namespace System.Security.Cryptography;

public abstract class SHA1 : HashAlgorithm
{
	private sealed class Implementation : SHA1
	{
		private readonly HashProvider _hashProvider;

		public Implementation()
		{
			_hashProvider = HashProviderDispenser.CreateHashProvider("SHA1");
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

	protected SHA1()
	{
		HashSizeValue = 160;
	}

	public static SHA1 Create()
	{
		return new Implementation();
	}

	public static byte[] HashData(byte[] source)
	{
		ArgumentNullException.ThrowIfNull(source, "source");
		return HashData(new ReadOnlySpan<byte>(source));
	}

	public static byte[] HashData(ReadOnlySpan<byte> source)
	{
		byte[] array = GC.AllocateUninitializedArray<byte>(20);
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
		if (destination.Length < 20)
		{
			bytesWritten = 0;
			return false;
		}
		bytesWritten = HashProviderDispenser.OneShotHashProvider.HashData("SHA1", source, destination);
		return true;
	}
}
