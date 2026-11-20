using System.Collections.Generic;
using System.Text;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Helpers;

namespace Auchan.Common.Ecom.Extensions;

public static class ProductExtensions
{
	public static string? GetPlainCategory(this ProductOffer offer)
	{
		ReadOnlyEquatableList<CategoryCodeDto> categoryCodes = offer.CategoryCodes;
		if (categoryCodes == null || categoryCodes.Count == 0)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (CategoryCodeDto item in categoryCodes)
		{
			stringBuilder.Append(item.Name + "/");
		}
		stringBuilder.Length--;
		return stringBuilder.ToString();
	}

	public static string? GetPlainCategory(this Product offer)
	{
		IReadOnlyList<CategoryCodeDto> categoryCodes = offer.CategoryCodes;
		if (categoryCodes == null || categoryCodes.Count == 0)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (CategoryCodeDto item in categoryCodes)
		{
			stringBuilder.Append(item.Name + "/");
		}
		stringBuilder.Length--;
		return stringBuilder.ToString();
	}

	public static string GetFormattedText(this Auchan.Common.Ecom.ProducModels.Cashback? cashbackInfo)
	{
		if ((object)cashbackInfo == null)
		{
			return string.Empty;
		}
		string cashbackCalculationType = GetCashbackCalculationType(cashbackInfo);
		return $"Кешбэк {cashbackInfo.Amount}{cashbackCalculationType}";
	}

	private static string GetCashbackCalculationType(Auchan.Common.Ecom.ProducModels.Cashback cashbackInfo)
	{
		return cashbackInfo.CalculationType switch
		{
			CashbackCalculationType.Percent => "%", 
			CashbackCalculationType.Points => GrammarHelper.DeclineNoun(cashbackInfo.Amount, new string[3] { " балл", " балла", " баллов" }), 
			_ => string.Empty, 
		};
	}
}
