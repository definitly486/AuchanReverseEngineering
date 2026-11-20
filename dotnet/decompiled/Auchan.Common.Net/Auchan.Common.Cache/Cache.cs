using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Akavache;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Cache;

[RequiresDynamicCode("Registrations for Akavache.Core")]
[RequiresUnreferencedCode("Registrations for Akavache.Core")]
public class Cache : ICache, IGenericCache
{
	private readonly Lazy<IHeaderInjector> _injector;

	private readonly Lazy<IHeaderInjector2> _injector2;

	private const int RETRY_IN_MILLISECONDS = 100;

	private const int MAX_RETRY = 10;

	public Cache(Lazy<IHeaderInjector> injector, Lazy<IHeaderInjector2> injector2)
	{
		_injector = injector;
		_injector2 = injector2;
		BlobCache.ForcedDateTimeKind = DateTimeKind.Local;
	}

	public Task Save<T>(string key, T obj)
	{
		return Task.Run(() => HandleStorageNotInitializedException(async () => await BlobCache.LocalMachine.InsertObject(key, obj)));
	}

	public Task SaveCustomScreenAnimation<T>(string key, T obj)
	{
		return Task.Run(() => HandleStorageNotInitializedException(async delegate
		{
			if (await TryGet<string>(key) == null)
			{
				string keyOldAnimation = await TryGet<string>("lottie-animation");
				if (keyOldAnimation != null)
				{
					await BlobCache.LocalMachine.InvalidateObject<byte[]>(keyOldAnimation);
					await BlobCache.LocalMachine.Invalidate(keyOldAnimation);
				}
				await BlobCache.LocalMachine.InsertObject("lottie-animation", key);
				await BlobCache.LocalMachine.InsertObject(key, obj);
			}
		}));
	}

	public Task Save<T>(string key, T obj, TimeSpan lifeTime)
	{
		return Task.Run(() => HandleStorageNotInitializedException(async () => await BlobCache.LocalMachine.InsertObject(key, obj, lifeTime)));
	}

	public Task<T> Get<T>(string key, T defaultValue)
	{
		return Task.Run(async delegate
		{
			try
			{
				return await HandleStorageNotInitializedException(async () => await BlobCache.LocalMachine.GetObject<T>(key));
			}
			catch (Exception)
			{
				return defaultValue;
			}
		});
	}

	public Task<T?> TryGet<T>(string key) where T : class
	{
		return Task.Run(async delegate
		{
			try
			{
				return await HandleStorageNotInitializedException(async () => await BlobCache.LocalMachine.GetObject<T>(key));
			}
			catch (Exception)
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
				return await HandleStorageNotInitializedException(async () => await BlobCache.LocalMachine.GetObject<T>(key));
			}
			catch (Exception)
			{
				return (T?)null;
			}
		});
	}

	public Task<T?> GetStruct<T>(string key) where T : struct
	{
		return Task.Run((Func<Task<T?>?>)(async () => await HandleStorageNotInitializedException(async () => await BlobCache.LocalMachine.GetObject<T>(key))));
	}

	public Task SaveSecure<T>(string key, T obj)
	{
		return Task.Run(() => HandleStorageNotInitializedException(async () => await BlobCache.Secure.InsertObject(key, obj)));
	}

	public Task SaveSecure<T>(string key, T obj, TimeSpan lifeTime)
	{
		return Task.Run(() => HandleStorageNotInitializedException(async () => await BlobCache.Secure.InsertObject(key, obj, lifeTime)));
	}

	public Task<T?> TryGetSecure<T>(string key) where T : class
	{
		return Task.Run(async delegate
		{
			try
			{
				return await HandleStorageNotInitializedException(async () => await BlobCache.Secure.GetObject<T>(key));
			}
			catch (Exception)
			{
				return (T)null;
			}
		});
	}

	public Task DeleteSecure(string key)
	{
		return Task.Run(() => HandleStorageNotInitializedException(async () => await BlobCache.Secure.Invalidate(key)));
	}

	public Task<DateTimeOffset?> GetCreatedAt(string key)
	{
		return Task.Run(() => HandleStorageNotInitializedException(async () => await BlobCache.LocalMachine.GetCreatedAt(key)));
	}

	public Task<IEnumerable<string>> GetAllKeys()
	{
		return Task.Run(() => HandleStorageNotInitializedException(async () => await BlobCache.LocalMachine.GetAllKeys()));
	}

	public Task Remove(string key)
	{
		return Task.Run(() => HandleStorageNotInitializedException(async () => await BlobCache.LocalMachine.Invalidate(key)));
	}

	public Task Remove(params string[] keys)
	{
		return Task.Run(() => HandleStorageNotInitializedException(async () => await BlobCache.LocalMachine.Invalidate(keys)));
	}

	public Task RemoveAll()
	{
		return Task.Run(() => HandleStorageNotInitializedException(async () => await BlobCache.LocalMachine.InvalidateAll()));
	}

	public Task RemoveExpired()
	{
		return Task.Run(async delegate
		{
			try
			{
				await HandleStorageNotInitializedException(async () => await BlobCache.LocalMachine.Vacuum());
			}
			catch
			{
			}
		});
	}

	public Task<Result<byte[], Exception>> DownloadFrom(string url, bool fetchAlways = false, DateTimeOffset? expiration = null)
	{
		return Task.Run(async delegate
		{
			try
			{
				Dictionary<string, string> headers = new Dictionary<string, string>();
				_injector.Value.Inject(url, headers);
				_injector2.Value.Inject(url, headers);
				return await HandleStorageNotInitializedException(async () => await BlobCache.LocalMachine.DownloadUrl(url, headers, fetchAlways, expiration));
			}
			catch (Exception error)
			{
				return Result.Failure<byte[], Exception>(error);
			}
		});
	}

	private async Task HandleStorageNotInitializedException(Func<Task> action, int depth = 0)
	{
		try
		{
			await action();
		}
		catch (InvalidOperationException ex)
		{
			if (depth < 10 && ex.Message == "There is not a valid operation queue")
			{
				await Task.Delay(100);
				await HandleStorageNotInitializedException(action, depth + 1);
			}
			throw;
		}
	}

	private async Task<T> HandleStorageNotInitializedException<T>(Func<Task<T>> action, int depth = 0)
	{
		try
		{
			return await action();
		}
		catch (InvalidOperationException ex)
		{
			if (depth >= 10 || !(ex.Message == "There is not a valid operation queue"))
			{
				throw;
			}
			await Task.Delay(100);
			return await HandleStorageNotInitializedException(action, depth + 1);
		}
	}
}
