using System;
using System.Collections.Generic;
using System.Threading;
using NLog.Common;
using NLog.Internal;

namespace NLog.Targets.Wrappers;

[Target("FallbackGroup", IsCompound = true)]
public class FallbackGroupTarget : CompoundTargetBase
{
	private long _currentTarget;

	public bool ReturnToFirstOnSuccess { get; set; }

	public bool EnableBatchWrite { get; set; } = true;

	public FallbackGroupTarget()
		: this(ArrayHelper.Empty<Target>())
	{
	}

	public FallbackGroupTarget(string name, params Target[] targets)
		: this(targets)
	{
		base.Name = name;
	}

	public FallbackGroupTarget(params Target[] targets)
		: base(targets)
	{
	}

	protected override void WriteAsyncThreadSafe(IList<AsyncLogEventInfo> logEvents)
	{
		if (logEvents.Count == 1)
		{
			WriteAsyncThreadSafe(logEvents[0]);
		}
		else if (EnableBatchWrite)
		{
			int num = (int)Interlocked.Read(ref _currentTarget);
			for (int i = 0; i < logEvents.Count; i++)
			{
				logEvents[i] = WrapWithFallback(logEvents[i], num);
			}
			base.Targets[num].WriteAsyncLogEvents(logEvents);
		}
		else
		{
			for (int j = 0; j < logEvents.Count; j++)
			{
				WriteAsyncThreadSafe(logEvents[j]);
			}
		}
	}

	protected override void WriteAsyncThreadSafe(AsyncLogEventInfo logEvent)
	{
		Write(logEvent);
	}

	protected override void Write(AsyncLogEventInfo logEvent)
	{
		int num = (int)Interlocked.Read(ref _currentTarget);
		AsyncLogEventInfo logEvent2 = WrapWithFallback(logEvent, num);
		base.Targets[num].WriteAsyncLogEvent(logEvent2);
	}

	private AsyncLogEventInfo WrapWithFallback(AsyncLogEventInfo logEvent, int targetToInvoke)
	{
		for (int i = 0; i < base.Targets.Count; i++)
		{
			if (i != targetToInvoke)
			{
				base.Targets[i].PrecalculateVolatileLayouts(logEvent.LogEvent);
			}
		}
		AsyncContinuation continuation = null;
		int tryCounter = 0;
		continuation = delegate(Exception? ex)
		{
			if (ex == null)
			{
				if (ReturnToFirstOnSuccess && Interlocked.Read(ref _currentTarget) != 0L)
				{
					InternalLogger.Debug("{0}: Target '{1}' succeeded. Returning to the first one.", this, base.Targets[targetToInvoke]);
					Interlocked.Exchange(ref _currentTarget, 0L);
				}
				logEvent.Continuation(null);
			}
			else
			{
				tryCounter++;
				int num = (targetToInvoke + 1) % base.Targets.Count;
				Interlocked.CompareExchange(ref _currentTarget, num, targetToInvoke);
				if (tryCounter < base.Targets.Count)
				{
					InternalLogger.Warn(ex, "{0}: Target '{1}' failed. Fallback to next: `{2}`", new ReadOnlySpan<object>(new object[3]
					{
						this,
						base.Targets[targetToInvoke],
						base.Targets[num]
					}));
					targetToInvoke = num;
					base.Targets[targetToInvoke].WriteAsyncLogEvent((continuation == null) ? logEvent : logEvent.LogEvent.WithContinuation(continuation));
				}
				else
				{
					InternalLogger.Warn(ex, "{0}: Target '{1}' failed. Fallback not possible", new ReadOnlySpan<object>(new object[2]
					{
						this,
						base.Targets[targetToInvoke]
					}));
					logEvent.Continuation(ex);
				}
			}
		};
		return logEvent.LogEvent.WithContinuation(continuation);
	}
}
