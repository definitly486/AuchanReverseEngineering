using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class PickupShopDto
{
	[JsonProperty("id")]
	public int? Id { get; init; }

	[JsonProperty("applied")]
	public bool IsLastSaved { get; init; }

	[JsonProperty("merchant_id")]
	public int MerchantId { get; init; }

	[JsonProperty("region_id")]
	public int RegionId { get; init; }

	[JsonProperty("name")]
	public required string Name { get; init; }

	[JsonProperty("address_string")]
	public required string Address { get; init; }

	[JsonProperty("geo_lat")]
	public string? Latitude { get; init; }

	[JsonProperty("geo_lon")]
	public string? Longitude { get; init; }
}
