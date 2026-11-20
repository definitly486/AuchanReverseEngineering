using System.Linq;

namespace Auchan.Common.Addresses;

public static class SuggestionExtensions
{
	public static string? GetValidationError(this SuggestionResult suggestion)
	{
		if (suggestion.IsNeedHouse)
		{
			return "Адрес должен включать дом";
		}
		if (!suggestion.IsSuccess || !suggestion.Suggestions.Any())
		{
			return "Адрес не найден. Попробуйте указать нужный адрес на карте";
		}
		return null;
	}

	public static string? GetValidationError(this Suggestion? suggestion)
	{
		if ((object)suggestion != null && !suggestion.IsFull)
		{
			return "Адрес должен включать дом";
		}
		return null;
	}
}
