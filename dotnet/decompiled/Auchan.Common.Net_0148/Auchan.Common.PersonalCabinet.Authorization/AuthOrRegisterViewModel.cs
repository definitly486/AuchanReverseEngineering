using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.DeveloperMenu;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Navigation;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;

namespace Auchan.Common.PersonalCabinet.Authorization;

public sealed class AuthOrRegisterViewModel : ScreenViewModel, IVkAuthViewModel, INotifyPropertyChanged
{
	private readonly IVkAuthService _vkAuthService;

	private readonly IInfoMessageService _infoMessageService;

	private readonly NotAuthReopenScreenService _notAuthReopenScreenService;

	private readonly Lazy<IDeferredLinkSupport> _deferredLinkSupport;

	private readonly Lazy<IUniversalLinksService> _universalLinksService;

	private readonly Lazy<ILogService> _logService;

	private int _logoClickCount;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	private const int LogoClickMaxCount = 10;

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
	} = VisualState.Default;

	public string Title => "Добро пожаловать!";

	public string AuthOrRegisterText => "Войдите или зарегистрируйтесь";

	public string ByPhoneNumberButtonText => "По номеру телефона";

	public string ByVkButtonText => "Войти с VK ID";

	public string ShowCatalogButton => "Смотреть каталог";

	public UICommand<LoginViewModel.Parameter> LoginCommand { get; } = new UICommand<LoginViewModel.Parameter>();

	protected override string ScreenName => "entry_welcome";

	public UICommand NavigateToDevMenuCommand { get; } = new UICommand();

	public UICommand OpenPasswordEnterCommand { get; } = new UICommand();

	public UICommand GoToCatalogCommand { get; } = new UICommand();

	public UICommand<BrokerToken> OpenVkSignUpCommand { get; } = new UICommand<BrokerToken>();

	public UICommand LoginByVkCommand { get; } = new UICommand();

	public AuthOrRegisterViewModel(IVkAuthService vkAuthService, IInfoMessageService infoMessageService, NotAuthReopenScreenService notAuthReopenScreenService, Lazy<IDeferredLinkSupport> deferredLinkSupport, Lazy<IUniversalLinksService> universalLinksService, Lazy<ILogService> logService)
	{
		_vkAuthService = vkAuthService;
		_infoMessageService = infoMessageService;
		_notAuthReopenScreenService = notAuthReopenScreenService;
		_deferredLinkSupport = deferredLinkSupport;
		_universalLinksService = universalLinksService;
		_logService = logService;
	}

	protected override async Task Start()
	{
		await base.Start();
		_vkAuthService.Init(this);
		LoginByVkCommand.PerformDebouncingTask(LoginByVkAsync).Subscribe().AddTo(base.CloseDisposable);
		GetDeferredLink().SafeFireAndForget((Action<Exception>)null, false);
	}

	protected override Task OnResumed()
	{
		AppAnalytics.AppMetrica.TrackEvent("welcomeScreenView");
		_vkAuthService.ContinueLoginAsync().SafeFireAndForget((Action<Exception>)null, false);
		return base.OnResumed();
	}

	public void SignClicked()
	{
		AppAnalytics.AppMetrica.TrackEvent("welcomeScreenButtonAuth");
		LoginCommand.Trigger(new LoginViewModel.Parameter());
	}

	public void OnLogoClick()
	{
		_logoClickCount++;
		if (_logoClickCount >= 10)
		{
			_notAuthReopenScreenService.Clear();
			_logoClickCount = 0;
			OpenPasswordEnterCommand.Trigger();
		}
	}

	public void VerifyPassword(string password)
	{
		if (DevMenuViewModel.VerifyPassword(password))
		{
			NavigateToDevMenuCommand.Trigger();
		}
		else if (password.Length == 6)
		{
			_infoMessageService.ShowSnackbar("Введен неверный пароль");
		}
	}

	public void GoToCatalog()
	{
		AppAnalytics.AppMetrica.TrackEvent("unauthCatalogTap");
		_notAuthReopenScreenService.Clear();
		GoToCatalogCommand.Trigger();
	}

	private async Task LoginByVkAsync()
	{
		await _vkAuthService.StartAsync();
	}

	private async Task GetDeferredLink()
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		Result<Uri, DomainError> result = await _deferredLinkSupport.Value.GetAsync();
		if (result.TryGetValue(out var value) && _universalLinksService.Value.ShouldHandleLink(value.ToString()))
		{
			await _universalLinksService.Value.HandleLink(value.ToString());
			return;
		}
		_logService.Value.LogError("IDeferredLinkSupport", $"got error [{result.Error}] while reading deferred deeplink", LogType.Debug, SystemType.MobileApp);
	}
}
