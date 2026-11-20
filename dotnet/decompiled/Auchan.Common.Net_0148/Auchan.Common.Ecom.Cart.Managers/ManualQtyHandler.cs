using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products;

namespace Auchan.Common.Ecom.Cart.Managers;

public static class ManualQtyHandler
{
	private const char Space = ' ';

	private const char Zero = '0';

	private const char Dot = '.';

	private const char Comma = ',';

	public static string OnQtyEnteredManually(ProductOffer productOffer, CartItemViewModel cartItemViewModel, string newQtyWithAlias)
	{
		if (productOffer.UnitType != ProductUnitType.Unit)
		{
			return WeightInput(cartItemViewModel, productOffer, newQtyWithAlias);
		}
		return UnitInput(cartItemViewModel, productOffer, newQtyWithAlias);
	}

	public static decimal NormalizeQtyIfNeeded(CartItemViewModel cartItemViewModel, ProductOffer productOffer)
	{
		string value = CleanInputQtyString(cartItemViewModel.ManualInputQty, productOffer.UnitType != ProductUnitType.Unit);
		decimal newQty = (string.IsNullOrEmpty(value) ? 0m : Convert.ToDecimal(value, CultureInfo.InvariantCulture));
		return NormalizeRound(productOffer, newQty);
	}

	private static string UnitInput(CartItemViewModel cartItemViewModel, ProductOffer productOffer, string newQtyWithAlias)
	{
		string text = CleanInputQtyString(newQtyWithAlias);
		if (newQtyWithAlias.Length < cartItemViewModel.ManualInputQty.Length)
		{
			text = (string.IsNullOrEmpty(text) ? string.Empty : text.Remove(text.Length - 1));
		}
		decimal num = (string.IsNullOrEmpty(text) ? 0m : Convert.ToDecimal(text, CultureInfo.InvariantCulture));
		if (num > productOffer.LastKnownStock)
		{
			num = productOffer.LastKnownStock;
		}
		return num + " " + ProductsConverter.QuantityAlias(productOffer.UnitType);
	}

	private static string WeightInput(CartItemViewModel cartItemViewModel, ProductOffer productOffer, string newQtyWithAlias)
	{
		string newQtyString = CleanInputQtyString(newQtyWithAlias, exceptSeparatorChar: true);
		if (newQtyWithAlias.Length >= cartItemViewModel.ManualInputQty.Length)
		{
			return OnInput(productOffer, newQtyString);
		}
		return OnClear(productOffer, newQtyString, newQtyWithAlias);
	}

	public static string OnQtyEnteredManually(ProductOffer productOffer, string manualInputQty, string newQtyWithAlias)
	{
		if (productOffer.UnitType != ProductUnitType.Unit)
		{
			return WeightInput(manualInputQty, productOffer, newQtyWithAlias);
		}
		return UnitInput(manualInputQty, productOffer, newQtyWithAlias);
	}

	public static decimal NormalizeQtyIfNeeded(string manualInputQty, ProductOffer productOffer)
	{
		string value = CleanInputQtyString(manualInputQty, productOffer.UnitType != ProductUnitType.Unit);
		decimal newQty = (string.IsNullOrEmpty(value) ? 0m : Convert.ToDecimal(value, CultureInfo.InvariantCulture));
		return NormalizeRound(productOffer, newQty);
	}

	private static string UnitInput(string manualInputQty, ProductOffer productOffer, string newQtyWithAlias)
	{
		string text = CleanInputQtyString(newQtyWithAlias);
		if (newQtyWithAlias.Length < manualInputQty.Length)
		{
			text = (string.IsNullOrEmpty(text) ? string.Empty : text.Remove(text.Length - 1));
		}
		decimal num = (string.IsNullOrEmpty(text) ? 0m : Convert.ToDecimal(text, CultureInfo.InvariantCulture));
		if (num > productOffer.LastKnownStock)
		{
			num = productOffer.LastKnownStock;
		}
		return num + " " + ProductsConverter.QuantityAlias(productOffer.UnitType);
	}

	private static string WeightInput(string manualInputQty, ProductOffer productOffer, string newQtyWithAlias)
	{
		string newQtyString = CleanInputQtyString(newQtyWithAlias, exceptSeparatorChar: true);
		if (newQtyWithAlias.Length >= manualInputQty.Length)
		{
			return OnInput(productOffer, newQtyString);
		}
		return OnClear(productOffer, newQtyString, newQtyWithAlias);
	}

	public static string OnQtyEnteredManually(ProductOffer productOffer, ProductItemViewModel cartItemViewModel, string newQtyWithAlias)
	{
		if (productOffer.UnitType != ProductUnitType.Unit)
		{
			return WeightInput(cartItemViewModel, productOffer, newQtyWithAlias);
		}
		return UnitInput(cartItemViewModel, productOffer, newQtyWithAlias);
	}

	public static decimal NormalizeQtyIfNeeded(ProductItemViewModel cartItemViewModel, ProductOffer productOffer)
	{
		string value = CleanInputQtyString(cartItemViewModel.ManualInputQty, productOffer.UnitType != ProductUnitType.Unit);
		decimal newQty = (string.IsNullOrEmpty(value) ? 0m : Convert.ToDecimal(value, CultureInfo.InvariantCulture));
		return NormalizeRound(productOffer, newQty);
	}

	private static string UnitInput(ProductItemViewModel cartItemViewModel, ProductOffer productOffer, string newQtyWithAlias)
	{
		string text = CleanInputQtyString(newQtyWithAlias);
		if (newQtyWithAlias.Length < cartItemViewModel.ManualInputQty.Length)
		{
			text = (string.IsNullOrEmpty(text) ? string.Empty : text.Remove(text.Length - 1));
		}
		decimal num = (string.IsNullOrEmpty(text) ? 0m : Convert.ToDecimal(text, CultureInfo.InvariantCulture));
		if (num > productOffer.LastKnownStock)
		{
			num = productOffer.LastKnownStock;
		}
		return num + " " + ProductsConverter.QuantityAlias(productOffer.UnitType);
	}

	private static string WeightInput(ProductItemViewModel cartItemViewModel, ProductOffer productOffer, string newQtyWithAlias)
	{
		string newQtyString = CleanInputQtyString(newQtyWithAlias, exceptSeparatorChar: true);
		if (newQtyWithAlias.Length >= cartItemViewModel.ManualInputQty.Length)
		{
			return OnInput(productOffer, newQtyString);
		}
		return OnClear(productOffer, newQtyString, newQtyWithAlias);
	}

	private static string OnClear(ProductOffer productOffer, string newQtyString, string newQtyWithAlias)
	{
		if (!newQtyWithAlias.Contains(ProductsConverter.QuantityAlias(productOffer.UnitType)) && !string.IsNullOrEmpty(newQtyString))
		{
			newQtyString = newQtyString.Remove(newQtyString.Length - 1);
		}
		if (newQtyString.FirstOrDefault() == '.' || string.IsNullOrWhiteSpace(newQtyString))
		{
			newQtyString = newQtyString.Insert(0, '0'.ToString());
		}
		return newQtyString + " " + ProductsConverter.QuantityAlias(productOffer.UnitType);
	}

	private static string OnInput(ProductOffer productOffer, string newQtyString)
	{
		decimal num = (string.IsNullOrEmpty(newQtyString) ? 0m : Convert.ToDecimal(newQtyString, CultureInfo.InvariantCulture));
		if (num > productOffer.LastKnownStock)
		{
			num = productOffer.LastKnownStock;
		}
		decimal num2 = ((DotCount(newQtyString) != 1 || CharsAfterDotCount(newQtyString) <= 0) ? Math.Round(num) : NormalizeRound(productOffer, num));
		bool flag = newQtyString.LastOrDefault() == '.';
		string input = num2.ToString(CultureInfo.InvariantCulture);
		input = ((DotCount(input) != 1 || CharsAfterDotCount(input) <= 2) ? num2.ToString() : num2.ToString("N2"));
		return input + (flag ? '.'.ToString() : string.Empty) + " " + ProductsConverter.QuantityAlias(productOffer.UnitType);
	}

	public static decimal NormalizeRound(ProductOffer productOffer, decimal newQty)
	{
		decimal num = WeightRound(newQty, productOffer.BasketStep);
		int num2 = (int)newQty;
		if ((int)num < num2)
		{
			return num + productOffer.BasketStep;
		}
		return num;
	}

	private static decimal WeightRound(decimal newQty, decimal basketStep)
	{
		decimal num = basketStep / 2.0m;
		decimal num2 = ((Math.Abs(newQty % basketStep - num) <= 0.0001m) ? Math.Floor(newQty / basketStep) : Math.Round(newQty / basketStep));
		return basketStep * num2;
	}

	private static string CleanInputQtyString(string input, bool exceptSeparatorChar = false)
	{
		input = input.Replace(',', '.');
		input = new Regex((!exceptSeparatorChar) ? "[^0-9]" : "[^0-9.'\\']", RegexOptions.None, TimeSpan.FromSeconds(60L)).Replace(input, string.Empty);
		input = input.Replace(' '.ToString(), string.Empty);
		while (DotCount(input) > 1)
		{
			int startIndex = input.LastIndexOf('.');
			input = input.Remove(startIndex);
		}
		return input;
	}

	private static int DotCount(string input)
	{
		return input.Count((char x) => x.Equals('.'));
	}

	private static int CharsAfterDotCount(string input)
	{
		if (input.Any((char x) => x == '.'))
		{
			int num = input.IndexOf('.');
			return input.Count() - 1 - num;
		}
		return 0;
	}
}
