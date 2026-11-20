using Newtonsoft.Json;

namespace Auchan.Common.Profile.Stores.Dto;

public class FullRegionDto
{
	[JsonProperty("id", Required = Required.Always)]
	public int Id { get; set; }

	[JsonProperty("city_id", Required = Required.Default)]
	public long? CityId { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("external_id")]
	public long? ExternalId { get; set; }

	[JsonProperty("fias_id")]
	public string FiasId { get; set; }
}
