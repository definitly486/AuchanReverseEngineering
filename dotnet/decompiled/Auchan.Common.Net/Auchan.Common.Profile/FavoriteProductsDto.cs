using Newtonsoft.Json;

namespace Auchan.Common.Profile;

public class FavoriteProductsDto
{
	[JsonProperty("data")]
	public Data? Data { get; set; }

	[JsonProperty("meta")]
	public Meta? Meta { get; set; }
}
