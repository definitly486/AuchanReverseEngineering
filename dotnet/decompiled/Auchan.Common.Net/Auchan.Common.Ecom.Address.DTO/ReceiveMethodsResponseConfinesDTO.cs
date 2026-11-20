using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Address.DTO;

public class ReceiveMethodsResponseConfinesDTO
{
	[JsonProperty("cost_min")]
	public decimal? MinCost { get; set; }

	[JsonProperty("cost_min_adult")]
	public decimal? MinAdultCost { get; set; }
}
