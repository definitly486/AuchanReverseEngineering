using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class LogoutResponseDto : BasePersonalCabinetResponseDto
{
	[JsonProperty("logout")]
	public string LogoutStatus { get; set; }

	public LogoutResponseDto(string logoutStatus)
	{
		LogoutStatus = logoutStatus;
	}
}
