using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class ProductOfferDto : ProductOfferBaseDto
{
	[JsonProperty("count", Required = Required.Always)]
	public decimal Count { get; set; }

	[JsonProperty("basketStep")]
	public decimal? BasketStep { get; set; }
}
