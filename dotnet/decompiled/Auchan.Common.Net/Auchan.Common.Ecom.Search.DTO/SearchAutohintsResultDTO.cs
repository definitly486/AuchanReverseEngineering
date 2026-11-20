using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Search.DTO;

public class SearchAutohintsResultDTO
{
	[JsonProperty("data")]
	public SearchAutohintsDataResultDTO Data { get; set; } = new SearchAutohintsDataResultDTO();
}
