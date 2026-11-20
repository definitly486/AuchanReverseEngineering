using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Akavache;

namespace Auchan.Common.Cache;

[RequiresDynamicCode("Registrations for Akavache.Core")]
[RequiresUnreferencedCode("Registrations for Akavache.Core")]
public class MemoryCache : IMemoryCache, IGenericCache
{
	private readonly IBlobCache _cache = BlobCache.InMemory;

	public async Task Save<T>(string key, T obj)
	{
		await _cache.InsertObject(key, obj);
	}

	public async Task Save<T>(string key, T obj, TimeSpan lifeTime)
	{
		await _cache.InsertObject(key, obj, lifeTime);
	}

	public async Task<T> Get<T>(string key, T defaultValue)
	{
		try
		{
			return await BlobCache.LocalMachine.GetObject<T>(key);
		}
		catch (Exception)
		{
			return defaultValue;
		}
	}

	public async Task<T?> TryGet<T>(string key) where T : class
	{
		try
		{
			return await _cache.GetObject<T>(key);
		}
		catch
		{
			return null;
		}
	}

	public async Task<T?> TryGetStruct<T>(string key) where T : struct
	{
		try
		{
			return await _cache.GetObject<T>(key);
		}
		catch
		{
			return null;
		}
	}

	public async Task Remove(string key)
	{
		await _cache.Invalidate(key);
	}

	public async Task Remove(params string[] keys)
	{
		await _cache.Invalidate(keys);
	}

	public async Task RemoveAll()
	{
		await _cache.InvalidateAll();
	}
}
