using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Splat;

namespace Akavache;

[RequiresUnreferencedCode("Registrations for Akavache.Core")]
[RequiresDynamicCode("Registrations for Akavache.Core")]
public class InMemoryBlobCache : ISecureBlobCache, IBlobCache, IDisposable, IObjectBlobCache, IEnableLogger
{
	private readonly AsyncSubject<Unit> _shutdown = new AsyncSubject<Unit>();

	private readonly IDisposable? _inner;

	private readonly Dictionary<string, CacheEntry> _cache = new Dictionary<string, CacheEntry>();

	private readonly JsonDateTimeContractResolver _jsonDateTimeContractResolver = new JsonDateTimeContractResolver();

	private bool _disposed;

	private DateTimeKind? _dateTimeKind;

	public DateTimeKind? ForcedDateTimeKind
	{
		get
		{
			return _dateTimeKind ?? BlobCache.ForcedDateTimeKind;
		}
		set
		{
			_dateTimeKind = value;
			if (_jsonDateTimeContractResolver != null)
			{
				_jsonDateTimeContractResolver.ForceDateTimeKindOverride = value;
			}
		}
	}

	public IScheduler Scheduler { get; protected set; }

	public IObservable<Unit> Shutdown => _shutdown;

	public InMemoryBlobCache()
		: this(null, null)
	{
	}

	public InMemoryBlobCache(IScheduler scheduler)
		: this(scheduler, null)
	{
	}

	public InMemoryBlobCache(IEnumerable<KeyValuePair<string, byte[]>> initialContents)
		: this(null, initialContents)
	{
	}

	public InMemoryBlobCache(IScheduler? scheduler, IEnumerable<KeyValuePair<string, byte[]>>? initialContents)
	{
		Scheduler = scheduler ?? CurrentThreadScheduler.Instance;
		foreach (KeyValuePair<string, byte[]> item in initialContents ?? Array.Empty<KeyValuePair<string, byte[]>>())
		{
			_cache[item.Key] = new CacheEntry(null, item.Value, Scheduler.Now, null);
		}
	}

	internal InMemoryBlobCache(Action disposer, IScheduler? scheduler, IEnumerable<KeyValuePair<string, byte[]>> initialContents)
		: this(scheduler, initialContents)
	{
		_inner = Disposable.Create(disposer);
	}

	public static InMemoryBlobCache OverrideGlobals(IScheduler? scheduler = null, params KeyValuePair<string, byte[]>[] initialContents)
	{
		IBlobCache local = BlobCache.LocalMachine;
		IBlobCache user = BlobCache.UserAccount;
		ISecureBlobCache sec = BlobCache.Secure;
		return (InMemoryBlobCache)(BlobCache.UserAccount = (BlobCache.Secure = (ISecureBlobCache)(BlobCache.LocalMachine = new InMemoryBlobCache(delegate
		{
			BlobCache.LocalMachine = local;
			BlobCache.Secure = sec;
			BlobCache.UserAccount = user;
		}, scheduler, initialContents))));
	}

	public static InMemoryBlobCache OverrideGlobals(IDictionary<string, byte[]> initialContents, IScheduler? scheduler = null)
	{
		return OverrideGlobals(scheduler, initialContents.ToArray());
	}

	public static InMemoryBlobCache OverrideGlobals(IDictionary<string, object> initialContents, IScheduler? scheduler = null)
	{
		KeyValuePair<string, byte[]>[] initialContents2 = initialContents.Select<KeyValuePair<string, object>, KeyValuePair<string, byte[]>>((KeyValuePair<string, object> item) => new KeyValuePair<string, byte[]>(item.Key, JsonSerializationMixin.SerializeObject(item.Value))).ToArray();
		return OverrideGlobals(scheduler, initialContents2);
	}

	public IObservable<Unit> Insert(string key, byte[] data, DateTimeOffset? absoluteExpiration = null)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
		}
		lock (_cache)
		{
			_cache[key] = new CacheEntry(null, data, Scheduler.Now, absoluteExpiration);
		}
		return Observable.Return(Unit.Default);
	}

	public IObservable<Unit> Flush()
	{
		if (!_disposed)
		{
			return Observable.Return(Unit.Default);
		}
		return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
	}

	public IObservable<byte[]> Get(string key)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<byte[]>("InMemoryBlobCache");
		}
		CacheEntry value;
		lock (_cache)
		{
			if (!_cache.TryGetValue(key, out value))
			{
				return ExceptionHelper.ObservableThrowKeyNotFoundException<byte[]>(key);
			}
		}
		if (value == null)
		{
			return ExceptionHelper.ObservableThrowKeyNotFoundException<byte[]>(key);
		}
		if (value.ExpiresAt.HasValue && Scheduler.Now > value.ExpiresAt.Value)
		{
			lock (_cache)
			{
				_cache.Remove(key);
			}
			return ExceptionHelper.ObservableThrowKeyNotFoundException<byte[]>(key);
		}
		return Observable.Return(value.Value, Scheduler);
	}

	public IObservable<DateTimeOffset?> GetCreatedAt(string key)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<DateTimeOffset?>("InMemoryBlobCache");
		}
		CacheEntry value;
		lock (_cache)
		{
			if (!_cache.TryGetValue(key, out value))
			{
				return Observable.Return<DateTimeOffset?>(null);
			}
		}
		if (value != null)
		{
			return Observable.Return((DateTimeOffset?)value.CreatedAt, Scheduler);
		}
		return ExceptionHelper.ObservableThrowKeyNotFoundException<DateTimeOffset?>(key);
	}

	public IObservable<IEnumerable<string>> GetAllKeys()
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<List<string>>("InMemoryBlobCache");
		}
		lock (_cache)
		{
			return Observable.Return((from x in _cache
				where !x.Value.ExpiresAt.HasValue || x.Value.ExpiresAt >= Scheduler.Now
				select x.Key).ToList());
		}
	}

	public IObservable<Unit> Invalidate(string key)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
		}
		lock (_cache)
		{
			_cache.Remove(key);
		}
		return Observable.Return(Unit.Default);
	}

	public IObservable<Unit> InvalidateAll()
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
		}
		lock (_cache)
		{
			_cache.Clear();
		}
		return Observable.Return(Unit.Default);
	}

	public IObservable<Unit> InsertObject<T>(string key, T value, DateTimeOffset? absoluteExpiration = null)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
		}
		byte[] value2 = SerializeObject(value);
		lock (_cache)
		{
			_cache[key] = new CacheEntry(typeof(T).FullName, value2, Scheduler.Now, absoluteExpiration);
		}
		return Observable.Return(Unit.Default);
	}

	public IObservable<T> GetObject<T>(string key)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<T>("InMemoryBlobCache");
		}
		CacheEntry value;
		lock (_cache)
		{
			if (!_cache.TryGetValue(key, out value))
			{
				return ExceptionHelper.ObservableThrowKeyNotFoundException<T>(key);
			}
		}
		if (value == null)
		{
			return ExceptionHelper.ObservableThrowKeyNotFoundException<T>(key);
		}
		if (value.ExpiresAt.HasValue && Scheduler.Now > value.ExpiresAt.Value)
		{
			lock (_cache)
			{
				_cache.Remove(key);
			}
			return ExceptionHelper.ObservableThrowKeyNotFoundException<T>(key);
		}
		return Observable.Return(DeserializeObject<T>(value.Value), Scheduler);
	}

	public IObservable<DateTimeOffset?> GetObjectCreatedAt<T>(string key)
	{
		return GetCreatedAt(key);
	}

	public IObservable<IEnumerable<T>> GetAllObjects<T>()
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<IEnumerable<T>>("InMemoryBlobCache");
		}
		lock (_cache)
		{
			return Observable.Return((from x in _cache
				where x.Value.TypeName == typeof(T).FullName && (!x.Value.ExpiresAt.HasValue || x.Value.ExpiresAt >= Scheduler.Now)
				select DeserializeObject<T>(x.Value.Value)).ToList(), Scheduler);
		}
	}

	public IObservable<Unit> InvalidateObject<T>(string key)
	{
		if (!_disposed)
		{
			return Invalidate(key);
		}
		return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
	}

	public IObservable<Unit> InvalidateAllObjects<T>()
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
		}
		lock (_cache)
		{
			KeyValuePair<string, CacheEntry>[] array = _cache.Where<KeyValuePair<string, CacheEntry>>((KeyValuePair<string, CacheEntry> x) => x.Value.TypeName == typeof(T).FullName).ToArray();
			foreach (KeyValuePair<string, CacheEntry> keyValuePair in array)
			{
				_cache.Remove(keyValuePair.Key);
			}
		}
		return Observable.Return(Unit.Default);
	}

	public IObservable<Unit> Vacuum()
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
		}
		lock (_cache)
		{
			KeyValuePair<string, CacheEntry>[] array = _cache.Where<KeyValuePair<string, CacheEntry>>(delegate(KeyValuePair<string, CacheEntry> x)
			{
				if (x.Value.ExpiresAt.HasValue)
				{
					DateTimeOffset now = Scheduler.Now;
					DateTimeOffset? expiresAt = x.Value.ExpiresAt;
					return now > expiresAt;
				}
				return false;
			}).ToArray();
			foreach (KeyValuePair<string, CacheEntry> keyValuePair in array)
			{
				_cache.Remove(keyValuePair.Key);
			}
		}
		return Observable.Return(Unit.Default);
	}

	public void Dispose()
	{
		Dispose(isDisposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool isDisposing)
	{
		if (_disposed)
		{
			return;
		}
		if (isDisposing)
		{
			Scheduler = CurrentThreadScheduler.Instance;
			lock (_cache)
			{
				_cache.Clear();
			}
			_inner?.Dispose();
			_shutdown.OnNext(Unit.Default);
			_shutdown.OnCompleted();
		}
		_disposed = true;
	}

	private byte[] SerializeObject<T>(T value)
	{
		JsonSerializer serializer = GetSerializer();
		using MemoryStream memoryStream = new MemoryStream();
		using BsonDataWriter jsonWriter = new BsonDataWriter(memoryStream);
		serializer.Serialize(jsonWriter, new ObjectWrapper<T>(value));
		return memoryStream.ToArray();
	}

	private T DeserializeObject<T>(byte[] data)
	{
		JsonSerializer serializer = GetSerializer();
		using BsonDataReader bsonDataReader = new BsonDataReader(new MemoryStream(data));
		DateTimeKind? forcedDateTimeKind = BlobCache.ForcedDateTimeKind;
		if (forcedDateTimeKind.HasValue)
		{
			bsonDataReader.DateTimeKindHandling = forcedDateTimeKind.Value;
		}
		try
		{
			ObjectWrapper<T> objectWrapper = serializer.Deserialize<ObjectWrapper<T>>(bsonDataReader);
			return (T)((objectWrapper == null) ? ((object)default(T)) : ((object)objectWrapper.Value));
		}
		catch (Exception exception)
		{
			this.Log().Warn(exception, "Failed to deserialize data as boxed, we may be migrating from an old Akavache");
		}
		return serializer.Deserialize<T>(bsonDataReader);
	}

	private JsonSerializer GetSerializer()
	{
		JsonSerializerSettings jsonSerializerSettings = Locator.Current.GetService<JsonSerializerSettings>() ?? new JsonSerializerSettings();
		lock (jsonSerializerSettings)
		{
			_jsonDateTimeContractResolver.ExistingContractResolver = jsonSerializerSettings.ContractResolver;
			jsonSerializerSettings.ContractResolver = _jsonDateTimeContractResolver;
			JsonSerializer result = JsonSerializer.Create(jsonSerializerSettings);
			jsonSerializerSettings.ContractResolver = _jsonDateTimeContractResolver.ExistingContractResolver;
			return result;
		}
	}
}
