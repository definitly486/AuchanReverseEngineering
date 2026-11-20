using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.LoyaltyProgram.Coupons.Infrastructure;

internal static class CouponsDependencyRegistry
{
	internal static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<ICouponsApi>(new EnvironmentHttpClient(resolverContext.Resolve<CouponsUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<CouponsUrlProvider>(Reuse.Singleton);
		registrator.Register<CouponsRepository>(Reuse.Singleton);
		registrator.Register<CouponsService>(Reuse.Singleton);
	}
}
