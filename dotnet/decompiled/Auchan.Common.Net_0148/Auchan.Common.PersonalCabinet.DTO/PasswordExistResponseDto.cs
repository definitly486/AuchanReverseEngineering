using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class PasswordExistResponseDto : BasePersonalCabinetResponseDto
{
	[JsonProperty("isExist")]
	public bool IsExists { get; set; }
}
