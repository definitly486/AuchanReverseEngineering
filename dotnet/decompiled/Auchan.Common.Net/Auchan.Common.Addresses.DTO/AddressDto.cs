using System;
using Newtonsoft.Json;

namespace Auchan.Common.Addresses.DTO;

public class AddressDto
{
	[JsonProperty("country")]
	public string Country { get; set; }

	[JsonProperty("federal_district")]
	public string? FederalDistrict { get; set; }

	[JsonProperty("region_fias_id")]
	public Guid RegionFiasId { get; set; }

	[JsonProperty("region_with_type")]
	public string RegionWithType { get; set; }

	[JsonProperty("region_type")]
	public string RegionType { get; set; }

	[JsonProperty("region_type_full")]
	public string RegionTypeFull { get; set; }

	[JsonProperty("region")]
	public string Region { get; set; }

	[JsonProperty("area_fias_id")]
	public Guid? AreaFiasId { get; set; }

	[JsonProperty("area_with_type")]
	public string? AreaWithType { get; set; }

	[JsonProperty("area_type")]
	public string? AreaType { get; set; }

	[JsonProperty("area_type_full")]
	public string? AreaTypeFull { get; set; }

	[JsonProperty("area")]
	public string? Area { get; set; }

	[JsonProperty("city_fias_id")]
	public Guid? CityFiasId { get; set; }

	[JsonProperty("city_with_type")]
	public string? CityWithType { get; set; }

	[JsonProperty("city_type")]
	public string? CityType { get; set; }

	[JsonProperty("city_type_full")]
	public string? CityTypeFull { get; set; }

	[JsonProperty("city")]
	public string? City { get; set; }

	[JsonProperty("settlement_fias_id")]
	public Guid? SettlementFiasId { get; set; }

	[JsonProperty("settlement_with_type")]
	public string? SettlementWithType { get; set; }

	[JsonProperty("settlement_type")]
	public string? SettlementType { get; set; }

	[JsonProperty("settlement_type_full")]
	public string? SettlementTypeFull { get; set; }

	[JsonProperty("settlement")]
	public string? Settlement { get; set; }

	[JsonProperty("street_fias_id")]
	public Guid? StreetFiasId { get; set; }

	[JsonProperty("street_with_type")]
	public string? StreetWithType { get; set; }

	[JsonProperty("street_type")]
	public string? StreetType { get; set; }

	[JsonProperty("street_type_full")]
	public string? StreetTypeFull { get; set; }

	[JsonProperty("street")]
	public string? Street { get; set; }

	[JsonProperty("house_fias_id")]
	public Guid? HouseFiasId { get; set; }

	[JsonProperty("house_type")]
	public string? HouseType { get; set; }

	[JsonProperty("house_type_full")]
	public string? HouseTypeFull { get; set; }

	[JsonProperty("house")]
	public string? House { get; set; }

	[JsonProperty("block_type")]
	public string? BlockType { get; set; }

	[JsonProperty("block_type_full")]
	public string? BlockTypeFull { get; set; }

	[JsonProperty("block")]
	public string? Block { get; set; }

	[JsonProperty("flat_type")]
	public string? FlatType { get; set; }

	[JsonProperty("flat_type_full")]
	public string? FlatTypeFull { get; set; }

	[JsonProperty("flat")]
	public string? Flat { get; set; }

	[JsonProperty("fias_id")]
	public Guid? FiasId { get; set; }

	[JsonProperty("fias_level")]
	public FiasLevel? FiasLevel { get; set; }

	[JsonProperty("geo_lat")]
	public float? GeoLat { get; set; }

	[JsonProperty("geo_lon")]
	public float? GeoLon { get; set; }

	[JsonProperty("qc_geo")]
	public GeoAccuracy? GeoAccuracy { get; set; }
}
