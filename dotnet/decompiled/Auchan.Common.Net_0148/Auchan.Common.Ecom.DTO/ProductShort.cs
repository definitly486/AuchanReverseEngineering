using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class ProductShort
{
	[JsonProperty("id")]
	public long Id { get; init; }

	[JsonProperty("auchan_code")]
	public long AuchanCode { get; init; }

	[JsonProperty("name")]
	public required string Name { get; init; }

	[JsonProperty("brandName")]
	public required string BrandName { get; init; }

	[JsonProperty("categoryName")]
	public required string CategoryName { get; init; }

	[JsonProperty("categoryNames")]
	public required IReadOnlyList<string> CategoryNames { get; init; }

	[JsonProperty("qty")]
	public decimal Qty { get; init; }

	[JsonProperty("step_basket")]
	public decimal BasketStep { get; init; }

	[JsonProperty("price")]
	public decimal Price { get; init; }

	[JsonProperty("unit_type")]
	public required string UnitType { get; init; }

	[JsonProperty("image_url")]
	public string? ImageUrl { get; init; }
}
