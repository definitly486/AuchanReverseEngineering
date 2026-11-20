using System;

namespace Auchan.Common.Splash;

public static class DateTimeWelcomeConverter
{
	public static string GetWelcomeString(DateTime dateTime)
	{
		if (dateTime.Hour >= 17)
		{
			return "Добрый вечер";
		}
		if (dateTime.Hour >= 11)
		{
			return "Добрый день";
		}
		if (dateTime.Hour >= 5)
		{
			return "Доброе утро";
		}
		return "Доброй ночи";
	}
}
