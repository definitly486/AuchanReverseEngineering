using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Microsoft.IO;

public sealed class RecyclableMemoryStreamManager
{
	public sealed class StreamCreatedEventArgs(Guid guid, string? tag, long requestedSize, long actualSize) : EventArgs()
	{
		[CompilerGenerated]
		private readonly Guid _003CId_003Ek__BackingField = guid;

		[CompilerGenerated]
		private readonly string? _003CTag_003Ek__BackingField = tag;

		[CompilerGenerated]
		private readonly long _003CRequestedSize_003Ek__BackingField = requestedSize;

		[CompilerGenerated]
		private readonly long _003CActualSize_003Ek__BackingField = actualSize;
	}

	public sealed class StreamDisposedEventArgs : EventArgs
	{
		[CompilerGenerated]
		private readonly Guid _003CId_003Ek__BackingField;

		[CompilerGenerated]
		private readonly string? _003CTag_003Ek__BackingField;

		[CompilerGenerated]
		private readonly string? _003CAllocationStack_003Ek__BackingField;

		[CompilerGenerated]
		private readonly string? _003CDisposeStack_003Ek__BackingField;

		[CompilerGenerated]
		private readonly TimeSpan _003CLifetime_003Ek__BackingField;

		public StreamDisposedEventArgs(Guid guid, string? tag, TimeSpan lifetime, string? allocationStack, string? disposeStack)
		{
			_003CId_003Ek__BackingField = guid;
			_003CTag_003Ek__BackingField = tag;
			_003CAllocationStack_003Ek__BackingField = allocationStack;
			_003CDisposeStack_003Ek__BackingField = disposeStack;
			_003CLifetime_003Ek__BackingField = lifetime;
			base._002Ector();
		}
	}

	public sealed class StreamDoubleDisposedEventArgs(Guid guid, string? tag, string? allocationStack, string? disposeStack1, string? disposeStack2) : EventArgs()
	{
		[CompilerGenerated]
		private readonly Guid _003CId_003Ek__BackingField = guid;

		[CompilerGenerated]
		private readonly string? _003CTag_003Ek__BackingField = tag;

		[CompilerGenerated]
		private readonly string? _003CAllocationStack_003Ek__BackingField = allocationStack;

		[CompilerGenerated]
		private readonly string? _003CDisposeStack1_003Ek__BackingField = disposeStack1;

		[CompilerGenerated]
		private readonly string? _003CDisposeStack2_003Ek__BackingField = disposeStack2;
	}

	public sealed class StreamFinalizedEventArgs(Guid guid, string? tag, string? allocationStack) : EventArgs()
	{
		[CompilerGenerated]
		private readonly Guid _003CId_003Ek__BackingField = guid;

		[CompilerGenerated]
		private readonly string? _003CTag_003Ek__BackingField = tag;

		[CompilerGenerated]
		private readonly string? _003CAllocationStack_003Ek__BackingField = allocationStack;
	}

	public sealed class StreamConvertedToArrayEventArgs(Guid guid, string? tag, string? stack, long length) : EventArgs()
	{
		[CompilerGenerated]
		private readonly Guid _003CId_003Ek__BackingField = guid;

		[CompilerGenerated]
		private readonly string? _003CTag_003Ek__BackingField = tag;

		[CompilerGenerated]
		private readonly string? _003CStack_003Ek__BackingField = stack;

		[CompilerGenerated]
		private readonly long _003CLength_003Ek__BackingField = length;
	}

	public sealed class StreamOverCapacityEventArgs : EventArgs
	{
		[CompilerGenerated]
		private readonly Guid _003CId_003Ek__BackingField;

		[CompilerGenerated]
		private readonly string? _003CTag_003Ek__BackingField;

		[CompilerGenerated]
		private readonly string? _003CAllocationStack_003Ek__BackingField;

		[CompilerGenerated]
		private readonly long _003CRequestedCapacity_003Ek__BackingField;

		[CompilerGenerated]
		private readonly long _003CMaximumCapacity_003Ek__BackingField;

		internal StreamOverCapacityEventArgs(Guid guid, string? tag, long requestedCapacity, long maximumCapacity, string? allocationStack)
		{
			_003CId_003Ek__BackingField = guid;
			_003CTag_003Ek__BackingField = tag;
			_003CRequestedCapacity_003Ek__BackingField = requestedCapacity;
			_003CMaximumCapacity_003Ek__BackingField = maximumCapacity;
			_003CAllocationStack_003Ek__BackingField = allocationStack;
		}
	}

	public sealed class BlockCreatedEventArgs : EventArgs
	{
		[CompilerGenerated]
		private readonly long _003CSmallPoolInUse_003Ek__BackingField;

		internal BlockCreatedEventArgs(long smallPoolInUse)
		{
			_003CSmallPoolInUse_003Ek__BackingField = smallPoolInUse;
		}
	}

	public sealed class LargeBufferCreatedEventArgs : EventArgs
	{
		[CompilerGenerated]
		private readonly Guid _003CId_003Ek__BackingField;

		[CompilerGenerated]
		private readonly string? _003CTag_003Ek__BackingField;

		[CompilerGenerated]
		private readonly bool _003CPooled_003Ek__BackingField;

		[CompilerGenerated]
		private readonly long _003CRequiredSize_003Ek__BackingField;

		[CompilerGenerated]
		private readonly long _003CLargePoolInUse_003Ek__BackingField;

		[CompilerGenerated]
		private readonly string? _003CCallStack_003Ek__BackingField;

		internal LargeBufferCreatedEventArgs(Guid guid, string? tag, long requiredSize, long largePoolInUse, bool pooled, string? callStack)
		{
			_003CRequiredSize_003Ek__BackingField = requiredSize;
			_003CLargePoolInUse_003Ek__BackingField = largePoolInUse;
			_003CPooled_003Ek__BackingField = pooled;
			_003CId_003Ek__BackingField = guid;
			_003CTag_003Ek__BackingField = tag;
			_003CCallStack_003Ek__BackingField = callStack;
		}
	}

	public sealed class BufferDiscardedEventArgs : EventArgs
	{
		[CompilerGenerated]
		private readonly Guid _003CId_003Ek__BackingField;

		[CompilerGenerated]
		private readonly string? _003CTag_003Ek__BackingField;

		[CompilerGenerated]
		private readonly Events.MemoryStreamBufferType _003CBufferType_003Ek__BackingField;

		[CompilerGenerated]
		private readonly Events.MemoryStreamDiscardReason _003CReason_003Ek__BackingField;

		internal BufferDiscardedEventArgs(Guid guid, string? tag, Events.MemoryStreamBufferType bufferType, Events.MemoryStreamDiscardReason reason)
		{
			_003CId_003Ek__BackingField = guid;
			_003CTag_003Ek__BackingField = tag;
			_003CBufferType_003Ek__BackingField = bufferType;
			_003CReason_003Ek__BackingField = reason;
		}
	}

	public sealed class StreamLengthEventArgs(long length) : EventArgs()
	{
		[CompilerGenerated]
		private readonly long _003CLength_003Ek__BackingField = length;
	}

	public sealed class UsageReportEventArgs(long smallPoolInUseBytes, long smallPoolFreeBytes, long largePoolInUseBytes, long largePoolFreeBytes) : EventArgs()
	{
		[CompilerGenerated]
		private readonly long _003CSmallPoolInUseBytes_003Ek__BackingField = smallPoolInUseBytes;

		[CompilerGenerated]
		private readonly long _003CSmallPoolFreeBytes_003Ek__BackingField = smallPoolFreeBytes;

		[CompilerGenerated]
		private readonly long _003CLargePoolInUseBytes_003Ek__BackingField = largePoolInUseBytes;

		[CompilerGenerated]
		private readonly long _003CLargePoolFreeBytes_003Ek__BackingField = largePoolFreeBytes;
	}

	[EventSource(Name = "Microsoft-IO-RecyclableMemoryStream", Guid = "{B80CD4E4-890E-468D-9CBA-90EB7C82DFC7}")]
	public sealed class Events : EventSource
	{
		public enum MemoryStreamBufferType
		{
			Small,
			Large
		}

		public enum MemoryStreamDiscardReason
		{
			TooLarge,
			EnoughFree
		}

		public static Events Writer = new Events();

		[Event(1, Level = EventLevel.Verbose, Version = 2)]
		public void MemoryStreamCreated(Guid guid, string? tag, long requestedSize, long actualSize)
		{
			if (!IsEnabled(EventLevel.Verbose, EventKeywords.None))
			{
			}
		}

		[Event(2, Level = EventLevel.Verbose, Version = 3)]
		public void MemoryStreamDisposed(Guid guid, string? tag, long lifetimeMs, string? allocationStack, string? disposeStack)
		{
			if (!IsEnabled(EventLevel.Verbose, EventKeywords.None))
			{
			}
		}

		[Event(3, Level = EventLevel.Critical)]
		public void MemoryStreamDoubleDispose(Guid guid, string? tag, string? allocationStack, string? disposeStack1, string? disposeStack2)
		{
			if (0 == 0)
			{
			}
		}

		[Event(4, Level = EventLevel.Error)]
		public void MemoryStreamFinalized(Guid guid, string? tag, string? allocationStack)
		{
			if (0 == 0)
			{
			}
		}

		[Event(5, Level = EventLevel.Verbose, Version = 2)]
		public void MemoryStreamToArray(Guid guid, string? tag, string? stack, long size)
		{
			if (!IsEnabled(EventLevel.Verbose, EventKeywords.None))
			{
			}
		}

		[Event(6, Level = EventLevel.Informational)]
		public void MemoryStreamManagerInitialized(int blockSize, int largeBufferMultiple, int maximumBufferSize)
		{
			if (0 == 0)
			{
			}
		}

		[Event(7, Level = EventLevel.Warning, Version = 2)]
		public void MemoryStreamNewBlockCreated(long smallPoolInUseBytes)
		{
			if (!IsEnabled(EventLevel.Warning, EventKeywords.None))
			{
			}
		}

		[Event(8, Level = EventLevel.Warning, Version = 3)]
		public void MemoryStreamNewLargeBufferCreated(long requiredSize, long largePoolInUseBytes)
		{
			if (!IsEnabled(EventLevel.Warning, EventKeywords.None))
			{
			}
		}

		[Event(9, Level = EventLevel.Verbose, Version = 3)]
		public void MemoryStreamNonPooledLargeBufferCreated(Guid guid, string? tag, long requiredSize, string? allocationStack)
		{
			if (!IsEnabled(EventLevel.Verbose, EventKeywords.None))
			{
			}
		}

		[Event(10, Level = EventLevel.Warning, Version = 2)]
		public void MemoryStreamDiscardBuffer(Guid guid, string? tag, MemoryStreamBufferType bufferType, MemoryStreamDiscardReason reason, long smallBlocksFree, long smallPoolBytesFree, long smallPoolBytesInUse, long largeBlocksFree, long largePoolBytesFree, long largePoolBytesInUse)
		{
			if (!IsEnabled(EventLevel.Warning, EventKeywords.None))
			{
			}
		}

		[Event(11, Level = EventLevel.Error, Version = 3)]
		public void MemoryStreamOverCapacity(Guid guid, string? tag, long requestedCapacity, long maxCapacity, string? allocationStack)
		{
			if (0 == 0)
			{
			}
		}
	}

	public class Options
	{
		public int BlockSize { get; } = 131072;

		public int LargeBufferMultiple { get; } = 1048576;

		public int MaximumBufferSize { get; } = 134217728;

		public long MaximumSmallPoolFreeBytes { get; }

		public long MaximumLargePoolFreeBytes { get; }

		public bool UseExponentialLargeBuffer { get; }

		public long MaximumStreamCapacity { get; }

		public bool GenerateCallStacks { get; }

		public bool AggressiveBufferReturn { get; }

		public bool ThrowExceptionOnToArray { get; }

		public bool ZeroOutBuffer { get; }
	}

	private readonly long[] largeBufferFreeSize;

	private readonly long[] largeBufferInUseSize;

	private readonly ConcurrentStack<byte[]>[] largePools;

	private readonly ConcurrentStack<byte[]> smallPool;

	private long smallPoolFreeSize;

	private long smallPoolInUseSize;

	internal readonly Options options;

	[CompilerGenerated]
	private EventHandler<BlockCreatedEventArgs>? BlockCreated;

	[CompilerGenerated]
	private EventHandler<LargeBufferCreatedEventArgs>? LargeBufferCreated;

	[CompilerGenerated]
	private EventHandler<StreamCreatedEventArgs>? StreamCreated;

	[CompilerGenerated]
	private EventHandler<StreamDisposedEventArgs>? StreamDisposed;

	[CompilerGenerated]
	private EventHandler<StreamDoubleDisposedEventArgs>? StreamDoubleDisposed;

	[CompilerGenerated]
	private EventHandler<StreamFinalizedEventArgs>? StreamFinalized;

	[CompilerGenerated]
	private EventHandler<StreamLengthEventArgs>? StreamLength;

	[CompilerGenerated]
	private EventHandler<StreamConvertedToArrayEventArgs>? StreamConvertedToArray;

	[CompilerGenerated]
	private EventHandler<StreamOverCapacityEventArgs>? StreamOverCapacity;

	[CompilerGenerated]
	private EventHandler<BufferDiscardedEventArgs>? BufferDiscarded;

	[CompilerGenerated]
	private EventHandler<UsageReportEventArgs>? UsageReport;

	public long SmallPoolFreeSize => smallPoolFreeSize;

	public long LargePoolFreeSize
	{
		get
		{
			long num = 0L;
			long[] array = largeBufferFreeSize;
			foreach (long num2 in array)
			{
				num += num2;
			}
			return num;
		}
	}

	public long LargePoolInUseSize
	{
		get
		{
			long num = 0L;
			long[] array = largeBufferInUseSize;
			foreach (long num2 in array)
			{
				num += num2;
			}
			return num;
		}
	}

	public long SmallBlocksFree => smallPool.Count;

	public long LargeBuffersFree
	{
		get
		{
			long num = 0L;
			ConcurrentStack<byte[]>[] array = largePools;
			foreach (ConcurrentStack<byte[]> concurrentStack in array)
			{
				num += concurrentStack.Count;
			}
			return num;
		}
	}

	public RecyclableMemoryStreamManager()
		: this(new Options())
	{
	}

	public RecyclableMemoryStreamManager(Options options)
	{
		if (options.BlockSize <= 0)
		{
			throw new InvalidOperationException("BlockSize must be a positive number");
		}
		if (options.LargeBufferMultiple <= 0)
		{
			throw new InvalidOperationException("LargeBufferMultiple must be a positive number");
		}
		if (options.MaximumBufferSize < options.BlockSize)
		{
			throw new InvalidOperationException("MaximumBufferSize must be at least BlockSize");
		}
		if (options.MaximumSmallPoolFreeBytes < 0)
		{
			throw new InvalidOperationException("MaximumSmallPoolFreeBytes must be non-negative");
		}
		if (options.MaximumLargePoolFreeBytes < 0)
		{
			throw new InvalidOperationException("MaximumLargePoolFreeBytes must be non-negative");
		}
		this.options = options;
		if (!IsLargeBufferSize(options.MaximumBufferSize))
		{
			throw new InvalidOperationException($"{"MaximumBufferSize"} is not {(options.UseExponentialLargeBuffer ? "an exponential" : "a multiple")} of {"LargeBufferMultiple"}.");
		}
		smallPool = new ConcurrentStack<byte[]>();
		int num = (options.UseExponentialLargeBuffer ? ((int)Math.Log(options.MaximumBufferSize / options.LargeBufferMultiple, 2.0) + 1) : (options.MaximumBufferSize / options.LargeBufferMultiple));
		largeBufferInUseSize = new long[num + 1];
		largeBufferFreeSize = new long[num];
		largePools = new ConcurrentStack<byte[]>[num];
		for (int i = 0; i < largePools.Length; i++)
		{
			largePools[i] = new ConcurrentStack<byte[]>();
		}
		Events.Writer.MemoryStreamManagerInitialized(options.BlockSize, options.LargeBufferMultiple, options.MaximumBufferSize);
	}

	internal byte[] GetBlock()
	{
		Interlocked.Add(ref smallPoolInUseSize, options.BlockSize);
		if (!smallPool.TryPop(out byte[] result))
		{
			result = (options.ZeroOutBuffer ? GC.AllocateArray<byte>(options.BlockSize) : GC.AllocateUninitializedArray<byte>(options.BlockSize));
			ReportBlockCreated();
		}
		else
		{
			Interlocked.Add(ref smallPoolFreeSize, -options.BlockSize);
		}
		return result;
	}

	internal byte[] GetLargeBuffer(long requiredSize, Guid id, string? tag)
	{
		if (requiredSize > 2147483591)
		{
			throw new OutOfMemoryException($"Requested size exceeds maximum array length of {2147483591}.");
		}
		requiredSize = RoundToLargeBufferSize(requiredSize);
		int num = GetPoolIndex(requiredSize);
		bool flag = false;
		bool pooled = true;
		string callStack = null;
		byte[] result;
		if (num < largePools.Length)
		{
			if (!largePools[num].TryPop(out result))
			{
				result = AllocateArray(requiredSize, options.ZeroOutBuffer);
				flag = true;
			}
			else
			{
				Interlocked.Add(ref largeBufferFreeSize[num], -result.Length);
			}
		}
		else
		{
			num = largeBufferInUseSize.Length - 1;
			result = AllocateArray(requiredSize, options.ZeroOutBuffer);
			if (options.GenerateCallStacks)
			{
				callStack = Environment.StackTrace;
			}
			flag = true;
			pooled = false;
		}
		Interlocked.Add(ref largeBufferInUseSize[num], result.Length);
		if (flag)
		{
			ReportLargeBufferCreated(id, tag, requiredSize, pooled, callStack);
		}
		return result;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static byte[] AllocateArray(long num2, bool zeroInitializeArray)
		{
			if (!zeroInitializeArray)
			{
				return GC.AllocateUninitializedArray<byte>((int)num2);
			}
			return GC.AllocateArray<byte>((int)num2);
		}
	}

	private long RoundToLargeBufferSize(long requiredSize)
	{
		if (options.UseExponentialLargeBuffer)
		{
			long num = 1L;
			while (options.LargeBufferMultiple * num < requiredSize)
			{
				num <<= 1;
			}
			return options.LargeBufferMultiple * num;
		}
		return (requiredSize + options.LargeBufferMultiple - 1) / options.LargeBufferMultiple * options.LargeBufferMultiple;
	}

	private bool IsLargeBufferSize(int value)
	{
		if (value != 0)
		{
			if (!options.UseExponentialLargeBuffer)
			{
				return value % options.LargeBufferMultiple == 0;
			}
			return value == RoundToLargeBufferSize(value);
		}
		return false;
	}

	private int GetPoolIndex(long length)
	{
		if (options.UseExponentialLargeBuffer)
		{
			int i;
			for (i = 0; options.LargeBufferMultiple << i < length; i++)
			{
			}
			return i;
		}
		return (int)(length / options.LargeBufferMultiple - 1);
	}

	internal void ReturnLargeBuffer(byte[] buffer, Guid id, string? tag)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (!IsLargeBufferSize(buffer.Length))
		{
			throw new ArgumentException($"{"buffer"} did not originate from this memory manager. The size is not {(options.UseExponentialLargeBuffer ? "an exponential" : "a multiple")} of {options.LargeBufferMultiple}.");
		}
		ZeroOutMemoryIfEnabled(buffer);
		int num = GetPoolIndex(buffer.Length);
		if (num < largePools.Length)
		{
			if ((largePools[num].Count + 1) * buffer.Length <= options.MaximumLargePoolFreeBytes || options.MaximumLargePoolFreeBytes == 0L)
			{
				largePools[num].Push(buffer);
				Interlocked.Add(ref largeBufferFreeSize[num], buffer.Length);
			}
			else
			{
				ReportBufferDiscarded(id, tag, Events.MemoryStreamBufferType.Large, Events.MemoryStreamDiscardReason.EnoughFree);
			}
		}
		else
		{
			num = largeBufferInUseSize.Length - 1;
			ReportBufferDiscarded(id, tag, Events.MemoryStreamBufferType.Large, Events.MemoryStreamDiscardReason.TooLarge);
		}
		Interlocked.Add(ref largeBufferInUseSize[num], -buffer.Length);
	}

	internal void ReturnBlocks(List<byte[]> blocks, Guid id, string? tag)
	{
		if (blocks == null)
		{
			throw new ArgumentNullException("blocks");
		}
		long num = (long)blocks.Count * (long)options.BlockSize;
		Interlocked.Add(ref smallPoolInUseSize, -num);
		foreach (byte[] block in blocks)
		{
			if (block == null || block.Length != options.BlockSize)
			{
				throw new ArgumentException("blocks contains buffers that are not BlockSize in length.", "blocks");
			}
		}
		foreach (byte[] block2 in blocks)
		{
			ZeroOutMemoryIfEnabled(block2);
			if (options.MaximumSmallPoolFreeBytes == 0L || SmallPoolFreeSize < options.MaximumSmallPoolFreeBytes)
			{
				Interlocked.Add(ref smallPoolFreeSize, options.BlockSize);
				smallPool.Push(block2);
				continue;
			}
			ReportBufferDiscarded(id, tag, Events.MemoryStreamBufferType.Small, Events.MemoryStreamDiscardReason.EnoughFree);
			break;
		}
	}

	internal void ReturnBlock(byte[] block, Guid id, string? tag)
	{
		int blockSize = options.BlockSize;
		Interlocked.Add(ref smallPoolInUseSize, -blockSize);
		if (block == null)
		{
			throw new ArgumentNullException("block");
		}
		if (block.Length != options.BlockSize)
		{
			throw new ArgumentException("block is not not BlockSize in length.");
		}
		ZeroOutMemoryIfEnabled(block);
		if (options.MaximumSmallPoolFreeBytes == 0L || SmallPoolFreeSize < options.MaximumSmallPoolFreeBytes)
		{
			Interlocked.Add(ref smallPoolFreeSize, options.BlockSize);
			smallPool.Push(block);
		}
		else
		{
			ReportBufferDiscarded(id, tag, Events.MemoryStreamBufferType.Small, Events.MemoryStreamDiscardReason.EnoughFree);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void ZeroOutMemoryIfEnabled(byte[] buffer)
	{
		if (options.ZeroOutBuffer)
		{
			Array.Clear(buffer);
		}
	}

	internal void ReportBlockCreated()
	{
		Events.Writer.MemoryStreamNewBlockCreated(smallPoolInUseSize);
		BlockCreated?.Invoke(this, new BlockCreatedEventArgs(smallPoolInUseSize));
	}

	internal void ReportLargeBufferCreated(Guid id, string? tag, long requiredSize, bool pooled, string? callStack)
	{
		if (pooled)
		{
			Events.Writer.MemoryStreamNewLargeBufferCreated(requiredSize, LargePoolInUseSize);
		}
		else
		{
			Events.Writer.MemoryStreamNonPooledLargeBufferCreated(id, tag, requiredSize, callStack);
		}
		LargeBufferCreated?.Invoke(this, new LargeBufferCreatedEventArgs(id, tag, requiredSize, LargePoolInUseSize, pooled, callStack));
	}

	internal void ReportBufferDiscarded(Guid id, string? tag, Events.MemoryStreamBufferType bufferType, Events.MemoryStreamDiscardReason reason)
	{
		Events.Writer.MemoryStreamDiscardBuffer(id, tag, bufferType, reason, SmallBlocksFree, smallPoolFreeSize, smallPoolInUseSize, LargeBuffersFree, LargePoolFreeSize, LargePoolInUseSize);
		BufferDiscarded?.Invoke(this, new BufferDiscardedEventArgs(id, tag, bufferType, reason));
	}

	internal void ReportStreamCreated(Guid id, string? tag, long requestedSize, long actualSize)
	{
		Events.Writer.MemoryStreamCreated(id, tag, requestedSize, actualSize);
		StreamCreated?.Invoke(this, new StreamCreatedEventArgs(id, tag, requestedSize, actualSize));
	}

	internal void ReportStreamDisposed(Guid id, string? tag, TimeSpan lifetime, string? allocationStack, string? disposeStack)
	{
		Events.Writer.MemoryStreamDisposed(id, tag, (long)lifetime.TotalMilliseconds, allocationStack, disposeStack);
		StreamDisposed?.Invoke(this, new StreamDisposedEventArgs(id, tag, lifetime, allocationStack, disposeStack));
	}

	internal void ReportStreamDoubleDisposed(Guid id, string? tag, string? allocationStack, string? disposeStack1, string? disposeStack2)
	{
		Events.Writer.MemoryStreamDoubleDispose(id, tag, allocationStack, disposeStack1, disposeStack2);
		StreamDoubleDisposed?.Invoke(this, new StreamDoubleDisposedEventArgs(id, tag, allocationStack, disposeStack1, disposeStack2));
	}

	internal void ReportStreamFinalized(Guid id, string? tag, string? allocationStack)
	{
		Events.Writer.MemoryStreamFinalized(id, tag, allocationStack);
		StreamFinalized?.Invoke(this, new StreamFinalizedEventArgs(id, tag, allocationStack));
	}

	internal void ReportStreamLength(long bytes)
	{
		StreamLength?.Invoke(this, new StreamLengthEventArgs(bytes));
	}

	internal void ReportStreamToArray(Guid id, string? tag, string? stack, long length)
	{
		Events.Writer.MemoryStreamToArray(id, tag, stack, length);
		StreamConvertedToArray?.Invoke(this, new StreamConvertedToArrayEventArgs(id, tag, stack, length));
	}

	internal void ReportStreamOverCapacity(Guid id, string? tag, long requestedCapacity, string? allocationStack)
	{
		Events.Writer.MemoryStreamOverCapacity(id, tag, requestedCapacity, options.MaximumStreamCapacity, allocationStack);
		StreamOverCapacity?.Invoke(this, new StreamOverCapacityEventArgs(id, tag, requestedCapacity, options.MaximumStreamCapacity, allocationStack));
	}

	internal void ReportUsageReport()
	{
		UsageReport?.Invoke(this, new UsageReportEventArgs(smallPoolInUseSize, smallPoolFreeSize, LargePoolInUseSize, LargePoolFreeSize));
	}

	public RecyclableMemoryStream GetStream()
	{
		return new RecyclableMemoryStream(this);
	}
}
