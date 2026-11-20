using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class ProductSortTypesDto
{
	[JsonProperty("items")]
	public IReadOnlyList<ProductSortTypeDto>? Items { get; init; }
}
