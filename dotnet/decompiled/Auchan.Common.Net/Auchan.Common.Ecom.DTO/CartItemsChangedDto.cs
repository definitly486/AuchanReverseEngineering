using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record CartItemsChangedDto
{
	public sealed record DataDto
	{
		[JsonProperty("changed")]
		public required IReadOnlyList<ChangedDto>? Changed { get; init; }

		[JsonProperty("items")]
		public required IReadOnlyList<ItemDto> Items { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private DataDto(DataDto original)
		{
			Changed = original.Changed;
			Items = original.Items;
		}

		public DataDto()
		{
		}
	}

	public sealed record ItemDto
	{
		[JsonProperty("id", Required = Required.Always)]
		public required long OfferId { get; init; }

		[JsonProperty("code", Required = Required.Always)]
		public required string Code { get; init; }

		[JsonProperty("product_id", Required = Required.Always)]
		public required long ProductId { get; init; }

		[JsonProperty("gima_id", Required = Required.Always)]
		public required string GimaId { get; init; }

		[JsonProperty("is_adult")]
		public required bool IsAdult { get; init; }

		[JsonProperty("is_selected")]
		public required bool IsSelected { get; init; }

		[JsonProperty("qty", Required = Required.Always)]
		public required decimal Qty { get; init; }

		[JsonProperty("image_url")]
		public required string? Image { get; init; }

		[JsonProperty("name", Required = Required.Always)]
		public required string Name { get; init; }

		[JsonProperty("old_price")]
		public required PriceDto? OldPrice { get; init; }

		[JsonProperty("price", Required = Required.Always)]
		public required PriceDto Price { get; init; }

		[JsonProperty("price_per_one")]
		public required decimal? PricePerOne { get; init; }

		[JsonProperty("basket_step", Required = Required.Always)]
		public required decimal BasketStep { get; init; }

		[JsonProperty("stock_qty", Required = Required.Always)]
		public required decimal StockQty { get; init; }

		[JsonProperty("selected_modifications")]
		public required IReadOnlyList<SelectedModificationDto>? SelectedModifications { get; init; }

		[JsonProperty("modifications")]
		public required IReadOnlyList<ProductModificationDto>? Modifications { get; init; }

		[JsonProperty("category_codes", Required = Required.Always)]
		public required IReadOnlyList<CategoryCodeDto> CategoryCodes { get; init; }

		[JsonProperty("total_discount")]
		public required decimal? TotalDiscount { get; init; }

		[JsonProperty("promotion")]
		public required PromotionDto? Promotion { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private ItemDto(ItemDto original)
		{
			OfferId = original.OfferId;
			Code = original.Code;
			ProductId = original.ProductId;
			GimaId = original.GimaId;
			IsAdult = original.IsAdult;
			IsSelected = original.IsSelected;
			Qty = original.Qty;
			Image = original.Image;
			Name = original.Name;
			OldPrice = original.OldPrice;
			Price = original.Price;
			PricePerOne = original.PricePerOne;
			BasketStep = original.BasketStep;
			StockQty = original.StockQty;
			SelectedModifications = original.SelectedModifications;
			Modifications = original.Modifications;
			CategoryCodes = original.CategoryCodes;
			TotalDiscount = original.TotalDiscount;
			Promotion = original.Promotion;
		}

		public ItemDto()
		{
		}
	}

	public sealed record ChangedDto
	{
		[JsonProperty("add", Required = Required.Always)]
		public required bool IsAddedToCart { get; init; }

		[JsonProperty("offer_id")]
		public required long? OfferId { get; init; }

		[JsonProperty("msg", Required = Required.Always)]
		public required IReadOnlyList<string> Messages { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private ChangedDto(ChangedDto original)
		{
			IsAddedToCart = original.IsAddedToCart;
			OfferId = original.OfferId;
			Messages = original.Messages;
		}

		public ChangedDto()
		{
		}
	}

	public sealed record PromotionDto
	{
		[JsonProperty("applied")]
		public required bool Applied { get; init; }

		[JsonProperty("tooltip")]
		public required string? Tooltip { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private PromotionDto(PromotionDto original)
		{
			Applied = original.Applied;
			Tooltip = original.Tooltip;
		}

		public PromotionDto()
		{
		}
	}

	[JsonProperty("data", Required = Required.Always)]
	public required DataDto Data { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CartItemsChangedDto(CartItemsChangedDto original)
	{
		Data = original.Data;
	}

	public CartItemsChangedDto()
	{
	}
}
