using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class SetShopResponse
{
	[JsonProperty("wasBasketChange", Required = Required.Always)]
	public bool BasketChanged { get; set; }
}
