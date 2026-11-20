using System;
using Auchan.Common.Addresses;

namespace Auchan.Common.Ecom.Address.Models;

public sealed record SavedAddress
{
	public long Id { get; init; }

	public bool IsLastSaved { get; init; }

	public long? RegionId { get; init; }

	public string AddressLine { get; init; } = "";

	public string Name { get; init; } = "";

	public string Comment { get; init; } = "";

	public string Flat { get; init; } = "";

	public string Floor { get; init; } = "";

	public string Porch { get; init; } = "";

	public string Intercom { get; init; } = "";

	public Coordinate? Coordinate { get; init; }

	public bool DeliveryAvailable { get; set; }

	public bool HasNameAndAddress
	{
		get
		{
			if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(AddressLine))
			{
				return !AddressLine.Equals(Name, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}
	}

	public DeliveryAddress ToDeliveryAddress()
	{
		return new DeliveryAddress
		{
			AddressLine = AddressLine,
			House = null,
			Coordinate = Coordinate,
			CountryCode = "RU",
			PostIndex = null,
			Region = "",
			RegionGuid = Guid.Empty,
			RegionId = RegionId,
			Area = null,
			AreaGuid = null,
			City = null,
			CityGuid = null,
			Block = null,
			Street = null,
			HouseFiasId = null,
			GeoAccuracy = null,
			FiasLevel = null,
			SettlementWithType = null,
			Uri = null
		};
	}
}
