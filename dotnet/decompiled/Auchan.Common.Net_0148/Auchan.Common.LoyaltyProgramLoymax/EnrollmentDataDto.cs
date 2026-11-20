using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class EnrollmentDataDto
{
	[JsonProperty("card_number")]
	public string? CardNumber { get; set; }

	[JsonProperty("virtual_card_number")]
	public string? VirtualCardNumber { get; set; }
}
