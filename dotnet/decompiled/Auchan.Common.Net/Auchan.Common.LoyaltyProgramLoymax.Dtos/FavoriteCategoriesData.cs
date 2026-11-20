using System;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax.Dtos;

public class FavoriteCategoriesData
{
	[JsonProperty("title")]
	public string Title { get; set; } = "";

	[JsonProperty("subtitle")]
	public string Subtitle { get; set; } = "";

	[JsonProperty("description_title")]
	public string DescriptionTitle { get; set; } = "";

	[JsonProperty("description")]
	public string Description { get; set; } = "";

	[JsonProperty("detail_description")]
	public string DetailDescription { get; set; } = "";

	[JsonProperty("max_count")]
	public int MaxCount { get; set; }

	[JsonProperty("accepted")]
	public bool Accepted { get; set; }

	[JsonProperty("categories")]
	public FavoriteCategory[] Categories { get; set; } = Array.Empty<FavoriteCategory>();
}
