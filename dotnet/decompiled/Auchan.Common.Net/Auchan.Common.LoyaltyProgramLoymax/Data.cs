using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class Data
{
	[JsonProperty("logicalName")]
	public string? LogicalName { get; set; }

	[JsonProperty("value")]
	public bool Value { get; set; }
}
