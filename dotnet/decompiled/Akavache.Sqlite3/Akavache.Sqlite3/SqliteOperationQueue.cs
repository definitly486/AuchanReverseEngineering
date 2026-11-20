using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using Akavache.Sqlite3.Internal;
using SQLite;
using Splat;

namespace Akavache.Sqlite3;

internal class SqliteOperationQueue : IEnableLogger, IDisposable
{
	private readonly Akavache.Sqlite3.Internal.AsyncLock _flushLock = new Akavache.Sqlite3.Internal.AsyncLock();

	private readonly IScheduler _scheduler;

	private readonly Lazy<BulkSelectSqliteOperation> _bulkSelectKey;

	private readonly Lazy<BulkSelectByTypeSqliteOperation> _bulkSelectType;

	private readonly Lazy<BulkInsertSqliteOperation> _bulkInsertKey;

	private readonly Lazy<BulkInvalidateSqliteOperation> _bulkInvalidateKey;

	private readonly Lazy<BulkInvalidateByTypeSqliteOperation> _bulkInvalidateType;

	private readonly Lazy<InvalidateAllSqliteOperation> _invalidateAll;

	private readonly Lazy<VacuumSqliteOperation> _vacuum;

	private readonly Lazy<DeleteExpiredSqliteOperation> _deleteExpired;

	private readonly Lazy<GetKeysSqliteOperation> _getAllKeys;

	private readonly Lazy<BeginTransactionSqliteOperation> _begin;

	private readonly Lazy<CommitTransactionSqliteOperation> _commit;

	private BlockingCollection<OperationQueueItem> _operationQueue = new BlockingCollection<OperationQueueItem>();

	private IDisposable? _start;

	private CancellationTokenSource? _shouldQuit;

	private const string NullKey = "___THIS_IS_THE_NULL_KEY_HOPE_NOBODY_PICKS_IT_FFS_____";

	public SqliteOperationQueue(SQLiteConnection connection, IScheduler scheduler)
	{
		_scheduler = scheduler;
		_bulkSelectKey = new Lazy<BulkSelectSqliteOperation>(() => new BulkSelectSqliteOperation(connection, useTypeInsteadOfKey: false, scheduler));
		_bulkSelectType = new Lazy<BulkSelectByTypeSqliteOperation>(() => new BulkSelectByTypeSqliteOperation(connection, scheduler));
		_bulkInsertKey = new Lazy<BulkInsertSqliteOperation>(() => new BulkInsertSqliteOperation(connection));
		_bulkInvalidateKey = new Lazy<BulkInvalidateSqliteOperation>(() => new BulkInvalidateSqliteOperation(connection, useTypeInsteadOfKey: false));
		_bulkInvalidateType = new Lazy<BulkInvalidateByTypeSqliteOperation>(() => new BulkInvalidateByTypeSqliteOperation(connection));
		_invalidateAll = new Lazy<InvalidateAllSqliteOperation>(() => new InvalidateAllSqliteOperation(connection));
		_vacuum = new Lazy<VacuumSqliteOperation>(() => new VacuumSqliteOperation(connection, scheduler));
		_deleteExpired = new Lazy<DeleteExpiredSqliteOperation>(() => new DeleteExpiredSqliteOperation(connection, scheduler));
		_getAllKeys = new Lazy<GetKeysSqliteOperation>(() => new GetKeysSqliteOperation(connection, scheduler));
		_begin = new Lazy<BeginTransactionSqliteOperation>(() => new BeginTransactionSqliteOperation(connection));
		_commit = new Lazy<CommitTransactionSqliteOperation>(() => new CommitTransactionSqliteOperation(connection));
	}

	internal SqliteOperationQueue()
	{
	}

	public IDisposable Start()
	{
		if (_start != null)
		{
			return _start;
		}
		_shouldQuit = new CancellationTokenSource();
		Task task = Task.Run(async delegate
		{
			List<OperationQueueItem> toProcess = new List<OperationQueueItem>();
			while (!_shouldQuit.IsCancellationRequested)
			{
				toProcess.Clear();
				IDisposable disposable;
				try
				{
					disposable = await _flushLock.LockAsync(_shouldQuit.Token).ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (OperationCanceledException)
				{
					break;
				}
				if (disposable == null)
				{
					break;
				}
				using (disposable)
				{
					OperationQueueItem item;
					try
					{
						item = _operationQueue.Take(_shouldQuit.Token);
					}
					catch (OperationCanceledException)
					{
						break;
					}
					if (_shouldQuit.IsCancellationRequested && item == null)
					{
						break;
					}
					toProcess.Add(item);
					while (toProcess.Count < 64 && _operationQueue.TryTake(out item) && item != null)
					{
						toProcess.Add(item);
					}
					try
					{
						ProcessItems(CoalesceOperations(toProcess));
					}
					catch (SQLiteException)
					{
						foreach (OperationQueueItem item2 in toProcess)
						{
							_operationQueue.Add(item2);
						}
					}
				}
			}
		});
		return _start = Disposable.Create(delegate
		{
			try
			{
				_shouldQuit.Cancel();
				task.Wait();
			}
			catch (OperationCanceledException)
			{
			}
			try
			{
				using (_flushLock.LockAsync(default(CancellationToken)).Result)
				{
					FlushInternal();
				}
			}
			catch (OperationCanceledException)
			{
			}
			_start = null;
		});
	}

	public IObservable<Unit> Flush()
	{
		OperationQueueItem operationQueueItem = OperationQueueItem.CreateUnit(OperationType.DoNothing);
		_operationQueue.Add(operationQueueItem);
		return operationQueueItem.CompletionAsUnit;
	}

	public AsyncSubject<IEnumerable<CacheElement>> Select(IEnumerable<string> keys)
	{
		OperationQueueItem operationQueueItem = OperationQueueItem.CreateSelect(OperationType.BulkSelectSqliteOperation, keys);
		_operationQueue.Add(operationQueueItem);
		return operationQueueItem.CompletionAsElements;
	}

	public AsyncSubject<IEnumerable<CacheElement>> SelectTypes(IEnumerable<string> types)
	{
		OperationQueueItem operationQueueItem = OperationQueueItem.CreateSelect(OperationType.BulkSelectByTypeSqliteOperation, types);
		_operationQueue.Add(operationQueueItem);
		return operationQueueItem.CompletionAsElements;
	}

	public AsyncSubject<Unit> Insert(IEnumerable<CacheElement> items)
	{
		OperationQueueItem operationQueueItem = OperationQueueItem.CreateInsert(OperationType.BulkInsertSqliteOperation, items);
		_operationQueue.Add(operationQueueItem);
		return operationQueueItem.CompletionAsUnit;
	}

	public AsyncSubject<Unit> Invalidate(IEnumerable<string> keys)
	{
		OperationQueueItem operationQueueItem = OperationQueueItem.CreateInvalidate(OperationType.BulkInvalidateSqliteOperation, keys);
		_operationQueue.Add(operationQueueItem);
		return operationQueueItem.CompletionAsUnit;
	}

	public AsyncSubject<Unit> InvalidateTypes(IEnumerable<string> types)
	{
		OperationQueueItem operationQueueItem = OperationQueueItem.CreateInvalidate(OperationType.BulkInvalidateByTypeSqliteOperation, types);
		_operationQueue.Add(operationQueueItem);
		return operationQueueItem.CompletionAsUnit;
	}

	public AsyncSubject<Unit> InvalidateAll()
	{
		OperationQueueItem operationQueueItem = OperationQueueItem.CreateUnit(OperationType.InvalidateAllSqliteOperation);
		_operationQueue.Add(operationQueueItem);
		return operationQueueItem.CompletionAsUnit;
	}

	public AsyncSubject<Unit> Vacuum()
	{
		AsyncSubject<Unit> asyncSubject = new AsyncSubject<Unit>();
		Task.Run(async delegate
		{
			IDisposable @lock = null;
			try
			{
				Task<IDisposable> task = _flushLock.LockAsync(_shouldQuit?.Token ?? CancellationToken.None);
				_operationQueue.Add(OperationQueueItem.CreateUnit(OperationType.DoNothing));
				try
				{
					@lock = await task.ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (OperationCanceledException)
				{
				}
				OperationQueueItem operationQueueItem = OperationQueueItem.CreateUnit(OperationType.DeleteExpiredSqliteOperation);
				_operationQueue.Add(operationQueueItem);
				FlushInternal();
				await operationQueueItem.CompletionAsUnit;
				OperationQueueItem operationQueueItem2 = OperationQueueItem.CreateUnit(OperationType.VacuumSqliteOperation);
				MarshalCompletion(operationQueueItem2.Completion, _vacuum.Value.PrepareToExecute(), Observable.Return(Unit.Default));
				await operationQueueItem2.CompletionAsUnit;
			}
			finally
			{
				@lock?.Dispose();
			}
		}).ToObservable().ObserveOn(_scheduler)
			.Multicast(asyncSubject)
			.PermaRef();
		return asyncSubject;
	}

	public AsyncSubject<IEnumerable<string>> GetAllKeys()
	{
		OperationQueueItem operationQueueItem = OperationQueueItem.CreateGetAllKeys();
		_operationQueue.Add(operationQueueItem);
		return operationQueueItem.CompletionAsKeys;
	}

	public void Dispose()
	{
		if (_bulkSelectKey.IsValueCreated)
		{
			_bulkSelectKey.Value.Dispose();
		}
		if (_bulkSelectType.IsValueCreated)
		{
			_bulkSelectType.Value.Dispose();
		}
		if (_bulkInsertKey.IsValueCreated)
		{
			_bulkInsertKey.Value.Dispose();
		}
		if (_bulkInvalidateKey.IsValueCreated)
		{
			_bulkInvalidateKey.Value.Dispose();
		}
		if (_bulkInvalidateType.IsValueCreated)
		{
			_bulkInvalidateType.Value.Dispose();
		}
		if (_invalidateAll.IsValueCreated)
		{
			_invalidateAll.Value.Dispose();
		}
		if (_vacuum.IsValueCreated)
		{
			_vacuum.Value.Dispose();
		}
		if (_deleteExpired.IsValueCreated)
		{
			_deleteExpired.Value.Dispose();
		}
		if (_getAllKeys.IsValueCreated)
		{
			_getAllKeys.Value.Dispose();
		}
		if (_begin.IsValueCreated)
		{
			_begin.Value.Dispose();
		}
		if (_begin.IsValueCreated)
		{
			_commit.Value.Dispose();
		}
		_operationQueue?.Dispose();
		_flushLock?.Dispose();
		_shouldQuit?.Dispose();
	}

	internal List<OperationQueueItem> DumpQueue()
	{
		return _operationQueue.ToList();
	}

	private static void MarshalCompletion(object completion, Action block, IObservable<Unit> commitResult)
	{
		AsyncSubject<Unit> asyncSubject = (AsyncSubject<Unit>)completion;
		try
		{
			block();
			asyncSubject.OnNext(Unit.Default);
			commitResult.SelectMany((Unit _) => Observable.Empty<Unit>()).Multicast(asyncSubject).PermaRef();
		}
		catch (Exception error)
		{
			asyncSubject.OnError(error);
		}
	}

	private void FlushInternal()
	{
		BlockingCollection<OperationQueueItem> value = new BlockingCollection<OperationQueueItem>();
		List<OperationQueueItem> inputItems = Interlocked.Exchange(ref _operationQueue, value).ToList();
		ProcessItems(CoalesceOperations(inputItems));
	}

	private void ProcessItems(List<OperationQueueItem> toProcess)
	{
		AsyncSubject<Unit> commitResult = new AsyncSubject<Unit>();
		_begin.Value.PrepareToExecute()();
		foreach (OperationQueueItem item in toProcess)
		{
			switch (item.OperationType)
			{
			case OperationType.DoNothing:
				MarshalCompletion(item.Completion, delegate
				{
				}, commitResult);
				break;
			case OperationType.BulkInsertSqliteOperation:
				MarshalCompletion(item.Completion, _bulkInsertKey.Value.PrepareToExecute(item.ParametersAsElements), commitResult);
				break;
			case OperationType.BulkInvalidateByTypeSqliteOperation:
				MarshalCompletion(item.Completion, _bulkInvalidateType.Value.PrepareToExecute(item.ParametersAsKeys), commitResult);
				break;
			case OperationType.BulkInvalidateSqliteOperation:
				MarshalCompletion(item.Completion, _bulkInvalidateKey.Value.PrepareToExecute(item.ParametersAsKeys), commitResult);
				break;
			case OperationType.BulkSelectByTypeSqliteOperation:
				MarshalCompletion(item.Completion, _bulkSelectType.Value.PrepareToExecute(item.ParametersAsKeys), commitResult);
				break;
			case OperationType.BulkSelectSqliteOperation:
				MarshalCompletion(item.Completion, _bulkSelectKey.Value.PrepareToExecute(item.ParametersAsKeys), commitResult);
				break;
			case OperationType.GetKeysSqliteOperation:
				MarshalCompletion(item.Completion, _getAllKeys.Value.PrepareToExecute(), commitResult);
				break;
			case OperationType.InvalidateAllSqliteOperation:
				MarshalCompletion(item.Completion, _invalidateAll.Value.PrepareToExecute(), commitResult);
				break;
			case OperationType.DeleteExpiredSqliteOperation:
				MarshalCompletion(item.Completion, _deleteExpired.Value.PrepareToExecute(), commitResult);
				break;
			case OperationType.VacuumSqliteOperation:
				throw new ArgumentException("Vacuum operation can't run inside transaction", "toProcess");
			default:
				throw new ArgumentException("Unknown operation", "toProcess");
			}
		}
		try
		{
			_commit.Value.PrepareToExecute()();
			_scheduler.Schedule(delegate
			{
				commitResult.OnNext(Unit.Default);
				commitResult.OnCompleted();
			});
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			Exception ex3 = ex2;
			_scheduler.Schedule(delegate
			{
				commitResult.OnError(ex3);
			});
		}
	}

	private void MarshalCompletion<T>(object completion, Func<T> block, IObservable<Unit> commitResult)
	{
		AsyncSubject<T> subj = (AsyncSubject<T>)completion;
		try
		{
			T value = block();
			subj.OnNext(value);
			commitResult.SelectMany((Unit _) => Observable.Empty<T>()).Multicast(subj).PermaRef();
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			_scheduler.Schedule(delegate
			{
				subj.OnError(ex2);
			});
		}
	}

	internal static List<OperationQueueItem> CoalesceOperations(List<OperationQueueItem> inputItems)
	{
		if (inputItems.Count <= 1)
		{
			return inputItems;
		}
		List<OperationQueueItem> list = new List<OperationQueueItem>();
		if (inputItems.Any(delegate(OperationQueueItem x)
		{
			OperationType operationType = x.OperationType;
			return (operationType == OperationType.InvalidateAllSqliteOperation || operationType == OperationType.GetKeysSqliteOperation) ? true : false;
		}))
		{
			return inputItems;
		}
		Dictionary<string, List<OperationQueueItem>> dictionary = new Dictionary<string, List<OperationQueueItem>>();
		foreach (OperationQueueItem inputItem in inputItems)
		{
			string key = GetKeyFromTuple(inputItem) ?? "___THIS_IS_THE_NULL_KEY_HOPE_NOBODY_PICKS_IT_FFS_____";
			if (!dictionary.TryGetValue(key, out var value))
			{
				value = new List<OperationQueueItem>();
				dictionary.Add(key, value);
			}
			value.Add(inputItem);
		}
		OperationType[] source = new OperationType[3]
		{
			OperationType.BulkInvalidateSqliteOperation,
			OperationType.BulkInsertSqliteOperation,
			OperationType.BulkSelectSqliteOperation
		};
		foreach (string item in dictionary.Keys.ToList())
		{
			if (!(item == "___THIS_IS_THE_NULL_KEY_HOPE_NOBODY_PICKS_IT_FFS_____"))
			{
				dictionary[item] = ((IEnumerable<OperationType>)source).Aggregate((IEnumerable<OperationQueueItem>)dictionary[item], (Func<IEnumerable<OperationQueueItem>, OperationType, IEnumerable<OperationQueueItem>>)MultipleOpsTurnIntoSingleOp).ToList();
			}
		}
		while (dictionary.Count > 0)
		{
			List<OperationQueueItem> list2 = new List<OperationQueueItem>();
			List<string> list3 = new List<string>();
			foreach (string key2 in dictionary.Keys)
			{
				List<OperationQueueItem> list4 = dictionary[key2];
				list2.Add(list4[0]);
				list4.RemoveAt(0);
				if (list4.Count == 0)
				{
					list3.Add(key2);
				}
			}
			IEnumerable<OperationQueueItem> collection = CoalesceUnrelatedItems(list2);
			list.AddRange(collection);
			foreach (string item2 in list3)
			{
				dictionary.Remove(item2);
			}
		}
		return list;
	}

	private static IEnumerable<OperationQueueItem> CoalesceUnrelatedItems(IEnumerable<OperationQueueItem> items)
	{
		return (from x in items
			group x by x.OperationType).SelectMany((IGrouping<OperationType, OperationQueueItem> group) => group.Key switch
		{
			OperationType.BulkSelectSqliteOperation => new _003C_003Ez__ReadOnlySingleElementList<OperationQueueItem>(GroupUnrelatedSelects(group)), 
			OperationType.BulkInsertSqliteOperation => new _003C_003Ez__ReadOnlySingleElementList<OperationQueueItem>(GroupUnrelatedInserts(group)), 
			OperationType.BulkInvalidateSqliteOperation => new _003C_003Ez__ReadOnlySingleElementList<OperationQueueItem>(GroupUnrelatedDeletes(group)), 
			_ => group, 
		});
	}

	private static IEnumerable<OperationQueueItem> MultipleOpsTurnIntoSingleOp(IEnumerable<OperationQueueItem> itemsWithSameKey, OperationType opTypeToDedup)
	{
		List<OperationQueueItem> currentWrites = null;
		foreach (OperationQueueItem item in itemsWithSameKey)
		{
			if (item.OperationType == opTypeToDedup)
			{
				if (currentWrites == null)
				{
					currentWrites = new List<OperationQueueItem>();
				}
				currentWrites.Add(item);
				continue;
			}
			if (currentWrites != null)
			{
				yield return (currentWrites.Count == 1) ? currentWrites[0] : new OperationQueueItem(CombineSubjectsByOperation(currentWrites[0].Completion, from x in currentWrites.Skip(1)
					select x.Completion, opTypeToDedup), currentWrites[0].Parameters)
				{
					OperationType = currentWrites[0].OperationType
				};
				currentWrites = null;
			}
			yield return item;
		}
		if (currentWrites != null)
		{
			yield return new OperationQueueItem(CombineSubjectsByOperation(currentWrites[0].Completion, from x in currentWrites.Skip(1)
				select x.Completion, opTypeToDedup), currentWrites[0].Parameters)
			{
				OperationType = currentWrites[0].OperationType
			};
		}
	}

	private static OperationQueueItem GroupUnrelatedSelects(IEnumerable<OperationQueueItem> unrelatedSelects)
	{
		Dictionary<string, AsyncSubject<IEnumerable<CacheElement>>> elementMap = new Dictionary<string, AsyncSubject<IEnumerable<CacheElement>>>();
		List<OperationQueueItem> list = unrelatedSelects.ToList();
		if (list.Count == 1)
		{
			return list[0];
		}
		foreach (OperationQueueItem item in list)
		{
			string text = item.ParametersAsKeys?.First();
			if (text != null)
			{
				elementMap[text] = item.CompletionAsElements;
			}
		}
		OperationQueueItem operationQueueItem = OperationQueueItem.CreateSelect(OperationType.BulkSelectSqliteOperation, elementMap.Keys);
		operationQueueItem.CompletionAsElements.Subscribe(delegate(IEnumerable<CacheElement> items)
		{
			Dictionary<string, CacheElement> dictionary = items.ToDictionary((CacheElement k) => k.Key, (CacheElement v) => v);
			foreach (string key in elementMap.Keys)
			{
				try
				{
					AsyncSubject<IEnumerable<CacheElement>> asyncSubject = elementMap[key];
					IEnumerable<CacheElement> value2;
					if (!dictionary.TryGetValue(key, out var value))
					{
						IEnumerable<CacheElement> enumerable = Array.Empty<CacheElement>();
						value2 = enumerable;
					}
					else
					{
						value2 = EnumerableEx.Return(value);
					}
					asyncSubject.OnNext(value2);
					elementMap[key].OnCompleted();
				}
				catch (KeyNotFoundException)
				{
				}
			}
		}, delegate(Exception ex)
		{
			foreach (AsyncSubject<IEnumerable<CacheElement>> value3 in elementMap.Values)
			{
				value3.OnError(ex);
			}
		}, delegate
		{
			foreach (AsyncSubject<IEnumerable<CacheElement>> value4 in elementMap.Values)
			{
				value4.OnCompleted();
			}
		});
		return operationQueueItem;
	}

	private static OperationQueueItem GroupUnrelatedInserts(IEnumerable<OperationQueueItem> unrelatedInserts)
	{
		List<OperationQueueItem> list = unrelatedInserts.ToList();
		if (list.Count == 1)
		{
			return list[0];
		}
		AsyncSubject<Unit> subj = new AsyncSubject<Unit>();
		List<CacheElement> toInsert = list.SelectMany(delegate(OperationQueueItem x)
		{
			subj.Subscribe(x.CompletionAsUnit);
			return x.ParametersAsElements ?? Array.Empty<CacheElement>();
		}).ToList();
		return OperationQueueItem.CreateInsert(OperationType.BulkInsertSqliteOperation, toInsert, subj);
	}

	private static OperationQueueItem GroupUnrelatedDeletes(IEnumerable<OperationQueueItem> unrelatedDeletes)
	{
		AsyncSubject<Unit> subj = new AsyncSubject<Unit>();
		List<OperationQueueItem> list = unrelatedDeletes.ToList();
		if (list.Count == 1)
		{
			return list[0];
		}
		List<string> toInvalidate = list.SelectMany(delegate(OperationQueueItem x)
		{
			subj.Subscribe(x.CompletionAsUnit);
			return x.ParametersAsKeys ?? Array.Empty<string>();
		}).ToList();
		return OperationQueueItem.CreateInvalidate(OperationType.BulkInvalidateSqliteOperation, toInvalidate, subj);
	}

	private static string? GetKeyFromTuple(OperationQueueItem item)
	{
		switch (item.OperationType)
		{
		case OperationType.BulkInsertSqliteOperation:
			if (item.ParametersAsElements != null)
			{
				return item.ParametersAsElements.First().Key;
			}
			break;
		case OperationType.BulkInvalidateByTypeSqliteOperation:
			if (item.ParametersAsKeys == null)
			{
				break;
			}
			goto IL_0076;
		case OperationType.BulkInvalidateSqliteOperation:
			if (item.ParametersAsKeys == null)
			{
				break;
			}
			goto IL_0076;
		case OperationType.BulkSelectSqliteOperation:
			if (item.ParametersAsKeys == null)
			{
				break;
			}
			goto IL_0076;
		case OperationType.BulkSelectByTypeSqliteOperation:
			if (item.ParametersAsKeys == null)
			{
				break;
			}
			goto IL_0076;
		case OperationType.DoNothing:
		case OperationType.InvalidateAllSqliteOperation:
		case OperationType.VacuumSqliteOperation:
		case OperationType.DeleteExpiredSqliteOperation:
		case OperationType.GetKeysSqliteOperation:
			{
				return null;
			}
			IL_0076:
			return item.ParametersAsKeys.First();
		}
		throw new ArgumentException("Unknown operation", "item");
	}

	private static object CombineSubjectsByOperation(object source, IEnumerable<object>? subjects, OperationType opType)
	{
		List<object> source2 = (subjects ?? Array.Empty<object>()).ToList();
		switch (opType)
		{
		case OperationType.BulkSelectSqliteOperation:
			return CombineSubjects((AsyncSubject<IEnumerable<CacheElement>>)source, source2.Cast<AsyncSubject<IEnumerable<CacheElement>>>());
		case OperationType.BulkInsertSqliteOperation:
		case OperationType.BulkInvalidateSqliteOperation:
			return CombineSubjects((AsyncSubject<Unit>)source, source2.Cast<AsyncSubject<Unit>>());
		default:
			throw new ArgumentException("Invalid operation type", "opType");
		}
	}

	private static AsyncSubject<T> CombineSubjects<T>(AsyncSubject<T> source, IEnumerable<AsyncSubject<T>> subjs)
	{
		foreach (AsyncSubject<T> subj in subjs)
		{
			source.Subscribe(subj);
		}
		return source;
	}
}
