using System;
using System.Globalization;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Ecom.Products;

public static class ProductsConverter
{
	public static string FromProductToUnitType(Product product)
	{
		if (product.Price == null)
		{
			return "";
		}
		switch (product.Price.UnitType)
		{
		case ProductUnitType.Unit:
			if (product.Weight == 0m)
			{
				return "Цена за 1 шт";
			}
			return $"Цена за 1 шт ({product.Weight} г)";
		case ProductUnitType.Kilogram_1:
			return "Цена за 1 кг";
		case ProductUnitType.Gram_100:
			return "Цена за 100 г";
		default:
			throw new NotSupportedException();
		}
	}

	public static string FromProductOfferToPricePerUnit(ProductOffer product)
	{
		return product.UnitType switch
		{
			ProductUnitType.Unit => $"{product.PricePerOne:C2}/шт", 
			ProductUnitType.Kilogram_1 => $"{product.PricePerOne:C2}/кг", 
			ProductUnitType.Gram_100 => $"{product.PricePerOne:C2}/100г", 
			_ => throw new NotSupportedException(), 
		};
	}

	public static string FromProductToQty(decimal qty, ProductUnitType unitType, bool addDot = false, bool withFraction = true)
	{
		switch (unitType)
		{
		case ProductUnitType.Unit:
			if (!addDot)
			{
				return $"{(int)qty} шт";
			}
			if (addDot)
			{
				return $"{(int)qty} шт.";
			}
			break;
		case ProductUnitType.Kilogram_1:
			if (withFraction)
			{
				goto IL_007e;
			}
			if (withFraction)
			{
				break;
			}
			goto IL_00a7;
		case ProductUnitType.Gram_100:
			{
				if (withFraction)
				{
					goto IL_007e;
				}
				if (withFraction)
				{
					break;
				}
				goto IL_00a7;
			}
			IL_007e:
			return qty.ToString("F2", CultureInfo.GetCultureInfo("ru-RU")) + " кг";
			IL_00a7:
			return $"{(int)qty} кг";
		}
		throw new NotSupportedException();
	}

	public static string FromProductToQtyNumber(double qty, ProductUnitType unitType)
	{
		switch (unitType)
		{
		case ProductUnitType.Unit:
			return $"{(int)qty}";
		case ProductUnitType.Kilogram_1:
		case ProductUnitType.Gram_100:
			return $"{qty:F2}";
		default:
			throw new NotSupportedException();
		}
	}

	public static string QuantityAlias(ProductUnitType unitType)
	{
		switch (unitType)
		{
		case ProductUnitType.Unit:
			return "шт";
		case ProductUnitType.Kilogram_1:
		case ProductUnitType.Gram_100:
			return "кг";
		default:
			throw new NotSupportedException();
		}
	}

	public static string QuantityAliasExtended(ProductUnitType unitType)
	{
		return unitType switch
		{
			ProductUnitType.Unit => "шт", 
			ProductUnitType.Kilogram_1 => "кг", 
			ProductUnitType.Gram_100 => "100 г", 
			_ => throw new NotSupportedException(), 
		};
	}

	public static string? GetStockInfo(Product product, bool withFraction = false)
	{
		Price price = product.Price;
		Stock stock = product.Stock;
		if (stock == null || price == null)
		{
			return null;
		}
		if (stock.Qty <= 0m)
		{
			return null;
		}
		if (stock.Qty > 80m)
		{
			return "В наличии: много";
		}
		string text = FromProductToQty(stock.Qty, price.UnitType, addDot: false, withFraction);
		return "В наличии: " + text + ".";
	}

	public static string? GetStockInfo(decimal qty, ProductUnitType type, bool withFraction = false)
	{
		if (qty <= 0m)
		{
			return null;
		}
		if (qty > 80m)
		{
			return "В наличии: много";
		}
		string text = FromProductToQty(qty, type, addDot: false, withFraction);
		return "В наличии: " + text + ".";
	}

	public static string FromProductsTypeToTitle(ProductsToLoad type)
	{
		return type switch
		{
			ProductsToLoad.ByCashbackAvailable => "Мой Кешбэк", 
			ProductsToLoad.ByPromoOnly => "Суперцены", 
			_ => string.Empty, 
		};
	}
}
