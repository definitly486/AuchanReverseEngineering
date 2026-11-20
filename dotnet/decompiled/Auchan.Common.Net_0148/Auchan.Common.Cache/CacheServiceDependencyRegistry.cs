using DryIoc;

namespace Auchan.Common.Cache;

internal static class CacheServiceDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.Register<ICache, Cache>(Reuse.Singleton);
		registrator.Register<IPersistence, Persistence>(Reuse.Singleton);
		registrator.Register<IUserPersistence, UserPersistence>(Reuse.Singleton);
		registrator.Register<IMemoryCache, MemoryCache>(Reuse.Singleton);
	}
}
