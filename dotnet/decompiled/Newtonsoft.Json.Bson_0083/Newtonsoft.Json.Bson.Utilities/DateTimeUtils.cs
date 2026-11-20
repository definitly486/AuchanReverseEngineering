using System;
using System.Globalization;

namespace Newtonsoft.Json.Bson.Utilities;

internal static class DateTimeUtils
{
	internal static readonly long InitialJavaScriptDateTicks;

	private static readonly int[] DaysToMonth365;

	private static readonly int[] DaysToMonth366;

	static DateTimeUtils()
	{
		InitialJavaScriptDateTicks = 621355968000000000L;
		DaysToMonth365 = new int[13]
		{
			0, 31, 59, 90, 120, 151, 181, 212, 243, 273,
			304, 334, 365
		};
		DaysToMonth366 = new int[13]
		{
			0, 31, 60, 91, 121, 152, 182, 213, 244, 274,
			305, 335, 366
		};
	}

	public static TimeSpan GetUtcOffset(this DateTime d)
	{
		return TimeZoneInfo.Local.GetUtcOffset(d);
	}

	internal static DateTime EnsureDateTime(DateTime value, DateTimeZoneHandling timeZone)
	{
		switch (timeZone)
		{
		case DateTimeZoneHandling.Local:
			value = SwitchToLocalTime(value);
			break;
		case DateTimeZoneHandling.Utc:
			value = SwitchToUtcTime(value);
			break;
		case DateTimeZoneHandling.Unspecified:
			value = new DateTime(value.Ticks, DateTimeKind.Unspecified);
			break;
		default:
			throw new ArgumentException("Invalid date time handling value.");
		case DateTimeZoneHandling.RoundtripKind:
			break;
		}
		return value;
	}

	private static DateTime SwitchToLocalTime(DateTime value)
	{
		return value.Kind switch
		{
			DateTimeKind.Unspecified => new DateTime(value.Ticks, DateTimeKind.Local), 
			DateTimeKind.Utc => value.ToLocalTime(), 
			DateTimeKind.Local => value, 
			_ => value, 
		};
	}

	private static DateTime SwitchToUtcTime(DateTime value)
	{
		return value.Kind switch
		{
			DateTimeKind.Unspecified => new DateTime(value.Ticks, DateTimeKind.Utc), 
			DateTimeKind.Utc => value, 
			DateTimeKind.Local => value.ToUniversalTime(), 
			_ => value, 
		};
	}

	private static long ToUniversalTicks(DateTime dateTime)
	{
		if (dateTime.Kind == DateTimeKind.Utc)
		{
			return dateTime.Ticks;
		}
		return ToUniversalTicks(dateTime, dateTime.GetUtcOffset());
	}

	private static long ToUniversalTicks(DateTime dateTime, TimeSpan offset)
	{
		if (dateTime.Kind == DateTimeKind.Utc || dateTime == DateTime.MaxValue || dateTime == DateTime.MinValue)
		{
			return dateTime.Ticks;
		}
		long num = dateTime.Ticks - offset.Ticks;
		if (num > 3155378975999999999L)
		{
			return 3155378975999999999L;
		}
		if (num < 0)
		{
			return 0L;
		}
		return num;
	}

	internal static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime, TimeSpan offset)
	{
		return UniversialTicksToJavaScriptTicks(ToUniversalTicks(dateTime, offset));
	}

	internal static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime, bool convertToUtc)
	{
		return UniversialTicksToJavaScriptTicks(convertToUtc ? ToUniversalTicks(dateTime) : dateTime.Ticks);
	}

	private static long UniversialTicksToJavaScriptTicks(long universialTicks)
	{
		return (universialTicks - InitialJavaScriptDateTicks) / 10000;
	}

	internal static DateTime ConvertJavaScriptTicksToDateTime(long javaScriptTicks)
	{
		return new DateTime(javaScriptTicks * 10000 + InitialJavaScriptDateTicks, DateTimeKind.Utc);
	}

	internal static bool TryParseDateTimeOffsetIso(string text, out DateTimeOffset dt)
	{
		DateTimeParser dateTimeParser = default(DateTimeParser);
		if (!dateTimeParser.Parse(text, 0, text.Length))
		{
			dt = default(DateTimeOffset);
			return false;
		}
		DateTime dateTime = CreateDateTime(dateTimeParser);
		TimeSpan offset = dateTimeParser.Zone switch
		{
			ParserTimeZone.Utc => new TimeSpan(0L), 
			ParserTimeZone.LocalWestOfUtc => new TimeSpan(-dateTimeParser.ZoneHour, -dateTimeParser.ZoneMinute, 0), 
			ParserTimeZone.LocalEastOfUtc => new TimeSpan(dateTimeParser.ZoneHour, dateTimeParser.ZoneMinute, 0), 
			_ => TimeZoneInfo.Local.GetUtcOffset(dateTime), 
		};
		long num = dateTime.Ticks - offset.Ticks;
		if (num < 0 || num > 3155378975999999999L)
		{
			dt = default(DateTimeOffset);
			return false;
		}
		dt = new DateTimeOffset(dateTime, offset);
		return true;
	}

	private static DateTime CreateDateTime(DateTimeParser dateTimeParser)
	{
		bool flag;
		if (dateTimeParser.Hour == 24)
		{
			flag = true;
			dateTimeParser.Hour = 0;
		}
		else
		{
			flag = false;
		}
		DateTime result = new DateTime(dateTimeParser.Year, dateTimeParser.Month, dateTimeParser.Day, dateTimeParser.Hour, dateTimeParser.Minute, dateTimeParser.Second).AddTicks(dateTimeParser.Fraction);
		if (flag)
		{
			result = result.AddDays(1.0);
		}
		return result;
	}

	internal static bool TryParseDateTime(string s, DateTimeZoneHandling dateTimeZoneHandling, string dateFormatString, CultureInfo culture, out DateTime dt)
	{
		if (s.Length > 0)
		{
			if (s[0] == '/')
			{
				if (s.Length >= 9 && s.StartsWith("/Date(", StringComparison.Ordinal) && s.EndsWith(")/", StringComparison.Ordinal) && TryParseDateTimeMicrosoft(s, dateTimeZoneHandling, out dt))
				{
					return true;
				}
			}
			else if (s.Length >= 19 && s.Length <= 40 && char.IsDigit(s[0]) && s[10] == 'T' && DateTime.TryParseExact(s, "yyyy-MM-ddTHH:mm:ss.FFFFFFFK", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dt))
			{
				dt = EnsureDateTime(dt, dateTimeZoneHandling);
				return true;
			}
			if (!string.IsNullOrEmpty(dateFormatString) && TryParseDateTimeExact(s, dateTimeZoneHandling, dateFormatString, culture, out dt))
			{
				return true;
			}
		}
		dt = default(DateTime);
		return false;
	}

	internal static bool TryParseDateTimeOffset(string s, string dateFormatString, CultureInfo culture, out DateTimeOffset dt)
	{
		if (s.Length > 0)
		{
			if (s[0] == '/')
			{
				if (s.Length >= 9 && s.StartsWith("/Date(", StringComparison.Ordinal) && s.EndsWith(")/", StringComparison.Ordinal) && TryParseDateTimeOffsetMicrosoft(s, out dt))
				{
					return true;
				}
			}
			else if (s.Length >= 19 && s.Length <= 40 && char.IsDigit(s[0]) && s[10] == 'T' && DateTimeOffset.TryParseExact(s, "yyyy-MM-ddTHH:mm:ss.FFFFFFFK", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dt) && TryParseDateTimeOffsetIso(s, out dt))
			{
				return true;
			}
			if (!string.IsNullOrEmpty(dateFormatString) && TryParseDateTimeOffsetExact(s, dateFormatString, culture, out dt))
			{
				return true;
			}
		}
		dt = default(DateTimeOffset);
		return false;
	}

	private static bool TryParseMicrosoftDate(string text, out long ticks, out TimeSpan offset, out DateTimeKind kind)
	{
		kind = DateTimeKind.Utc;
		int num = text.IndexOf('+', 7, text.Length - 8);
		if (num == -1)
		{
			num = text.IndexOf('-', 7, text.Length - 8);
		}
		if (num != -1)
		{
			kind = DateTimeKind.Local;
			if (!TryReadOffset(text, num, out offset))
			{
				ticks = 0L;
				return false;
			}
		}
		else
		{
			offset = TimeSpan.Zero;
			num = text.Length - 2;
		}
		return long.TryParse(text.Substring(6, num - 6), out ticks);
	}

	private static bool TryParseDateTimeMicrosoft(string text, DateTimeZoneHandling dateTimeZoneHandling, out DateTime dt)
	{
		if (!TryParseMicrosoftDate(text, out var ticks, out var _, out var kind))
		{
			dt = default(DateTime);
			return false;
		}
		DateTime dateTime = ConvertJavaScriptTicksToDateTime(ticks);
		switch (kind)
		{
		case DateTimeKind.Unspecified:
			dt = DateTime.SpecifyKind(dateTime.ToLocalTime(), DateTimeKind.Unspecified);
			break;
		case DateTimeKind.Local:
			dt = dateTime.ToLocalTime();
			break;
		default:
			dt = dateTime;
			break;
		}
		dt = EnsureDateTime(dt, dateTimeZoneHandling);
		return true;
	}

	private static bool TryParseDateTimeExact(string text, DateTimeZoneHandling dateTimeZoneHandling, string dateFormatString, CultureInfo culture, out DateTime dt)
	{
		if (DateTime.TryParseExact(text, dateFormatString, culture, DateTimeStyles.RoundtripKind, out var result))
		{
			result = EnsureDateTime(result, dateTimeZoneHandling);
			dt = result;
			return true;
		}
		dt = default(DateTime);
		return false;
	}

	private static bool TryParseDateTimeOffsetMicrosoft(string text, out DateTimeOffset dt)
	{
		if (!TryParseMicrosoftDate(text, out var ticks, out var offset, out var _))
		{
			dt = default(DateTime);
			return false;
		}
		dt = new DateTimeOffset(ConvertJavaScriptTicksToDateTime(ticks).Add(offset).Ticks, offset);
		return true;
	}

	private static bool TryParseDateTimeOffsetExact(string text, string dateFormatString, CultureInfo culture, out DateTimeOffset dt)
	{
		if (DateTimeOffset.TryParseExact(text, dateFormatString, culture, DateTimeStyles.RoundtripKind, out var result))
		{
			dt = result;
			return true;
		}
		dt = default(DateTimeOffset);
		return false;
	}

	private static bool TryReadOffset(string offsetText, int startIndex, out TimeSpan offset)
	{
		bool flag = offsetText[startIndex] == '-';
		if (int.TryParse(offsetText.Substring(startIndex + 1, 2), out var result))
		{
			offset = default(TimeSpan);
			return false;
		}
		int result2 = 0;
		if (offsetText.Length - startIndex > 5 && int.TryParse(offsetText.Substring(startIndex + 3, 2), out result2))
		{
			offset = default(TimeSpan);
			return false;
		}
		offset = TimeSpan.FromHours((double)result) + TimeSpan.FromMinutes((double)result2);
		if (flag)
		{
			offset = offset.Negate();
		}
		return true;
	}
}
