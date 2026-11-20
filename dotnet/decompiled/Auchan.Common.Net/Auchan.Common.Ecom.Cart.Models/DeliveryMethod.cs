using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record DeliveryMethod
{
	public required long Id { get; init; }

	public required CheckoutReceiveMethod Method { get; init; }

	public required bool ToDoor { get; init; }

	public required Address? Address { get; init; }

	public required CheckoutShop? Shop { get; init; }

	public required CheckoutCar? Car { get; init; }

	public required IReadOnlyList<CheckoutDate> Dates { get; init; }

	public required string? DeliveryTimeHint { get; init; }

	public required decimal? MinSlotPrice { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private DeliveryMethod(DeliveryMethod original)
	{
		Id = original.Id;
		Method = original.Method;
		ToDoor = original.ToDoor;
		Address = original.Address;
		Shop = original.Shop;
		Car = original.Car;
		Dates = original.Dates;
		DeliveryTimeHint = original.DeliveryTimeHint;
		MinSlotPrice = original.MinSlotPrice;
	}

	public DeliveryMethod()
	{
	}
}
