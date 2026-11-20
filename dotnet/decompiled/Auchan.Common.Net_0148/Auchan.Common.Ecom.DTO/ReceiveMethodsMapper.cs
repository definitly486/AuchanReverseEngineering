using System;
using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Addresses;
using Auchan.Common.Ecom.Address.Models;

namespace Auchan.Common.Ecom.DTO;

public static class ReceiveMethodsMapper
{
	public static SavedReceiveMethods ToModel(this ReceiveMethodsResponseDto.Content dto)
	{
		return new SavedReceiveMethods
		{
			CurrentRegionId = dto.CurrentRegionId,
			CurrentDeliveryMethod = dto.CurrentDeliveryMethod,
			CurrentAddress = dto.CurrentAddress?.ToAddress(),
			CurrentMerchantId = dto.CurrentMerchantId,
			CurrentPickupShop = dto.CurrentPickupShop?.ToModel(),
			CurrentCarPickupShop = dto.CurrentCarPickupShop?.ToModel(),
			Addresses = ((from i in dto.Addresses ?? Array.Empty<SavedAddressDto>()
				let j = i.ToAddress()
				where j != null
				select j).ToList() ?? new List<SavedAddress>()),
			PickupShops = (dto.PickupShops.Select((PickupShopDto i) => i.ToModel()).ToList() ?? new List<SavedStore>()),
			CarPickupShops = (dto.CarPickupShops.Select((PickupShopDto i) => i.ToModel()).ToList() ?? new List<SavedStore>())
		};
	}

	public static SavedAddress ToAddress(this SavedAddressDto address)
	{
		return new SavedAddress
		{
			Id = address.Id,
			IsLastSaved = address.IsLastSaved,
			RegionId = address.RegionId,
			AddressLine = (address.Address ?? ""),
			Coordinate = Coordinate.Parse(address.Latitude, address.Longitude),
			Name = (address.Name ?? ""),
			Comment = (address.Comment ?? ""),
			Porch = (address.Porch ?? ""),
			Floor = (address.Floor ?? ""),
			Flat = (address.Flat ?? ""),
			Intercom = (address.Intercom ?? "")
		};
	}
}
