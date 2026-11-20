using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Cache;

public interface ICache : IGenericCache
{
	Task SaveCustomScreenAnimation<T>(string key, T obj);

	Task<T?> GetStruct<T>(string key) where T : struct;

	Task SaveSecure<T>(string key, T obj);

	Task SaveSecure<T>(string key, T obj, TimeSpan lifeTime);

	Task<T?> TryGetSecure<T>(string key) where T : class;

	Task DeleteSecure(string key);

	Task<DateTimeOffset?> GetCreatedAt(string key);

	Task<IEnumerable<string>> GetAllKeys();

	Task RemoveExpired();

	Task<Result<byte[], Exception>> DownloadFrom(string url, bool fetchAlways = false, DateTimeOffset? expiration = null);
}
