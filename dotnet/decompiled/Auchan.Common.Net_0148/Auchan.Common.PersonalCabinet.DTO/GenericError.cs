using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class GenericError
{
	[JsonProperty("error")]
	public int Error { get; set; }

	[JsonProperty("Msg")]
	public string? Message { get; set; }
}
