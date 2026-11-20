using Auchan.Common.AdminTool;
using Auchan.Common.Networking;
using Auchan.Common.Profile.Stores.Repositories;
using Auchan.Common.Profile.Stores.Services;
using DryIoc;
using Refit;

namespace Auchan.Common.Profile.Stores.Infrastructure;

internal static class StoresDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IFullStoreApi>(new EnvironmentHttpClient(resolverContext.Resolve<AdminToolBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), new HttpMessageAuthSchemaHandler("Token", resolverContext.Resolve<CoreHttpMessageHandler>())), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<IFullStoreService, FullStoreService>(Reuse.Singleton);
		registrator.Register<IStoreRepository, StoreRepository>(Reuse.Singleton);
		registrator.Register<IFullStoreFilterService, FullStoreFilterService>(Reuse.Singleton);
		registrator.Register<ISelfScanStoresRepository, SelfScanStoresRepository>(Reuse.Singleton);
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IRegionApi>(new EnvironmentHttpClient(resolverContext.Resolve<AdminToolBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), new HttpMessageAuthSchemaHandler("Token", resolverContext.Resolve<CoreHttpMessageHandler>())), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<IRegionService, RegionService>(Reuse.Singleton);
		registrator.Register<IRegionRepository, RegionRepository>(Reuse.Singleton);
		registrator.Register<IAllExistingRegionRepository, AllExistingRegionRepository>(Reuse.Singleton);
		registrator.Register<StoreDetailsServicesItemViewModel>();
	}
}
