using Newtonsoft.Json;

namespace Auchan.Common.Ecom.PriceChecker.Dto;

public class ValueAfterOpenPricecheckerDto
{
	[JsonProperty("client_id")]
	public string ClientId { get; set; }

	[JsonProperty("store_id")]
	public string StoreId { get; set; }

	[JsonProperty("device")]
	public string Device { get; set; }

	[JsonProperty("operating_system")]
	public string OperatingSystem { get; set; }
}
