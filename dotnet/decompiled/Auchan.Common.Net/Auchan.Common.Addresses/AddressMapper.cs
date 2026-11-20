using System;
using System.Globalization;
using Auchan.Common.Addresses.DTO;
using Auchan.Common.Ecom.DTO;

namespace Auchan.Common.Addresses;

public static class AddressMapper
{
	public static UserAddress ToUserAddress(this DeliveryAddress deliveryAddress)
	{
		return new UserAddress
		{
			AddressString = deliveryAddress.AddressLine,
			House = deliveryAddress.House,
			Area = deliveryAddress.Area,
			AreaGuid = deliveryAddress.AreaGuid,
			Block = deliveryAddress.Block,
			City = deliveryAddress.City,
			CityGuid = (deliveryAddress.CityGuid ?? Guid.Empty),
			CountryCode = deliveryAddress.CountryCode,
			GeoLat = (deliveryAddress.Coordinate?.Lat.ToString(CultureInfo.InvariantCulture) ?? ""),
			GeoLon = (deliveryAddress.Coordinate?.Lon.ToString(CultureInfo.InvariantCulture) ?? ""),
			PostIndex = deliveryAddress.PostIndex,
			Region = deliveryAddress.Region,
			RegionGuid = deliveryAddress.RegionGuid.ToString(),
			Street = deliveryAddress.Street,
			Flat = deliveryAddress.Flat,
			Floor = deliveryAddress.Floor,
			Porch = deliveryAddress.Porch,
			Intercom = deliveryAddress.Intercom,
			Comment = deliveryAddress.Comment,
			SettlementWithType = deliveryAddress.SettlementWithType
		};
	}

	public static DeliveryAddress? ToAddress(this UserAddress? address, string? uri)
	{
		if (address == null || address.AddressString == null)
		{
			return null;
		}
		if (!Guid.TryParse(address.RegionGuid, out var result))
		{
			result = default(Guid);
		}
		return new DeliveryAddress
		{
			AddressLine = address.AddressString,
			House = address.House,
			Coordinate = Coordinate.Parse(address.GeoLat, address.GeoLon),
			CountryCode = (address.CountryCode ?? "RU"),
			PostIndex = address.PostIndex,
			Region = (address.Region ?? ""),
			RegionGuid = result,
			RegionId = address.RegionId,
			Area = address.Area,
			AreaGuid = address.AreaGuid,
			City = address.City,
			CityGuid = address.CityGuid,
			Block = address.Block,
			Street = address.Street,
			HouseFiasId = null,
			GeoAccuracy = GeoAccuracy.Direct,
			FiasLevel = FiasLevel.Street,
			SettlementWithType = address.SettlementWithType,
			Uri = uri
		};
	}
}
