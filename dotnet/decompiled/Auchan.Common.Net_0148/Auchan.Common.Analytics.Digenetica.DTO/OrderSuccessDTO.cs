using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Analytics.Digenetica.DTO;

internal class OrderSuccessDTO : BaseEventDTO
{
	[JsonProperty("orderId")]
	public string OrderId { get; set; }

	[JsonProperty("cartId")]
	public string CartId { get; set; }

	[JsonProperty("total")]
	public string Total { get; set; }

	[JsonProperty("subtotal")]
	public string Subtotal { get; set; }

	[JsonProperty("cartItems")]
	public IReadOnlyList<CartItemDTO> CartItems { get; set; }
}
