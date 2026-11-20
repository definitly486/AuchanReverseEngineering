namespace Auchan.Common.StoreReview;

public static class CustomerFlagsMapper
{
	public static CustomerFlags ToModel(this CustomerFlagsDataDto dto)
	{
		return new CustomerFlags
		{
			Id = dto.Id,
			CustomerId = dto.CustomerId,
			IsFirstPurchaseApp = dto.IsFirstPurchaseApp,
			IsRatingPopupNeeded = dto.IsRatingPopupNeeded
		};
	}
}
