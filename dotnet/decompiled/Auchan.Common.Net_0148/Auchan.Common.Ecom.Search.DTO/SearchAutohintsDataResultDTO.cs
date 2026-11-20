using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Search.DTO;

public class SearchAutohintsDataResultDTO
{
	[JsonProperty("query")]
	public string Query { get; set; } = string.Empty;

	[JsonProperty("correction")]
	public string Correction { get; set; } = string.Empty;

	[JsonProperty("sts")]
	public List<SearchAutohintsPopularsResultDTO> Populars { get; set; } = new List<SearchAutohintsPopularsResultDTO>();

	[JsonProperty("taps")]
	public List<SearchAutohintsFillsResultDTO> Autofills { get; set; } = new List<SearchAutohintsFillsResultDTO>();

	[JsonProperty("categories")]
	public List<SearchAutohintsCategoriesResultDTO> Categories { get; set; } = new List<SearchAutohintsCategoriesResultDTO>();
}
