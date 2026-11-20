namespace Auchan.Common.StoreReview;

public class CustomerFlags
{
	public int Id { get; set; }

	public int CustomerId { get; set; }

	public bool IsFirstPurchaseApp { get; set; }

	public bool IsRatingPopupNeeded { get; set; }
}
