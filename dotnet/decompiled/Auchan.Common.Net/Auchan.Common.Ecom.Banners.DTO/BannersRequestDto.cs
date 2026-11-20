using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Banners.DTO;

internal sealed class BannersRequestDto
{
	public sealed class FilterDto
	{
		[JsonProperty("region_id")]
		public required long RegionId { get; init; }

		[JsonProperty("merchant_id")]
		public required int MerchantId { get; init; }
	}

	[JsonProperty("filter")]
	public required FilterDto Filter { get; init; }
}
