using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.StoreReview;

internal static class StoreReviewDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<ICustomerFlagApi>(new EnvironmentHttpClient(new CustomerFlagsBaseUrlProvider(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<CustomerFlagService>(Reuse.Singleton);
		registrator.Register<StoreReview>(Reuse.Singleton);
	}
}
