using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class LoyaltyCurrencyDto
{
	[JsonProperty("id")]
	public long Id { get; set; }

	[JsonProperty("code")]
	public string? Code { get; set; }
}
