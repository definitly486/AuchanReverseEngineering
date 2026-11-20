using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class Summary
{
	public sealed class MarkingInfoDto
	{
		[JsonProperty("marking_count")]
		public required int Count { get; init; }

		[JsonProperty("limit")]
		public required int Limit { get; init; }

		[JsonProperty("excess")]
		public required int Excess { get; init; }

		[JsonProperty("limit_exceeded")]
		public required bool LimitExcess { get; init; }
	}

	[JsonProperty("sum", Required = Required.Always)]
	public required Money Sum { get; init; }

	[JsonProperty("bonusGet")]
	public required int BonusGet { get; init; }

	[JsonProperty("stamp_discount")]
	public required bool StampDiscount { get; init; }

	[JsonProperty("total", Required = Required.Always)]
	public required Money Total { get; init; }

	[JsonProperty("adultSum")]
	public required MoneyWithQuantity? AdultSum { get; init; }

	[JsonProperty("nonAdultSum")]
	public required MoneyWithQuantity? NonAdultSum { get; init; }

	[JsonProperty("discounts", Required = Required.Always)]
	public required IReadOnlyList<DiscountDto> Discounts { get; init; }

	[JsonProperty("totalWeight", Required = Required.Always)]
	public required decimal TotalWeight { get; init; }

	[JsonProperty("price")]
	public required decimal DeliveryTotalPrice { get; init; }

	[JsonProperty("delivery_price")]
	public required decimal DeliveryPrice { get; init; }

	[JsonProperty("delivery_over_price")]
	public required decimal DeliveryOverPrice { get; init; }

	[JsonProperty("delivery_step")]
	public required decimal DeliveryStep { get; init; }

	[JsonProperty("delivery_step_price")]
	public required decimal DeliveryStepPrice { get; init; }

	[JsonProperty("picking_price")]
	public required int PickingPrice { get; init; }

	[JsonProperty("total_discount")]
	public required decimal TotalDiscount { get; init; }

	[JsonProperty("marking_info")]
	public required MarkingInfoDto? MarkingInfo { get; init; }
}
