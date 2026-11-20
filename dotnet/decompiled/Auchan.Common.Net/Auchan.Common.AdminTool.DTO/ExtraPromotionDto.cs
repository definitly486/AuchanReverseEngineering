using Auchan.Common.AdminTool.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.AdminTool.DTO;

public sealed class ExtraPromotionDto
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; } = string.Empty;

	[JsonConverter(typeof(StringEnumConverter))]
	[JsonProperty("location")]
	public ExtraPromotionLocation Location { get; set; }

	[JsonConverter(typeof(StringEnumConverter))]
	[JsonProperty("transition")]
	public ExtraPromotionTransition Transition { get; set; }

	[JsonProperty("picture")]
	public string Picture { get; set; } = string.Empty;

	[JsonProperty("begins_on")]
	public long? BeginsOn { get; set; }

	[JsonProperty("ends_on")]
	public long? EndsOn { get; set; }

	[JsonProperty("location_id")]
	public int? LocationId { get; set; }

	[JsonProperty("transition_code")]
	public string? TransitionCode { get; set; }

	[JsonProperty("region_id")]
	public int? RegionId { get; set; }
}
