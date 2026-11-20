using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class LoyaltyCardRolloutDto
{
	[JsonProperty("firstName")]
	public string? FirstName { get; set; }

	[JsonProperty("lastName")]
	public string? LastName { get; set; }

	[JsonProperty("birthDate")]
	public string? BirthDate { get; set; }

	[JsonProperty("identifierNo")]
	public string? CardNumber { get; set; }

	[JsonProperty("identifierSecretNo")]
	public string? CvcCode { get; set; }

	[JsonProperty("permissions")]
	public LoyaltyCardRolloutPermissionsDto? Permissions { get; set; }
}
