using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public class ChatStatusResponseDTO
{
	[JsonProperty("data")]
	public Data Data { get; set; } = new Data();
}
