using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Notifications.DTO;
using Refit;

namespace Auchan.Common.Notifications;

[Headers(new string[] { "Authorization: Basic Z3M6Z3M=" })]
public interface INotificationsApi
{
	[Get("/notifications")]
	Task<NotificationsListResponseDto> GetNotifications([Header("X-Token-CMD")] string token, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/notifications/view")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<NotificationViewResponseDto> MarkAsViewed([Header("X-Token-CMD")] string token, [Body] NotificationViewRequestDto body, CancellationToken cancellationToken = default(CancellationToken));
}
