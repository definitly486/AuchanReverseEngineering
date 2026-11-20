using Auchan.Common.Ecom;
using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.PersonalOffers;

public class PersonalOffersDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IPersonalOffersApi>(new EnvironmentHttpClient(resolverContext.Resolve<EcomBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<PersonalOffersService>();
	}
}
