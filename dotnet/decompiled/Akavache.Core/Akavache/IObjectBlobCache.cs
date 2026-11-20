using System;
using System.Collections.Generic;
using System.Reactive;

namespace Akavache;

public interface IObjectBlobCache : IBlobCache, IDisposable
{
	IObservable<Unit> InsertObject<T>(string key, T value, DateTimeOffset? absoluteExpiration = null);

	IObservable<T?> GetObject<T>(string key);

	IObservable<IEnumerable<T>> GetAllObjects<T>();

	IObservable<DateTimeOffset?> GetObjectCreatedAt<T>(string key);

	IObservable<Unit> InvalidateObject<T>(string key);

	IObservable<Unit> InvalidateAllObjects<T>();
}
