using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.Notifications.DTO;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Notifications;

public sealed class NotificationsViewModel : ScreenViewModel, IYandexMetricaScreenViewModel, IScreenViewModel
{
	private readonly NotificationsService _service;

	private readonly NotificationsCounterService _counterService;

	private readonly Lazy<IUniversalLinksService> _linksService;

	private readonly DefaultErrorTranslator _errorTranslator;

	private readonly Subject<NotificationItemViewModel> _expandItem = new Subject<NotificationItemViewModel>();

	[CompilerGenerated]
	private string _003CErrorTitleText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorHintText_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsRefreshing_003Ek__BackingField;

	public string Title => "Уведомления";

	public string EmptyTitleText => "У вас пока нет уведомлений";

	public string ErrorTitleText
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorTitleText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CErrorTitleText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorTitleText_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorTitleText");
			}
		}
	} = "Упс! Что-то пошло не так.";

	public string ErrorHintText
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorHintText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CErrorHintText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorHintText_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorHintText");
			}
		}
	} = "Небольшие технические проблемы,\nпопробуйте обновить экран.";

	public string ErrorRetryButtonText => "Повторить";

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.InProgress;

	public bool IsRefreshing
	{
		[CompilerGenerated]
		get
		{
			return _003CIsRefreshing_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsRefreshing_003Ek__BackingField != value)
			{
				_003CIsRefreshing_003Ek__BackingField = value;
				RaisePropertyChanged("IsRefreshing");
			}
		}
	}

	public ObservableRangeCollection<NotificationItemViewModel> Items { get; } = new ObservableRangeCollection<NotificationItemViewModel>();

	public IObservable<NotificationItemViewModel> ExpandItemCommand => _expandItem.Debounce();

	public UICommand RetryCommand { get; } = new UICommand();

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "Notifications";

	string IYandexMetricaScreenViewModel.ScreenName => "Notifications";

	public NotificationsViewModel(NotificationsService service, NotificationsCounterService counterService, Lazy<IUniversalLinksService> linksService, DefaultErrorTranslator errorTranslator)
	{
		_service = service;
		_counterService = counterService;
		_linksService = linksService;
		_errorTranslator = errorTranslator;
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadAsync();
	}

	public Task Refresh()
	{
		return LoadAsync(isRefreshing: true);
	}

	public void OnRetryClick()
	{
		LoadAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void OnItemClicked(NotificationItemViewModel item)
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_notification");
		item.MarkAsRead();
		RecalculateLocalCounter();
		if (item.HasDeeplink)
		{
			_linksService.Value.HandleLinkOnStart(item.DeeplinkUrl, UniversalLinkSource.Push).SafeFireAndForget((Action<Exception>)null, false);
		}
		else
		{
			_expandItem.OnNext(item);
		}
	}

	private async Task LoadAsync(bool isRefreshing = false)
	{
		if (isRefreshing)
		{
			IsRefreshing = true;
		}
		else
		{
			State = VisualState.InProgress;
		}
		Result<NotificationsListResponseDto, DomainError> result = await _service.GetNotifications();
		IsRefreshing = false;
		if (result.IsFailure)
		{
			(string, string) tuple = _errorTranslator.Translate(result.Error);
			ErrorTitleText = tuple.Item1;
			ErrorHintText = tuple.Item2;
			State = ((Items.Count > 0) ? VisualState.Default : VisualState.Error);
			_counterService.PublishLatest(0);
			return;
		}
		NotificationsListData data = result.Value.Data;
		Items.Clear();
		Items.AddRange(data.Notifications.Select((NotificationDto n) => new NotificationItemViewModel(n)));
		_counterService.PublishLatest(data.NewNotificationsCount.GetValueOrDefault());
		State = ((Items.Count != 0) ? VisualState.Default : VisualState.Empty);
	}

	private void RecalculateLocalCounter()
	{
		int value = Items.Count((NotificationItemViewModel i) => i.IsUnread);
		_counterService.PublishLatest(value);
	}
}
