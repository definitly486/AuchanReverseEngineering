using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

public sealed class ProductTrackingRequest : TrackingRequest
{
	[JsonProperty("productId")]
	public required long ProductId { get; init; }

	[JsonProperty("stockId")]
	public required string StockId { get; init; }
}
