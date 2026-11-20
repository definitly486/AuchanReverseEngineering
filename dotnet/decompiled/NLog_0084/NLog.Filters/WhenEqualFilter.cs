using System;

namespace NLog.Filters;

[Filter("whenEqual")]
public class WhenEqualFilter : LayoutBasedFilter
{
	public bool IgnoreCase { get; set; }

	public string CompareTo { get; set; } = string.Empty;

	protected override FilterResult Check(LogEventInfo logEvent)
	{
		StringComparison comparisonType = (IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		if (base.Layout.Render(logEvent).Equals(CompareTo, comparisonType))
		{
			return base.Action;
		}
		return FilterResult.Neutral;
	}
}
