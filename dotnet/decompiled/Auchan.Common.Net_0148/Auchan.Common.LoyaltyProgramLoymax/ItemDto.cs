using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class ItemDto
{
	[JsonProperty("currency_code")]
	public string? CurrencyCode { get; set; }

	[JsonProperty("currency_amount")]
	public decimal? CurrencyAmount { get; set; }

	[JsonProperty("currency_name")]
	public string? CurrencyName { get; set; }
}
