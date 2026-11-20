using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Cache;
using Auchan.Common.Common;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.PriceChecker;
using Auchan.Common.Home;
using Auchan.Common.Logs;
using Auchan.Common.Navigation;
using Auchan.Common.Networking;
using Auchan.Common.Profile.Stores.Repositories;
using Auchan.Common.Profile.Stores.Services;

namespace Auchan.Common.DeveloperMenu;

public class DevMenuViewModel : ScreenViewModel
{
	private readonly IEnvironmentManager _environmentManager;

	private readonly ILogService _logService;

	private readonly IRegionRepository _regionRepository;

	private readonly IAllExistingRegionRepository _allRegionRepository;

	private readonly IStoreRepository _storeRepository;

	private readonly IFullStoreFilterService _fullStoreFilterService;

	private readonly ChangeEnvironmentUseCase _changeEnvironmentUseCase;

	private readonly IEcomContext _ecomContext;

	private readonly IAdminContext _adminContext;

	private readonly Lazy<IPriceCheckerContext> _priceCheckerContext;

	private readonly Lazy<IHomeScreenTracker> _homeScreenTracker;

	private readonly Lazy<IRestartService> _restartService;

	private readonly IAppMetricaKeyProvider _appMetricaKeyProvider;

	private readonly INavigationContext _navigationContext;

	private IApplicationSettings _applicationSettings;

	private readonly IInfoMessageService _messageService;

	private readonly IMemoryCache _memoryCache;

	private readonly ICache _cache;

	[CompilerGenerated]
	private string _003CSelectedEnvironmentText_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CSelectedEnvironment_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CCanResetCache_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAppMetricaCustomKey_003Ek__BackingField;

	public string ScreenTitle => "Административное меню";

	public string SaveButtonText => "Сохранить";

	public string OpenLogsButtonText => "Открыть логи";

	public string ResetCacheButtonText => "Сбросить кэш";

	public string SelectedEnvironmentText
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedEnvironmentText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CSelectedEnvironmentText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSelectedEnvironmentText_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedEnvironmentText");
			}
		}
	} = "";

	public int CurrentEnvironment => (int)_environmentManager.CurrentEnvironment;

	public int SelectedEnvironment
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedEnvironment_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CSelectedEnvironment_003Ek__BackingField != value)
			{
				_003CSelectedEnvironment_003Ek__BackingField = value;
				RaisePropertyChanged("IsEnvironmentChanged");
				RaisePropertyChanged("HaveChanges");
				RaisePropertyChanged("SelectedEnvironment");
			}
		}
	}

	public bool IsEnvironmentChanged => SelectedEnvironment != CurrentEnvironment;

	public bool HaveChanges
	{
		get
		{
			if (!IsEnvironmentChanged)
			{
				return IsAppMetricaKeyChanged;
			}
			return true;
		}
	}

	public bool CanResetCache
	{
		[CompilerGenerated]
		get
		{
			return _003CCanResetCache_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CCanResetCache_003Ek__BackingField != value)
			{
				_003CCanResetCache_003Ek__BackingField = value;
				RaisePropertyChanged("CanResetCache");
			}
		}
	} = true;

	public string[] EnvironmentVariants => Enum.GetNames(typeof(Auchan.Common.Networking.Environment));

	public string AppMetricaCustomKeyText => "YAM Post Key";

	public string AppMetricaCustomKey
	{
		[CompilerGenerated]
		get
		{
			return _003CAppMetricaCustomKey_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CAppMetricaCustomKey_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAppMetricaCustomKey_003Ek__BackingField = value;
				RaisePropertyChanged("IsAppMetricaKeyChanged");
				RaisePropertyChanged("HaveChanges");
				RaisePropertyChanged("AppMetricaCustomKey");
			}
		}
	}

	public bool IsAppMetricaKeyChanged => AppMetricaCustomKey != _appMetricaKeyProvider.CustomKey;

	public DevMenuViewModel(IEnvironmentManager environmentManager, ChangeEnvironmentUseCase changeEnvironmentUseCase, IEcomContext ecomContext, ILogService logService, IRegionRepository regionRepository, IAllExistingRegionRepository allRegionRepository, IStoreRepository storeRepository, IFullStoreFilterService fullStoreFilterService, ICache cache, IInfoMessageService messageService, IMemoryCache memoryCache, INavigationContext navigationContext, IApplicationSettings applicationSettings, IAdminContext adminContext, Lazy<IPriceCheckerContext> priceCheckerContext, Lazy<IHomeScreenTracker> homeScreenTracker, Lazy<IRestartService> restartService, IAppMetricaKeyProvider appMetricaKeyProvider)
	{
		_environmentManager = environmentManager;
		_changeEnvironmentUseCase = changeEnvironmentUseCase;
		_ecomContext = ecomContext;
		_logService = logService;
		_regionRepository = regionRepository;
		_allRegionRepository = allRegionRepository;
		_storeRepository = storeRepository;
		_fullStoreFilterService = fullStoreFilterService;
		_cache = cache;
		_navigationContext = navigationContext;
		_messageService = messageService;
		_memoryCache = memoryCache;
		_applicationSettings = applicationSettings;
		_adminContext = adminContext;
		_priceCheckerContext = priceCheckerContext;
		_homeScreenTracker = homeScreenTracker;
		_restartService = restartService;
		_appMetricaKeyProvider = appMetricaKeyProvider;
		SelectedEnvironment = CurrentEnvironment;
		AppMetricaCustomKey = _appMetricaKeyProvider.CustomKey;
	}

	protected override async Task OnResumed()
	{
		_logService.LogInfo("DevMenuViewModel", "Открыто DevMenu", LogType.UserAction, SystemType.MobileApp);
		await base.Start();
	}

	public async Task SaveChanges()
	{
		if (HaveChanges)
		{
			if (IsAppMetricaKeyChanged)
			{
				_appMetricaKeyProvider.CustomKey = AppMetricaCustomKey;
				RaisePropertyChanged("HaveChanges");
			}
			if (IsEnvironmentChanged)
			{
				await ResetCacheAsync();
				await _changeEnvironmentUseCase.Execute((Auchan.Common.Networking.Environment)SelectedEnvironment);
				await ResetCacheAsync();
				_ecomContext.AgeGateAgreement = AgreeState.None;
				_restartService.Value.Restart();
			}
		}
	}

	public async Task ResetCache()
	{
		CanResetCache = false;
		await ResetCacheAsync();
		CanResetCache = true;
		_messageService.ShowSnackbar("Кэш очищен", SnackbarStyle.Success);
		_navigationContext.IsStartForExtraOnboardingsShowed = false;
		_restartService.Value.Restart();
	}

	private async Task ResetCacheAsync()
	{
		_ = 5;
		try
		{
			_homeScreenTracker.Value.Shown = false;
			_applicationSettings.Reset();
			await ClearStores();
			await _adminContext.CleanDeinitialize();
			await _ecomContext.CleanDeinitialize();
			await _priceCheckerContext.Value.CleanDeinitialize();
			await _memoryCache.RemoveAll();
			await _cache.RemoveAll();
		}
		catch (Exception value)
		{
			_messageService.ShowSnackbar("Ошибка при сбросе кэша");
			_logService.LogError("DevMenuViewModel", $"Ошибка при сбросе кэша: {value}", LogType.UserAction, SystemType.MobileApp);
		}
	}

	private async Task ClearStores()
	{
		_fullStoreFilterService.ClearAll();
		await _storeRepository.ClearCacheAsync();
		await _regionRepository.ClearCacheAsync();
		await _allRegionRepository.ClearCacheAsync();
	}

	public static bool VerifyPassword(string password)
	{
		return BitConverter.ToString(SHA512.HashData(Encoding.UTF8.GetBytes(password))) == "A6-3C-94-28-48-D9-C0-DF-71-83-BB-F8-3D-9E-6A-4C-9A-C3-03-03-E2-C5-DA-5E-39-21-88-42-AC-94-6B-8B-7B-8B-4C-8B-84-55-FE-FA-2C-6F-9A-22-0E-3E-6E-2E-DD-F0-8B-9A-FE-CE-B3-DE-1A-9B-F7-4C-E4-C0-86-2D";
	}
}
