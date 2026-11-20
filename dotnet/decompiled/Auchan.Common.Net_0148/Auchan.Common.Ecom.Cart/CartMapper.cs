using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.Cart.StampsWithdraw;
using Auchan.Common.Ecom.Cart.StampsWithdrawViewModel;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;

namespace Auchan.Common.Ecom.Cart;

public static class CartMapper
{
	public static (CartModel cartModel, IReadOnlyList<ProductOffer> invalidProducts) ValidateAndMap(this CartDto dto)
	{
		IEnumerable<(ProductOffer, ProductOffer)> enumerable = dto.Items.Select((CartItemDto p) => p.ToProductModel());
		IEnumerable<(ProductOffer product, ProductOffer invalidProduct)> itemsUnavailable = dto.ItemsUnavailable.Select((CartItemDto p) => p.ToProductModel(forUnavailable: true));
		CartModel item = new CartModel
		{
			Items = enumerable.SelectNotNull<(ProductOffer, ProductOffer), ProductOffer>(((ProductOffer product, ProductOffer invalidProduct) t) => t.product).ToImmutableList(),
			ItemsUnavailable = itemsUnavailable.SelectNotNull(((ProductOffer product, ProductOffer invalidProduct) t) => t.product).ToImmutableList(),
			Discounts = dto.Summary.Discounts.Select((DiscountDto d) => new CartDiscount
			{
				Value = (float)d.Value.Value,
				ValueInPercent = d.ValueInPercent.Value,
				EndDate = (d.EndDate ?? ""),
				IsLoyaltyProgramDiscount = d.IsLoyaltyProgramDiscount
			}).ToImmutableList(),
			DeliveryTotalPrice = dto.Summary.DeliveryTotalPrice,
			DeliveryPrice = dto.Summary.DeliveryPrice,
			DeliveryOverPrice = dto.Summary.DeliveryOverPrice,
			TotalWeight = dto.Summary.TotalWeight,
			TotalCount = dto.MinCart.TotalCount,
			Subtotal = dto.Summary.Sum.Value,
			Total = dto.Summary.Total.Value,
			AdultSumValue = (dto.Summary.AdultSum?.Value ?? 0m),
			NonAdultSumValue = (dto.Summary.NonAdultSum?.Value ?? 0m),
			HasStampDiscount = dto.Summary.StampDiscount,
			NextDeliveryThreshold = dto.Summary.DeliveryStepPrice,
			NotEnoughToNextDeliveryThreshold = dto.Summary.DeliveryStep,
			PickingPrice = dto.Summary.PickingPrice,
			TotalDiscount = dto.Summary.TotalDiscount,
			MarkingInfo = new MarkingInfo
			{
				MarkingCount = (dto.Summary.MarkingInfo?.Count ?? 0),
				Limit = (dto.Summary.MarkingInfo?.Limit ?? 0),
				Excess = (dto.Summary.MarkingInfo?.Excess ?? 0),
				LimitExcess = (dto.Summary.MarkingInfo?.LimitExcess ?? false)
			}
		};
		List<ProductOffer> source = (from t in enumerable
			where t.product == null
			select t.invalidProduct).Concat(from t in itemsUnavailable
			where t.product == null
			select t.invalidProduct).ToList();
		source = source.Where((ProductOffer ip) => itemsUnavailable.All(((ProductOffer product, ProductOffer invalidProduct) iu) => iu.product?.GimaId != ip.GimaId)).ToList();
		return (cartModel: item, invalidProducts: source);
	}

	public static StampDiscountModel? Map(this StampDiscountDto dto)
	{
		return new StampDiscountModel(decimal.ToInt32(dto.Data.Stamps), dto.Data.CountDescription, dto.Data.Items.Select((StampDiscountItem x) => new StampsWithdrawProductItemViewModel(x.Name, x.DiscountPrice, x.FullPrice, x.ImageUrl)));
	}

	public static IReadOnlyList<SelectedModificationDto> ToDto(this IReadOnlyList<SelectedModification> modifications)
	{
		if (modifications == null || !modifications.Any())
		{
			return null;
		}
		return modifications.Select((SelectedModification c) => new SelectedModificationDto
		{
			Code = c.Code,
			Value = (c.Value?.Key ?? string.Empty)
		}).ToImmutableList();
	}

	public static ComboSuggestion Map(this ComboSuggestionsResponseDto @this)
	{
		if (!@this.IsValid())
		{
			throw new ArgumentException("validation required");
		}
		return new ComboSuggestion
		{
			Status = (ComboSuggestionStatus)(@this.Data.Status - 1),
			Tooltip = @this.Data.Tooltip
		};
	}

	public static bool IsValid(this ComboSuggestionsResponseDto @this)
	{
		if (@this.Data != null)
		{
			return @this.Data.Status > ComboSuggestionsResponseDto.StatusDto.Unknown;
		}
		return false;
	}

	public static ProductOfferChange Map(this CartItemsChangedDto.ItemDto @this)
	{
		return new ProductOfferChange
		{
			Id = @this.OfferId,
			Code = @this.Code,
			ProductId = @this.ProductId,
			GimaId = @this.GimaId,
			IsAdult = @this.IsAdult,
			IsSelected = @this.IsSelected,
			Qty = @this.Qty,
			ImageUrl = @this.Image,
			Name = @this.Name,
			OldPrice = @this.OldPrice?.Value,
			Price = @this.Price.Value.GetValueOrDefault(),
			UnitType = @this.Price.UnitType.GetValueOrDefault(),
			PricePerOne = @this.PricePerOne.GetValueOrDefault(),
			BasketStep = @this.BasketStep,
			RealStock = @this.StockQty,
			CategoryCodes = @this.CategoryCodes.ToReadOnlyEquatable(),
			TotalDiscount = @this.TotalDiscount,
			PromotionApplied = (@this.Promotion?.Applied ?? false),
			PromotionTooltip = @this.Promotion?.Tooltip,
			SelectedModifications = CartItemDtoMapper.Map(@this.SelectedModifications, @this.Modifications).ToReadOnlyEquatable()
		};
	}

	public static ChangedItem Map(this CartItemsChangedDto.ChangedDto @this)
	{
		return new ChangedItem
		{
			IsAdded = @this.IsAddedToCart,
			OfferId = @this.OfferId.GetValueOrDefault()
		};
	}
}
