using Auchan.Common.SafeEntrance.Managers;
using DryIoc;

namespace Auchan.Common.SafeEntrance.DependencyRegistry;

internal static class SafeEntranceDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.Register<ISafeEntranceManager, SafeEntranceManager>(Reuse.Singleton);
		registrator.Register<ISafeEntranceContext, SafeEntranceContext>(Reuse.Singleton);
	}
}
