using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CheckoutCommitDto
{
	[JsonProperty("recipient")]
	public CheckoutRecipient Recipient { get; set; }

	[JsonProperty("receive")]
	public CheckoutReceive Receive { get; set; }

	[JsonProperty("payment")]
	public CheckoutPayment Payment { get; set; }
}
