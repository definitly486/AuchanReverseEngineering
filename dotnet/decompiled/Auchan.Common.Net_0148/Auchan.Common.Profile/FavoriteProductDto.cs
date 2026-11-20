using System.Collections.Generic;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Reviews.Api.Ecom.Dto;
using Newtonsoft.Json;

namespace Auchan.Common.Profile;

public class FavoriteProductDto
{
	[JsonProperty("id")]
	public long? Id { get; set; }

	[JsonProperty("productId")]
	public string? ProductId { get; init; }

	[JsonProperty("code")]
	public string? Code { get; set; }

	[JsonProperty("categoryCodes")]
	public List<CategoryCodeDto>? CategoryCodes { get; set; }

	[JsonProperty("additionalCategories")]
	public List<List<AdditionalCategory>>? AdditionalCategories { get; set; }

	[JsonProperty("gima_id")]
	public long? GimaId { get; set; }

	[JsonProperty("title")]
	public string? Title { get; set; }

	[JsonProperty("price")]
	public FavoritePriceDto? Price { get; set; }

	[JsonProperty("clientAccountID")]
	public long? ClientAccountId { get; set; }

	[JsonProperty("created_at")]
	public string? CreatedAt { get; set; }

	[JsonProperty("basketStep")]
	public decimal? BasketStep { get; set; }

	[JsonProperty("stock")]
	public StockDto? Stock { get; set; }

	[JsonProperty("saleActive")]
	public bool? SaleActive { get; set; }

	[JsonProperty("active")]
	public bool? Active { get; set; }

	[JsonProperty("isAdult")]
	public bool? IsAdult { get; set; }

	[JsonProperty("is_new")]
	public bool IsNew { get; set; }

	[JsonProperty("oldPrice")]
	public FavoritePriceDto? OldPrice { get; set; }

	[JsonProperty("discount")]
	public DiscountDto? Discount { get; set; }

	[JsonProperty("cashback")]
	public CashbackDto? Cashback { get; set; }

	[JsonProperty("plus_one_promotion")]
	public PlusOnePromotionDto? PlusOnePromotion { get; set; }

	[JsonProperty("catalogImageUrl")]
	public string? CatalogImageUrl { get; set; }

	[JsonProperty("mediaUrls")]
	public IReadOnlyList<string>? MediaUrls { get; set; }

	[JsonProperty("description")]
	public Description? Description { get; set; }

	[JsonProperty("rate")]
	public RateDto? Rate { get; set; }

	[JsonProperty("collectible")]
	public CollectibleInfoDto? Collectible { get; set; }

	[JsonProperty("in_waitlist")]
	public bool? InWaitList { get; set; }

	[JsonProperty("badges")]
	public List<BadgeDto>? Badges { get; set; } = new List<BadgeDto>();

	[JsonProperty("package_display")]
	public string? PackageDisplay { get; set; }

	[JsonProperty("in_combo")]
	public bool InCombo { get; init; }
}
