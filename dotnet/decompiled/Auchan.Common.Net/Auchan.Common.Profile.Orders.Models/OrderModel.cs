using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Profile.Orders.Enums;

namespace Auchan.Common.Profile.Orders.Models;

public sealed record OrderModel : IListOrderModel, IOrderModel
{
	public required long Id { get; init; }

	public required string Number { get; init; }

	public required CustomerStatus Status { get; init; }

	public bool IsDelayed { get; init; }

	public required bool IsAdult { get; init; }

	public required decimal Price { get; init; }

	public required decimal DeliveryPrice { get; init; }

	public required decimal? ProductsOnlyPrice { get; init; }

	public required DateTime CreatedAt { get; init; }

	public required ShopInfoModel Shop { get; init; }

	public required DeliveryInfoModel Delivery { get; init; }

	public required int UsedPoints { get; init; }

	public int UsedStamps { get; init; }

	public required PaymentMethod PaymentMethod { get; init; }

	public required bool AwaitingPayment { get; init; }

	public required string PaymentUrl { get; init; }

	public int PickingPrice { get; init; }

	public decimal? SurgeAmount { get; init; }

	public SelfPickupPointInfoModel? SelfPickupPointInfo { get; init; }

	public required bool IsCancellationPossible { get; init; }

	public required bool IsCanAddGoodsToOrder { get; init; }

	DeliveryMethod IListOrderModel.DeliveryMethod => Delivery?.DeliveryMethod ?? DeliveryMethod.Unknown;

	bool IListOrderModel.IsValid => Delivery != null;

	DateTimeOffset IListOrderModel.DeliveryDate => Delivery.DeliveryDate;

	string IListOrderModel.DeliveryTime => Delivery.DeliveryTime;

	IReadOnlyList<ProductModel> IListOrderModel.Products => Delivery.Products;

	string IListOrderModel.DeliveryAddress => Delivery.Address;

	string? IListOrderModel.CourierNumber => Delivery.CourierNumber;

	[CompilerGenerated]
	[SetsRequiredMembers]
	private OrderModel(OrderModel original)
	{
		Id = original.Id;
		Number = original.Number;
		Status = original.Status;
		IsDelayed = original.IsDelayed;
		IsAdult = original.IsAdult;
		Price = original.Price;
		DeliveryPrice = original.DeliveryPrice;
		ProductsOnlyPrice = original.ProductsOnlyPrice;
		CreatedAt = original.CreatedAt;
		Shop = original.Shop;
		Delivery = original.Delivery;
		UsedPoints = original.UsedPoints;
		UsedStamps = original.UsedStamps;
		PaymentMethod = original.PaymentMethod;
		AwaitingPayment = original.AwaitingPayment;
		PaymentUrl = original.PaymentUrl;
		PickingPrice = original.PickingPrice;
		SurgeAmount = original.SurgeAmount;
		SelfPickupPointInfo = original.SelfPickupPointInfo;
		IsCancellationPossible = original.IsCancellationPossible;
		IsCanAddGoodsToOrder = original.IsCanAddGoodsToOrder;
	}

	public OrderModel()
	{
	}
}
