using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Extensions;

namespace Auchan.Common.Ecom.DTO;

public static class CartItemDtoMapper
{
	public static (ProductOffer? product, ProductOffer invalidProduct) ToProductModel(this CartItemDto item, bool forUnavailable = false)
	{
		if (forUnavailable)
		{
			if (item.Product.ProductId == null || string.IsNullOrWhiteSpace(item.Product.Name) || string.IsNullOrWhiteSpace(item.Product.Code) || string.IsNullOrWhiteSpace(item.Product.GimaId))
			{
				return (product: null, invalidProduct: ProductOffer.Create(item.Product.Id, ProductIdHelper.TryGetProductId(item.Product.ProductId), Map(item.SelectedModifications, item.Product.Modifications)));
			}
		}
		else if (item.Product.ProductId == null || string.IsNullOrWhiteSpace(item.Product.Name) || item.Product.Price == null || item.Product.Price.Currency == null || !item.Product.Price.Value.HasValue || !item.Product.Price.UnitType.HasValue || !item.Product.SaleActive.HasValue || !item.Product.Weight.HasValue || item.Product.Stock == null || !item.Product.Stock.Qty.HasValue || !item.Product.Stock.StoreId.HasValue || !item.Product.BasketStep.HasValue || string.IsNullOrWhiteSpace(item.Product.Code) || string.IsNullOrWhiteSpace(item.Product.GimaId) || (item.Product.Discount != null && (!item.Product.Discount.Value.HasValue || !item.Product.Discount.ValueInPercent.HasValue || item.Product.Discount.EndDate == null)) || string.IsNullOrWhiteSpace(item.Product.ImageUrl))
		{
			return (product: null, invalidProduct: ProductOffer.Create(item.Product.Id, ProductIdHelper.TryGetProductId(item.Product.ProductId), Map(item.SelectedModifications, item.Product.Modifications)));
		}
		ImmutableList<CategoryCodeDto>.Builder builder = ImmutableList.CreateBuilder<CategoryCodeDto>();
		for (int i = 0; i < item.Product.CategoryCodes.Count; i++)
		{
			builder.Add(new CategoryCodeDto
			{
				Id = item.Product.CategoryIds[i],
				Code = item.Product.CategoryCodes[i],
				Name = item.Product.CategoryNames[i]
			});
		}
		return (product: new ProductOffer
		{
			Id = item.Product.Id,
			ProductId = ProductIdHelper.TryGetProductId(item.Product.ProductId),
			Qty = item.Count,
			Name = item.Product.Name,
			PricePerOne = item.Product.PricePerOne.GetValueOrDefault(),
			Price = (item.Product.Price?.Value).GetValueOrDefault(),
			OldPrice = item.Product.OldPrice?.Value,
			IsSaleActive = (item.Product.SaleActive == true),
			Discount = item.Product.Discount.Map(),
			Weight = item.Product.Weight.GetValueOrDefault(),
			ImageUrl = item.Product.ImageUrl,
			RealStock = (item.Product.Stock?.Qty).GetValueOrDefault(),
			CategoryCodes = builder.ToImmutable().ToReadOnlyEquatable(),
			UnitType = (item.Product.Price?.UnitType).GetValueOrDefault(),
			BasketStep = (item.Product.BasketStep ?? 1m),
			Code = item.Product.Code,
			GimaId = item.Product.GimaId,
			IsAdult = (item.Product.IsAdult == true),
			IsNew = item.Product.IsNew,
			Cashback = item.Product.Cashback?.Map(),
			Collectible = item.Product.Collectible?.Map(),
			PlusOnePromotion = item.Product.PlusOnePromotion?.Map(),
			Badges = item.Product.Badges.Map().ToReadOnlyEquatable(),
			SelectedModifications = Map(item.SelectedModifications, item.Product.Modifications),
			Comment = item.Comment,
			Tags = (item.Product.Tags ?? Array.Empty<Tag>()).ToReadOnlyEquatable(),
			IsSelected = item.IsSelected,
			IsMarkedProduct = item.IsMarkedProduct,
			InCombo = item.InCombo,
			TotalDiscount = item.Product.TotalDiscount
		}, invalidProduct: ProductOffer.Create(item.Product.Id, ProductIdHelper.TryGetProductId(item.Product.ProductId), Map(item.SelectedModifications, item.Product.Modifications)));
	}

	public static ReadOnlyEquatableList<SelectedModification> Map(IReadOnlyList<SelectedModificationDto>? dtoSelected, IReadOnlyList<ProductModificationDto>? dtoModifications)
	{
		if (dtoSelected.IsNullOrEmpty() || dtoModifications.IsNullOrEmpty())
		{
			return new ReadOnlyEquatableList<SelectedModification>();
		}
		ImmutableList<SelectedModification>.Builder builder = ImmutableList.CreateBuilder<SelectedModification>();
		foreach (SelectedModificationDto selected in dtoSelected)
		{
			ProductModificationDto productModificationDto = dtoModifications.FirstOrDefault((ProductModificationDto c) => c.Code == selected.Code);
			if (!(productModificationDto == null))
			{
				ProductModificationValueDto productModificationValueDto = productModificationDto.Values.FirstOrDefault((ProductModificationValueDto c) => c.Value == selected.Value);
				if (!(productModificationValueDto == null))
				{
					SelectedModification item = new SelectedModification
					{
						Code = productModificationDto.Code,
						Name = productModificationDto.Name,
						Value = productModificationValueDto.Map()
					};
					builder.Add(item);
				}
			}
		}
		return builder.ToImmutable().ToReadOnlyEquatable();
	}

	private static ProductModificationValue Map(this ProductModificationValueDto dto)
	{
		return new ProductModificationValue
		{
			Description = dto.Description,
			ImageUrls = dto.ImageUrls.ToReadOnlyEquatable(),
			Key = dto.Value,
			PreviewImageUrl = dto.PreviewImageUrl
		};
	}
}
