using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class LoyaltyProgramSocialStatusSegmentDto
{
	[JsonProperty("code")]
	public string Code { get; set; } = string.Empty;

	[JsonProperty("id")]
	public int Id { get; set; }
}
