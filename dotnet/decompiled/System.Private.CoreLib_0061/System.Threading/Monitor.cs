using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace System.Threading;

public static class Monitor
{
	public static long LockContentionCount => Monitor_get_lock_contention_count() + Lock.ContentionCount;

	[MethodImpl(MethodImplOptions.InternalCall)]
	[Intrinsic]
	public static extern void Enter(object obj);

	[Intrinsic]
	public static void Enter(object obj, ref bool lockTaken)
	{
		if (lockTaken)
		{
			throw new ArgumentException("Argument_MustBeFalse", "lockTaken");
		}
		ReliableEnterTimeout(obj, -1, ref lockTaken);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void InternalExit(object obj);

	public static void Exit(object obj)
	{
		if (obj == null)
		{
			ArgumentNullException.ThrowIfNull(obj, "obj");
		}
		if (!ObjectHeader.TryExitChecked(obj))
		{
			InternalExit(obj);
		}
	}

	public static bool TryEnter(object obj)
	{
		bool lockTaken = false;
		TryEnter(obj, 0, ref lockTaken);
		return lockTaken;
	}

	public static void TryEnter(object obj, ref bool lockTaken)
	{
		if (lockTaken)
		{
			throw new ArgumentException("Argument_MustBeFalse", "lockTaken");
		}
		ReliableEnterTimeout(obj, 0, ref lockTaken);
	}

	public static bool TryEnter(object obj, int millisecondsTimeout)
	{
		bool lockTaken = false;
		TryEnter(obj, millisecondsTimeout, ref lockTaken);
		return lockTaken;
	}

	public static void TryEnter(object obj, int millisecondsTimeout, ref bool lockTaken)
	{
		if (lockTaken)
		{
			throw new ArgumentException("Argument_MustBeFalse", "lockTaken");
		}
		ReliableEnterTimeout(obj, millisecondsTimeout, ref lockTaken);
	}

	public static bool IsEntered(object obj)
	{
		ArgumentNullException.ThrowIfNull(obj, "obj");
		return ObjectHeader.IsEntered(obj);
	}

	[UnsupportedOSPlatform("browser")]
	public static bool Wait(object obj, int millisecondsTimeout)
	{
		ArgumentNullException.ThrowIfNull(obj, "obj");
		return ObjWait(millisecondsTimeout, obj);
	}

	public static void Pulse(object obj)
	{
		ArgumentNullException.ThrowIfNull(obj, "obj");
		ObjPulse(obj);
	}

	public static void PulseAll(object obj)
	{
		ArgumentNullException.ThrowIfNull(obj, "obj");
		ObjPulseAll(obj);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Monitor_pulse(object obj);

	private static void ObjPulse(object obj)
	{
		if (!ObjectHeader.HasOwner(obj))
		{
			throw new SynchronizationLockException();
		}
		Monitor_pulse(obj);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Monitor_pulse_all(object obj);

	private static void ObjPulseAll(object obj)
	{
		if (!ObjectHeader.HasOwner(obj))
		{
			throw new SynchronizationLockException();
		}
		Monitor_pulse_all(obj);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool Monitor_wait(object obj, int ms, bool allowInterruption);

	private static bool ObjWait(int millisecondsTimeout, object obj)
	{
		if (millisecondsTimeout < 0 && millisecondsTimeout != -1)
		{
			throw new ArgumentOutOfRangeException("millisecondsTimeout");
		}
		if (!ObjectHeader.HasOwner(obj))
		{
			throw new SynchronizationLockException();
		}
		bool flag = millisecondsTimeout != 0 && NativeRuntimeEventSource.Log.IsEnabled(EventLevel.Verbose, (EventKeywords)4398046511104L);
		if (flag)
		{
			NativeRuntimeEventSource.Log.WaitHandleWaitStart(NativeRuntimeEventSource.WaitHandleWaitSourceMap.MonitorWait, obj);
		}
		bool result = Monitor_wait(obj, millisecondsTimeout, allowInterruption: true);
		if (flag)
		{
			NativeRuntimeEventSource.Log.WaitHandleWaitStop(0);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void try_enter_with_atomic_var(object obj, int millisecondsTimeout, bool allowInterruption, ref bool lockTaken);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void ReliableEnterTimeout(object obj, int timeout, ref bool lockTaken)
	{
		if (obj == null)
		{
			ArgumentNullException.ThrowIfNull(obj, "obj");
		}
		if (timeout < 0 && timeout != -1)
		{
			throw new ArgumentOutOfRangeException("timeout");
		}
		if (ObjectHeader.TryEnterFast(obj))
		{
			lockTaken = true;
		}
		else
		{
			try_enter_with_atomic_var(obj, timeout, allowInterruption: true, ref lockTaken);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern long Monitor_get_lock_contention_count();

	public static bool TryEnter(object obj, TimeSpan timeout)
	{
		return TryEnter(obj, WaitHandle.ToTimeoutMilliseconds(timeout));
	}

	public static void TryEnter(object obj, TimeSpan timeout, ref bool lockTaken)
	{
		TryEnter(obj, WaitHandle.ToTimeoutMilliseconds(timeout), ref lockTaken);
	}

	[UnsupportedOSPlatform("browser")]
	public static bool Wait(object obj, TimeSpan timeout)
	{
		return Wait(obj, WaitHandle.ToTimeoutMilliseconds(timeout));
	}

	[UnsupportedOSPlatform("browser")]
	public static bool Wait(object obj)
	{
		return Wait(obj, -1);
	}

	[UnsupportedOSPlatform("browser")]
	public static bool Wait(object obj, int millisecondsTimeout, bool exitContext)
	{
		return Wait(obj, millisecondsTimeout);
	}

	[UnsupportedOSPlatform("browser")]
	public static bool Wait(object obj, TimeSpan timeout, bool exitContext)
	{
		return Wait(obj, WaitHandle.ToTimeoutMilliseconds(timeout));
	}
}
