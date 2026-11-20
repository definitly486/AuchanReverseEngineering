using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

public sealed class OrderTrackingRequest : TrackingRequest
{
	[JsonProperty("productId")]
	public required long ProductId { get; init; }

	[JsonProperty("stockId")]
	public required string StockId { get; init; }

	[JsonProperty("quantity")]
	public required decimal Quantity { get; init; }

	[JsonProperty("price")]
	public required decimal Price { get; init; }

	[JsonProperty("transaction")]
	public required string Transaction { get; init; }
}
