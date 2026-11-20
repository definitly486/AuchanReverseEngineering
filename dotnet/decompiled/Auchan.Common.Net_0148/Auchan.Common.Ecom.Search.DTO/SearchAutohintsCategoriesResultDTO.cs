using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Search.DTO;

public class SearchAutohintsCategoriesResultDTO
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; } = string.Empty;

	[JsonProperty("code")]
	public string Code { get; set; } = string.Empty;
}
