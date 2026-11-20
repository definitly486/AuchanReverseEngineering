using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalOffers;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.AdminTool;

public class AdminContext : IAdminContext, INotifyPropertyChanged
{
	public const string ADMIN_CONTEXT_PREFERENCES = "AdminContextPreferences";

	public const string VIEWED_MY_OFFERS = "VIEWED_MY_OFFER";

	public const string VIEWED_BANNERS = "VIEWED_BANNER";

	public const int PersOffersPageSize = 50;

	private readonly IEcomContext _ecomContext;

	private readonly Lazy<IAdminToolService> _adminToolService;

	private readonly Lazy<IPromotionRepository> _promotionRepository;

	private readonly Lazy<PersonalOffersService> _personalOffersService;

	private readonly IUserContext _userContext;

	private readonly SemaphoreSlim _semaphoreAppConfig = new SemaphoreSlim(1);

	private TaskCompletionSource<AppConfig> _appConfigTcs = new TaskCompletionSource<AppConfig>();

	private DateTime _appConfigUpdateTime = DateTime.MinValue;

	private SemaphoreSlim _persOffersSemaphore = new SemaphoreSlim(1);

	private DateTime _persOffersUpdateTime = DateTime.MinValue;

	private readonly TimeSpan _persOffersCacheInterval = TimeSpan.FromMinutes(1L);

	private AppConfig? _appConfig;

	private readonly ObservableRangeCollection<Promotion> _promotions = new ObservableRangeCollection<Promotion>();

	private readonly ObservableRangeCollection<PersOfferItemViewModel> _personalOffers = new ObservableRangeCollection<PersOfferItemViewModel>();

	private Task<ImmutableList<ExtraPromotion>> _extraPromotions = Task.FromResult(ImmutableList<ExtraPromotion>.Empty);

	private List<int> _showedExtraPromotions;

	private Task<Result<List<Promotion>, DomainError>>? _prefetchPromotions;

	[CompilerGenerated]
	private bool _003CShowedStartOnboardingsThisSession_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CShowedTooltipThisSession_003Ek__BackingField;

	[CompilerGenerated]
	private StampsConfig? _003CStampsConfig_003Ek__BackingField;

	private int NumberOfTooltipPopups
	{
		get
		{
			return Preferences.Get("NumberOfTooltipPopups", 0, "AdminContextPreferences");
		}
		set
		{
			if (NumberOfTooltipPopups != value)
			{
				Preferences.Set("NumberOfTooltipPopups", value, "AdminContextPreferences");
				OnPropertyChanged("NumberOfTooltipPopups");
			}
		}
	}

	private int LastGameAnimationIndex
	{
		get
		{
			return Preferences.Get("LastGameAnimationIndex", 0, "AdminContextPreferences");
		}
		set
		{
			if (LastGameAnimationIndex != value)
			{
				Preferences.Set("LastGameAnimationIndex", value, "AdminContextPreferences");
				OnPropertyChanged("LastGameAnimationIndex");
			}
		}
	}

	public bool ShowedStartOnboardingsThisSession
	{
		[CompilerGenerated]
		get
		{
			return _003CShowedStartOnboardingsThisSession_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CShowedStartOnboardingsThisSession_003Ek__BackingField != value)
			{
				_003CShowedStartOnboardingsThisSession_003Ek__BackingField = value;
				OnPropertyChanged("ShowedStartOnboardingsThisSession");
			}
		}
	}

	public bool ShowedTooltipThisSession
	{
		[CompilerGenerated]
		get
		{
			return _003CShowedTooltipThisSession_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CShowedTooltipThisSession_003Ek__BackingField != value)
			{
				_003CShowedTooltipThisSession_003Ek__BackingField = value;
				OnPropertyChanged("ShowedTooltipThisSession");
			}
		}
	}

	public bool ShowedEcoCheck
	{
		get
		{
			return Preferences.Get("ShowedEcoCheck", defaultValue: false, "AdminContextPreferences");
		}
		set
		{
			if (ShowedEcoCheck != value)
			{
				Preferences.Set("ShowedEcoCheck", value, "AdminContextPreferences");
				OnPropertyChanged("ShowedEcoCheck");
			}
		}
	}

	public bool ShowedGameAnimationPopup
	{
		get
		{
			return Preferences.Get("ShowedGameAnimationPopup", defaultValue: false, "AdminContextPreferences");
		}
		set
		{
			if (ShowedGameAnimationPopup != value)
			{
				Preferences.Set("ShowedGameAnimationPopup", value, "AdminContextPreferences");
				OnPropertyChanged("ShowedGameAnimationPopup");
			}
		}
	}

	public DateTime GamePopupLastShowTime
	{
		get
		{
			return Preferences.Get("GamePopupLastShowTime", DateTime.MinValue, "AdminContextPreferences");
		}
		set
		{
			if (!DateTime.Equals(GamePopupLastShowTime, value))
			{
				Preferences.Set("GamePopupLastShowTime", value, "AdminContextPreferences");
				OnPropertyChanged("GamePopupLastShowTime");
			}
		}
	}

	public bool GamePopupDontShowFlag
	{
		get
		{
			return Preferences.Get("GamePopupDontShowFlag", defaultValue: false, "AdminContextPreferences");
		}
		set
		{
			if (GamePopupDontShowFlag != value)
			{
				Preferences.Set("GamePopupDontShowFlag", value, "AdminContextPreferences");
				OnPropertyChanged("GamePopupDontShowFlag");
			}
		}
	}

	public string CustomSplashAnimationKey
	{
		get
		{
			return Preferences.Get("CustomSplashAnimationKey", "", "AdminContextPreferences");
		}
		set
		{
			if (!string.Equals(CustomSplashAnimationKey, value, StringComparison.Ordinal))
			{
				Preferences.Set("CustomSplashAnimationKey", value, "AdminContextPreferences");
				OnPropertyChanged("CustomSplashAnimationKey");
			}
		}
	}

	public bool AdditionalOrderTooltipShown
	{
		get
		{
			return Preferences.Get("AdditionalOrderTooltipShown", defaultValue: false, "AdminContextPreferences");
		}
		set
		{
			if (AdditionalOrderTooltipShown != value)
			{
				Preferences.Set("AdditionalOrderTooltipShown", value, "AdminContextPreferences");
				OnPropertyChanged("AdditionalOrderTooltipShown");
			}
		}
	}

	public AppConfig AppConfig => _appConfig ?? throw new InvalidOperationException("AppConfig is not initialized yet");

	public StampsConfig? StampsConfig
	{
		[CompilerGenerated]
		get
		{
			return _003CStampsConfig_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CStampsConfig_003Ek__BackingField, value))
			{
				_003CStampsConfig_003Ek__BackingField = value;
				OnPropertyChanged("StampsConfig");
			}
		}
	}

	public bool AppConfigIsNotNull => _appConfig != null;

	public string LastNewAppVersion
	{
		get
		{
			return Preferences.Get("LastNewAppVersion", string.Empty, "AdminContextPreferences");
		}
		set
		{
			if (!string.Equals(LastNewAppVersion, value, StringComparison.Ordinal))
			{
				Preferences.Set("LastNewAppVersion", value, "AdminContextPreferences");
				OnPropertyChanged("LastNewAppVersion");
			}
		}
	}

	public int CountOfNewPersonalOffers
	{
		get
		{
			try
			{
				return PersonalOffers.Any() ? PersonalOffers.Count((PersOfferItemViewModel offer) => !IsMyOfferViewed(offer.Code)) : 0;
			}
			catch (Exception ex)
			{
				DevAnalytics.Report("CountOfNewPersonalOffers", ex);
			}
			return 0;
		}
	}

	public ReadOnlyObservableCollection<Promotion> Promotions { get; }

	public ReadOnlyObservableCollection<PersOfferItemViewModel> PersonalOffers { get; }

	public IObservable<IReadOnlyList<Promotion>> PromotionsChanged { get; }

	public IObservable<IReadOnlyList<PersOfferItemViewModel>> PersonalOffersChanged { get; }

	public event PropertyChangedEventHandler? PropertyChanged;

	public AdminContext(IEcomContext ecomContext, IHomeScreenTracker homeScreenTracker, Lazy<IAdminToolService> adminToolService, Lazy<IPromotionRepository> promotionRepository, IUserContext userContext, Lazy<PersonalOffersService> personalOffersService)
	{
		_ecomContext = ecomContext;
		_adminToolService = adminToolService;
		_promotionRepository = promotionRepository;
		_userContext = userContext;
		_personalOffersService = personalOffersService;
		_showedExtraPromotions = PreferencesEx.Get<List<int>>("_showedExtraPromotions", "AdminContextPreferences") ?? new List<int>();
		homeScreenTracker.OnShown += delegate
		{
			_prefetchPromotions = null;
		};
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ActiveStore).PerformSamplingTask((Func<Store, Task>)async delegate
		{
			await GetPromotions(forceUpdate: true);
		}, (IScheduler?)null).Subscribe();
		_userContext.AfterLoggedOut += delegate
		{
			ShowedTooltipThisSession = false;
			ShowedStartOnboardingsThisSession = false;
			ShowedEcoCheck = false;
			ShowedGameAnimationPopup = false;
			AdditionalOrderTooltipShown = false;
			_promotions.Clear();
			_personalOffers.Clear();
			_persOffersUpdateTime = DateTime.MinValue;
			Preferences.Remove("LastNewAppVersion", "AdminContextPreferences");
			return Task.CompletedTask;
		};
		Promotions = _promotions.AsReadOnly();
		PersonalOffers = _personalOffers.AsReadOnly();
		PromotionsChanged = from _ in Promotions.CollectionChangedAsObservable()
			select Promotions;
		PersonalOffersChanged = from _ in PersonalOffers.CollectionChangedAsObservable()
			select PersonalOffers;
	}

	public void SaveViewedMyOfferId(string id)
	{
		if (PersonalOffers.Count > 0)
		{
			PreferencesEx.Set(id, string.Empty, "VIEWED_MY_OFFER");
			OnPropertyChanged("PersonalOffers");
		}
	}

	public void InvalidatePersOffersCache()
	{
		_persOffersUpdateTime = DateTime.MinValue;
	}

	public bool IsMyOfferViewed(string id)
	{
		return PreferencesEx.Get<string>(id, "VIEWED_MY_OFFER") != null;
	}

	public void SaveViewedBannerId(int id)
	{
		if (Promotions.Count > 0)
		{
			PreferencesEx.Set($"{id}", string.Empty, "VIEWED_BANNER");
			_promotions.ForceNotifyItemChanged(0);
			OnPropertyChanged("Promotions");
		}
	}

	public bool IsBannerViewed(int id)
	{
		return PreferencesEx.Get<string>($"{id}", "VIEWED_BANNER") != null;
	}

	public async Task<Result<AppConfig, DomainError>> GetAppConfig()
	{
		if (_appConfig == null)
		{
			Result<AppConfig, DomainError> result = await Task.Run(() => _adminToolService.Value.AppConfig());
			if (result.IsFailure)
			{
				return result;
			}
			UpdateStampsConfig().SafeFireAndForget((Action<Exception>)null, false);
			_appConfigUpdateTime = DateTime.UtcNow;
			_appConfig = result.Value;
			_appConfigTcs.TrySetResult(result.Value);
		}
		return Result.Success<AppConfig, DomainError>(_appConfig);
	}

	public async Task<StampsConfig?> UpdateStampsConfig()
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		if (_appConfig != null)
		{
			StampsConfig = await Task.Run(() => _adminToolService.Value.StampsConfig());
		}
		return StampsConfig;
	}

	public void InitializeAppConfigAndExtraPromotionAtAppStart(AppConfig appConfig, ImmutableList<ExtraPromotion> extraPromotions)
	{
		UpdateStampsConfig().SafeFireAndForget((Action<Exception>)null, false);
		_appConfigUpdateTime = DateTime.UtcNow;
		_appConfig = appConfig;
		_appConfigTcs.TrySetResult(appConfig);
		_extraPromotions = Task.FromResult(extraPromotions);
	}

	public Task<AppConfig> WaitForAppConfig()
	{
		if (_appConfig == null)
		{
			return _appConfigTcs.Task;
		}
		return Task.FromResult(_appConfig);
	}

	public async Task<Result<AppConfig, DomainError>> SyncAppConfig()
	{
		await _semaphoreAppConfig.WaitAsync();
		try
		{
			if (_appConfig != null && DateTime.UtcNow - _appConfigUpdateTime < TimeSpan.FromSeconds(5L))
			{
				return Result.Success<AppConfig, DomainError>(_appConfig);
			}
			Result<AppConfig, DomainError> result = await Task.Run(() => _adminToolService.Value.AppConfig());
			if (result.IsFailure)
			{
				return result;
			}
			UpdateStampsConfig().SafeFireAndForget((Action<Exception>)null, false);
			_appConfigUpdateTime = DateTime.UtcNow;
			_appConfig = result.Value;
			_appConfigTcs.TrySetResult(result.Value);
		}
		finally
		{
			_semaphoreAppConfig.Release();
		}
		return Result.Success<AppConfig, DomainError>(_appConfig);
	}

	public Task CleanDeinitialize()
	{
		_appConfig = null;
		_appConfigTcs = new TaskCompletionSource<AppConfig>();
		_promotions.Clear();
		_extraPromotions = Task.FromResult(ImmutableList<ExtraPromotion>.Empty);
		_showedExtraPromotions.Clear();
		Preferences.Clear("AdminContextPreferences");
		Preferences.Clear("VIEWED_MY_OFFER");
		return Task.CompletedTask;
	}

	public void PrefetchPromotions()
	{
		_prefetchPromotions = GetPromotionsInternal(forceUpdate: false);
	}

	public Task<Result<List<Promotion>, DomainError>> GetPromotions(bool forceUpdate = false)
	{
		if (_prefetchPromotions != null)
		{
			return _prefetchPromotions;
		}
		return GetPromotionsInternal(forceUpdate);
	}

	private async Task<Result<List<Promotion>, DomainError>> GetPromotionsInternal(bool forceUpdate)
	{
		if (!forceUpdate && _promotions.Count > 0)
		{
			return Result.Success<List<Promotion>, DomainError>(_promotions.ToList());
		}
		List<string> segments = ((_userContext.LoyaltyProgramSegments == null) ? null : ((_userContext.LoyaltyProgramSegments.Count > 0) ? _userContext.LoyaltyProgramSegments : null));
		Result<List<Promotion>, DomainError> result = await Task.Run(() => _promotionRepository.Value.Promotions(_ecomContext.ActiveStore.City.FiasId, _ecomContext.ActiveStore.Id.ToString("D3"), segments));
		if (result.IsSuccess)
		{
			lock (_promotions)
			{
				_promotions.ReplaceRange(result.Value);
			}
		}
		return result;
	}

	public async Task<Result<List<PersOfferItemViewModel>, DomainError>> GetPersonalOffers()
	{
		await _persOffersSemaphore.WaitAsync();
		try
		{
			if (DateTime.UtcNow - _persOffersUpdateTime > _persOffersCacheInterval)
			{
				Result<List<PersOfferItemViewModel>, DomainError> result = await Task.Run(() => _personalOffersService.Value.PersonalOffers());
				if (result.IsSuccess)
				{
					lock (_personalOffers)
					{
						List<PersOfferItemViewModel> value = result.Value;
						_personalOffers.ReplaceRange(SortedOffers(value));
					}
					_persOffersUpdateTime = DateTime.UtcNow;
					return Result.Success<List<PersOfferItemViewModel>, DomainError>(_personalOffers.ToList());
				}
				_personalOffers.Clear();
				return Result.Failure<List<PersOfferItemViewModel>, DomainError>(result.Error);
			}
			_personalOffers.ReplaceRange(SortedOffers(_personalOffers));
			return Result.Success<List<PersOfferItemViewModel>, DomainError>(_personalOffers.ToList());
		}
		finally
		{
			_persOffersSemaphore.Release();
		}
	}

	public List<PersOfferItemViewModel> SortedOffers(IEnumerable<PersOfferItemViewModel> offers)
	{
		offers.ForEach(delegate(PersOfferItemViewModel o)
		{
			o.Update();
		});
		return (from b in offers
			orderby IsMyOfferViewed(b.Code), b.IsAccepted, b.EndsOn ?? DateTime.MaxValue, b.Title
			select b).ToList();
	}

	public Task<Result<object, DomainError>> ActivatePersonalOffer(string loymaxId)
	{
		return _personalOffersService.Value.ActivatePersonalOffer(loymaxId);
	}

	public async Task<Result<Promotion, DomainError>> Promotion(int id)
	{
		if (_promotions.Count == 0)
		{
			await GetPromotions();
		}
		Promotion promotion = _promotions.FirstOrDefault((Promotion x) => x.Id == id);
		if (promotion != null)
		{
			return Result.Success<Promotion, DomainError>(promotion);
		}
		return Result.Failure<Promotion, DomainError>(new NoDataError());
	}

	public Task<ImmutableList<ExtraPromotion>> GetExtraPromotionsAsync()
	{
		return _extraPromotions;
	}

	public void UpdateExtraPromotions()
	{
		_extraPromotions = DoAsync();
		async Task<ImmutableList<ExtraPromotion>> DoAsync()
		{
			ImmutableList<ExtraPromotion> value;
			return (await Task.Run(() => _promotionRepository.Value.ExtraPromotions(_ecomContext.ActiveStore.City.FiasId))).TryGetValue(out value) ? value : ImmutableList.Create(default(ReadOnlySpan<ExtraPromotion>));
		}
	}

	public void AddShowedExtraPromotion(int id)
	{
		_showedExtraPromotions.Add(id);
		PreferencesEx.Set("_showedExtraPromotions", _showedExtraPromotions, "AdminContextPreferences");
	}

	public bool IsShowedExtraPromotion(int id)
	{
		return _showedExtraPromotions.Contains(id);
	}

	public void OnStartOnboardingsShown()
	{
		ShowedStartOnboardingsThisSession = true;
	}

	public void OnTooltipPopupShown()
	{
		ShowedTooltipThisSession = true;
		NumberOfTooltipPopups++;
	}

	public bool ShouldShowTooltipPopup(int limit)
	{
		if (NumberOfTooltipPopups < limit)
		{
			return !ShowedTooltipThisSession;
		}
		return false;
	}

	public GameAnimation? GetNextGameAnimation()
	{
		if (AppConfig == null || AppConfig.GameConfig == null || AppConfig.GameConfig.Animations.Count == 0)
		{
			return null;
		}
		if (LastGameAnimationIndex >= AppConfig.GameConfig.Animations.Count - 1)
		{
			LastGameAnimationIndex = 0;
			return AppConfig.GameConfig.Animations.FirstOrDefault();
		}
		LastGameAnimationIndex++;
		return AppConfig.GameConfig.Animations.ElementAt(LastGameAnimationIndex);
	}

	public void OnGamePopupShown()
	{
		GamePopupLastShowTime = DateTime.UtcNow;
	}

	public void OnGameAnimationPopupShown()
	{
		ShowedGameAnimationPopup = true;
	}

	public void OnEcoCheckShown()
	{
		ShowedEcoCheck = true;
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	public bool IsGameActive()
	{
		if (AppConfig != null && AppConfig.GameConfig != null && AppConfig.GameConfig.GameEnabled && AppConfig.GameConfig.BeginsOn <= DateTime.UtcNow)
		{
			return AppConfig.GameConfig.EndsOn >= DateTime.UtcNow;
		}
		return false;
	}
}
