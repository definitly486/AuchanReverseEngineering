using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class ProductFilterResponseDto
{
	[JsonProperty("filters")]
	public IReadOnlyList<ProductFilterDto>? Filters { get; set; }

	[JsonProperty("requiredRedirectFor")]
	public IReadOnlyList<RequestRedirectDto>? RequiredRedirectFor { get; set; }

	[JsonProperty("product_counter")]
	public int ProductCounter { get; set; }

	[JsonProperty("selectedFilters")]
	public IReadOnlyDictionary<string, object>? SelectedFilters { get; set; }
}
