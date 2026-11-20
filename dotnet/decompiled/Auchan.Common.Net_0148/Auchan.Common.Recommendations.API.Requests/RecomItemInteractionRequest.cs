using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

public sealed class RecomItemInteractionRequest : TrackingRequest
{
	[JsonProperty("productId")]
	public required long ProductId { get; init; }

	[JsonProperty("stockId")]
	public required string StockId { get; init; }

	[JsonProperty("recomBlockId")]
	public required string BlockId { get; init; }
}
