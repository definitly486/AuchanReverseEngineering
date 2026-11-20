using Newtonsoft.Json;

namespace Auchan.Common.Reviews.Api.Ecom.Dto;

public sealed class HideFromUnreviewedRequestBodyDto
{
	[JsonProperty("gima_id", NullValueHandling = NullValueHandling.Ignore)]
	public string? GimaId { get; init; }
}
