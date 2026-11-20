using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class UserAddress
{
	[JsonProperty("address_string")]
	[JsonPropertyName("address_string")]
	public string? AddressString { get; set; }

	[JsonProperty("country_code")]
	[JsonPropertyName("country_code")]
	public string? CountryCode { get; set; }

	[JsonProperty("post_index")]
	[JsonPropertyName("post_index")]
	public string? PostIndex { get; set; }

	[JsonProperty("region")]
	[JsonPropertyName("region")]
	public string? Region { get; set; }

	[JsonProperty("region_guid")]
	[JsonPropertyName("region_guid")]
	public string RegionGuid { get; set; } = "";

	[JsonProperty("region_id")]
	[JsonPropertyName("region_id")]
	public long? RegionId { get; set; }

	[JsonProperty("area")]
	[JsonPropertyName("area")]
	public string? Area { get; set; }

	[JsonProperty("area_guid")]
	[JsonPropertyName("area_guid")]
	public string? AreaGuid { get; set; }

	[JsonProperty("city")]
	[JsonPropertyName("city")]
	public string? City { get; set; }

	[JsonProperty("city_guid")]
	[JsonPropertyName("city_guid")]
	public Guid? CityGuid { get; set; }

	[JsonProperty("street")]
	[JsonPropertyName("street")]
	public string? Street { get; set; }

	[JsonProperty("house")]
	[JsonPropertyName("house")]
	public string? House { get; set; }

	[JsonProperty("block")]
	[JsonPropertyName("block")]
	public string? Block { get; set; }

	[JsonProperty("flat")]
	[JsonPropertyName("flat")]
	public string? Flat { get; set; }

	[JsonProperty("floor")]
	[JsonPropertyName("floor")]
	public string? Floor { get; set; }

	[JsonProperty("porch")]
	[JsonPropertyName("porch")]
	public string? Porch { get; set; }

	[JsonProperty("intercom")]
	[JsonPropertyName("intercom")]
	public string? Intercom { get; set; }

	[JsonProperty("comment")]
	[JsonPropertyName("comment")]
	public string? Comment { get; set; }

	[JsonProperty("geo_lat")]
	[JsonPropertyName("geo_lat")]
	public string? GeoLat { get; set; }

	[JsonProperty("geo_lon")]
	[JsonPropertyName("geo_lon")]
	public string? GeoLon { get; set; }

	[JsonProperty("default")]
	[JsonPropertyName("default")]
	public bool? IsDefault { get; set; }

	[JsonProperty("settlement_with_type")]
	[JsonPropertyName("settlement_with_type")]
	public string? SettlementWithType { get; set; }
}
