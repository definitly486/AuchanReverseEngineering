using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class ProductResultDto
{
	[JsonProperty("items")]
	public List<ProductDto> Items { get; set; }

	[JsonProperty("range")]
	public int Range { get; set; }
}
