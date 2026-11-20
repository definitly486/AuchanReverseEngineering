using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record DeliveryTariff
{
	public required decimal? DeliveryPrice { get; init; }

	public required decimal? BasketPrice { get; init; }

	public required decimal? Overprice { get; init; }

	public required decimal? StandardWeight { get; init; }

	public required decimal? MaxWeight { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private DeliveryTariff(DeliveryTariff original)
	{
		DeliveryPrice = original.DeliveryPrice;
		BasketPrice = original.BasketPrice;
		Overprice = original.Overprice;
		StandardWeight = original.StandardWeight;
		MaxWeight = original.MaxWeight;
	}

	public DeliveryTariff()
	{
	}
}
