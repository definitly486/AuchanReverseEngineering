using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class BalanceDto
{
	[JsonProperty("data")]
	public BalanceDataDto? Data { get; set; }
}
