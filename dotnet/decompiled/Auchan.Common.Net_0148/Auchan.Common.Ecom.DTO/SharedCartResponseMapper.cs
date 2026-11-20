using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Badges;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;

namespace Auchan.Common.Ecom.DTO;

public static class SharedCartResponseMapper
{
	public static SharedCartModel ToModel(this SharedCartResponseDto dto)
	{
		return new SharedCartModel
		{
			Available = dto.Data.Items.Select((SharedCartResponseDto.ProductDto i) => i.ToModel()).ToImmutableList(),
			Unavailable = dto.Data.Unavailable.Select((SharedCartResponseDto.ProductDto i) => i.ToModel()).ToImmutableList(),
			Count = dto.Data.Summary.Count,
			IsAdult = dto.Data.Summary.IsAdult,
			TotalPrice = dto.Data.Summary.Total.Value
		};
	}

	public static ProductOffer ToModel(this SharedCartResponseDto.ProductDto dto)
	{
		return new ProductOffer
		{
			Id = dto.OfferId,
			ProductId = dto.ProductId,
			Qty = dto.Count,
			Name = dto.Name,
			PricePerOne = dto.PricePerOne.GetValueOrDefault(),
			Price = dto.Price.Value,
			OldPrice = dto.OldPrice?.Value,
			IsSaleActive = false,
			Discount = null,
			Weight = 0m,
			ImageUrl = dto.ImageUrl,
			RealStock = dto.StockQty.GetValueOrDefault(),
			CategoryCodes = new ReadOnlyEquatableList<CategoryCodeDto>(),
			UnitType = dto.Price.UnitType,
			BasketStep = dto.BasketStep,
			Code = dto.Code,
			GimaId = "",
			IsAdult = dto.IsAdult,
			IsNew = false,
			SelectedModifications = dto.SelectedModifications.Select((SharedCartResponseDto.ModificationDto i) => i.ToModel()).ToImmutableList().ToReadOnlyEquatable(),
			Cashback = null,
			Collectible = null,
			PlusOnePromotion = null,
			Badges = new ReadOnlyEquatableList<BadgeModel>(),
			Comment = null,
			Tags = new ReadOnlyEquatableList<Tag>(),
			IsSelected = true,
			IsMarkedProduct = false,
			InCombo = false,
			TotalDiscount = null
		};
	}

	public static SelectedModification ToModel(this SharedCartResponseDto.ModificationDto dto)
	{
		return new SelectedModification
		{
			Code = dto.Code,
			Name = "",
			Value = new ProductModificationValue
			{
				Key = dto.Value
			}
		};
	}
}
