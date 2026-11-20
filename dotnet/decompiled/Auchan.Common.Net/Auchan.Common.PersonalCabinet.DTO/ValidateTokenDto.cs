using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class ValidateTokenDto : BasePersonalCabinetResponseDto
{
	[JsonProperty("validate")]
	public bool Validate { get; set; }
}
