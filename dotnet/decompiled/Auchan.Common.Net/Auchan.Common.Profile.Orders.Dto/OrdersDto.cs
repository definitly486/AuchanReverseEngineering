using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

public sealed record OrdersDto
{
	[JsonProperty("orders")]
	public IReadOnlyList<OrderDto> Orders { get; set; }

	[JsonProperty("range")]
	public int Range { get; set; }
}
