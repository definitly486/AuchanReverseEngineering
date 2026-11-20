using Auchan.Common.Networking;
using Auchan.Common.Profile.UserCards;
using DryIoc;
using Refit;

namespace Auchan.Common.Processing;

public static class ProcessingDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IUserCardsApi>(new EnvironmentHttpClient(resolverContext.Resolve<ProcessingBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<ProcessingBaseUrlProvider>(Reuse.Singleton);
		registrator.Register<IUserCardsService, UserCardsService>(Reuse.Singleton);
	}
}
