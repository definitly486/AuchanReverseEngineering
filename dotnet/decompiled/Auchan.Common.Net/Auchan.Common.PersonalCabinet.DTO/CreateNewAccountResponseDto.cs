using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class CreateNewAccountResponseDto : TokenDto
{
	[JsonProperty("profile")]
	public ProfileDto? Profile { get; set; }
}
