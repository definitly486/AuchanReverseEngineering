using System;
using System.Collections.Generic;
using System.Threading;
using NLog.Common;
using NLog.Layouts;

namespace NLog.Targets.Wrappers;

[Target("RetryingWrapper", IsWrapper = true)]
public class RetryingTargetWrapper : WrapperTargetBase
{
	private readonly object _retrySyncObject = new object();

	public Layout<int> RetryCount { get; set; }

	public Layout<int> RetryDelayMilliseconds { get; set; }

	public bool EnableBatchWrite { get; set; } = true;

	public RetryingTargetWrapper()
	{
		RetryCount = 3;
		RetryDelayMilliseconds = 100;
	}

	public RetryingTargetWrapper(string name, Target wrappedTarget, int retryCount, int retryDelayMilliseconds)
		: this(wrappedTarget, retryCount, retryDelayMilliseconds)
	{
		base.Name = name ?? base.Name;
	}

	public RetryingTargetWrapper(Target wrappedTarget, int retryCount, int retryDelayMilliseconds)
	{
		base.Name = ((wrappedTarget == null || string.IsNullOrEmpty(wrappedTarget.Name)) ? base.Name : (wrappedTarget.Name + "_wrapper"));
		base.WrappedTarget = wrappedTarget;
		RetryCount = retryCount;
		RetryDelayMilliseconds = retryDelayMilliseconds;
	}

	protected override void WriteAsyncThreadSafe(IList<AsyncLogEventInfo> logEvents)
	{
		if (logEvents.Count == 1)
		{
			WriteAsyncThreadSafe(logEvents[0]);
			return;
		}
		if (EnableBatchWrite)
		{
			int initialSleep = 1;
			Func<int, bool> sleepBeforeRetry = (int retryNumber) => retryNumber > 1 || Interlocked.Exchange(ref initialSleep, 0) == 1;
			for (int num = 0; num < logEvents.Count; num++)
			{
				logEvents[num] = WrapWithRetry(logEvents[num], sleepBeforeRetry);
			}
			lock (_retrySyncObject)
			{
				base.WrappedTarget?.WriteAsyncLogEvents(logEvents);
				return;
			}
		}
		lock (_retrySyncObject)
		{
			for (int num2 = 0; num2 < logEvents.Count; num2++)
			{
				WriteAsyncThreadSafe(logEvents[num2]);
			}
		}
	}

	protected override void WriteAsyncThreadSafe(AsyncLogEventInfo logEvent)
	{
		lock (_retrySyncObject)
		{
			Write(logEvent);
		}
	}

	protected override void Write(AsyncLogEventInfo logEvent)
	{
		base.WrappedTarget?.WriteAsyncLogEvent(WrapWithRetry(logEvent, (int retryNumber) => true));
	}

	private AsyncLogEventInfo WrapWithRetry(AsyncLogEventInfo logEvent, Func<int, bool> sleepBeforeRetry)
	{
		AsyncContinuation continuation = null;
		int counter = 0;
		continuation = delegate(Exception? ex)
		{
			if (ex == null)
			{
				logEvent.Continuation(null);
			}
			else
			{
				int num = Interlocked.Increment(ref counter);
				int num2 = RetryCount.RenderValue(logEvent.LogEvent, 0);
				int num3 = RetryDelayMilliseconds.RenderValue(logEvent.LogEvent, 0);
				InternalLogger.Warn(ex, "{0}: Error while writing to '{1}'. Try {2}/{3}", new ReadOnlySpan<object>(new object[4] { this, base.WrappedTarget, num, num2 }));
				if (num >= num2)
				{
					InternalLogger.Warn("{0}: Too many retries. Aborting.", this);
					logEvent.Continuation(ex);
				}
				else
				{
					if (sleepBeforeRetry(num))
					{
						int num4 = 0;
						while (num4 < num3)
						{
							int num5 = Math.Min(100, num3 - num4);
							AsyncHelpers.WaitForDelay(TimeSpan.FromMilliseconds((double)num5));
							num4 += num5;
							if (!base.IsInitialized)
							{
								InternalLogger.Warn("{0}): Target closed. Aborting.", this);
								logEvent.Continuation(ex);
								return;
							}
						}
					}
					base.WrappedTarget?.WriteAsyncLogEvent((continuation == null) ? logEvent : logEvent.LogEvent.WithContinuation(continuation));
				}
			}
		};
		return logEvent.LogEvent.WithContinuation(continuation);
	}
}
