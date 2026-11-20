using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Home;
using Auchan.Common.LoyaltyProgram;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel.DataTransfer;

namespace Auchan.Common.Splash;

public class SplashViewModel : ScreenViewModel, IYandexMetricaScreenViewModel, IScreenViewModel
{
	public enum VisualState
	{
		Default,
		Error,
		Maintenance
	}

	private readonly IAdminContext _adminContext;

	private readonly Lazy<IApplicationInitializer> _applicationInitializer;

	private readonly IUserContext _userContext;

	private readonly Lazy<IApplicationStateManager> _applicationStateManager;

	private readonly Lazy<IRestartService> _restartService;

	private readonly Lazy<ILottieFetcher> _lottieFetcher;

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	private readonly IHomeScreenTracker _homeScreenTracker;

	private readonly Lazy<ILoyaltyCardManager> _loyaltyCardManager;

	private readonly Subject<Unit> _retryInput = new Subject<Unit>();

	private string _promocode = string.Empty;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private ThemeHelper.ThemeEnum _003CTheme_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CRetryButtonText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CQRCodeButtonText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CQrCode_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CMaintenanceInfoText_003Ek__BackingField;

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	}

	public ThemeHelper.ThemeEnum Theme
	{
		[CompilerGenerated]
		get
		{
			return _003CTheme_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CTheme_003Ek__BackingField != value)
			{
				_003CTheme_003Ek__BackingField = value;
				RaisePropertyChanged("Theme");
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
		set
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
		set
		{
			if (!string.Equals(_003CErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorMessage");
			}
		}
	} = "Небольшие технические проблемы, попробуйте обновить экран.";

	public string RetryButtonText
	{
		[CompilerGenerated]
		get
		{
			return _003CRetryButtonText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CRetryButtonText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CRetryButtonText_003Ek__BackingField = value;
				RaisePropertyChanged("RetryButtonText");
			}
		}
	} = "Повторить";

	public string QRCodeButtonText
	{
		[CompilerGenerated]
		get
		{
			return _003CQRCodeButtonText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CQRCodeButtonText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CQRCodeButtonText_003Ek__BackingField = value;
				RaisePropertyChanged("QRCodeButtonText");
			}
		}
	} = "Показать карту лояльности";

	public string LoyaltyCardSubText => "";

	public string LoyaltyCardSubTextForSmallDisplays => "";

	public string QrCode
	{
		[CompilerGenerated]
		get
		{
			return _003CQrCode_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CQrCode_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CQrCode_003Ek__BackingField = value;
				RaisePropertyChanged("IsQrCodeEmpty");
				RaisePropertyChanged("QrCode");
			}
		}
	} = "";

	public bool IsQRCodeButtonVisible
	{
		get
		{
			if (_userContext.Authorized)
			{
				return _userContext.Profile != null;
			}
			return false;
		}
	}

	public bool IsQrCodeEmpty => string.IsNullOrEmpty(QrCode);

	public string MaintenanceInfoText
	{
		[CompilerGenerated]
		get
		{
			return _003CMaintenanceInfoText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CMaintenanceInfoText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CMaintenanceInfoText_003Ek__BackingField = value;
				RaisePropertyChanged("IsMaintenanceInfoAvailable");
				RaisePropertyChanged("MaintenanceInfoText");
			}
		}
	} = string.Empty;

	public bool IsMaintenanceInfoAvailable => !string.IsNullOrEmpty(MaintenanceInfoText);

	public UICommand OpenMainScreenCommand { get; } = new UICommand();

	public UICommand OpenQRCodeCommand { get; } = new UICommand();

	public UICommand OpenSafeEntranceScreenCommand { get; } = new UICommand();

	public bool IsCustomSplashAnimationEnabled
	{
		get
		{
			if (_userContext.Authorized)
			{
				return !string.IsNullOrWhiteSpace(_adminContext.CustomSplashAnimationKey);
			}
			return false;
		}
	}

	public string CustomSplashAnimationUrl => _adminContext.CustomSplashAnimationKey;

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "";

	string IYandexMetricaScreenViewModel.ScreenName => "noConnection";

	public SplashViewModel(IAdminContext adminContext, Lazy<IApplicationInitializer> applicationInitializer, IUserContext userContext, Lazy<IApplicationStateManager> applicationStateManager, Lazy<ILoyaltyCardManager> loyaltyCardManager, Lazy<IRestartService> restartService, Lazy<ILottieFetcher> lottieFetcher, Lazy<IInfoMessageService> infoMessageService, IHomeScreenTracker homeScreenTracker)
	{
		_adminContext = adminContext;
		_loyaltyCardManager = loyaltyCardManager;
		_applicationInitializer = applicationInitializer;
		_userContext = userContext;
		_applicationStateManager = applicationStateManager;
		_restartService = restartService;
		_lottieFetcher = lottieFetcher;
		_infoMessageService = infoMessageService;
		_homeScreenTracker = homeScreenTracker;
		_retryInput.PerformDebouncingTask(Retry).Subscribe().AddTo(base.CloseDisposable);
	}

	public void OnRetryClick()
	{
		_retryInput.OnNext(Unit.Default);
	}

	public void OnQRCodeClick()
	{
		OpenQRCodeCommand.Trigger();
	}

	public override NavigationPossibilityType OnNavigateFrom()
	{
		return NavigationPossibilityType.Delayed;
	}

	protected override async Task Start()
	{
		await base.Start();
		if (_homeScreenTracker.Shown)
		{
			OpenMainScreenCommand.Trigger();
			return;
		}
		await Task.WhenAll(LoadQrCode(), InitializeApp());
	}

	private async Task LoadQrCode()
	{
		Result<LoyaltyCardEntity, DomainError> result = await _loyaltyCardManager.Value.GetLoyaltyCard(CancellationToken.None);
		if (result.IsSuccess)
		{
			QrCode = result.Value.QrCode ?? string.Empty;
		}
	}

	public void OnApplicationStarting()
	{
		_applicationStateManager.Value.OnResumedAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private Task Retry()
	{
		_restartService.Value.Restart();
		return Task.CompletedTask;
	}

	private async Task InitializeApp()
	{
		State = VisualState.Default;
		AppInitializationResult appInitializationResult = await _applicationInitializer.Value.Initialize();
		if (_adminContext.AppConfigIsNotNull && _adminContext.AppConfig?.LoadScreenConfig != null && IsCustomSplashAnimationEnabled)
		{
			Task.Run(() => _lottieFetcher.Value.FetchStreamAsync(CustomSplashAnimationUrl)).SafeFireAndForget((Action<Exception>)null, false);
		}
		else if (!string.IsNullOrEmpty(CustomSplashAnimationUrl))
		{
			Task.Run(() => _lottieFetcher.Value.RemoveFromCache(CustomSplashAnimationUrl)).SafeFireAndForget((Action<Exception>)null, false);
		}
		State = appInitializationResult.SplashScreenState;
		SetupMaintenanceIfNeeded(appInitializationResult);
		SetupErrorIfNeeded(appInitializationResult);
		NavigateAfterInit(appInitializationResult.SplashScreenNextNavigation);
	}

	private void SetupMaintenanceIfNeeded(AppInitializationResult appInitializationResult)
	{
		if (appInitializationResult.SplashScreenState == VisualState.Maintenance)
		{
			_promocode = _adminContext.AppConfig?.MaintenancePromocode ?? string.Empty;
			string text = _adminContext.AppConfig?.MaintenancePromocodeMessage ?? string.Empty;
			if (!string.IsNullOrEmpty(_promocode))
			{
				text = text.Replace(_promocode, "<b>" + _promocode + "</b>");
			}
			MaintenanceInfoText = text.Replace("\u2028", "<br/>").Replace("\n", "<br/>");
		}
	}

	private void SetupErrorIfNeeded(AppInitializationResult appInitializationResult)
	{
		if (appInitializationResult.HasError)
		{
			ErrorTitle = appInitializationResult.InitError.Title;
			ErrorMessage = appInitializationResult.InitError.Message;
			RetryButtonText = appInitializationResult.InitError.RetryButtonText;
		}
	}

	private void NavigateAfterInit(SplashScreenNextNavigation splashScreenNextNavigation)
	{
		switch (splashScreenNextNavigation)
		{
		case SplashScreenNextNavigation.MainScreen:
			OpenMainScreenCommand.Trigger();
			break;
		case SplashScreenNextNavigation.SafeEntrance:
			OpenSafeEntranceScreenCommand.Trigger();
			break;
		default:
			throw new ArgumentOutOfRangeException();
		case SplashScreenNextNavigation.None:
			break;
		}
	}

	public void OnInformerClick()
	{
		DoAsync().SafeFireAndForget((Action<Exception>)null, false);
		async Task DoAsync()
		{
			if (!string.IsNullOrEmpty(_promocode))
			{
				await Clipboard.SetTextAsync(_promocode);
				_infoMessageService.Value.ShowAlert("Промокод", "скопирован в буфер обмена", AlertButtons.OkButtons);
			}
		}
	}
}
