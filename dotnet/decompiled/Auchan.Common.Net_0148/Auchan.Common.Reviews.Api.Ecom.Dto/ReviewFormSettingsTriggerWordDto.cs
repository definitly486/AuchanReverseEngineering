using Newtonsoft.Json;

namespace Auchan.Common.Reviews.Api.Ecom.Dto;

public class ReviewFormSettingsTriggerWordDto
{
	[JsonProperty("id")]
	public int? Id { get; set; }

	[JsonProperty("name")]
	public string? Name { get; set; }

	[JsonProperty("is_custom")]
	public bool IsCustom { get; set; }
}
