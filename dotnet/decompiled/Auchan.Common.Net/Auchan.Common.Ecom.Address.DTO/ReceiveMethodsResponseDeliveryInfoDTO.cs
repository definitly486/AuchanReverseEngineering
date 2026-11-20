using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Address.DTO;

public class ReceiveMethodsResponseDeliveryInfoDTO
{
	[JsonProperty("address_string")]
	public string? Address { get; set; } = string.Empty;

	[JsonProperty("time")]
	public string? Time { get; set; } = string.Empty;

	[JsonProperty("express_time")]
	public string? ExpressTime { get; set; } = string.Empty;

	[JsonProperty("price")]
	public decimal? Price { get; set; }
}
