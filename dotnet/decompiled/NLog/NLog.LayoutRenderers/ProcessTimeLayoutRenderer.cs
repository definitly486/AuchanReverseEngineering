using System;
using System.Globalization;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("processtime")]
[ThreadAgnostic]
public class ProcessTimeLayoutRenderer : LayoutRenderer, IRawValue
{
	public bool Invariant
	{
		get
		{
			return Culture == CultureInfo.InvariantCulture;
		}
		set
		{
			Culture = (value ? CultureInfo.InvariantCulture : CultureInfo.CurrentCulture);
		}
	}

	public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		TimeSpan value = GetValue(logEvent);
		CultureInfo culture = GetCulture(logEvent, Culture);
		WriteTimestamp(builder, value, culture);
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object value)
	{
		value = GetValue(logEvent);
		return true;
	}

	internal static void WriteTimestamp(StringBuilder builder, TimeSpan ts, CultureInfo culture)
	{
		string value = ":";
		string value2 = ".";
		if (culture != CultureInfo.InvariantCulture)
		{
			value = culture.DateTimeFormat.TimeSeparator;
			value2 = culture.NumberFormat.NumberDecimalSeparator;
		}
		builder.Append2DigitsZeroPadded(ts.Hours);
		builder.Append(value);
		builder.Append2DigitsZeroPadded(ts.Minutes);
		builder.Append(value);
		builder.Append2DigitsZeroPadded(ts.Seconds);
		builder.Append(value2);
		int milliseconds = ts.Milliseconds;
		if (milliseconds < 100)
		{
			builder.Append('0');
			if (milliseconds < 10)
			{
				builder.Append('0');
				if (milliseconds < 0)
				{
					builder.Append('0');
					return;
				}
			}
		}
		builder.AppendInvariant(milliseconds);
	}

	private static TimeSpan GetValue(LogEventInfo logEvent)
	{
		return logEvent.TimeStamp.ToUniversalTime() - LogEventInfo.ZeroDate;
	}
}
