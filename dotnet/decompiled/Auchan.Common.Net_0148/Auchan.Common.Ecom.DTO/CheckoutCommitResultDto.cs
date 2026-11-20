using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CheckoutCommitResultDto : BaseCheckoutResponseDto
{
	[JsonProperty("paymentUrl")]
	public string PaymentUrl { get; set; }

	[JsonProperty("orderId")]
	public string[] OrderIds { get; set; }
}
