using System.Runtime.CompilerServices;
using Auchan.Common.Ecom.Cart.Managers;
using Auchan.Common.Ecom.ViewModels;
using Auchan.Common.InfoPages.ServiceErrors;
using Auchan.Common.LoyaltyProgram.Mappers;
using DryIoc;

namespace Auchan.Common.Networking;

internal static class NetworkDependencyRegistry
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Register(IRegistrator registrator)
	{
		registrator.Register<INetworkSettings, NetworkSettings>();
		registrator.Register<IHeaderProvider, HeaderProvider>();
		registrator.Register<IHeaderInjector, HeaderInjector>(Reuse.Singleton);
		registrator.Register<IHeaderInjector2, XAppUserAgentHeaderInjector>(Reuse.Singleton);
		registrator.Register<IBasicAuthorizationHeaderInjector, BasicAuthorizationHeaderInjector>(Reuse.Singleton);
	}
}
