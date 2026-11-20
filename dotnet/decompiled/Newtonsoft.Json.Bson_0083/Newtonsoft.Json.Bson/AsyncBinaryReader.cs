using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Newtonsoft.Json.Bson;

internal class AsyncBinaryReader : BinaryReader
{
	private byte[] _buffer;

	private byte[] Buffer => _buffer ?? (_buffer = new byte[16]);

	public AsyncBinaryReader(Stream input)
		: base(input)
	{
	}

	private void EndOfStream()
	{
		throw new EndOfStreamException("Unable to read beyond the end of the stream.");
	}

	private void FileNotOpen()
	{
		throw new ObjectDisposedException("Cannot access a closed file.");
	}

	private async Task<byte[]> ReadBufferAsync(int size, CancellationToken cancellationToken)
	{
		byte[] buffer = Buffer;
		int offset = 0;
		if (BaseStream == null)
		{
			FileNotOpen();
		}
		do
		{
			int num = await BaseStream.ReadAsync(buffer, offset, size, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (num == 0)
			{
				EndOfStream();
			}
			offset += num;
			size -= num;
		}
		while (size > 0);
		return buffer;
	}

	public async Task<byte> ReadByteAsync(CancellationToken cancellationToken)
	{
		return (await ReadBufferAsync(1, cancellationToken).ConfigureAwait(continueOnCapturedContext: false))[0];
	}

	public async Task<long> ReadInt64Async(CancellationToken cancellationToken)
	{
		byte[] array = await ReadBufferAsync(8, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		uint num = (uint)(array[0] | (array[1] << 8) | (array[2] << 16) | (array[3] << 24));
		return (long)(((ulong)(uint)(array[4] | (array[5] << 8) | (array[6] << 16) | (array[7] << 24)) << 32) | num);
	}

	public async Task<int> ReadInt32Async(CancellationToken cancellationToken)
	{
		byte[] array = await ReadBufferAsync(4, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		return array[0] | (array[1] << 8) | (array[2] << 16) | (array[3] << 24);
	}

	public async Task<double> ReadDoubleAsync(CancellationToken cancellationToken)
	{
		byte[] array = await ReadBufferAsync(8, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		uint num = (uint)(array[0] | (array[1] << 8) | (array[2] << 16) | (array[3] << 24));
		return BitConverter.Int64BitsToDouble((long)(((ulong)(uint)(array[4] | (array[5] << 8) | (array[6] << 16) | (array[7] << 24)) << 32) | num));
	}

	public Task<int> ReadAsync(byte[] buffer, int index, int count, CancellationToken cancellationToken)
	{
		Stream baseStream = BaseStream;
		if (baseStream == null)
		{
			FileNotOpen();
		}
		return baseStream.ReadAsync(buffer, index, count, cancellationToken);
	}

	public async Task<byte[]> ReadBytesAsync(int count, CancellationToken cancellationToken)
	{
		Stream stream = BaseStream;
		if (stream == null)
		{
			FileNotOpen();
		}
		if (count == 0)
		{
			return new byte[0];
		}
		byte[] result = new byte[count];
		int numRead = 0;
		do
		{
			int num = await stream.ReadAsync(result, numRead, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (num == 0)
			{
				break;
			}
			numRead += num;
			count -= num;
		}
		while (count > 0);
		if (numRead != result.Length)
		{
			byte[] array = new byte[numRead];
			result.CopyTo(array, 0);
			return array;
		}
		return result;
	}
}
