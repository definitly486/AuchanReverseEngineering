using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Addresses.DTO;

namespace Auchan.Common.Addresses;

public sealed record DeliveryAddress
{
	public required string AddressLine { get; init; }

	public required string? House { get; set; }

	public required Coordinate? Coordinate { get; init; }

	public required string CountryCode { get; init; }

	public required string? PostIndex { get; init; }

	public required string Region { get; init; }

	public required Guid RegionGuid { get; init; }

	public required long? RegionId { get; init; }

	public required string? Area { get; init; }

	public required string? AreaGuid { get; init; }

	public required string? City { get; init; }

	public required Guid? CityGuid { get; init; }

	public required string? Block { get; init; }

	public required string? Street { get; init; }

	public required string? SettlementWithType { get; init; }

	public required Guid? HouseFiasId { get; init; }

	public required GeoAccuracy? GeoAccuracy { get; init; }

	public required FiasLevel? FiasLevel { get; init; }

	public string Flat { get; set; } = "";

	public string Floor { get; set; } = "";

	public string Porch { get; set; } = "";

	public string Comment { get; set; } = "";

	public string Intercom { get; set; } = "";

	public required string? Uri { get; init; }

	public bool IsValid
	{
		get
		{
			if (House != null)
			{
				if (!HouseFiasId.HasValue)
				{
					if (!HouseFiasId.HasValue)
					{
						if (GeoAccuracy != Auchan.Common.Addresses.DTO.GeoAccuracy.Direct && GeoAccuracy != Auchan.Common.Addresses.DTO.GeoAccuracy.House)
						{
							return !GeoAccuracy.HasValue;
						}
						return true;
					}
					return false;
				}
				return true;
			}
			return false;
		}
	}

	[CompilerGenerated]
	[SetsRequiredMembers]
	private DeliveryAddress(DeliveryAddress original)
	{
		AddressLine = original.AddressLine;
		House = original.House;
		Coordinate = original.Coordinate;
		CountryCode = original.CountryCode;
		PostIndex = original.PostIndex;
		Region = original.Region;
		RegionGuid = original.RegionGuid;
		RegionId = original.RegionId;
		Area = original.Area;
		AreaGuid = original.AreaGuid;
		City = original.City;
		CityGuid = original.CityGuid;
		Block = original.Block;
		Street = original.Street;
		SettlementWithType = original.SettlementWithType;
		HouseFiasId = original.HouseFiasId;
		GeoAccuracy = original.GeoAccuracy;
		FiasLevel = original.FiasLevel;
		Flat = original.Flat;
		Floor = original.Floor;
		Porch = original.Porch;
		Comment = original.Comment;
		Intercom = original.Intercom;
		Uri = original.Uri;
	}

	public DeliveryAddress()
	{
	}
}
