using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class ProductSortSelectionDto
{
	[JsonProperty("order_field")]
	public string Field { get; set; } = string.Empty;

	[JsonProperty("order_direction")]
	public string Direction { get; set; } = string.Empty;
}
