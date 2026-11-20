using System;

namespace Auchan.Common.Helpers;

public static class TimeHelper
{
	public static int CurrentUnixTimeStamp => (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

	public static DateTime ConvertFromUnixTimestamp(double timestamp)
	{
		return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
	}

	public static double ConvertToUnixTimestamp(DateTime date)
	{
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
		return Math.Floor((date.ToUniversalTime() - dateTime).TotalSeconds);
	}

	public static string GetLeftSecondsFormatted(this TimeSpan timeSpan)
	{
		int num = Convert.ToInt32(timeSpan.TotalSeconds);
		string value = GrammarHelper.DeclineNoun(num, new string[3] { "секунду", "секунды", "секунд" });
		return $"{num} {value}";
	}
}
