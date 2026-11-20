using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class Error
{
	[JsonProperty("code")]
	public string? Code { get; set; }

	[JsonProperty("message")]
	public string? Message { get; set; }
}
