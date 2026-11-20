using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Analytics;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Banners;
using Auchan.Common.Ecom.Onboardings;
using Auchan.Common.HardUpdate;
using Auchan.Common.LoyaltyProgram;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using Auchan.Common.PersonalCabinet.DomainModels;
using Auchan.Common.PersonalCabinet.Errors;
using Auchan.Common.PersonalCabinet.Interactors;
using Auchan.Common.Profile.Orders.Services;
using Auchan.Common.SafeEntrance.Managers;
using Auchan.Common.StoreReview;
using Auchan.Common.Vpn;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Splash;

internal sealed class ApplicationInitializer : IApplicationInitializer
{
	private readonly Lazy<IAdminToolAuthorizer> _adminToolAuthorizer;

	private readonly Lazy<IAdminToolService> _adminToolService;

	private readonly Lazy<IUserContext> _userContext;

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<ILoyaltyCardManager> _loyaltyCardManager;

	private readonly Lazy<ILoyaltyManager> _loyaltyManager;

	private readonly Lazy<IAdminContext> _adminContext;

	private readonly Lazy<DefaultErrorTranslator> _errorTranslator;

	private readonly Lazy<IHardUpdateManager> _hardUpdateManager;

	private readonly Lazy<ProfileInteractor> _profileInteractor;

	private readonly IApplicationStateManager _applicationStateManager;

	private readonly Lazy<ISafeEntranceContext> _safeEntranceContext;

	private readonly Lazy<ILoginManager> _loginManager;

	private readonly Lazy<IDeviceService> _deviceService;

	private readonly Lazy<IContactsLoader> _contactsLoader;

	private readonly Lazy<IVpnChecker> _vpnChecker;

	private readonly Lazy<IOnboardingsManager> _onboardingsManager;

	private readonly Lazy<StoreRepository> _storeRepository;

	private readonly Lazy<IOrdersRepository> _ordersRepository;

	private readonly Lazy<IStoreService> _storeService;

	private readonly Lazy<Auchan.Common.StoreReview.StoreReview> _storeReview;

	private readonly Lazy<IBannersRepository> _bannersRepository;

	private bool _stateManagerInitialized;

	private const string RetryButtonText = "Повторить";

	private AppInitError? _appInitializationConfigError;

	private SplashViewModel.VisualState State { get; set; }

	public ApplicationInitializer(Lazy<IUserContext> userContext, Lazy<IEcomContext> ecomContext, Lazy<ILoyaltyCardManager> loyaltyCardManager, Lazy<ILoyaltyManager> loyaltyManager, Lazy<IAdminContext> adminContext, Lazy<DefaultErrorTranslator> errorTranslator, Lazy<IHardUpdateManager> hardUpdateManager, Lazy<ProfileInteractor> profileInteractor, IApplicationStateManager applicationStateManager, Lazy<ISafeEntranceContext> safeEntranceContext, Lazy<ILoginManager> loginManager, Lazy<IDeviceService> deviceService, Lazy<IAdminToolService> adminToolService, Lazy<IAdminToolAuthorizer> adminToolAuthorizer, Lazy<IContactsLoader> contactsLoader, Lazy<IVpnChecker> vpnChecker, Lazy<IOnboardingsManager> onboardingsManager, Lazy<StoreRepository> storeRepository, Lazy<IOrdersRepository> ordersRepository, Lazy<IStoreService> storeService, Lazy<Auchan.Common.StoreReview.StoreReview> storeReview, Lazy<IBannersRepository> bannersRepository)
	{
		_userContext = userContext;
		_ecomContext = ecomContext;
		_loyaltyCardManager = loyaltyCardManager;
		_loyaltyManager = loyaltyManager;
		_adminContext = adminContext;
		_errorTranslator = errorTranslator;
		_hardUpdateManager = hardUpdateManager;
		_profileInteractor = profileInteractor;
		_applicationStateManager = applicationStateManager;
		_safeEntranceContext = safeEntranceContext;
		_loginManager = loginManager;
		_deviceService = deviceService;
		_adminToolService = adminToolService;
		_adminToolAuthorizer = adminToolAuthorizer;
		_contactsLoader = contactsLoader;
		_vpnChecker = vpnChecker;
		_onboardingsManager = onboardingsManager;
		_storeRepository = storeRepository;
		_ordersRepository = ordersRepository;
		_storeService = storeService;
		_storeReview = storeReview;
		_bannersRepository = bannersRepository;
	}

	public async Task<AppInitializationResult> Initialize()
	{
		AppAnalytics.AppMetrica.ColdStartEnd().SafeFireAndForget((Action<Exception>)null, false);
		_ = 1;
		Task.Run(() => _contactsLoader.Value.LoadContacts()).SafeFireAndForget((Action<Exception>)null, false);
		if (await _vpnChecker.Value.VpnStateAtAppStart() == VpnState.Block)
		{
			return new AppInitializationResult(SplashViewModel.VisualState.Default, SplashScreenNextNavigation.None);
		}
		Result<Unit, DomainError> result = await _profileInteractor.Value.SyncProfile();
		if (result.IsFailure)
		{
			DomainError error = result.Error;
			if (error is UpdateRequiredError updateRequiredError)
			{
				_hardUpdateManager.Value.OnHardUpdateRequired(new HardUpdateViewModel.Parameter(updateRequiredError.Message));
				(string title, string description) tuple = _errorTranslator.Value.Translate(updateRequiredError);
				string item = tuple.title;
				string item2 = tuple.description;
				AppInitError initError = new AppInitError(item, item2, "Повторить");
				State = SplashViewModel.VisualState.Error;
				return new AppInitializationResult(State, SplashScreenNextNavigation.None, initError);
			}
			if (error is SessionExpiredError || error is MissingToken80Error)
			{
				await _userContext.Value.LogOut();
			}
		}
		Task getAppConfig = ((!_adminContext.Value.AppConfigIsNotNull) ? InitializeAdminApiRequest() : _adminContext.Value.SyncAppConfig());
		Task<Result<LoyaltyCardEntity, DomainError>> loyaltyCard = _loyaltyCardManager.Value.GetLoyaltyCard(CancellationToken.None, forceUpdate: false, 3);
		Task task = Task.Run((Action)_storeReview.Value.DoNotihing);
		IReadOnlyList<Task> readOnlyList = new global::_003C_003Ez__ReadOnlyArray<Task>(new Task[3] { getAppConfig, loyaltyCard, task });
		if (_userContext.Value.Authorized)
		{
			Task task2 = _ecomContext.Value.SyncReceiveMethodQueued(appSessionStarted: true);
			IReadOnlyList<Task> readOnlyList2 = readOnlyList;
			int num = 0;
			Task[] array = new Task[1 + readOnlyList2.Count];
			foreach (Task item5 in readOnlyList2)
			{
				array[num] = item5;
				num++;
			}
			array[num] = task2;
			readOnlyList = new global::_003C_003Ez__ReadOnlyArray<Task>(array);
			_storeRepository.Value.PrefetchReceiveMethods();
			_ordersRepository.Value.PrefetchFirstPage();
		}
		await Task.WhenAll(readOnlyList);
		if (getAppConfig.IsCompleted && _adminContext.Value.AppConfigIsNotNull && _adminContext.Value.AppConfig.LoadScreenConfig != null)
		{
			_adminContext.Value.CustomSplashAnimationKey = _adminContext.Value.AppConfig.LoadScreenConfig.LoadScreenAnimationUrl;
		}
		else
		{
			_adminContext.Value.CustomSplashAnimationKey = string.Empty;
		}
		if (_userContext.Value.Authorized)
		{
			_adminContext.Value.PrefetchPromotions();
			_bannersRepository.Value.GetBannersAsync().SafeFireAndForget((Action<Exception>)null, false);
			_onboardingsManager.Value.PrefetchOnboardings();
		}
		if (State == SplashViewModel.VisualState.Error)
		{
			return new AppInitializationResult(State, SplashScreenNextNavigation.None, _appInitializationConfigError);
		}
		await GetSocialStatusAsync();
		if (_adminContext.Value.AppConfig.MaintenanceStatus == MaintenanceType.DelayedBlocking || _adminContext.Value.AppConfig.MaintenanceStatus == MaintenanceType.InstantBlocking)
		{
			State = SplashViewModel.VisualState.Maintenance;
			AppInitError initError2 = new AppInitError(_adminContext.Value.AppConfig.MaintenanceTitle, _adminContext.Value.AppConfig.MaintenanceMessage, _adminContext.Value.AppConfig.MaintenanceButtonTitle);
			return new AppInitializationResult(State, SplashScreenNextNavigation.None, initError2);
		}
		State = SplashViewModel.VisualState.Default;
		if (!_stateManagerInitialized)
		{
			_applicationStateManager.StartAsync().SafeFireAndForget((Action<Exception>)null, false);
			_stateManagerInitialized = true;
		}
		if (!_ecomContext.Value.Initialized)
		{
			Result<Unit, DomainError> result2 = await _ecomContext.Value.Initialize();
			if (result2.IsFailure)
			{
				if (result2.Error is UpdateRequiredError updateRequiredError2)
				{
					_hardUpdateManager.Value.OnHardUpdateRequired(new HardUpdateViewModel.Parameter(updateRequiredError2.Message));
				}
				(string title, string description) tuple2 = _errorTranslator.Value.Translate(result2.Error);
				string item3 = tuple2.title;
				string item4 = tuple2.description;
				State = SplashViewModel.VisualState.Error;
				return new AppInitializationResult(State, SplashScreenNextNavigation.None, new AppInitError(item3, item4, "Повторить"));
			}
		}
		_userContext.Value.IsAuthorizedAcrossRegistration = false;
		if (_userContext.Value.IsSignupWasShown && string.IsNullOrEmpty(_userContext.Value.Profile?.LoymaxLoyaltyId))
		{
			await _loginManager.Value.ProceedLoyaltyRolloutCardOptions();
			return new AppInitializationResult(State, SplashScreenNextNavigation.None);
		}
		if (!_userContext.Value.Authorized)
		{
			bool displayOnboardings = await _onboardingsManager.Value.ShouldShowOnboardings(ShowAt.BeforeAuth);
			if (!(await _loginManager.Value.LoginAsync(displayOnboardings)))
			{
				return new AppInitializationResult(State, SplashScreenNextNavigation.None);
			}
			_adminContext.Value.UpdateExtraPromotions();
			await _adminContext.Value.GetPromotions(forceUpdate: true);
			if (!_loginManager.Value.ShouldNavigateToProfile)
			{
				return NavigateToSafeEntranceIfNeeded();
			}
			if (1 == 0)
			{
			}
			return new AppInitializationResult(State, SplashScreenNextNavigation.MainScreen);
		}
		AppInitializationResult appInitializationResult = NavigateToSafeEntranceIfNeeded();
		return (appInitializationResult.SplashScreenNextNavigation != SplashScreenNextNavigation.SafeEntrance) ? new AppInitializationResult(State, SplashScreenNextNavigation.MainScreen) : appInitializationResult;
	}

	private async Task InitializeAdminApiRequest()
	{
		try
		{
			string fiasId = _ecomContext.Value.ActiveStore.City.FiasId;
			string storeId = _ecomContext.Value.ActiveStore.Id.ToString();
			string udid = _deviceService.Value.Udid;
			Result<Initialization, DomainError> result = await _adminToolService.Value.Initialize(udid, fiasId, storeId);
			if (result.IsFailure)
			{
				(string title, string description) tuple = _errorTranslator.Value.Translate(result.Error);
				string item = tuple.title;
				string item2 = tuple.description;
				_appInitializationConfigError = new AppInitError(item, item2, "Повторить");
				State = SplashViewModel.VisualState.Error;
				if (result.Error is UpdateRequiredError updateRequiredError)
				{
					_hardUpdateManager.Value.OnHardUpdateRequired(new HardUpdateViewModel.Parameter(updateRequiredError.Message));
					return;
				}
			}
			else
			{
				_adminContext.Value.UpdateStampsConfig().SafeFireAndForget((Action<Exception>)null, false);
			}
			_adminContext.Value.InitializeAppConfigAndExtraPromotionAtAppStart(result.Value.AppConfig, result.Value.ExtraPromotions);
			_adminToolAuthorizer.Value.InitializeUdidKeyAtAppStart(result.Value.Udid.Key);
		}
		catch (Exception ex)
		{
			_ = ex;
			await GetUdidAndAppConfigSeparately();
		}
	}

	private async Task GetUdidAndAppConfigSeparately()
	{
		Result<AppConfig, DomainError> result = await _adminContext.Value.GetAppConfig();
		if (result.IsFailure)
		{
			if (result.Error is UpdateRequiredError updateRequiredError)
			{
				_hardUpdateManager.Value.OnHardUpdateRequired(new HardUpdateViewModel.Parameter(updateRequiredError.Message));
			}
			(string title, string description) tuple = _errorTranslator.Value.Translate(result.Error);
			string item = tuple.title;
			string item2 = tuple.description;
			_appInitializationConfigError = new AppInitError(item, item2, "Повторить");
			State = SplashViewModel.VisualState.Error;
		}
	}

	private async Task GetSocialStatusAsync()
	{
		var (flag3, _, loyaltyProgramSocialStatusResponse2) = await _loyaltyManager.Value.GetSocialStatusAsync(3);
		if (_userContext.Value.Profile == null)
		{
			return;
		}
		if (flag3)
		{
			ProfileModel profile = _userContext.Value.Profile;
			profile.IsAuchanEmployee = loyaltyProgramSocialStatusResponse2.IsEmployee;
			profile.IsConfirmedSocialStatus = loyaltyProgramSocialStatusResponse2.IsSocial;
			_userContext.Value.Profile = profile;
			_userContext.Value.LoyaltyProgramSegments = loyaltyProgramSocialStatusResponse2.Segments.Select((LoyaltyProgramSocialStatusSegment x) => x.Code).ToList();
			if (_adminContext.Value.AppConfigIsNotNull)
			{
				_adminContext.Value.StampsConfig?.SetSocialStatus(loyaltyProgramSocialStatusResponse2);
			}
		}
		_userContext.Value.UpdateProfileWithNotify(_userContext.Value.Profile, needUpdateEmployeeStatus: true);
	}

	private AppInitializationResult NavigateToSafeEntranceIfNeeded()
	{
		if (_safeEntranceContext.Value.IsPinCodeCreated && !_userContext.Value.IsAuthorizedAcrossRegistration)
		{
			return new AppInitializationResult(State, SplashScreenNextNavigation.SafeEntrance);
		}
		return new AppInitializationResult(State, SplashScreenNextNavigation.MainScreen);
	}
}
