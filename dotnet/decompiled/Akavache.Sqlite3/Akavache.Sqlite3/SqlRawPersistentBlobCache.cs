using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using SQLite;
using Splat;

namespace Akavache.Sqlite3;

[RequiresUnreferencedCode("Registrations for Akavache.Core")]
[RequiresDynamicCode("Registrations for Akavache.Core")]
public class SqlRawPersistentBlobCache : IEnableLogger, IObjectBulkBlobCache, IObjectBlobCache, IBlobCache, IDisposable, IBulkBlobCache
{
	private static readonly object DisposeGate = 42;

	private readonly IObservable<Unit> _initializer;

	private readonly AsyncSubject<Unit> _shutdown = new AsyncSubject<Unit>();

	private readonly JsonDateTimeContractResolver _jsonDateTimeContractResolver = new JsonDateTimeContractResolver();

	private SqliteOperationQueue? _opQueue;

	private IDisposable? _queueThread;

	private DateTimeKind? _dateTimeKind;

	private bool _disposed;

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

	public IScheduler Scheduler { get; }

	public SQLiteConnection Connection { get; }

	public IObservable<Unit> Shutdown => _shutdown;

	public SqlRawPersistentBlobCache(string databaseFile, IScheduler? scheduler = null)
	{
		Scheduler = scheduler ?? BlobCache.TaskpoolScheduler;
		BlobCache.EnsureInitialized();
		Connection = new SQLiteConnection(databaseFile);
		_initializer = Initialize();
	}

	public IObservable<Unit> Insert(string key, byte[] data, DateTimeOffset? absoluteExpiration = null)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
		}
		if (key == null)
		{
			return Observable.Throw<Unit>(new ArgumentNullException("key"));
		}
		if (data == null)
		{
			return Observable.Throw<Unit>(new ArgumentNullException("data"));
		}
		if (_opQueue == null)
		{
			return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
		}
		DateTime exp = (absoluteExpiration ?? DateTimeOffset.MaxValue).UtcDateTime;
		DateTime createdAt = Scheduler.Now.UtcDateTime;
		return _initializer.SelectMany((Unit _) => BeforeWriteToDiskFilter(data, Scheduler)).SelectMany((byte[] encData) => _opQueue.Insert(new _003C_003Ez__ReadOnlySingleElementList<CacheElement>(new CacheElement
		{
			Key = key,
			Value = encData,
			CreatedAt = createdAt,
			Expiration = exp
		}))).PublishLast()
			.PermaRef();
	}

	public IObservable<byte[]> Get(string key)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<byte[]>("SqlitePersistentBlobCache");
		}
		if (key == null)
		{
			return Observable.Throw<byte[]>(new ArgumentNullException("key"));
		}
		if (_opQueue == null)
		{
			return Observable.Throw<byte[]>(new InvalidOperationException("There is not a valid operation queue"));
		}
		return _initializer.SelectMany((Unit _) => _opQueue.Select(new _003C_003Ez__ReadOnlySingleElementList<string>(key))).SelectMany(delegate(IEnumerable<CacheElement> x)
		{
			List<CacheElement> list = x.ToList();
			return (list.Count != 1) ? ExceptionHelper.ObservableThrowKeyNotFoundException<byte[]>(key) : Observable.Return(list[0].Value);
		}).SelectMany((byte[] x) => AfterReadFromDiskFilter(x, Scheduler))
			.PublishLast()
			.PermaRef();
	}

	public IObservable<IEnumerable<string>> GetAllKeys()
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<List<string>>("SqlitePersistentBlobCache");
		}
		if (_opQueue == null)
		{
			return Observable.Throw<IEnumerable<string>>(new InvalidOperationException("There is not a valid operation queue"));
		}
		return _initializer.SelectMany((Unit _) => _opQueue.GetAllKeys()).PublishLast().PermaRef();
	}

	public IObservable<DateTimeOffset?> GetCreatedAt(string key)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<DateTimeOffset?>("SqlitePersistentBlobCache");
		}
		if (key == null)
		{
			return Observable.Throw<DateTimeOffset?>(new ArgumentNullException("key"));
		}
		if (_opQueue == null)
		{
			return Observable.Throw<DateTimeOffset?>(new InvalidOperationException("There is not a valid operation queue"));
		}
		return _initializer.SelectMany((Unit _) => _opQueue.Select(new _003C_003Ez__ReadOnlySingleElementList<string>(key))).Select(delegate(IEnumerable<CacheElement> x)
		{
			List<CacheElement> list = x.ToList();
			return (list.Count != 1) ? ((DateTimeOffset?)null) : new DateTimeOffset?(new DateTimeOffset(list[0].CreatedAt, TimeSpan.Zero));
		}).PublishLast()
			.PermaRef();
	}

	public IObservable<DateTimeOffset?> GetObjectCreatedAt<T>(string key)
	{
		return GetCreatedAt(key);
	}

	public IObservable<Unit> Flush()
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
		}
		if (_opQueue == null)
		{
			return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
		}
		return _initializer.SelectMany((Unit _) => _opQueue.Flush()).PublishLast().PermaRef();
	}

	public IObservable<Unit> Invalidate(string key)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
		}
		if (_opQueue == null)
		{
			return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
		}
		return _initializer.SelectMany((Unit _) => _opQueue.Invalidate(new _003C_003Ez__ReadOnlySingleElementList<string>(key))).PublishLast().PermaRef();
	}

	public IObservable<Unit> InvalidateAll()
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
		}
		if (_opQueue == null)
		{
			return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
		}
		return _initializer.SelectMany((Unit _) => _opQueue.InvalidateAll()).PublishLast().PermaRef();
	}

	public IObservable<Unit> InsertObject<T>(string key, T value, DateTimeOffset? absoluteExpiration = null)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
		}
		if (key == null)
		{
			return Observable.Throw<Unit>(new ArgumentNullException("key"));
		}
		if (_opQueue == null)
		{
			return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
		}
		byte[] data = SerializeObject(value);
		DateTime exp = (absoluteExpiration ?? DateTimeOffset.MaxValue).UtcDateTime;
		DateTime createdAt = Scheduler.Now.UtcDateTime;
		return _initializer.SelectMany((Unit _) => BeforeWriteToDiskFilter(data, Scheduler)).SelectMany((byte[] encData) => _opQueue.Insert(new _003C_003Ez__ReadOnlySingleElementList<CacheElement>(new CacheElement
		{
			Key = key,
			TypeName = typeof(T).FullName,
			Value = encData,
			CreatedAt = createdAt,
			Expiration = exp
		}))).PublishLast()
			.PermaRef();
	}

	public IObservable<T?> GetObject<T>(string key)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<T>("SqlitePersistentBlobCache");
		}
		if (key == null)
		{
			return Observable.Throw<T>(new ArgumentNullException("key"));
		}
		if (_opQueue == null)
		{
			return Observable.Throw<T>(new InvalidOperationException("There is not a valid operation queue"));
		}
		return _initializer.SelectMany((Unit _) => _opQueue.Select(new _003C_003Ez__ReadOnlySingleElementList<string>(key))).SelectMany(delegate(IEnumerable<CacheElement> x)
		{
			List<CacheElement> list = x.ToList();
			return (list.Count != 1) ? ExceptionHelper.ObservableThrowKeyNotFoundException<byte[]>(key) : Observable.Return(list[0].Value);
		}).SelectMany((byte[] x) => AfterReadFromDiskFilter(x, Scheduler))
			.SelectMany(DeserializeObject<T>)
			.PublishLast()
			.PermaRef();
	}

	public IObservable<IEnumerable<T>> GetAllObjects<T>()
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<IEnumerable<T>>("SqlitePersistentBlobCache");
		}
		if (_opQueue == null)
		{
			return Observable.Throw<IEnumerable<T>>(new InvalidOperationException("There is not a valid operation queue"));
		}
		string typeFullName = typeof(T).FullName;
		if (typeFullName == null)
		{
			return Observable.Throw<IEnumerable<T>>(new InvalidOperationException("The generic type does not have a valid full name and is required"));
		}
		return _initializer.SelectMany((Unit _) => _opQueue.SelectTypes(new _003C_003Ez__ReadOnlySingleElementList<string>(typeFullName)).SelectMany((IEnumerable<CacheElement> x) => (from y in x.ToObservable().SelectMany((CacheElement y) => AfterReadFromDiskFilter(y.Value, Scheduler)).SelectMany(DeserializeObject<T>)
			where y != null
			select (y)).ToList())).PublishLast().PermaRef();
	}

	public IObservable<Unit> InvalidateObject<T>(string key)
	{
		if (!_disposed)
		{
			return Invalidate(key);
		}
		return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
	}

	public IObservable<Unit> InvalidateAllObjects<T>()
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
		}
		if (_opQueue == null)
		{
			return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
		}
		string typeFullName = typeof(T).FullName;
		if (typeFullName == null)
		{
			return Observable.Throw<Unit>(new InvalidOperationException("The generic type does not have a valid full name and is required"));
		}
		return _initializer.SelectMany((Unit _) => _opQueue.InvalidateTypes(new _003C_003Ez__ReadOnlySingleElementList<string>(typeFullName))).PublishLast().PermaRef();
	}

	public IObservable<Unit> Vacuum()
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
		}
		if (_opQueue == null)
		{
			return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
		}
		return _initializer.SelectMany((Unit _) => _opQueue.Vacuum()).PublishLast().PermaRef();
	}

	public IObservable<Unit> Insert(IDictionary<string, byte[]> keyValuePairs, DateTimeOffset? absoluteExpiration = null)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
		}
		if (keyValuePairs == null)
		{
			return Observable.Throw<Unit>(new ArgumentNullException("keyValuePairs"));
		}
		if (_opQueue == null)
		{
			return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
		}
		DateTime exp = (absoluteExpiration ?? DateTimeOffset.MaxValue).UtcDateTime;
		DateTime createdAt = Scheduler.Now.UtcDateTime;
		return _initializer.SelectMany((Unit _) => keyValuePairs.Select<KeyValuePair<string, byte[]>, IObservable<(string, byte[])>>((KeyValuePair<string, byte[]> x) => from data in BeforeWriteToDiskFilter(x.Value, Scheduler)
			select (key: x.Key, data: data))).Merge().ToList()
			.SelectMany((IList<(string key, byte[] data)> list) => _opQueue.Insert(list.Select(((string key, byte[] data) data) => new CacheElement
			{
				Key = data.key,
				Value = data.data,
				CreatedAt = createdAt,
				Expiration = exp
			})))
			.PublishLast()
			.PermaRef();
	}

	public IObservable<IDictionary<string, byte[]>> Get(IEnumerable<string> keys)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<IDictionary<string, byte[]>>("SqlitePersistentBlobCache");
		}
		if (keys == null)
		{
			return Observable.Throw<IDictionary<string, byte[]>>(new ArgumentNullException("keys"));
		}
		if (_opQueue == null)
		{
			return Observable.Throw<IDictionary<string, byte[]>>(new InvalidOperationException("There is not a valid operation queue"));
		}
		return _initializer.SelectMany((Unit _) => _opQueue.Select(keys)).SelectMany((IEnumerable<CacheElement> x) => Observable.Return(x.ToList().ToDictionary((CacheElement element) => element.Key, (CacheElement element) => element.Value))).SelectMany((Dictionary<string, byte[]> dict) => dict.Select((KeyValuePair<string, byte[]> x) => from data in AfterReadFromDiskFilter(x.Value, Scheduler)
			select (key: x.Key, data: data)))
			.Merge()
			.ToDictionary(((string key, byte[] data) x) => x.key, ((string key, byte[] data) x) => x.data)
			.PublishLast()
			.PermaRef();
	}

	public IObservable<IDictionary<string, DateTimeOffset?>> GetCreatedAt(IEnumerable<string> keys)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<IDictionary<string, DateTimeOffset?>>("SqlitePersistentBlobCache");
		}
		if (keys == null)
		{
			return Observable.Throw<IDictionary<string, DateTimeOffset?>>(new ArgumentNullException("keys"));
		}
		if (_opQueue == null)
		{
			return Observable.Throw<IDictionary<string, DateTimeOffset?>>(new InvalidOperationException("There is not a valid operation queue"));
		}
		return (from x in _initializer.SelectMany((Unit _) => _opQueue.Select(keys))
			select ((IEnumerable<CacheElement>)x.ToList()).ToDictionary((Func<CacheElement, string>)((CacheElement element) => element.Key), (Func<CacheElement, DateTimeOffset?>)((CacheElement element) => new DateTimeOffset(element.CreatedAt, TimeSpan.Zero)))).PublishLast().PermaRef();
	}

	public IObservable<Unit> Invalidate(IEnumerable<string> keys)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
		}
		if (_opQueue == null)
		{
			return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
		}
		return _initializer.SelectMany((Unit _) => _opQueue.Invalidate(keys)).PublishLast().PermaRef();
	}

	public IObservable<Unit> InsertObjects<T>(IDictionary<string, T> keyValuePairs, DateTimeOffset? absoluteExpiration = null)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
		}
		if (keyValuePairs == null)
		{
			return Observable.Throw<Unit>(new ArgumentNullException("keyValuePairs"));
		}
		if (_opQueue == null)
		{
			return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
		}
		IEnumerable<(string key, byte[] value)> dataToAdd = keyValuePairs.Select<KeyValuePair<string, T>, (string, byte[])>((KeyValuePair<string, T> x) => (key: x.Key, value: SerializeObject(x.Value)));
		DateTime exp = (absoluteExpiration ?? DateTimeOffset.MaxValue).UtcDateTime;
		DateTime createdAt = Scheduler.Now.UtcDateTime;
		return _initializer.SelectMany((Unit _) => dataToAdd.Select(((string key, byte[] value) x) => from data in BeforeWriteToDiskFilter(x.value, Scheduler)
			select (key: x.key, data: data))).Merge().ToList()
			.SelectMany((IList<(string key, byte[] data)> list) => _opQueue.Insert(list.Select(((string key, byte[] data) data) => new CacheElement
			{
				Key = data.key,
				TypeName = typeof(T).FullName,
				Value = data.data,
				CreatedAt = createdAt,
				Expiration = exp
			})))
			.PublishLast()
			.PermaRef();
	}

	public IObservable<IDictionary<string, T>> GetObjects<T>(IEnumerable<string> keys)
	{
		if (_disposed)
		{
			return ExceptionHelper.ObservableThrowObjectDisposedException<IDictionary<string, T>>("SqlitePersistentBlobCache");
		}
		if (keys == null)
		{
			return Observable.Throw<IDictionary<string, T>>(new ArgumentNullException("keys"));
		}
		if (_opQueue == null)
		{
			return Observable.Throw<IDictionary<string, T>>(new InvalidOperationException("There is not a valid operation queue"));
		}
		return _initializer.SelectMany((Unit _) => _opQueue.Select(keys)).SelectMany((IEnumerable<CacheElement> x) => Observable.Return(x.ToList().ToDictionary((CacheElement element) => element.Key, (CacheElement element) => element.Value))).SelectMany((Dictionary<string, byte[]> dict) => dict.Select((KeyValuePair<string, byte[]> x) => from data in AfterReadFromDiskFilter(x.Value, Scheduler)
			select (key: x.Key, data: data)))
			.Merge()
			.SelectMany(((string key, byte[] data) x) => from obj in DeserializeObject<T>(x.data)
				where obj != null
				select (key: x.key, data: obj))
			.ToDictionary(((string key, T data) x) => x.key, ((string key, T data) x) => x.data)
			.PublishLast()
			.PermaRef();
	}

	public IObservable<Unit> InvalidateObjects<T>(IEnumerable<string> keys)
	{
		if (!_disposed)
		{
			return Invalidate(keys);
		}
		return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
	}

	public void Dispose()
	{
		Dispose(isDisposing: true);
		GC.SuppressFinalize(this);
	}

	internal void ReplaceOperationQueue(SqliteOperationQueue queue)
	{
		_initializer.Wait();
		_opQueue?.Dispose();
		_opQueue = queue;
		_opQueue.Start();
	}

	protected virtual void Dispose(bool isDisposing)
	{
		if (_disposed)
		{
			return;
		}
		if (isDisposing)
		{
			IDisposable disp = Interlocked.Exchange(ref _queueThread, null);
			if (disp == null)
			{
				return;
			}
			Observable.Start(delegate
			{
				lock (DisposeGate)
				{
					disp.Dispose();
					_opQueue?.Dispose();
					Connection.Dispose();
				}
			}, Scheduler).Multicast(_shutdown).PermaRef();
		}
		_disposed = true;
	}

	protected IObservable<Unit> Initialize()
	{
		return Observable.Create(delegate(IObserver<Unit> subj)
		{
			try
			{
				Connection.ExecuteScalar<int>("PRAGMA journal_mode=WAL", Array.Empty<object>());
				Connection.Execute("PRAGMA temp_store=MEMORY");
				Connection.Execute("PRAGMA synchronous=OFF");
			}
			catch (SQLiteException)
			{
			}
			try
			{
				Connection.CreateTable<CacheElement>();
				if (GetSchemaVersion() < 2)
				{
					Connection.Execute("ALTER TABLE CacheElement RENAME TO VersionOneCacheElement;");
					Connection.CreateTable<CacheElement>();
					Connection.Execute(string.Format(CultureInfo.InvariantCulture, "INSERT INTO CacheElement SELECT Key,TypeName,Value,Expiration,\"{0}\" AS CreatedAt FROM VersionOneCacheElement;", BlobCache.TaskpoolScheduler.Now.UtcDateTime.Ticks));
					Connection.Execute("DROP TABLE VersionOneCacheElement;");
					Connection.Insert(new SchemaInfo
					{
						Version = 2
					});
				}
				_opQueue = new SqliteOperationQueue(Connection, Scheduler);
				_queueThread = _opQueue.Start();
				subj.OnNext(Unit.Default);
				subj.OnCompleted();
			}
			catch (Exception error)
			{
				subj.OnError(error);
			}
			return Disposable.Empty;
		}).PublishLast().PermaRef();
	}

	protected int GetSchemaVersion()
	{
		bool flag = false;
		int result = 0;
		try
		{
			result = Connection.ExecuteScalar<int>("SELECT Version from SchemaInfo ORDER BY Version DESC LIMIT 1", Array.Empty<object>());
		}
		catch (Exception)
		{
			flag = true;
		}
		if (flag)
		{
			Connection.CreateTable<SchemaInfo>();
			result = 1;
		}
		return result;
	}

	protected virtual IObservable<byte[]> BeforeWriteToDiskFilter(byte[] data, IScheduler scheduler)
	{
		if (!_disposed)
		{
			return Observable.Return(data, scheduler);
		}
		return ExceptionHelper.ObservableThrowObjectDisposedException<byte[]>("SqlitePersistentBlobCache");
	}

	protected virtual IObservable<byte[]> AfterReadFromDiskFilter(byte[] data, IScheduler scheduler)
	{
		if (!_disposed)
		{
			return Observable.Return(data, scheduler);
		}
		return ExceptionHelper.ObservableThrowObjectDisposedException<byte[]>("SqlitePersistentBlobCache");
	}

	private byte[] SerializeObject<T>(T value)
	{
		JsonSerializer serializer = GetSerializer();
		using MemoryStream memoryStream = new MemoryStream();
		using BsonDataWriter jsonWriter = new BsonDataWriter(memoryStream);
		serializer.Serialize(jsonWriter, new ObjectWrapper<T>(value));
		return memoryStream.ToArray();
	}

	private IObservable<T?> DeserializeObject<T>(byte[] data)
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
			try
			{
				return Observable.Return(serializer.Deserialize<ObjectWrapper<T>>(bsonDataReader).Value);
			}
			catch (Exception exception)
			{
				this.Log().Warn(exception, "Failed to deserialize data as boxed, we may be migrating from an old Akavache");
			}
			return Observable.Return(serializer.Deserialize<T>(bsonDataReader));
		}
		catch (Exception exception2)
		{
			return Observable.Throw<T>(exception2);
		}
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
