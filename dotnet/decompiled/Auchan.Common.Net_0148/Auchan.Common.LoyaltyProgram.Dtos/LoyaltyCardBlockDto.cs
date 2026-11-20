using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class LoyaltyCardBlockDto
{
	[JsonProperty("fraud")]
	public bool Fraud { get; set; }

	[JsonProperty("reason")]
	public string? Reason { get; set; }
}
