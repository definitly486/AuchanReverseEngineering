using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Profile.Orders.Enums;

namespace Auchan.Common.Profile.Orders.Models;

public sealed record OrderToAdditionModel
{
	public required long Id { get; init; }

	public required string Number { get; init; }

	public required decimal Price { get; init; }

	public required decimal DeliveryPrice { get; init; }

	public required decimal PickingPrice { get; init; }

	public required DateTimeOffset DeliveryDate { get; init; }

	public required string DeliveryTime { get; init; }

	public required string DeliveryPlace { get; init; }

	public required DeliveryMethod DeliveryMethod { get; init; }

	public required string ShopName { get; init; }

	public required DateTimeOffset EditableTill { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private OrderToAdditionModel(OrderToAdditionModel original)
	{
		Id = original.Id;
		Number = original.Number;
		Price = original.Price;
		DeliveryPrice = original.DeliveryPrice;
		PickingPrice = original.PickingPrice;
		DeliveryDate = original.DeliveryDate;
		DeliveryTime = original.DeliveryTime;
		DeliveryPlace = original.DeliveryPlace;
		DeliveryMethod = original.DeliveryMethod;
		ShopName = original.ShopName;
		EditableTill = original.EditableTill;
	}

	public OrderToAdditionModel()
	{
	}
}
