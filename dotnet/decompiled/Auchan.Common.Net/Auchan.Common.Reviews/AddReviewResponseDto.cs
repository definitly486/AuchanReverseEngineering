using Newtonsoft.Json;

namespace Auchan.Common.Reviews;

public class AddReviewResponseDto
{
	[JsonProperty("Message")]
	public string? Message { get; set; }

	[JsonProperty("ReviewID")]
	public string? ReviewId { get; set; }
}
