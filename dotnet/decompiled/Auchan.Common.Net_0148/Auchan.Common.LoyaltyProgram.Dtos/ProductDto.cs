using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class ProductDto
{
	[JsonProperty("code")]
	public string? Code { get; set; }

	[JsonProperty("domain")]
	public string? Domain { get; set; }

	[JsonProperty("points")]
	public decimal? Points { get; set; }

	[JsonProperty("processedPoints")]
	public List<ProcessedPointDto>? ProcessedPoints { get; set; }

	[JsonProperty("quantity")]
	public double? Quantity { get; set; }

	[JsonProperty("value")]
	public double? Value { get; set; }

	[JsonProperty("image_url")]
	public string? Image { get; set; }

	[JsonProperty("name")]
	public string? Name { get; set; }
}
