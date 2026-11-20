using Newtonsoft.Json;

namespace Auchan.Common.StoreReview;

public class UpdateCustomerFlagsRequestDto
{
	[JsonProperty("is_first_purchase_app", NullValueHandling = NullValueHandling.Ignore)]
	public bool? IsFirstPurchaseApp { get; set; }

	[JsonProperty("is_rating_initiated", NullValueHandling = NullValueHandling.Ignore)]
	public bool? IsRatingInitiated { get; set; }
}
