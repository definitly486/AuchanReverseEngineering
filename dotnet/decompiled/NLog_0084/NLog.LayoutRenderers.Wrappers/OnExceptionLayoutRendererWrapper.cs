using System.Text;
using NLog.Config;
using NLog.Layouts;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("onexception")]
[ThreadAgnostic]
public sealed class OnExceptionLayoutRendererWrapper : WrapperLayoutRendererBase
{
	public Layout Else { get; set; } = Layout.Empty;

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		if (logEvent.Exception != null)
		{
			base.Inner?.Render(logEvent, builder);
		}
		else
		{
			Else?.Render(logEvent, builder);
		}
	}

	protected override string Transform(string text)
	{
		return text;
	}
}
