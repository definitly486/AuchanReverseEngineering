using NLog.Layouts;

namespace NLog.Filters;

public abstract class LayoutBasedFilter : Filter
{
	public Layout Layout { get; set; } = NLog.Layouts.Layout.Empty;
}
