namespace Auchan.Common.Profile.Extensions;

public static class CalendarExtensions
{
	public static string GetMonthTitle(this int month)
	{
		return month switch
		{
			1 => "Янв.", 
			2 => "Фев.", 
			3 => "Март", 
			4 => "Апр.", 
			5 => "Май", 
			6 => "Июнь", 
			7 => "Июль", 
			8 => "Авг.", 
			9 => "Сен.", 
			10 => "Окт.", 
			11 => "Ноя.", 
			12 => "Дек.", 
			_ => string.Empty, 
		};
	}
}
