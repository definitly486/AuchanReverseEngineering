using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Splat;

namespace Akavache;

public static class JsonSerializationMixin
{
	private static readonly ConcurrentDictionary<string, object> _inflightFetchRequests = new ConcurrentDictionary<string, object>();

	public static IObservable<Unit> InsertObject<T>(this IBlobCache blobCache, string key, T value, DateTimeOffset? absoluteExpiration = null)
	{
		if (blobCache != null)
		{
			if (blobCache is IObjectBlobCache objectBlobCache)
			{
				return objectBlobCache.InsertObject(key, value, absoluteExpiration);
			}
			byte[] data = SerializeObject(value);
			return blobCache.Insert(GetTypePrefixedKey(key, typeof(T)), data, absoluteExpiration);
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<Unit> InsertAllObjects<T>(this IBlobCache blobCache, IDictionary<string, T> keyValuePairs, DateTimeOffset? absoluteExpiration = null)
	{
		if (!(blobCache is IObjectBlobCache blobCache2))
		{
			throw new NotImplementedException();
		}
		return blobCache2.InsertObjects(keyValuePairs, absoluteExpiration);
	}

	public static IObservable<T?> GetObject<T>(this IBlobCache blobCache, string key)
	{
		if (blobCache != null)
		{
			if (blobCache is IObjectBlobCache objectBlobCache)
			{
				return objectBlobCache.GetObject<T>(key);
			}
			return blobCache.Get(GetTypePrefixedKey(key, typeof(T))).SelectMany(DeserializeObject<T>);
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<IEnumerable<T>> GetAllObjects<T>(this IBlobCache blobCache)
	{
		if (blobCache != null)
		{
			if (blobCache is IObjectBlobCache objectBlobCache)
			{
				return objectBlobCache.GetAllObjects<T>();
			}
			return blobCache.GetAllKeys().SelectMany((IEnumerable<string> x) => x.Where((string y) => y.StartsWith(GetTypePrefixedKey(string.Empty, typeof(T)), StringComparison.InvariantCulture)).ToObservable()).SelectMany((string x) => (from result in blobCache.GetObject<T>(x)
				where result != null
				select (result)).Catch(Observable.Empty<T>()))
				.ToList();
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<T?> GetOrFetchObject<T>(this IBlobCache blobCache, string key, Func<IObservable<T>> fetchFunc, DateTimeOffset? absoluteExpiration = null)
	{
		if (blobCache != null)
		{
			return blobCache.GetObject<T>(key).Catch<T, Exception>(delegate
			{
				string prefixedKey = blobCache.GetHashCode().ToString(CultureInfo.InvariantCulture) + key;
				IObservable<T> value = Observable.Defer(fetchFunc).Do(delegate(T x)
				{
					blobCache.InsertObject(key, x, absoluteExpiration);
				}).Finally(delegate
				{
					_inflightFetchRequests.TryRemove(prefixedKey, out object _);
				})
					.Multicast(new AsyncSubject<T>())
					.RefCount();
				return (IObservable<T>)_inflightFetchRequests.GetOrAdd(prefixedKey, value);
			});
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<T?> GetOrFetchObject<T>(this IBlobCache blobCache, string key, Func<Task<T>> fetchFunc, DateTimeOffset? absoluteExpiration = null)
	{
		if (blobCache != null)
		{
			return blobCache.GetOrFetchObject(key, () => fetchFunc().ToObservable(), absoluteExpiration);
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<T?> GetOrCreateObject<T>(this IBlobCache blobCache, string key, Func<T> fetchFunc, DateTimeOffset? absoluteExpiration = null)
	{
		if (blobCache != null)
		{
			return blobCache.GetOrFetchObject(key, () => Observable.Return(fetchFunc()), absoluteExpiration);
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<DateTimeOffset?> GetObjectCreatedAt<T>(this IBlobCache blobCache, string key)
	{
		if (blobCache != null)
		{
			if (blobCache is IObjectBlobCache objectBlobCache)
			{
				return objectBlobCache.GetObjectCreatedAt<T>(key);
			}
			return blobCache.GetCreatedAt(GetTypePrefixedKey(key, typeof(T)));
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<T?> GetAndFetchLatest<T>(this IBlobCache blobCache, string key, Func<IObservable<T>> fetchFunc, Func<DateTimeOffset, bool>? fetchPredicate = null, DateTimeOffset? absoluteExpiration = null, bool shouldInvalidateOnError = false, Func<T, bool>? cacheValidationPredicate = null)
	{
		ArgumentNullException.ThrowIfNull(blobCache, "blobCache");
		IObservable<T> observable = (from x in Observable.Defer(() => blobCache.GetObjectCreatedAt<T>(key))
			select fetchPredicate == null || !x.HasValue || fetchPredicate(x.Value) into x
			where x
			select x).SelectMany((bool _) => fetchFunc().Catch((Exception ex) => (shouldInvalidateOnError ? blobCache.InvalidateObject<T>(key) : Observable.Return(Unit.Default)).SelectMany((Unit __) => Observable.Throw<T>(ex))).SelectMany((T x) => (cacheValidationPredicate == null || cacheValidationPredicate(x)) ? (from __ in blobCache.InvalidateObject<T>(key)
			select x) : Observable.Return(default(T))).SelectMany((T x) => (cacheValidationPredicate == null || cacheValidationPredicate(x)) ? (from __ in blobCache.InsertObject(key, x, absoluteExpiration)
			select x) : Observable.Return(default(T))));
		if (observable == null)
		{
			return Observable.Throw<T>(new InvalidOperationException("Could not find a valid way to fetch the value"));
		}
		return (from x in blobCache.GetObject<T>(key)
			select (x: x, true)).Catch(Observable.Return((default(T), false))).SelectMany(((T, bool) x) => (!x.Item2) ? Observable.Empty<T>() : Observable.Return(x.Item1)).Concat(observable)
			.Multicast(new ReplaySubject<T>())
			.RefCount();
	}

	public static IObservable<T?> GetAndFetchLatest<T>(this IBlobCache blobCache, string key, Func<Task<T>> fetchFunc, Func<DateTimeOffset, bool>? fetchPredicate = null, DateTimeOffset? absoluteExpiration = null, bool shouldInvalidateOnError = false, Func<T, bool>? cacheValidationPredicate = null)
	{
		if (blobCache != null)
		{
			return blobCache.GetAndFetchLatest(key, () => fetchFunc().ToObservable(), fetchPredicate, absoluteExpiration, shouldInvalidateOnError, cacheValidationPredicate);
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<Unit> InvalidateObject<T>(this IBlobCache blobCache, string key)
	{
		if (blobCache != null)
		{
			if (blobCache is IObjectBlobCache objectBlobCache)
			{
				return objectBlobCache.InvalidateObject<T>(key);
			}
			return blobCache.Invalidate(GetTypePrefixedKey(key, typeof(T)));
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<Unit> InvalidateAllObjects<T>(this IBlobCache blobCache)
	{
		if (blobCache != null)
		{
			if (blobCache is IObjectBlobCache objectBlobCache)
			{
				return objectBlobCache.InvalidateAllObjects<T>();
			}
			AsyncSubject<Unit> ret = new AsyncSubject<Unit>();
			blobCache.GetAllKeys().SelectMany((IEnumerable<string> x) => x.Where((string y) => y.StartsWith(GetTypePrefixedKey(string.Empty, typeof(T)), StringComparison.InvariantCulture)).ToObservable()).SelectMany(blobCache.Invalidate)
				.Subscribe(delegate
				{
				}, delegate(Exception ex)
				{
					ret.OnError(ex);
				}, delegate
				{
					ret.OnNext(Unit.Default);
					ret.OnCompleted();
				});
			return ret;
		}
		throw new ArgumentNullException("blobCache");
	}

	internal static byte[] SerializeObject(object value)
	{
		return JsonSerializationMixin.SerializeObject<object>(value);
	}

	internal static byte[] SerializeObject<T>(T value)
	{
		JsonSerializerSettings service = Locator.Current.GetService<JsonSerializerSettings>();
		return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value, service));
	}

	internal static IObservable<T?> DeserializeObject<T>(byte[] x)
	{
		JsonSerializerSettings service = Locator.Current.GetService<JsonSerializerSettings>();
		try
		{
			return Observable.Return(JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(x, 0, x.Length), service));
		}
		catch (Exception exception)
		{
			return Observable.Throw<T>(exception);
		}
	}

	internal static string GetTypePrefixedKey(string key, Type type)
	{
		return type.FullName + "___" + key;
	}
}
