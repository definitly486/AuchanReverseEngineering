using Newtonsoft.Json;

namespace Auchan.Common.Analytics.Digenetica.DTO;

internal class CartItemDTO
{
	[JsonProperty("productId")]
	public string ProductId { get; set; }

	[JsonProperty("productName")]
	public string ProductName { get; set; }

	[JsonProperty("sku", Required = Required.AllowNull)]
	public string? SKU { get; set; }

	[JsonProperty("price")]
	public string Price { get; set; }

	[JsonProperty("salePrice")]
	public string SalePrice { get; set; }

	[JsonProperty("quantity")]
	public long Quantity { get; set; }

	[JsonProperty("subtotal")]
	public string Subtotal { get; set; }
}
