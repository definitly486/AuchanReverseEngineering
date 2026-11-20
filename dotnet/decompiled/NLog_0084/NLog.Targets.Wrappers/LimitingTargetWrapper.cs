using System;
using NLog.Common;
using NLog.Layouts;

namespace NLog.Targets.Wrappers;

[Target("LimitingWrapper", IsWrapper = true)]
public class LimitingTargetWrapper : WrapperTargetBase
{
	private DateTime _firstWriteInInterval;

	public Layout<int> MessageLimit { get; set; }

	public Layout<TimeSpan> Interval { get; set; }

	public int MessagesWrittenCount { get; private set; }

	public LimitingTargetWrapper()
	{
		MessageLimit = 1000;
		Interval = TimeSpan.FromHours(1.0);
	}

	public LimitingTargetWrapper(string name, Target wrappedTarget)
		: this(wrappedTarget, 1000, TimeSpan.FromHours(1.0))
	{
		base.Name = name ?? base.Name;
	}

	public LimitingTargetWrapper(Target wrappedTarget)
		: this(wrappedTarget, 1000, TimeSpan.FromHours(1.0))
	{
	}

	public LimitingTargetWrapper(Target wrappedTarget, int messageLimit, TimeSpan interval)
	{
		base.Name = ((wrappedTarget == null || string.IsNullOrEmpty(wrappedTarget.Name)) ? base.Name : (wrappedTarget.Name + "_wrapper"));
		base.WrappedTarget = wrappedTarget;
		MessageLimit = messageLimit;
		Interval = interval;
	}

	protected override void InitializeTarget()
	{
		if (MessageLimit.IsFixed && MessageLimit.FixedValue <= 0)
		{
			throw new NLogConfigurationException("The LimitingTargetWrapper's MessageLimit property must be > 0.");
		}
		if (Interval.IsFixed && Interval.FixedValue <= TimeSpan.Zero)
		{
			throw new NLogConfigurationException("The LimitingTargetWrapper's property Interval must be > 0.");
		}
		base.InitializeTarget();
		ResetInterval(DateTime.MinValue);
		InternalLogger.Trace("{0}: Initialized with MessageLimit={1} and Interval={2}.", this, MessageLimit, Interval);
	}

	protected override void Write(AsyncLogEventInfo logEvent)
	{
		int num = RenderLogEvent(MessageLimit, logEvent.LogEvent, 0);
		TimeSpan timeSpan = RenderLogEvent(Interval, logEvent.LogEvent);
		if (logEvent.LogEvent.TimeStamp - _firstWriteInInterval > timeSpan)
		{
			ResetInterval(logEvent.LogEvent.TimeStamp);
			InternalLogger.Debug("{0}: New interval of '{1}' started.", this, timeSpan);
		}
		if (num <= 0 || MessagesWrittenCount < num)
		{
			base.WrappedTarget?.WriteAsyncLogEvent(logEvent);
			MessagesWrittenCount++;
		}
		else
		{
			logEvent.Continuation(null);
			InternalLogger.Trace("{0}: Discarded event, because MessageLimit of '{1}' was reached.", this, num);
		}
	}

	private void ResetInterval(DateTime timestamp)
	{
		_firstWriteInInterval = timestamp;
		MessagesWrittenCount = 0;
	}
}
