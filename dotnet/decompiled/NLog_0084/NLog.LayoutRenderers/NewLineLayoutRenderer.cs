using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers;

[LayoutRenderer("newline")]
[ThreadAgnostic]
[AppDomainFixedOutput]
public class NewLineLayoutRenderer : LayoutRenderer
{
	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		builder.Append("\n");
	}
}
