using System.Collections.Generic;
using Auchan.Common.Ecom.DTO;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

public class ProductDto
{
	[JsonProperty("name")]
	public string? Name { get; set; }

	[JsonProperty("imageUrl", Required = Required.Default)]
	public string? ImageUrl { get; set; }

	[JsonProperty("code")]
	public string? Code { get; set; }

	[JsonProperty("gima_id")]
	public string? GimaId { get; set; }

	[JsonProperty("qty", Required = Required.Default)]
	public decimal? Qty { get; set; }

	[JsonProperty("price", Required = Required.Default)]
	public decimal? Price { get; set; }

	[JsonProperty("qty_init", Required = Required.Default)]
	public decimal? QtyInit { get; set; }

	[JsonProperty("price_init", Required = Required.Default)]
	public decimal? PriceInit { get; set; }

	[JsonProperty("weight", Required = Required.Default)]
	public decimal? Weight { get; set; }

	[JsonProperty("product_type_is_per_kilo", Required = Required.Default)]
	public bool? ProductTypeIsPerKilo { get; set; }

	[JsonProperty("adult")]
	public bool Adult { get; set; }

	[JsonProperty("selected_modifications", Required = Required.Default)]
	public IReadOnlyList<SelectedModificationDto>? SelectedModifications { get; set; }

	[JsonProperty("modifications", Required = Required.Default)]
	public IReadOnlyList<ProductModificationDto>? Modifications { get; set; }

	[JsonProperty("item_id")]
	public int? ItemId { get; set; }

	[JsonProperty("source_item_id")]
	public int? SourceItemId { get; set; }

	[JsonProperty("dest_item_id")]
	public int? DestItemId { get; set; }
}
