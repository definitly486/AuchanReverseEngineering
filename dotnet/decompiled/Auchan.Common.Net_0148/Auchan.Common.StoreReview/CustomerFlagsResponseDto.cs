using Newtonsoft.Json;

namespace Auchan.Common.StoreReview;

public class CustomerFlagsResponseDto
{
	[JsonProperty("data")]
	public CustomerFlagsDataDto? Data { get; set; }

	[JsonProperty("meta")]
	public object? Meta { get; set; }
}
