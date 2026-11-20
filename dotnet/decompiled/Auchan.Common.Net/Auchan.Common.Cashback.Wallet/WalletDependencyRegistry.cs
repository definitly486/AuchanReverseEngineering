using Auchan.Common.AdminTool;
using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.Cashback.Wallet;

public static class WalletDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IWalletApi>(new EnvironmentHttpClient(resolverContext.Resolve<AdminToolBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<IWalletService, WalletService>(Reuse.Singleton);
		registrator.Register<IWalletManager, WalletManager>(Reuse.Singleton);
	}
}
