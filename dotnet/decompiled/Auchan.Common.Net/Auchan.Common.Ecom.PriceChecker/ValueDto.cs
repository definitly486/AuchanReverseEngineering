using Newtonsoft.Json;

namespace Auchan.Common.Ecom.PriceChecker;

public class ValueDto
{
	[JsonProperty("client_id")]
	public string ClientId { get; set; }

	[JsonProperty("store_id")]
	public string StoreId { get; set; }

	[JsonProperty("EAN")]
	public string Ean { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("response_code")]
	public long ResponseCode { get; set; }
}
