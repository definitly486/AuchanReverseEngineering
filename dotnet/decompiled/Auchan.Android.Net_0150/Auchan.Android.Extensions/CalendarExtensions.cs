using System;

namespace Auchan.Android.Extensions;

public static class CalendarExtensions
{
	public static long ToMillisecondsSinceUnixEpoch(this DateTime dateTime)
	{
		return new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
	}
}
