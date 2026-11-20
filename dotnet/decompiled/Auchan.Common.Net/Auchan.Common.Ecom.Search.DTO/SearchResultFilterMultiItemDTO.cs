using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Search.DTO;

public class SearchResultFilterMultiItemDTO
{
	[JsonProperty("name")]
	public string Name { get; init; } = string.Empty;

	[JsonProperty("code")]
	public string Code { get; init; } = string.Empty;

	[JsonProperty("disabled")]
	public bool Disabled { get; init; }

	[JsonProperty("counter")]
	public int Counter { get; init; }
}
