using Newtonsoft.Json;

namespace Auchan.Common.StoreReview;

public class CustomerFlagsDataDto
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("customer_id")]
	public int CustomerId { get; set; }

	[JsonProperty("is_first_purchase_app")]
	public bool IsFirstPurchaseApp { get; set; }

	[JsonProperty("is_rating_popup_needed")]
	public bool IsRatingPopupNeeded { get; set; }
}
