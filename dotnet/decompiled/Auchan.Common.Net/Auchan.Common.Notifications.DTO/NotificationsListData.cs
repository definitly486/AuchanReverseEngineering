using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Notifications.DTO;

public class NotificationsListData
{
	[JsonProperty("new_notifications_count")]
	public int? NewNotificationsCount { get; set; }

	[JsonProperty("notifications")]
	public List<NotificationDto> Notifications { get; set; } = new List<NotificationDto>();
}
