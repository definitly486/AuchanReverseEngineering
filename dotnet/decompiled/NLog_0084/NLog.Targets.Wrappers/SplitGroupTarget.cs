using System;
using System.Collections.Generic;
using System.Threading;
using NLog.Common;
using NLog.Internal;

namespace NLog.Targets.Wrappers;

[Target("SplitGroup", IsCompound = true)]
public class SplitGroupTarget : CompoundTargetBase
{
	public SplitGroupTarget()
		: this(ArrayHelper.Empty<Target>())
	{
	}

	public SplitGroupTarget(string name, params Target[] targets)
		: this(targets)
	{
		base.Name = name;
	}

	public SplitGroupTarget(params Target[] targets)
		: base(targets)
	{
	}

	protected override void Write(AsyncLogEventInfo logEvent)
	{
		if (base.Targets.Count == 0)
		{
			logEvent.Continuation(null);
			return;
		}
		if (base.Targets.Count > 1)
		{
			logEvent = logEvent.LogEvent.WithContinuation(CreateCountedContinuation(logEvent.Continuation, base.Targets.Count));
		}
		for (int i = 0; i < base.Targets.Count; i++)
		{
			base.Targets[i].WriteAsyncLogEvent(logEvent);
		}
	}

	protected override void Write(IList<AsyncLogEventInfo> logEvents)
	{
		InternalLogger.Trace("{0}: Writing {1} events", this, logEvents.Count);
		if (logEvents.Count == 1)
		{
			Write(logEvents[0]);
			return;
		}
		if (base.Targets.Count == 0 || logEvents.Count == 0)
		{
			for (int i = 0; i < logEvents.Count; i++)
			{
				logEvents[i].Continuation(null);
			}
			return;
		}
		if (base.Targets.Count > 1)
		{
			for (int j = 0; j < logEvents.Count; j++)
			{
				AsyncLogEventInfo asyncLogEventInfo = logEvents[j];
				logEvents[j] = asyncLogEventInfo.LogEvent.WithContinuation(CreateCountedContinuation(asyncLogEventInfo.Continuation, base.Targets.Count));
			}
		}
		for (int k = 0; k < base.Targets.Count; k++)
		{
			InternalLogger.Trace("{0}: Sending {1} events to {2}", this, logEvents.Count, base.Targets[k]);
			IList<AsyncLogEventInfo> logEvents2 = logEvents;
			if (k < base.Targets.Count - 1)
			{
				AsyncLogEventInfo[] array = new AsyncLogEventInfo[logEvents.Count];
				logEvents.CopyTo(array, 0);
				logEvents2 = array;
			}
			base.Targets[k].WriteAsyncLogEvents(logEvents2);
		}
	}

	private static AsyncContinuation CreateCountedContinuation(AsyncContinuation originalContinuation, int targetCounter)
	{
		List<Exception> exceptions = new List<Exception>();
		return delegate(Exception? ex)
		{
			if (ex != null)
			{
				lock (exceptions)
				{
					exceptions.Add(ex);
				}
			}
			int num = Interlocked.Decrement(ref targetCounter);
			if (num == 0)
			{
				Exception combinedException = AsyncHelpers.GetCombinedException(exceptions);
				InternalLogger.Trace("SplitGroup: Combined exception: {0}", combinedException);
				originalContinuation(combinedException);
			}
			else
			{
				InternalLogger.Trace("SplitGroup: {0} remaining.", num);
			}
		};
	}
}
