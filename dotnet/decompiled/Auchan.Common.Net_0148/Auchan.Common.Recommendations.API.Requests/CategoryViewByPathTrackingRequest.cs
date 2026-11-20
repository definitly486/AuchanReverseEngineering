using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

public sealed class CategoryViewByPathTrackingRequest : TrackingRequest
{
	[JsonProperty("categoryPath")]
	public required string CategoryPath { get; set; }
}
