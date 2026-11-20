using System.Globalization;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("ticks")]
[ThreadAgnostic]
public class TicksLayoutRenderer : LayoutRenderer, IRawValue
{
	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		builder.Append(GetValue(logEvent).ToString(CultureInfo.InvariantCulture));
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object value)
	{
		value = GetValue(logEvent);
		return true;
	}

	private static long GetValue(LogEventInfo logEvent)
	{
		return logEvent.TimeStamp.Ticks;
	}
}
