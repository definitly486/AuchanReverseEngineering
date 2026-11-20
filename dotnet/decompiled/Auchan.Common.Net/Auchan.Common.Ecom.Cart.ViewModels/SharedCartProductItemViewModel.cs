using System;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.Products;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public sealed class SharedCartProductItemViewModel
{
	public sealed class Parameter
	{
		public required ProductOffer Product { get; init; }

		public required bool IsLast { get; init; }

		public required bool IsAvailable { get; init; }
	}

	private readonly Parameter _parameter;

	public ProductOffer Product => _parameter.Product;

	public string TitleText => Product.Name;

	public string PriceText => Price(Product);

	public string OldPriceText
	{
		get
		{
			if (Product.OldPrice.HasValue)
			{
				return Product.OldPrice.Value.ToString("F2");
			}
			return "";
		}
	}

	public bool OldPriceVisible => Product.OldPrice.HasValue;

	public string PricePerItemText => PricePerItemFrom(Product);

	public string CountText => GetCountText(Product);

	public string? ImageUrl => Product.ImageUrl;

	public bool IsSeparatorVisible => !_parameter.IsLast;

	public bool IsAvailable => _parameter.IsAvailable;

	public SharedCartProductItemViewModel(Parameter parameter)
	{
		_parameter = parameter;
	}

	private static string Price(ProductOffer offer)
	{
		return offer.UnitType switch
		{
			ProductUnitType.Unit => offer.Price.ToString("C2"), 
			ProductUnitType.Kilogram_1 => offer.Price.ToString("C2"), 
			ProductUnitType.Gram_100 => offer.Price.ToString("C2"), 
			_ => throw new NotSupportedException("dead code"), 
		};
	}

	private static string PricePerItemFrom(ProductOffer offer)
	{
		return offer.UnitType switch
		{
			ProductUnitType.Unit => $"{offer.PricePerOne:C2}/шт", 
			ProductUnitType.Kilogram_1 => $"{offer.PricePerOne:C2}/кг", 
			ProductUnitType.Gram_100 => $"{offer.PricePerOne:C2}/100г", 
			_ => throw new NotSupportedException("dead code"), 
		};
	}

	private static string GetCountText(ProductOffer offer)
	{
		switch (offer.UnitType)
		{
		case ProductUnitType.Unit:
			return $"{offer.Qty:F0} шт";
		case ProductUnitType.Kilogram_1:
		case ProductUnitType.Gram_100:
			if (Math.Abs(offer.Qty - Math.Floor(offer.Qty)) <= 0m)
			{
				return $"{offer.Qty:F0} кг";
			}
			return offer.Qty.ToString("F2").TrimEnd('0') + " кг";
		default:
			throw new ArgumentException("unit type isn't supported");
		}
	}
}
