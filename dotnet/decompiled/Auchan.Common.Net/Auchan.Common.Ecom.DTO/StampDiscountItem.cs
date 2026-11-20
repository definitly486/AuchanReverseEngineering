using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class StampDiscountItem
{
	[JsonProperty("gima_id")]
	public int GimaId { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; } = string.Empty;

	[JsonProperty("price_per_one")]
	public decimal DiscountPrice { get; set; }

	[JsonProperty("cost_per_one")]
	public decimal FullPrice { get; set; }

	[JsonProperty("image_url")]
	public string ImageUrl { get; set; } = string.Empty;
}
