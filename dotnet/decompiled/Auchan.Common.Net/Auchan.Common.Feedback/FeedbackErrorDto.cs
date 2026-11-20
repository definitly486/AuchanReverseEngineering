using Newtonsoft.Json;

namespace Auchan.Common.Feedback;

public sealed class FeedbackErrorDto
{
	[JsonProperty("code")]
	public string Code { get; set; }

	[JsonProperty("message")]
	public string Message { get; set; }

	public FeedbackErrorDto(string code, string message)
	{
		Code = code;
		Message = message;
	}
}
