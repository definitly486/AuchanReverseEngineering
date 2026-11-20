using System;

namespace Auchan.Common.Helpers;

public static class ThemeHelper
{
	public enum ThemeEnum
	{
		Default,
		Custom,
		NewYearNight,
		NewYearDay
	}

	private static readonly DateTime _newYearThemeStartDate = new DateTime(2022, 11, 21);

	private static readonly DateTime _newYearThemeEndDate = new DateTime(2023, 1, 9);

	public static ThemeEnum GetCurrentTheme()
	{
		if (DateTime.UtcNow >= _newYearThemeStartDate && DateTime.UtcNow <= _newYearThemeEndDate)
		{
			if (!(DateTime.Now.TimeOfDay < TimeSpan.FromHours(17)) || !(DateTime.Now.TimeOfDay >= TimeSpan.FromHours(6)))
			{
				return ThemeEnum.NewYearNight;
			}
			return ThemeEnum.NewYearDay;
		}
		return ThemeEnum.Default;
	}
}
