using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CartItemNotAuthRequest
{
	[JsonProperty("merchant", Required = Required.Always)]
	public string Merchant { get; set; }

	[JsonProperty("items", Required = Required.Always)]
	public ProductOfferDto[] Items { get; set; }
}
