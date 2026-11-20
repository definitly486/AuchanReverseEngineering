using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

public sealed class CategoryViewTrackingRequest : TrackingRequest
{
	[JsonProperty("categoryId")]
	public required long CategoryId { get; init; }
}
