using System.Threading;

namespace System.Diagnostics;

internal sealed class ProcessWaitHandle : WaitHandle
{
	internal ProcessWaitHandle(ProcessWaitState processWaitState)
	{
		ManualResetEvent waitHandle = processWaitState.EnsureExitedEvent();
		this.SetSafeWaitHandle(waitHandle.GetSafeWaitHandle());
	}

	protected override void Dispose(bool explicitDisposing)
	{
		base.SafeWaitHandle = null;
		base.Dispose(explicitDisposing);
	}
}
