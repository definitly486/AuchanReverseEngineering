using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CheckoutRecipient
{
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("phone")]
	public string Phone { get; set; }

	[JsonProperty("email")]
	public string? Email { get; set; }
}
