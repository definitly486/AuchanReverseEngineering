using System.Text;
using NLog.Config;
using NLog.Layouts;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("onhasproperties")]
[ThreadAgnostic]
public sealed class OnHasPropertiesLayoutRendererWrapper : WrapperLayoutRendererBase
{
	public Layout Else { get; set; } = Layout.Empty;

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		if (logEvent.HasProperties)
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
