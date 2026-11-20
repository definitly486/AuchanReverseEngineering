using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using Splat;

namespace Akavache;

[RequiresUnreferencedCode("Registrations for Akavache.Core")]
[RequiresDynamicCode("Registrations for Akavache.Core")]
public class KeyedOperationQueue : IKeyedOperationQueue, IEnableLogger, IDisposable
{
	private static int _sequenceNumber = 1;

	private readonly IScheduler _scheduler;

	private readonly Subject<KeyedOperation> _queuedOps = new Subject<KeyedOperation>();

	private readonly IConnectableObservable<KeyedOperation> _resultObs;

	private AsyncSubject<Unit>? _shutdownObs;

	public KeyedOperationQueue(IScheduler? scheduler = null)
	{
		if (scheduler == null)
		{
			scheduler = BlobCache.TaskpoolScheduler;
		}
		_scheduler = scheduler;
		_resultObs = (from x in _queuedOps
			group x by x.Key into x
			select x.Select(ProcessOperation).Concat()).Merge().Multicast(new Subject<KeyedOperation>());
		_resultObs.Connect();
	}

	public IObservable<Unit> EnqueueOperation(string key, Action action)
	{
		return EnqueueOperation(key, delegate
		{
			action();
			return Unit.Default;
		});
	}

	public IObservable<T> EnqueueOperation<T>(string key, Func<T> calculationFunc)
	{
		return EnqueueObservableOperation(key, () => SafeStart(calculationFunc));
	}

	public IObservable<T> EnqueueObservableOperation<T>(string key, Func<IObservable<T>> asyncCalculationFunc)
	{
		int num = Interlocked.Increment(ref _sequenceNumber);
		if (key == null)
		{
			key = "__NONE__";
		}
		this.Log().Debug(CultureInfo.InvariantCulture, "Queuing operation {0} with key {1}", num, key);
		KeyedOperation<T> keyedOperation = new KeyedOperation<T>(asyncCalculationFunc, key, num);
		_queuedOps.OnNext(keyedOperation);
		return keyedOperation.Result;
	}

	public IObservable<Unit> ShutdownQueue()
	{
		lock (_queuedOps)
		{
			if (_shutdownObs != null)
			{
				return _shutdownObs;
			}
			_queuedOps.OnCompleted();
			_shutdownObs = new AsyncSubject<Unit>();
			(from x in _resultObs.Materialize()
				where x.Kind != NotificationKind.OnNext
				select x).SelectMany((Notification<KeyedOperation> x) => (x.Kind != NotificationKind.OnError || x.Exception == null) ? Observable.Return(Unit.Default) : Observable.Throw<Unit>(x.Exception)).Multicast(_shutdownObs).Connect();
			return _shutdownObs;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			_queuedOps?.Dispose();
			_shutdownObs?.Dispose();
		}
	}

	private static IObservable<KeyedOperation> ProcessOperation(KeyedOperation operation)
	{
		return (from _ in Observable.Defer(operation.EvaluateFunc)
			select operation).Catch(Observable.Return(operation));
	}

	private AsyncSubject<T> SafeStart<T>(Func<T> calculationFunc)
	{
		AsyncSubject<T> ret = new AsyncSubject<T>();
		Observable.Start(delegate
		{
			try
			{
				T value = calculationFunc();
				ret.OnNext(value);
				ret.OnCompleted();
			}
			catch (Exception ex)
			{
				this.Log().Warn(ex, "Failure running queued op");
				ret.OnError(ex);
			}
		}, _scheduler);
		return ret;
	}
}
