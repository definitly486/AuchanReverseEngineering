using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Analytics.Digenetica.DTO;

internal class SearchDTO : BaseEventDTO
{
	[JsonProperty("searchTerm")]
	public string Query { get; set; }

	[JsonProperty("pageNumber")]
	public string Page { get; set; }

	[JsonProperty("pageProducts")]
	public IReadOnlyList<string>? ProductIds { get; set; }
}
