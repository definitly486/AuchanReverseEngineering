using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class RepeatCartRequest
{
	[JsonProperty("merchantId")]
	public string MerchantId { get; set; }

	public RepeatCartRequest(string merchantId)
	{
		MerchantId = merchantId;
	}
}
