using Auchan.Common.AdminTool;
using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.Tooltips;

public static class TooltipsDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<ITooltipsApi>(new EnvironmentHttpClient(resolverContext.Resolve<AdminToolBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<ITooltipsService, TooltipsService>(Reuse.Singleton);
		registrator.Register<ITooltipsRepository, TooltipsRepository>(Reuse.Singleton);
		registrator.Register<ITooltipsManager, TooltipsManager>(Reuse.Singleton);
	}
}
