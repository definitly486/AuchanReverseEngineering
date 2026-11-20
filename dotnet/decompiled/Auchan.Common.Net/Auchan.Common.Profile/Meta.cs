using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Profile;

public class Meta
{
	[JsonProperty("products_count")]
	public long? ProductsCount { get; set; }

	[JsonProperty("gima_ids")]
	public List<long>? GimaIds { get; set; }

	[JsonProperty("categories")]
	public List<CategoryDto>? Categories { get; set; }
}
