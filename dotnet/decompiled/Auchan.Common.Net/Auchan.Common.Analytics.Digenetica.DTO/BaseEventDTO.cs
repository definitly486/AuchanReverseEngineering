using Newtonsoft.Json;

namespace Auchan.Common.Analytics.Digenetica.DTO;

internal class BaseEventDTO
{
	[JsonProperty("eventType")]
	public string EventType { get; set; }

	[JsonProperty("sessionId")]
	public string SessionId { get; set; }

	[JsonProperty("userId")]
	public string? UserId { get; set; }

	[JsonProperty("apiKey")]
	public string ApiKey { get; set; }

	[JsonProperty("userGUID")]
	public string UserGUID { get; set; }

	[JsonProperty("regionId")]
	public string RegionId { get; set; }

	[JsonProperty("channel")]
	public string Channel { get; set; }
}
