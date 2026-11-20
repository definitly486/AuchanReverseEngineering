using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class ShopServiceDto
{
	[JsonProperty("id", Required = Required.Always)]
	public int Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("mobile_icon")]
	public string? Icon { get; set; }
}
