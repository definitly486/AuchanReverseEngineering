using System;
using System.Collections.Generic;
using Auchan.Common.Profile.Orders.Enums;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class Delivery
{
	[JsonProperty("method_id")]
	public DeliveryMethod MethodId { get; init; }

	[JsonProperty("delivery_at")]
	public DateTimeOffset? DeliveryAt { get; init; }

	[JsonProperty("delivery_time")]
	public required TimeSlot DeliveryTime { get; init; }

	[JsonProperty("delivery_address")]
	public string? DeliveryAddress { get; init; }

	[JsonProperty("delivery_comment")]
	public string? DeliveryComment { get; init; }

	[JsonProperty("receiver_email")]
	public string? ReceiverEmail { get; init; }

	[JsonProperty("receiver_phone")]
	public string? ReceiverPhone { get; init; }

	[JsonProperty("receiver_name")]
	public required string ReceiverName { get; init; }

	[JsonProperty("products")]
	public required IReadOnlyList<ProductShort> Products { get; init; }

	[JsonProperty("total_products_weight")]
	public double TotalWeight { get; init; }
}
