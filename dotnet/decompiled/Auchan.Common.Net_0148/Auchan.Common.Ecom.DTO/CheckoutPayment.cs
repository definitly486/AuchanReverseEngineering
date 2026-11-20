using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CheckoutPayment
{
	[JsonProperty("returnUrl")]
	public string ReturnUrl { get; set; }

	[JsonProperty("failureUrl")]
	public string FailureUrl { get; set; }

	[JsonProperty("paymentMethod")]
	public string PaymentMethod { get; set; }
}
