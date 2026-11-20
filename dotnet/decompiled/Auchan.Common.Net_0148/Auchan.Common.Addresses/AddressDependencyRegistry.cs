using Auchan.Common.Common;
using DryIoc;

namespace Auchan.Common.Addresses;

internal static class AddressDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterMany<LocationProvider>(Reuse.Singleton);
		registrator.Register<IApplicationStateObserver, AddressApplicationStateObserver>(Reuse.Singleton);
	}
}
