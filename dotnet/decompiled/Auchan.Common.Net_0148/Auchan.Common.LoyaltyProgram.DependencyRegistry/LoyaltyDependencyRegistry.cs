using Auchan.Common.AdminTool;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Services;
using Auchan.Common.LoyaltyProgram.Services.Infrastructure;
using Auchan.Common.LoyaltyProgram.Services.TransactionDetails;
using Auchan.Common.LoyaltyProgram.ViewModels;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.TransactionDetails.Repository;
using Auchan.Common.LoyaltyProgram.ViewModels.NewLoyaltyCard;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration.DataProviders;
using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.LoyaltyProgram.DependencyRegistry;

internal static class LoyaltyDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<ILoyaltyProgramApi>(new EnvironmentHttpClient(resolverContext.Resolve<LoyaltyProgramUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<ILoyaltyProgramAdminApi>(new EnvironmentHttpClient(resolverContext.Resolve<AdminToolBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), new HttpMessageAuthSchemaHandler("Token", resolverContext.Resolve<CoreHttpMessageHandler>())), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<LoyaltyProgramUrlProvider>();
		registrator.Register<ILoyaltyProgramRequestsProvider, LoyaltyProgramRequestsProvider>(Reuse.Singleton);
		registrator.Register<ILoyaltyTriggersManager, LoyaltyTriggersManager>(Reuse.Singleton);
		registrator.Register<ILoyaltyManager, LoyaltyManager>(Reuse.Singleton);
		registrator.Register<ILoyaltyProgramBalanceService, LoyaltyProgramBalanceService>(Reuse.Singleton);
		registrator.Register<ILoyaltyCardService, LoyaltyCardService>(Reuse.Singleton);
		registrator.RegisterMany<LoyaltyCardManager>(Reuse.Singleton);
		registrator.Register<ILoyaltyProgramPurchasesHistoryService, LoyaltyProgramPurchasesHistoryService>(Reuse.Singleton);
		registrator.Register<ILoyaltyPurchasesRepository, LoyaltyPurchasesRepository>(Reuse.Singleton);
		registrator.Register<ITransactionDetailsService, TransactionDetailsService>(Reuse.Singleton);
		registrator.Register<ITransactionDetailsRepository, TransactionDetailsRepository>(Reuse.Singleton);
		registrator.Register<ILoyaltyPointsExpirationService, LoyaltyPointsExpirationService>(Reuse.Singleton);
		registrator.Register<ILoyaltyExpirationPointsDataProvider, LoyaltyExpirationPointsDataProvider>(Reuse.Singleton);
		registrator.Register<ILoyaltySocialStatusService, LoyaltySocialStatusService>(Reuse.Singleton);
		registrator.Register<ILoyaltyPersonalizedGreetingsService, LoyaltyPersonalizedGreetingsService>(Reuse.Singleton);
		registrator.Register<ILoyaltyPersonalizedGreetingsManager, LoyaltyPersonalizedGreetingManager>(Reuse.Singleton);
		registrator.Register<IPointsTransferService, PointsTransferService>(Reuse.Singleton);
		registrator.Register<IPointsTransferManager, PointsTransferManager>(Reuse.Singleton);
		registrator.Register<FavoriteCategoriesService>(Reuse.Singleton);
		registrator.Register<FavoriteCategoriesRepository>(Reuse.Singleton);
		registrator.Register<NewLoyaltyBalanceItemViewModel>();
		registrator.Register<HintItemViewModel>();
	}
}
