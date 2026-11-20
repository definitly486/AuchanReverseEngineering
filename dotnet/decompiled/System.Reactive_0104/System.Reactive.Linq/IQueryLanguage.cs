using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace System.Reactive.Linq;

internal interface IQueryLanguage
{
	IObservable<TSource?> LastOrDefaultAsync<TSource>(IObservable<TSource> source);

	IObservable<IDictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) where TKey : notnull;

	IObservable<IList<TSource>> ToList<TSource>(IObservable<TSource> source);

	IObservable<TSource> Start<TSource>(Func<TSource> function, IScheduler scheduler);

	IObservable<Unit> Start(Action action, IScheduler scheduler);

	IObservable<TResult> FromAsync<TResult>(Func<Task<TResult>> functionAsync);

	IObservable<TResult> FromAsync<TResult>(Func<Task<TResult>> functionAsync, TaskObservationOptions.Value options);

	IObservable<Unit> FromAsync(Func<Task> actionAsync, TaskObservationOptions.Value options);

	AsyncSubject<TSource> GetAwaiter<TSource>(IObservable<TSource> source);

	IConnectableObservable<TResult> Multicast<TSource, TResult>(IObservable<TSource> source, ISubject<TSource, TResult> subject);

	IConnectableObservable<TSource> PublishLast<TSource>(IObservable<TSource> source);

	IObservable<TSource> RefCount<TSource>(IConnectableObservable<TSource> source);

	TSource Wait<TSource>(IObservable<TSource> source);

	IObservable<TSource> ObserveOn<TSource>(IObservable<TSource> source, IScheduler scheduler);

	IObservable<TSource> SubscribeOn<TSource>(IObservable<TSource> source, IScheduler scheduler);

	IObservable<TSource> ToObservable<TSource>(IEnumerable<TSource> source);

	IObservable<TSource> ToObservable<TSource>(IEnumerable<TSource> source, IScheduler scheduler);

	IObservable<TSource> Create<TSource>(Func<IObserver<TSource>, IDisposable> subscribe);

	IObservable<TValue> Defer<TValue>(Func<IObservable<TValue>> observableFactory);

	IObservable<TResult> Empty<TResult>();

	IObservable<TResult> Return<TResult>(TResult value);

	IObservable<TResult> Return<TResult>(TResult value, IScheduler scheduler);

	IObservable<TResult> Throw<TResult>(Exception exception);

	IObservable<EventPattern<TEventArgs>> FromEventPattern<TDelegate, TEventArgs>(Action<TDelegate> addHandler, Action<TDelegate> removeHandler);

	IObservable<EventPattern<TEventArgs>> FromEventPattern<TEventArgs>(Action<EventHandler<TEventArgs>> addHandler, Action<EventHandler<TEventArgs>> removeHandler);

	IObservable<TEventArgs> FromEvent<TDelegate, TEventArgs>(Func<Action<TEventArgs>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler);

	IObservable<Unit> FromEvent(Action<Action> addHandler, Action<Action> removeHandler);

	IObservable<TSource> Catch<TSource, TException>(IObservable<TSource> source, Func<TException, IObservable<TSource>> handler) where TException : Exception;

	IObservable<TSource> Catch<TSource>(IObservable<TSource> first, IObservable<TSource> second);

	IObservable<TSource> Catch<TSource>(IEnumerable<IObservable<TSource>> sources);

	IObservable<TSource> Concat<TSource>(IObservable<TSource> first, IObservable<TSource> second);

	IObservable<TSource> Concat<TSource>(IObservable<IObservable<TSource>> sources);

	IObservable<TSource> Merge<TSource>(IObservable<IObservable<TSource>> sources);

	IObservable<TSource> Merge<TSource>(IEnumerable<IObservable<TSource>> sources);

	IObservable<TSource> AsObservable<TSource>(IObservable<TSource> source);

	IObservable<TSource> DistinctUntilChanged<TSource>(IObservable<TSource> source);

	IObservable<TSource> Do<TSource>(IObservable<TSource> source, Action<TSource> onNext);

	IObservable<TSource> Finally<TSource>(IObservable<TSource> source, Action finallyAction);

	IObservable<TSource> IgnoreElements<TSource>(IObservable<TSource> source);

	IObservable<Notification<TSource>> Materialize<TSource>(IObservable<TSource> source);

	IObservable<TSource> Retry<TSource>(IObservable<TSource> source, int retryCount);

	IObservable<TSource> StartWith<TSource>(IObservable<TSource> source, params TSource[] values);

	IObservable<TSource> TakeLast<TSource>(IObservable<TSource> source, int count);

	IObservable<TResult> Cast<TResult>(IObservable<object> source);

	IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(IObservable<TSource> source, Func<TSource, TKey> keySelector);

	IObservable<TResult> Select<TSource, TResult>(IObservable<TSource> source, Func<TSource, TResult> selector);

	IObservable<TResult> SelectMany<TSource, TResult>(IObservable<TSource> source, Func<TSource, IObservable<TResult>> selector);

	IObservable<TResult> SelectMany<TSource, TResult>(IObservable<TSource> source, Func<TSource, IEnumerable<TResult>> selector);

	IObservable<TSource> Skip<TSource>(IObservable<TSource> source, int count);

	IObservable<TSource> Take<TSource>(IObservable<TSource> source, int count);

	IObservable<TSource> Where<TSource>(IObservable<TSource> source, Func<TSource, bool> predicate);

	IObservable<TSource> Delay<TSource>(IObservable<TSource> source, TimeSpan dueTime);

	IObservable<long> Interval(TimeSpan period);

	IObservable<TSource> Sample<TSource>(IObservable<TSource> source, TimeSpan interval);

	IObservable<TSource> Throttle<TSource>(IObservable<TSource> source, TimeSpan dueTime);

	IObservable<TSource> Timeout<TSource>(IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler);

	IObservable<long> Timer(TimeSpan dueTime);

	IObservable<TResult> CombineLatest<T1, T2, T3, T4, T5, T6, TResult>(IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, IObservable<T4> source4, IObservable<T5> source5, IObservable<T6> source6, Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector);
}
