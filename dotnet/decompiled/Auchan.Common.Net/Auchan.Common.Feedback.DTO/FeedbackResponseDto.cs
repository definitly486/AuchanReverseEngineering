using Newtonsoft.Json;

namespace Auchan.Common.Feedback.DTO;

public sealed class FeedbackResponseDto
{
	[JsonProperty("non_field_errors")]
	public FeedbackErrorDto[]? Errors { get; set; }
}
