using System;

namespace Java.Interop;

public struct JniTransition : IDisposable
{
	private bool disposed;

	private Exception? pendingException;

	public JniTransition(nint environmentPointer)
	{
		disposed = false;
		pendingException = null;
		JniEnvironment.SetEnvironmentPointer(environmentPointer);
	}

	public void SetPendingException(Exception exception)
	{
		if (disposed)
		{
			throw new ObjectDisposedException("JniTransition");
		}
		pendingException = exception;
	}

	public void Dispose()
	{
		if (!disposed)
		{
			disposed = true;
			if (pendingException != null)
			{
				JniEnvironment.Runtime.RaisePendingException(pendingException);
				pendingException = null;
			}
		}
	}
}
