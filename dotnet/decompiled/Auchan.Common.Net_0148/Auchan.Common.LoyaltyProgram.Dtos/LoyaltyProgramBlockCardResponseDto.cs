using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class LoyaltyProgramBlockCardResponseDto
{
	[JsonProperty("error")]
	public int Error { get; set; }

	[JsonProperty("Msg")]
	public string? Message { get; set; }
}
