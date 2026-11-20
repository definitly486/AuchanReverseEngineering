using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class LoyaltyEnrollmentDto
{
	[JsonProperty("loyalty_id")]
	public int? LoyaltyId { get; set; }
}
