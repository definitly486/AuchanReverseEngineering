using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class CheckAccountRequestDto
{
	[JsonProperty("email")]
	public string? Email { get; set; }

	[JsonProperty("password")]
	public string? Password { get; set; }
}
