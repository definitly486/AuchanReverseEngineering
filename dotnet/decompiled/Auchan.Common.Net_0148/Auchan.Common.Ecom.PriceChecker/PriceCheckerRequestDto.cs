using Newtonsoft.Json;

namespace Auchan.Common.Ecom.PriceChecker;

public class PriceCheckerRequestDto
{
	[JsonProperty("ean")]
	public required long Ean { get; init; }

	[JsonProperty("client_id")]
	public required string ClientId { get; init; }

	[JsonProperty("is_employee")]
	public required bool IsEmployee { get; init; }

	[JsonProperty("merchant_id")]
	public required int MerchantId { get; init; }
}
