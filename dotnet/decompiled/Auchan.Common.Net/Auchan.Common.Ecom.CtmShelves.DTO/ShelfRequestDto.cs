using Newtonsoft.Json;

namespace Auchan.Common.Ecom.CtmShelves.DTO;

internal sealed class ShelfRequestDto
{
	[JsonProperty("page_url")]
	public required string PageUrl { get; init; }

	[JsonProperty("merchant_id", NullValueHandling = NullValueHandling.Ignore)]
	public int? MerchantId { get; init; }
}
