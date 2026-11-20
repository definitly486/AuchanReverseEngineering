using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class LoyaltyProgramCommonRequestDto
{
	[JsonProperty("accessToken")]
	public string? AccessToken { get; set; }

	[JsonProperty("source")]
	public string? Source { get; set; }
}
