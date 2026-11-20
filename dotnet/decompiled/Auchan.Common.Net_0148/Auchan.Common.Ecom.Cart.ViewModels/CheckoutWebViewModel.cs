using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using Auchan.Common.Recommendations;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Ecom.Cart.ViewModels;

[RequiresAuthorization]
public class CheckoutWebViewModel : ScreenViewModel
{
	public class Parameter
	{
		public required string Url { get; init; }

		public required string ReturnUrlSubstring { get; init; }

		public required string FailureUrlSubstring { get; init; }

		public required IEnumerable<string> OrderIds { get; init; }
	}

	public enum VisualState
	{
		Default,
		InProgress,
		Error
	}

	private const string MIR_PAY_APP_REQUIRED = "Необходимо установить приложение Mir Pay.";

	private const string T_BANK_APP_REQUIRED = "Необходимо установить приложение T-Банк.";

	private readonly string[] _urlsToIgnore = new string[3] { "favicon", "about:blank", "https://ru.id.group-ib.com/id.html" };

	private readonly string[] _urlsToOpenSystemBrowser = new string[2] { "sberbank.com/ru/certificates", "cdn.tbank.ru/static/documents/" };

	private readonly string _mirPayHost = "pay.mironline.ru";

	private readonly IReadOnlyList<string> _tpayStartUrls = new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "https://o.tbank.ru/", "https://www.tinkoff.ru/tpay" });

	private readonly IReadOnlyList<string> _goBackUrls = new global::_003C_003Ez__ReadOnlySingleElementList<string>("https://www.auchan.ru");

	private readonly Parameter _parameter;

	private readonly ICheckoutService _checkoutService;

	private readonly ILogService _logService;

	private readonly IInfoMessageService _infoMessageService;

	private readonly IAppAvailabilityService _appAvailabilityService;

	private readonly ITrackingService _trackingService;

	private readonly Lazy<AppMetrica> _appMetrica;

	private readonly IUserContext _userContext;

	private readonly Subject<string> _redirectToResult = new Subject<string>();

	private bool _onPayAppNotFoundShown;

	private bool _paymentCompleted;

	[CompilerGenerated]
	private bool _003CTabBarVisible_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CUrl_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorButtonTitle_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<string> _003COpenThirdPartyAppCommand_003Ek__BackingField;

	public override bool TabBarVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CTabBarVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			if (_003CTabBarVisible_003Ek__BackingField != value)
			{
				_003CTabBarVisible_003Ek__BackingField = value;
				RaisePropertyChanged("TabBarVisible");
			}
		}
	}

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return _003CTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitle_003Ek__BackingField = value;
				RaisePropertyChanged("Title");
			}
		}
	} = "Оплата";

	public string Url
	{
		[CompilerGenerated]
		get
		{
			return _003CUrl_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CUrl_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CUrl_003Ek__BackingField = value;
				RaisePropertyChanged("Url");
			}
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
	} = VisualState.InProgress;

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
	} = "Ошибка";

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
	} = "Упс";

	public string ErrorButtonTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorButtonTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorButtonTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorButtonTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorButtonTitle");
			}
		}
	} = "Повторить";

	public UICommand<CheckoutSuccessViewModel.Parameter> SuccessfulPaymentCommand { get; } = new UICommand<CheckoutSuccessViewModel.Parameter>();

	public UICommand ReturnToCheckoutCommand { get; } = new UICommand();

	public UICommand ReturnToCartCommand { get; } = new UICommand();

	public UICommand ReloadCommand { get; } = new UICommand();

	public UICommand<string> OpenThirdPartyAppCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenThirdPartyAppCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenThirdPartyAppCommand_003Ek__BackingField, value))
			{
				_003COpenThirdPartyAppCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenThirdPartyAppCommand");
			}
		}
	} = new UICommand<string>();

	public UICommand<CheckoutOrderNotPaidViewModel.Parameter> OpenOrderNotPaidCommand { get; } = new UICommand<CheckoutOrderNotPaidViewModel.Parameter>();

	public UICommand OnBackCommand { get; } = new UICommand();

	public CheckoutWebViewModel(Parameter parameter, ICheckoutService checkoutService, ILogService logService, IInfoMessageService infoMessageService, IAppAvailabilityService appAvailabilityService, IUniversalLinksService universalLinksService, IUserContext userContext, ITrackingService trackingService, Lazy<AppMetrica> appMetrica)
	{
		_parameter = parameter;
		_checkoutService = checkoutService;
		_logService = logService;
		_infoMessageService = infoMessageService;
		_appAvailabilityService = appAvailabilityService;
		_userContext = userContext;
		_trackingService = trackingService;
		_appMetrica = appMetrica;
		Url = parameter.Url;
		universalLinksService.WeakOnLinkReceived += OnLinkReceived;
	}

	protected override async Task Start()
	{
		ProfileModel profile = _userContext.Profile;
		LoyaltyCardEntity loyaltyCard = _userContext.LoyaltyCard;
		if (profile != null && loyaltyCard != null)
		{
			await _trackingService.SetCustomer(profile, loyaltyCard);
		}
		_redirectToResult.PerformDebouncingTask(OnRedirectToReturnUrl).Subscribe().AddTo(base.CloseDisposable);
		OnBackCommand.Subscribe(delegate
		{
			OnPaymentFailure(_parameter.OrderIds);
		}).AddTo(base.CloseDisposable);
		await base.Start();
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		_appMetrica.Value.TrackEvent("paymentScreenView");
	}

	public bool OnPageLoading(string url)
	{
		_logService.LogInfo("CheckoutWebViewModel", "OnPageLoading: " + url, LogType.UserAction, SystemType.MobileApp);
		if (_urlsToIgnore.Any(url.Contains))
		{
			return true;
		}
		if (url.Contains(_mirPayHost))
		{
			if (_appAvailabilityService.MirPayAvailable)
			{
				OpenThirdPartyAppCommand.Trigger(url);
			}
			else
			{
				OnPayAppNotFound("Необходимо установить приложение Mir Pay.").SafeFireAndForget((Action<Exception>)null, false);
			}
			return true;
		}
		if (_goBackUrls.Any(url.StartsWith))
		{
			OnBackCommand.Trigger();
			return true;
		}
		if (_tpayStartUrls.Any(url.StartsWith) && !_appAvailabilityService.TPayAvailable)
		{
			OnPayAppNotFound("Необходимо установить приложение T-Банк.").SafeFireAndForget((Action<Exception>)null, false);
			return true;
		}
		if (IAppAvailabilityService.TPayDeeplinks.Any(url.StartsWith))
		{
			if (_appAvailabilityService.TPayAvailable)
			{
				OpenThirdPartyAppCommand.Trigger(url);
			}
			else
			{
				OnPayAppNotFound("Необходимо установить приложение T-Банк.").SafeFireAndForget((Action<Exception>)null, false);
			}
			return true;
		}
		if (Uri.TryCreate(url, default(UriCreationOptions), out Uri result) && result.Scheme.StartsWith("bank") && result.Scheme.Substring("bank".Length).All((char i) => char.IsDigit(i)))
		{
			ProcessPaymentUri(result).SafeFireAndForget((Action<Exception>)null, false);
			return true;
		}
		if (_urlsToOpenSystemBrowser.Any(url.Contains))
		{
			Browser.OpenAsync(url).SafeFireAndForget((Action<Exception>)null, false);
			return true;
		}
		try
		{
			if (url.Contains(_parameter.ReturnUrlSubstring))
			{
				_redirectToResult.OnNext(url);
				return true;
			}
			if (url.Contains(_parameter.FailureUrlSubstring))
			{
				AppAnalytics.AppMetrica.FailurePaymentScreenView();
				OnRedirectToFailureUrl(url);
				return true;
			}
		}
		catch (Exception)
		{
		}
		return false;
	}

	private async Task ProcessPaymentUri(Uri paymentUri)
	{
		if (await TryOpenAsync(paymentUri))
		{
			_appMetrica.Value.TrackGoingToExternalBank(appLaunched: true, _parameter.OrderIds);
			await _infoMessageService.ShowDialogAsync("Внимание!", "Запущено приложение банка", AlertButtons.OkButtons);
		}
		else
		{
			_appMetrica.Value.TrackGoingToExternalBank(appLaunched: false, _parameter.OrderIds);
			await _infoMessageService.ShowDialogAsync("Приложение банка не найдено", "Выберите оплату в браузере или установите приложение банка", AlertButtons.OkButtons);
		}
		static async Task<bool> TryOpenAsync(Uri uri)
		{
			try
			{
				return await Launcher.Default.OpenAsync(uri);
			}
			catch (Exception)
			{
				return false;
			}
		}
	}

	private void OnLinkReceived(object? sender, UniversalLinkServiceLinkEvent e)
	{
		string link = e.Link;
		try
		{
			if (link.Contains(_parameter.ReturnUrlSubstring))
			{
				e.Handled = true;
				_redirectToResult.OnNext(link);
			}
			if (link.Contains(_parameter.FailureUrlSubstring))
			{
				e.Handled = true;
				AppAnalytics.AppMetrica.FailurePaymentScreenView();
				OnRedirectToFailureUrl(link);
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task OnRedirectToReturnUrl(string url)
	{
		State = VisualState.InProgress;
		string text = HttpUtility.ParseQueryString(new Uri(url).Query)["orderId"];
		if (string.IsNullOrEmpty(text))
		{
			_logService.LogError("CheckoutWebViewModel", "Пустой orderId в " + url, LogType.ApiRequest, SystemType.ECom);
		}
		else
		{
			Result<CheckoutOrderDetails, DomainError> result = await _checkoutService.OrderData(text);
			CheckoutSuccessType value = CheckoutSuccessType.PaymentCompleted;
			_logService.Log("CheckoutWebViewModel", $"Результат оплаты заказа: {value}", (!result.IsSuccess) ? LogLevel.Error : LogLevel.Info, LogType.ApiRequest, SystemType.ECom);
		}
		SuccessfulPaymentCommand.Trigger(new CheckoutSuccessViewModel.Parameter(CheckoutSuccessType.PaymentCompleted, _parameter.OrderIds, PaymentCode.Online));
		_paymentCompleted = true;
	}

	private async Task OnPayAppNotFound(string message)
	{
		if (!_onPayAppNotFoundShown)
		{
			_onPayAppNotFoundShown = true;
			YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
			_ = awaiter.IsCompleted;
			await awaiter;
			YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
			awaiter = yieldAwaiter;
			awaiter.GetResult();
			await _infoMessageService.ShowDialogAsync("Ошибка!", message, AlertButtons.CloseButtons);
			OnBackCommand.Trigger();
		}
	}

	private void OnRedirectToFailureUrl(string url)
	{
		string text = HttpUtility.ParseQueryString(new Uri(url).Query)["orderId"];
		if (string.IsNullOrEmpty(text))
		{
			_logService.LogError("CheckoutWebViewModel", "Пустой orderId в " + url, LogType.ApiRequest, SystemType.ECom);
			ReturnToCartCommand.Trigger();
		}
		else
		{
			OnPaymentFailure(new global::_003C_003Ez__ReadOnlySingleElementList<string>(text));
		}
	}

	private void OnPaymentFailure(IEnumerable<string> orderIds)
	{
		OpenOrderNotPaidCommand.Trigger(new CheckoutOrderNotPaidViewModel.Parameter
		{
			OrderIds = orderIds
		});
	}

	public void OnPageLoaded(string url)
	{
		_logService.LogInfo("CheckoutWebViewModel", "OnPageLoaded: " + url, LogType.UserAction, SystemType.MobileApp);
		if (!_urlsToIgnore.Any(url.Contains) && !url.Contains(_parameter.ReturnUrlSubstring))
		{
			State = VisualState.Default;
		}
	}

	public void OnHttpError(string? error)
	{
		OnError("WebView Http Error " + error);
	}

	public void OnWebError(string? error)
	{
		OnError("WebView Web Error " + error);
	}

	private void OnError(string error)
	{
		ErrorMessage = error;
		_logService.LogError("CheckoutWebViewModel", "WebView Http Error " + error, LogType.UserAction, SystemType.ECom);
		AppAnalytics.AppMetrica.TrackEvent("paymentScreenPaymentError", ("errorId", error));
	}

	public void Retry()
	{
		ReloadCommand.Trigger();
		State = VisualState.Default;
	}

	public override NavigationPossibilityType OnNavigateFrom()
	{
		if (!_paymentCompleted)
		{
			return NavigationPossibilityType.Impossible;
		}
		return NavigationPossibilityType.Possible;
	}
}
