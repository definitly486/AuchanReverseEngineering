using System;
using System.Reactive;

namespace Akavache;

public interface IKeyedOperationQueue
{
	IObservable<T> EnqueueObservableOperation<T>(string key, Func<IObservable<T>> asyncCalculationFunc);

	IObservable<T> EnqueueOperation<T>(string key, Func<T> calculationFunc);

	IObservable<Unit> EnqueueOperation(string key, Action action);

	IObservable<Unit> ShutdownQueue();
}
