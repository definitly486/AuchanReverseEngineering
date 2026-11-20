using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class LoyaltyCardRolloutPermissionsDto
{
	[JsonProperty("adverts")]
	public bool Adverts { get; set; }

	[JsonProperty("email")]
	public bool Email { get; set; }

	[JsonProperty("facebook")]
	public bool Facebook { get; set; }

	[JsonProperty("info")]
	public bool Info { get; set; }

	[JsonProperty("phone")]
	public bool Phone { get; set; }

	[JsonProperty("post")]
	public bool Post { get; set; }

	[JsonProperty("sms")]
	public bool Sms { get; set; }
}
