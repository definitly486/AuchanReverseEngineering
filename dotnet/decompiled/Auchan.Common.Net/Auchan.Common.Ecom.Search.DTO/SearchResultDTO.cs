using System.Collections.Generic;
using Auchan.Common.Ecom.DTO;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Search.DTO;

public class SearchResultDTO
{
	[JsonProperty("items")]
	public IReadOnlyList<CategoryWithProductDto>? Items { get; init; }

	[JsonProperty("filters")]
	public IReadOnlyList<SearchResultFilterDTO>? Filters { get; init; }

	[JsonProperty("products_counter", Required = Required.Default)]
	public int Count { get; set; }

	[JsonProperty("selectedFilters", Required = Required.Default)]
	public IReadOnlyDictionary<string, object>? SelectedFilters { get; init; }

	[JsonProperty("sort", Required = Required.Default)]
	public string Sort { get; init; } = "default";
}
