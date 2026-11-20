using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CategoryWithProductDto
{
	[JsonProperty("name")]
	public string? Name { get; init; }

	[JsonProperty("parentCategoryCode")]
	public string? ParentCategoryCode { get; init; }

	[JsonProperty("parentCategoryName")]
	public string? ParentCategoryName { get; init; }

	[JsonProperty("products")]
	public IReadOnlyList<ProductSearchDto>? Products { get; init; }
}
