using System;
using System.Collections.Generic;
using Auchan.Common.Reviews.Api.Ecom.Dto;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class ProductDto
{
	[JsonProperty("id")]
	public int? Id { get; init; }

	[JsonProperty("productId")]
	public string? ProductId { get; init; }

	[JsonProperty("code")]
	public string? Code { get; init; }

	[JsonProperty("categoryCodes")]
	public IReadOnlyList<CategoryCodeDto>? CategoryCodes { get; init; }

	[JsonProperty("title")]
	public string? Title { get; init; }

	[JsonProperty("title_url")]
	public string? ShareUrl { get; init; } = string.Empty;

	[JsonProperty("vendorCode")]
	public string? VendorCode { get; init; }

	[JsonProperty("price")]
	public PriceDto? Price { get; init; }

	[JsonProperty("offline_price")]
	public PriceDto? OfflinePrice { get; init; }

	[JsonProperty("stock")]
	public StockDto? Stock { get; init; }

	[JsonProperty("active")]
	public bool IsActive { get; init; }

	[JsonProperty("isAdult", Required = Required.Default)]
	public bool? IsAdult { get; init; }

	[JsonProperty("is_new")]
	public bool IsNew { get; init; }

	[JsonProperty("saleActive")]
	public bool? IsSaleActive { get; init; }

	[JsonProperty("oldPrice")]
	public PriceDto? OldPrice { get; init; }

	[JsonProperty("mediaUrls")]
	public IReadOnlyList<string>? MediaUrls { get; init; }

	[JsonProperty("description")]
	public DescriptionDto? Description { get; init; }

	[JsonProperty("characteristics")]
	public IReadOnlyList<CharacteristicDto>? Characteristics { get; init; }

	[JsonProperty("brand")]
	public BrandDto? Brand { get; init; }

	[JsonProperty("gimaId")]
	public string? GimaId { get; init; }

	[JsonProperty("cashback")]
	public CashbackDto? Cashback { get; init; }

	[JsonProperty("plus_one_promotion")]
	public PlusOnePromotionDto? PlusOnePromotion { get; init; }

	[JsonProperty("basketStep")]
	public decimal BasketStep { get; init; }

	[JsonProperty("discount")]
	public DiscountDto? Discount { get; init; }

	[JsonProperty("offline_discount")]
	public DiscountDto? OfflineDiscount { get; init; }

	[JsonProperty("energy_value")]
	public EnergyValueDto? EnergyValue { get; init; }

	[JsonProperty("modifications", Required = Required.Default)]
	public IReadOnlyList<ProductModificationDto> Modifications { get; init; } = Array.Empty<ProductModificationDto>();

	[JsonProperty("regional_category")]
	public bool? RegionalCategory { get; init; }

	[JsonProperty("collectible")]
	public CollectibleInfoDto? Collectible { get; init; }

	[JsonProperty("rate", NullValueHandling = NullValueHandling.Ignore)]
	public RateDto? Rate { get; init; }

	[JsonProperty("reviewing_is_allowed")]
	public bool ReviewingIsAllowed { get; init; }

	[JsonProperty("stickers")]
	public ReviewRewardStickerDto? ReviewRewardSticker { get; init; }

	[JsonProperty("channel")]
	public string? Channel { get; init; }

	[JsonProperty("gluings")]
	public IReadOnlyList<GluingDto> Gluings { get; init; } = Array.Empty<GluingDto>();

	[JsonProperty("badges")]
	public IReadOnlyList<BadgeDto>? Badges { get; init; } = Array.Empty<BadgeDto>();

	[JsonProperty("in_waitlist")]
	public bool? InWaitList { get; init; }

	[JsonProperty("package_display")]
	public string? PackageDisplay { get; init; }

	[JsonProperty("in_combo")]
	public bool InCombo { get; init; }

	[JsonProperty("product_certificate")]
	public IReadOnlyList<string?>? ProductsCertificate { get; init; }
}
