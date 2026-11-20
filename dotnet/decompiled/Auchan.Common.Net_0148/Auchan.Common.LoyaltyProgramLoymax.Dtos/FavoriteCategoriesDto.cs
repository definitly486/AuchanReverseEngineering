using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax.Dtos;

public class FavoriteCategoriesDto
{
	[JsonProperty("data")]
	public FavoriteCategoriesData Data { get; set; } = new FavoriteCategoriesData();
}
