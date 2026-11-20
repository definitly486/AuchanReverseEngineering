using Newtonsoft.Json;

namespace Auchan.Common.Notifications.DTO;

public class NotificationDto
{
	[JsonProperty("uuid")]
	public string Uuid { get; set; } = string.Empty;

	[JsonProperty("title")]
	public string Title { get; set; } = string.Empty;

	[JsonProperty("text")]
	public string Text { get; set; } = string.Empty;

	[JsonProperty("date_from")]
	public string DateFrom { get; set; } = string.Empty;

	[JsonProperty("deeplink_url")]
	public string? DeeplinkUrl { get; set; }

	[JsonProperty("image")]
	public string? Image { get; set; }
}
