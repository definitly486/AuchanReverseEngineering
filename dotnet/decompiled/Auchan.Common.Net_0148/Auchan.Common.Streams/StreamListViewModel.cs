using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Streams;

public class StreamListViewModel : ScreenViewModel
{
	public enum VisualState
	{
		Default,
		InProgress,
		Error
	}

	private const string OnlineSoon = "Скоро в эфире";

	private const string OnlineNow = "Уже в эфире";

	private readonly StreamsService _streamsService;

	private readonly DefaultErrorTranslator _defaultErrorTranslator;

	private readonly IEnvironmentManager _environmentManager;

	private readonly TaskQueue _getStreamListTaskQueue = new TaskQueue();

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	public readonly string Title = "LIVE";

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsRefreshing_003Ek__BackingField;

	public readonly UICommand<StreamViewModel.Parameter, StreamViewModel.Parameter> NavigateToStreamCommand = new UICommand<StreamViewModel.Parameter, StreamViewModel.Parameter>((StreamViewModel.Parameter p) => p);

	[CompilerGenerated]
	private ObservableRangeCollection<StreamItemViewModel> _003CStreamItemViewModels_003Ek__BackingField;

	private string ApplicationId
	{
		get
		{
			if (_environmentManager.CurrentEnvironment != Auchan.Common.Networking.Environment.Production)
			{
				return "auchan-test";
			}
			return "auchan";
		}
	}

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
	}

	public string ErrorTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorTitle");
			}
		}
	} = "Упс! Что-то пошло не так.";

	public string ErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorMessage");
			}
		}
	} = "Небольшие технические проблемы,\nпопробуйте обновить экран.";

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

	public ObservableRangeCollection<StreamItemViewModel> StreamItemViewModels
	{
		[CompilerGenerated]
		get
		{
			return _003CStreamItemViewModels_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CStreamItemViewModels_003Ek__BackingField, value))
			{
				_003CStreamItemViewModels_003Ek__BackingField = value;
				RaisePropertyChanged("StreamItemViewModels");
			}
		}
	} = new ObservableRangeCollection<StreamItemViewModel>();

	public StreamListViewModel(StreamsService streamsService, DefaultErrorTranslator defaultErrorTranslator, IEnvironmentManager environmentManager)
	{
		_streamsService = streamsService;
		_defaultErrorTranslator = defaultErrorTranslator;
		_environmentManager = environmentManager;
	}

	protected override async Task Start()
	{
		await base.Start();
		_getStreamListTaskQueue.Enqueue(async delegate
		{
			State = VisualState.InProgress;
			await LoadStreamData();
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void OnRefresh()
	{
		_getStreamListTaskQueue.Enqueue(async delegate
		{
			IsRefreshing = true;
			await LoadStreamData();
			IsRefreshing = false;
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void OnStreamClicked(StreamItemViewModel streamItemViewModel)
	{
		if (streamItemViewModel.IsAvailable)
		{
			NavigateToStreamCommand.Trigger(new StreamViewModel.Parameter(ApplicationId, streamItemViewModel.Id));
		}
	}

	private async Task LoadStreamData()
	{
		StreamItemViewModels.Clear();
		Result<StreamsDtos.StreamBlockDto, DomainError> result = await _streamsService.GetStreams(ApplicationId);
		if (result.IsSuccess)
		{
			List<StreamItemViewModel> list = result.Value.Body?.AvailableStreams?.Select((StreamsDtos.StreamDto x) => new StreamItemViewModel(x.Id ?? string.Empty, x.PreviewImages?.FirstOrDefault()?.Src ?? string.Empty, isAvailable: true)).ToList();
			if (list != null && list.Count > 0)
			{
				StreamItemViewModels.Add(new StreamItemViewModel("Уже в эфире"));
				StreamItemViewModels.AddRange(list);
			}
			List<StreamItemViewModel> list2 = result.Value.Body?.PlannedStreams?.Select((StreamsDtos.StreamDto x) => new StreamItemViewModel(x.Id ?? string.Empty, x.PreviewImages?.FirstOrDefault()?.Src ?? string.Empty, isAvailable: false)).ToList();
			if (list2 != null && list2.Count > 0)
			{
				StreamItemViewModels.Add(new StreamItemViewModel("Скоро в эфире"));
				StreamItemViewModels.AddRange(list2);
			}
		}
		State = VisualState.Default;
		if (result.IsFailure)
		{
			(string, string) tuple = _defaultErrorTranslator.Translate(result.Error);
			ErrorTitle = tuple.Item1;
			ErrorMessage = tuple.Item2;
			State = VisualState.Error;
		}
	}
}
