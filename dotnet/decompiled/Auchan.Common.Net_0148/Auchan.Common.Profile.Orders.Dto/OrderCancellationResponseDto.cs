using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

public sealed class OrderCancellationResponseDto
{
	[JsonProperty("order_id", Required = Required.Default)]
	public int? OrderId { get; set; }

	[JsonProperty("cancellation_reason")]
	public string CancellationReason { get; set; }

	[JsonProperty("new_status")]
	public string NewStatus { get; set; }

	[JsonProperty("refund")]
	public bool GotRefund { get; set; }
}
