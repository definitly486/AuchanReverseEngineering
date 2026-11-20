using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class StampDiscountData
{
	[JsonProperty("stamp")]
	public decimal Stamps { get; set; }

	[JsonProperty("count")]
	public string CountDescription { get; set; } = string.Empty;

	[JsonProperty("items")]
	public List<StampDiscountItem> Items { get; set; } = new List<StampDiscountItem>();
}
