using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Stores.Dto;

public class FullStoreDto
{
	[JsonProperty("id", Required = Required.Always)]
	public int Id { get; set; }

	[JsonProperty("external_id")]
	public int ExternalId { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("address")]
	public string Address { get; set; }

	[JsonProperty("phone_number")]
	public string Phone { get; set; }

	[JsonProperty("fax_number")]
	public string Fax { get; set; }

	[JsonProperty("email")]
	public string Email { get; set; }

	[JsonProperty("email_pok")]
	public string EmailPok { get; set; }

	[JsonProperty("internal_email")]
	public string InternalEmail { get; set; }

	[JsonProperty("cashless_payment")]
	public bool CashlessPayment { get; set; }

	[JsonProperty("store_format")]
	public string StoreFormat { get; set; }

	[JsonProperty("public_transport")]
	public string PublicTransport { get; set; }

	[JsonProperty("private_transport")]
	public string PrivateTransport { get; set; }

	[JsonProperty("parking_lots", Required = Required.Default)]
	public int? ParkingLots { get; set; }

	[JsonProperty("latitude")]
	public double? Latitude { get; set; }

	[JsonProperty("longitude")]
	public double? Longitude { get; set; }

	[JsonProperty("description")]
	public string Description { get; set; }

	[JsonProperty("distance_in_km", Required = Required.Default)]
	public double? DistanceInKm { get; set; }

	[JsonProperty("region")]
	public FullRegionDto Region { get; set; }

	[JsonProperty("services")]
	public List<FullStoreServiceDto> Services { get; set; }

	[JsonProperty("opening_hours")]
	public List<FullStoreScheduleDto> Schedules { get; set; }
}
