using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.IO;

public sealed class RecyclableMemoryStream : MemoryStream, IBufferWriter<byte>
{
	private struct BlockAndOffset
	{
		public int Block;

		public int Offset;

		public BlockAndOffset(int block, int offset)
		{
			Block = block;
			Offset = offset;
		}
	}

	private readonly List<byte[]> blocks;

	private readonly Guid id;

	private readonly RecyclableMemoryStreamManager memoryManager;

	private readonly string? tag;

	private readonly long creationTimestamp;

	private List<byte[]>? dirtyBuffers;

	private bool disposed;

	private byte[]? largeBuffer;

	private long length;

	private long position;

	private byte[]? bufferWriterTempBuffer;

	internal Guid Id
	{
		get
		{
			CheckDisposed();
			return id;
		}
	}

	internal string? Tag
	{
		get
		{
			CheckDisposed();
			return tag;
		}
	}

	internal RecyclableMemoryStreamManager MemoryManager
	{
		get
		{
			CheckDisposed();
			return memoryManager;
		}
	}

	internal string? AllocationStack { get; }

	internal string? DisposeStack { get; private set; }

	public override int Capacity
	{
		get
		{
			CheckDisposed();
			if (largeBuffer != null)
			{
				return largeBuffer.Length;
			}
			long num = (long)blocks.Count * (long)memoryManager.options.BlockSize;
			if (num > int.MaxValue)
			{
				throw new InvalidOperationException("Capacity is larger than int.MaxValue. Use Capacity64 instead.");
			}
			return (int)num;
		}
		set
		{
			Capacity64 = value;
		}
	}

	public long Capacity64
	{
		get
		{
			CheckDisposed();
			if (largeBuffer != null)
			{
				return largeBuffer.Length;
			}
			return (long)blocks.Count * (long)memoryManager.options.BlockSize;
		}
		set
		{
			CheckDisposed();
			EnsureCapacity(value);
		}
	}

	public override long Length
	{
		get
		{
			CheckDisposed();
			return length;
		}
	}

	public override long Position
	{
		get
		{
			CheckDisposed();
			return position;
		}
		set
		{
			CheckDisposed();
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value", "value must be non-negative.");
			}
			if (largeBuffer != null && value > 2147483591)
			{
				throw new InvalidOperationException($"Once the stream is converted to a single large buffer, position cannot be set past {2147483591}.");
			}
			position = value;
		}
	}

	public override bool CanRead => !Disposed;

	public override bool CanSeek => !Disposed;

	public override bool CanTimeout => false;

	public override bool CanWrite => !Disposed;

	private bool Disposed => disposed;

	public RecyclableMemoryStream(RecyclableMemoryStreamManager memoryManager)
		: this(memoryManager, Guid.NewGuid(), null, 0L, null)
	{
	}

	internal RecyclableMemoryStream(RecyclableMemoryStreamManager memoryManager, Guid id, string? tag, long requestedSize, byte[]? initialLargeBuffer)
		: base(Array.Empty<byte>())
	{
		this.memoryManager = memoryManager;
		this.id = id;
		this.tag = tag;
		blocks = new List<byte[]>();
		creationTimestamp = Stopwatch.GetTimestamp();
		long num = Math.Max(requestedSize, this.memoryManager.options.BlockSize);
		if (initialLargeBuffer == null)
		{
			EnsureCapacity(num);
		}
		else
		{
			largeBuffer = initialLargeBuffer;
		}
		if (this.memoryManager.options.GenerateCallStacks)
		{
			AllocationStack = Environment.StackTrace;
		}
		this.memoryManager.ReportStreamCreated(this.id, this.tag, requestedSize, num);
		this.memoryManager.ReportUsageReport();
	}

	~RecyclableMemoryStream()
	{
		Dispose(disposing: false);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposed)
		{
			string disposeStack = null;
			if (memoryManager.options.GenerateCallStacks)
			{
				disposeStack = Environment.StackTrace;
			}
			memoryManager.ReportStreamDoubleDisposed(id, tag, AllocationStack, DisposeStack, disposeStack);
			return;
		}
		disposed = true;
		TimeSpan lifetime = TimeSpan.FromTicks((Stopwatch.GetTimestamp() - creationTimestamp) * 10000000 / Stopwatch.Frequency);
		if (memoryManager.options.GenerateCallStacks)
		{
			DisposeStack = Environment.StackTrace;
		}
		memoryManager.ReportStreamDisposed(id, tag, lifetime, AllocationStack, DisposeStack);
		if (disposing)
		{
			GC.SuppressFinalize(this);
		}
		else
		{
			memoryManager.ReportStreamFinalized(id, tag, AllocationStack);
			if (!AppDomain.CurrentDomain.IsFinalizingForUnload())
			{
			}
		}
		memoryManager.ReportStreamLength(length);
		if (largeBuffer != null)
		{
			memoryManager.ReturnLargeBuffer(largeBuffer, id, tag);
		}
		if (dirtyBuffers != null)
		{
			foreach (byte[] dirtyBuffer in dirtyBuffers)
			{
				memoryManager.ReturnLargeBuffer(dirtyBuffer, id, tag);
			}
		}
		memoryManager.ReturnBlocks(blocks, id, tag);
		memoryManager.ReportUsageReport();
		blocks.Clear();
		base.Dispose(disposing);
	}

	public override void Close()
	{
		Dispose(disposing: true);
	}

	public override byte[] GetBuffer()
	{
		CheckDisposed();
		if (largeBuffer != null)
		{
			return largeBuffer;
		}
		if (blocks.Count == 1)
		{
			return blocks[0];
		}
		byte[] buffer = memoryManager.GetLargeBuffer(Capacity64, id, tag);
		AssertLengthIsSmall();
		InternalRead(buffer, 0, (int)length, 0L);
		largeBuffer = buffer;
		if (blocks.Count > 0 && memoryManager.options.AggressiveBufferReturn)
		{
			memoryManager.ReturnBlocks(blocks, id, tag);
			blocks.Clear();
		}
		return largeBuffer;
	}

	public override void CopyTo(Stream destination, int bufferSize)
	{
		WriteTo(destination, position, length - position);
	}

	public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
	{
		if (destination == null)
		{
			throw new ArgumentNullException("destination");
		}
		CheckDisposed();
		if (length == 0L)
		{
			return Task.CompletedTask;
		}
		long num = position;
		long num2 = length - num;
		position += num2;
		if (destination is MemoryStream stream)
		{
			WriteTo(stream, num, num2);
			return Task.CompletedTask;
		}
		if (largeBuffer == null)
		{
			if (blocks.Count == 1)
			{
				AssertLengthIsSmall();
				return destination.WriteAsync(blocks[0], (int)num, (int)num2, cancellationToken);
			}
			return CopyToAsyncImpl(destination, GetBlockAndRelativeOffset(num), num2, blocks, cancellationToken);
		}
		AssertLengthIsSmall();
		return destination.WriteAsync(largeBuffer, (int)num, (int)num2, cancellationToken);
		static async Task CopyToAsyncImpl(Stream stream2, BlockAndOffset blockAndOffset, long count, List<byte[]> blocks, CancellationToken cancellationToken2)
		{
			long bytesRemaining = count;
			int currentBlock = blockAndOffset.Block;
			int num3 = blockAndOffset.Offset;
			while (bytesRemaining > 0)
			{
				byte[] array = blocks[currentBlock];
				int amountToCopy = (int)Math.Min(array.Length - num3, bytesRemaining);
				await stream2.WriteAsync(array, num3, amountToCopy, cancellationToken2);
				bytesRemaining -= amountToCopy;
				int num4 = currentBlock + 1;
				currentBlock = num4;
				num3 = 0;
			}
		}
	}

	public void Advance(int count)
	{
		CheckDisposed();
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count", "count must be non-negative.");
		}
		byte[] array = bufferWriterTempBuffer;
		if (array != null)
		{
			if (count > array.Length)
			{
				throw new InvalidOperationException($"Cannot advance past the end of the buffer, which has a size of {array.Length}.");
			}
			Write(array, 0, count);
			ReturnTempBuffer(array);
			bufferWriterTempBuffer = null;
		}
		else
		{
			long num = ((largeBuffer == null) ? (memoryManager.options.BlockSize - GetBlockAndRelativeOffset(position).Offset) : (largeBuffer.Length - position));
			if (count > num)
			{
				throw new InvalidOperationException($"Cannot advance past the end of the buffer, which has a size of {num}.");
			}
			position += count;
			length = Math.Max(position, length);
		}
	}

	private void ReturnTempBuffer(byte[] buffer)
	{
		if (buffer.Length == memoryManager.options.BlockSize)
		{
			memoryManager.ReturnBlock(buffer, id, tag);
		}
		else
		{
			memoryManager.ReturnLargeBuffer(buffer, id, tag);
		}
	}

	public Memory<byte> GetMemory(int sizeHint = 0)
	{
		return GetWritableBuffer(sizeHint);
	}

	public Span<byte> GetSpan(int sizeHint = 0)
	{
		return GetWritableBuffer(sizeHint);
	}

	private ArraySegment<byte> GetWritableBuffer(int sizeHint)
	{
		CheckDisposed();
		if (sizeHint < 0)
		{
			throw new ArgumentOutOfRangeException("sizeHint", "sizeHint must be non-negative.");
		}
		int num = Math.Max(sizeHint, 1);
		EnsureCapacity(position + num);
		if (bufferWriterTempBuffer != null)
		{
			ReturnTempBuffer(bufferWriterTempBuffer);
			bufferWriterTempBuffer = null;
		}
		if (largeBuffer != null)
		{
			return new ArraySegment<byte>(largeBuffer, (int)position, largeBuffer.Length - (int)position);
		}
		BlockAndOffset blockAndRelativeOffset = GetBlockAndRelativeOffset(position);
		if (MemoryManager.options.BlockSize - blockAndRelativeOffset.Offset >= num)
		{
			return new ArraySegment<byte>(blocks[blockAndRelativeOffset.Block], blockAndRelativeOffset.Offset, MemoryManager.options.BlockSize - blockAndRelativeOffset.Offset);
		}
		bufferWriterTempBuffer = ((num > memoryManager.options.BlockSize) ? memoryManager.GetLargeBuffer(num, id, tag) : memoryManager.GetBlock());
		return new ArraySegment<byte>(bufferWriterTempBuffer);
	}

	public override bool TryGetBuffer(out ArraySegment<byte> buffer)
	{
		CheckDisposed();
		try
		{
			if (length <= 2147483591)
			{
				buffer = new ArraySegment<byte>(GetBuffer(), 0, (int)Length);
				return true;
			}
		}
		catch (OutOfMemoryException)
		{
		}
		buffer = ArraySegment<byte>.Empty;
		return false;
	}

	[Obsolete("This method has degraded performance vs. GetBuffer and should be avoided.")]
	public override byte[] ToArray()
	{
		CheckDisposed();
		string stack = (memoryManager.options.GenerateCallStacks ? Environment.StackTrace : null);
		memoryManager.ReportStreamToArray(id, tag, stack, length);
		if (memoryManager.options.ThrowExceptionOnToArray)
		{
			throw new NotSupportedException("The underlying RecyclableMemoryStreamManager is configured to not allow calls to ToArray.");
		}
		byte[] array = new byte[Length];
		InternalRead(array, 0, (int)length, 0L);
		return array;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		return SafeRead(buffer, offset, count, ref position);
	}

	public int SafeRead(byte[] buffer, int offset, int count, ref long streamPosition)
	{
		CheckDisposed();
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0)
		{
			throw new ArgumentOutOfRangeException("offset", "offset cannot be negative.");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count", "count cannot be negative.");
		}
		if (offset + count > buffer.Length)
		{
			throw new ArgumentException("buffer length must be at least offset + count.");
		}
		int num = InternalRead(buffer, offset, count, streamPosition);
		streamPosition += num;
		return num;
	}

	public override int Read(Span<byte> buffer)
	{
		return SafeRead(buffer, ref position);
	}

	public int SafeRead(Span<byte> buffer, ref long streamPosition)
	{
		CheckDisposed();
		int num = InternalRead(buffer, streamPosition);
		streamPosition += num;
		return num;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		CheckDisposed();
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0)
		{
			throw new ArgumentOutOfRangeException("offset", offset, "offset must be in the range of 0 - buffer.Length-1.");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count", count, "count must be non-negative.");
		}
		if (count + offset > buffer.Length)
		{
			throw new ArgumentException("count must be greater than buffer.Length - offset.");
		}
		int blockSize = memoryManager.options.BlockSize;
		long newCapacity = position + count;
		EnsureCapacity(newCapacity);
		if (largeBuffer == null)
		{
			int num = count;
			int num2 = 0;
			BlockAndOffset blockAndRelativeOffset = GetBlockAndRelativeOffset(position);
			while (num > 0)
			{
				byte[] dst = blocks[blockAndRelativeOffset.Block];
				int num3 = Math.Min(blockSize - blockAndRelativeOffset.Offset, num);
				Buffer.BlockCopy(buffer, offset + num2, dst, blockAndRelativeOffset.Offset, num3);
				num -= num3;
				num2 += num3;
				blockAndRelativeOffset.Block++;
				blockAndRelativeOffset.Offset = 0;
			}
		}
		else
		{
			Buffer.BlockCopy(buffer, offset, largeBuffer, (int)position, count);
		}
		position = newCapacity;
		length = Math.Max(position, length);
	}

	public override void Write(ReadOnlySpan<byte> source)
	{
		CheckDisposed();
		int blockSize = memoryManager.options.BlockSize;
		long newCapacity = position + source.Length;
		EnsureCapacity(newCapacity);
		if (largeBuffer == null)
		{
			BlockAndOffset blockAndRelativeOffset = GetBlockAndRelativeOffset(position);
			while (source.Length > 0)
			{
				byte[] array = blocks[blockAndRelativeOffset.Block];
				int start = Math.Min(blockSize - blockAndRelativeOffset.Offset, source.Length);
				source.Slice(0, start).CopyTo(array.AsSpan(blockAndRelativeOffset.Offset));
				source = source.Slice(start);
				blockAndRelativeOffset.Block++;
				blockAndRelativeOffset.Offset = 0;
			}
		}
		else
		{
			source.CopyTo(largeBuffer.AsSpan((int)position));
		}
		position = newCapacity;
		length = Math.Max(position, length);
	}

	public override string ToString()
	{
		if (disposed)
		{
			return $"Disposed: Id = {id}, Tag = {tag}, Final Length: {length:N0} bytes";
		}
		return $"Id = {Id}, Tag = {Tag}, Length = {Length:N0} bytes";
	}

	public override void WriteByte(byte value)
	{
		CheckDisposed();
		long newCapacity = position + 1;
		if (largeBuffer == null)
		{
			int blockSize = memoryManager.options.BlockSize;
			long result;
			int num = (int)Math.DivRem(position, blockSize, out result);
			if (num >= blocks.Count)
			{
				EnsureCapacity(newCapacity);
			}
			blocks[num][result] = value;
		}
		else
		{
			if (position >= largeBuffer.Length)
			{
				EnsureCapacity(newCapacity);
			}
			largeBuffer[position] = value;
		}
		position = newCapacity;
		if (position > length)
		{
			length = position;
		}
	}

	public override int ReadByte()
	{
		return SafeReadByte(ref position);
	}

	public int SafeReadByte(ref long streamPosition)
	{
		CheckDisposed();
		if (streamPosition == length)
		{
			return -1;
		}
		byte result;
		if (largeBuffer == null)
		{
			BlockAndOffset blockAndRelativeOffset = GetBlockAndRelativeOffset(streamPosition);
			result = blocks[blockAndRelativeOffset.Block][blockAndRelativeOffset.Offset];
		}
		else
		{
			result = largeBuffer[streamPosition];
		}
		streamPosition++;
		return result;
	}

	public override void SetLength(long value)
	{
		CheckDisposed();
		if (value < 0)
		{
			throw new ArgumentOutOfRangeException("value", "value must be non-negative.");
		}
		EnsureCapacity(value);
		length = value;
		if (position > value)
		{
			position = value;
		}
	}

	public override long Seek(long offset, SeekOrigin loc)
	{
		CheckDisposed();
		long num = loc switch
		{
			SeekOrigin.Begin => offset, 
			SeekOrigin.Current => offset + position, 
			SeekOrigin.End => offset + length, 
			_ => throw new ArgumentException("Invalid seek origin.", "loc"), 
		};
		if (num < 0)
		{
			throw new IOException("Seek before beginning.");
		}
		position = num;
		return position;
	}

	public override void WriteTo(Stream stream)
	{
		WriteTo(stream, 0L, length);
	}

	public void WriteTo(Stream stream, long offset, long count)
	{
		CheckDisposed();
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (offset < 0 || offset + count > length)
		{
			throw new ArgumentOutOfRangeException("offset must not be negative and offset + count must not exceed the length of the stream.", (Exception?)null);
		}
		if (largeBuffer == null)
		{
			BlockAndOffset blockAndRelativeOffset = GetBlockAndRelativeOffset(offset);
			long num = count;
			int num2 = blockAndRelativeOffset.Block;
			int num3 = blockAndRelativeOffset.Offset;
			while (num > 0)
			{
				byte[] array = blocks[num2];
				int num4 = (int)Math.Min((long)array.Length - (long)num3, num);
				stream.Write(array, num3, num4);
				num -= num4;
				num2++;
				num3 = 0;
			}
		}
		else
		{
			stream.Write(largeBuffer, (int)offset, (int)count);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void CheckDisposed()
	{
		if (Disposed)
		{
			ThrowDisposedException();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ThrowDisposedException()
	{
		throw new ObjectDisposedException($"The stream with Id {id} and Tag {tag} is disposed.");
	}

	private int InternalRead(byte[] buffer, int offset, int count, long fromPosition)
	{
		if (length - fromPosition <= 0)
		{
			return 0;
		}
		int num3;
		if (largeBuffer == null)
		{
			BlockAndOffset blockAndRelativeOffset = GetBlockAndRelativeOffset(fromPosition);
			int num = 0;
			int num2 = (int)Math.Min(count, length - fromPosition);
			while (num2 > 0)
			{
				byte[] array = blocks[blockAndRelativeOffset.Block];
				num3 = Math.Min(array.Length - blockAndRelativeOffset.Offset, num2);
				Buffer.BlockCopy(array, blockAndRelativeOffset.Offset, buffer, num + offset, num3);
				num += num3;
				num2 -= num3;
				blockAndRelativeOffset.Block++;
				blockAndRelativeOffset.Offset = 0;
			}
			return num;
		}
		num3 = (int)Math.Min(count, length - fromPosition);
		Buffer.BlockCopy(largeBuffer, (int)fromPosition, buffer, offset, num3);
		return num3;
	}

	private int InternalRead(Span<byte> buffer, long fromPosition)
	{
		if (length - fromPosition <= 0)
		{
			return 0;
		}
		int num3;
		if (largeBuffer == null)
		{
			BlockAndOffset blockAndRelativeOffset = GetBlockAndRelativeOffset(fromPosition);
			int num = 0;
			int num2 = (int)Math.Min(buffer.Length, length - fromPosition);
			while (num2 > 0)
			{
				byte[] array = blocks[blockAndRelativeOffset.Block];
				num3 = Math.Min(array.Length - blockAndRelativeOffset.Offset, num2);
				array.AsSpan(blockAndRelativeOffset.Offset, num3).CopyTo(buffer.Slice(num));
				num += num3;
				num2 -= num3;
				blockAndRelativeOffset.Block++;
				blockAndRelativeOffset.Offset = 0;
			}
			return num;
		}
		num3 = (int)Math.Min(buffer.Length, length - fromPosition);
		largeBuffer.AsSpan((int)fromPosition, num3).CopyTo(buffer);
		return num3;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private BlockAndOffset GetBlockAndRelativeOffset(long offset)
	{
		int blockSize = memoryManager.options.BlockSize;
		long result;
		return new BlockAndOffset((int)Math.DivRem(offset, blockSize, out result), (int)result);
	}

	private void EnsureCapacity(long newCapacity)
	{
		if (newCapacity > memoryManager.options.MaximumStreamCapacity && memoryManager.options.MaximumStreamCapacity > 0)
		{
			memoryManager.ReportStreamOverCapacity(id, tag, newCapacity, AllocationStack);
			throw new OutOfMemoryException($"Requested capacity is too large: {newCapacity}. Limit is {memoryManager.options.MaximumStreamCapacity}.");
		}
		if (largeBuffer != null)
		{
			if (newCapacity > largeBuffer.Length)
			{
				byte[] buffer = memoryManager.GetLargeBuffer(newCapacity, id, tag);
				InternalRead(buffer, 0, (int)length, 0L);
				ReleaseLargeBuffer();
				largeBuffer = buffer;
			}
		}
		else
		{
			long num = newCapacity / memoryManager.options.BlockSize + 1;
			if (blocks.Capacity < num)
			{
				blocks.Capacity = (int)num;
			}
			while (Capacity64 < newCapacity)
			{
				blocks.Add(memoryManager.GetBlock());
			}
		}
	}

	private void ReleaseLargeBuffer()
	{
		if (memoryManager.options.AggressiveBufferReturn)
		{
			memoryManager.ReturnLargeBuffer(largeBuffer, id, tag);
		}
		else
		{
			if (dirtyBuffers == null)
			{
				dirtyBuffers = new List<byte[]>(1);
			}
			dirtyBuffers.Add(largeBuffer);
		}
		largeBuffer = null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void AssertLengthIsSmall()
	{
	}
}
