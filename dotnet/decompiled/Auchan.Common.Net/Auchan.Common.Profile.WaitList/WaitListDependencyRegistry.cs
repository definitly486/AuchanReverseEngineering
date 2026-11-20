using Auchan.Common.Common;
using Auchan.Common.Ecom;
using Auchan.Common.Networking;
using Auchan.Common.Profile.WaitList.Api;
using DryIoc;
using Refit;

namespace Auchan.Common.Profile.WaitList;

internal static class WaitListDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IWaitListApi>(new EnvironmentHttpClient(resolverContext.Resolve<EcomBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<WaitListService>(Reuse.Singleton);
		registrator.Register<WaitListProducts>(Reuse.Singleton);
		registrator.Register<IApplicationStateObserver, WaitListApplicationStateObserver>(Reuse.Singleton);
	}
}
