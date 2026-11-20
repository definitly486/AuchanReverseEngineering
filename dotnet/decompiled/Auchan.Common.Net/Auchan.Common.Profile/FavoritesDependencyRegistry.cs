using Auchan.Common.Ecom;
using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.Profile;

internal static class FavoritesDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IFavoritesApi>(new EnvironmentHttpClient(resolverContext.Resolve<EcomBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<FavoritesService>(Reuse.Singleton);
		registrator.Register<Favorites>(Reuse.Singleton);
	}
}
