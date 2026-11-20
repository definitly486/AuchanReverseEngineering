using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CartProductDto
{
	[JsonProperty("id")]
	public required long? Id { get; init; }

	[JsonProperty("gimaId")]
	public required string? GimaId { get; init; }

	[JsonProperty("name")]
	public required string? Name { get; init; }

	[JsonProperty("code")]
	public required string? Code { get; init; }

	[JsonProperty("categoryCodes")]
	public required IReadOnlyList<string> CategoryCodes { get; init; } = Array.Empty<string>();

	[JsonProperty("categoryId")]
	public required IReadOnlyList<long> CategoryIds { get; init; } = Array.Empty<long>();

	[JsonProperty("categoryNames")]
	public required IReadOnlyList<string> CategoryNames { get; init; } = Array.Empty<string>();

	[JsonProperty("price")]
	public required PriceDto? Price { get; init; }

	[JsonProperty("pricePerOne")]
	public required decimal? PricePerOne { get; init; }

	[JsonProperty("active")]
	public required bool? Active { get; init; }

	[JsonProperty("saleActive")]
	public required bool? SaleActive { get; init; }

	[JsonProperty("stock")]
	public required StockDto? Stock { get; init; }

	[JsonProperty("tags")]
	public required IReadOnlyList<Tag>? Tags { get; init; }

	[JsonProperty("oldPrice")]
	public required PriceDto? OldPrice { get; init; }

	[JsonProperty("imageUrl")]
	public required string? ImageUrl { get; init; }

	[JsonProperty("productId")]
	public required string? ProductId { get; init; }

	[JsonProperty("weight")]
	public required decimal? Weight { get; init; }

	[JsonProperty("basketStep")]
	public required decimal? BasketStep { get; init; }

	[JsonProperty("discount")]
	public required DiscountDto? Discount { get; init; }

	[JsonProperty("isAdult")]
	public required bool? IsAdult { get; init; }

	[JsonProperty("is_new")]
	public required bool IsNew { get; init; }

	[JsonProperty("modifications")]
	public required IReadOnlyList<ProductModificationDto>? Modifications { get; init; }

	[JsonProperty("cashback")]
	public required CashbackDto? Cashback { get; init; }

	[JsonProperty("collectible")]
	public required CollectibleInfoDto? Collectible { get; init; }

	[JsonProperty("plus_one_promotion")]
	public required PlusOnePromotionDto? PlusOnePromotion { get; init; }

	[JsonProperty("badges")]
	public required IReadOnlyList<BadgeDto>? Badges { get; init; } = Array.Empty<BadgeDto>();

	[JsonProperty("total_discount")]
	public required decimal TotalDiscount { get; init; }
}
