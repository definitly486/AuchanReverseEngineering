using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Badges;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Extensions;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record ProductOfferChange : IProductOfferWithModifications
{
	public required long Id { get; init; }

	public required string Code { get; init; }

	public required long ProductId { get; init; }

	public required string GimaId { get; init; }

	public required bool IsAdult { get; init; }

	public required bool IsSelected { get; init; }

	public required decimal Qty { get; init; }

	public required string? ImageUrl { get; init; }

	public required string Name { get; init; }

	public required decimal? OldPrice { get; init; }

	public required decimal Price { get; init; }

	public required ProductUnitType UnitType { get; init; }

	public required decimal PricePerOne { get; init; }

	public required decimal BasketStep { get; init; }

	public required decimal RealStock { get; init; }

	[JsonConverter(typeof(ReadOnlyEquatableListConverter<CategoryCodeDto>))]
	public required ReadOnlyEquatableList<CategoryCodeDto> CategoryCodes { get; init; }

	public required decimal? TotalDiscount { get; init; }

	public required bool PromotionApplied { get; init; }

	public required string? PromotionTooltip { get; init; }

	[JsonConverter(typeof(ReadOnlyEquatableListConverter<SelectedModification>))]
	public required ReadOnlyEquatableList<SelectedModification> SelectedModifications { get; init; }

	long? IProductOfferWithModifications.Id => Id;

	IReadOnlyList<SelectedModification> IProductOfferWithModifications.SelectedModifications => SelectedModifications;

	public ProductOffer ToOffer()
	{
		return new ProductOffer
		{
			Id = Id,
			ProductId = ProductId,
			Qty = Qty,
			RealStock = RealStock,
			CategoryCodes = CategoryCodes,
			Name = Name,
			PricePerOne = PricePerOne,
			Price = Price,
			OldPrice = OldPrice,
			IsSaleActive = false,
			Weight = 0m,
			UnitType = UnitType,
			BasketStep = BasketStep,
			Discount = null,
			ImageUrl = ImageUrl,
			Code = Code,
			GimaId = GimaId,
			IsAdult = IsAdult,
			IsNew = false,
			Comment = null,
			Cashback = null,
			PlusOnePromotion = null,
			Tags = new ReadOnlyEquatableList<Tag>(),
			Collectible = null,
			Badges = new ReadOnlyEquatableList<BadgeModel>(),
			SelectedModifications = SelectedModifications.ToReadOnlyEquatable(),
			IsSelected = IsSelected,
			IsMarkedProduct = false,
			InCombo = false,
			TotalDiscount = TotalDiscount
		};
	}

	public static ProductOfferChange FromOffer(ProductOffer productOffer)
	{
		return new ProductOfferChange
		{
			Id = productOffer.Id.GetValueOrDefault(),
			ProductId = productOffer.ProductId,
			Qty = productOffer.Qty,
			RealStock = productOffer.RealStock,
			CategoryCodes = productOffer.CategoryCodes,
			Name = (productOffer.Name ?? ""),
			PricePerOne = productOffer.PricePerOne,
			Price = productOffer.Price,
			OldPrice = productOffer.OldPrice,
			UnitType = productOffer.UnitType,
			BasketStep = productOffer.BasketStep,
			ImageUrl = productOffer.ImageUrl,
			Code = (productOffer.Code ?? ""),
			GimaId = (productOffer.GimaId ?? ""),
			IsAdult = productOffer.IsAdult,
			SelectedModifications = productOffer.SelectedModifications.ToReadOnlyEquatable(),
			IsSelected = productOffer.IsSelected,
			TotalDiscount = productOffer.TotalDiscount,
			PromotionApplied = false,
			PromotionTooltip = null
		};
	}

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ProductOfferChange(ProductOfferChange original)
	{
		Id = original.Id;
		Code = original.Code;
		ProductId = original.ProductId;
		GimaId = original.GimaId;
		IsAdult = original.IsAdult;
		IsSelected = original.IsSelected;
		Qty = original.Qty;
		ImageUrl = original.ImageUrl;
		Name = original.Name;
		OldPrice = original.OldPrice;
		Price = original.Price;
		UnitType = original.UnitType;
		PricePerOne = original.PricePerOne;
		BasketStep = original.BasketStep;
		RealStock = original.RealStock;
		CategoryCodes = original.CategoryCodes;
		TotalDiscount = original.TotalDiscount;
		PromotionApplied = original.PromotionApplied;
		PromotionTooltip = original.PromotionTooltip;
		SelectedModifications = original.SelectedModifications;
	}

	public ProductOfferChange()
	{
	}
}
