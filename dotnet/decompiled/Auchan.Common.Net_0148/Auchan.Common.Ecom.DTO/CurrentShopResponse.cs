using Auchan.Common.Ecom.AddressStoreSelection;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CurrentShopResponse
{
	[JsonProperty("currentDeliveryMethod")]
	public ReceivingMethod? CurrentReceiveMethod { get; set; }

	[JsonProperty("shop")]
	public ShopDto? Current { get; set; }

	[JsonProperty("defaultShop")]
	public ShopDto? Default { get; set; }
}
