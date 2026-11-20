using System;
using System.Threading;
using NLog.Common;

namespace NLog.Internal;

[Obsolete("Marked obsolete on NLog 6.0")]
internal sealed class TimeoutContinuation : IDisposable
{
	private AsyncContinuation? _asyncContinuation;

	private Timer? _timeoutTimer;

	public TimeoutContinuation(AsyncContinuation asyncContinuation, TimeSpan timeout)
	{
		_asyncContinuation = asyncContinuation;
		_timeoutTimer = new Timer(TimerElapsed, null, (int)timeout.TotalMilliseconds, -1);
	}

	public void Function(Exception? exception)
	{
		try
		{
			AsyncContinuation? asyncContinuation = Interlocked.Exchange(ref _asyncContinuation, null);
			StopTimer();
			asyncContinuation?.Invoke(exception);
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "Exception in asynchronous handler.");
			if (ex.MustBeRethrown())
			{
				throw;
			}
		}
	}

	public void Dispose()
	{
		StopTimer();
	}

	private void StopTimer()
	{
		Interlocked.Exchange(ref _timeoutTimer, null)?.WaitForDispose(TimeSpan.Zero);
	}

	private void TimerElapsed(object state)
	{
		Function(new TimeoutException("Timeout."));
	}
}
