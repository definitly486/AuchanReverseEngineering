using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Akavache;
using AsyncAwaitBestPractices;
using Auchan.Common.Addresses;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Analytics.YandexAppMetrica.DataStores;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Cache;
using Auchan.Common.Cashback.Wallet;
using Auchan.Common.Common;
using Auchan.Common.DependencyInjection;
using Auchan.Common.DeveloperMenu;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.CtmShelves;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.Onboardings.Infrastructure;
using Auchan.Common.Ecom.PriceChecker;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Home;
using Auchan.Common.InfoPages;
using Auchan.Common.Logs;
using Auchan.Common.LoyaltyProgram.Coupons.Infrastructure;
using Auchan.Common.LoyaltyProgram.DependencyRegistry;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.Maintenance;
using Auchan.Common.Managers.AppActionManager;
using Auchan.Common.Navigation;
using Auchan.Common.Networking;
using Auchan.Common.NewYearGame;
using Auchan.Common.Notifications;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalOffers;
using Auchan.Common.Processing;
using Auchan.Common.Profile;
using Auchan.Common.Profile.Cases;
using Auchan.Common.Profile.GiftCards.Infrastructure;
using Auchan.Common.Profile.Stores.Infrastructure;
using Auchan.Common.Profile.WaitList;
using Auchan.Common.Recommendations;
using Auchan.Common.Reviews;
using Auchan.Common.SafeEntrance.DependencyRegistry;
using Auchan.Common.Splash;
using Auchan.Common.StoreReview;
using Auchan.Common.Streams;
using Auchan.Common.SupportChat;
using Auchan.Common.Tooltips;
using Auchan.Common.UniversalLinks;
using Auchan.Common.Vpn;
using DryIoc;
using Microsoft.Maui.ApplicationModel;
using Newtonsoft.Json;
using Refit;

namespace Auchan.Common;

[RequiresUnreferencedCode("DI Registrations")]
[RequiresDynamicCode("DI Registrations")]
public static class Setup
{
	static Setup()
	{
		CultureInfo obj = new CultureInfo("ru-RU")
		{
			NumberFormat = 
			{
				NumberDecimalSeparator = ",",
				CurrencyDecimalSeparator = ",",
				NumberGroupSeparator = "\u00a0",
				CurrencyGroupSeparator = "\u00a0"
			}
		};
		CultureInfo.CurrentCulture = obj;
		CultureInfo.DefaultThreadCurrentCulture = obj;
		SafeFireAndForgetExtensions.SetDefaultExceptionHandling((Action<Exception>)delegate(Exception ex)
		{
			string description = $"SafeFireAndForgetExtensions: {ex}";
			DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<ILogService>().LogError("SafeFireAndForgetExtensions", description, LogType.Crash, SystemType.MobileApp);
			DevAnalytics.Report("SafeFireAndForgetExtensions", ex);
		});
		Registrations.Start("Auchan-Mobile");
	}

	public static Container DIContainer(Action<IRegistrator> registerExternal)
	{
		Container container = new Container((Rules rules) => rules.WithUseInterpretation().WithoutThrowOnRegisteringDisposableTransient());
		container.Register<IApplicationInitializer, ApplicationInitializer>();
		container.Register<IEnvironmentManager, EnvironmentManager>(Reuse.Singleton);
		container.Register<CoreHttpMessageHandler>(Reuse.Singleton);
		container.Register<AuthTokenHeaderMessageHandler>(Reuse.Singleton);
		container.Register<DefaultErrorTranslator>(Reuse.Singleton);
		container.Register<ErrorTracker>(Reuse.Singleton);
		container.Register<IExcelService, ExcelService>(Reuse.Singleton);
		container.Register<IApplicationStateManager, ApplicationStateManager>(Reuse.Singleton);
		container.Register<IViewModelStateManager, ViewModelStateManager>(Reuse.Singleton);
		container.Register<INavigationContext, NavigationContext>(Reuse.Singleton);
		container.Register<IUniversalLinksService, UniversalLinksService>(Reuse.Singleton);
		container.Register<IActivationParametersStore, ActivationParametersStore>(Reuse.Singleton);
		container.Register<IApplicationSettings, ApplicationSettings>(Reuse.Singleton);
		container.Register<UrlNavigationHandler>(Reuse.Singleton);
		container.Register<IVpnChecker, VpnChecker>(Reuse.Singleton);
		container.Register<IDataBroker, DataBroker>(Reuse.Singleton);
		container.Register<IHomeScreenTracker, HomeScreenTracker>(Reuse.Singleton);
		container.RegisterDelegate((IResolverContext _) => AppActions.Current, Reuse.Singleton);
		container.RegisterMany<AppActionsManger>(Reuse.Singleton);
		container.RegisterMany<MaintenanceManager>(Reuse.Singleton);
		container.Register<IApplicationSettings, ApplicationSettings>();
		container.Register<ILogoutService, LogoutService>(Reuse.Singleton);
		container.Register<IFullScreenDialogState, FullScreenDialogState>(Reuse.Singleton);
		container.Register<IContactsLoader, ContactsLoader>(Reuse.Singleton);
		container.Register<ScreenDataStore>(Reuse.Singleton);
		container.Register<ILottieFetcher, LottieFetcher>(Reuse.Singleton);
		container.RegisterDelegate((IResolverContext _) => new RefitSettings(new NewtonsoftJsonContentSerializer(new JsonSerializerSettings())), Reuse.Singleton);
		container.RegisterDelegate((IResolverContext _) => new RefitSettings<SystemTextJsonContentSerializer>(new SystemTextJsonContentSerializer(new JsonSerializerOptions
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			TypeInfoResolver = EcomSerializationContext.Default
		})));
		container.Register<BottomNavigationViewModel.IRemoteControl, BottomNavigationViewModel.RemoteControl>(Reuse.Singleton);
		ViewModelRegistry.Register(container);
		StreamsDependencyRegistry.Register(container);
		AddressDependencyRegistry.Register(container);
		DynamicFeedbackDependencyRegistry.Register(container);
		AdminToolDependencyRegistry.Register(container);
		OnboardingsDependencyRegistry.Register(container);
		ProcessingDependencyRegistry.Register(container);
		DevMenuDependencyRegistry.Register(container);
		EcomDependencyRegistry.Register(container);
		CatalogDependencyRegistry.Register(container);
		SearchDependencyRegistry.Register(container);
		CartDependencyRegistry.Register(container);
		PersonalCabinetDependencyRegistry.Register(container);
		LogMenuDependencyRegistry.Register(container);
		PriceCheckerDependencyRegistry.Register(container);
		InfoPagesDependencyRegistry.Register(container);
		CacheServiceDependencyRegistry.Register(container);
		NewYearGameDependencyRegistry.Register(container);
		SupportChatDependencyRegistry.Register(container);
		GiftCardsDependencyRegistry.Register(container);
		CasesDependencyRegistry.Register(container);
		WalletDependencyRegistry.Register(container);
		AnalyticsDependencyRegistry.Register(container);
		OrdersDependencyRegistry.Register(container);
		FavoritesDependencyRegistry.Register(container);
		WaitListDependencyRegistry.Register(container);
		StoresDependencyRegistry.Register(container);
		RecommendationDependencyRegistry.Register(container);
		AddReviewDependencyRegistry.Register(container);
		SafeEntranceDependencyRegistry.Register(container);
		LoyaltyDependencyRegistry.Register(container);
		LoymaxLoyaltyDependencyRegistry.Register(container);
		CouponsDependencyRegistry.Register(container);
		TooltipsDependencyRegistry.Register(container);
		NetworkDependencyRegistry.Register(container);
		PersonalOffersDependencyRegistry.Register(container);
		NotificationsDependencyRegistry.Register(container);
		StoreReviewDependencyRegistry.Register(container);
		DependencyRegistry.Register(container);
		registerExternal(container);
		DI.Setup(container);
		return container;
	}
}
