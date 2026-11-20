using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class ProductSortTypeDto
{
	[JsonProperty("serial")]
	public int Serial { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; } = string.Empty;

	[JsonProperty("field")]
	public string Field { get; set; } = string.Empty;

	[JsonProperty("direction")]
	public string Direction { get; set; } = string.Empty;
}
