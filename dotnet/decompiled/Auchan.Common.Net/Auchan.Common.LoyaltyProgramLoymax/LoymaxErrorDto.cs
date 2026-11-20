using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class LoymaxErrorDto
{
	[JsonProperty("code")]
	public string? Code { get; set; }

	[JsonProperty("message")]
	public string? Message { get; set; }
}
