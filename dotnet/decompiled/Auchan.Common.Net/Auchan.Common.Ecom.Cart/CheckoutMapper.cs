using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Extensions;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Ecom.Cart;

internal static class CheckoutMapper
{
	public static bool IsValid(this CheckoutDataResponseDto @this)
	{
		if (@this.Data.DeliveryMethod.Method == Auchan.Common.Profile.Orders.Enums.DeliveryMethod.Unknown)
		{
			return false;
		}
		if (@this.Data.DeliveryMethod.Method.IsDelivery() && @this.Data.DeliveryMethod.Address == null)
		{
			return false;
		}
		if (!@this.Data.DeliveryMethod.Method.IsDelivery() && @this.Data.DeliveryMethod.Shop == null)
		{
			return false;
		}
		if (@this.Data.AvailablePayments.All((AvailablePaymentDto i) => i.Code == CheckoutDataResponseDto.PaymentCodeDto.Unknown))
		{
			return false;
		}
		return true;
	}

	public static CheckoutData Map(this CheckoutDataResponseDto @this)
	{
		CheckoutData obj = new CheckoutData
		{
			Recipient = new Recipient
			{
				Name = (@this.Data.Recipient.Name ?? ""),
				Phone = (@this.Data.Recipient.Phone ?? ""),
				Email = (@this.Data.Recipient.Email ?? "")
			}
		};
		Auchan.Common.Ecom.Cart.Models.DeliveryMethod obj2 = new Auchan.Common.Ecom.Cart.Models.DeliveryMethod
		{
			Id = @this.Data.DeliveryMethod.Id,
			Method = (CheckoutReceiveMethod)(@this.Data.DeliveryMethod.Method - 1),
			ToDoor = (@this.Data.DeliveryMethod.ToDoor == true),
			Address = ((@this.Data.DeliveryMethod.Address == null) ? null : new Auchan.Common.Ecom.Cart.Models.Address
			{
				AddressText = @this.Data.DeliveryMethod.Address.Address,
				Flat = @this.Data.DeliveryMethod.Address.Flat,
				Floor = @this.Data.DeliveryMethod.Address.Floor,
				Porch = @this.Data.DeliveryMethod.Address.Porch,
				Intercom = @this.Data.DeliveryMethod.Address.Intercom,
				Comment = @this.Data.DeliveryMethod.Address.Comment
			}),
			Shop = ((@this.Data.DeliveryMethod.Shop == null) ? null : new CheckoutShop
			{
				Address = @this.Data.DeliveryMethod.Shop.Address
			}),
			Car = ((@this.Data.DeliveryMethod.Car == null) ? null : new CheckoutCar
			{
				Color = @this.Data.DeliveryMethod.Car.Color,
				Brand = @this.Data.DeliveryMethod.Car.Brand,
				Number = @this.Data.DeliveryMethod.Car.Number
			})
		};
		IReadOnlyList<CheckoutDataResponseDto.DateDto>? dates = @this.Data.DeliveryMethod.Dates;
		obj2.Dates = ((dates != null) ? dates.Map() : null) ?? ImmutableList.Create(default(ReadOnlySpan<CheckoutDate>));
		obj2.DeliveryTimeHint = @this.Data.DeliveryMethod.DeliveryTimeHint;
		obj2.MinSlotPrice = @this.Data.DeliveryMethod.MinSlotPrice;
		obj.DeliveryMethod = obj2;
		obj.AdditionalBenefit = @this.Data.AdditionalBenefit.Map();
		obj.Products = ((@this.Data.Products == null) ? new ReadOnlyEquatableList<CheckoutProduct>() : @this.Data.Products.Select((CheckoutDataResponseDto.ProductDto i) => new CheckoutProduct
		{
			OfferId = i.OfferId,
			ImageUrl = i.ImageUrl,
			Qty = i.Qty
		}).ToImmutableList().ToReadOnlyEquatable());
		obj.AdultProducts = ((@this.Data.AdultProducts == null) ? new ReadOnlyEquatableList<CheckoutProduct>() : @this.Data.AdultProducts.Select((CheckoutDataResponseDto.ProductDto i) => new CheckoutProduct
		{
			OfferId = i.OfferId,
			ImageUrl = i.ImageUrl,
			Qty = i.Qty
		}).ToImmutableList().ToReadOnlyEquatable());
		obj.Summary = @this.Data.Summary.Map();
		obj.AvailablePayments = @this.Data.AvailablePayments.Map();
		obj.Replacements = @this.Data.Replacements.Select((CheckoutDataResponseDto.ReplacementDto i) => new Replacement
		{
			Id = i.ReplacementMethodId,
			Name = i.ReplacementMethod,
			IsDefault = i.IsDefault
		}).ToImmutableList();
		obj.NeedsRecalculate = @this.Data.NeedsRecalculate == true;
		obj.VpnState = @this.VpnState;
		return obj;
	}

	private static ImmutableList<CheckoutDate> Map(this IReadOnlyList<CheckoutDataResponseDto.DateDto> @this)
	{
		return @this.Select((CheckoutDataResponseDto.DateDto i) => new CheckoutDate
		{
			Date = i.Date.Date,
			Day = i.Day,
			Time = i.Time.Select((CheckoutDataResponseDto.TimeDto timeDto) => new CheckoutTime
			{
				Id = timeDto.Id,
				Slot = timeDto.Slot,
				Name = timeDto.Name,
				Price = timeDto.Price,
				HasSurge = (timeDto.HasSurge == true)
			}).ToImmutableList()
		}).ToImmutableList();
	}

	private static ImmutableList<AvailablePayment> Map(this IReadOnlyList<AvailablePaymentDto> @this)
	{
		return (from i in @this
			where i.Code != CheckoutDataResponseDto.PaymentCodeDto.Unknown
			select new AvailablePayment
			{
				Code = (PaymentCode)(i.Code - 1),
				IsAvailable = i.IsAvailable,
				ItemsCount = i.ItemsCount,
				Sum = i.Sum
			}).ToImmutableList();
	}

	private static AdditionalBenefit? Map(this AdditionalBenefitDto? @this)
	{
		if (!(@this == null))
		{
			return new AdditionalBenefit
			{
				Mechanic = @this.Mechanic,
				Informers = ((@this.Informers == null) ? null : new Informers
				{
					TwoMechanicInformer = @this.Informers.TwoMechanicInformer,
					PointsInformer = @this.Informers.PointsInformer,
					AlcoholInformer = @this.Informers.AlcoholInformer
				}),
				Points = ((@this.Points == null) ? null : new Points
				{
					Total = @this.Points.Total,
					Available = @this.Points.Available,
					BurnablePoints = @this.Points.BurnablePoints
				}),
				PromocodeCondition = ((@this.PromocodeCondition == null) ? null : new PromocodeCondition
				{
					IsSuccess = @this.PromocodeCondition.IsSuccess,
					PromoCode = @this.PromocodeCondition.PromoCode,
					Message = @this.PromocodeCondition.Message,
					LinkName = @this.PromocodeCondition.LinkName,
					Slug = @this.PromocodeCondition.Slug
				})
			};
		}
		return null;
	}

	private static Auchan.Common.Ecom.Cart.Models.Summary Map(this SummaryDto @this)
	{
		return new Auchan.Common.Ecom.Cart.Models.Summary
		{
			TotalWeight = @this.TotalWeight,
			ItemsCount = @this.ItemsCount,
			BasketCost = @this.BasketCost,
			AdultBasketCost = @this.AdultBasketCost,
			NonAdultBasketCost = @this.NonAdultBasketCost,
			BasketPrice = @this.BasketPrice,
			TotalDeliveryPrice = @this.TotalDeliveryPrice,
			DeliveryTariff = ((@this.DeliveryTariff == null) ? null : new DeliveryTariff
			{
				DeliveryPrice = @this.DeliveryTariff.DeliveryPrice,
				BasketPrice = @this.DeliveryTariff.TariffBasketPrice,
				Overprice = @this.DeliveryTariff.Overprice,
				StandardWeight = @this.DeliveryTariff.StandardWeight,
				MaxWeight = @this.DeliveryTariff.MaxWeight
			}),
			TotalPrice = @this.TotalPrice,
			PromocodeDiscount = @this.PromocodeDiscount,
			UsedPoints = @this.UsedPoints,
			Economy = @this.Economy,
			UsedStamps = @this.UsedStamps,
			PickingPrice = @this.PickingPrice,
			SurgeAmount = @this.SurgeAmount
		};
	}

	public static bool IsValid(this RecalculateResponseDto @this)
	{
		if (@this.Data.AvailablePayments.All((AvailablePaymentDto i) => i.Code == CheckoutDataResponseDto.PaymentCodeDto.Unknown))
		{
			return false;
		}
		return true;
	}

	public static RecalculateResult Map(this RecalculateResponseDto @this)
	{
		RecalculateResult recalculateResult = new RecalculateResult();
		IReadOnlyList<CheckoutDataResponseDto.DateDto>? dates = @this.Data.Dates;
		recalculateResult.Dates = ((dates != null) ? dates.Map() : null);
		recalculateResult.MinSlotPrice = @this.Data.MinSlotPrice;
		recalculateResult.AdditionalBenefit = @this.Data.AdditionalBenefit.Map();
		recalculateResult.Summary = @this.Data.Summary.Map();
		recalculateResult.AvailablePayments = @this.Data.AvailablePayments.Map();
		return recalculateResult;
	}

	public static CheckoutOrderDetails Map(this OrderDetailsDto @this)
	{
		TimeSlot timeSlot = @this.Deliveries?.FirstOrDefault()?.DeliveryTime;
		return new CheckoutOrderDetails
		{
			Dto = @this,
			DeliveryMethod = (@this.Deliveries?.FirstOrDefault()?.MethodId ?? Auchan.Common.Profile.Orders.Enums.DeliveryMethod.BySelf),
			IsValid = (@this.Deliveries?.FirstOrDefault() != null),
			Shop = new ShopInfoModel
			{
				Name = (@this.Shop?.Name ?? ""),
				Address = (@this.Shop?.AddressString ?? ""),
				PickupDescription = (@this.Shop?.PickupDescription ?? ""),
				PickupPhotoUrls = (@this.Shop?.PhotoUrls ?? Array.Empty<string>()),
				CollectOrder = (@this.Shop?.CollectOrder == true)
			},
			Number = @this.Order.Number,
			DeliveryDate = (@this.Deliveries?.FirstOrDefault()?.DeliveryAt ?? DateTimeOffset.MinValue),
			DeliveryTime = ((timeSlot == null) ? "" : (timeSlot.From + " - " + timeSlot.To)),
			Products = (@this.Deliveries?.FirstOrDefault()?.Products.Select((ProductShort i) => i.Map()).ToImmutableList() ?? ImmutableList.Create(default(ReadOnlySpan<ProductModel>))),
			DeliveryAddress = (@this.Deliveries?.FirstOrDefault()?.DeliveryAddress ?? ""),
			Price = (@this.Payments?.FirstOrDefault()?.Sum.Value).GetValueOrDefault(),
			Id = @this.Order.Id,
			IsAdult = @this.Order.IsAdult,
			IsCanAddGoodsToOrder = @this.Order.AdditionAvailable,
			IsPayed = @this.Order.IsPayed,
			PaymentMethod = (@this.Payments?.FirstOrDefault()?.PaymentMethod).GetValueOrDefault(),
			StatusText = (@this.Order.SuccessPaymentStatus ?? "Оплачен")
		};
	}

	public static ProductModel Map(this ProductShort @this)
	{
		return new ProductModel
		{
			Name = @this.Name,
			ImageUrl = @this.ImageUrl,
			Code = "",
			SelectedModifications = Array.Empty<SelectedModification>()
		};
	}
}
