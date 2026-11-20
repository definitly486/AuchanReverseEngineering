using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Search.DTO;

public class SearchRequestDTO
{
	[JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
	public Dictionary<string, object>? Filters { get; set; }

	[JsonProperty("sort")]
	public string Sort { get; set; } = "default";

	[JsonProperty("group_by", NullValueHandling = NullValueHandling.Include)]
	public string? GroupBy { get; set; }
}
