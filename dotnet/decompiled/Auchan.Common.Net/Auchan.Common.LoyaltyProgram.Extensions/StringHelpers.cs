using System.Globalization;
using Auchan.Common.Helpers;
using Auchan.Common.LoyaltyProgram.Enums;

namespace Auchan.Common.LoyaltyProgram.Extensions;

public static class StringHelpers
{
	private const string RubleSign = " ₽";

	private static NumberFormatInfo _priceFormat = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();

	public static string GetFormattedMoneyAmount(this decimal money, QualifiedLoyaltyOperationType operationType)
	{
		_priceFormat.NumberGroupSeparator = " ";
		_priceFormat.CurrencyDecimalSeparator = ",";
		_priceFormat.NumberDecimalSeparator = ",";
		_priceFormat.PercentDecimalSeparator = ",";
		string text = "#,0.00";
		string text2 = "";
		if (operationType == QualifiedLoyaltyOperationType.Purchase || operationType == QualifiedLoyaltyOperationType.Order)
		{
			text2 = " ₽";
		}
		return money.ToString(text, _priceFormat) + text2;
	}

	public static string GetLoyaltyPointsDeclined(this int points, LoyaltyPointType PointType, bool capitalizedFirstLetter = false)
	{
		string text = string.Empty;
		if (PointType == LoyaltyPointType.Points)
		{
			text = GrammarHelper.DeclineNoun(points, new string[3] { "Балл", "Балла", "Баллов" });
		}
		if (PointType == LoyaltyPointType.Stamps)
		{
			text = GrammarHelper.DeclineNoun(points, new string[3] { "Марка", "Марки", "Марок" });
		}
		if (!capitalizedFirstLetter && !string.IsNullOrEmpty(text))
		{
			return text.ToLower();
		}
		return text;
	}

	public static string GetLoyaltyPointsDeclinedAccusative(this int points, LoyaltyPointType PointType, bool capitalizedFirstLetter = false)
	{
		string text = string.Empty;
		if (PointType == LoyaltyPointType.Points)
		{
			text = GrammarHelper.DeclineNoun(points, new string[3] { "Балл", "Балла", "Баллов" });
		}
		if (PointType == LoyaltyPointType.Stamps)
		{
			text = GrammarHelper.DeclineNoun(points, new string[3] { "Марку", "Марки", "Марок" });
		}
		if (!capitalizedFirstLetter && !string.IsNullOrEmpty(text))
		{
			return text.ToLower();
		}
		return text;
	}

	public static string GetLoyaltyPointsAvailableAdjectiveDeclined(this int points, LoyaltyPointType PointType)
	{
		return GrammarHelper.DeclineNoun(points, new string[3]
		{
			(PointType == LoyaltyPointType.Points) ? "доступен" : "доступна",
			"доступны",
			"доступно"
		});
	}
}
