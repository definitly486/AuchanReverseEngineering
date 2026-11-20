using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Newtonsoft.Json.Bson;

internal class AsyncBinaryWriter : BinaryWriter
{
	private static readonly byte[] ByteValueBuffer = new byte[19]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
		10, 11, 12, 13, 14, 15, 16, 17, 18
	};

	private byte[] _buffer;

	private byte[] Buffer => _buffer ?? (_buffer = new byte[8]);

	public AsyncBinaryWriter(Stream stream)
		: base(stream)
	{
	}

	public Task FlushAsync(CancellationToken cancellationToken)
	{
		return OutStream.FlushAsync(cancellationToken);
	}

	public Task WriteAsync(bool value, CancellationToken cancellationToken)
	{
		return OutStream.WriteAsync(ByteValueBuffer, value ? 1 : 0, 1, cancellationToken);
	}

	public Task WriteAsync(int value, CancellationToken cancellationToken)
	{
		byte[] buffer = Buffer;
		buffer[0] = (byte)value;
		buffer[1] = (byte)(value >> 8);
		buffer[2] = (byte)(value >> 16);
		buffer[3] = (byte)(value >> 24);
		return OutStream.WriteAsync(buffer, 0, 4, cancellationToken);
	}

	public Task WriteAsync(long value, CancellationToken cancellationToken)
	{
		byte[] buffer = Buffer;
		buffer[0] = (byte)value;
		buffer[1] = (byte)(value >> 8);
		buffer[2] = (byte)(value >> 16);
		buffer[3] = (byte)(value >> 24);
		buffer[4] = (byte)(value >> 32);
		buffer[5] = (byte)(value >> 40);
		buffer[6] = (byte)(value >> 48);
		buffer[7] = (byte)(value >> 56);
		return OutStream.WriteAsync(buffer, 0, 8, cancellationToken);
	}

	public Task WriteAsync(byte value, CancellationToken cancellationToken)
	{
		return OutStream.WriteAsync(ByteValueBuffer, value, 1, cancellationToken);
	}

	public Task WriteAsync(double value, CancellationToken cancellationToken)
	{
		return WriteAsync(BitConverter.DoubleToInt64Bits(value), cancellationToken);
	}

	public Task WriteAsync(byte[] buffer, CancellationToken cancellationToken)
	{
		return OutStream.WriteAsync(buffer, 0, buffer.Length, cancellationToken);
	}

	public Task WriteAsync(byte[] buffer, int index, int count, CancellationToken cancellationToken)
	{
		return OutStream.WriteAsync(buffer, index, count, cancellationToken);
	}
}
