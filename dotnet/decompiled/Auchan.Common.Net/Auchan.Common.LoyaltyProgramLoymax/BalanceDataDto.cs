using System;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class BalanceDataDto
{
	[JsonProperty("items")]
	public ItemDto[]? Items { get; set; }

	[JsonProperty("next_expiration_amount")]
	public long? NextExpirationAmount { get; set; }

	[JsonProperty("next_expiration_date")]
	public DateTime? NextExpirationDate { get; set; }

	[JsonProperty("next_activation_amount")]
	public long? NextActivationAmount { get; set; }

	[JsonProperty("next_activation_date")]
	public DateTime? NextActivationDate { get; set; }

	[JsonProperty("expiration_currency_list")]
	public LoyaltyCurrencyDto[]? ExpirationCurrencyList { get; set; }

	[JsonProperty("activation_currency_list")]
	public LoyaltyCurrencyDto[]? ActivationCurrencyList { get; set; }
}
