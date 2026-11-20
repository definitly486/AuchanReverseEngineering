using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

public sealed class SearchTrackingRequest : TrackingRequest
{
	[JsonProperty("searchPhrase")]
	public required string SearchPhrase { get; init; }
}
