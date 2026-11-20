using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

public sealed class RecomBlockViewedRequest : TrackingRequest
{
	[JsonProperty("recomBlockId")]
	public required string BlockId { get; init; }
}
