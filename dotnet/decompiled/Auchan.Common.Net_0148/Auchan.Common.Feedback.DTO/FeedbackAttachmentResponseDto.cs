using Newtonsoft.Json;

namespace Auchan.Common.Feedback.DTO;

public sealed class FeedbackAttachmentResponseDto
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("content_type")]
	public string ContentType { get; set; }

	[JsonProperty("file")]
	public string File { get; set; }

	[JsonProperty("non_field_errors")]
	public FeedbackErrorDto[]? Errors { get; set; }

	public FeedbackAttachmentResponseDto(int id, string contentType, string file)
	{
		Id = id;
		ContentType = contentType;
		File = file;
	}
}
