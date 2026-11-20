using System;

namespace NLog.Filters;

[Filter("whenNotContains")]
public class WhenNotContainsFilter : LayoutBasedFilter
{
	public string Substring { get; set; } = string.Empty;

	public bool IgnoreCase { get; set; }

	protected override FilterResult Check(LogEventInfo logEvent)
	{
		StringComparison comparisonType = (IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		string text = base.Layout.Render(logEvent);
		if (!string.IsNullOrEmpty(Substring) && text.IndexOf(Substring, comparisonType) < 0)
		{
			return base.Action;
		}
		return FilterResult.Neutral;
	}
}
