using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class StampDiscountDto
{
	[JsonProperty("data", Required = Required.Always)]
	public StampDiscountData Data { get; set; }
}
