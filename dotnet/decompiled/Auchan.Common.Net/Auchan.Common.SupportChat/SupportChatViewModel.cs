using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.SupportChat.DTO;
using Auchan.Common.SupportChat.ItemViewModels;
using Auchan.Common.SupportChat.Models;
using CSharpFunctionalExtensions;
using EBind;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Media;
using Microsoft.Maui.Networking;
using Microsoft.Maui.Storage;

namespace Auchan.Common.SupportChat;

public class SupportChatViewModel : ScreenViewModel
{
	public enum VisualState
	{
		Default,
		IsProgress,
		Error
	}

	private readonly SupportChatMessageManager _supportChatMessageManager;

	private readonly IBeesenderFileUploader _beesenderFileUploader;

	private readonly IDataBroker _dataBroker;

	private readonly IPickerOptionsProvider _pickerOptionsProvider;

	private readonly ILogService _logService;

	private readonly SemaphoreSlim _itemViewModelsUpdate = new SemaphoreSlim(1);

	private int _invisibleItemProcessing;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	private const string OPERATOR_CALL = "Вызов оператора";

	private string _message = "";

	[CompilerGenerated]
	private bool _003CSendButtonEnabled_003Ek__BackingField;

	private WritingMessageViewModel _writingMessageViewModel = new WritingMessageViewModel();

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

	public string Title => "Чат c АШАН";

	public string SelectFileText => "Выбор файлов";

	public string SelectPhotoFromGalleryText => "Выбрать фото";

	public string SelectVideoFromGalleryText => "Выбрать видео";

	public ObservableRangeCollection<BaseSupportChatItemViewModel> ItemViewModels { get; } = new ObservableRangeCollection<BaseSupportChatItemViewModel>
	{
		ShouldDeferEvents = false
	};

	public ObservableRangeCollection<MacroItemViewModel> MacroItemViewModels { get; } = new ObservableRangeCollection<MacroItemViewModel>
	{
		ShouldDeferEvents = false
	};

	public bool InputBlocked => MacroItemViewModels.Count > 1;

	public UICommand CloseCommand { get; } = new UICommand();

	public UICommand SendCommand { get; } = new UICommand();

	public UICommand SelectFileCommand { get; } = new UICommand();

	public UICommand SelectPhotoFromGalleryCommand { get; } = new UICommand();

	public UICommand SelectVideoFromGalleryCommand { get; } = new UICommand();

	public UICommand<DynamicFeedbackViewModel.Parameter> NavigateToFeedbackCommand { get; } = new UICommand<DynamicFeedbackViewModel.Parameter>();

	public UICommand<SupportChatSendErrorViewModel.Parameter, OutgoingMessageViewModel> OpenResendCommand { get; } = new UICommand<SupportChatSendErrorViewModel.Parameter, OutgoingMessageViewModel>((OutgoingMessageViewModel p) => new SupportChatSendErrorViewModel.Parameter(p.Message));

	public UICommand<MacroItemViewModel> MacroSelectedCommand { get; } = new UICommand<MacroItemViewModel>();

	public UICommand<BrokerToken> OpenFileSendErrorCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<BrokerToken> OpenRefundCommand { get; } = new UICommand<BrokerToken>();

	public string MessagePlaceholder => "Сообщение";

	public string ChooseButtonPlaceholder => "Выберите кнопку";

	public string Message
	{
		get
		{
			return _message;
		}
		set
		{
			if (!string.Equals(_message, value, StringComparison.Ordinal))
			{
				_message = value;
				RaisePropertyChanged("Message");
				SendButtonEnabled = !string.IsNullOrWhiteSpace(_message);
			}
		}
	}

	public bool SendButtonEnabled
	{
		[CompilerGenerated]
		get
		{
			return _003CSendButtonEnabled_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CSendButtonEnabled_003Ek__BackingField != value)
			{
				_003CSendButtonEnabled_003Ek__BackingField = value;
				RaisePropertyChanged("SendButtonEnabled");
			}
		}
	}

	public string ErrorTitle => "Упс! Что-то пошло не так";

	public string ErrorMessage => "Небольшие технические проблемы,\nпопробуйте обновить экран.";

	public SupportChatViewModel(SupportChatMessageManager supportChatMessageManager, IBeesenderFileUploader beesenderFileUploader, IDataBroker dataBroker, IPickerOptionsProvider pickerOptionsProvider, ILogService logService)
	{
		_supportChatMessageManager = supportChatMessageManager;
		_beesenderFileUploader = beesenderFileUploader;
		_dataBroker = dataBroker;
		_pickerOptionsProvider = pickerOptionsProvider;
		_logService = logService;
		SendCommand.PerformTask(SendMessage).Subscribe().AddTo(base.CloseDisposable);
		MacroSelectedCommand.PerformTask(SendMacro).Subscribe().AddTo(base.CloseDisposable);
		SelectFileCommand.PerformTask(SelectFile).Subscribe().AddTo(base.CloseDisposable);
		SelectPhotoFromGalleryCommand.PerformTask(SelectPhotoGallery).Subscribe().AddTo(base.CloseDisposable);
		SelectVideoFromGalleryCommand.PerformTask(SelectVideoGallery).Subscribe().AddTo(base.CloseDisposable);
		TabBarVisible = false;
	}

	public void SetMessageSilent(string value)
	{
		_message = value;
		SendButtonEnabled = !string.IsNullOrWhiteSpace(_message);
	}

	protected override async Task Start()
	{
		await base.Start();
		Task<IReadOnlyList<string>> macrosTask = _supportChatMessageManager.GetMacrosAsync();
		await Task.WhenAll(LoadMessages(), macrosTask);
		await ApplyCachedMacrosAsync(macrosTask.Result);
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		Result<ChatStatusResponseDTO, DomainError> statusTask = await _supportChatMessageManager.GetStatus();
		if (statusTask.IsFailure)
		{
			State = VisualState.Error;
			return;
		}
		_supportChatMessageManager.OnMessageUpdated += new DisposableDelegate<EventHandler<CacheMessage>>(delegate(object? sender, CacheMessage message)
		{
			foreach (BaseSupportChatItemViewModel item in ItemViewModels.LockedInvoke((ObservableRangeCollection<BaseSupportChatItemViewModel> ivm) => new List<BaseSupportChatItemViewModel>(ivm)))
			{
				BaseMessageViewModel messageVM = item as BaseMessageViewModel;
				if (messageVM != null && messageVM.MessageId == message.Id)
				{
					MainThread.BeginInvokeOnMainThread(delegate
					{
						messageVM.OnMessageUpdated();
					});
					break;
				}
			}
		}, delegate(EventHandler<CacheMessage> d)
		{
			_supportChatMessageManager.OnMessageUpdated -= d;
		}).AddTo(base.PauseDisposable);
		_supportChatMessageManager.OnButtonsUpdated += new DisposableDelegate<EventHandler<List<string>>>(delegate(object? _, List<string> macros)
		{
			UpdateMacros(macros).SafeFireAndForget((Action<Exception>)null, false);
		}, delegate(EventHandler<List<string>> d)
		{
			_supportChatMessageManager.OnButtonsUpdated -= d;
		}).AddTo(base.PauseDisposable);
		_supportChatMessageManager.OnDisconnected += new DisposableDelegate<EventHandler>(OnDisconnected, delegate(EventHandler d)
		{
			_supportChatMessageManager.OnDisconnected -= d;
		}).AddTo(base.PauseDisposable);
		Connectivity.ConnectivityChanged += new DisposableDelegate<EventHandler<ConnectivityChangedEventArgs>>(OnConnectivityChanged, delegate(EventHandler<ConnectivityChangedEventArgs> eh)
		{
			Connectivity.ConnectivityChanged -= eh;
		}).AddTo(base.PauseDisposable);
		await _supportChatMessageManager.ConnectAsync();
		await ApplyCachedMacrosAsync(await _supportChatMessageManager.GetMacrosAsync());
		if (!statusTask.Value.Data.IsOpened)
		{
			await _supportChatMessageManager.ClearOperatorInfoAsync();
			if (ItemViewModels.Count != 0)
			{
				await UpdateMacros(Array.Empty<string>());
			}
			else
			{
				ItemViewModels.Add(_writingMessageViewModel);
			}
			await _supportChatMessageManager.SendInitialMessage(delegate
			{
				ItemViewModels.Add(_writingMessageViewModel);
			});
		}
		State = VisualState.Default;
	}

	protected override async Task OnPaused()
	{
		await base.OnPaused();
		_supportChatMessageManager.Disconnect();
	}

	public void Retry()
	{
		State = VisualState.IsProgress;
		OnResumed().SafeFireAndForget((Action<Exception>)null, false);
	}

	private void OnDisconnected(object? sender, EventArgs e)
	{
		if (Connectivity.NetworkAccess == NetworkAccess.Internet)
		{
			_supportChatMessageManager.ConnectAsync().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private void OnConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
	{
		if (Connectivity.NetworkAccess == NetworkAccess.Internet)
		{
			_supportChatMessageManager.ConnectAsync().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public override void Dispose()
	{
		_supportChatMessageManager.Disconnect();
		base.Dispose();
	}

	private async Task LoadMessages()
	{
		State = VisualState.IsProgress;
		await Task.Delay(100);
		Result<ObservableRangeCollection<CacheMessage>, DomainError> messageModels = await _supportChatMessageManager.GetMessages();
		if (messageModels.IsFailure)
		{
			State = VisualState.Error;
			return;
		}
		messageModels.Value.SubscribeToCollectionChanged(delegate(NotifyCollectionChangedEventArgs args)
		{
			OnMessagesChanged(args, messageModels.Value);
		}, base.CloseDisposable);
		OnMessagesChanged(null, messageModels.Value);
	}

	private async Task SendMacro(MacroItemViewModel viewModel)
	{
		if (_supportChatMessageManager.IsLeaveFeedbackButton(viewModel.MacroText))
		{
			NavigateToFeedbackCommand.Trigger(new DynamicFeedbackViewModel.Parameter(FeedbackState.WithTopicAndCategory, ForCase.Chatbot));
			return;
		}
		if (_supportChatMessageManager.ShouldSendLogsOnButton(viewModel.MacroText))
		{
			_logService.SendLogs(ILogService.SendFrom.ChatBot).SafeFireAndForget((Action<Exception>)null, false);
		}
		await MainThread.InvokeOnMainThreadAsync(() => _supportChatMessageManager.SendMessage(viewModel.MacroText));
	}

	private async Task SendMessage(Unit _)
	{
		if (SendButtonEnabled)
		{
			string message = Message;
			Message = "";
			await MainThread.InvokeOnMainThreadAsync(() => _supportChatMessageManager.SendMessage(message));
		}
	}

	private Task SelectFile(Unit _)
	{
		return SendFileAsync(() => FilePicker.PickAsync(_pickerOptionsProvider.FilePickOptions));
	}

	private Task SelectPhotoGallery(Unit _)
	{
		return SendFileAsync(() => MediaPicker.PickPhotoAsync());
	}

	private Task SelectVideoGallery(Unit _)
	{
		return SendFileAsync(() => MediaPicker.PickVideoAsync());
	}

	private async Task SendFileAsync(Func<Task<FileResult?>> getFile)
	{
		FileResult file = await getFile();
		if (file == null)
		{
			return;
		}
		State = VisualState.IsProgress;
		Result<UploadFileResult, ServiceError> upload = await _beesenderFileUploader.UploadFileAsync(file);
		State = VisualState.Default;
		if (upload.IsSuccess)
		{
			using (CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(2L)))
			{
				await _supportChatMessageManager.WaitForConnectionAsync(cts.Token);
				string text = ((upload.Value.MessageType == MessageType.File) ? ("Отправлен файл " + file.FileName) : "");
				await MainThread.InvokeOnMainThreadAsync(() => _supportChatMessageManager.SendMessage(text, upload.Value));
				return;
			}
		}
		SupportChatSendFileViewModel.Parameter parameter = new SupportChatSendFileViewModel.Parameter(UploadError2StatusCode(upload.Error));
		OpenFileSendErrorCommand.Trigger(_dataBroker.Push(parameter));
		if (await parameter.WaitForResultAsync() == AgreeState.Yes)
		{
			await SendFileAsync(getFile);
		}
	}

	private string UploadError2StatusCode(ServiceError serviceError)
	{
		if (serviceError is UnsuccessfulStatusCodeError<UploadFileResponseDTO> { Content: not null } unsuccessfulStatusCodeError && unsuccessfulStatusCodeError.Content.Error != null)
		{
			if (unsuccessfulStatusCodeError.Content.Error.Contains("Invalid file extension."))
			{
				return "Неверный формат файла";
			}
			return unsuccessfulStatusCodeError.Content.Error;
		}
		return "Отсутствует подключение к интернету, попробуйте позже";
	}

	private Task UpdateMacros(IReadOnlyList<string> macros)
	{
		return MainThread.InvokeOnMainThreadAsync(async delegate
		{
			try
			{
				await _itemViewModelsUpdate.WaitAsync();
				List<string> list = new List<string>(macros);
				int num = list.IndexOf("Вызов оператора");
				if (num >= 0)
				{
					list.RemoveAt(num);
					list.Add("Вызов оператора");
				}
				MacroItemViewModels.ReplaceRange(list.Select((string m) => new MacroItemViewModel(m)));
			}
			finally
			{
				_itemViewModelsUpdate.Release();
			}
		});
	}

	private async Task ApplyCachedMacrosAsync(IReadOnlyList<string> cachedMacros)
	{
		if (cachedMacros.Count > 0)
		{
			if (MacroItemViewModels.Count == 0)
			{
				await UpdateMacros(cachedMacros);
			}
		}
		else if (MacroItemViewModels.Count <= 0)
		{
			IReadOnlyList<string> readOnlyList = await _supportChatMessageManager.GetLastMacrosAsync();
			if (readOnlyList.Count > 0 && MacroItemViewModels.Count == 0)
			{
				await UpdateMacros(readOnlyList);
			}
		}
	}

	private ICollection<BaseSupportChatItemViewModel> ViewModelCollectionFromModels(ICollection<CacheMessage> models)
	{
		List<BaseSupportChatItemViewModel> list = new List<BaseSupportChatItemViewModel>();
		if (models == null || !models.Any())
		{
			return list;
		}
		CacheMessage[] array = models.ToArray();
		bool flag = false;
		DateTime date = models.First().SendTime.Date;
		list.Add(new DateItemViewModel(date));
		for (int i = 0; i < array.Length; i++)
		{
			if (date != array[i].SendTime.Date)
			{
				list.Add(new DateItemViewModel(array[i].SendTime));
				date = array[i].SendTime.Date;
			}
			BaseSupportChatItemViewModel baseSupportChatItemViewModel = MessageViewModelFromType(array[i]);
			if (!baseSupportChatItemViewModel.ShouldBeDisplayed)
			{
				ProcessInvisibleChatItem(baseSupportChatItemViewModel).SafeFireAndForget((Action<Exception>)null, false);
				continue;
			}
			BaseMessageViewModel baseMessageViewModel = list.LastOrDefault((BaseSupportChatItemViewModel vm) => vm is BaseCachedSupportChatItemViewModel) as BaseMessageViewModel;
			bool flag2 = CheckMessageConsequtiveness(baseMessageViewModel, baseSupportChatItemViewModel, i);
			if (flag)
			{
				if (flag2)
				{
					baseMessageViewModel.Layout = MessageLayoutType.Middle;
					(baseSupportChatItemViewModel as BaseMessageViewModel).Layout = MessageLayoutType.Lower;
				}
				else
				{
					flag = false;
				}
			}
			else if (flag2)
			{
				flag = true;
				baseMessageViewModel.Layout = MessageLayoutType.Upper;
				(baseSupportChatItemViewModel as BaseMessageViewModel).Layout = MessageLayoutType.Lower;
			}
			list.Add(baseSupportChatItemViewModel);
		}
		return list;
	}

	public void OnAttachButtonClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("TapFeedbackFileAttachment");
	}

	private void RemoveTypingIndicator()
	{
		if (ItemViewModels.Contains(_writingMessageViewModel))
		{
			ItemViewModels.Remove(_writingMessageViewModel);
		}
	}

	private async void OnMessagesChanged(NotifyCollectionChangedEventArgs? args, ObservableCollection<CacheMessage> messageModels)
	{
		await MainThread.InvokeOnMainThreadAsync(async delegate
		{
			await HandleMessagesChangedOnMainThread(args, messageModels);
		});
	}

	private async Task HandleMessagesChangedOnMainThread(NotifyCollectionChangedEventArgs? args, ObservableCollection<CacheMessage> messageModels)
	{
		try
		{
			if (args != null && args.Action == NotifyCollectionChangedAction.Add && args.NewItems != null && args.OldItems == null && ItemViewModels.Count > 0)
			{
				RemoveTypingIndicator();
			}
			await _itemViewModelsUpdate.WaitAsync();
			if (args != null && args.Action == NotifyCollectionChangedAction.Add && args.NewItems != null && args.OldItems == null && ItemViewModels.Count > 0)
			{
				int num = args.NewStartingIndex;
				List<BaseSupportChatItemViewModel> target = ItemViewModels.ToList();
				List<BaseSupportChatItemViewModel> list = new List<BaseSupportChatItemViewModel>(args.NewItems.Count);
				int num2 = -1;
				foreach (object newItem in args.NewItems)
				{
					int insertionIndex;
					BaseSupportChatItemViewModel baseSupportChatItemViewModel = TryInsertModelIntoViewModelCollection((CacheMessage)newItem, num, target, out insertionIndex);
					if (baseSupportChatItemViewModel.ShouldBeDisplayed)
					{
						if (num2 == -1)
						{
							num2 = insertionIndex;
						}
						list.Add(baseSupportChatItemViewModel);
						num++;
					}
					else
					{
						ProcessInvisibleChatItem(baseSupportChatItemViewModel).SafeFireAndForget((Action<Exception>)null, false);
					}
				}
				if (list.Count > 0 && num2 >= 0)
				{
					ItemViewModels.InsertRange(num2, list);
				}
			}
			else
			{
				if (messageModels.Count == 0 && !ItemViewModels.Contains(_writingMessageViewModel))
				{
					ItemViewModels.Add(_writingMessageViewModel);
				}
				else if (args == null || args.Action != NotifyCollectionChangedAction.Remove)
				{
					RemoveTypingIndicator();
				}
				ItemViewModels.LockedInvoke(delegate(ObservableRangeCollection<BaseSupportChatItemViewModel> ivm)
				{
					ivm.ReplaceRange(ViewModelCollectionFromModels(messageModels));
				});
			}
		}
		finally
		{
			_itemViewModelsUpdate.Release();
		}
		BaseSupportChatItemViewModel TryInsertModelIntoViewModelCollection(CacheMessage message, int index, IList<BaseSupportChatItemViewModel> list2, out int reference)
		{
			BaseSupportChatItemViewModel baseSupportChatItemViewModel2 = MessageViewModelFromType(message);
			if (!baseSupportChatItemViewModel2.ShouldBeDisplayed)
			{
				reference = -1;
				return baseSupportChatItemViewModel2;
			}
			BaseMessageViewModel baseMessageViewModel = baseSupportChatItemViewModel2 as BaseMessageViewModel;
			if (index != 0)
			{
				BaseCachedSupportChatItemViewModel baseCachedSupportChatItemViewModel = list2.OfType<BaseCachedSupportChatItemViewModel>().ElementAtOrDefault(index - 1);
				if (baseCachedSupportChatItemViewModel != null)
				{
					index = list2.IndexOf(baseCachedSupportChatItemViewModel) + 1;
				}
			}
			if (index == 0 && !(baseSupportChatItemViewModel2 is DateItemViewModel) && list2.FirstOrDefault() is DateItemViewModel)
			{
				index = 1;
			}
			if (baseMessageViewModel == null)
			{
				list2.Insert(index, baseSupportChatItemViewModel2);
				reference = index;
				return baseSupportChatItemViewModel2;
			}
			BaseMessageViewModel baseMessageViewModel2 = ((index != 0) ? list2.ElementAtOrDefault(index - 1) : null) as BaseMessageViewModel;
			BaseMessageViewModel baseMessageViewModel3 = list2.ElementAtOrDefault(index) as BaseMessageViewModel;
			bool flag = baseMessageViewModel2 != null && baseMessageViewModel2.Message.Type == baseMessageViewModel.Message.Type && baseMessageViewModel2.Message.SenderName == baseMessageViewModel.Message.SenderName;
			bool flag2 = baseMessageViewModel3 != null && baseMessageViewModel3.Message.Type == baseMessageViewModel.Message.Type && baseMessageViewModel3.Message.SenderName == baseMessageViewModel.Message.SenderName;
			if (flag && flag2)
			{
				baseMessageViewModel.Layout = MessageLayoutType.Middle;
			}
			else if (flag)
			{
				if (baseMessageViewModel2.Layout == MessageLayoutType.Lower)
				{
					baseMessageViewModel2.Layout = MessageLayoutType.Middle;
				}
				if (baseMessageViewModel2.Layout == MessageLayoutType.Single)
				{
					baseMessageViewModel2.Layout = MessageLayoutType.Upper;
				}
				baseMessageViewModel.Layout = MessageLayoutType.Lower;
			}
			else if (flag2)
			{
				if (baseMessageViewModel3.Layout == MessageLayoutType.Upper)
				{
					baseMessageViewModel3.Layout = MessageLayoutType.Middle;
				}
				if (baseMessageViewModel3.Layout == MessageLayoutType.Single)
				{
					baseMessageViewModel3.Layout = MessageLayoutType.Lower;
				}
				baseMessageViewModel.Layout = MessageLayoutType.Upper;
			}
			list2.Insert(index, baseSupportChatItemViewModel2);
			reference = index;
			return baseSupportChatItemViewModel2;
		}
	}

	private bool CheckMessageConsequtiveness(BaseMessageViewModel? prevMessageVM, BaseSupportChatItemViewModel currentItemVM, int currentIndex)
	{
		if (currentIndex != 0 && prevMessageVM != null && currentItemVM is BaseMessageViewModel baseMessageViewModel && baseMessageViewModel.Message.Type == prevMessageVM.Message.Type)
		{
			return prevMessageVM.Message.SenderName == baseMessageViewModel.Message.SenderName;
		}
		return false;
	}

	private BaseSupportChatItemViewModel MessageViewModelFromType(CacheMessage message)
	{
		return message.Type switch
		{
			CacheMessageType.Incoming => new IncomingMessageViewModel(message, MessageLayoutType.Single), 
			CacheMessageType.Outgoing => new OutgoingMessageViewModel(this, message, MessageLayoutType.Single), 
			CacheMessageType.System => new StatusItemViewModel(), 
			CacheMessageType.StructChips => RefundOrderListItemViewModel.New(this, message), 
			CacheMessageType.StructProducts => RefundOrderPopupChatItemViewModel.New(message), 
			_ => throw new NotImplementedException(), 
		};
	}

	public void OnRefundClick(RefundOrderItemViewModel vm)
	{
		MainThread.InvokeOnMainThreadAsync(() => _supportChatMessageManager.SendMessage(vm.Name)).SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task ProcessInvisibleChatItem(BaseSupportChatItemViewModel ivm)
	{
		int num = Interlocked.Increment(ref _invisibleItemProcessing);
		using (Disposable.Create(delegate
		{
			Interlocked.Decrement(ref _invisibleItemProcessing);
		}))
		{
			if (num != 1)
			{
				return;
			}
			YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
			bool isCompleted = awaiter.IsCompleted;
			await awaiter;
			YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
			awaiter = yieldAwaiter;
			awaiter.GetResult();
			await _supportChatMessageManager.WaitForConnectionAsync(default(CancellationToken));
			if (ivm is RefundOrderPopupChatItemViewModel refundOrderPopupChatItemViewModel)
			{
				RefundScreenViewModel.Parameter parameter = new RefundScreenViewModel.Parameter
				{
					Items = refundOrderPopupChatItemViewModel.Items
				};
				OpenRefundCommand.Trigger(_dataBroker.Push(parameter));
				RefundScreenViewModel.Result result = await parameter.WaitForResultAsync();
				if (result.GoBack)
				{
					await _supportChatMessageManager.SendMessage("Назад");
				}
				else
				{
					await _supportChatMessageManager.SendStructuredMessage(result.Text, result.Data);
				}
			}
		}
	}
}
