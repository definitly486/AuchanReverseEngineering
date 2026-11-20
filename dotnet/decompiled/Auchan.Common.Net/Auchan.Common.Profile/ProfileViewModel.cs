using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.DependencyInjection;
using Auchan.Common.DeveloperMenu;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Drive;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages;
using Auchan.Common.InfoPages.Models;
using Auchan.Common.Logs;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;
using Auchan.Common.Navigation;
using Auchan.Common.Notifications;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using Auchan.Common.PersonalCabinet.DomainModels;
using Auchan.Common.Profile.WaitList;
using Auchan.Common.Recommendations;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.Recommendations.ViewModels;
using Auchan.Common.Reviews;
using Auchan.Common.StoreReview;
using Auchan.Common.SupportChat;
using CSharpFunctionalExtensions;
using DryIoc;
using EBind;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Profile;

public sealed class ProfileViewModel : ScreenViewModel, IYandexMetricaScreenViewModel, IScreenViewModel
{
	public enum VisualState
	{
		Default,
		InProgress
	}

	private const string _errorMessage = "Не удалось отправить логи, повторите попытку";

	public const int VersionLongPressSeconds = 5;

	private readonly IEcomContext _ecomContext;

	private readonly IUserContext _userContext;

	private readonly IAdminContext _adminContext;

	private readonly IInfoMessageService _infoMessageService;

	private readonly ILogService _logService;

	private readonly IInfoPagesRepository _infoPagesRepository;

	private readonly ILoginManager _loginManager;

	private readonly INavigationService _navigationService;

	private readonly ICarsRepository _carsRepository;

	private readonly ReviewsEcomService _reviewsEcomService;

	private readonly SupportChatMessageManager _supportChatMessageManager;

	private readonly WaitListProducts _waitListProducts;

	private readonly NotificationsCounterService _notificationsCounterService;

	private readonly Subject<Unit> _navigateToUserData = new Subject<Unit>();

	private readonly Subject<Unit> _navigateToNotifications = new Subject<Unit>();

	private readonly Subject<Unit> _navigateToUserOrders = new Subject<Unit>();

	private readonly Subject<Unit> _navigateToUserFavorites = new Subject<Unit>();

	private readonly Subject<Unit> _navigateToUserWaitList = new Subject<Unit>();

	private readonly Subject<Unit> _navigateToUserCars = new Subject<Unit>();

	private readonly Subject<Unit> _navigateToAutoOnboarding = new Subject<Unit>();

	private readonly Subject<bool> _navigateToSocialStatus = new Subject<bool>();

	private readonly Subject<Unit> _navigateToUserAddresses = new Subject<Unit>();

	private readonly Subject<Unit> _navigateToUserCards = new Subject<Unit>();

	private readonly Subject<Unit> _navigateToStores = new Subject<Unit>();

	private readonly Subject<InfoPageIntermediateViewModel.Parameter> _navigateToInfoPages = new Subject<InfoPageIntermediateViewModel.Parameter>();

	private readonly Subject<FAQViewModel.Parameter> _navigateToFAQ = new Subject<FAQViewModel.Parameter>();

	private readonly Subject<Unit> _navigateToTutorials = new Subject<Unit>();

	private readonly Subject<Unit> _navigateToSafeEntrance = new Subject<Unit>();

	private readonly Subject<Unit> _sendLogs = new Subject<Unit>();

	private const string IS_ONBOARDING_SHOWED_CACHE_KEY = "IS_ONBOARDING_SHOWED_CACHE_KEY ";

	private const int VersionClickMaxCount = 10;

	private int _versionClickCount;

	private CancellationTokenSource? _versionTimerTokenSource;

	private Task? _versionTimerTask;

	private readonly TaskQueue _recommendationsQueue = new TaskQueue();

	private readonly Func<RecommendationBuilder> _recommendationBuilderFactory;

	[CompilerGenerated]
	private List<string> _003C_paymentAndDeliverySlugs_003Ek__BackingField;

	[CompilerGenerated]
	private List<string> _003C_refundAndExchangeSlugs_003Ek__BackingField;

	[CompilerGenerated]
	private List<string> _003C_documentsSlugs_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsPaymentAndDeliveryVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsCarsViewVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsSocialStatusViewVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsRefundAndExchangeVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsDocumentsVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsGiftCardsVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsUserReviewsVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsAuchanPayVisible_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAppVersion_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CUserMuid_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CUnreadMessageCount_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CProductsCountInWaitList_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CWaitingForReviewProductsCount_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CNotificationsCount_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CNavigateToGiftCardsCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CNavigateToUserCasesCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CNavigateToUserReviewsCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<InfoPageViewModel.Parameter> _003CNavigateToInfoPageCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CNavigateToSalesAndNewsCommand_003Ek__BackingField;

	[CompilerGenerated]
	private RecommendationsViewModel _003CRecommendations_003Ek__BackingField;

	private List<string> _paymentAndDeliverySlugs
	{
		[CompilerGenerated]
		get
		{
			return _003C_paymentAndDeliverySlugs_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003C_paymentAndDeliverySlugs_003Ek__BackingField, value))
			{
				_003C_paymentAndDeliverySlugs_003Ek__BackingField = value;
				RaisePropertyChanged("_paymentAndDeliverySlugs");
			}
		}
	} = new List<string>();

	private List<string> _refundAndExchangeSlugs
	{
		[CompilerGenerated]
		get
		{
			return _003C_refundAndExchangeSlugs_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003C_refundAndExchangeSlugs_003Ek__BackingField, value))
			{
				_003C_refundAndExchangeSlugs_003Ek__BackingField = value;
				RaisePropertyChanged("_refundAndExchangeSlugs");
			}
		}
	} = new List<string>();

	private List<string> _documentsSlugs
	{
		[CompilerGenerated]
		get
		{
			return _003C_documentsSlugs_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003C_documentsSlugs_003Ek__BackingField, value))
			{
				_003C_documentsSlugs_003Ek__BackingField = value;
				RaisePropertyChanged("_documentsSlugs");
			}
		}
	} = new List<string>();

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
	} = "";

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
	} = "";

	public string ProgressTitle => "Загружаем ваш профиль…";

	public string UnauthorizedUserLabelText => "Авторизуйтесь\nили зарегистрируйтесь";

	public string AuthorizeButtonText => "Авторизация";

	public string UserDataText => "Мои данные";

	public string UserOrdersText => "Мои заказы";

	public string UserReviewsText => "Мои отзывы";

	public string UserFavoritesText => "Избранное";

	public string UserWaitListText => "Лист ожидания";

	public string UserNotificationsText => "Уведомления";

	public string UserGiftCardsText => "Подарочные карты";

	public string UserCasesText => "Мои обращения";

	public string SalesAndNewsText => "Акции и новости";

	public string UserCarsText => "Мои автомобили";

	public string SocialStatusText => "Социальный Статус";

	public string LoyaltyPurchaseHistoryText => "Мои покупки";

	public string UserAddressesText => "Адреса доставки";

	public string UserCardsText => "Мои карты";

	public string AuchanPayText => "АШАН Pay";

	public string AboutStoresText => "Магазины рядом";

	public string AboutDeliveryText => "Доставка и оплата";

	public string AboutRefundText => "Обмен и возврат товаров";

	public string AboutVacancyText => "Вакансии АШАН";

	public string HelpSectionHeaderText => "Помощь";

	public string HelpFAQText => "Вопросы и ответы";

	public string HelpTutorialsText => "Обучающие инструкции";

	public string FeedbackSectionHeaderText => "Связаться с нами";

	public string FeedbackChatText => "Написать";

	public string FeedbackCallText => "Позвонить";

	public string DocumentsText => "Документы";

	public string SafeEntranceText => "Безопасный вход";

	public bool IsPaymentAndDeliveryVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsPaymentAndDeliveryVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsPaymentAndDeliveryVisible_003Ek__BackingField != value)
			{
				_003CIsPaymentAndDeliveryVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsPaymentAndDeliveryVisible");
			}
		}
	}

	public bool IsCarsViewVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsCarsViewVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsCarsViewVisible_003Ek__BackingField != value)
			{
				_003CIsCarsViewVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsCarsViewVisible");
			}
		}
	}

	public bool IsSocialStatusViewVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsSocialStatusViewVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsSocialStatusViewVisible_003Ek__BackingField != value)
			{
				_003CIsSocialStatusViewVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsSocialStatusViewVisible");
			}
		}
	}

	public bool IsRefundAndExchangeVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsRefundAndExchangeVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsRefundAndExchangeVisible_003Ek__BackingField != value)
			{
				_003CIsRefundAndExchangeVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsRefundAndExchangeVisible");
			}
		}
	}

	public bool IsDocumentsVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsDocumentsVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsDocumentsVisible_003Ek__BackingField != value)
			{
				_003CIsDocumentsVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsDocumentsVisible");
			}
		}
	}

	public bool IsGiftCardsVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsGiftCardsVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsGiftCardsVisible_003Ek__BackingField != value)
			{
				_003CIsGiftCardsVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsGiftCardsVisible");
			}
		}
	}

	public bool IsUserReviewsVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsUserReviewsVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsUserReviewsVisible_003Ek__BackingField != value)
			{
				_003CIsUserReviewsVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsUserReviewsVisible");
			}
		}
	}

	public bool IsChatEnabled => _adminContext.AppConfig?.IsChatEnabled ?? false;

	public bool IsAuchanPayVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsAuchanPayVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsAuchanPayVisible_003Ek__BackingField != value)
			{
				_003CIsAuchanPayVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsAuchanPayVisible");
			}
		}
	}

	public string UserName => _userContext.Profile?.FirstName + " " + _userContext.Profile?.LastName;

	public string AppVersion
	{
		[CompilerGenerated]
		get
		{
			return _003CAppVersion_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CAppVersion_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAppVersion_003Ek__BackingField = value;
				RaisePropertyChanged("AppVersion");
			}
		}
	} = (DeviceInfo.Platform == DevicePlatform.Android) ? $"Версия {AppInfo.VersionString} ({AppInfo.BuildString})" : $"Версия {AppInfo.BuildString} ({AppInfo.VersionString})";

	public string RecomTechNote => "В приложении используются рекомендательные технологии";

	public string UserMuid
	{
		[CompilerGenerated]
		get
		{
			return _003CUserMuid_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CUserMuid_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CUserMuid_003Ek__BackingField = value;
				RaisePropertyChanged("UserMuid");
			}
		}
	}

	public int UnreadMessageCount
	{
		[CompilerGenerated]
		get
		{
			return _003CUnreadMessageCount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CUnreadMessageCount_003Ek__BackingField != value)
			{
				_003CUnreadMessageCount_003Ek__BackingField = value;
				RaisePropertyChanged("UnreadMessageCount");
			}
		}
	}

	public int ProductsCountInWaitList
	{
		[CompilerGenerated]
		get
		{
			return _003CProductsCountInWaitList_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CProductsCountInWaitList_003Ek__BackingField != value)
			{
				_003CProductsCountInWaitList_003Ek__BackingField = value;
				RaisePropertyChanged("ProductsCountInWaitList");
			}
		}
	}

	public int WaitingForReviewProductsCount
	{
		[CompilerGenerated]
		get
		{
			return _003CWaitingForReviewProductsCount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CWaitingForReviewProductsCount_003Ek__BackingField != value)
			{
				_003CWaitingForReviewProductsCount_003Ek__BackingField = value;
				RaisePropertyChanged("WaitingForReviewProductsCount");
			}
		}
	}

	public int NotificationsCount
	{
		[CompilerGenerated]
		get
		{
			return _003CNotificationsCount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CNotificationsCount_003Ek__BackingField != value)
			{
				_003CNotificationsCount_003Ek__BackingField = value;
				RaisePropertyChanged("NotificationsCount");
			}
		}
	}

	public IObservable<Unit> NavigateToUserDataCommand => _navigateToUserData.Debounce();

	public IObservable<Unit> NavigateToUserOrdersCommand => _navigateToUserOrders.Debounce();

	public IObservable<Unit> NavigateToUserFavoritesCommand => _navigateToUserFavorites.Debounce();

	public IObservable<Unit> NavigateToUserWaitListCommand => _navigateToUserWaitList.Debounce();

	public IObservable<Unit> NavigateToNotificationsCommand => _navigateToNotifications.Debounce();

	public UICommand NavigateToGiftCardsCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CNavigateToGiftCardsCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CNavigateToGiftCardsCommand_003Ek__BackingField, value))
			{
				_003CNavigateToGiftCardsCommand_003Ek__BackingField = value;
				RaisePropertyChanged("NavigateToGiftCardsCommand");
			}
		}
	} = new UICommand();

	public UICommand NavigateToUserCasesCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CNavigateToUserCasesCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CNavigateToUserCasesCommand_003Ek__BackingField, value))
			{
				_003CNavigateToUserCasesCommand_003Ek__BackingField = value;
				RaisePropertyChanged("NavigateToUserCasesCommand");
			}
		}
	} = new UICommand();

	public UICommand NavigateToUserReviewsCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CNavigateToUserReviewsCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CNavigateToUserReviewsCommand_003Ek__BackingField, value))
			{
				_003CNavigateToUserReviewsCommand_003Ek__BackingField = value;
				RaisePropertyChanged("NavigateToUserReviewsCommand");
			}
		}
	} = new UICommand();

	public IObservable<Unit> NavigateToUserCarsCommand => _navigateToUserCars.Debounce();

	public IObservable<Unit> NavigateToAutoOnboardingCommand => _navigateToAutoOnboarding.Debounce();

	public IObservable<bool> NavigateToSocialStatusCommand => _navigateToSocialStatus.Debounce();

	public UICommand<MyPurchasesViewModel.Parameter> NavigateToPurchaseHistoryCommand { get; } = new UICommand<MyPurchasesViewModel.Parameter>(new MyPurchasesViewModel.Parameter
	{
		OpenOnStartup = MyPurchasesViewModel.FiltersIds.Purchase
	});

	public IObservable<Unit> NavigateToUserAddressesCommand => _navigateToUserAddresses.Debounce();

	public IObservable<Unit> NavigateToUserCardsCommand => _navigateToUserCards.Debounce();

	public IObservable<Unit> NavigateToStoresCommand => _navigateToStores.Debounce();

	public IObservable<InfoPageIntermediateViewModel.Parameter> NavigateToInfoPagesCommand => _navigateToInfoPages.Debounce();

	public UICommand<InfoPageViewModel.Parameter> NavigateToInfoPageCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CNavigateToInfoPageCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CNavigateToInfoPageCommand_003Ek__BackingField, value))
			{
				_003CNavigateToInfoPageCommand_003Ek__BackingField = value;
				RaisePropertyChanged("NavigateToInfoPageCommand");
			}
		}
	} = new UICommand<InfoPageViewModel.Parameter>();

	public UICommand NavigateToSalesAndNewsCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CNavigateToSalesAndNewsCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CNavigateToSalesAndNewsCommand_003Ek__BackingField, value))
			{
				_003CNavigateToSalesAndNewsCommand_003Ek__BackingField = value;
				RaisePropertyChanged("NavigateToSalesAndNewsCommand");
			}
		}
	} = new UICommand();

	public IObservable<FAQViewModel.Parameter> NavigateToFAQCommand => _navigateToFAQ.Debounce();

	public IObservable<Unit> NavigateToTutorialsCommand => _navigateToTutorials.Debounce();

	public UICommand NavigateToDevMenuCommand { get; } = new UICommand();

	public IObservable<Unit> NavigateToSafeEntranceCommand => _navigateToSafeEntrance.Debounce();

	public UICommand NavigateToChatCommand { get; } = new UICommand();

	public RecommendationsViewModel Recommendations
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

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "Profile";

	string IYandexMetricaScreenViewModel.ScreenName => "Profile";

	public UICommand OpenPasswordEnterCommand { get; } = new UICommand();

	public ProfileViewModel(IUserContext userContext, IEcomContext ecomContext, IAdminContext adminContext, IInfoMessageService infoMessageService, ILogService logService, ICarsRepository carsRepository, IInfoPagesRepository infoPagesRepository, ILoginManager loginManager, INavigationService navigationService, ReviewsEcomService reviewsEcomService, SupportChatMessageManager supportChatMessageManager, WaitListProducts waitListProducts, NotificationsCounterService notificationsCounterService, RecommendationsViewModel recommendations, Func<RecommendationBuilder> recommendationBuilderFactory)
	{
		_userContext = userContext;
		_adminContext = adminContext;
		_infoMessageService = infoMessageService;
		_logService = logService;
		_carsRepository = carsRepository;
		_ecomContext = ecomContext;
		_infoPagesRepository = infoPagesRepository;
		_loginManager = loginManager;
		_navigationService = navigationService;
		_reviewsEcomService = reviewsEcomService;
		_supportChatMessageManager = supportChatMessageManager;
		_waitListProducts = waitListProducts;
		_notificationsCounterService = notificationsCounterService;
		_recommendationBuilderFactory = recommendationBuilderFactory;
		_notificationsCounterService.Count.Subscribe(delegate(int count)
		{
			MainThread.BeginInvokeOnMainThread(delegate
			{
				NotificationsCount = count;
			});
		}).AddTo(base.CloseDisposable);
		Recommendations = recommendations.Setup(base.CloseDisposable, this);
		UserMuid = $"Номер клиента: {_userContext.Profile?.MagentoAccountId}";
		_userContext.OnPropertyChanges((IUserContext x) => x.Profile).StartWith(_userContext.Profile).Subscribe(delegate
		{
			RaisePropertyChanged("UserMuid");
			RaisePropertyChanged("UserName");
		})
			.AddTo(base.CloseDisposable);
		_sendLogs.PerformDebouncingTask(SendLogs).Subscribe().AddTo(base.CloseDisposable);
	}

	public void OnGiftCardsClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_gift_cards");
		NavigateToGiftCardsCommand.Trigger();
	}

	public void OnUserCasesClick()
	{
		NavigateToUserCasesCommand.Trigger();
	}

	public void OnUserReviewsClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_reviews");
		NavigateToUserReviewsCommand.Trigger();
	}

	public void OnSalesAndNewsTap()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_News");
		NavigateToSalesAndNewsCommand.Trigger();
	}

	public void OnModifyClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_FIO");
		_navigateToUserData.OnNext(Unit.Default);
	}

	public void OnUserOrdersClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_auth_my_orders");
		_navigateToUserOrders.OnNext(Unit.Default);
	}

	public void OnUserFavoritesClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_Favorites");
		_navigateToUserFavorites.OnNext(Unit.Default);
	}

	public void OnUserWaitListClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_waiting_list");
		_navigateToUserWaitList.OnNext(Unit.Default);
	}

	public void OnNotificationsClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_notifications");
		_navigateToNotifications.OnNext(Unit.Default);
	}

	public void OnUserCarsClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_my_cars");
		if (!Preferences.Get("IS_ONBOARDING_SHOWED_CACHE_KEY ", defaultValue: false) && !_ecomContext.ActiveStore.HasCarPickup && _carsRepository.Cars.Count == 0)
		{
			Preferences.Set("IS_ONBOARDING_SHOWED_CACHE_KEY ", value: true);
			_navigateToAutoOnboarding.OnNext(Unit.Default);
		}
		_navigateToUserCars.OnNext(Unit.Default);
	}

	public void OnPurchaseHistoryClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_history_order_composition_screen");
		NavigateToPurchaseHistoryCommand.Trigger();
	}

	public void OnUserAddressesClick()
	{
		_infoMessageService.ShowNotImplementedMessage();
	}

	public void OnUserCardsClick()
	{
		_navigateToUserCards.OnNext(Unit.Default);
	}

	public void OnStoresClick()
	{
		AppAnalytics.AppMetrica.TapMainOnNearbyStores();
		_navigateToStores.OnNext(Unit.Default);
	}

	public void OnFAQClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_FAQ");
		ProfileModel? profile = _userContext.Profile;
		if (profile != null && profile.IsAuchanEmployee)
		{
			_navigateToFAQ.OnNext(new FAQViewModel.Parameter(FAQType.Employees));
		}
		else
		{
			_navigateToFAQ.OnNext(new FAQViewModel.Parameter(FAQType.Default));
		}
	}

	public void OnTutorialsClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_manuals");
		_navigateToTutorials.OnNext(Unit.Default);
	}

	public void OnNavigateToPaymentAndDelivery()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_deliverydetails");
		OnNavigateToInfoPagesClick(InfoPagePosition.PaymentDelivery, _paymentAndDeliverySlugs);
	}

	public void OnNavigateToExchangeAndRefund()
	{
		OnNavigateToInfoPagesClick(InfoPagePosition.RefundExchange, _refundAndExchangeSlugs);
	}

	public void OnNavigateToVacancy()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_vacancies");
		NavigateToInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.Vacancy));
	}

	public void OnNavigateToDocuments()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_documents");
		OnNavigateToInfoPagesClick(InfoPagePosition.Documents, _documentsSlugs);
	}

	public void OnVersionClick()
	{
		_versionClickCount++;
		if (_versionClickCount >= 10)
		{
			_versionClickCount = 0;
			OpenPasswordEnterCommand.Trigger();
		}
	}

	public void OnVersionDown()
	{
		_versionTimerTokenSource = new CancellationTokenSource();
		CancellationToken token = _versionTimerTokenSource.Token;
		_versionTimerTask = Task.Run(async delegate
		{
			try
			{
				await Task.Delay(5000);
				if (!token.IsCancellationRequested)
				{
					_sendLogs.OnNext(Unit.Default);
				}
			}
			catch (TaskCanceledException)
			{
			}
		}, token);
		_versionTimerTask.SafeFireAndForget((Action<Exception>)null, false);
	}

	public void OnVersionUp()
	{
		_versionTimerTokenSource?.Cancel();
		OnVersionClick();
	}

	public void OnVersionLongPress()
	{
		_sendLogs.OnNext(Unit.Default);
	}

	public void OnSocialStatusClick()
	{
		bool value = _userContext.Profile?.IsConfirmedSocialStatus ?? false;
		_navigateToSocialStatus.OnNext(value);
	}

	public void OnFeedbackCallClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_phone");
		_navigationService.CallToAuchanSupport();
	}

	public void OnFeedbackChatClick()
	{
		if (IsChatEnabled)
		{
			AppAnalytics.AppMetrica.TrackEvent("tap_feedback");
			NavigateToChatCommand.Trigger();
		}
	}

	protected override async Task Start()
	{
		State = VisualState.InProgress;
		await base.Start();
		Task task = LoadInfoPages();
		Task<Result<bool, DomainError>> showReviewsTask = _reviewsEcomService.CheckShouldDisplayMyReviewsAsync();
		await Task.WhenAll(task, showReviewsTask);
		IsAuchanPayVisible = false;
		IsGiftCardsVisible = _adminContext.AppConfig?.GiftCardsEnabled ?? false;
		Result<bool, DomainError> result = showReviewsTask.Result;
		IsUserReviewsVisible = result.IsSuccess && result.Value;
		_loginManager.ShouldNavigateToProfile = false;
		_supportChatMessageManager.OnUnreadMessagesCountChanged += new DisposableDelegate<EventHandler<int>>(delegate(object? o, int e)
		{
			MainThread.BeginInvokeOnMainThread(delegate
			{
				UnreadMessageCount = e;
			});
		}, delegate(EventHandler<int> eh)
		{
			_supportChatMessageManager.OnUnreadMessagesCountChanged -= eh;
		}).AddTo(base.CloseDisposable);
		_waitListProducts.OnProductsCountInWaitListChanged += new DisposableDelegate<EventHandler<int>>(delegate(object? o, int e)
		{
			MainThread.BeginInvokeOnMainThread(delegate
			{
				ProductsCountInWaitList = e;
			});
		}, delegate(EventHandler<int> eh)
		{
			_waitListProducts.OnProductsCountInWaitListChanged -= eh;
		}).AddTo(base.CloseDisposable);
		State = VisualState.Default;
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		ProfileModel profile = _userContext.Profile;
		if (profile != null)
		{
			UpdateAllCountIcons().SafeFireAndForget((Action<Exception>)null, true);
			LoadRecommendations().SafeFireAndForget((Action<Exception>)null, true);
			_logService.LogInfo("ProfileViewModel", "Открыт экран профиля", LogType.UserAction, SystemType.MobileApp);
			_versionClickCount = 0;
			IsCarsViewVisible = _ecomContext.ActiveStore.HasCarPickup;
			IsSocialStatusViewVisible = !profile.IsAuchanEmployee;
			DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<Auchan.Common.StoreReview.StoreReview>().RequestReviewIfNeeded().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public void OnEmailClientsNotFound()
	{
		_infoMessageService.ShowSnackbar("Почтовые клиенты не найдены.");
	}

	public void OnNavigateToSafeEntranceClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_PINcode");
		_navigateToSafeEntrance.OnNext(Unit.Default);
	}

	private async Task SendLogs()
	{
		State = VisualState.InProgress;
		Result<Unit, DomainError> result = await _logService.SendLogs();
		if (result.IsFailure)
		{
			if (!string.IsNullOrEmpty(result.Error?.Message))
			{
				_infoMessageService.ShowSnackbar(string.Format("Не удалось отправить логи, повторите попытку", "\nОтвет: " + result.Error.Message));
			}
			else
			{
				_infoMessageService.ShowSnackbar($"Не удалось отправить логи, повторите попытку");
			}
		}
		else
		{
			_infoMessageService.ShowSnackbar("Логи успешно отправлены", SnackbarStyle.Success);
		}
		State = VisualState.Default;
	}

	private async Task LoadInfoPages()
	{
		Result<List<InfoPage>, DomainError> result = await _infoPagesRepository.InfoPages();
		if (result.IsFailure)
		{
			IsDocumentsVisible = false;
			IsPaymentAndDeliveryVisible = false;
			IsRefundAndExchangeVisible = false;
			return;
		}
		_documentsSlugs.AddRange(from x in result.Value
			where x.Position == InfoPagePosition.Documents
			select x.Slug);
		_paymentAndDeliverySlugs.AddRange(from x in result.Value
			where x.Position == InfoPagePosition.PaymentDelivery
			select x.Slug);
		_refundAndExchangeSlugs.AddRange(from x in result.Value
			where x.Position == InfoPagePosition.RefundExchange
			select x.Slug);
		IsDocumentsVisible = _documentsSlugs.Any();
		IsPaymentAndDeliveryVisible = _paymentAndDeliverySlugs.Any();
		IsRefundAndExchangeVisible = _refundAndExchangeSlugs.Any();
	}

	private async Task UpdateAllCountIcons()
	{
		State = VisualState.InProgress;
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		Result<int, DomainError> result = await _supportChatMessageManager.GetUnreadMessageCount();
		UnreadMessageCount = (result.IsSuccess ? result.Value : 0);
		ProductsCountInWaitList = _waitListProducts.ProductsCountInWaitList;
		Result<(IReadOnlyList<UnreviewedProductItemViewModel>, int), DomainError> result2 = await _reviewsEcomService.GetUnreviewedProductsAsync(0, 0);
		WaitingForReviewProductsCount = (result2.IsSuccess ? result2.Value.Item2 : 0);
		State = VisualState.Default;
	}

	private void OnNavigateToInfoPagesClick(InfoPagePosition position, List<string> slugs)
	{
		_navigateToInfoPages.OnNext(new InfoPageIntermediateViewModel.Parameter(slugs, InfoPagesConverter.PositionToCategoryTitle(position)));
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

	private Task LoadRecommendations()
	{
		return _recommendationsQueue.Enqueue(async delegate
		{
			LoadRequest loadRequest = _recommendationBuilderFactory().AddPersonalViewed("Вы смотрели", "recently_viewed_profile").Build();
			await Recommendations.Load(loadRequest);
		});
	}
}
