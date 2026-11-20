using Newtonsoft.Json;

namespace Auchan.Common.NewYearGame.DTO;

public class GameMessageDataDTO
{
	[JsonProperty("sessionId")]
	public string SessionId { get; set; }

	[JsonProperty("channel")]
	public string Channel { get; set; }

	public GameMessageDataDTO(string sessionId, string channel)
	{
		SessionId = sessionId;
		Channel = channel;
	}
}
