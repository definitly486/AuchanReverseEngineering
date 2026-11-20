using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record Summary
{
	public required decimal TotalWeight { get; init; }

	public required decimal ItemsCount { get; init; }

	public required decimal BasketCost { get; init; }

	public required decimal? AdultBasketCost { get; init; }

	public required decimal NonAdultBasketCost { get; init; }

	public required decimal BasketPrice { get; init; }

	public required decimal TotalDeliveryPrice { get; init; }

	public required DeliveryTariff? DeliveryTariff { get; init; }

	public required decimal TotalPrice { get; init; }

	public required decimal? PromocodeDiscount { get; init; }

	public required decimal? UsedPoints { get; init; }

	public required decimal? Economy { get; init; }

	public required decimal? UsedStamps { get; init; }

	public required decimal? PickingPrice { get; init; }

	public required decimal? SurgeAmount { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private Summary(Summary original)
	{
		TotalWeight = original.TotalWeight;
		ItemsCount = original.ItemsCount;
		BasketCost = original.BasketCost;
		AdultBasketCost = original.AdultBasketCost;
		NonAdultBasketCost = original.NonAdultBasketCost;
		BasketPrice = original.BasketPrice;
		TotalDeliveryPrice = original.TotalDeliveryPrice;
		DeliveryTariff = original.DeliveryTariff;
		TotalPrice = original.TotalPrice;
		PromocodeDiscount = original.PromocodeDiscount;
		UsedPoints = original.UsedPoints;
		Economy = original.Economy;
		UsedStamps = original.UsedStamps;
		PickingPrice = original.PickingPrice;
		SurgeAmount = original.SurgeAmount;
	}

	public Summary()
	{
	}
}
