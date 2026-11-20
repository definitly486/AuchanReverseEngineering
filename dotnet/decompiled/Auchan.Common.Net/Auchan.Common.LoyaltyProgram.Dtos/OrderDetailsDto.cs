using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class OrderDetailsDto
{
	[JsonProperty("delayedPoints")]
	public decimal? DelayedPoints { get; set; }

	[JsonProperty("bookDate")]
	public DateTime? DelayedPointsBookDate { get; set; }

	[JsonProperty("discountValue")]
	public long? DiscountValue { get; set; }

	[JsonProperty("processDate")]
	public DateTimeOffset? ProcessDate { get; set; }

	[JsonProperty("identifierId")]
	public long? IdentifierId { get; set; }

	[JsonProperty("products")]
	public List<ProductDto>? Products { get; set; }
}
