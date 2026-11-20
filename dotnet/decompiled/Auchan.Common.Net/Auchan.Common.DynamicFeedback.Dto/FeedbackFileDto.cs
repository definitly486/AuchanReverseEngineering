using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Dto;

public class FeedbackFileDto
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("name")]
	public string? Name { get; set; }

	[JsonProperty("url")]
	public string? Url { get; set; }

	[JsonProperty("size")]
	public int Size { get; set; }

	[JsonProperty("extension")]
	public string? Extension { get; set; }
}
