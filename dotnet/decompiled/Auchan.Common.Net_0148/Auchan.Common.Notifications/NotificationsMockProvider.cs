using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Notifications.DTO;

namespace Auchan.Common.Notifications;

public static class NotificationsMockProvider
{
	public static bool UseMock { get; set; } = false;

	public static bool ForceEmpty { get; set; } = false;

	public static bool ForceError { get; set; } = false;

	public static int ArtificialDelayMs { get; set; } = 0;

	public static int NewNotificationsCount { get; set; } = 4;

	public static async Task SimulateDelay()
	{
		if (ArtificialDelayMs > 0)
		{
			await Task.Delay(ArtificialDelayMs);
		}
	}

	public static NotificationsListResponseDto BuildResponse()
	{
		NotificationsListData data = (ForceEmpty ? new NotificationsListData
		{
			NewNotificationsCount = 0,
			Notifications = new List<NotificationDto>()
		} : new NotificationsListData
		{
			NewNotificationsCount = NewNotificationsCount,
			Notifications = new List<NotificationDto>
			{
				new NotificationDto
				{
					Uuid = "mock-1",
					Title = "Хороший день начинается…",
					Text = "С кофе и кешбэка 10%. Успейте до 28.09",
					DateFrom = "Сегодня",
					DeeplinkUrl = "auchan://cashback"
				},
				new NotificationDto
				{
					Uuid = "mock-2",
					Title = "Пожар! Горят ваши баллы!",
					Text = "У вас 150 баллов, они сгорят 10.10.2026 г",
					DateFrom = "Сегодня",
					DeeplinkUrl = "auchan://profile"
				},
				new NotificationDto
				{
					Uuid = "mock-3",
					Title = "Вам промокод \"ИСТОРИЯ\"",
					Text = "Скидка 15% на заказ от 3000р",
					DateFrom = "9 июля",
					DeeplinkUrl = "auchan://cart"
				},
				new NotificationDto
				{
					Uuid = "mock-4",
					Title = "На вашей улице счастье!",
					Text = "Бесплатная доставка от 1500Р по промокоду FREE1500",
					DateFrom = "23 июня",
					DeeplinkUrl = null
				},
				new NotificationDto
				{
					Uuid = "mock-5",
					Title = "«ЭкоНива» приглашает на ферму",
					Text = "С 21 по 24 сентября на парковке АШАН вас ждёт шатёр с коровами и телятами. Приходите всей семьёй!",
					DateFrom = "8 июня",
					DeeplinkUrl = null
				},
				new NotificationDto
				{
					Uuid = "mock-6",
					Title = "Очень длинный заголовок уведомления который точно не помещается в одну строку и должен быть обрезан троеточием",
					Text = "И не менее длинный текст уведомления, который должен занять три строки и упереться в ограничение по количеству строк, после чего его обрежет ellipsis в конце последней видимой строки на экране списка уведомлений.",
					DateFrom = "5 июля",
					DeeplinkUrl = "auchan://product/669586"
				}
			}
		});
		return new NotificationsListResponseDto
		{
			Data = data
		};
	}

	public static NotificationViewResponseDto BuildViewResponse()
	{
		return new NotificationViewResponseDto
		{
			Result = "ok"
		};
	}
}
