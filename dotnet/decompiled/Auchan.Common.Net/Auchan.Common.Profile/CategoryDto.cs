using Newtonsoft.Json;

namespace Auchan.Common.Profile;

public class CategoryDto
{
	[JsonProperty("code")]
	public string? Code { get; set; }

	[JsonProperty("name")]
	public string? Name { get; set; }

	[JsonProperty("count")]
	public long? Count { get; set; }
}
