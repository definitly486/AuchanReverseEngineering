using System.Text;
using System.Threading;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("threadname")]
public class ThreadNameLayoutRenderer : LayoutRenderer, IStringValueRenderer
{
	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		builder.Append(GetStringValue());
	}

	private static string GetStringValue()
	{
		return Thread.CurrentThread.Name;
	}

	string IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		return GetStringValue();
	}
}
