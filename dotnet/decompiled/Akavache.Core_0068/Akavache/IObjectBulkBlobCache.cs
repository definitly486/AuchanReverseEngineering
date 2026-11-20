using System;
using System.Collections.Generic;
using System.Reactive;

namespace Akavache;

public interface IObjectBulkBlobCache : IObjectBlobCache, IBlobCache, IDisposable, IBulkBlobCache
{
	IObservable<Unit> InsertObjects<T>(IDictionary<string, T> keyValuePairs, DateTimeOffset? absoluteExpiration = null);

	IObservable<IDictionary<string, T>> GetObjects<T>(IEnumerable<string> keys);

	IObservable<Unit> InvalidateObjects<T>(IEnumerable<string> keys);
}
