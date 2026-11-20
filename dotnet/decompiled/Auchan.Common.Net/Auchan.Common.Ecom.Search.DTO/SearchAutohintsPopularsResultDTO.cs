using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Search.DTO;

public class SearchAutohintsPopularsResultDTO
{
	[JsonProperty("st")]
	public string Text { get; set; } = string.Empty;

	[JsonProperty("amount")]
	public int Amount { get; set; }
}
