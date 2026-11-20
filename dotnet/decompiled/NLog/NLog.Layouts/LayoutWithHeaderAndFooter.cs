using System.Text;
using NLog.Config;

namespace NLog.Layouts;

[Layout("LayoutWithHeaderAndFooter")]
[ThreadAgnostic]
[AppDomainFixedOutput]
public class LayoutWithHeaderAndFooter : Layout
{
	public Layout Layout { get; set; } = NLog.Layouts.Layout.Empty;

	public Layout? Header { get; set; }

	public Layout? Footer { get; set; }

	protected override string GetFormattedMessage(LogEventInfo logEvent)
	{
		return Layout.Render(logEvent);
	}

	protected override void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
	{
		Layout.Render(logEvent, target);
	}
}
