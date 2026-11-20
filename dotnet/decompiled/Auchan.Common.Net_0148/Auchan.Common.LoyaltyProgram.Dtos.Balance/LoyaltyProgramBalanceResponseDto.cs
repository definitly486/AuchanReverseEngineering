using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos.Balance;

public class LoyaltyProgramBalanceResponseDto
{
	[JsonProperty("balance")]
	public LoyaltyProgramBalanceDetailsDto? Balance { get; set; }

	[JsonProperty("identifierNo")]
	public string? IdentifierNumber { get; set; }

	[JsonProperty("status")]
	public string? Status { get; set; }

	[JsonProperty("redemptionEnabled")]
	public bool RedemptionEnabled { get; set; }

	[JsonProperty("redemptionRequiresPin")]
	public bool RedemptionRequiresPin { get; set; }

	[JsonProperty("salesEnabled")]
	public bool SalesEnabled { get; set; }

	[JsonProperty("totalPointBalance")]
	public bool TotalPointBalance { get; set; }
}
