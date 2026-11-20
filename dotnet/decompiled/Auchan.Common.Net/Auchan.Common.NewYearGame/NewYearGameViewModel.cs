using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Networking;
using Auchan.Common.NewYearGame.DTO;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.ApplicationModel.DataTransfer;

namespace Auchan.Common.NewYearGame;

public class NewYearGameViewModel : ScreenViewModel<NewYearGameViewModel.Parameter>
{
	public class Parameter : BrokeredParameter
	{
		public int Id { get; }

		public Parameter(int id)
		{
			Id = id;
		}
	}

	public enum VisualState
	{
		Default,
		Error,
		InProgress
	}

	private readonly Subject<Unit> _onReload = new Subject<Unit>();

	private readonly IAdminContext _adminContext;

	private readonly ILogService _logService;

	private readonly INewYearGameService _gameService;

	private readonly IErrorTranslator _errorTranslator;

	private readonly IUniversalLinksService _universalLinksService;

	private readonly IInfoMessageService _infoMessageService;

	private readonly ITokenService _tokenService;

	private readonly IEnvironmentManager _environmentManager;

	[CompilerGenerated]
	private UICommand _003CPrepareDelayedNavigationCommand_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CGameUrl_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	public UICommand<string> LoadUrlCommand { get; } = new UICommand<string>();

	public UICommand<string> PostMessageCommand { get; } = new UICommand<string>();

	public UICommand CloseCommand { get; } = new UICommand();

	public UICommand<BrokerToken> OpenCategoryCommand { get; } = new UICommand<BrokerToken>();

	public UICommand PrepareDelayedNavigationCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CPrepareDelayedNavigationCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CPrepareDelayedNavigationCommand_003Ek__BackingField, value))
			{
				_003CPrepareDelayedNavigationCommand_003Ek__BackingField = value;
				RaisePropertyChanged("PrepareDelayedNavigationCommand");
			}
		}
	} = new UICommand();

	public (string username, string password) GameCredentials
	{
		get
		{
			if (_environmentManager.CurrentEnvironment != Auchan.Common.Networking.Environment.Production)
			{
				return (username: "gs", password: "gs");
			}
			return (username: "1", password: "qwe");
		}
	}

	public string GameUrl
	{
		[CompilerGenerated]
		get
		{
			return _003CGameUrl_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CGameUrl_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CGameUrl_003Ek__BackingField = value;
				RaisePropertyChanged("GameUrl");
			}
		}
	} = "";

	public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();

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

	public string BackButtonText => "Назад";

	public string ErrorButtonText => "Повторить";

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
	} = string.Empty;

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
	} = string.Empty;

	public NewYearGameViewModel(BrokerToken brokerToken, IAdminContext adminContext, INewYearGameService gameService, DefaultErrorTranslator defaultErrorTranslator, IUniversalLinksService universalLinksService, ILogService logService, IInfoMessageService infoMessageService, ITokenService tokenService, IEnvironmentManager environmentManager)
		: base(brokerToken)
	{
		_adminContext = adminContext;
		_logService = logService;
		_infoMessageService = infoMessageService;
		_tokenService = tokenService;
		_environmentManager = environmentManager;
		_gameService = gameService;
		_errorTranslator = defaultErrorTranslator;
		_universalLinksService = universalLinksService;
		_onReload.PerformDebouncingTask(LoadGame).Subscribe().AddTo(base.CloseDisposable);
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadGame();
	}

	public async Task LoadGame()
	{
		State = VisualState.InProgress;
		GameUrl = _adminContext.AppConfig?.GameConfigs?.FirstOrDefault((GameConfig gc) => gc.Id == base.Argument.Id)?.Url ?? string.Empty;
		if (string.IsNullOrWhiteSpace(GameUrl))
		{
			State = VisualState.Error;
			(ErrorTitle, ErrorMessage) = _errorTranslator.Translate(new NoDataError());
			return;
		}
		Headers.Clear();
		if (Uri.TryCreate(GameUrl, UriKind.RelativeOrAbsolute, out Uri result) && (result.Host.EndsWith(".auchan.ru") || result.Host == "auchan.ru") && (await _tokenService.SavedToken80()).TryGetValue(out var value))
		{
			Headers["X-Token-CMD"] = value.Token;
		}
		Result<string, DomainError> result2 = await _gameService.NewYearGameToken();
		if (result2.IsFailure)
		{
			State = VisualState.Error;
			(ErrorTitle, ErrorMessage) = _errorTranslator.Translate(result2.Error);
		}
		else
		{
			State = VisualState.Default;
			string subject = GameUrl + "?sessionId=" + result2.Value + "&channel=M";
			LoadUrlCommand.Trigger(subject);
			AppAnalytics.AppMetrica.TrackEvent("tapOnGameBanner");
		}
	}

	protected override async Task OnPaused()
	{
		await base.OnPaused();
		PostMessageCommand.Trigger(NewYearGameMessageHelper.GetMessage(NewYearGameActionType.Pause));
	}

	public bool Loading(string url)
	{
		_logService.LogInfo("NewYearGameViewModel", "Game is loading url: " + url, LogType.UserAction, SystemType.MobileApp);
		if (url.ContainsIgnoreCase(GameUrl))
		{
			return false;
		}
		if (new global::_003C_003Ez__ReadOnlyArray<string>(new string[4] { "about:blank", "about:srcdoc", "https://cdn.inappstory.ru/", "https://cs.inappstory.ru/" }).Any(url.Contains))
		{
			return false;
		}
		if (_universalLinksService.ShouldHandleLink(url))
		{
			if (false)
			{
			}
			PrepareDelayedNavigationCommand.Trigger();
			_universalLinksService.HandleLink(url);
			return true;
		}
		OpenSystemBrowserAsync(url).SafeFireAndForget((Action<Exception>)null, false);
		return true;
		static async Task OpenSystemBrowserAsync(string uriString)
		{
			try
			{
				await Browser.Default.OpenAsync(new Uri(uriString), new BrowserLaunchOptions
				{
					LaunchMode = BrowserLaunchMode.External
				});
			}
			catch (Exception)
			{
			}
		}
	}

	public void Finished(string url)
	{
	}

	public void OnError()
	{
		State = VisualState.Error;
		ErrorTitle = "Упс! Что-то пошло не так.";
		ErrorMessage = "Небольшие технические проблемы,\nпопробуйте обновить экран.";
	}

	public void OnReload()
	{
		GameUrl = _adminContext.AppConfig?.GameConfigs?.FirstOrDefault((GameConfig gc) => gc.Id == base.Argument.Id)?.Url ?? string.Empty;
		_onReload.OnNext(Unit.Default);
	}

	public void OnMessageReceived(string message)
	{
		GameMessageDTO dTO = NewYearGameMessageHelper.GetDTO(message);
		if (dTO != null)
		{
			switch (dTO.Type)
			{
			case NewYearGameActionType.WriteClipboard:
				Clipboard.SetTextAsync(dTO.ClipboardContent).SafeFireAndForget((Action<Exception>)null, false);
				_infoMessageService.ShowSnackbar("Скопировано в буфер обмена", SnackbarStyle.Success);
				break;
			case NewYearGameActionType.Close:
				CloseCommand.Trigger();
				break;
			}
		}
	}
}
