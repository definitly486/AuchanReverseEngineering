using System.Collections.Generic;
using NLog.Common;
using NLog.Conditions;
using NLog.Filters;
using NLog.Internal;

namespace NLog.Targets.Wrappers;

[Target("FilteringWrapper", IsWrapper = true)]
public class FilteringTargetWrapper : WrapperTargetBase
{
	public ConditionExpression? Condition
	{
		get
		{
			return (Filter as ConditionBasedFilter)?.Condition;
		}
		set
		{
			Filter = CreateFilter(value);
		}
	}

	public Filter Filter { get; set; }

	public FilteringTargetWrapper()
	{
		Filter = ConditionBasedFilter.Empty;
	}

	public FilteringTargetWrapper(string name, Target wrappedTarget, ConditionExpression condition)
		: this(wrappedTarget, condition)
	{
		base.Name = name ?? base.Name;
	}

	public FilteringTargetWrapper(Target wrappedTarget, ConditionExpression condition)
	{
		base.Name = ((wrappedTarget == null || string.IsNullOrEmpty(wrappedTarget.Name)) ? base.Name : (wrappedTarget.Name + "_wrapper"));
		base.WrappedTarget = wrappedTarget;
		Filter = CreateFilter(condition);
	}

	protected override void InitializeTarget()
	{
		if (Filter == null || Filter == ConditionBasedFilter.Empty)
		{
			throw new NLogConfigurationException("FilteringTargetWrapper Filter-property must be assigned. Filter LogEvents using blank Filter not supported.");
		}
		base.InitializeTarget();
	}

	protected override void Write(AsyncLogEventInfo logEvent)
	{
		if (ShouldLogEvent(logEvent, Filter))
		{
			base.WrappedTarget?.WriteAsyncLogEvent(logEvent);
		}
	}

	protected override void Write(IList<AsyncLogEventInfo> logEvents)
	{
		IList<AsyncLogEventInfo> list = logEvents.Filter(Filter, (AsyncLogEventInfo logEvent, Filter filter) => ShouldLogEvent(logEvent, filter));
		if (list.Count > 0)
		{
			base.WrappedTarget?.WriteAsyncLogEvents(list);
		}
	}

	private static bool ShouldLogEvent(AsyncLogEventInfo logEvent, Filter filter)
	{
		FilterResult filterResult = filter.GetFilterResult(logEvent.LogEvent);
		if (filterResult != FilterResult.Ignore && filterResult != FilterResult.IgnoreFinal)
		{
			return true;
		}
		logEvent.Continuation(null);
		return false;
	}

	private static ConditionBasedFilter CreateFilter(ConditionExpression? value)
	{
		if (value == null)
		{
			return ConditionBasedFilter.Empty;
		}
		return new ConditionBasedFilter
		{
			Condition = value,
			FilterDefaultAction = FilterResult.Ignore
		};
	}
}
