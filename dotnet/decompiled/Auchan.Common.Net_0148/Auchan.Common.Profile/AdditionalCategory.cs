using Newtonsoft.Json;

namespace Auchan.Common.Profile;

public class AdditionalCategory
{
	[JsonProperty("code")]
	public string? Code { get; set; }

	[JsonProperty("name")]
	public string? Name { get; set; }
}
