using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace System.Reactive.Linq;

public static class Observable
{
	private static IQueryLanguage s_impl = QueryServices.GetQueryImpl((IQueryLanguage)new QueryLanguage());

	public static IObservable<TSource?> LastOrDefaultAsync<TSource>(this IObservable<TSource> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return s_impl.LastOrDefaultAsync(source);
	}

	public static IObservable<IDictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) where TKey : notnull
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (keySelector == null)
		{
			throw new ArgumentNullException("keySelector");
		}
		if (elementSelector == null)
		{
			throw new ArgumentNullException("elementSelector");
		}
		return s_impl.ToDictionary(source, keySelector, elementSelector);
	}

	public static IObservable<IList<TSource>> ToList<TSource>(this IObservable<TSource> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return s_impl.ToList(source);
	}

	public static IObservable<TResult> Start<TResult>(Func<TResult> function, IScheduler scheduler)
	{
		if (function == null)
		{
			throw new ArgumentNullException("function");
		}
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		return s_impl.Start(function, scheduler);
	}

	public static IObservable<Unit> Start(Action action, IScheduler scheduler)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		return s_impl.Start(action, scheduler);
	}

	public static IObservable<TResult> FromAsync<TResult>(Func<Task<TResult>> functionAsync)
	{
		if (functionAsync == null)
		{
			throw new ArgumentNullException("functionAsync");
		}
		return s_impl.FromAsync(functionAsync);
	}

	public static IObservable<TResult> FromAsync<TResult>(Func<Task<TResult>> functionAsync, IScheduler scheduler)
	{
		if (functionAsync == null)
		{
			throw new ArgumentNullException("functionAsync");
		}
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		return s_impl.FromAsync(functionAsync, new TaskObservationOptions.Value(scheduler, ignoreExceptionsAfterUnsubscribe: false));
	}

	public static IObservable<Unit> FromAsync(Func<Task> actionAsync, IScheduler scheduler)
	{
		if (actionAsync == null)
		{
			throw new ArgumentNullException("actionAsync");
		}
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		return s_impl.FromAsync(actionAsync, new TaskObservationOptions.Value(scheduler, ignoreExceptionsAfterUnsubscribe: false));
	}

	public static AsyncSubject<TSource> GetAwaiter<TSource>(this IObservable<TSource> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return s_impl.GetAwaiter(source);
	}

	public static IConnectableObservable<TResult> Multicast<TSource, TResult>(this IObservable<TSource> source, ISubject<TSource, TResult> subject)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (subject == null)
		{
			throw new ArgumentNullException("subject");
		}
		return s_impl.Multicast(source, subject);
	}

	public static IConnectableObservable<TSource> PublishLast<TSource>(this IObservable<TSource> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return s_impl.PublishLast(source);
	}

	public static IObservable<TSource> RefCount<TSource>(this IConnectableObservable<TSource> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return s_impl.RefCount(source);
	}

	public static TSource Wait<TSource>(this IObservable<TSource> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return s_impl.Wait(source);
	}

	public static IObservable<TSource> ObserveOn<TSource>(this IObservable<TSource> source, IScheduler scheduler)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		return s_impl.ObserveOn(source, scheduler);
	}

	public static IObservable<TSource> SubscribeOn<TSource>(this IObservable<TSource> source, IScheduler scheduler)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		return s_impl.SubscribeOn(source, scheduler);
	}

	public static IObservable<TSource> ToObservable<TSource>(this IEnumerable<TSource> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return s_impl.ToObservable(source);
	}

	public static IObservable<TSource> ToObservable<TSource>(this IEnumerable<TSource> source, IScheduler scheduler)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		return s_impl.ToObservable(source, scheduler);
	}

	public static IObservable<TResult> Create<TResult>(Func<IObserver<TResult>, IDisposable> subscribe)
	{
		if (subscribe == null)
		{
			throw new ArgumentNullException("subscribe");
		}
		return s_impl.Create(subscribe);
	}

	public static IObservable<TResult> Defer<TResult>(Func<IObservable<TResult>> observableFactory)
	{
		if (observableFactory == null)
		{
			throw new ArgumentNullException("observableFactory");
		}
		return s_impl.Defer(observableFactory);
	}

	public static IObservable<TResult> Empty<TResult>()
	{
		return s_impl.Empty<TResult>();
	}

	public static IObservable<TResult> Return<TResult>(TResult value)
	{
		return s_impl.Return(value);
	}

	public static IObservable<TResult> Return<TResult>(TResult value, IScheduler scheduler)
	{
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		return s_impl.Return(value, scheduler);
	}

	public static IObservable<TResult> Throw<TResult>(Exception exception)
	{
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		return s_impl.Throw<TResult>(exception);
	}

	public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TDelegate, TEventArgs>(Action<TDelegate> addHandler, Action<TDelegate> removeHandler)
	{
		if (addHandler == null)
		{
			throw new ArgumentNullException("addHandler");
		}
		if (removeHandler == null)
		{
			throw new ArgumentNullException("removeHandler");
		}
		return s_impl.FromEventPattern<TDelegate, TEventArgs>(addHandler, removeHandler);
	}

	public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TEventArgs>(Action<EventHandler<TEventArgs>> addHandler, Action<EventHandler<TEventArgs>> removeHandler)
	{
		if (addHandler == null)
		{
			throw new ArgumentNullException("addHandler");
		}
		if (removeHandler == null)
		{
			throw new ArgumentNullException("removeHandler");
		}
		return s_impl.FromEventPattern(addHandler, removeHandler);
	}

	public static IObservable<TEventArgs> FromEvent<TDelegate, TEventArgs>(Func<Action<TEventArgs>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler)
	{
		if (conversion == null)
		{
			throw new ArgumentNullException("conversion");
		}
		if (addHandler == null)
		{
			throw new ArgumentNullException("addHandler");
		}
		if (removeHandler == null)
		{
			throw new ArgumentNullException("removeHandler");
		}
		return s_impl.FromEvent(conversion, addHandler, removeHandler);
	}

	public static IObservable<Unit> FromEvent(Action<Action> addHandler, Action<Action> removeHandler)
	{
		if (addHandler == null)
		{
			throw new ArgumentNullException("addHandler");
		}
		if (removeHandler == null)
		{
			throw new ArgumentNullException("removeHandler");
		}
		return s_impl.FromEvent(addHandler, removeHandler);
	}

	public static IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TResult> resultSelector)
	{
		if (source1 == null)
		{
			throw new ArgumentNullException("source1");
		}
		if (source2 == null)
		{
			throw new ArgumentNullException("source2");
		}
		if (source3 == null)
		{
			throw new ArgumentNullException("source3");
		}
		if (source4 == null)
		{
			throw new ArgumentNullException("source4");
		}
		if (source5 == null)
		{
			throw new ArgumentNullException("source5");
		}
		if (source6 == null)
		{
			throw new ArgumentNullException("source6");
		}
		if (resultSelector == null)
		{
			throw new ArgumentNullException("resultSelector");
		}
		return s_impl.CombineLatest(source1, source2, source3, source4, source5, source6, resultSelector);
	}

	public static IObservable<TSource> Catch<TSource, TException>(this IObservable<TSource> source, Func<TException, IObservable<TSource>> handler) where TException : Exception
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (handler == null)
		{
			throw new ArgumentNullException("handler");
		}
		return s_impl.Catch(source, handler);
	}

	public static IObservable<TSource> Catch<TSource>(this IObservable<TSource> first, IObservable<TSource> second)
	{
		if (first == null)
		{
			throw new ArgumentNullException("first");
		}
		if (second == null)
		{
			throw new ArgumentNullException("second");
		}
		return s_impl.Catch(first, second);
	}

	public static IObservable<TSource> Catch<TSource>(this IEnumerable<IObservable<TSource>> sources)
	{
		if (sources == null)
		{
			throw new ArgumentNullException("sources");
		}
		return s_impl.Catch(sources);
	}

	public static IObservable<TSource> Concat<TSource>(this IObservable<TSource> first, IObservable<TSource> second)
	{
		if (first == null)
		{
			throw new ArgumentNullException("first");
		}
		if (second == null)
		{
			throw new ArgumentNullException("second");
		}
		return s_impl.Concat(first, second);
	}

	public static IObservable<TSource> Concat<TSource>(this IObservable<IObservable<TSource>> sources)
	{
		if (sources == null)
		{
			throw new ArgumentNullException("sources");
		}
		return s_impl.Concat(sources);
	}

	public static IObservable<TSource> Merge<TSource>(this IObservable<IObservable<TSource>> sources)
	{
		if (sources == null)
		{
			throw new ArgumentNullException("sources");
		}
		return s_impl.Merge(sources);
	}

	public static IObservable<TSource> Merge<TSource>(this IEnumerable<IObservable<TSource>> sources)
	{
		if (sources == null)
		{
			throw new ArgumentNullException("sources");
		}
		return s_impl.Merge(sources);
	}

	public static IObservable<TSource> AsObservable<TSource>(this IObservable<TSource> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return s_impl.AsObservable(source);
	}

	public static IObservable<TSource> DistinctUntilChanged<TSource>(this IObservable<TSource> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return s_impl.DistinctUntilChanged(source);
	}

	public static IObservable<TSource> Do<TSource>(this IObservable<TSource> source, Action<TSource> onNext)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (onNext == null)
		{
			throw new ArgumentNullException("onNext");
		}
		return s_impl.Do(source, onNext);
	}

	public static IObservable<TSource> Finally<TSource>(this IObservable<TSource> source, Action finallyAction)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (finallyAction == null)
		{
			throw new ArgumentNullException("finallyAction");
		}
		return s_impl.Finally(source, finallyAction);
	}

	public static IObservable<TSource> IgnoreElements<TSource>(this IObservable<TSource> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return s_impl.IgnoreElements(source);
	}

	public static IObservable<Notification<TSource>> Materialize<TSource>(this IObservable<TSource> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return s_impl.Materialize(source);
	}

	public static IObservable<TSource> Retry<TSource>(this IObservable<TSource> source, int retryCount)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (retryCount < 0)
		{
			throw new ArgumentOutOfRangeException("retryCount");
		}
		return s_impl.Retry(source, retryCount);
	}

	public static IObservable<TSource> StartWith<TSource>(this IObservable<TSource> source, params TSource[] values)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		return s_impl.StartWith(source, values);
	}

	public static IObservable<TSource> TakeLast<TSource>(this IObservable<TSource> source, int count)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		return s_impl.TakeLast(source, count);
	}

	public static IObservable<TResult> Cast<TResult>(this IObservable<object> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return s_impl.Cast<TResult>(source);
	}

	public static IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (keySelector == null)
		{
			throw new ArgumentNullException("keySelector");
		}
		return s_impl.GroupBy(source, keySelector);
	}

	public static IObservable<TResult> Select<TSource, TResult>(this IObservable<TSource> source, Func<TSource, TResult> selector)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (selector == null)
		{
			throw new ArgumentNullException("selector");
		}
		return s_impl.Select(source, selector);
	}

	public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IObservable<TResult>> selector)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (selector == null)
		{
			throw new ArgumentNullException("selector");
		}
		return s_impl.SelectMany(source, selector);
	}

	public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (selector == null)
		{
			throw new ArgumentNullException("selector");
		}
		return s_impl.SelectMany(source, selector);
	}

	public static IObservable<TSource> Skip<TSource>(this IObservable<TSource> source, int count)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		return s_impl.Skip(source, count);
	}

	public static IObservable<TSource> Take<TSource>(this IObservable<TSource> source, int count)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		return s_impl.Take(source, count);
	}

	public static IObservable<TSource> Where<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (predicate == null)
		{
			throw new ArgumentNullException("predicate");
		}
		return s_impl.Where(source, predicate);
	}

	public static IObservable<TSource> Delay<TSource>(this IObservable<TSource> source, TimeSpan dueTime)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (dueTime < TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("dueTime");
		}
		return s_impl.Delay(source, dueTime);
	}

	public static IObservable<long> Interval(TimeSpan period)
	{
		if (period < TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("period");
		}
		return s_impl.Interval(period);
	}

	public static IObservable<TSource> Sample<TSource>(this IObservable<TSource> source, TimeSpan interval)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (interval < TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("interval");
		}
		return s_impl.Sample(source, interval);
	}

	public static IObservable<TSource> Throttle<TSource>(this IObservable<TSource> source, TimeSpan dueTime)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (dueTime < TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("dueTime");
		}
		return s_impl.Throttle(source, dueTime);
	}

	public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (dueTime < TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("dueTime");
		}
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		return s_impl.Timeout(source, dueTime, scheduler);
	}

	public static IObservable<long> Timer(TimeSpan dueTime)
	{
		return s_impl.Timer(dueTime);
	}
}
