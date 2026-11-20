using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class ShopPickupDto
{
	[JsonProperty("cost_min")]
	public int? CostMin { get; set; }

	[JsonProperty("cost_min_adult")]
	public int? CostMinAdult { get; set; }

	[JsonProperty("weight_max")]
	public int? WeightMax { get; set; }
}
