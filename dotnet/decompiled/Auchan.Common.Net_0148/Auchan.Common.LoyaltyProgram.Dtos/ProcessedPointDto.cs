using Auchan.Common.LoyaltyProgram.Enums;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class ProcessedPointDto
{
	[JsonProperty("pointType")]
	public ExpirationPointType? PointType { get; set; }

	[JsonProperty("points")]
	public decimal? Points { get; set; }

	[JsonProperty("trlId")]
	public long? TrlId { get; set; }

	[JsonProperty("trlResultId")]
	public long? TrlResultId { get; set; }
}
