using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos.Balance;

public class LoyaltyProgramBalanceDetailsDto
{
	[JsonProperty("pinSet")]
	public bool PinSet { get; set; }

	[JsonProperty("pointBalances")]
	public IEnumerable<LoyaltyProgramBalanceDetailsItemDto>? Balances { get; set; }
}
