using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Akavache;

namespace Auchan.Common.Cache;

[RequiresDynamicCode("Registrations for Akavache.Core")]
[RequiresUnreferencedCode("Registrations for Akavache.Core")]
public class Persistence : IPersistence
{
	private readonly Lazy<IBlobCache> _cache = new Lazy<IBlobCache>(() => BlobCache.UserAccount, LazyThreadSafetyMode.PublicationOnly);

	public Task Save<T>(string key, T obj)
	{
		return Task.Run(async () => await _cache.Value.InsertObject(key, obj));
	}

	public Task Save<T>(string key, T obj, TimeSpan lifeTime)
	{
		return Task.Run(async () => await _cache.Value.InsertObject(key, obj, lifeTime));
	}

	public Task<T?> TryGet<T>(string key) where T : class
	{
		return Task.Run(async delegate
		{
			try
			{
				return await _cache.Value.GetObject<T>(key);
			}
			catch
			{
				return (T)null;
			}
		});
	}

	public Task<T?> TryGetStruct<T>(string key) where T : struct
	{
		return Task.Run(async delegate
		{
			try
			{
				return await _cache.Value.GetObject<T>(key);
			}
			catch
			{
				return (T?)null;
			}
		});
	}

	public Task Remove(string key)
	{
		return Task.Run(async () => await _cache.Value.Invalidate(key));
	}

	public Task Remove(params string[] keys)
	{
		return Task.Run(async () => await _cache.Value.Invalidate(keys));
	}

	public Task RemoveAll()
	{
		return Task.Run(async () => await _cache.Value.InvalidateAll());
	}
}
