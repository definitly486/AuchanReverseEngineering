using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.DTO;

public sealed class RecommendationItem
{
	[JsonProperty("productId")]
	public string GimaId { get; set; }
}
