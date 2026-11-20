using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Ecom.AddressStoreSelection;

namespace Auchan.Common.Ecom.Address.Models;

public sealed record SavedReceiveMethods
{
	public required int? CurrentRegionId { get; init; }

	public required ReceivingMethod? CurrentDeliveryMethod { get; init; }

	public required int? CurrentMerchantId { get; init; }

	public SavedAddress? CurrentAddress { get; init; }

	public SavedStore? CurrentPickupShop { get; init; }

	public SavedStore? CurrentCarPickupShop { get; init; }

	public required IList<SavedAddress> Addresses { get; init; }

	public required IList<SavedStore> PickupShops { get; init; }

	public required IList<SavedStore> CarPickupShops { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private SavedReceiveMethods(SavedReceiveMethods original)
	{
		CurrentRegionId = original.CurrentRegionId;
		CurrentDeliveryMethod = original.CurrentDeliveryMethod;
		CurrentMerchantId = original.CurrentMerchantId;
		CurrentAddress = original.CurrentAddress;
		CurrentPickupShop = original.CurrentPickupShop;
		CurrentCarPickupShop = original.CurrentCarPickupShop;
		Addresses = original.Addresses;
		PickupShops = original.PickupShops;
		CarPickupShops = original.CarPickupShops;
	}

	public SavedReceiveMethods()
	{
	}
}
