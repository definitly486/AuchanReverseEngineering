using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class TokenDto : BasePersonalCabinetResponseDto
{
	[JsonProperty("access_token")]
	public string? AccessToken { get; set; }
}
