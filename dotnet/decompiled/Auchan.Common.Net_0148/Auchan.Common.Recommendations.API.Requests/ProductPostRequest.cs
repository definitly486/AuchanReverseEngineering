using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

public sealed class ProductPostRequest : TrackingRequest
{
	[JsonProperty("id")]
	public required long ProductId { get; init; }

	[JsonProperty("stockId")]
	public required string StockId { get; init; }

	[JsonProperty("name")]
	public required string Name { get; init; }

	[JsonProperty("price")]
	public decimal? Price { get; init; }

	[JsonProperty("pictureUrl")]
	public required string PictureUrl { get; init; }

	[JsonProperty("url")]
	public required string Url { get; init; }

	[JsonProperty("isAvailable")]
	public bool isAvailable { get; set; }

	[JsonProperty("categoryPaths")]
	public required string[] CategoryPaths { get; init; }

	[JsonProperty("description")]
	public required string description { get; init; }

	[JsonProperty("vendor")]
	public required string Vendor { get; init; }

	[JsonProperty("oldPrice")]
	public decimal? OldPrice { get; set; }

	[JsonProperty("params")]
	public required Dictionary<string, string> BasketParams { get; init; }
}
