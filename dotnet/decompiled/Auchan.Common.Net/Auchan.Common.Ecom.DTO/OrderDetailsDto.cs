using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class OrderDetailsDto
{
	[JsonProperty("order")]
	public required Order Order { get; init; }

	[JsonProperty("shop")]
	public ShopDto? Shop { get; init; }

	[JsonProperty("deliveries")]
	public IReadOnlyList<Delivery>? Deliveries { get; init; }

	[JsonProperty("payments")]
	public IReadOnlyList<Payment>? Payments { get; init; }
}
