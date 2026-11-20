using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class LoyaltyOperationsFilterDto
{
	[JsonProperty("expiration_currency_list", NullValueHandling = NullValueHandling.Ignore)]
	public LoyaltyCurrencyDto[]? ExpirationCurrencyList { get; set; }

	[JsonProperty("activation_currency_list", NullValueHandling = NullValueHandling.Ignore)]
	public LoyaltyCurrencyDto[]? ActivationCurrencyList { get; set; }
}
