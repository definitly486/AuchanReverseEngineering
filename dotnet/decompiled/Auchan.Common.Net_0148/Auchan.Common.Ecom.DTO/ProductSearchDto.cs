using System;
using System.Collections.Generic;
using Auchan.Common.Reviews.Api.Ecom.Dto;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class ProductSearchDto
{
	[JsonProperty("id")]
	public int Id { get; init; }

	[JsonProperty("gimaId")]
	public string GimaId { get; init; }

	[JsonProperty("code", Required = Required.Always)]
	public string Code { get; init; }

	[JsonProperty("brandName")]
	public string? BrandName { get; init; }

	[JsonProperty("isAdult", Required = Required.Default)]
	public bool? IsAdult { get; init; }

	[JsonProperty("name")]
	public string? Name { get; init; }

	[JsonProperty("productId")]
	public string? ProductId { get; init; }

	[JsonProperty("icon")]
	public string? Icon { get; init; }

	[JsonProperty("categoryName")]
	public string? CategoryName { get; init; }

	[JsonProperty("type")]
	public string? Type { get; init; }

	[JsonProperty("rating")]
	public string? Rating { get; init; }

	[JsonProperty("tags")]
	public IReadOnlyList<object>? Tags { get; init; }

	[JsonProperty("weight")]
	public decimal Weight { get; init; }

	[JsonProperty("package_display", Required = Required.Default)]
	public string? PackageDisplay { get; init; }

	[JsonProperty("basketStep")]
	public decimal BasketStep { get; init; }

	[JsonProperty("is_new")]
	public bool IsNew { get; init; }

	[JsonProperty("active")]
	public bool IsActive { get; init; }

	[JsonProperty("saleActive")]
	public bool IsSaleActive { get; init; }

	[JsonProperty("stock")]
	public StockDto? Stock { get; init; }

	[JsonProperty("price")]
	public PriceDto? Price { get; init; }

	[JsonProperty("oldPrice")]
	public PriceDto? OldPrice { get; init; }

	[JsonProperty("imageUrl")]
	public string? ImageUrl { get; init; }

	[JsonProperty("discount", Required = Required.Default)]
	public DiscountDto? Discount { get; init; }

	[JsonProperty("cashback")]
	public CashbackDto? Cashback { get; init; }

	[JsonProperty("plus_one_promotion")]
	public PlusOnePromotionDto? PlusOnePromotion { get; init; }

	[JsonProperty("modifications", Required = Required.Default)]
	public IReadOnlyList<ProductModificationDto> Modifications { get; init; } = Array.Empty<ProductModificationDto>();

	[JsonProperty("collectible")]
	public CollectibleInfoDto? Collectible { get; init; }

	[JsonProperty("rate", NullValueHandling = NullValueHandling.Ignore)]
	public RateDto? Rate { get; init; }

	[JsonProperty("mediaUrls")]
	public IReadOnlyList<string>? MediaUrls { get; init; }

	[JsonProperty("badges")]
	public IReadOnlyList<BadgeDto>? Badges { get; init; } = Array.Empty<BadgeDto>();

	[JsonProperty("in_combo")]
	public bool InCombo { get; init; }
}
