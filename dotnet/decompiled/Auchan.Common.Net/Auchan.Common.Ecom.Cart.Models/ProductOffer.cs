using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Badges;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Extensions;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record ProductOffer : IProductOfferWithModifications
{
	public required long? Id { get; init; }

	public required long ProductId { get; init; }

	public required decimal Qty { get; init; }

	public decimal LastKnownStock => CartHelper.ComputeStock(RealStock, BasketStep, UnitType);

	public required decimal RealStock { get; init; }

	[JsonConverter(typeof(ReadOnlyEquatableListConverter<CategoryCodeDto>))]
	public required ReadOnlyEquatableList<CategoryCodeDto> CategoryCodes { get; init; }

	public required string? Name { get; init; }

	public required decimal PricePerOne { get; init; }

	public decimal PricePerOneOrPerKilo
	{
		get
		{
			if (UnitType != ProductUnitType.Gram_100)
			{
				return PricePerOne;
			}
			return PricePerOne * 10m;
		}
	}

	public required decimal Price { get; init; }

	public required decimal? OldPrice { get; init; }

	public decimal? OldPricePerOneOrPerKilo
	{
		get
		{
			if (!OldPrice.HasValue || UnitType != ProductUnitType.Gram_100)
			{
				return OldPrice;
			}
			return OldPrice / (decimal?)10;
		}
	}

	public required bool IsSaleActive { get; init; }

	public required decimal Weight { get; init; }

	public required ProductUnitType UnitType { get; init; }

	public required decimal BasketStep { get; init; }

	public required Discount? Discount { get; init; }

	public required string? ImageUrl { get; init; }

	public required string? Code { get; init; }

	public required string? GimaId { get; init; }

	public required bool IsAdult { get; init; }

	public required bool IsNew { get; init; }

	public required string? Comment { get; init; }

	public required Auchan.Common.Ecom.ProducModels.Cashback? Cashback { get; init; }

	public required PlusOnePromotion? PlusOnePromotion { get; init; }

	[JsonConverter(typeof(ReadOnlyEquatableListConverter<Tag>))]
	public required ReadOnlyEquatableList<Tag> Tags { get; init; }

	public required CollectibleInfo? Collectible { get; init; }

	[JsonConverter(typeof(ReadOnlyEquatableListConverter<BadgeModel>))]
	public required ReadOnlyEquatableList<BadgeModel> Badges { get; init; }

	[JsonConverter(typeof(ReadOnlyEquatableListConverter<SelectedModification>))]
	public required ReadOnlyEquatableList<SelectedModification> SelectedModifications { get; init; }

	public required bool IsSelected { get; init; }

	public required bool IsMarkedProduct { get; init; }

	public required bool InCombo { get; init; }

	public required decimal? TotalDiscount { get; init; }

	public bool ContainsModifications => SelectedModifications.IsNotNullOrEmpty();

	IReadOnlyList<SelectedModification> IProductOfferWithModifications.SelectedModifications => SelectedModifications;

	public bool IsMatch(Product product, IReadOnlyList<SelectedModification> modifications)
	{
		if (GimaId == product.GimaId)
		{
			return Cart.IsModificationsEqual(SelectedModifications, modifications);
		}
		return false;
	}

	public static ProductOffer Create(long? id, long productId, ReadOnlyEquatableList<SelectedModification> selectedModifications)
	{
		return new ProductOffer
		{
			SelectedModifications = selectedModifications.ToReadOnlyEquatable(),
			Badges = new ReadOnlyEquatableList<BadgeModel>(),
			CategoryCodes = new ReadOnlyEquatableList<CategoryCodeDto>(),
			Id = id,
			ProductId = productId,
			Qty = 0m,
			Name = null,
			PricePerOne = 0m,
			Price = 0m,
			OldPrice = null,
			IsSaleActive = false,
			Discount = null,
			Weight = 0m,
			ImageUrl = null,
			RealStock = 0m,
			UnitType = ProductUnitType.Unit,
			BasketStep = 0m,
			Code = null,
			GimaId = null,
			IsAdult = false,
			IsNew = false,
			Cashback = null,
			Collectible = null,
			PlusOnePromotion = null,
			Comment = null,
			Tags = new ReadOnlyEquatableList<Tag>(),
			IsSelected = false,
			IsMarkedProduct = false,
			InCombo = false,
			TotalDiscount = null
		};
	}

	public bool TryUpdateWith(ProductOfferChange change, [NotNullWhen(true)] out ProductOffer? offer)
	{
		if (Qty == change.Qty && PricePerOne == change.PricePerOne && OldPrice == change.OldPrice && Price == change.Price && RealStock == change.RealStock && TotalDiscount == change.TotalDiscount)
		{
			offer = null;
			return false;
		}
		offer = this with
		{
			ProductId = change.ProductId,
			Qty = change.Qty,
			PricePerOne = change.PricePerOne,
			OldPrice = change.OldPrice,
			Price = change.Price,
			RealStock = change.RealStock,
			TotalDiscount = change.TotalDiscount
		};
		return true;
	}

	public bool EqualsToWithModifications(ProductOffer other)
	{
		if (GimaId != other.GimaId)
		{
			return false;
		}
		if (SelectedModifications.Any())
		{
			return SelectedModifications.All((SelectedModification m) => m.Value?.Key == other.SelectedModifications.FirstOrDefault((SelectedModification c) => c.Code == m.Code)?.Value?.Key);
		}
		return true;
	}

	public ProductOfferKey GetKey()
	{
		return new ProductOfferKey
		{
			Id = Id,
			ProductId = ProductId,
			Code = Code,
			GimaId = GimaId,
			SelectedModifications = SelectedModifications
		};
	}

	public decimal GetSubTotal(bool showRealPrice, decimal qty)
	{
		if (!showRealPrice)
		{
			return PricePerOne * qty * (decimal)((UnitType != ProductUnitType.Gram_100) ? 1 : 10);
		}
		return Price;
	}

	public decimal GetSubTotal(bool showRealPrice)
	{
		return GetSubTotal(showRealPrice, Qty);
	}

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ProductOffer(ProductOffer original)
	{
		Id = original.Id;
		ProductId = original.ProductId;
		Qty = original.Qty;
		RealStock = original.RealStock;
		CategoryCodes = original.CategoryCodes;
		Name = original.Name;
		PricePerOne = original.PricePerOne;
		Price = original.Price;
		OldPrice = original.OldPrice;
		IsSaleActive = original.IsSaleActive;
		Weight = original.Weight;
		UnitType = original.UnitType;
		BasketStep = original.BasketStep;
		Discount = original.Discount;
		ImageUrl = original.ImageUrl;
		Code = original.Code;
		GimaId = original.GimaId;
		IsAdult = original.IsAdult;
		IsNew = original.IsNew;
		Comment = original.Comment;
		Cashback = original.Cashback;
		PlusOnePromotion = original.PlusOnePromotion;
		Tags = original.Tags;
		Collectible = original.Collectible;
		Badges = original.Badges;
		SelectedModifications = original.SelectedModifications;
		IsSelected = original.IsSelected;
		IsMarkedProduct = original.IsMarkedProduct;
		InCombo = original.InCombo;
		TotalDiscount = original.TotalDiscount;
	}

	public ProductOffer()
	{
	}
}
