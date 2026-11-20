using System;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("guid")]
[ThreadAgnostic]
public class GuidLayoutRenderer : LayoutRenderer, IRawValue, IStringValueRenderer
{
	public string Format { get; set; } = "N";

	public bool GeneratedFromLogEvent { get; set; }

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		builder.Append(GetStringValue(logEvent));
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object value)
	{
		value = GetValue(logEvent);
		return true;
	}

	string IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		return GetStringValue(logEvent);
	}

	private string GetStringValue(LogEventInfo logEvent)
	{
		return GetValue(logEvent).ToString(Format);
	}

	private Guid GetValue(LogEventInfo logEvent)
	{
		if (GeneratedFromLogEvent)
		{
			int hashCode = logEvent.GetHashCode();
			short b = (short)((hashCode >> 16) & 0xFFFF);
			short c = (short)(hashCode & 0xFFFF);
			long ticks = LogEventInfo.ZeroDate.Ticks;
			byte d = (byte)((ticks >> 56) & 0xFF);
			byte e = (byte)((ticks >> 48) & 0xFF);
			byte f = (byte)((ticks >> 40) & 0xFF);
			byte g = (byte)((ticks >> 32) & 0xFF);
			byte h = (byte)((ticks >> 24) & 0xFF);
			byte i = (byte)((ticks >> 16) & 0xFF);
			byte j = (byte)((ticks >> 8) & 0xFF);
			byte k = (byte)(ticks & 0xFF);
			return new Guid(logEvent.SequenceID, b, c, d, e, f, g, h, i, j, k);
		}
		return Guid.NewGuid();
	}
}
