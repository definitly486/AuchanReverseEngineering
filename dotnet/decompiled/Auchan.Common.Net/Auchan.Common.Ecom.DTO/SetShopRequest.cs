using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class SetShopRequest
{
	[JsonProperty("merchant_id")]
	public int ShopId { get; }

	[JsonProperty("delivery_method")]
	public int DeliveryMethod { get; }

	[JsonProperty("simulate", NullValueHandling = NullValueHandling.Ignore)]
	public bool? Simulate { get; }

	public SetShopRequest(int shopId, int deliveryMethod, bool? simulate)
	{
		ShopId = shopId;
		DeliveryMethod = deliveryMethod;
		Simulate = simulate;
	}
}
