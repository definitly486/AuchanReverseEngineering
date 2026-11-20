namespace System.Security.Cryptography;

internal abstract class HashProvider : IDisposable
{
	public abstract int HashSizeInBytes { get; }

	public void AppendHashData(byte[] data, int offset, int count)
	{
		ArgumentNullException.ThrowIfNull(data, "data");
		ArgumentOutOfRangeException.ThrowIfNegative(offset, "offset");
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		if (data.Length - offset < count)
		{
			throw new ArgumentException("Argument_InvalidOffLen");
		}
		AppendHashData(new ReadOnlySpan<byte>(data, offset, count));
	}

	public abstract void AppendHashData(ReadOnlySpan<byte> data);

	public abstract int FinalizeHashAndReset(Span<byte> destination);

	public byte[] FinalizeHashAndReset()
	{
		byte[] array = new byte[HashSizeInBytes];
		FinalizeHashAndReset(array);
		return array;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public abstract void Dispose(bool disposing);

	public abstract void Reset();
}
