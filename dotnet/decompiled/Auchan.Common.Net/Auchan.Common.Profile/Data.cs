using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Profile;

public class Data
{
	[JsonProperty("items")]
	public List<FavoriteProductDto>? Items { get; set; }

	[JsonProperty("range")]
	public long? Range { get; set; }

	[JsonProperty("activeRange")]
	public long? ActiveRange { get; set; }

	[JsonProperty("minPrice")]
	public double? MinPrice { get; set; }

	[JsonProperty("maxPrice")]
	public double? MaxPrice { get; set; }
}
