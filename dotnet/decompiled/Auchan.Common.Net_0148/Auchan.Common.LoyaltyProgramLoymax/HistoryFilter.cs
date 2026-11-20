using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class HistoryFilter
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; } = "";
}
