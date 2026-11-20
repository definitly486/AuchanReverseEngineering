using Auchan.Common.LoyaltyProgramLoymax;
using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class ProfileResponseSnackCaseDto : LoymaxResponseBaseDto
{
	[JsonProperty("data")]
	public ProfileSnackCaseDto? Profile { get; set; }
}
