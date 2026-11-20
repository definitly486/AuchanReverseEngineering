using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.Profile.GiftCards.Infrastructure;

public static class GiftCardsDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IGiftCardsApi>(new EnvironmentHttpClient(resolverContext.Resolve<GiftCardsBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<GiftCardsBaseUrlProvider>(Reuse.Singleton);
		registrator.Register<GiftCardsService>(Reuse.Singleton);
	}
}
