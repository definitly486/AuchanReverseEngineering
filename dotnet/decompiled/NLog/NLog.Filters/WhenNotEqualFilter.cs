using System;

namespace NLog.Filters;

[Filter("whenNotEqual")]
public class WhenNotEqualFilter : LayoutBasedFilter
{
	public string CompareTo { get; set; } = string.Empty;

	public bool IgnoreCase { get; set; }

	protected override FilterResult Check(LogEventInfo logEvent)
	{
		StringComparison comparisonType = (IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		if (!base.Layout.Render(logEvent).Equals(CompareTo, comparisonType))
		{
			return base.Action;
		}
		return FilterResult.Neutral;
	}
}
