using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Address.DTO;

public class ReceiveMethodsResponseShopDTO
{
	[JsonProperty("region_id")]
	public int RegionId { get; set; }

	[JsonProperty("merchant_id")]
	public int MerchantId { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; } = string.Empty;
}
