using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class ProfileResponseDto : BasePersonalCabinetResponseDto
{
	[JsonProperty("profile")]
	public ProfileDto? Profile { get; set; }
}
