using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Akavache.Sqlite3.Internal;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Feedback;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.SupportChat.DTO;
using Auchan.Common.SupportChat.Models;
using CSharpFunctionalExtensions;
using EBind;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Storage;

namespace Auchan.Common.SupportChat;

public class SupportChatMessageManager : IApplicationStateObserver
{
	private const string LEAVE_FEEDBACK_BUTTON = "Оставить отзыв";

	private const string SEND_LOGS_BUTTON_PART = "не помогло";

	public const string IS_SUPPORT_CHAT_ONBOARDING_SHOWN_CACHE_KEY = "IS_SUPPORT_CHAT_ONBOARDING_SHOWN_CACHE_KEY";

	public const string DEFAULT_OPERATOR_NAME = "АШАН-бот";

	public const string DEFAULT_OPERATOR_URL = "Default";

	private readonly Lazy<SupportChatMessageRepository> _repository;

	private readonly IUserContext _userContext;

	private readonly Lazy<IAdminContext> _adminContext;

	private readonly Lazy<IFeedbackContactsProvider> _feedbackContactsProvider;

	private readonly Lazy<ISupportChatMessageService> _webocketService;

	private readonly Lazy<ISupportChatAPIService> _APIService;

	private volatile int _messageCountRequestId;

	private int _initialMessageSent;

	private volatile TaskCompletionSource<bool> _connectingTcs = new TaskCompletionSource<bool>();

	private AsyncLock _receiveMessageLock = new AsyncLock();

	private readonly CompositeDisposable _closeConnectionDisposables = new CompositeDisposable();

	private int _unreadMessageCount;

	private int UnreadMessageCount
	{
		get
		{
			return _unreadMessageCount;
		}
		set
		{
			if (_unreadMessageCount != value)
			{
				_unreadMessageCount = value;
				this.OnUnreadMessagesCountChanged?.Invoke(this, value);
			}
		}
	}

	public event EventHandler<CacheMessage>? OnMessageUpdated;

	public event EventHandler<List<string>>? OnButtonsUpdated;

	public event EventHandler? OnDisconnected;

	public event EventHandler<int>? OnUnreadMessagesCountChanged;

	public SupportChatMessageManager(Lazy<SupportChatMessageRepository> repository, Lazy<ISupportChatMessageService> service, IUserContext userContext, Lazy<IAdminContext> adminContext, Lazy<IFeedbackContactsProvider> feedbackContactsProvider, Lazy<ISupportChatAPIService> supportChatAPI)
	{
		_repository = repository;
		_webocketService = service;
		_userContext = userContext;
		_adminContext = adminContext;
		_feedbackContactsProvider = feedbackContactsProvider;
		_userContext.AfterLoggedOut += async delegate
		{
			await _repository.Value.ClearMacroCachesAsync();
			Preferences.Clear("IS_SUPPORT_CHAT_ONBOARDING_SHOWN_CACHE_KEY");
			await Task.Run(() => Disconnect());
		};
		OnButtonsUpdated += delegate(object? sender, List<string> macros)
		{
			_repository.Value.UpdateMacrosAsync(macros).SafeFireAndForget((Action<Exception>)null, false);
		};
		OnMessageUpdated += CheckIfThereReservedMessageUpdated;
		_APIService = supportChatAPI;
	}

	public async Task<Result<object, DomainError>> ConnectAsync()
	{
		Disconnect();
		_webocketService.Value.OnMessageReceived += new DisposableDelegate<EventHandler<BaseWSMessageDTO>>(delegate(object? s, BaseWSMessageDTO args)
		{
			ReceiveMessage(args).SafeFireAndForget((Action<Exception>)null, false);
		}, delegate(EventHandler<BaseWSMessageDTO> d)
		{
			_webocketService.Value.OnMessageReceived -= d;
		}).AddTo(_closeConnectionDisposables);
		_webocketService.Value.OnDisconnected += new DisposableDelegate<EventHandler>(delegate(object? o, EventArgs e)
		{
			this.OnDisconnected?.Invoke(this, e);
		}, delegate(EventHandler d)
		{
			_webocketService.Value.OnDisconnected -= d;
		}).AddTo(_closeConnectionDisposables);
		await _webocketService.Value.ConnectAsync();
		_connectingTcs.TrySetResult(result: true);
		return Result.Success<object, DomainError>(new object());
	}

	public Result<object, DomainError> Disconnect()
	{
		Interlocked.Exchange(ref _connectingTcs, new TaskCompletionSource<bool>()).TrySetResult(result: false);
		_closeConnectionDisposables.Clear();
		_webocketService.Value.Disconnect();
		Interlocked.Exchange(ref _initialMessageSent, 0);
		return Result.Success<object, DomainError>(new object());
	}

	public async Task WaitForConnectionAsync(CancellationToken cancellationToken)
	{
		using (cancellationToken.Register(delegate
		{
			_connectingTcs.TrySetCanceled();
		}))
		{
			try
			{
				while (!(await _connectingTcs.Task))
				{
				}
			}
			catch (OperationCanceledException)
			{
			}
		}
	}

	public async Task<Result<ObservableRangeCollection<CacheMessage>, DomainError>> GetMessages()
	{
		return Result.Success<ObservableRangeCollection<CacheMessage>, DomainError>(await _repository.Value.GetMessages());
	}

	public Task<IReadOnlyList<string>> GetMacrosAsync()
	{
		return _repository.Value.GetMacrosAsync();
	}

	public Task<IReadOnlyList<string>> GetLastMacrosAsync()
	{
		return _repository.Value.GetLastMacrosAsync();
	}

	public Task ClearOperatorInfoAsync()
	{
		return _repository.Value.ClearOperatorInfoAsync();
	}

	public async Task<Result<int, DomainError>> GetUnreadMessageCount()
	{
		if (!_adminContext.Value.AppConfigIsNotNull || !_adminContext.Value.AppConfig.IsChatEnabled)
		{
			return 0;
		}
		if (_webocketService.Value.IsConnected)
		{
			return UnreadMessageCount;
		}
		Result<int, DomainError> result = await _APIService.Value.GetUnreadMessageCount();
		if (result.IsSuccess)
		{
			UnreadMessageCount = result.Value;
		}
		return result;
	}

	public Task<Result<ChatStatusResponseDTO, DomainError>> GetStatus()
	{
		return _APIService.Value.GetStatus();
	}

	private async Task ReceiveMessage(BaseWSMessageDTO message)
	{
		if (!MainThread.IsMainThread)
		{
			throw new InvalidOperationException("main thread required");
		}
		using (await _receiveMessageLock.LockAsync(default(CancellationToken)))
		{
			if (!(message is MessageReceivedWSDTO messageReceivedWSDTO))
			{
				if (!(message is NewMessageFromQueueWSDTO newDTO))
				{
					return;
				}
				if (newDTO.Data.OutSeq.HasValue)
				{
					_webocketService.Value.SendAcknowledgeAsync(newDTO.Data.OutSeq.GetValueOrDefault()).SafeFireAndForget((Action<Exception>)null, false);
					if (await _repository.Value.MessageExists(newDTO.Data.OutSeq))
					{
						return;
					}
				}
				UploadFileResult ufr = null;
				CacheMessageType cmt = CacheMessageType.Incoming;
				if (newDTO.Data.Type == WSDataContentType.Image && newDTO.Data.Content.Text != null)
				{
					string text = newDTO.Data.Content.Text;
					ufr = new UploadFileResult(0, text, text, 0L, "unknown");
					newDTO.Data.Content.Text = "";
				}
				if (newDTO.Data.Type == WSDataContentType.OperatorInfo)
				{
					cmt = CacheMessageType.System;
					if (IsBot(newDTO.Data.Content.OperatorInfo))
					{
						await _repository.Value.ClearOperatorInfoAsync();
						return;
					}
					await _repository.Value.UpdateOperatorInfoAsync(newDTO.Data.Content.OperatorInfo);
				}
				StructMessageReceivedWSDTO structMessageReceivedWSDTO = newDTO.Data.Content.AsStructuredMessage();
				if ((object)structMessageReceivedWSDTO != null)
				{
					cmt = structMessageReceivedWSDTO.CacheMessageType;
				}
				await ClearStructMessagesAsync();
				SupportChatMessageRepository value = _repository.Value;
				CacheMessageType type = cmt;
				WSDataContentType type2 = newDTO.Data.Type;
				string text2 = newDTO.Data.Content.Text;
				int? outSeq = newDTO.Data.OutSeq;
				CacheMessage cacheMessage = await value.SaveMessage(type, type2, text2, MessageStatusType.Sent, outSeq, await _repository.Value.GetOperatorAvatarAsync(), await _repository.Value.GetOperatorNameAsync(), ufr);
				if (newDTO.Data.Type != WSDataContentType.Unknown)
				{
					List<string> buttons = newDTO.Data.Content.Buttons;
					if (buttons.Count == 0)
					{
						IReadOnlyList<string> readOnlyList = await _repository.Value.GetMacrosAsync();
						if (readOnlyList.Count != 1 || !IsLeaveFeedbackButton(readOnlyList.FirstOrDefault()))
						{
							this.OnButtonsUpdated?.Invoke(this, buttons);
						}
					}
					else
					{
						this.OnButtonsUpdated?.Invoke(this, buttons);
					}
				}
				this.OnMessageUpdated?.Invoke(this, cacheMessage);
			}
			else
			{
				CacheMessage cacheMessage2 = await _repository.Value.UpdateMessage(messageReceivedWSDTO.Meta.MessageId, MessageStatusType.Sent);
				if (cacheMessage2 != null)
				{
					this.OnMessageUpdated?.Invoke(this, cacheMessage2);
				}
			}
		}
	}

	public async Task<Result<ObservableRangeCollection<CacheMessage>, DomainError>> SendInitialMessage(Action showWritingMessage)
	{
		UnreadMessageCount = 0;
		if (_repository.Value.Messages.Count > 0)
		{
			CacheMessage lastMessage = _repository.Value.Messages.LastOrDefault();
			if (lastMessage != null && lastMessage.DataContentType == WSDataContentType.Buttons && lastMessage.Text.ContainsIgnoreCase("я с удовольствием вам помогу"))
			{
				await _repository.Value.UpdateMacrosAsync(new List<string>());
				await _repository.Value.DeleteMessage(lastMessage.Id);
				lastMessage = _repository.Value.Messages.LastOrDefault();
				if (lastMessage != null && lastMessage.Text.ContainsIgnoreCase("Рад приветствовать"))
				{
					await _repository.Value.DeleteMessage(lastMessage.Id);
				}
			}
			showWritingMessage();
		}
		string s = "Начать чат. (Сервисное сообщение)";
		if (Interlocked.CompareExchange(ref _initialMessageSent, 1, 0) != 0)
		{
			return _repository.Value.Messages;
		}
		CacheMessage message = new CacheMessage
		{
			Type = CacheMessageType.Outgoing,
			DataContentType = WSDataContentType.Text,
			Id = Guid.NewGuid(),
			Text = Encoding.Unicode.GetString(Encoding.Unicode.GetBytes(s)).Replace("\n", "<br/>"),
			Status = MessageStatusType.InProgress,
			SendTime = DateTime.Now
		};
		if ((await _webocketService.Value.SendMessage(message)).IsFailure)
		{
			OnErrorReceived().SafeFireAndForget((Action<Exception>)null, false);
		}
		return _repository.Value.Messages;
	}

	public async Task<Result<ObservableRangeCollection<CacheMessage>, DomainError>> SendMessage(string text, UploadFileResult? upload = null)
	{
		if (!MainThread.IsMainThread)
		{
			throw new InvalidOperationException("main thread required");
		}
		ClearMacro();
		await ClearStructMessagesAsync();
		UnreadMessageCount = 0;
		CacheMessage message = await _repository.Value.SaveMessage(CacheMessageType.Outgoing, upload?.MessageType.ToWSDataContentType() ?? WSDataContentType.Text, text, MessageStatusType.InProgress, null, null, null, upload);
		this.OnMessageUpdated?.Invoke(this, message);
		Result<CacheMessage, DomainError> result = await _webocketService.Value.SendMessage(message);
		await _repository.Value.UpdateMessage(message.Id, (!result.IsSuccess) ? MessageStatusType.Error : MessageStatusType.Sent);
		this.OnMessageUpdated?.Invoke(this, message);
		if (result.IsFailure)
		{
			OnErrorReceived().SafeFireAndForget((Action<Exception>)null, false);
		}
		return _repository.Value.Messages;
	}

	public async Task<Result<ObservableRangeCollection<CacheMessage>, DomainError>> SendStructuredMessage(string text, string data)
	{
		if (!MainThread.IsMainThread)
		{
			throw new InvalidOperationException("main thread required");
		}
		ClearMacro();
		await ClearStructMessagesAsync();
		UnreadMessageCount = 0;
		CacheMessage message = await _repository.Value.SaveMessage(CacheMessageType.Outgoing, WSDataContentType.Text, text, MessageStatusType.InProgress);
		this.OnMessageUpdated?.Invoke(this, message);
		CacheMessage message2 = new CacheMessage
		{
			Type = message.Type,
			DataContentType = message.DataContentType,
			Id = message.Id,
			Text = data,
			Status = message.Status,
			SendTime = message.SendTime,
			UploadFileResult = message.UploadFileResult,
			SequenceNumber = message.SequenceNumber
		};
		Result<CacheMessage, DomainError> result = await _webocketService.Value.SendMessage(message2);
		await _repository.Value.UpdateMessage(message.Id, (!result.IsSuccess) ? MessageStatusType.Error : MessageStatusType.Sent);
		this.OnMessageUpdated?.Invoke(this, message);
		if (result.IsFailure)
		{
			OnErrorReceived().SafeFireAndForget((Action<Exception>)null, false);
		}
		return _repository.Value.Messages;
	}

	public async Task<Result<ObservableRangeCollection<CacheMessage>, DomainError>> ResendMessage(CacheMessage message)
	{
		UnreadMessageCount = 0;
		Result<CacheMessage, DomainError> result = await _webocketService.Value.SendMessage(message);
		await _repository.Value.UpdateMessage(message.Id, (!result.IsSuccess) ? MessageStatusType.Error : MessageStatusType.Sent);
		this.OnMessageUpdated?.Invoke(this, message);
		return _repository.Value.Messages;
	}

	public async Task<Result<ObservableRangeCollection<CacheMessage>, DomainError>> DeleteMessage(CacheMessage message)
	{
		await _repository.Value.DeleteMessage(message.Id);
		return _repository.Value.Messages;
	}

	private async Task OnErrorReceived()
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		string text = _feedbackContactsProvider.Value.Phone;
		if (text.StartsWith("8"))
		{
			text = "+7" + text.Substring("8".Length);
		}
		CacheMessage e = await _repository.Value.SaveMessage(CacheMessageType.Incoming, WSDataContentType.Text, $"К сожалению, на данный момент чат не доступен. Вы можете просто позвонить {text} или написать нам, перейдя по кнопке <b>\"{"Оставить отзыв"}\"</b>.", MessageStatusType.Sent);
		this.OnMessageUpdated?.Invoke(this, e);
		this.OnButtonsUpdated?.Invoke(this, new List<string> { "Оставить отзыв" });
	}

	private void CheckIfThereReservedMessageUpdated(object? sender, CacheMessage e)
	{
		if (e.Text == "К сожалению все операторы сейчас заняты, пожалуйста, воспользуйтесь кнопкой \"Оставить отзыв\".")
		{
			this.OnButtonsUpdated?.Invoke(this, new List<string> { "Оставить отзыв" });
		}
	}

	public bool IsLeaveFeedbackButton(string? buttonName)
	{
		return buttonName == "Оставить отзыв";
	}

	public bool ShouldSendLogsOnButton(string buttonName)
	{
		return buttonName.ContainsIgnoreCase("не помогло");
	}

	private async Task UpdateUnreadMessagesLoop()
	{
		TimeSpan twoMinutes = TimeSpan.FromMinutes(2L);
		int id = ++_messageCountRequestId;
		while (id == _messageCountRequestId)
		{
			await GetUnreadMessageCount();
			await Task.Delay(twoMinutes);
		}
	}

	public Task OnResumedAsync()
	{
		return Task.Run(() => UpdateUnreadMessagesLoop());
	}

	public void OnPaused()
	{
		_messageCountRequestId++;
	}

	public void ClearMacro()
	{
		this.OnButtonsUpdated?.Invoke(this, new List<string>());
		_repository.Value.ClearMacroCachesAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	public Task ClearStructMessagesAsync()
	{
		return _repository.Value.ClearStructMessagesAsync();
	}

	private bool IsBot(WSDataOperatorDTO? operatorInfo)
	{
		if (operatorInfo != null && operatorInfo.Name != null && !(operatorInfo.Name == "ЧатБотОдин") && !operatorInfo.Name.ToLower().EndsWith(" бот"))
		{
			return operatorInfo.Name.ToLower().EndsWith("-бот");
		}
		return true;
	}
}
