using NLog.Common;

namespace NLog.Targets.Wrappers;

[Target("RepeatingWrapper", IsWrapper = true)]
public class RepeatingTargetWrapper : WrapperTargetBase
{
	public int RepeatCount { get; set; } = 3;

	public RepeatingTargetWrapper()
	{
	}

	public RepeatingTargetWrapper(string name, Target wrappedTarget, int repeatCount)
		: this(wrappedTarget, repeatCount)
	{
		base.Name = name;
	}

	public RepeatingTargetWrapper(Target wrappedTarget, int repeatCount)
	{
		base.Name = ((wrappedTarget == null || string.IsNullOrEmpty(wrappedTarget.Name)) ? base.Name : (wrappedTarget.Name + "_wrapper"));
		base.WrappedTarget = wrappedTarget;
		RepeatCount = repeatCount;
	}

	protected override void Write(AsyncLogEventInfo logEvent)
	{
		AsyncHelpers.Repeat(RepeatCount, logEvent.Continuation, delegate(AsyncContinuation cont)
		{
			base.WrappedTarget?.WriteAsyncLogEvent(logEvent.LogEvent.WithContinuation(cont));
		});
	}
}
