using System;
using System.Globalization;
using System.Linq;

namespace Auchan.Common.Extensions;

public static class DateTimeExtensions
{
	public static DateTime YearsAgo(this DateTime dateTime, int years)
	{
		return dateTime.AddYears(-years);
	}

	public static string ToShortDate(this DateTime dateTime)
	{
		return dateTime.ToString("dd.MM.yyyy");
	}

	public static string ToLongDate(this DateTime dateTime)
	{
		return dateTime.ToString("dd.MM.yyyy HH:mm:ss.ffff");
	}

	public static DateTime UTCToMoscow(this DateTime dateTime)
	{
		return dateTime.AddHours(3.0);
	}

	public static string ToLongDateWithFullMonth(this DateTime dateTime)
	{
		CultureInfo cultureInfo = new CultureInfo("ru-RU");
		cultureInfo.DateTimeFormat.MonthGenitiveNames = cultureInfo.DateTimeFormat.MonthGenitiveNames.Select((string x) => x.FirstCharToUpper()).ToArray();
		return dateTime.ToString("d MMMM yyyy", cultureInfo);
	}

	public static string ToDayAndMonth(this DateTime dateTime)
	{
		CultureInfo cultureInfo = new CultureInfo("ru-RU");
		cultureInfo.DateTimeFormat.MonthGenitiveNames = cultureInfo.DateTimeFormat.MonthGenitiveNames.Select((string x) => x.FirstCharToUpper()).ToArray();
		return dateTime.ToString("d MMMM", cultureInfo);
	}

	public static string ToTransactionDateTime(this DateTime dateTime)
	{
		CultureInfo cultureInfo = new CultureInfo("ru-RU");
		cultureInfo.DateTimeFormat.MonthGenitiveNames = cultureInfo.DateTimeFormat.MonthGenitiveNames.Select((string x) => x.FirstCharToUpper()).ToArray();
		return dateTime.ToString("d MMMM yyyy — hh:mm", cultureInfo);
	}

	public static string ToProcessingFormat(this DateTime dateTime)
	{
		return $"{dateTime:yyyy-MM-ddTH:mm:ss.fffZ}";
	}

	public static int ToTimestamp(this DateTime dateTime)
	{
		return (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
	}

	public static string ToMonthAndYear(this DateTime dateTime)
	{
		CultureInfo cultureInfo = new CultureInfo("ru-RU");
		cultureInfo.DateTimeFormat.MonthNames = cultureInfo.DateTimeFormat.MonthNames.Select((string x) => x.FirstCharToUpper()).ToArray();
		return dateTime.ToString("MMMM, yyyy", cultureInfo);
	}

	public static string ToTimeDayMonthFormat(this DateTime dateTime)
	{
		CultureInfo cultureInfo = new CultureInfo("ru-RU");
		return dateTime.ToString("HH:mm, d MMMM", cultureInfo);
	}

	public static bool IsDateIntersected(this DateTime date, DateTime start, DateTime end)
	{
		if (start <= date)
		{
			return date <= end;
		}
		return false;
	}

	public static decimal GetYearsFromDate(this DateTime dateEnd, DateTime dateStart)
	{
		int num = (dateEnd.Year - dateStart.Year) * 12 + (dateEnd.Month - dateStart.Month);
		if (dateEnd.Day < dateStart.Day)
		{
			num--;
		}
		return (decimal)num / 12m;
	}

	public static int GetDifferenceMonths(this DateTime from, DateTime to)
	{
		return (to.Year - from.Year) * 12 + to.Month - from.Month;
	}

	public static string GetTodayTomorrowOrDate(this DateTimeOffset dateTime, Func<DateTimeOffset, string> other, Func<DateTimeOffset, string> fallback)
	{
		if (dateTime.DayOfYear == DateTimeOffset.Now.DayOfYear)
		{
			return "сегодня";
		}
		if (dateTime.DayOfYear - DateTimeOffset.Now.DayOfYear == 1)
		{
			return "завтра";
		}
		if (dateTime.DayOfYear - DateTimeOffset.Now.DayOfYear >= 2)
		{
			return other(dateTime);
		}
		return fallback(dateTime);
	}

	public static string GetTodayTomorrowOrDate(this DateTimeOffset dateTime, Func<DateTimeOffset, string> fallback)
	{
		return dateTime.GetTodayTomorrowOrDate((DateTimeOffset d) => d.ToString("dd.MM"), fallback);
	}

	public static string GetTodayTomorrowOrDate(this DateTimeOffset dateTime)
	{
		return dateTime.GetTodayTomorrowOrDate((DateTimeOffset _) => string.Empty);
	}
}
