using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.DynamicFeedback.Responses;

public class FeedbackFieldDto
{
	[JsonProperty("name")]
	public string? Name { get; set; }

	[JsonProperty("type")]
	public long Type { get; set; }

	[JsonProperty("binding")]
	public bool Binding { get; set; }

	[JsonProperty("display")]
	public bool Display { get; set; }

	[JsonProperty("name_fos")]
	public string? NameFos { get; set; }

	[JsonProperty("position")]
	public long Position { get; set; }

	[JsonProperty("english_name")]
	public string? EnglishName { get; set; }

	[JsonConverter(typeof(StringEnumConverter))]
	[JsonProperty("mask")]
	public Mask? Mask { get; set; }
}
