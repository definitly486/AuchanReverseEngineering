using System;
using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.Addresses.DTO;
using Auchan.Common.Ecom.DTO;

namespace Auchan.Common.Addresses;

public static class SuggestionMapper
{
	public static DeliveryAddress ToAddress(this SuggestionDto dto)
	{
		return new DeliveryAddress
		{
			AddressLine = dto.AddressLine,
			House = dto.Address.House,
			Coordinate = ExtractCoordinates(dto),
			CountryCode = "RU",
			PostIndex = null,
			Region = dto.Address.Region,
			RegionGuid = dto.Address.RegionFiasId,
			RegionId = null,
			Area = dto.Address.Area,
			AreaGuid = dto.Address.AreaFiasId.ToString(),
			City = dto.Address.City,
			CityGuid = dto.Address.CityFiasId,
			Block = dto.Address.Block,
			Street = dto.Address.Street,
			HouseFiasId = dto.Address.HouseFiasId,
			GeoAccuracy = dto.Address.GeoAccuracy,
			FiasLevel = dto.Address.FiasLevel,
			SettlementWithType = dto.Address.SettlementWithType,
			Uri = null
		};
	}

	private static Coordinate? ExtractCoordinates(SuggestionDto dto)
	{
		float? geoLat = dto.Address.GeoLat;
		float? geoLon = dto.Address.GeoLon;
		if (geoLat.HasValue && geoLon.HasValue)
		{
			return new Coordinate(geoLat.Value, geoLon.Value);
		}
		return null;
	}

	public static SuggestionResult? ToModel(this SuggestGeocodeResponseDto dto)
	{
		if (dto.Data == null)
		{
			return null;
		}
		return new SuggestionResult
		{
			IsNeedHouse = dto.Data.IsNeedHouse,
			IsSuccess = dto.Data.Success,
			Suggestions = (from i in dto.Data.Suggests ?? Array.Empty<SuggestGeocodeResponseDto.DataDto.Suggest>()
				select new Suggestion
				{
					Address = i.Address?.ToAddress(i.Uri),
					IsFull = i.IsFull,
					RegionId = i.RegionId
				} into s
				where s.Address != null
				select s).ToImmutableList()
		};
	}
}
