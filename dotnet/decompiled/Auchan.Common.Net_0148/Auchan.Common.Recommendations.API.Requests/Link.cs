using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

public class Link
{
	[JsonProperty("name")]
	public required string Name { get; init; }

	[JsonProperty("value")]
	public required string Value { get; init; }
}
