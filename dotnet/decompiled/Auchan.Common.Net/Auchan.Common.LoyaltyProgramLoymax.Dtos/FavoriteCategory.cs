using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax.Dtos;

public class FavoriteCategory
{
	[JsonProperty("link")]
	public string Link { get; set; } = "";

	[JsonProperty("code")]
	public string Code { get; set; } = "";

	[JsonProperty("category_id")]
	public string CategoryId { get; set; } = "";

	[JsonProperty("name")]
	public string Name { get; set; } = "";

	[JsonProperty("image_url")]
	public string? ImageUrl { get; set; }

	[JsonProperty("mobile_image_url")]
	public string MobileImageUrl { get; set; } = "";

	[JsonProperty("preference_value")]
	public int PreferenceValue { get; set; }

	[JsonProperty("preference_type")]
	public int PreferenceType { get; set; }

	[JsonProperty("description")]
	public string Description { get; set; } = "";
}
