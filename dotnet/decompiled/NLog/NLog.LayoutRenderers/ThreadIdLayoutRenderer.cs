using System.Globalization;
using System.Text;
using NLog.Common;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("threadid")]
public class ThreadIdLayoutRenderer : LayoutRenderer, IStringValueRenderer
{
	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		builder.AppendInvariant(GetValue());
	}

	private static int GetValue()
	{
		return AsyncHelpers.GetManagedThreadId();
	}

	string IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		return GetValue().ToString(CultureInfo.InvariantCulture);
	}
}
