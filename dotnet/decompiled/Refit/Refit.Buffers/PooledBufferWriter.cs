using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Refit.Buffers;

internal sealed class PooledBufferWriter : IBufferWriter<byte>, IDisposable
{
	private sealed class PooledMemoryStream : Stream
	{
		private readonly int length;

		private byte[]? pooledBuffer;

		private int position;

		public override bool CanRead => true;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length => length;

		public override long Position
		{
			get
			{
				return position;
			}
			set
			{
				ThrowNotSupportedException();
			}
		}

		public PooledMemoryStream(PooledBufferWriter writer)
		{
			length = writer.position;
			pooledBuffer = writer.buffer;
		}

		~PooledMemoryStream()
		{
			Dispose(disposing: true);
		}

		public override void Flush()
		{
		}

		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled(cancellationToken);
			}
			return Task.CompletedTask;
		}

		public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled(cancellationToken);
			}
			try
			{
				return CopyToInternalAsync(destination, cancellationToken);
			}
			catch (OperationCanceledException ex)
			{
				return Task.FromCanceled(ex.CancellationToken);
			}
			catch (Exception exception)
			{
				return Task.FromException(exception);
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (offset < 0)
			{
				ThrowArgumentOutOfRangeExceptionForNegativeOffset();
			}
			if (count < 0)
			{
				ThrowArgumentOutOfRangeExceptionForNegativeCount();
			}
			if (offset + count > buffer.Length)
			{
				ThrowArgumentOutOfRangeExceptionForEndOfStreamReached();
			}
			if (pooledBuffer == null)
			{
				ThrowObjectDisposedException();
			}
			Span<byte> destination = buffer.AsSpan(offset, count);
			Span<byte> span = pooledBuffer.AsSpan(0, length);
			Span<byte> span2 = span.Slice(position);
			if (span2.Length <= destination.Length)
			{
				span2.CopyTo(destination);
				position += span2.Length;
				return span2.Length;
			}
			span = span2.Slice(0, destination.Length);
			span.CopyTo(destination);
			position += destination.Length;
			return destination.Length;
		}

		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled<int>(cancellationToken);
			}
			try
			{
				return Task.FromResult(Read(buffer, offset, count));
			}
			catch (OperationCanceledException ex)
			{
				return Task.FromCanceled<int>(ex.CancellationToken);
			}
			catch (Exception exception)
			{
				return Task.FromException<int>(exception);
			}
		}

		public override int ReadByte()
		{
			if (pooledBuffer == null)
			{
				ThrowObjectDisposedException();
			}
			if (position >= pooledBuffer.Length)
			{
				return -1;
			}
			return pooledBuffer[position++];
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			ThrowNotSupportedException();
			return 0L;
		}

		public override void SetLength(long value)
		{
			ThrowNotSupportedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			ThrowNotSupportedException();
		}

		protected override void Dispose(bool disposing)
		{
			if (pooledBuffer != null)
			{
				GC.SuppressFinalize(this);
				ArrayPool<byte>.Shared.Return(pooledBuffer);
				pooledBuffer = null;
			}
		}

		public Task CopyToInternalAsync(Stream destination, CancellationToken cancellationToken)
		{
			if (pooledBuffer == null)
			{
				ThrowObjectDisposedException();
			}
			int num = length - position;
			Memory<byte> memory = pooledBuffer.AsMemory(position, num);
			position += memory.Length;
			return destination.WriteAsync(memory, cancellationToken).AsTask();
		}

		public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return new ValueTask<int>(Task.FromCanceled<int>(cancellationToken));
			}
			try
			{
				return new ValueTask<int>(Read(buffer.Span));
			}
			catch (OperationCanceledException ex)
			{
				return new ValueTask<int>(Task.FromCanceled<int>(ex.CancellationToken));
			}
			catch (Exception exception)
			{
				return new ValueTask<int>(Task.FromException<int>(exception));
			}
		}

		public override int Read(Span<byte> buffer)
		{
			if (pooledBuffer == null)
			{
				ThrowObjectDisposedException();
			}
			if (position >= length)
			{
				return 0;
			}
			int num = length - position;
			Span<byte> span = pooledBuffer.AsSpan(position, num);
			int num2 = Math.Min(span.Length, buffer.Length);
			Span<byte> destination = buffer.Slice(0, num2);
			span.CopyTo(destination);
			position += num2;
			return num2;
		}
	}

	public const int DefaultSize = 1024;

	private byte[] buffer = Array.Empty<byte>();

	private int position;

	public PooledBufferWriter()
	{
		buffer = ArrayPool<byte>.Shared.Rent(1024);
		position = 0;
	}

	public void Advance(int count)
	{
		if (count < 0)
		{
			ThrowArgumentOutOfRangeExceptionForNegativeCount();
		}
		if (position > buffer.Length - count)
		{
			ThrowArgumentOutOfRangeExceptionForAdvancedTooFar();
		}
		position += count;
	}

	public Memory<byte> GetMemory(int sizeHint = 0)
	{
		EnsureFreeCapacity(sizeHint);
		return buffer.AsMemory(position);
	}

	public Span<byte> GetSpan(int sizeHint = 0)
	{
		EnsureFreeCapacity(sizeHint);
		return buffer.AsSpan(position);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void EnsureFreeCapacity(int count)
	{
		if (count < 0)
		{
			ThrowArgumentOutOfRangeExceptionForNegativeCount();
		}
		if (count == 0)
		{
			count = 1;
		}
		int num = buffer.Length;
		int num2 = num - position;
		if (count > num2)
		{
			int num3 = Math.Max(count, num);
			int minimumLength = checked(num + num3);
			byte[] destinationArray = ArrayPool<byte>.Shared.Rent(minimumLength);
			Array.Copy(buffer, destinationArray, position);
			ArrayPool<byte>.Shared.Return(buffer);
			buffer = destinationArray;
		}
	}

	public void Dispose()
	{
		if (buffer.Length != 0)
		{
			ArrayPool<byte>.Shared.Return(buffer);
		}
	}

	public Stream DetachStream()
	{
		PooledMemoryStream result = new PooledMemoryStream(this);
		buffer = Array.Empty<byte>();
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ThrowArgumentOutOfRangeExceptionForNegativeCount()
	{
		throw new ArgumentOutOfRangeException("count", "The count can't be < 0");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ThrowArgumentOutOfRangeExceptionForNegativeOffset()
	{
		throw new ArgumentOutOfRangeException("offset", "The offset can't be < 0");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ThrowArgumentOutOfRangeExceptionForAdvancedTooFar()
	{
		throw new ArgumentOutOfRangeException("count", "Advanced too far");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ThrowArgumentOutOfRangeExceptionForEndOfStreamReached()
	{
		throw new ArgumentException("The end of the stream has been exceeded");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ThrowObjectDisposedException()
	{
		throw new ObjectDisposedException("The stream in use has alreadybeen disposed");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ThrowNotSupportedException()
	{
		throw new NotSupportedException("The stream doesn't support the requested operation");
	}
}
