using Newtonsoft.Json;

namespace Auchan.Common.Profile.UserCards.DTO;

public class BaseProcessingResponseDto
{
	[JsonProperty("code", Required = Required.Always)]
	public int Code { get; set; }

	[JsonProperty("message", Required = Required.Always)]
	public string Message { get; set; }
}
