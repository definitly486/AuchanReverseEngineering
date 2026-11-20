using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

internal sealed class ProductPlacementTrackingRequest : TrackingRequest
{
	[JsonProperty("impressionContentId", Required = Required.Always)]
	public required string ContentId { get; init; }
}
