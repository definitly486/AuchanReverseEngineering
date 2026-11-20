using Auchan.Common.Profile.Orders.Models;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class Order : IOrderModel
{
	[JsonProperty("id")]
	public long Id { get; init; }

	[JsonProperty("number")]
	public required string Number { get; init; }

	[JsonProperty("is_payed")]
	public bool IsPayed { get; init; }

	[JsonProperty("is_adult")]
	public bool IsAdult { get; init; }

	[JsonProperty("success_payment_status")]
	public string? SuccessPaymentStatus { get; init; }

	[JsonProperty("promo_code")]
	public string? Promocode { get; init; }

	[JsonProperty("delivery_price")]
	public decimal? DeliveryPrice { get; init; }

	[JsonProperty("picking_price")]
	public int PickingPrice { get; init; }

	[JsonProperty("addition_available")]
	public bool AdditionAvailable { get; init; }

	bool IOrderModel.IsCanAddGoodsToOrder => AdditionAvailable;
}
