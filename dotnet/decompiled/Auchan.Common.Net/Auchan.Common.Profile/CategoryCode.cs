using Newtonsoft.Json;

namespace Auchan.Common.Profile;

public class CategoryCode
{
	[JsonProperty("id")]
	public long? Id { get; set; }

	[JsonProperty("code")]
	public string? Code { get; set; }

	[JsonProperty("name")]
	public string? Name { get; set; }
}
