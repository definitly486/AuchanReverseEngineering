using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;

namespace Akavache;

public static class BulkOperationsMixin
{
	public static IObservable<IDictionary<string, byte[]>> Get(this IBlobCache blobCache, IEnumerable<string> keys)
	{
		if (blobCache != null)
		{
			if (blobCache is IBulkBlobCache bulkBlobCache)
			{
				return bulkBlobCache.Get(keys);
			}
			return keys.ToObservable().SelectMany((string x) => (from y in blobCache.Get(x)
				select new KeyValuePair<string, byte[]>(x, y)).Catch((KeyNotFoundException _) => Observable.Empty<KeyValuePair<string, byte[]>>())).ToDictionary((KeyValuePair<string, byte[]> k) => k.Key, (KeyValuePair<string, byte[]> v) => v.Value);
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<Unit> Insert(this IBlobCache blobCache, IDictionary<string, byte[]> keyValuePairs, DateTimeOffset? absoluteExpiration = null)
	{
		if (blobCache != null)
		{
			if (blobCache is IBulkBlobCache bulkBlobCache)
			{
				return bulkBlobCache.Insert(keyValuePairs, absoluteExpiration);
			}
			return keyValuePairs.ToObservable().SelectMany<KeyValuePair<string, byte[]>, Unit>((KeyValuePair<string, byte[]> x) => blobCache.Insert(x.Key, x.Value, absoluteExpiration)).TakeLast(1);
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<IDictionary<string, DateTimeOffset?>> GetCreatedAt(this IBlobCache blobCache, IEnumerable<string> keys)
	{
		if (blobCache != null)
		{
			if (blobCache is IBulkBlobCache bulkBlobCache)
			{
				return bulkBlobCache.GetCreatedAt(keys);
			}
			return keys.ToObservable().SelectMany((string x) => from y in blobCache.GetCreatedAt(x)
				select new
				{
					Key = x,
					Value = y
				}).ToDictionary(k => k.Key, v => v.Value);
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<Unit> Invalidate(this IBlobCache blobCache, IEnumerable<string> keys)
	{
		if (blobCache != null)
		{
			if (blobCache is IBulkBlobCache bulkBlobCache)
			{
				return bulkBlobCache.Invalidate(keys);
			}
			return keys.ToObservable().SelectMany(blobCache.Invalidate).TakeLast(1);
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<IDictionary<string, T>> GetObjects<T>(this IBlobCache blobCache, IEnumerable<string> keys)
	{
		if (!(blobCache is IObjectBulkBlobCache objectBulkBlobCache))
		{
			return keys.ToObservable().SelectMany((string x) => (from y in blobCache.GetObject<T>(x)
				where y != null
				select new KeyValuePair<string, T>(x, y)).Catch((KeyNotFoundException _) => Observable.Empty<KeyValuePair<string, T>>())).ToDictionary((KeyValuePair<string, T> k) => k.Key, (KeyValuePair<string, T> v) => v.Value);
		}
		return objectBulkBlobCache.GetObjects<T>(keys);
	}

	public static IObservable<Unit> InsertObjects<T>(this IBlobCache blobCache, IDictionary<string, T> keyValuePairs, DateTimeOffset? absoluteExpiration = null)
	{
		if (blobCache != null)
		{
			if (blobCache is IObjectBulkBlobCache objectBulkBlobCache)
			{
				return objectBulkBlobCache.InsertObjects(keyValuePairs, absoluteExpiration);
			}
			return keyValuePairs.ToObservable().SelectMany<KeyValuePair<string, T>, Unit>((KeyValuePair<string, T> x) => blobCache.InsertObject(x.Key, x.Value, absoluteExpiration)).TakeLast(1);
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<Unit> InvalidateObjects<T>(this IBlobCache blobCache, IEnumerable<string> keys)
	{
		if (blobCache != null)
		{
			if (blobCache is IObjectBulkBlobCache objectBulkBlobCache)
			{
				return objectBulkBlobCache.InvalidateObjects<T>(keys);
			}
			return keys.ToObservable().SelectMany(blobCache.InvalidateObject<T>).TakeLast(1);
		}
		throw new ArgumentNullException("blobCache");
	}
}
