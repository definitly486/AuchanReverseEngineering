using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Dto;

public class PreferredCommunicationMethod
{
	[JsonProperty("id")]
	public long Id { get; set; }

	[JsonProperty("code")]
	public long Code { get; set; }

	[JsonProperty("name")]
	public string? Name { get; set; }
}
