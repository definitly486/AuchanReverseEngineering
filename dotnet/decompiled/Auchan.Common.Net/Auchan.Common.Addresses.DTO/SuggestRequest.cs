using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Addresses.DTO;

public class SuggestRequest
{
	[JsonProperty("query")]
	public string Query { get; set; }

	[JsonProperty("count")]
	public int MaxSuggestions { get; set; } = 10;

	[JsonProperty("locations")]
	public List<LocationDto>? Locations { get; set; }

	public SuggestRequest(string query)
	{
		Query = query;
	}
}
