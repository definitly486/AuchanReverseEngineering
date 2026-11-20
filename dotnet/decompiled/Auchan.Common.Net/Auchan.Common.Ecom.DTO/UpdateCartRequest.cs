using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class UpdateCartRequest
{
	[JsonProperty("merchantId")]
	public string MerchantId { get; set; }

	[JsonProperty("arrived")]
	public int Arrived { get; set; }

	public UpdateCartRequest(string merchantId, int arrived)
	{
		MerchantId = merchantId;
		Arrived = arrived;
	}
}
