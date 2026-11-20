using System.Collections.Generic;
using NLog.Common;
using NLog.Conditions;
using NLog.Config;
using NLog.Internal;

namespace NLog.Targets.Wrappers;

[Target("PostFilteringWrapper", IsWrapper = true)]
public class PostFilteringTargetWrapper : WrapperTargetBase
{
	public ConditionExpression? DefaultFilter { get; set; }

	[ArrayParameter(typeof(FilteringRule), "when")]
	public IList<FilteringRule> Rules { get; } = new List<FilteringRule>();

	public PostFilteringTargetWrapper()
	{
	}

	public PostFilteringTargetWrapper(Target wrappedTarget)
		: this(string.Empty, wrappedTarget)
	{
	}

	public PostFilteringTargetWrapper(string name, Target wrappedTarget)
	{
		base.Name = ((!string.IsNullOrEmpty(name) || wrappedTarget == null || string.IsNullOrEmpty(wrappedTarget.Name)) ? name : (wrappedTarget.Name + "_wrapper"));
		base.WrappedTarget = wrappedTarget;
	}

	protected override void InitializeTarget()
	{
		base.InitializeTarget();
		foreach (FilteringRule rule in Rules)
		{
			if (rule.Exists == null)
			{
				throw new NLogConfigurationException("PostFilteringTargetWrapper When-Rules with unassigned Exists-property.");
			}
			if (rule.Filter == null)
			{
				throw new NLogConfigurationException("PostFilteringTargetWrapper When-Rules with unassigned Filter-property.");
			}
		}
	}

	protected override void Write(AsyncLogEventInfo logEvent)
	{
		Write(new AsyncLogEventInfo[1] { logEvent });
	}

	protected override void Write(IList<AsyncLogEventInfo> logEvents)
	{
		InternalLogger.Trace("{0}: Running on {1} events", this, logEvents.Count);
		ConditionExpression conditionExpression = EvaluateAllRules(logEvents);
		if (conditionExpression == null)
		{
			base.WrappedTarget?.WriteAsyncLogEvents(logEvents);
			return;
		}
		InternalLogger.Trace("{0}: Filter to apply: {1}", this, conditionExpression);
		IList<AsyncLogEventInfo> list = logEvents.Filter(conditionExpression, (AsyncLogEventInfo logEvent, ConditionExpression filter) => ShouldLogEvent(logEvent, filter));
		InternalLogger.Trace("{0}: After filtering: {1} events.", this, list.Count);
		if (list.Count > 0)
		{
			InternalLogger.Trace("{0}: Sending to {1}", this, base.WrappedTarget);
			base.WrappedTarget?.WriteAsyncLogEvents(list);
		}
	}

	private static bool ShouldLogEvent(AsyncLogEventInfo logEvent, ConditionExpression resultFilter)
	{
		object obj = resultFilter.Evaluate(logEvent.LogEvent);
		if (ConditionExpression.BoxedTrue.Equals(obj))
		{
			return true;
		}
		logEvent.Continuation(null);
		return false;
	}

	private ConditionExpression? EvaluateAllRules(IList<AsyncLogEventInfo> logEvents)
	{
		if (Rules.Count == 0)
		{
			return DefaultFilter;
		}
		for (int i = 0; i < logEvents.Count; i++)
		{
			for (int j = 0; j < Rules.Count; j++)
			{
				FilteringRule filteringRule = Rules[j];
				object obj = filteringRule.Exists?.Evaluate(logEvents[i].LogEvent);
				if (ConditionExpression.BoxedTrue.Equals(obj))
				{
					InternalLogger.Trace("{0}: Rule matched: {1}", this, filteringRule.Exists);
					return filteringRule.Filter;
				}
			}
		}
		return DefaultFilter;
	}
}
