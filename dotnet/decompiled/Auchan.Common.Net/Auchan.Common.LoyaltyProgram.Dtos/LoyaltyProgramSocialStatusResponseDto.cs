using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class LoyaltyProgramSocialStatusResponseDto
{
	[JsonProperty("segments", Required = Required.Default)]
	public LoyaltyProgramSocialStatusSegmentDto[]? Segments { get; set; }

	[JsonProperty("code")]
	public string Code { get; set; } = string.Empty;

	[JsonProperty("value")]
	public bool Value { get; set; }
}
