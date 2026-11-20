using Newtonsoft.Json;

namespace Auchan.Common.Reviews.Api.Ecom.Dto;

public class OffsetPaginationDto
{
	[JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
	public string? Type { get; set; }

	[JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
	public int Limit { get; set; }

	[JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
	public int Offset { get; set; }

	[JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
	public int? Total { get; set; }
}
