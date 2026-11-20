using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

public sealed record DeliveryAddressDto
{
	[JsonProperty("address_string")]
	public string? Address { get; init; }

	[JsonProperty("country_code")]
	public string? CountryCode { get; init; }

	[JsonProperty("post_index")]
	public string? PostIndex { get; init; }

	[JsonProperty("region")]
	public string? Region { get; init; }

	[JsonProperty("region_guid")]
	public string? RegionGuid { get; init; }

	[JsonProperty("area")]
	public string? Area { get; init; }

	[JsonProperty("area_guid")]
	public string? AreaGuid { get; init; }

	[JsonProperty("city")]
	public string? City { get; init; }

	[JsonProperty("city_guid")]
	public string? CityGuid { get; init; }

	[JsonProperty("street")]
	public string? Street { get; init; }

	[JsonProperty("house")]
	public string? House { get; init; }

	[JsonProperty("block")]
	public string? Block { get; init; }

	[JsonProperty("flat")]
	public string? Flat { get; init; }

	[JsonProperty("floor")]
	public string? Floor { get; init; }

	[JsonProperty("porch")]
	public string? Porch { get; init; }

	[JsonProperty("intercom")]
	public string? Intercom { get; init; }

	[JsonProperty("comment")]
	public string? Comment { get; init; }

	[JsonProperty("geo_lat", Required = Required.Default)]
	public double? GeoLat { get; init; }

	[JsonProperty("geo_lon", Required = Required.Default)]
	public double? GeoLon { get; init; }
}
