using System.Runtime.InteropServices;

namespace System.Threading;

[StructLayout(LayoutKind.Auto)]
internal struct LowLevelMonitor
{
	private nint _nativeMonitor;

	public void Dispose()
	{
		DisposeCore();
	}

	public void Acquire()
	{
		AcquireCore();
	}

	public void Release()
	{
		ReleaseCore();
	}

	public void Wait()
	{
		WaitCore();
	}

	public bool Wait(int timeoutMilliseconds)
	{
		return WaitCore(timeoutMilliseconds);
	}

	public void Signal_Release()
	{
		Signal_ReleaseCore();
	}

	public void Initialize()
	{
		_nativeMonitor = Interop.Sys.LowLevelMonitor_Create();
		if (_nativeMonitor == IntPtr.Zero)
		{
			throw new OutOfMemoryException();
		}
	}

	private void DisposeCore()
	{
		if (_nativeMonitor != IntPtr.Zero)
		{
			Interop.Sys.LowLevelMonitor_Destroy(_nativeMonitor);
			_nativeMonitor = IntPtr.Zero;
		}
	}

	private void AcquireCore()
	{
		Interop.Sys.LowLevelMonitor_Acquire(_nativeMonitor);
	}

	private void ReleaseCore()
	{
		Interop.Sys.LowLevelMonitor_Release(_nativeMonitor);
	}

	private void WaitCore()
	{
		Interop.Sys.LowLevelMonitor_Wait(_nativeMonitor);
	}

	private bool WaitCore(int timeoutMilliseconds)
	{
		if (timeoutMilliseconds < 0)
		{
			WaitCore();
			return true;
		}
		return Interop.Sys.LowLevelMonitor_TimedWait(_nativeMonitor, timeoutMilliseconds);
	}

	private void Signal_ReleaseCore()
	{
		Interop.Sys.LowLevelMonitor_Signal_Release(_nativeMonitor);
	}
}
