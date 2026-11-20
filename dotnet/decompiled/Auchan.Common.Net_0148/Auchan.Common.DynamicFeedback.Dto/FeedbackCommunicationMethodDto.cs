using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Dto;

public class FeedbackCommunicationMethodDto
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("code")]
	public int Code { get; set; }

	[JsonProperty("name")]
	public string? Name { get; set; }
}
