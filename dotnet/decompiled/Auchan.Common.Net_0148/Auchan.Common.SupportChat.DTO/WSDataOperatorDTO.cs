using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public class WSDataOperatorDTO
{
	[JsonProperty("operatorPhotoLink")]
	public string IconUrl { get; set; }

	[JsonProperty("operatorName")]
	public string Name { get; set; }
}
