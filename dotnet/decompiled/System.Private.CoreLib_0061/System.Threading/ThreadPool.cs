using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace System.Threading;

public static class ThreadPool
{
	internal static readonly ThreadPoolWorkQueue s_workQueue = new ThreadPoolWorkQueue();

	internal static readonly Action<object> s_invokeAsyncStateMachineBox = delegate(object state)
	{
		if (state is IAsyncStateMachineBox asyncStateMachineBox)
		{
			asyncStateMachineBox.MoveNext();
		}
		else
		{
			ThrowHelper.ThrowUnexpectedStateForKnownCallback(state);
		}
	};

	private static readonly bool IsWorkerTrackingEnabledInConfig = AppContextConfigHelper.GetBooleanConfig("System.Threading.ThreadPool.EnableWorkerTracking", "DOTNET_ThreadPool_EnableWorkerTracking");

	internal static bool EnableWorkerTracking
	{
		get
		{
			if (IsWorkerTrackingEnabledInConfig)
			{
				return false;
			}
			return false;
		}
	}

	public static long PendingWorkItemCount
	{
		get
		{
			ThreadPoolWorkQueue threadPoolWorkQueue = s_workQueue;
			return ThreadPoolWorkQueue.LocalCount + threadPoolWorkQueue.GlobalCount;
		}
	}

	public static int ThreadCount => PortableThreadPool.ThreadPoolInstance.ThreadCount;

	public static long CompletedWorkItemCount => PortableThreadPool.ThreadPoolInstance.CompletedWorkItemCount;

	[UnsupportedOSPlatform("browser")]
	[CLSCompliant(false)]
	public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object? state, uint millisecondsTimeOutInterval, bool executeOnlyOnce)
	{
		if (millisecondsTimeOutInterval > int.MaxValue && millisecondsTimeOutInterval != uint.MaxValue)
		{
			throw new ArgumentOutOfRangeException("millisecondsTimeOutInterval", "ArgumentOutOfRange_LessEqualToIntegerMaxVal");
		}
		return RegisterWaitForSingleObject(waitObject, callBack, state, millisecondsTimeOutInterval, executeOnlyOnce, flowExecutionContext: true);
	}

	[UnsupportedOSPlatform("browser")]
	[CLSCompliant(false)]
	public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object? state, uint millisecondsTimeOutInterval, bool executeOnlyOnce)
	{
		if (millisecondsTimeOutInterval > int.MaxValue && millisecondsTimeOutInterval != uint.MaxValue)
		{
			throw new ArgumentOutOfRangeException("millisecondsTimeOutInterval", "ArgumentOutOfRange_NeedNonNegOrNegative1");
		}
		return RegisterWaitForSingleObject(waitObject, callBack, state, millisecondsTimeOutInterval, executeOnlyOnce, flowExecutionContext: false);
	}

	[UnsupportedOSPlatform("browser")]
	public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object? state, int millisecondsTimeOutInterval, bool executeOnlyOnce)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(millisecondsTimeOutInterval, -1, "millisecondsTimeOutInterval");
		return RegisterWaitForSingleObject(waitObject, callBack, state, (uint)millisecondsTimeOutInterval, executeOnlyOnce, flowExecutionContext: true);
	}

	[UnsupportedOSPlatform("browser")]
	public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object? state, int millisecondsTimeOutInterval, bool executeOnlyOnce)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(millisecondsTimeOutInterval, -1, "millisecondsTimeOutInterval");
		return RegisterWaitForSingleObject(waitObject, callBack, state, (uint)millisecondsTimeOutInterval, executeOnlyOnce, flowExecutionContext: false);
	}

	[UnsupportedOSPlatform("browser")]
	public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object? state, long millisecondsTimeOutInterval, bool executeOnlyOnce)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(millisecondsTimeOutInterval, -1L, "millisecondsTimeOutInterval");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(millisecondsTimeOutInterval, 2147483647L, "millisecondsTimeOutInterval");
		return RegisterWaitForSingleObject(waitObject, callBack, state, (uint)millisecondsTimeOutInterval, executeOnlyOnce, flowExecutionContext: true);
	}

	[UnsupportedOSPlatform("browser")]
	public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object? state, long millisecondsTimeOutInterval, bool executeOnlyOnce)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(millisecondsTimeOutInterval, -1L, "millisecondsTimeOutInterval");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(millisecondsTimeOutInterval, 2147483647L, "millisecondsTimeOutInterval");
		return RegisterWaitForSingleObject(waitObject, callBack, state, (uint)millisecondsTimeOutInterval, executeOnlyOnce, flowExecutionContext: false);
	}

	[UnsupportedOSPlatform("browser")]
	public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object? state, TimeSpan timeout, bool executeOnlyOnce)
	{
		long num = (long)timeout.TotalMilliseconds;
		ArgumentOutOfRangeException.ThrowIfLessThan(num, -1L, "timeout");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(num, 2147483647L, "timeout");
		return RegisterWaitForSingleObject(waitObject, callBack, state, (uint)num, executeOnlyOnce, flowExecutionContext: true);
	}

	[UnsupportedOSPlatform("browser")]
	public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object? state, TimeSpan timeout, bool executeOnlyOnce)
	{
		long num = (long)timeout.TotalMilliseconds;
		ArgumentOutOfRangeException.ThrowIfLessThan(num, -1L, "timeout");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(num, 2147483647L, "timeout");
		return RegisterWaitForSingleObject(waitObject, callBack, state, (uint)num, executeOnlyOnce, flowExecutionContext: false);
	}

	public static bool QueueUserWorkItem(WaitCallback callBack)
	{
		return QueueUserWorkItem(callBack, null);
	}

	public static bool QueueUserWorkItem(WaitCallback callBack, object? state)
	{
		if (callBack == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.callBack);
		}
		ExecutionContext executionContext = ExecutionContext.Capture();
		object callback = ((executionContext == null || executionContext.IsDefault) ? ((QueueUserWorkItemCallbackBase)new QueueUserWorkItemCallbackDefaultContext(callBack, state)) : ((QueueUserWorkItemCallbackBase)new QueueUserWorkItemCallback(callBack, state, executionContext)));
		s_workQueue.Enqueue(callback, forceGlobal: true);
		return true;
	}

	public static bool QueueUserWorkItem<TState>(Action<TState> callBack, TState state, bool preferLocal)
	{
		if (callBack == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.callBack);
		}
		ExecutionContext executionContext = ExecutionContext.Capture();
		object callback = ((executionContext == null || executionContext.IsDefault) ? ((QueueUserWorkItemCallbackBase)new QueueUserWorkItemCallbackDefaultContext<TState>(callBack, state)) : ((QueueUserWorkItemCallbackBase)new QueueUserWorkItemCallback<TState>(callBack, state, executionContext)));
		s_workQueue.Enqueue(callback, !preferLocal);
		return true;
	}

	public static bool UnsafeQueueUserWorkItem<TState>(Action<TState> callBack, TState state, bool preferLocal)
	{
		if (callBack == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.callBack);
		}
		if ((object)callBack == s_invokeAsyncStateMachineBox)
		{
			if (!(state is IAsyncStateMachineBox))
			{
				ThrowHelper.ThrowUnexpectedStateForKnownCallback(state);
			}
			UnsafeQueueUserWorkItemInternal(state, preferLocal);
			return true;
		}
		s_workQueue.Enqueue(new QueueUserWorkItemCallbackDefaultContext<TState>(callBack, state), !preferLocal);
		return true;
	}

	public static bool UnsafeQueueUserWorkItem(WaitCallback callBack, object? state)
	{
		if (callBack == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.callBack);
		}
		object callback = new QueueUserWorkItemCallbackDefaultContext(callBack, state);
		s_workQueue.Enqueue(callback, forceGlobal: true);
		return true;
	}

	public static bool UnsafeQueueUserWorkItem(IThreadPoolWorkItem callBack, bool preferLocal)
	{
		if (callBack == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.callBack);
		}
		if (callBack is Task)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.callBack);
		}
		UnsafeQueueUserWorkItemInternal(callBack, preferLocal);
		return true;
	}

	internal static void UnsafeQueueUserWorkItemInternal(object callBack, bool preferLocal)
	{
		s_workQueue.Enqueue(callBack, !preferLocal);
	}

	internal static void UnsafeQueueHighPriorityWorkItemInternal(IThreadPoolWorkItem callBack)
	{
		s_workQueue.EnqueueAtHighPriority(callBack);
	}

	internal static bool TryPopCustomWorkItem(object workItem)
	{
		return ThreadPoolWorkQueue.LocalFindAndPop(workItem);
	}

	internal static IEnumerable<object> GetQueuedWorkItems()
	{
		foreach (object highPriorityWorkItem in s_workQueue.highPriorityWorkItems)
		{
			yield return highPriorityWorkItem;
		}
		ConcurrentQueue<object>[] assignableWorkItemQueues = s_workQueue._assignableWorkItemQueues;
		foreach (ConcurrentQueue<object> concurrentQueue in assignableWorkItemQueues)
		{
			foreach (object item in concurrentQueue)
			{
				yield return item;
			}
		}
		foreach (object workItem in s_workQueue.workItems)
		{
			yield return workItem;
		}
		ThreadPoolWorkQueue.WorkStealingQueue[] queues = ThreadPoolWorkQueue.WorkStealingQueueList.Queues;
		foreach (ThreadPoolWorkQueue.WorkStealingQueue workStealingQueue in queues)
		{
			if (workStealingQueue == null || workStealingQueue.m_array == null)
			{
				continue;
			}
			object[] items = workStealingQueue.m_array;
			foreach (object obj in items)
			{
				if (obj != null)
				{
					yield return obj;
				}
			}
		}
	}

	internal static object GetOrCreateThreadLocalCompletionCountObject()
	{
		return PortableThreadPool.ThreadPoolInstance.GetOrCreateThreadLocalCompletionCountObject();
	}

	public static bool SetMaxThreads(int workerThreads, int completionPortThreads)
	{
		return PortableThreadPool.ThreadPoolInstance.SetMaxThreads(workerThreads, completionPortThreads);
	}

	public static void GetMaxThreads(out int workerThreads, out int completionPortThreads)
	{
		PortableThreadPool.ThreadPoolInstance.GetMaxThreads(out workerThreads, out completionPortThreads);
	}

	public static bool SetMinThreads(int workerThreads, int completionPortThreads)
	{
		return PortableThreadPool.ThreadPoolInstance.SetMinThreads(workerThreads, completionPortThreads);
	}

	public static void GetMinThreads(out int workerThreads, out int completionPortThreads)
	{
		PortableThreadPool.ThreadPoolInstance.GetMinThreads(out workerThreads, out completionPortThreads);
	}

	public static void GetAvailableThreads(out int workerThreads, out int completionPortThreads)
	{
		PortableThreadPool.ThreadPoolInstance.GetAvailableThreads(out workerThreads, out completionPortThreads);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void NotifyWorkItemProgress()
	{
		PortableThreadPool.ThreadPoolInstance.NotifyWorkItemProgress();
	}

	internal static bool NotifyThreadBlocked()
	{
		return PortableThreadPool.ThreadPoolInstance.NotifyThreadBlocked();
	}

	internal static void NotifyThreadUnblocked()
	{
		PortableThreadPool.ThreadPoolInstance.NotifyThreadUnblocked();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool NotifyWorkItemComplete(object threadLocalCompletionCountObject, int currentTimeMs)
	{
		return PortableThreadPool.ThreadPoolInstance.NotifyWorkItemComplete(threadLocalCompletionCountObject, currentTimeMs);
	}

	internal static void RequestWorkerThread()
	{
		PortableThreadPool.ThreadPoolInstance.RequestWorker();
	}

	internal static void ReportThreadStatus(bool isWorking)
	{
		PortableThreadPool.ThreadPoolInstance.ReportThreadStatus(isWorking);
	}

	internal static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, uint millisecondsTimeOutInterval, bool executeOnlyOnce, bool flowExecutionContext)
	{
		Thread.ThrowIfNoThreadStart();
		return PortableThreadPool.RegisterWaitForSingleObject(waitObject, callBack, state, millisecondsTimeOutInterval, executeOnlyOnce, flowExecutionContext);
	}

	[CLSCompliant(false)]
	[SupportedOSPlatform("windows")]
	public unsafe static bool UnsafeQueueNativeOverlapped(NativeOverlapped* overlapped)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_OverlappedIO");
	}

	[Obsolete("ThreadPool.BindHandle(IntPtr) has been deprecated. Use ThreadPool.BindHandle(SafeHandle) instead.")]
	[SupportedOSPlatform("windows")]
	public static bool BindHandle(nint osHandle)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_OverlappedIO");
	}

	[SupportedOSPlatform("windows")]
	public static bool BindHandle(SafeHandle osHandle)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_OverlappedIO");
	}
}
