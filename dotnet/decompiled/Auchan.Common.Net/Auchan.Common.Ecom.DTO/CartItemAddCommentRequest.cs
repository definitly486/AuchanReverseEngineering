using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CartItemAddCommentRequest
{
	[JsonProperty("items", Required = Required.Always)]
	public ProductOfferBaseDto[] Items { get; set; }
}
