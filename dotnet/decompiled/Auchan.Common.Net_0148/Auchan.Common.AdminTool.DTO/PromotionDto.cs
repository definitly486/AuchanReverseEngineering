using System.Collections.Generic;
using Auchan.Common.Deeplinks;
using Auchan.Common.Promotions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.AdminTool.DTO;

public class PromotionDto
{
	[JsonProperty("begins_on")]
	public long? BeginsOn { get; set; }

	[JsonProperty("category_code")]
	public string? СategoryСode { get; set; }

	[JsonProperty("category_title")]
	public string? CategoryTitle { get; set; }

	[JsonProperty("category_description")]
	public string? CategoryDescription { get; set; }

	[JsonProperty("category_link_text")]
	public string? CategoryLinkText { get; set; }

	[JsonProperty("category_link")]
	public string? CategoryLink { get; set; }

	[JsonProperty("description")]
	public string? Description { get; set; }

	[JsonProperty("ends_on")]
	public long? EndsOn { get; set; }

	[JsonProperty("id", Required = Required.Always)]
	public int Id { get; set; }

	[JsonProperty("kind", Required = Required.Always)]
	[JsonConverter(typeof(StringEnumConverter))]
	public PromotionKind Kind { get; set; }

	[JsonProperty("name", Required = Required.Always)]
	public string Name { get; set; }

	[JsonProperty("picture", Required = Required.Always)]
	public string Picture { get; set; }

	[JsonProperty("short_picture", Required = Required.Default)]
	public string? ShortPicture { get; set; }

	[JsonProperty("animation", Required = Required.Default)]
	public string? Animation { get; set; }

	[JsonProperty("position_multiple", Required = Required.Default)]
	[JsonConverter(typeof(PositionMultipleJsonConverter))]
	public List<PromotionPosition>? Position { get; set; }

	[JsonProperty("region_id")]
	public int? RegionId { get; set; }

	[JsonProperty("regions")]
	public List<int>? RegionIds { get; set; }

	[JsonProperty("stores")]
	public List<int>? StoreIds { get; set; }

	[JsonProperty("url")]
	public string? Url { get; set; }

	[JsonProperty("navigated_to", Required = Required.Default)]
	[JsonConverter(typeof(DeeplinkTypeConverter))]
	public DeeplinkType? Deeplink { get; set; }

	[JsonProperty("navigation_code", Required = Required.Default)]
	public string? DeeplinkId { get; set; }

	public string GimaId { get; set; } = "";
}
