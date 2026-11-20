using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class ShopsResponse
{
	[JsonProperty("shops", Required = Required.Always)]
	public List<ShopDto> Shops { get; set; }

	[JsonProperty("services", Required = Required.Default)]
	public List<ShopServiceDto>? Services { get; set; }
}
