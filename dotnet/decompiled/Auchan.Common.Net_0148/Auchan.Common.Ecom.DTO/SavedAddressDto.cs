using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record SavedAddressDto
{
	[JsonProperty("id")]
	public long Id { get; init; }

	[JsonProperty("applied")]
	public bool IsLastSaved { get; init; }

	[JsonProperty("region_id")]
	public long? RegionId { get; init; }

	[JsonProperty("address_string")]
	public string Address { get; init; } = "";

	[JsonProperty("name")]
	public string? Name { get; init; } = "";

	[JsonProperty("comment")]
	public string? Comment { get; init; } = "";

	[JsonProperty("flat")]
	public string Flat { get; init; } = "";

	[JsonProperty("floor")]
	public string Floor { get; init; } = "";

	[JsonProperty("porch")]
	public string Porch { get; init; } = "";

	[JsonProperty("intercom")]
	public string Intercom { get; init; } = "";

	[JsonProperty("description")]
	public string? Description { get; init; } = "";

	[JsonProperty("geo_lat")]
	public string Latitude { get; init; } = "";

	[JsonProperty("geo_lon")]
	public string Longitude { get; init; } = "";
}
