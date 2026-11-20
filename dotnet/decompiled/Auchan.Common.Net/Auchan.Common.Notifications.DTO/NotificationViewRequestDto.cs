using Newtonsoft.Json;

namespace Auchan.Common.Notifications.DTO;

public class NotificationViewRequestDto
{
	[JsonProperty("source_id")]
	public int SourceId { get; }

	[JsonProperty("uuid")]
	public string Uuid { get; }

	public NotificationViewRequestDto(string uuid, int sourceId = 1)
	{
		Uuid = uuid;
		SourceId = sourceId;
	}
}
