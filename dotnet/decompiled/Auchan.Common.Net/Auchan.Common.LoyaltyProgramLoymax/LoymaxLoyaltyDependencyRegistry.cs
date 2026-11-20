using Auchan.Common.LoyaltyProgram;
using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.LoyaltyProgramLoymax;

internal static class LoymaxLoyaltyDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<ILoymaxLoyaltyApi>(new EnvironmentHttpClient(resolverContext.Resolve<LoymaxLoyaltyProgramUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<LoymaxLoyaltyProgramUrlProvider>();
	}
}
