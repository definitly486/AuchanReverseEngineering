using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class LoyaltyEnrollmentDtos : LoymaxResponseBaseDto
{
	[JsonProperty("data")]
	public EnrollmentDataDto? Data { get; set; }
}
