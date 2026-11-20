using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

public class SoftLinks
{
	[JsonProperty("loymax_loyalty")]
	public required string? LoymaxLoyalty { get; init; }
}
