using Newtonsoft.Json;

namespace Auchan.Common.Profile.Stores.Dto;

public class FullStoreServiceDto
{
	[JsonProperty("id", Required = Required.Always)]
	public int Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("icon")]
	public string Icon { get; set; }
}
