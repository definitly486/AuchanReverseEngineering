using System;
using System.Collections.Generic;
using System.Reactive;

namespace Akavache;

public interface IBulkBlobCache : IBlobCache, IDisposable
{
	IObservable<Unit> Insert(IDictionary<string, byte[]> keyValuePairs, DateTimeOffset? absoluteExpiration = null);

	IObservable<IDictionary<string, byte[]>> Get(IEnumerable<string> keys);

	IObservable<IDictionary<string, DateTimeOffset?>> GetCreatedAt(IEnumerable<string> keys);

	IObservable<Unit> Invalidate(IEnumerable<string> keys);
}
