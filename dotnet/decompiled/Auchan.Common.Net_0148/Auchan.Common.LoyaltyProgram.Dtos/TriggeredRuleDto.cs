using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class TriggeredRuleDto
{
	[JsonProperty("code")]
	public string? Code { get; set; }

	[JsonProperty("order")]
	public long? Order { get; set; }

	[JsonProperty("trlId")]
	public long? TrlId { get; set; }
}
