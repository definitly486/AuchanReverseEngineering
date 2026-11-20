using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers;

[LayoutRenderer("literal")]
[ThreadAgnostic]
[AppDomainFixedOutput]
public class LiteralLayoutRenderer : LayoutRenderer
{
	[DefaultParameter]
	public string Text { get; set; } = string.Empty;

	public LiteralLayoutRenderer()
	{
	}

	public LiteralLayoutRenderer(string text)
	{
		Text = text;
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		builder.Append(Text);
	}
}
