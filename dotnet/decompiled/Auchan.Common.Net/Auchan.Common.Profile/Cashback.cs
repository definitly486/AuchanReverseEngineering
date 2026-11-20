using Newtonsoft.Json;

namespace Auchan.Common.Profile;

public class Cashback
{
	[JsonProperty("point")]
	public long? Point { get; set; }

	[JsonProperty("percent")]
	public long? Percent { get; set; }

	[JsonProperty("limit_type")]
	public string? LimitType { get; set; }

	[JsonProperty("limit")]
	public double? Limit { get; set; }
}
