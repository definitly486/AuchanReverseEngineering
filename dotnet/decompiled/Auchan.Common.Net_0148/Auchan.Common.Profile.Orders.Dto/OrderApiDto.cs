using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

public class OrderApiDto
{
	[JsonProperty("order")]
	public OrderDto Order { get; set; }
}
