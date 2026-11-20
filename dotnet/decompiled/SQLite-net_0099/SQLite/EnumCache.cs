using System;
using System.Collections.Generic;

namespace SQLite;

internal static class EnumCache
{
	private static readonly Dictionary<Type, EnumCacheInfo> Cache = new Dictionary<Type, EnumCacheInfo>();

	public static EnumCacheInfo GetInfo(Type type)
	{
		lock (Cache)
		{
			EnumCacheInfo value = null;
			if (!Cache.TryGetValue(type, out value))
			{
				value = new EnumCacheInfo(type);
				Cache[type] = value;
			}
			return value;
		}
	}
}
