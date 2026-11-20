using System;
using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.Replacements;

namespace Auchan.Common.Ecom.Address.Models;

public class Store
{
	public sealed class DeliveryTariff
	{
		public required decimal DeliveryPrice { get; init; }

		public required decimal BasketCost { get; init; }
	}

	public required string DeliveryStartTime { get; init; }

	public required string DeliveryEndTime { get; init; }

	public required bool HasDeliveryStartAndEnd { get; init; }

	public bool HasDeliveryWithTimePeriod
	{
		get
		{
			if (HasDelivery)
			{
				return HasDeliveryStartAndEnd;
			}
			return false;
		}
	}

	public required IReadOnlyList<DeliveryTariff> StandardDeliveryTariffs { get; init; }

	public required DateTime ExpressEndsAt { get; init; }

	public required DateTime ExpressStartAt { get; init; }

	public required int ExpressWeightMax { get; init; }

	public required decimal ExpressDeliveryStandardWeight { get; init; }

	public required int ExpressDeliveryTime { get; init; }

	public required bool HasExpressDelivery { get; init; }

	public required bool HasExpressDeliveryStartAndEnd { get; init; }

	public required string ExpressDeliveryStartTime { get; init; }

	public required string ExpressDeliveryEndTime { get; init; }

	public bool HasExpressDeliveryWithTimePeriod
	{
		get
		{
			if (HasExpressDelivery)
			{
				return HasExpressDeliveryStartAndEnd;
			}
			return false;
		}
	}

	public required IReadOnlyList<DeliveryTariff> ExpressDeliveryTariffs { get; init; }

	public required int Id { get; init; }

	public required string Name { get; init; }

	public required string Address { get; init; }

	public required string WorkingHours { get; init; }

	public required bool HasDelivery { get; init; }

	public required bool HasDeliveryToDoor { get; init; }

	public required bool HasStorePickUp { get; init; }

	public required bool HasCarPickup { get; init; }

	public required bool HasStoreOnlinePayment { get; init; }

	public required bool HasStoreOfflinePayment { get; init; }

	public required bool HasStorePickupPoint { get; init; }

	public required City City { get; init; }

	public required bool IsDefaultInCity { get; init; }

	public required int MinCostForPickup { get; init; }

	public required int MinCostForCarPickup { get; init; }

	public required int MinCostAdultForPickup { get; init; }

	public required int MinCostAdultForCarPickup { get; init; }

	public required int MaxDeliveryWeightKg { get; init; }

	public required int MaxPickupWeightKg { get; init; }

	public required int MaxCarPickupWeightKg { get; init; }

	public required ReplacementsCollection Replacements { get; init; }

	public required double? DistanceFromUserLocation { get; init; }

	public required decimal DeliveryStandardWeight { get; init; }

	public required decimal StandardOverweightPricePerKilo { get; init; }

	public required decimal ExpressOverweightPricePerKilo { get; init; }

	public decimal MinCostForFreeDelivery => (from i in GetTariffsForDeliveryType(ReceivingMethod.Delivery)
		where i.DeliveryPrice == 0m
		select i).FirstOrDefault()?.BasketCost ?? 0m;

	public decimal MinCostForExpressDelivery => GetTariffsForDeliveryType(ReceivingMethod.ExpressDelivery).MinBy((DeliveryTariff i) => i.BasketCost)?.BasketCost ?? 0m;

	public decimal MinCostForFreeExpressDelivery => (from i in GetTariffsForDeliveryType(ReceivingMethod.ExpressDelivery)
		where i.DeliveryPrice == 0m
		select i).FirstOrDefault()?.BasketCost ?? 0m;

	public string? DistanceFromUserLocationText
	{
		get
		{
			if (!DistanceFromUserLocation.HasValue)
			{
				return null;
			}
			return $"{DistanceFromUserLocation.Value:F1} км";
		}
	}

	public decimal GetStandardWeightForDeliveryType(ReceivingMethod receivingMethod)
	{
		return receivingMethod switch
		{
			ReceivingMethod.Delivery => DeliveryStandardWeight, 
			ReceivingMethod.ExpressDelivery => ExpressDeliveryStandardWeight, 
			_ => 0m, 
		};
	}

	public decimal GetOverweightPricePerKiloForDeilveryType(ReceivingMethod receivingMethod)
	{
		return receivingMethod switch
		{
			ReceivingMethod.Delivery => StandardOverweightPricePerKilo, 
			ReceivingMethod.ExpressDelivery => ExpressOverweightPricePerKilo, 
			_ => 0m, 
		};
	}

	public IReadOnlyList<DeliveryTariff> GetTariffsForDeliveryType(ReceivingMethod receivingMethod)
	{
		return receivingMethod switch
		{
			ReceivingMethod.Delivery => StandardDeliveryTariffs, 
			ReceivingMethod.ExpressDelivery => ExpressDeliveryTariffs, 
			_ => Array.Empty<DeliveryTariff>(), 
		};
	}

	public DeliveryTariff? GetTariffForDeliveryByOrderSize(ReceivingMethod receivingMethod, decimal orderPrice)
	{
		return (from t in GetTariffsForDeliveryType(receivingMethod).Reverse()
			where t.BasketCost < orderPrice
			select t).FirstOrDefault();
	}

	public decimal GetMinCost(ReceivingMethod deliveryMethod, bool isAdultInCart)
	{
		switch (deliveryMethod)
		{
		case ReceivingMethod.Delivery:
		case ReceivingMethod.ExpressDelivery:
			return GetTariffsForDeliveryType(deliveryMethod).MinBy((DeliveryTariff i) => i.BasketCost)?.BasketCost ?? 0m;
		case ReceivingMethod.Pickup:
			return isAdultInCart ? MinCostAdultForPickup : MinCostForPickup;
		case ReceivingMethod.CarPickup:
			return isAdultInCart ? MinCostAdultForCarPickup : MinCostForCarPickup;
		default:
			return Math.Max(GetMinCost(ReceivingMethod.Delivery, isAdultInCart), Math.Max(MinCostForPickup, MinCostForCarPickup));
		}
	}

	public override int GetHashCode()
	{
		return Id.GetHashCode();
	}

	public override bool Equals(object? obj)
	{
		if (!(obj is Store store))
		{
			return false;
		}
		return store.Id == Id;
	}
}
