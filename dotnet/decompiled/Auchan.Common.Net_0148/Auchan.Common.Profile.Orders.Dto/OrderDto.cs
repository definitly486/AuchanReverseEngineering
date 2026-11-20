using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Profile.Orders.Enums;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

public sealed record OrderDto
{
	[JsonProperty("id", Required = Required.Default)]
	public int? Id { get; init; }

	[JsonProperty("number")]
	public required string Number { get; init; }

	[JsonProperty("created_at")]
	public DateTime CreatedAt { get; init; }

	[JsonProperty("price", Required = Required.Default)]
	public decimal? Price { get; init; }

	[JsonProperty("delivery_price", Required = Required.Default)]
	public decimal? DeliveryPrice { get; init; }

	[JsonProperty("used_points")]
	public int? UsedPoints { get; init; }

	[JsonProperty("used_stamps")]
	public int? UsedStamps { get; init; }

	[JsonProperty("products_price")]
	public decimal? ProductsOnlyPrice { get; init; }

	[JsonProperty("payment_status")]
	public PaymentStatus PaymentStatus { get; init; }

	[JsonProperty("awaiting_payment", Required = Required.Default)]
	public bool AwaitingPayment { get; init; }

	[JsonProperty("payment_url", Required = Required.Default)]
	public string PaymentUrl { get; init; } = string.Empty;

	[JsonProperty("status_for_customer")]
	public CustomerStatus CustomerStatus { get; init; }

	[JsonProperty("is_delayed")]
	public bool? IsDelayed { get; init; }

	[JsonProperty("isAdult")]
	public bool IsAdult { get; init; }

	[JsonProperty("shop", Required = Required.Default)]
	public required ShopDto Shop { get; init; }

	[JsonProperty("deliveries", Required = Required.Always)]
	public required IReadOnlyList<DeliveryDto> Deliveries { get; init; }

	[JsonProperty("payments")]
	public IReadOnlyList<PaymentDto> Payments { get; init; } = Array.Empty<PaymentDto>();

	[JsonProperty("inform_pvz")]
	public SelfPickupPointInfoDto? selfPickupPointInfo { get; init; }

	[JsonProperty("cancellation_possibility")]
	public bool IsCancellationPossible { get; init; }

	[JsonProperty("picking_price")]
	public int PickingPrice { get; init; }

	[JsonProperty("surge_amount")]
	public decimal? SurgeAmount { get; init; }

	[JsonProperty("addition_available")]
	public bool AdditionAvailable { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private OrderDto(OrderDto original)
	{
		Id = original.Id;
		Number = original.Number;
		CreatedAt = original.CreatedAt;
		Price = original.Price;
		DeliveryPrice = original.DeliveryPrice;
		UsedPoints = original.UsedPoints;
		UsedStamps = original.UsedStamps;
		ProductsOnlyPrice = original.ProductsOnlyPrice;
		PaymentStatus = original.PaymentStatus;
		AwaitingPayment = original.AwaitingPayment;
		PaymentUrl = original.PaymentUrl;
		CustomerStatus = original.CustomerStatus;
		IsDelayed = original.IsDelayed;
		IsAdult = original.IsAdult;
		Shop = original.Shop;
		Deliveries = original.Deliveries;
		Payments = original.Payments;
		selfPickupPointInfo = original.selfPickupPointInfo;
		IsCancellationPossible = original.IsCancellationPossible;
		PickingPrice = original.PickingPrice;
		SurgeAmount = original.SurgeAmount;
		AdditionAvailable = original.AdditionAvailable;
	}

	public OrderDto()
	{
	}
}
