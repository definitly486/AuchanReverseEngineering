using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Search.DTO;

public class SearchAutohintsFillsResultDTO
{
	[JsonProperty("tap")]
	public string Text { get; set; } = string.Empty;

	[JsonProperty("relatedSearch")]
	public string FullText { get; set; } = string.Empty;
}
