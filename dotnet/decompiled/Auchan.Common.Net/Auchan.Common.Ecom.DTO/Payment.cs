using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class Payment
{
	[JsonProperty("payment_method")]
	public required long PaymentMethod { get; init; }

	[JsonProperty("sum")]
	public required Sum Sum { get; init; }
}
