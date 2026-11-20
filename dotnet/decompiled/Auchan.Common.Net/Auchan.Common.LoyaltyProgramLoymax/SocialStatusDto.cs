using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class SocialStatusDto
{
	[JsonProperty("data")]
	public Data[]? Data { get; set; }
}
