using System.Runtime.Versioning;
using Microsoft.Win32.SafeHandles;

namespace System.Threading;

[UnsupportedOSPlatform("browser")]
public sealed class RegisteredWaitHandle : MarshalByRefObject
{
	private SafeWaitHandle _waitHandle;

	private readonly _ThreadPoolWaitOrTimerCallback _callbackHelper;

	private readonly int _signedMillisecondsTimeout;

	private bool _repeating;

	private static AutoResetEvent s_cachedEvent;

	private static readonly LowLevelLock s_callbackLock = new LowLevelLock();

	private int _numRequestedCallbacks;

	private bool _signalAfterCallbacksComplete;

	private bool _unregisterCalled;

	private bool _unregistered;

	private AutoResetEvent _callbacksComplete;

	private AutoResetEvent _removed;

	internal _ThreadPoolWaitOrTimerCallback? Callback => _callbackHelper;

	internal SafeWaitHandle Handle => _waitHandle;

	internal int TimeoutTimeMs { get; private set; }

	internal int TimeoutDurationMs => _signedMillisecondsTimeout;

	internal bool IsInfiniteTimeout => TimeoutDurationMs == -1;

	internal bool Repeating => _repeating;

	private SafeWaitHandle? UserUnregisterWaitHandle { get; set; }

	private nint UserUnregisterWaitHandleValue { get; set; }

	private static nint InvalidHandleValue => new IntPtr(-1);

	internal bool IsBlocking => UserUnregisterWaitHandleValue == InvalidHandleValue;

	internal PortableThreadPool.WaitThread? WaitThread { get; set; }

	public bool Unregister(WaitHandle waitObject)
	{
		return UnregisterPortableCore(waitObject);
	}

	internal void PerformCallback(bool timedOut)
	{
		PerformCallbackPortableCore(timedOut);
	}

	internal RegisteredWaitHandle(WaitHandle waitHandle, _ThreadPoolWaitOrTimerCallback callbackHelper, int millisecondsTimeout, bool repeating)
	{
		GC.SuppressFinalize(this);
		Thread.ThrowIfNoThreadStart();
		_waitHandle = waitHandle.SafeWaitHandle;
		_callbackHelper = callbackHelper;
		_signedMillisecondsTimeout = millisecondsTimeout;
		_repeating = repeating;
		if (!IsInfiniteTimeout)
		{
			RestartTimeout();
		}
	}

	private static AutoResetEvent RentEvent()
	{
		return Interlocked.Exchange(ref s_cachedEvent, null) ?? new AutoResetEvent(initialState: false);
	}

	private static void ReturnEvent(AutoResetEvent resetEvent)
	{
		if (Interlocked.CompareExchange(ref s_cachedEvent, resetEvent, null) != null)
		{
			resetEvent.Dispose();
		}
	}

	internal void RestartTimeout()
	{
		TimeoutTimeMs = Environment.TickCount + TimeoutDurationMs;
	}

	private bool UnregisterPortableCore(WaitHandle waitObject)
	{
		s_callbackLock.Acquire();
		bool success = false;
		try
		{
			if (_unregisterCalled)
			{
				return false;
			}
			UserUnregisterWaitHandle = waitObject?.SafeWaitHandle;
			UserUnregisterWaitHandle?.DangerousAddRef(ref success);
			UserUnregisterWaitHandleValue = UserUnregisterWaitHandle?.DangerousGetHandle() ?? IntPtr.Zero;
			if (_unregistered)
			{
				SignalUserWaitHandle();
				return true;
			}
			if (IsBlocking)
			{
				_callbacksComplete = RentEvent();
			}
			else
			{
				_removed = RentEvent();
			}
		}
		catch (Exception)
		{
			if (_removed != null)
			{
				ReturnEvent(_removed);
				_removed = null;
			}
			else if (_callbacksComplete != null)
			{
				ReturnEvent(_callbacksComplete);
				_callbacksComplete = null;
			}
			UserUnregisterWaitHandleValue = IntPtr.Zero;
			if (success)
			{
				UserUnregisterWaitHandle?.DangerousRelease();
			}
			UserUnregisterWaitHandle = null;
			throw;
		}
		finally
		{
			_unregisterCalled = true;
			s_callbackLock.Release();
		}
		WaitThread.UnregisterWait(this);
		return true;
	}

	private void SignalUserWaitHandle()
	{
		SafeWaitHandle userUnregisterWaitHandle = UserUnregisterWaitHandle;
		nint userUnregisterWaitHandleValue = UserUnregisterWaitHandleValue;
		try
		{
			if (userUnregisterWaitHandleValue != IntPtr.Zero && userUnregisterWaitHandleValue != InvalidHandleValue)
			{
				EventWaitHandle.Set(userUnregisterWaitHandle);
			}
		}
		finally
		{
			userUnregisterWaitHandle?.DangerousRelease();
			_callbacksComplete?.Set();
			_unregistered = true;
		}
	}

	internal void PerformCallbackPortableCore(bool timedOut)
	{
		_ThreadPoolWaitOrTimerCallback.PerformWaitOrTimerCallback(Callback, timedOut);
		CompleteCallbackRequest();
	}

	internal void RequestCallback()
	{
		s_callbackLock.Acquire();
		try
		{
			_numRequestedCallbacks++;
		}
		finally
		{
			s_callbackLock.Release();
		}
	}

	internal void OnRemoveWait()
	{
		s_callbackLock.Acquire();
		try
		{
			_removed?.Set();
			if (_numRequestedCallbacks == 0)
			{
				SignalUserWaitHandle();
			}
			else
			{
				_signalAfterCallbacksComplete = true;
			}
		}
		finally
		{
			s_callbackLock.Release();
		}
	}

	private void CompleteCallbackRequest()
	{
		s_callbackLock.Acquire();
		try
		{
			_numRequestedCallbacks--;
			if (_numRequestedCallbacks == 0 && _signalAfterCallbacksComplete)
			{
				SignalUserWaitHandle();
			}
		}
		finally
		{
			s_callbackLock.Release();
		}
	}

	internal void WaitForCallbacks()
	{
		_callbacksComplete.WaitOne();
		ReturnEvent(_callbacksComplete);
		_callbacksComplete = null;
	}

	internal void WaitForRemoval()
	{
		_removed.WaitOne();
		ReturnEvent(_removed);
		_removed = null;
	}
}
