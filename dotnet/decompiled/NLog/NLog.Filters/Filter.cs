using NLog.Config;

namespace NLog.Filters;

[NLogConfigurationItem]
public abstract class Filter
{
	public FilterResult Action { get; set; }

	protected Filter()
	{
		Action = FilterResult.Neutral;
	}

	internal FilterResult GetFilterResult(LogEventInfo logEvent)
	{
		return Check(logEvent);
	}

	protected abstract FilterResult Check(LogEventInfo logEvent);
}
