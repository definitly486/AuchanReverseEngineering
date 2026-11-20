using System;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("longdate")]
[ThreadAgnostic]
public class LongDateLayoutRenderer : LayoutRenderer, IRawValue
{
	private bool? _universalTime;

	public bool UniversalTime
	{
		get
		{
			return _universalTime == true;
		}
		set
		{
			_universalTime = value;
		}
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		DateTime value = GetValue(logEvent);
		builder.Append4DigitsZeroPadded(value.Year);
		builder.Append('-');
		builder.Append2DigitsZeroPadded(value.Month);
		builder.Append('-');
		builder.Append2DigitsZeroPadded(value.Day);
		builder.Append(' ');
		builder.Append2DigitsZeroPadded(value.Hour);
		builder.Append(':');
		builder.Append2DigitsZeroPadded(value.Minute);
		builder.Append(':');
		builder.Append2DigitsZeroPadded(value.Second);
		builder.Append('.');
		builder.Append4DigitsZeroPadded((int)(value.Ticks % 10000000) / 1000);
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object value)
	{
		value = GetValue(logEvent);
		return true;
	}

	private DateTime GetValue(LogEventInfo logEvent)
	{
		DateTime timeStamp = logEvent.TimeStamp;
		if (_universalTime.HasValue)
		{
			if (!_universalTime.Value)
			{
				return timeStamp.ToLocalTime();
			}
			return timeStamp.ToUniversalTime();
		}
		return timeStamp;
	}
}
