using Auchan.Common.Ecom.Address.Models;

namespace Auchan.Common.Ecom.DTO;

public static class PickupShopMapper
{
	public static SavedStore ToModel(this PickupShopDto dto)
	{
		return new SavedStore
		{
			Id = (dto.Id ?? (-1)),
			IsLastSaved = dto.IsLastSaved,
			MerchantId = dto.MerchantId,
			RegionId = dto.RegionId,
			Name = dto.Name,
			Address = dto.Address,
			Latitude = dto.Latitude,
			Longitude = dto.Longitude
		};
	}
}
