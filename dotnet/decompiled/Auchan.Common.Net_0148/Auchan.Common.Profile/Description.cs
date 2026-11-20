using Newtonsoft.Json;

namespace Auchan.Common.Profile;

public class Description
{
	[JsonProperty("content")]
	public string? Content { get; set; }
}
