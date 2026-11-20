using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using Microsoft.Win32.SafeHandles;

namespace System.Threading;

public abstract class WaitHandle : MarshalByRefObject, IDisposable
{
	protected static readonly nint InvalidHandle = new IntPtr(-1);

	private SafeWaitHandle _waitHandle;

	[ThreadStatic]
	private static SafeWaitHandle[] t_safeWaitHandlesForRent;

	public const int WaitTimeout = 258;

	[Obsolete("WaitHandle.Handle has been deprecated. Use the SafeWaitHandle property instead.")]
	public virtual nint Handle
	{
		get
		{
			if (_waitHandle != null)
			{
				return _waitHandle.DangerousGetHandle();
			}
			return InvalidHandle;
		}
		set
		{
			if (value == InvalidHandle)
			{
				if (_waitHandle != null)
				{
					_waitHandle.SetHandleAsInvalid();
					_waitHandle = null;
				}
			}
			else
			{
				_waitHandle = new SafeWaitHandle(value, ownsHandle: true);
			}
		}
	}

	public SafeWaitHandle SafeWaitHandle
	{
		get
		{
			return _waitHandle ?? (_waitHandle = new SafeWaitHandle(InvalidHandle, ownsHandle: false));
		}
		[param: AllowNull]
		set
		{
			_waitHandle = value;
		}
	}

	internal static int ToTimeoutMilliseconds(TimeSpan timeout)
	{
		long num = (long)timeout.TotalMilliseconds;
		ArgumentOutOfRangeException.ThrowIfLessThan(num, -1L, "timeout");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(num, 2147483647L, "timeout");
		return (int)num;
	}

	public virtual void Close()
	{
		Dispose();
	}

	protected virtual void Dispose(bool explicitDisposing)
	{
		_waitHandle?.Close();
	}

	public void Dispose()
	{
		Dispose(explicitDisposing: true);
		GC.SuppressFinalize(this);
	}

	public virtual bool WaitOne(int millisecondsTimeout)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(millisecondsTimeout, -1, "millisecondsTimeout");
		return WaitOneNoCheck(millisecondsTimeout);
	}

	internal bool WaitOneNoCheck(int millisecondsTimeout, bool useTrivialWaits = false, object associatedObject = null, NativeRuntimeEventSource.WaitHandleWaitSourceMap waitSource = NativeRuntimeEventSource.WaitHandleWaitSourceMap.Unknown)
	{
		SafeWaitHandle waitHandle = _waitHandle;
		ObjectDisposedException.ThrowIf(waitHandle == null, this);
		bool success = false;
		try
		{
			waitHandle.DangerousAddRef(ref success);
			int num = -1;
			bool flag = false;
			if (!useTrivialWaits)
			{
				SynchronizationContext current = SynchronizationContext.Current;
				if (current != null && current.IsWaitNotificationRequired())
				{
					flag = true;
					num = current.Wait(new nint[1] { waitHandle.DangerousGetHandle() }, waitAll: false, millisecondsTimeout);
				}
			}
			if (!flag)
			{
				bool flag2 = millisecondsTimeout != 0 && !useTrivialWaits && NativeRuntimeEventSource.Log.IsEnabled(EventLevel.Verbose, (EventKeywords)4398046511104L);
				bool flag3 = flag2 && waitSource != NativeRuntimeEventSource.WaitHandleWaitSourceMap.MonitorWait;
				if (flag3)
				{
					num = WaitOneCore(waitHandle.DangerousGetHandle(), 0, useTrivialWaits);
					if (num == 258)
					{
						flag3 = false;
					}
					else
					{
						flag2 = false;
					}
				}
				if (flag2)
				{
					NativeRuntimeEventSource.Log.WaitHandleWaitStart(waitSource, associatedObject ?? this);
				}
				if (!flag3)
				{
					num = WaitOneCore(waitHandle.DangerousGetHandle(), millisecondsTimeout, useTrivialWaits);
				}
				if (flag2)
				{
					NativeRuntimeEventSource.Log.WaitHandleWaitStop(0);
				}
			}
			if (num == 128)
			{
				throw new AbandonedMutexException();
			}
			return num != 258;
		}
		finally
		{
			if (success)
			{
				waitHandle.DangerousRelease();
			}
		}
	}

	private static SafeWaitHandle[] RentSafeWaitHandleArray(int capacity)
	{
		SafeWaitHandle[] array = t_safeWaitHandlesForRent;
		t_safeWaitHandlesForRent = null;
		int num = ((array != null) ? array.Length : 0);
		if (num < capacity)
		{
			array = new SafeWaitHandle[Math.Max(capacity, Math.Min(64, 2 * num))];
		}
		return array;
	}

	private static void ReturnSafeWaitHandleArray(SafeWaitHandle[] safeWaitHandles)
	{
		t_safeWaitHandlesForRent = safeWaitHandles;
	}

	private static void ObtainSafeWaitHandles(ReadOnlySpan<WaitHandle> waitHandles, Span<SafeWaitHandle> safeWaitHandles, Span<nint> unsafeWaitHandles)
	{
		bool success = true;
		SafeWaitHandle safeWaitHandle = null;
		try
		{
			for (int i = 0; i < waitHandles.Length; i++)
			{
				WaitHandle waitHandle = waitHandles[i] ?? throw new ArgumentNullException($"waitHandles[{i}]", "ArgumentNull_ArrayElement");
				SafeWaitHandle waitHandle2 = waitHandle._waitHandle;
				ObjectDisposedException.ThrowIf(waitHandle2 == null, waitHandle);
				safeWaitHandle = waitHandle2;
				success = false;
				waitHandle2.DangerousAddRef(ref success);
				safeWaitHandles[i] = waitHandle2;
				unsafeWaitHandles[i] = waitHandle2.DangerousGetHandle();
			}
		}
		catch
		{
			for (int j = 0; j < waitHandles.Length; j++)
			{
				SafeWaitHandle safeWaitHandle2 = safeWaitHandles[j];
				if (safeWaitHandle2 == null)
				{
					break;
				}
				safeWaitHandle2.DangerousRelease();
				safeWaitHandles[j] = null;
				if (safeWaitHandle2 == safeWaitHandle)
				{
					safeWaitHandle = null;
					success = true;
				}
			}
			if (!success)
			{
				safeWaitHandle.DangerousRelease();
			}
			throw;
		}
	}

	private static int WaitMultiple(WaitHandle[] waitHandles, bool waitAll, int millisecondsTimeout)
	{
		ArgumentNullException.ThrowIfNull(waitHandles, "waitHandles");
		return WaitMultiple(new ReadOnlySpan<WaitHandle>(waitHandles), waitAll, millisecondsTimeout);
	}

	private unsafe static int WaitMultiple(ReadOnlySpan<WaitHandle> waitHandles, bool waitAll, int millisecondsTimeout)
	{
		if (waitHandles.Length == 0)
		{
			throw new ArgumentException("Argument_EmptyWaithandleArray", "waitHandles");
		}
		if (waitHandles.Length > 64)
		{
			throw new NotSupportedException("NotSupported_MaxWaitHandles");
		}
		ArgumentOutOfRangeException.ThrowIfLessThan(millisecondsTimeout, -1, "millisecondsTimeout");
		SynchronizationContext current = SynchronizationContext.Current;
		bool flag = current?.IsWaitNotificationRequired() ?? false;
		SafeWaitHandle[] array = RentSafeWaitHandleArray(waitHandles.Length);
		try
		{
			int num;
			if (flag)
			{
				nint[] array2 = new nint[waitHandles.Length];
				ObtainSafeWaitHandles(waitHandles, array, array2);
				num = current.Wait(array2, waitAll, millisecondsTimeout);
			}
			else
			{
				int length = waitHandles.Length;
				Span<nint> span = new Span<nint>(stackalloc byte[(int)checked(unchecked((nuint)(uint)length) * (nuint)8u)], length);
				ObtainSafeWaitHandles(waitHandles, array, span);
				num = WaitMultipleIgnoringSyncContext(span, waitAll, millisecondsTimeout);
			}
			if (num >= 128 && num < 128 + waitHandles.Length)
			{
				if (waitAll)
				{
					throw new AbandonedMutexException();
				}
				num -= 128;
				throw new AbandonedMutexException(num, waitHandles[num]);
			}
			return num;
		}
		finally
		{
			for (int i = 0; i < waitHandles.Length; i++)
			{
				SafeWaitHandle safeWaitHandle = array[i];
				if (safeWaitHandle != null)
				{
					safeWaitHandle.DangerousRelease();
					array[i] = null;
				}
			}
			ReturnSafeWaitHandleArray(array);
		}
	}

	private unsafe static int WaitAnyMultiple(ReadOnlySpan<SafeWaitHandle> safeWaitHandles, int millisecondsTimeout)
	{
		SynchronizationContext current = SynchronizationContext.Current;
		if (current != null && current.IsWaitNotificationRequired())
		{
			nint[] array = new nint[safeWaitHandles.Length];
			for (int i = 0; i < safeWaitHandles.Length; i++)
			{
				array[i] = safeWaitHandles[i].DangerousGetHandle();
			}
			return current.Wait(array, waitAll: false, millisecondsTimeout);
		}
		int length = safeWaitHandles.Length;
		Span<nint> span = new Span<nint>(stackalloc byte[(int)checked(unchecked((nuint)(uint)length) * (nuint)8u)], length);
		for (int j = 0; j < safeWaitHandles.Length; j++)
		{
			span[j] = safeWaitHandles[j].DangerousGetHandle();
		}
		return WaitMultipleIgnoringSyncContext(span, waitAll: false, millisecondsTimeout);
	}

	internal static int WaitMultipleIgnoringSyncContext(ReadOnlySpan<nint> handles, bool waitAll, int millisecondsTimeout)
	{
		int num = -1;
		bool flag = millisecondsTimeout != 0 && NativeRuntimeEventSource.Log.IsEnabled(EventLevel.Verbose, (EventKeywords)4398046511104L);
		bool flag2 = flag;
		if (flag2)
		{
			num = WaitMultipleIgnoringSyncContextCore(handles, waitAll, 0);
			if (num == 258)
			{
				flag2 = false;
			}
			else
			{
				flag = false;
			}
		}
		if (flag)
		{
			NativeRuntimeEventSource.Log.WaitHandleWaitStart();
		}
		if (!flag2)
		{
			num = WaitMultipleIgnoringSyncContextCore(handles, waitAll, millisecondsTimeout);
		}
		if (flag)
		{
			NativeRuntimeEventSource.Log.WaitHandleWaitStop(0);
		}
		return num;
	}

	private static bool SignalAndWait(WaitHandle toSignal, WaitHandle toWaitOn, int millisecondsTimeout)
	{
		ArgumentNullException.ThrowIfNull(toSignal, "toSignal");
		ArgumentNullException.ThrowIfNull(toWaitOn, "toWaitOn");
		ArgumentOutOfRangeException.ThrowIfLessThan(millisecondsTimeout, -1, "millisecondsTimeout");
		SafeWaitHandle waitHandle = toSignal._waitHandle;
		SafeWaitHandle waitHandle2 = toWaitOn._waitHandle;
		ObjectDisposedException.ThrowIf(waitHandle == null, toSignal);
		ObjectDisposedException.ThrowIf(waitHandle2 == null, toWaitOn);
		bool success = false;
		bool success2 = false;
		try
		{
			waitHandle.DangerousAddRef(ref success);
			waitHandle2.DangerousAddRef(ref success2);
			int num = SignalAndWaitCore(waitHandle.DangerousGetHandle(), waitHandle2.DangerousGetHandle(), millisecondsTimeout);
			if (num == 128)
			{
				throw new AbandonedMutexException();
			}
			return num != 258;
		}
		finally
		{
			if (success2)
			{
				waitHandle2.DangerousRelease();
			}
			if (success)
			{
				waitHandle.DangerousRelease();
			}
		}
	}

	internal static void ThrowInvalidHandleException()
	{
		throw new InvalidOperationException("InvalidOperation_InvalidHandle")
		{
			HResult = -2147024890
		};
	}

	public virtual bool WaitOne(TimeSpan timeout)
	{
		return WaitOneNoCheck(ToTimeoutMilliseconds(timeout));
	}

	public virtual bool WaitOne()
	{
		return WaitOneNoCheck(-1);
	}

	public virtual bool WaitOne(int millisecondsTimeout, bool exitContext)
	{
		return WaitOne(millisecondsTimeout);
	}

	public virtual bool WaitOne(TimeSpan timeout, bool exitContext)
	{
		return WaitOneNoCheck(ToTimeoutMilliseconds(timeout));
	}

	public static bool WaitAll(WaitHandle[] waitHandles, int millisecondsTimeout)
	{
		return WaitMultiple(waitHandles, waitAll: true, millisecondsTimeout) != 258;
	}

	public static bool WaitAll(WaitHandle[] waitHandles, TimeSpan timeout)
	{
		return WaitMultiple(waitHandles, waitAll: true, ToTimeoutMilliseconds(timeout)) != 258;
	}

	public static bool WaitAll(WaitHandle[] waitHandles)
	{
		return WaitMultiple(waitHandles, waitAll: true, -1) != 258;
	}

	public static bool WaitAll(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext)
	{
		return WaitMultiple(waitHandles, waitAll: true, millisecondsTimeout) != 258;
	}

	public static bool WaitAll(WaitHandle[] waitHandles, TimeSpan timeout, bool exitContext)
	{
		return WaitMultiple(waitHandles, waitAll: true, ToTimeoutMilliseconds(timeout)) != 258;
	}

	public static int WaitAny(WaitHandle[] waitHandles, int millisecondsTimeout)
	{
		return WaitMultiple(waitHandles, waitAll: false, millisecondsTimeout);
	}

	internal static int WaitAny(ReadOnlySpan<SafeWaitHandle> safeWaitHandles, int millisecondsTimeout)
	{
		return WaitAnyMultiple(safeWaitHandles, millisecondsTimeout);
	}

	public static int WaitAny(WaitHandle[] waitHandles, TimeSpan timeout)
	{
		return WaitMultiple(waitHandles, waitAll: false, ToTimeoutMilliseconds(timeout));
	}

	public static int WaitAny(WaitHandle[] waitHandles)
	{
		return WaitMultiple(waitHandles, waitAll: false, -1);
	}

	public static int WaitAny(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext)
	{
		return WaitMultiple(waitHandles, waitAll: false, millisecondsTimeout);
	}

	public static int WaitAny(WaitHandle[] waitHandles, TimeSpan timeout, bool exitContext)
	{
		return WaitMultiple(waitHandles, waitAll: false, ToTimeoutMilliseconds(timeout));
	}

	public static bool SignalAndWait(WaitHandle toSignal, WaitHandle toWaitOn)
	{
		return SignalAndWait(toSignal, toWaitOn, -1);
	}

	public static bool SignalAndWait(WaitHandle toSignal, WaitHandle toWaitOn, TimeSpan timeout, bool exitContext)
	{
		return SignalAndWait(toSignal, toWaitOn, ToTimeoutMilliseconds(timeout));
	}

	public static bool SignalAndWait(WaitHandle toSignal, WaitHandle toWaitOn, int millisecondsTimeout, bool exitContext)
	{
		return SignalAndWait(toSignal, toWaitOn, millisecondsTimeout);
	}

	private static int WaitOneCore(nint handle, int millisecondsTimeout, bool useTrivialWaits)
	{
		return WaitSubsystem.Wait(handle, millisecondsTimeout, !useTrivialWaits);
	}

	private static int WaitMultipleIgnoringSyncContextCore(ReadOnlySpan<nint> handles, bool waitAll, int millisecondsTimeout)
	{
		return WaitSubsystem.Wait(handles, waitAll, millisecondsTimeout);
	}

	private static int SignalAndWaitCore(nint handleToSignal, nint handleToWaitOn, int millisecondsTimeout)
	{
		return WaitSubsystem.SignalAndWait(handleToSignal, handleToWaitOn, millisecondsTimeout);
	}
}
