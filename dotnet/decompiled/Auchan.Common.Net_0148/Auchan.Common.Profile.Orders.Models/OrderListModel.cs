using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Profile.Orders.Enums;

namespace Auchan.Common.Profile.Orders.Models;

public sealed record OrderListModel : IListOrderModel, IOrderModel
{
	public long Id { get; init; }

	public required string Number { get; init; }

	public DateTime CreatedAt { get; init; }

	public DateTimeOffset DeliveryDate { get; init; }

	public required string DeliveryAddress { get; init; }

	public required bool IsAdult { get; init; }

	public decimal Price { get; init; }

	public decimal DeliveryPrice { get; init; }

	public CustomerStatus Status { get; init; }

	public bool IsDelayed { get; init; }

	public bool AwaitingPayment { get; init; }

	public string PaymentUrl { get; init; } = string.Empty;

	public DeliveryMethod DeliveryMethod { get; init; }

	public int Qty { get; init; }

	public bool HasChanges => Products.Any((ProductModel product) => product.HasChanges);

	public required IReadOnlyList<ProductModel> Products { get; init; }

	public required string StoreName { get; init; }

	public required IReadOnlyList<string> PickupPointImageUrls { get; init; }

	public bool? CollectOrder { get; init; }

	public string? StoreAddress { get; init; }

	public string? PickupPointDescription { get; init; }

	public required string DeliveryTime { get; init; }

	public required string DeliveryToTime { get; init; }

	public PaymentMethod PaymentMethod { get; init; }

	public required ShopInfoModel Shop { get; init; }

	public required bool IsCanAddGoodsToOrder { get; init; }

	public required string? CourierNumber { get; init; }

	public string DateTimeText
	{
		get
		{
			string text = $"{DeliveryDate:M} {DeliveryDate:yyyy}";
			if (!string.IsNullOrWhiteSpace(DeliveryToTime))
			{
				return text + ", " + DeliveryToTime;
			}
			return text;
		}
	}

	bool IListOrderModel.IsValid => true;

	[CompilerGenerated]
	[SetsRequiredMembers]
	private OrderListModel(OrderListModel original)
	{
		Id = original.Id;
		Number = original.Number;
		CreatedAt = original.CreatedAt;
		DeliveryDate = original.DeliveryDate;
		DeliveryAddress = original.DeliveryAddress;
		IsAdult = original.IsAdult;
		Price = original.Price;
		DeliveryPrice = original.DeliveryPrice;
		Status = original.Status;
		IsDelayed = original.IsDelayed;
		AwaitingPayment = original.AwaitingPayment;
		PaymentUrl = original.PaymentUrl;
		DeliveryMethod = original.DeliveryMethod;
		Qty = original.Qty;
		Products = original.Products;
		StoreName = original.StoreName;
		PickupPointImageUrls = original.PickupPointImageUrls;
		CollectOrder = original.CollectOrder;
		StoreAddress = original.StoreAddress;
		PickupPointDescription = original.PickupPointDescription;
		DeliveryTime = original.DeliveryTime;
		DeliveryToTime = original.DeliveryToTime;
		PaymentMethod = original.PaymentMethod;
		Shop = original.Shop;
		IsCanAddGoodsToOrder = original.IsCanAddGoodsToOrder;
		CourierNumber = original.CourierNumber;
	}

	public OrderListModel()
	{
	}
}
