using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class ShopDeliveryTariffDto
{
	[JsonProperty("delivery_price")]
	public required decimal DeliveryPrice { get; init; }

	[JsonProperty("basket_cost")]
	public required decimal BasketCost { get; init; }
}
