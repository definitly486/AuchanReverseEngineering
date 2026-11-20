using Newtonsoft.Json;

namespace Auchan.Common.Reviews.Api.Ecom.Dto;

public class RateDto
{
	[JsonProperty("rating")]
	public double? Rating { get; set; } = 0.0;

	[JsonProperty("reviews_qnt", NullValueHandling = NullValueHandling.Ignore)]
	public int ReviewsCount { get; set; }

	[JsonProperty("rate5", NullValueHandling = NullValueHandling.Ignore)]
	public int Rate5 { get; set; }

	[JsonProperty("rate4", NullValueHandling = NullValueHandling.Ignore)]
	public int Rate4 { get; set; }

	[JsonProperty("rate3", NullValueHandling = NullValueHandling.Ignore)]
	public int Rate3 { get; set; }

	[JsonProperty("rate2", NullValueHandling = NullValueHandling.Ignore)]
	public int Rate2 { get; set; }

	[JsonProperty("rate1", NullValueHandling = NullValueHandling.Ignore)]
	public int Rate1 { get; set; }
}
