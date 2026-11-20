using Newtonsoft.Json;

namespace Auchan.Common.Notifications.DTO;

public class NotificationsListResponseDto
{
	[JsonProperty("data")]
	public NotificationsListData Data { get; set; } = new NotificationsListData();
}
