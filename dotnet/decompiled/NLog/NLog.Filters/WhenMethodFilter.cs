using System;
using NLog.Internal;

namespace NLog.Filters;

public class WhenMethodFilter : Filter
{
	private readonly Func<LogEventInfo, FilterResult> _filterMethod;

	public WhenMethodFilter(Func<LogEventInfo, FilterResult> filterMethod)
	{
		Guard.ThrowIfNull(filterMethod, "filterMethod");
		_filterMethod = filterMethod;
	}

	protected override FilterResult Check(LogEventInfo logEvent)
	{
		FilterResult filterResult = _filterMethod(logEvent);
		if (base.Action == FilterResult.Neutral)
		{
			return filterResult;
		}
		if (filterResult != FilterResult.Neutral)
		{
			return base.Action;
		}
		return FilterResult.Neutral;
	}
}
