using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

public class CustomData
{
	[JsonProperty("name")]
	public required string Name { get; init; }
}
