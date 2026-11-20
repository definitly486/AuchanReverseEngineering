using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Responses;

public class City
{
	[JsonProperty("id")]
	public long Id { get; set; }

	[JsonProperty("lkp_town")]
	public string? LkpTown { get; set; }

	[JsonProperty("shops")]
	public List<Shop>? Shops { get; set; }
}
