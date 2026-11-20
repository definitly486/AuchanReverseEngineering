using System;
using System.Threading.Tasks;

namespace Auchan.Common.Cache;

public interface IUserPersistence
{
	Task Save<T>(string key, T obj);

	Task Save<T>(string key, T obj, TimeSpan lifeTime);

	Task<T?> TryGet<T>(string key) where T : class;

	Task<T?> TryGetStruct<T>(string key) where T : struct;

	Task Remove(string key);

	Task Remove(params string[] keys);

	Task RemoveAll();
}
