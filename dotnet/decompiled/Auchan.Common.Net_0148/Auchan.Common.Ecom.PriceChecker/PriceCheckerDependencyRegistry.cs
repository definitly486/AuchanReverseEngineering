using Auchan.Common.Managers.UniversalLink;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using DryIoc;
using Refit;

namespace Auchan.Common.Ecom.PriceChecker;

internal static class PriceCheckerDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IPriceCheckerApi>(new EnvironmentHttpClient(new EcomBaseUrlProvider(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IPriceCheckerEventsApi>(new EnvironmentHttpClient(new PersonalCabinetBaseUrlProvider(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<PriceCheckerService>();
		registrator.Register<IPriceCheckerContext, PriceCheckerContext>(Reuse.Singleton);
		registrator.Register<UniversalLinkLoader>();
		registrator.Register<UniversalLinkParser>();
		registrator.Register<PriceChecker>();
	}
}
