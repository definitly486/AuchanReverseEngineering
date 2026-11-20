using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class CheckPhoneDto : BasePersonalCabinetResponseDto
{
	[JsonProperty("result")]
	public int Result { get; set; }

	[JsonProperty("resultmessage")]
	public string? ResultMessage { get; set; }
}
