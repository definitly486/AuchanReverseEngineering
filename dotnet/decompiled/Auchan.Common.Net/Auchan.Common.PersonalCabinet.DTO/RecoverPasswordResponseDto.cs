using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class RecoverPasswordResponseDto : BasePersonalCabinetResponseDto
{
	[JsonProperty("success")]
	public bool Success { get; set; }
}
