using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;

namespace System;

public static class GC
{
	internal static readonly object EPHEMERON_TOMBSTONE = get_ephemeron_tombstone();

	public static int MaxGeneration => GetMaxGeneration();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetCollectionCount(int generation);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetMaxGeneration();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void InternalCollect(int generation);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void AddPressure(ulong bytesAllocated);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RemovePressure(ulong bytesRemoved);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void register_ephemeron_array(Ephemeron[] array);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern object get_ephemeron_tombstone();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern long GetAllocatedBytesForCurrentThread();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern long GetTotalAllocatedBytes(bool precise = false);

	public static void AddMemoryPressure(long bytesAllocated)
	{
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(bytesAllocated, "bytesAllocated");
		_ = 4;
		ArgumentOutOfRangeException.ThrowIfGreaterThan(bytesAllocated, 2147483647L, "bytesAllocated");
		AddPressure((ulong)bytesAllocated);
	}

	public static void RemoveMemoryPressure(long bytesAllocated)
	{
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(bytesAllocated, "bytesAllocated");
		_ = 4;
		ArgumentOutOfRangeException.ThrowIfGreaterThan(bytesAllocated, 2147483647L, "bytesAllocated");
		RemovePressure((ulong)bytesAllocated);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern int GetGeneration(object obj);

	public static void Collect(int generation)
	{
		Collect(generation, GCCollectionMode.Default);
	}

	public static void Collect()
	{
		InternalCollect(MaxGeneration);
	}

	public static void Collect(int generation, GCCollectionMode mode)
	{
		Collect(generation, mode, blocking: true);
	}

	public static void Collect(int generation, GCCollectionMode mode, bool blocking)
	{
		Collect(generation, mode, blocking, compacting: false);
	}

	public static void Collect(int generation, GCCollectionMode mode, bool blocking, bool compacting)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(generation, "generation");
		if (mode < GCCollectionMode.Default || mode > GCCollectionMode.Aggressive)
		{
			throw new ArgumentOutOfRangeException("mode", "ArgumentOutOfRange_Enum");
		}
		InternalCollect(generation);
	}

	public static int CollectionCount(int generation)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(generation, "generation");
		return GetCollectionCount(generation);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void KeepAlive(object? obj)
	{
	}

	public static int GetGeneration(WeakReference wo)
	{
		object? target = wo.Target;
		ArgumentNullException.ThrowIfNull(target, "wo");
		return GetGeneration(target);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void WaitForPendingFinalizers();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void _SuppressFinalize(object o);

	public static void SuppressFinalize(object obj)
	{
		ArgumentNullException.ThrowIfNull(obj, "obj");
		_SuppressFinalize(obj);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void _ReRegisterForFinalize(object o);

	public static void ReRegisterForFinalize(object obj)
	{
		ArgumentNullException.ThrowIfNull(obj, "obj");
		_ReRegisterForFinalize(obj);
	}

	[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "Finalize")]
	private static extern void CallFinalize(object o);

	private static void GuardedFinalize(object o)
	{
		try
		{
			CallFinalize(o);
		}
		catch (Exception ex) when (ExceptionHandling.IsHandledByGlobalHandler(ex))
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern long GetTotalMemory(bool forceFullCollection);

	private static bool _RegisterForFullGCNotification(int maxGenerationPercentage, int largeObjectHeapPercentage)
	{
		throw new NotImplementedException();
	}

	private static bool _CancelFullGCNotification()
	{
		throw new NotImplementedException();
	}

	private static GCNotificationStatus _WaitForFullGCApproach(int millisecondsTimeout)
	{
		throw new NotImplementedException();
	}

	private static GCNotificationStatus _WaitForFullGCComplete(int millisecondsTimeout)
	{
		throw new NotImplementedException();
	}

	public static void RegisterForFullGCNotification(int maxGenerationThreshold, int largeObjectHeapThreshold)
	{
		if (maxGenerationThreshold <= 0 || maxGenerationThreshold >= 100)
		{
			throw new ArgumentOutOfRangeException("maxGenerationThreshold", SR.Format("ArgumentOutOfRange_Bounds_Lower_Upper", 1, 99));
		}
		if (largeObjectHeapThreshold <= 0 || largeObjectHeapThreshold >= 100)
		{
			throw new ArgumentOutOfRangeException("largeObjectHeapThreshold", SR.Format("ArgumentOutOfRange_Bounds_Lower_Upper", 1, 99));
		}
		if (!_RegisterForFullGCNotification(maxGenerationThreshold, largeObjectHeapThreshold))
		{
			throw new InvalidOperationException("InvalidOperation_NotWithConcurrentGC");
		}
	}

	public static void CancelFullGCNotification()
	{
		if (!_CancelFullGCNotification())
		{
			throw new InvalidOperationException("InvalidOperation_NotWithConcurrentGC");
		}
	}

	public static GCNotificationStatus WaitForFullGCApproach()
	{
		return _WaitForFullGCApproach(-1);
	}

	public static GCNotificationStatus WaitForFullGCApproach(int millisecondsTimeout)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(millisecondsTimeout, -1, "millisecondsTimeout");
		return _WaitForFullGCApproach(millisecondsTimeout);
	}

	public static GCNotificationStatus WaitForFullGCComplete()
	{
		return _WaitForFullGCComplete(-1);
	}

	public static GCNotificationStatus WaitForFullGCComplete(int millisecondsTimeout)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(millisecondsTimeout, -1, "millisecondsTimeout");
		return _WaitForFullGCComplete(millisecondsTimeout);
	}

	private static bool StartNoGCRegion(long totalSize, bool hasLohSize, long lohSize, bool disallowFullBlockingGC)
	{
		throw new NotImplementedException();
	}

	public static bool TryStartNoGCRegion(long totalSize)
	{
		return StartNoGCRegion(totalSize, hasLohSize: false, 0L, disallowFullBlockingGC: false);
	}

	public static bool TryStartNoGCRegion(long totalSize, long lohSize)
	{
		return StartNoGCRegion(totalSize, hasLohSize: true, lohSize, disallowFullBlockingGC: false);
	}

	public static bool TryStartNoGCRegion(long totalSize, bool disallowFullBlockingGC)
	{
		return StartNoGCRegion(totalSize, hasLohSize: false, 0L, disallowFullBlockingGC);
	}

	public static bool TryStartNoGCRegion(long totalSize, long lohSize, bool disallowFullBlockingGC)
	{
		return StartNoGCRegion(totalSize, hasLohSize: true, lohSize, disallowFullBlockingGC);
	}

	public static void EndNoGCRegion()
	{
		throw new NotImplementedException();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void _GetGCMemoryInfo(out long highMemoryLoadThresholdBytes, out long memoryLoadBytes, out long totalAvailableMemoryBytes, out long totalCommittedBytes, out long heapSizeBytes, out long fragmentedBytes);

	public static GCMemoryInfo GetGCMemoryInfo()
	{
		GCMemoryInfoData gCMemoryInfoData = new GCMemoryInfoData();
		_GetGCMemoryInfo(out gCMemoryInfoData._highMemoryLoadThresholdBytes, out gCMemoryInfoData._memoryLoadBytes, out gCMemoryInfoData._totalAvailableMemoryBytes, out gCMemoryInfoData._totalCommittedBytes, out gCMemoryInfoData._heapSizeBytes, out gCMemoryInfoData._fragmentedBytes);
		return new GCMemoryInfo(gCMemoryInfoData);
	}

	public static GCMemoryInfo GetGCMemoryInfo(GCKind kind)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Array AllocPinnedArray(Type t, int length);

	public static T[] AllocateUninitializedArray<T>(int length, bool pinned = false)
	{
		return AllocateArray<T>(length, pinned);
	}

	public static T[] AllocateArray<T>(int length, bool pinned = false)
	{
		if (pinned)
		{
			return Unsafe.As<T[]>(AllocPinnedArray(typeof(T[]), length));
		}
		return new T[length];
	}

	internal static ulong GetGenerationSize(int generation)
	{
		switch (generation)
		{
		case 0:
			return EventPipeInternal.GetRuntimeCounterValue(EventPipeInternal.RuntimeCounters.GC_NURSERY_SIZE_BYTES);
		case 1:
		case 2:
			return EventPipeInternal.GetRuntimeCounterValue(EventPipeInternal.RuntimeCounters.GC_MAJOR_SIZE_BYTES);
		case 3:
			return EventPipeInternal.GetRuntimeCounterValue(EventPipeInternal.RuntimeCounters.GC_LARGE_OBJECT_SIZE_BYTES);
		case 4:
			return 0uL;
		default:
			return 0uL;
		}
	}

	internal static int GetLastGCPercentTimeInGC()
	{
		return (int)EventPipeInternal.GetRuntimeCounterValue(EventPipeInternal.RuntimeCounters.GC_LAST_PERCENT_TIME_IN_GC);
	}

	public static TimeSpan GetTotalPauseDuration()
	{
		return TimeSpan.Zero;
	}

	public static IReadOnlyDictionary<string, object> GetConfigurationVariables()
	{
		return new Dictionary<string, object>();
	}

	public static void RefreshMemoryLimit()
	{
		throw new PlatformNotSupportedException();
	}

	public static void RegisterNoGCRegionCallback(long totalSize, Action callback)
	{
		throw new PlatformNotSupportedException();
	}

	public static GCNotificationStatus WaitForFullGCApproach(TimeSpan timeout)
	{
		return WaitForFullGCApproach(WaitHandle.ToTimeoutMilliseconds(timeout));
	}

	public static GCNotificationStatus WaitForFullGCComplete(TimeSpan timeout)
	{
		return WaitForFullGCComplete(WaitHandle.ToTimeoutMilliseconds(timeout));
	}
}
