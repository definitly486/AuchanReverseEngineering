using System;
using System.Threading;

namespace Polly.Utilities;

internal readonly struct TimedLock : IDisposable
{
	private static readonly TimeSpan LockTimeout = TimeSpan.FromMilliseconds(2147483647.0);

	private readonly object _target;

	public static TimedLock Lock(object o)
	{
		return Lock(o, LockTimeout);
	}

	private static TimedLock Lock(object o, TimeSpan timeout)
	{
		TimedLock result = new TimedLock(o);
		if (!Monitor.TryEnter(o, timeout))
		{
			throw new LockTimeoutException();
		}
		return result;
	}

	private TimedLock(object o)
	{
		_target = o;
	}

	public void Dispose()
	{
		Monitor.Exit(_target);
	}
}
