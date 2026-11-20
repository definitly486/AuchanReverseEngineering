using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.Ecom.Search.Infrastructure;

public static class SearchDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<ISearchAPI>(new EnvironmentHttpClient(resolverContext.Resolve<EcomBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<SearchQueryHistoryRepository>(Reuse.Singleton);
		registrator.Register<SearchProductsManager>(Reuse.Singleton);
		registrator.Register<SearchProductsRepository>(Reuse.Singleton);
		registrator.Register<SearchProductsService>(Reuse.Singleton);
		registrator.Register<SearchFormHistoryItemViewModel>();
		registrator.Register<SearchAutohintsService>();
	}
}
