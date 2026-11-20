using System.Net;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;

namespace Auchan.Common.Ecom.PriceChecker;

internal static class Mapper
{
	public static PriceCheckerError ToPriceCheckerError(this ServiceError error)
	{
		return new PriceCheckerError
		{
			InnerError = error.ToBaseDomainError(),
			StatusCode = (int)((error is UnsuccessfulStatusCodeError unsuccessfulStatusCodeError) ? unsuccessfulStatusCodeError.StatusCode : HttpStatusCode.Forbidden)
		};
	}

	public static ValidationResult Map(this PriceCheckerResponseDto.DataDto @this)
	{
		ValidationResult obj = new ValidationResult
		{
			Barcode = @this.Ean
		};
		Product obj2 = new Product
		{
			GimaId = @this.GimaId,
			Title = @this.Name,
			Stock = new Stock
			{
				Qty = 1m
			}
		};
		PriceCheckerResponseDto.DiscountDto? discount = @this.Discount;
		obj2.OldPrice = ((discount == null || !discount.DiscountPrice.HasValue) ? null : new Price
		{
			Value = @this.Price,
			UnitType = @this.UnitType.Map(),
			Currency = "RUB"
		});
		obj2.Price = new Price
		{
			Value = (@this.Discount?.DiscountPrice ?? @this.Price),
			UnitType = @this.UnitType.Map(),
			Currency = "RUB"
		};
		obj2.Discount = @this.ToDiscount();
		obj.Product = obj2;
		obj.IsOnline = @this.IsOnline;
		return obj;
	}

	private static Discount? ToDiscount(this PriceCheckerResponseDto.DataDto @this)
	{
		PriceCheckerResponseDto.DiscountDto? discount = @this.Discount;
		if (discount != null && discount.DiscountPrice.HasValue)
		{
			return new Discount
			{
				Value = @this.Discount.DiscountPrice.Value - @this.Price,
				ValueInPercent = @this.Discount.InPercent.GetValueOrDefault(),
				EndDate = @this.Discount.EndDate.GetValueOrDefault(),
				IsLoyaltyProgramDiscount = false
			};
		}
		return null;
	}

	public static ProductUnitType Map(this PriceCheckerResponseDto.UnitTypeDto @this)
	{
		if (@this == PriceCheckerResponseDto.UnitTypeDto.PerKilo)
		{
			return ProductUnitType.Kilogram_1;
		}
		return ProductUnitType.Unit;
	}
}
