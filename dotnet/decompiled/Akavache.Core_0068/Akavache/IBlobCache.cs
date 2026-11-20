using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Concurrency;

namespace Akavache;

public interface IBlobCache : IDisposable
{
	IObservable<Unit> Shutdown { get; }

	IScheduler Scheduler { get; }

	DateTimeKind? ForcedDateTimeKind { get; set; }

	IObservable<Unit> Insert(string key, byte[] data, DateTimeOffset? absoluteExpiration = null);

	IObservable<byte[]> Get(string key);

	IObservable<IEnumerable<string>> GetAllKeys();

	IObservable<DateTimeOffset?> GetCreatedAt(string key);

	IObservable<Unit> Flush();

	IObservable<Unit> Invalidate(string key);

	IObservable<Unit> InvalidateAll();

	IObservable<Unit> Vacuum();
}
