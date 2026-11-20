using Newtonsoft.Json;

namespace Auchan.Common.Notifications.DTO;

public class NotificationViewResponseDto
{
	[JsonProperty("result")]
	public string? Result { get; set; }
}
