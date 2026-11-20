using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Controls.AutoLayout;
using Auchan.Common.Deeplinks;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Banners;
using Auchan.Common.Ecom.Banners.Models;
using Auchan.Common.Ecom.Banners.ViewModels;
using Auchan.Common.Ecom.Onboardings;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Home;
using Auchan.Common.InfoPages;
using Auchan.Common.LoyaltyProgram.Coupons;
using Auchan.Common.LoyaltyProgram.Coupons.Infrastructure;
using Auchan.Common.LoyaltyProgram.Coupons.Models;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Extensions;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.ViewModels.CardRollout;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;
using Auchan.Common.Navigation;
using Auchan.Common.NewYearGame;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using Auchan.Common.Recommendations;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.Tooltips;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;
using EBind;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Storage;

namespace Auchan.Common.LoyaltyProgram;

[RequiresAuthorization]
public class LoyaltyTabViewModel : AutoLayoutScreenViewModel, IYandexMetricaScreenViewModel, IScreenViewModel, ICouponsViewModel
{
	private enum BlockOrder
	{
		Card,
		GameBanner,
		Buttons,
		SocialStatus,
		PersOffers,
		Coupons,
		Help
	}

	public const float CouponRatio = 2.9385965f;

	public const string OfferActivationFailedMessage = "К сожалению, сейчас активация невозможна. Попробуйте позднее.";

	private bool _recommendationsViewed;

	private readonly IUserContext _userContext;

	private readonly IEcomContext _ecomContext;

	private readonly IAdminContext _adminContext;

	private readonly ITooltipsManager _tooltipsManager;

	private readonly Func<RecommendationBuilder> _recommendationBuilderFactory;

	private readonly IOnboardingsManager _onboardingsManager;

	private readonly CouponsRepository _couponsRepository;

	private readonly IDataBroker _dataBroker;

	private readonly Lazy<IRecommendationsGimaIdCache> _recommendationsPopularCache;

	private readonly Lazy<IUniversalLinksService> _universalLinksService;

	private readonly Lazy<ILoyaltyManager> _loyaltyManager;

	private readonly IBannersRepository _bannersRepository;

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	private readonly Subject<bool> _navigateSocialStatus = new Subject<bool>();

	private readonly Subject<FAQViewModel.Parameter> _navigateFaq = new Subject<FAQViewModel.Parameter>();

	private readonly Subject<InfoPageViewModel.Parameter> _navigateRules = new Subject<InfoPageViewModel.Parameter>();

	private readonly Subject<Unit> _navigateToPointsTransfer = new Subject<Unit>();

	private readonly Subject<Unit> _navigateToReissuePlasticOptions = new Subject<Unit>();

	private readonly Subject<LoyaltyCardReattachPlasticCardNavigationParameter> _navigateToReattach = new Subject<LoyaltyCardReattachPlasticCardNavigationParameter>();

	private readonly Subject<Deeplink> _openDeeplink = new Subject<Deeplink>();

	private readonly Subject<ProductsViewModel.Parameter> _openCashbackProducts = new Subject<ProductsViewModel.Parameter>();

	private readonly Subject<TooltipViewModel.Parameter> _openTooltips = new Subject<TooltipViewModel.Parameter>();

	private readonly Subject<SantaPopupDialogViewModel.Parameter> _openNewYearSantaPopup = new Subject<SantaPopupDialogViewModel.Parameter>();

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private LoyaltyCardElementViewModel _003CLoyaltyCardViewModel_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CRefreshCommand_003Ek__BackingField;

	[CompilerGenerated]
	private EndlessRecommendationsViewModel _003CRecommendations_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CCouponsAllAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CCouponsNewAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCouponsNewText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPersOffersNewText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CHasPersOffers_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CNewOffersCountText_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<OnboardingsViewModel.Parameter> _003COpenOnboardingsCommand_003Ek__BackingField;

	private bool _firstStart = true;

	private bool _onboardingWasAddedToQueue;

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

	public LoyaltyCardElementViewModel LoyaltyCardViewModel
	{
		[CompilerGenerated]
		get
		{
			return _003CLoyaltyCardViewModel_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CLoyaltyCardViewModel_003Ek__BackingField, value))
			{
				_003CLoyaltyCardViewModel_003Ek__BackingField = value;
				RaisePropertyChanged("LoyaltyCardViewModel");
			}
		}
	}

	public UICommand RefreshCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CRefreshCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CRefreshCommand_003Ek__BackingField, value))
			{
				_003CRefreshCommand_003Ek__BackingField = value;
				RaisePropertyChanged("RefreshCommand");
			}
		}
	} = new UICommand();

	public UICommand RefreshDoneCommand { get; } = new UICommand();

	public UICommand LoadCouponsCommand { get; } = new UICommand();

	public EndlessRecommendationsViewModel Recommendations
	{
		[CompilerGenerated]
		get
		{
			return _003CRecommendations_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CRecommendations_003Ek__BackingField, value))
			{
				_003CRecommendations_003Ek__BackingField = value;
				RaisePropertyChanged("Recommendations");
			}
		}
	}

	public UICommand ReloadRecommendationsCommand { get; } = new UICommand();

	public string Title => "Здравствуйте, " + _userContext.Profile.FirstName;

	public string ProgressTitle => "Загружаем карту лояльности…";

	public bool SocialStatusHintVisible
	{
		get
		{
			if (Preferences.Get("SocialStatusHintVisible", defaultValue: true) && !_userContext.Profile.IsConfirmedSocialStatus)
			{
				return !_userContext.Profile.IsAuchanEmployee;
			}
			return false;
		}
		private set
		{
			if (SocialStatusHintVisible != value)
			{
				Preferences.Set("SocialStatusHintVisible", value);
				RaisePropertyChanged("SocialStatusHintVisible");
			}
		}
	}

	public string MyCashbackText => "Мой Кешбэк";

	public string GiftPointsButton
	{
		get
		{
			if ((!_loyaltyManager.Value.IsPointsTransferEnabled || _adminContext.StampsConfig?.AllowStampsTransfer != true) && _loyaltyManager.Value.IsTransferEnabled)
			{
				if (_adminContext.StampsConfig?.AllowStampsTransfer != true)
				{
					return "Подарить баллы";
				}
				return "Подарить марки";
			}
			return "Подарить баллы\nи марки";
		}
	}

	public string MyOffers => "Мои предложения";

	public string MyCoupons => "Мои купоны и промокоды";

	public bool CouponsAllAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CCouponsAllAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CCouponsAllAvailable_003Ek__BackingField != value)
			{
				_003CCouponsAllAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("CouponsAllAvailable");
			}
		}
	}

	public bool CouponsNewAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CCouponsNewAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CCouponsNewAvailable_003Ek__BackingField != value)
			{
				_003CCouponsNewAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("CouponsNewAvailable");
			}
		}
	}

	public string CouponsNewText
	{
		[CompilerGenerated]
		get
		{
			return _003CCouponsNewText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCouponsNewText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCouponsNewText_003Ek__BackingField = value;
				RaisePropertyChanged("CouponsNewText");
			}
		}
	} = string.Empty;

	public string PersOffersNewText
	{
		[CompilerGenerated]
		get
		{
			return _003CPersOffersNewText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CPersOffersNewText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPersOffersNewText_003Ek__BackingField = value;
				RaisePropertyChanged("PersOffersNewText");
			}
		}
	} = string.Empty;

	public bool HasPersOffers
	{
		[CompilerGenerated]
		get
		{
			return _003CHasPersOffers_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CHasPersOffers_003Ek__BackingField != value)
			{
				_003CHasPersOffers_003Ek__BackingField = value;
				RaisePropertyChanged("HasPersOffers");
			}
		}
	}

	public ObservableRangeCollection<CouponItemViewModel> Coupons { get; } = new ObservableRangeCollection<CouponItemViewModel>();

	public ObservableRangeCollection<PersOfferItemViewModel> PersonalOffers { get; } = new ObservableRangeCollection<PersOfferItemViewModel>();

	IReadOnlyList<CouponItemViewModel> ICouponsViewModel.Coupons => Coupons;

	public string AllButtonText => "Все";

	public string NewOffersCountText
	{
		[CompilerGenerated]
		get
		{
			return _003CNewOffersCountText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CNewOffersCountText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CNewOffersCountText_003Ek__BackingField = value;
				RaisePropertyChanged("NewOffersCountText");
			}
		}
	} = string.Empty;

	public string NewYearGamePlayButtonText => _adminContext.AppConfig?.GameConfig?.ButtonText ?? "Играть";

	public ObservableRangeCollection<PromotionItemViewModel> BannerList { get; } = new ObservableRangeCollection<PromotionItemViewModel>();

	public string FAQButton => "Вопросы и ответы";

	public string ChatButton => "Написать нам";

	public bool IsChatEnabled => _adminContext.AppConfig?.IsChatEnabled ?? false;

	public string AddCardButton => "Добавить пластиковую карту";

	public string RulesButton => "Правила программы лояльности";

	public IObservable<bool> NavigateToSocialStatusCommand => _navigateSocialStatus.Debounce();

	public IObservable<FAQViewModel.Parameter> NavigateFAQCommand => _navigateFaq.Debounce();

	public UICommand NavigateToChatCommand { get; } = new UICommand();

	public IObservable<InfoPageViewModel.Parameter> NavigateLoyaltyRulesCommand => _navigateRules.Debounce();

	public IObservable<ProductsViewModel.Parameter> OpenCashbackProducts => _openCashbackProducts.Debounce();

	public IObservable<TooltipViewModel.Parameter> OpenTooltipsCommand => _openTooltips.Debounce();

	public IObservable<SantaPopupDialogViewModel.Parameter> OpenNewYearSantaPopup => _openNewYearSantaPopup.Debounce();

	public string AddPlasticCard => "Добавить пластиковую карту";

	public IObservable<Unit> NavigateToPointsTransferCommand => _navigateToPointsTransfer.Debounce();

	public IObservable<Unit> NavigateToReissuePlasticOptionsCommand => _navigateToReissuePlasticOptions.Debounce();

	public IObservable<LoyaltyCardReattachPlasticCardNavigationParameter> GoToReattachPlasticCardCommand => _navigateToReattach.Debounce();

	public UICommand OpenMyOffersCommand { get; } = new UICommand();

	public UICommand<BrokerToken> OpenOfferDetailsCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<BrokerToken> OpenAIOfferDetailsCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<ProductDetailsViewModel.Parameter> OpenProductDetailsCommand { get; } = new UICommand<ProductDetailsViewModel.Parameter>();

	public IObservable<Deeplink> OpenDeeplinkCommand => _openDeeplink.Debounce();

	public UICommand<OnboardingsViewModel.Parameter> OpenOnboardingsCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenOnboardingsCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003COpenOnboardingsCommand_003Ek__BackingField, value))
			{
				_003COpenOnboardingsCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenOnboardingsCommand");
			}
		}
	} = new UICommand<OnboardingsViewModel.Parameter>();

	public UICommand<CouponsViewModel.Parameter> OpenCouponsCommand { get; } = new UICommand<CouponsViewModel.Parameter>();

	public UICommand OpenAboutCouponsCommand { get; } = new UICommand();

	public UICommand<BrokerToken> OpenCouponDetailsCommand { get; } = new UICommand<BrokerToken>();

	public bool IsEmployeeLayout => _userContext.Profile?.IsAuchanEmployee ?? false;

	public string EmployeeNameText => _userContext.Profile?.FirstName ?? "";

	public string EmployeeDescriptionText => "Сотрудник АШАН Ритейл";

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "";

	string IYandexMetricaScreenViewModel.ScreenName => "Loyalty";

	public UICommand<LoyaltyPointsTransferNavigationParameter> NavigateToStampsTransferCommand { get; } = new UICommand<LoyaltyPointsTransferNavigationParameter>();

	public IBannerNavigationSupport BannerNavigationSupport { get; } = new BannerNavigationSupport();

	public LoyaltyTabViewModel(IUserContext userContext, IInfoMessageService messageService, IStoreService storeService, IEcomContext ecomContext, IAdminContext adminContext, ITooltipsManager tooltipsManager, Func<LoyaltyCardScreen, ScreenViewModel, LoyaltyCardElementViewModel> loyaltyCardElementVMFactory, Func<RecommendationBuilder> recommendationBuilderFactory, IOnboardingsManager onboardingsManager, CouponsRepository couponsRepository, EndlessRecommendationsViewModel recommendations, IDataBroker dataBroker, Lazy<IRecommendationsGimaIdCache> recommendationsPopularCache, Lazy<IInfoMessageService> infoMessageService, Lazy<IUniversalLinksService> universalLinksService, Lazy<ILoyaltyManager> loyaltyManager, IBannersRepository bannersRepository)
	{
		_userContext = userContext;
		_ecomContext = ecomContext;
		_adminContext = adminContext;
		_tooltipsManager = tooltipsManager;
		_infoMessageService = infoMessageService;
		_recommendationBuilderFactory = recommendationBuilderFactory;
		_onboardingsManager = onboardingsManager;
		_couponsRepository = couponsRepository;
		_recommendationsPopularCache = recommendationsPopularCache;
		_dataBroker = dataBroker;
		_universalLinksService = universalLinksService;
		_loyaltyManager = loyaltyManager;
		_bannersRepository = bannersRepository;
		Recommendations = recommendations.Setup(base.CloseDisposable, this, base.AutoLayout);
		base.ElementViewModels.Add(LoyaltyCardViewModel = loyaltyCardElementVMFactory(LoyaltyCardScreen.LoyaltyCard, this));
		base.AutoLayout.Insert(AutoLayoutViewModel.AutoLayoutElement.New("LoyaltyCardBlock", LoyaltyCardViewModel, BlockOrder.Card));
		base.AutoLayout.Insert(AutoLayoutViewModel.AutoLayoutElement.New("LoyaltyTabButtonsBlock", this, BlockOrder.Buttons));
		if (SocialStatusHintVisible)
		{
			base.AutoLayout.Insert(AutoLayoutViewModel.AutoLayoutElement.New("LoyaltyTabSocialStatusBlock", new LinkedText("Если вы относитесь к социальной категории граждан, зайдите в Профиль, мы расскажем вам о дополнительных возможностях.", "Профиль", OpenProfile), BlockOrder.SocialStatus));
		}
		base.AutoLayout.Insert(AutoLayoutViewModel.AutoLayoutElement.New("LoyaltyTabCoupons", Coupons, BlockOrder.Coupons));
		base.AutoLayout.Insert(AutoLayoutViewModel.AutoLayoutElement.New("LoyaltyTabHelpBlock", this, BlockOrder.Help));
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ActiveStore).StartWith(_ecomContext.ActiveStore).ObserveOn(Auchan.Common.Helpers.MainThread.Scheduler)
			.PerformSamplingTask(LoadPersonalOffers)
			.PerformDebouncingTask(LoadRecommendations)
			.Subscribe()
			.AddTo(base.CloseDisposable);
		RefreshCommand.PerformDebouncingTask(OnRefresh).Subscribe().AddTo(base.CloseDisposable);
		LoadCouponsCommand.PerformDebouncingTask(LoadCoupons).Subscribe().AddTo(base.CloseDisposable);
		_couponsRepository.CouponSeen += new DisposableDelegate<EventHandler<long>>(delegate
		{
			LoadCouponsCommand.Trigger();
		}, delegate(EventHandler<long> d)
		{
			_couponsRepository.CouponSeen -= d;
		}).AddTo(base.CloseDisposable);
		ReloadRecommendationsCommand.Subscribe(delegate
		{
			Recommendations.ReloadCommand.Trigger();
		}).AddTo(base.CloseDisposable);
		_userContext.AfterLoggedOut += delegate
		{
			Preferences.Clear("SocialStatusHintVisible");
			return Task.CompletedTask;
		};
	}

	protected override async Task OnResumed()
	{
		State = VisualState.InProgress;
		await base.OnResumed();
		Task<bool> shouldShowOnboardingsTask = _onboardingsManager.ShouldShowOnboardings(ShowAt.LoyaltyPage);
		if (shouldShowOnboardingsTask.IsCompleted)
		{
			Do(await shouldShowOnboardingsTask);
		}
		else
		{
			await Task.WhenAll(shouldShowOnboardingsTask, Task.Delay(1000));
			Do(shouldShowOnboardingsTask.Result);
		}
		State = VisualState.Default;
		_firstStart = false;
		DoShortRefresh(forceUpdate: false).SafeFireAndForget((Action<Exception>)null, false);
		void Do(bool shouldShowOnboardings)
		{
			if (!_firstStart && shouldShowOnboardings && !_onboardingWasAddedToQueue)
			{
				OpenOnboardingsCommand.Trigger(new OnboardingsViewModel.Parameter(ShowAt.LoyaltyPage));
				_onboardingWasAddedToQueue = true;
			}
			UpdateBannerListIfNeed();
		}
	}

	private void UpdateBannerListIfNeed()
	{
		foreach (PersOfferItemViewModel personalOffer in PersonalOffers)
		{
			personalOffer.Update();
		}
	}

	protected override async Task Start()
	{
		State = VisualState.InProgress;
		await base.Start();
		LoadRecommendations().SafeFireAndForget((Action<Exception>)null, false);
		_bannersRepository.OnBannersUpdate(delegate(object? o, BannersUpdatedEventArgs e)
		{
			LoadBanners(e.Banners).SafeFireAndForget((Action<Exception>)null, false);
		}).AddTo(base.CloseDisposable);
		LoadBanners().SafeFireAndForget((Action<Exception>)null, false);
		_adminContext.OnPropertyChanges((IAdminContext x) => x.PersonalOffers).StartWith(_adminContext.PersonalOffers).Subscribe(delegate
		{
			int countOfNewPersonalOffers = _adminContext.CountOfNewPersonalOffers;
			NewOffersCountText = ((countOfNewPersonalOffers == 0) ? string.Empty : $"{countOfNewPersonalOffers} нов{((countOfNewPersonalOffers % 10 == 1 && countOfNewPersonalOffers % 100 != 11) ? "ое" : "ых")}");
		})
			.AddTo(base.CloseDisposable);
		Result<Tooltip[], DomainError> tooltipsResult = await _tooltipsManager.GetTooltips();
		if (await _onboardingsManager.ShouldShowOnboardings(ShowAt.LoyaltyPage) && !_onboardingWasAddedToQueue)
		{
			OpenOnboardingsCommand.Trigger(new OnboardingsViewModel.Parameter(ShowAt.LoyaltyPage));
			_onboardingWasAddedToQueue = true;
		}
		if (tooltipsResult.IsSuccess)
		{
			Tooltip[] array = tooltipsResult.Value.Where((Tooltip t) => t.Target != TooltipTargetType.PriceChecker && t.Target != TooltipTargetType.FavoriteCategories).ToArray();
			if (!(_adminContext.AppConfig.LoyaltyConfig?.EPointsBalanceEnabled ?? true))
			{
				array = array.Where((Tooltip t) => t.Target != TooltipTargetType.ExpressPoints).ToArray();
			}
			if (array.Length != 0)
			{
				_openTooltips.OnNext(new TooltipViewModel.Parameter(array));
			}
		}
		State = VisualState.Default;
	}

	public void RunTask(Task task)
	{
		RunTaskAsync(task).SafeFireAndForget((Action<Exception>)null, false);
	}

	private Task LoadRecommendations()
	{
		LoadRequest loadRequest = _recommendationBuilderFactory().AddPopularEndless("Популярные товары для вас", "card_auchan_endless_shelf_personalized", "card_auchan_endless_shelf").Build();
		return Recommendations.Load(loadRequest);
	}

	public void OnRecommendationsViewed()
	{
		if (!_recommendationsViewed)
		{
			_recommendationsViewed = true;
			Recommendations.Viewed();
		}
	}

	private async Task RunTaskAsync(Task task)
	{
		await task;
	}

	private void OpenProfile()
	{
		_navigateSocialStatus.OnNext(_userContext.Profile?.IsConfirmedSocialStatus ?? false);
	}

	public void HideSocialStatusHint()
	{
		SocialStatusHintVisible = false;
		base.AutoLayout.Elements.RemoveAll((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "LoyaltyTabSocialStatusBlock");
	}

	public void CashbackClicked()
	{
		AppAnalytics.AppMetrica.TapLoyaltyOnCashback();
		_openCashbackProducts.OnNext(new ProductsViewModel.Parameter
		{
			Title = "Мой Кешбэк",
			Code = string.Empty,
			ProductsToLoadType = ProductsToLoad.ByCashbackAvailable,
			DefaultSortSelection = new ProductSortSelection
			{
				Direction = "desc",
				Field = "cashbackValue"
			},
			Breadcrumbs = new global::_003C_003Ez__ReadOnlySingleElementList<string>("Мой Кешбэк")
		});
	}

	public async Task PointsClicked()
	{
		AppAnalytics.AppMetrica.TapLoyaltyOnShareBonus();
		if (!_loyaltyManager.Value.IsPointsTransferEnabled && _adminContext.StampsConfig?.AllowStampsTransfer == true)
		{
			NavigateToStampsTransferCommand.Trigger(new LoyaltyPointsTransferNavigationParameter(0, 0, 0, LoyaltyPointType.Stamps, replacePrevious: false, forStamps: true));
		}
		else
		{
			_navigateToPointsTransfer.OnNext(Unit.Default);
		}
	}

	public void AllOffersClicked()
	{
		AppAnalytics.AppMetrica.TapLoyaltyOnAllOffers();
		OpenMyOffersCommand.Trigger();
	}

	public async void OnPersOfferTapped(PersOfferItemViewModel offerViewModel)
	{
		TrackBannerClick(offerViewModel);
		ProductDetailsViewModel.Parameter productParam = null;
		bool hasChanges;
		if (offerViewModel.IsAiOffer)
		{
			AIOfferDetailsViewModel.Parameter parameter = new AIOfferDetailsViewModel.Parameter(offerViewModel.Code);
			OpenAIOfferDetailsCommand.Trigger(_dataBroker.Push(parameter));
			AIOfferDetailsViewModel.OfferDetailsResult offerDetailsResult = await parameter.WaitForResultAsync();
			hasChanges = offerDetailsResult.HasChanges;
			productParam = offerDetailsResult.ProductDetailsParameter;
		}
		else
		{
			OfferDetailsViewModel.Parameter parameter2 = new OfferDetailsViewModel.Parameter(offerViewModel.Code);
			OpenOfferDetailsCommand.Trigger(_dataBroker.Push(parameter2));
			hasChanges = (await parameter2.WaitForResultAsync()).HasChanges;
		}
		if (productParam != null)
		{
			OpenProductDetailsCommand.Trigger(productParam);
		}
		else if (hasChanges)
		{
			LoadPersonalOffers().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public void OnBannerClicked(BannerItemViewModel bannerViewModel)
	{
		bannerViewModel.Banner.NavigateTo.Activate(BannerNavigationSupport);
	}

	public async void OnActivatePersOfferTapped(PersOfferItemViewModel offerViewModel)
	{
		if (!offerViewModel.IsAccepted)
		{
			AppAnalytics.AppMetrica.TrackEvent("Tap_MainPersonal_offer_activate");
			if ((await _adminContext.ActivatePersonalOffer(offerViewModel.LoymaxId)).IsSuccess)
			{
				offerViewModel.IsAccepted = true;
				PersonalOffers.ForceNotifyItemChanged(offerViewModel);
				_adminContext.InvalidatePersOffersCache();
			}
			else
			{
				_infoMessageService.Value.ShowSnackbar("К сожалению, сейчас активация невозможна. Попробуйте позднее.");
			}
		}
	}

	private void TrackBannerClick(PersOfferItemViewModel bannerViewModel)
	{
		int num = PersonalOffers.IndexOf(bannerViewModel);
		AppAnalytics.AppMetrica.PersonalOfferTapped(bannerViewModel.Code, bannerViewModel.Title, num + 1, this);
	}

	public void CouponTapped(CouponItemViewModel c)
	{
		AppAnalytics.AppMetrica.TrackEvent("Tap_offer");
		OpenCouponDetailsCommand.Trigger(_dataBroker.Push(new CouponDetailsViewModel.Parameter(c.Coupon)));
	}

	public void FaqClicked()
	{
		AppAnalytics.AppMetrica.OpenLoyaltyQuestions();
		_navigateFaq.OnNext(new FAQViewModel.Parameter(FAQType.Loyalty));
	}

	public void OnChatClick()
	{
		if (IsChatEnabled)
		{
			NavigateToChatCommand.Trigger();
		}
	}

	public void AddCardClicked()
	{
		OnReissuePlasticCardSelected();
	}

	public void LoyaltyRulesClicked()
	{
		ProfileModel? profile = _userContext.Profile;
		if (profile != null && profile.IsAuchanEmployee)
		{
			_navigateRules.OnNext(new InfoPageViewModel.Parameter(InfoType.EmployeesLoyaltyPolicy));
		}
		else
		{
			_navigateRules.OnNext(new InfoPageViewModel.Parameter(InfoType.LoyaltyPolicy));
		}
	}

	private async Task DoShortRefresh(bool forceUpdate)
	{
		await Task.WhenAll(LoadPersonalOffers(), LoadCoupons(), LoyaltyCardViewModel.Load(forceUpdate));
	}

	private async Task OnRefresh()
	{
		_recommendationsPopularCache.Value.Clear();
		await DoShortRefresh(forceUpdate: true);
		RaisePropertyChanged("GiftPointsButton");
		RefreshDoneCommand.Trigger();
	}

	private void OnReissuePlasticCardSelected()
	{
		if (_userContext.GetIsLoyaltyCardVirtual())
		{
			_navigateToReattach.OnNext(new LoyaltyCardReattachPlasticCardNavigationParameter
			{
				ReattachType = LoyaltyCardReattachType.ReattachVirtual
			});
		}
		else
		{
			_navigateToReissuePlasticOptions.OnNext(Unit.Default);
		}
	}

	private async Task LoadPersonalOffers()
	{
		Result<List<PersOfferItemViewModel>, DomainError> result = await _adminContext.GetPersonalOffers();
		List<AutoLayoutViewModel.AutoLayoutElement> list = base.AutoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "LoyaltyTabPersOffers").ToList();
		if (result.IsFailure || result.Value.Count == 0)
		{
			HasPersOffers = false;
			base.AutoLayout.Elements.RemoveRange(list);
			return;
		}
		PersonalOffers.ReplaceRange(_adminContext.PersonalOffers);
		HasPersOffers = PersonalOffers.Count > 0;
		if (list.Any())
		{
			base.AutoLayout.Elements.ReplaceRange(base.AutoLayout.Elements.IndexOf(list.First()), list.Count(), new global::_003C_003Ez__ReadOnlySingleElementList<AutoLayoutViewModel.AutoLayoutElement>(AutoLayoutViewModel.AutoLayoutElement.New("LoyaltyTabPersOffers", PersonalOffers, BlockOrder.PersOffers)));
		}
		else
		{
			base.AutoLayout.Insert(AutoLayoutViewModel.AutoLayoutElement.New("LoyaltyTabPersOffers", PersonalOffers, BlockOrder.PersOffers));
		}
		int num = PersonalOffers.Count((PersOfferItemViewModel b) => !b.IsViewed);
		PersOffersNewText = ((num == 0) ? string.Empty : $"+{num}");
	}

	private async Task LoadBanners(IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>? banners = null)
	{
		if (!Microsoft.Maui.ApplicationModel.MainThread.IsMainThread)
		{
			throw new InvalidOperationException("can't operate @ background thread");
		}
		Result<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError> result = ((banners == null) ? (await _bannersRepository.GetBannersAsync()) : Result.Success<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError>(banners));
		Result<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError> result2 = result;
		ImmutableList<AutoLayoutViewModel.AutoLayoutElement> toRemove = base.AutoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "GameBanner").ToImmutableList();
		IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>> value;
		IReadOnlyList<BannerItemViewModel> loyaltyBannerItems = AdditionalBannerCarouselProvider.GetLoyaltyBannerItems((IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>?)(result2.TryGetValue(out value) ? ((IEnumerable)value) : ((IEnumerable)_bannersRepository.NoBanners)));
		if (loyaltyBannerItems.Any())
		{
			base.AutoLayout.ReplaceOrInsertRange(toRemove, new global::_003C_003Ez__ReadOnlySingleElementList<AutoLayoutViewModel.AutoLayoutElement>(AutoLayoutViewModel.AutoLayoutElement.New("GameBanner", loyaltyBannerItems, BlockOrder.GameBanner)));
		}
	}

	private async Task LoadCoupons()
	{
		Result<List<Coupon>, DomainError> result = await _couponsRepository.GetCoupons();
		if (result.IsFailure)
		{
			Coupons.ReplaceRange(Enumerable.Repeat(new CouponItemViewModel(), 1));
			CouponsAllAvailable = false;
			CouponsNewAvailable = false;
			return;
		}
		Coupons.ReplaceRange(result.Value.Select((Coupon c) => new CouponItemViewModel(c)).ToList());
		CouponsAllAvailable = true;
		CouponsNewAvailable = result.Value.Any((Coupon c) => c.IsNew);
		if (CouponsNewAvailable)
		{
			int value = result.Value.Count((Coupon c) => c.IsNew);
			CouponsNewText = $"+{value}";
		}
		List<AutoLayoutViewModel.AutoLayoutElement> source = base.AutoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "LoyaltyTabCoupons").ToList();
		if (source.Any())
		{
			base.AutoLayout.Elements.ReplaceRange(base.AutoLayout.Elements.IndexOf(source.First()), source.Count(), new global::_003C_003Ez__ReadOnlySingleElementList<AutoLayoutViewModel.AutoLayoutElement>(AutoLayoutViewModel.AutoLayoutElement.New("LoyaltyTabCoupons", Coupons, BlockOrder.Coupons)));
		}
		else
		{
			base.AutoLayout.Insert(AutoLayoutViewModel.AutoLayoutElement.New("LoyaltyTabCoupons", Coupons, BlockOrder.Coupons));
		}
	}
}
