using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.DTO;

public sealed class RecommendationResponse
{
	[JsonProperty("recommendations")]
	public IReadOnlyList<RecommendationItem>? Recommendations { get; init; }
}
