using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Notifications.DTO;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Notifications;

public class NotificationsCounterService
{
	private readonly NotificationsService _notificationsService;

	private readonly BehaviorSubject<int> _count = new BehaviorSubject<int>(0);

	public IObservable<int> Count => _count;

	public int CurrentValue => _count.Value;

	public NotificationsCounterService(NotificationsService notificationsService)
	{
		_notificationsService = notificationsService;
	}

	public void PublishLatest(int value)
	{
		if (_count.Value != value)
		{
			_count.OnNext(value);
		}
	}

	public async Task Refresh()
	{
		Result<NotificationsListResponseDto, DomainError> result = await _notificationsService.GetNotifications();
		PublishLatest(result.IsSuccess ? result.Value.Data.NewNotificationsCount.GetValueOrDefault() : 0);
	}

	public void RefreshInBackground()
	{
		Refresh().SafeFireAndForget((Action<Exception>)null, false);
	}
}
