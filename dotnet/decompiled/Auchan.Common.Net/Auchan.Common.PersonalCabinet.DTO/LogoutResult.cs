using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class LogoutResult
{
	[JsonProperty("logout")]
	public string? Logout { get; set; }
}
