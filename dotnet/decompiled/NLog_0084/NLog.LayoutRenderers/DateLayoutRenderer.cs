using System;
using System.Globalization;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("date")]
[ThreadAgnostic]
public class DateLayoutRenderer : LayoutRenderer, IRawValue, IStringValueRenderer
{
	private sealed class CachedDateFormatted
	{
		public readonly DateTime Date;

		public readonly string FormattedDate;

		public CachedDateFormatted(DateTime date, string formattedDate)
		{
			Date = date;
			FormattedDate = formattedDate;
		}
	}

	private string _format;

	private const string _lowTimeResolutionChars = "YyMDdHh";

	private CachedDateFormatted? _cachedDateFormatted;

	private bool _utcRoundRoundTrip;

	private bool? _universalTime;

	public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

	[DefaultParameter]
	public string Format
	{
		get
		{
			return _format;
		}
		set
		{
			_format = value;
			_cachedDateFormatted = (IsLowTimeResolutionLayout(_format) ? new CachedDateFormatted(DateTime.MaxValue, string.Empty) : null);
			_utcRoundRoundTrip = IsUtcRoundRountTripLayout(_format, _universalTime);
		}
	}

	public bool UniversalTime
	{
		get
		{
			return _universalTime == true;
		}
		set
		{
			_universalTime = value;
			_utcRoundRoundTrip = IsUtcRoundRountTripLayout(_format, _universalTime);
		}
	}

	public DateLayoutRenderer()
	{
		_format = (Format = "yyyy/MM/dd HH:mm:ss.fff");
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		DateTime value = GetValue(logEvent);
		if (_utcRoundRoundTrip && value.Kind != DateTimeKind.Local)
		{
			builder.AppendXmlDateTimeUtcRoundTripFixed(value);
			return;
		}
		IFormatProvider formatProvider = GetFormatProvider(logEvent, Culture);
		builder.Append(GetStringValue(value, formatProvider));
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object value)
	{
		value = GetValue(logEvent);
		return true;
	}

	string IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		return GetStringValue(GetValue(logEvent), GetFormatProvider(logEvent, Culture));
	}

	private string GetStringValue(DateTime timestamp, IFormatProvider? formatProvider)
	{
		CachedDateFormatted cachedDateFormatted = _cachedDateFormatted;
		if (formatProvider != CultureInfo.InvariantCulture)
		{
			cachedDateFormatted = null;
		}
		else if (cachedDateFormatted != null && cachedDateFormatted.Date == timestamp.Date.AddHours(timestamp.Hour))
		{
			return cachedDateFormatted.FormattedDate;
		}
		string text = timestamp.ToString(_format, formatProvider);
		if (cachedDateFormatted != null)
		{
			_cachedDateFormatted = new CachedDateFormatted(timestamp.Date.AddHours(timestamp.Hour), text);
		}
		return text;
	}

	private DateTime GetValue(LogEventInfo logEvent)
	{
		DateTime result = logEvent.TimeStamp;
		if (_universalTime.HasValue)
		{
			result = (_universalTime.Value ? result.ToUniversalTime() : result.ToLocalTime());
		}
		return result;
	}

	private static bool IsLowTimeResolutionLayout(string dateTimeFormat)
	{
		foreach (char c in dateTimeFormat)
		{
			if (char.IsLetter(c) && "YyMDdHh".IndexOf(c) < 0)
			{
				return false;
			}
		}
		return true;
	}

	private static bool IsUtcRoundRountTripLayout(string dateTimeFormat, bool? universalTime)
	{
		if (dateTimeFormat == "o" || dateTimeFormat == "O")
		{
			if (universalTime.HasValue)
			{
				return universalTime.Value;
			}
			return true;
		}
		return false;
	}
}
