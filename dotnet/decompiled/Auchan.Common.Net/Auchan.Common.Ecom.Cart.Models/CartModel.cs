using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record CartModel
{
	public required IReadOnlyList<ProductOffer> Items { get; init; }

	public required IReadOnlyList<ProductOffer> ItemsUnavailable { get; init; }

	public required IReadOnlyList<CartDiscount> Discounts { get; init; }

	public required decimal DeliveryTotalPrice { get; init; }

	public required decimal TotalWeight { get; init; }

	public required int TotalCount { get; init; }

	public required decimal DeliveryPrice { get; init; }

	public required decimal DeliveryOverPrice { get; init; }

	public required decimal Subtotal { get; init; }

	public required decimal Total { get; init; }

	public required decimal NonAdultSumValue { get; init; }

	public required decimal AdultSumValue { get; init; }

	public required bool HasStampDiscount { get; init; }

	public required decimal NotEnoughToNextDeliveryThreshold { get; init; }

	public required decimal NextDeliveryThreshold { get; init; }

	public required int PickingPrice { get; init; }

	public required MarkingInfo MarkingInfo { get; init; }

	public required decimal TotalDiscount { get; init; }

	public static CartModel Empty { get; } = new CartModel
	{
		Items = Array.Empty<ProductOffer>(),
		ItemsUnavailable = Array.Empty<ProductOffer>(),
		Discounts = Array.Empty<CartDiscount>(),
		DeliveryTotalPrice = 0m,
		TotalWeight = 0m,
		TotalCount = 0,
		DeliveryPrice = 0m,
		DeliveryOverPrice = 0m,
		Subtotal = 0m,
		Total = 0m,
		NonAdultSumValue = 0m,
		AdultSumValue = 0m,
		HasStampDiscount = false,
		NotEnoughToNextDeliveryThreshold = 0m,
		NextDeliveryThreshold = 0m,
		PickingPrice = 0,
		MarkingInfo = Auchan.Common.Ecom.Cart.Models.MarkingInfo.Empty,
		TotalDiscount = 0m
	};

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CartModel(CartModel original)
	{
		Items = original.Items;
		ItemsUnavailable = original.ItemsUnavailable;
		Discounts = original.Discounts;
		DeliveryTotalPrice = original.DeliveryTotalPrice;
		TotalWeight = original.TotalWeight;
		TotalCount = original.TotalCount;
		DeliveryPrice = original.DeliveryPrice;
		DeliveryOverPrice = original.DeliveryOverPrice;
		Subtotal = original.Subtotal;
		Total = original.Total;
		NonAdultSumValue = original.NonAdultSumValue;
		AdultSumValue = original.AdultSumValue;
		HasStampDiscount = original.HasStampDiscount;
		NotEnoughToNextDeliveryThreshold = original.NotEnoughToNextDeliveryThreshold;
		NextDeliveryThreshold = original.NextDeliveryThreshold;
		PickingPrice = original.PickingPrice;
		MarkingInfo = original.MarkingInfo;
		TotalDiscount = original.TotalDiscount;
	}

	public CartModel()
	{
	}
}
