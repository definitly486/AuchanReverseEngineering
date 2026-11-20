using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Logs;

public class LogViewModel : ScreenViewModel
{
	private const string ErrorMessage = "Не удалось отправить логи, повторите попытку";

	private readonly ILogService _logService;

	private readonly IInfoMessageService _infoMessageService;

	private readonly Subject<string> _searchTextChanged = new Subject<string>();

	private readonly IDisposable _searchSubscription;

	private List<Log>? _log;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	private string _searchText = string.Empty;

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
	} = VisualState.Default;

	public string ScreenTitle => "Логи";

	public string SendLogsButtonText { get; } = "Отправить лог в админ. панель";

	private ObservableRangeCollection<LogItemViewModel> LogItemViewModels { get; } = new ObservableRangeCollection<LogItemViewModel>();

	public ObservableRangeCollection<LogItemViewModel> FilteredLogItemViewModels { get; } = new ObservableRangeCollection<LogItemViewModel>();

	public string SearchText
	{
		get
		{
			return _searchText;
		}
		set
		{
			if (!(_searchText == value))
			{
				_searchText = value;
				RaisePropertyChanged("SearchText");
				_searchTextChanged.OnNext(_searchText);
			}
		}
	}

	public LogViewModel(ILogService logService, IInfoMessageService infoMessageService)
	{
		_logService = logService;
		_infoMessageService = infoMessageService;
		_searchSubscription = _searchTextChanged.Throttle(TimeSpan.FromMilliseconds(300L)).ObserveOn(MainThread.Scheduler).Subscribe(delegate
		{
			ApplyFilter();
		})
			.AddTo(base.CloseDisposable);
		_logService.LogInfo("Open log menu", "User opened log menu", LogType.UserAction, SystemType.MobileApp);
	}

	protected override async Task Start()
	{
		State = VisualState.InProgress;
		await base.Start();
		await ReadLog();
		State = VisualState.Default;
	}

	public async Task SendLogsAsync()
	{
		State = VisualState.InProgress;
		Result<Unit, DomainError> result = await _logService.SendLogs();
		if (result.IsFailure)
		{
			_infoMessageService.ShowSnackbar((!string.IsNullOrEmpty(result.Error?.Message)) ? string.Format("Не удалось отправить логи, повторите попытку", "\nОтвет: " + result.Error.Message) : $"Не удалось отправить логи, повторите попытку");
		}
		else
		{
			await ReadLog();
			_infoMessageService.ShowSnackbar("Логи успешно отправлены", SnackbarStyle.Success);
		}
		State = VisualState.Default;
	}

	public void ExportLogsClick()
	{
		ExportLogsAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private void ApplyFilter()
	{
		if (string.IsNullOrWhiteSpace(_searchText))
		{
			FilteredLogItemViewModels.Clear();
			FilteredLogItemViewModels.InsertRange(0, LogItemViewModels);
			return;
		}
		List<LogItemViewModel> collection = LogItemViewModels.Where((LogItemViewModel x) => (!string.IsNullOrEmpty(x.Name) && x.Name.Contains(_searchText, StringComparison.OrdinalIgnoreCase)) || (!string.IsNullOrEmpty(x.Description) && x.Description.Contains(_searchText, StringComparison.OrdinalIgnoreCase)) || x.LogType.Contains(_searchText, StringComparison.OrdinalIgnoreCase) || x.LogTime.Contains(_searchText, StringComparison.OrdinalIgnoreCase)).ToList();
		FilteredLogItemViewModels.Clear();
		FilteredLogItemViewModels.InsertRange(0, collection);
	}

	private async Task ReadLog()
	{
		_log = await _logService.ReadLogAsyncBackwards();
		LogItemViewModels.ReplaceRange(_log.Select((Log x) => new LogItemViewModel(x)));
		ApplyFilter();
	}

	private async Task ExportLogsAsync()
	{
		State = VisualState.InProgress;
		Result<Unit, DomainError> result = await _logService.ExportLogs();
		State = VisualState.Default;
		if (result.IsFailure)
		{
			_infoMessageService.ShowSnackbar("Ошибка сохранения логов на устройство");
		}
	}
}
