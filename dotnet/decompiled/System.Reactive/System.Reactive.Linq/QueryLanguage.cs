using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq.ObservableImpl;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace System.Reactive.Linq;

internal class QueryLanguage : IQueryLanguage
{
	private sealed class CreateWithDisposableObservable<TSource> : ObservableBase<TSource>
	{
		private readonly Func<IObserver<TSource>, IDisposable> _subscribe;

		public CreateWithDisposableObservable(Func<IObserver<TSource>, IDisposable> subscribe)
		{
			_subscribe = subscribe;
		}

		protected override IDisposable SubscribeCore(IObserver<TSource> observer)
		{
			return _subscribe(observer) ?? Disposable.Empty;
		}
	}

	public virtual IObservable<TSource?> LastOrDefaultAsync<TSource>(IObservable<TSource> source)
	{
		return new LastOrDefaultAsync<TSource>.Sequence(source);
	}

	public virtual IObservable<IDictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) where TKey : notnull
	{
		return new ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default);
	}

	public virtual IObservable<IList<TSource>> ToList<TSource>(IObservable<TSource> source)
	{
		return new ToList<TSource>(source);
	}

	public virtual IObservable<TSource> Start<TSource>(Func<TSource> function, IScheduler scheduler)
	{
		return ToAsync(function, scheduler)();
	}

	public virtual IObservable<TSource> StartAsync<TSource>(Func<Task<TSource>> functionAsync)
	{
		return StartAsyncImpl(functionAsync, new TaskObservationOptions.Value(null, ignoreExceptionsAfterUnsubscribe: false));
	}

	public virtual IObservable<TSource> StartAsync<TSource>(Func<Task<TSource>> functionAsync, in TaskObservationOptions.Value options)
	{
		return StartAsyncImpl(functionAsync, in options);
	}

	private IObservable<TSource> StartAsyncImpl<TSource>(Func<Task<TSource>> functionAsync, in TaskObservationOptions.Value options)
	{
		Task<TSource> task;
		try
		{
			task = functionAsync();
		}
		catch (Exception exception)
		{
			return Throw<TSource>(exception);
		}
		return task.ToObservable(options);
	}

	public virtual IObservable<Unit> Start(Action action, IScheduler scheduler)
	{
		return ToAsync(action, scheduler)();
	}

	public virtual IObservable<Unit> StartAsync(Func<Task> actionAsync, in TaskObservationOptions.Value options)
	{
		return StartAsyncImpl(actionAsync, in options);
	}

	private IObservable<Unit> StartAsyncImpl(Func<Task> actionAsync, in TaskObservationOptions.Value options)
	{
		Task task;
		try
		{
			task = actionAsync();
		}
		catch (Exception exception)
		{
			return Throw<Unit>(exception);
		}
		return task.ToObservable(options);
	}

	public virtual IObservable<TResult> FromAsync<TResult>(Func<Task<TResult>> functionAsync)
	{
		return Defer(() => StartAsync(functionAsync));
	}

	public virtual IObservable<TResult> FromAsync<TResult>(Func<Task<TResult>> functionAsync, TaskObservationOptions.Value options)
	{
		return Defer(() => StartAsync(functionAsync, in options));
	}

	public virtual IObservable<Unit> FromAsync(Func<Task> actionAsync, TaskObservationOptions.Value options)
	{
		return Defer(() => StartAsync(actionAsync, in options));
	}

	public virtual Func<IObservable<TResult>> ToAsync<TResult>(Func<TResult> function, IScheduler scheduler)
	{
		return delegate
		{
			AsyncSubject<TResult> asyncSubject = new AsyncSubject<TResult>();
			scheduler.ScheduleAction((function, asyncSubject), delegate((Func<TResult> function, AsyncSubject<TResult> subject) state)
			{
				TResult value;
				try
				{
					value = state.function();
				}
				catch (Exception error)
				{
					state.subject.OnError(error);
					return;
				}
				state.subject.OnNext(value);
				state.subject.OnCompleted();
			});
			return asyncSubject.AsObservable();
		};
	}

	public virtual Func<IObservable<Unit>> ToAsync(Action action, IScheduler scheduler)
	{
		return delegate
		{
			AsyncSubject<Unit> asyncSubject = new AsyncSubject<Unit>();
			scheduler.ScheduleAction((asyncSubject, action), delegate((AsyncSubject<Unit> subject, Action action) state)
			{
				try
				{
					state.action();
				}
				catch (Exception error)
				{
					state.subject.OnError(error);
					return;
				}
				state.subject.OnNext(Unit.Default);
				state.subject.OnCompleted();
			});
			return asyncSubject.AsObservable();
		};
	}

	public virtual AsyncSubject<TSource> GetAwaiter<TSource>(IObservable<TSource> source)
	{
		return RunAsync(source, CancellationToken.None);
	}

	public virtual AsyncSubject<TSource> RunAsync<TSource>(IObservable<TSource> source, CancellationToken cancellationToken)
	{
		AsyncSubject<TSource> asyncSubject = new AsyncSubject<TSource>();
		if (cancellationToken.IsCancellationRequested)
		{
			return Cancel(asyncSubject, cancellationToken);
		}
		IDisposable subscription = source.SubscribeSafe(asyncSubject);
		if (cancellationToken.CanBeCanceled)
		{
			RegisterCancelation(asyncSubject, subscription, cancellationToken);
		}
		return asyncSubject;
	}

	private static AsyncSubject<T> Cancel<T>(AsyncSubject<T> subject, CancellationToken cancellationToken)
	{
		subject.OnError(new OperationCanceledException(cancellationToken));
		return subject;
	}

	private static void RegisterCancelation<T>(AsyncSubject<T> subject, IDisposable subscription, CancellationToken token)
	{
		CancellationTokenRegistration ctr = token.Register(delegate
		{
			subscription.Dispose();
			Cancel(subject, token);
		});
		subject.Subscribe(Stubs<T>.Ignore, delegate
		{
			ctr.Dispose();
		}, ((CancellationTokenRegistration)ctr).Dispose);
	}

	public virtual IConnectableObservable<TResult> Multicast<TSource, TResult>(IObservable<TSource> source, ISubject<TSource, TResult> subject)
	{
		return new ConnectableObservable<TSource, TResult>(source, subject);
	}

	public virtual IConnectableObservable<TSource> PublishLast<TSource>(IObservable<TSource> source)
	{
		return source.Multicast(new AsyncSubject<TSource>());
	}

	public virtual IObservable<TSource> RefCount<TSource>(IConnectableObservable<TSource> source)
	{
		return RefCount(source, 1);
	}

	public virtual IObservable<TSource> RefCount<TSource>(IConnectableObservable<TSource> source, int minObservers)
	{
		return new RefCount<TSource>.Eager(source, minObservers);
	}

	[return: MaybeNull]
	private static TSource LastOrDefaultInternal<TSource>(IObservable<TSource> source, bool throwOnEmpty)
	{
		using LastBlocking<TSource> lastBlocking = new LastBlocking<TSource>();
		using (source.Subscribe(lastBlocking))
		{
			lastBlocking.Wait();
		}
		lastBlocking._error?.Throw();
		if (throwOnEmpty && !lastBlocking._hasValue)
		{
			throw new InvalidOperationException(Strings_Linq.NO_ELEMENTS);
		}
		return lastBlocking._value;
	}

	public virtual TSource Wait<TSource>(IObservable<TSource> source)
	{
		return LastOrDefaultInternal(source, throwOnEmpty: true);
	}

	public virtual IObservable<TSource> ObserveOn<TSource>(IObservable<TSource> source, IScheduler scheduler)
	{
		return Synchronization.ObserveOn(source, scheduler);
	}

	public virtual IObservable<TSource> SubscribeOn<TSource>(IObservable<TSource> source, IScheduler scheduler)
	{
		return Synchronization.SubscribeOn(source, scheduler);
	}

	public virtual IObservable<TSource> ToObservable<TSource>(IEnumerable<TSource> source)
	{
		return ToObservable_(source, SchedulerDefaults.Iteration);
	}

	public virtual IObservable<TSource> ToObservable<TSource>(IEnumerable<TSource> source, IScheduler scheduler)
	{
		return ToObservable_(source, scheduler);
	}

	private static IObservable<TSource> ToObservable_<TSource>(IEnumerable<TSource> source, IScheduler scheduler)
	{
		ISchedulerLongRunning schedulerLongRunning = scheduler.AsLongRunning();
		if (schedulerLongRunning != null)
		{
			return new ToObservableLongRunning<TSource>(source, schedulerLongRunning);
		}
		return new ToObservableRecursive<TSource>(source, scheduler);
	}

	public virtual IObservable<TSource> Create<TSource>(Func<IObserver<TSource>, IDisposable> subscribe)
	{
		return new CreateWithDisposableObservable<TSource>(subscribe);
	}

	public virtual IObservable<TValue> Defer<TValue>(Func<IObservable<TValue>> observableFactory)
	{
		return new Defer<TValue>(observableFactory);
	}

	public virtual IObservable<TResult> Empty<TResult>()
	{
		return EmptyDirect<TResult>.Instance;
	}

	public virtual IObservable<TResult> Return<TResult>(TResult value)
	{
		return Return(value, SchedulerDefaults.ConstantTimeOperations);
	}

	public virtual IObservable<TResult> Return<TResult>(TResult value, IScheduler scheduler)
	{
		if (scheduler == ImmediateScheduler.Instance)
		{
			return new ReturnImmediate<TResult>(value);
		}
		return new Return<TResult>(value, scheduler);
	}

	public virtual IObservable<TResult> Throw<TResult>(Exception exception)
	{
		return Throw<TResult>(exception, SchedulerDefaults.ConstantTimeOperations);
	}

	public virtual IObservable<TResult> Throw<TResult>(Exception exception, IScheduler scheduler)
	{
		if (scheduler == ImmediateScheduler.Instance)
		{
			return new ThrowImmediate<TResult>(exception);
		}
		return new Throw<TResult>(exception, scheduler);
	}

	public virtual IObservable<EventPattern<TEventArgs>> FromEventPattern<TDelegate, TEventArgs>(Action<TDelegate> addHandler, Action<TDelegate> removeHandler)
	{
		return FromEventPattern_<TDelegate, TEventArgs>(addHandler, removeHandler, GetSchedulerForCurrentContext());
	}

	private static IObservable<EventPattern<TEventArgs>> FromEventPattern_<TDelegate, TEventArgs>(Action<TDelegate> addHandler, Action<TDelegate> removeHandler, IScheduler scheduler)
	{
		return new FromEventPattern.Impl<TDelegate, TEventArgs>(addHandler, removeHandler, scheduler);
	}

	public virtual IObservable<EventPattern<TEventArgs>> FromEventPattern<TEventArgs>(Action<EventHandler<TEventArgs>> addHandler, Action<EventHandler<TEventArgs>> removeHandler)
	{
		return FromEventPattern_(addHandler, removeHandler, GetSchedulerForCurrentContext());
	}

	private static IObservable<EventPattern<TEventArgs>> FromEventPattern_<TEventArgs>(Action<EventHandler<TEventArgs>> addHandler, Action<EventHandler<TEventArgs>> removeHandler, IScheduler scheduler)
	{
		return new FromEventPattern.Impl<EventHandler<TEventArgs>, TEventArgs>((EventHandler<TEventArgs> handler) => handler, addHandler, removeHandler, scheduler);
	}

	public virtual IObservable<TEventArgs> FromEvent<TDelegate, TEventArgs>(Func<Action<TEventArgs>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler)
	{
		return FromEvent_(conversion, addHandler, removeHandler, GetSchedulerForCurrentContext());
	}

	private static IObservable<TEventArgs> FromEvent_<TDelegate, TEventArgs>(Func<Action<TEventArgs>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler, IScheduler scheduler)
	{
		return new FromEvent<TDelegate, TEventArgs>(conversion, addHandler, removeHandler, scheduler);
	}

	public virtual IObservable<Unit> FromEvent(Action<Action> addHandler, Action<Action> removeHandler)
	{
		return FromEvent_(addHandler, removeHandler, GetSchedulerForCurrentContext());
	}

	private static IObservable<Unit> FromEvent_(Action<Action> addHandler, Action<Action> removeHandler, IScheduler scheduler)
	{
		return new FromEvent<Action, Unit>((Action<Unit> h) => delegate
		{
			h(default(Unit));
		}, addHandler, removeHandler, scheduler);
	}

	private static IScheduler GetSchedulerForCurrentContext()
	{
		SynchronizationContext current = SynchronizationContext.Current;
		if (current != null)
		{
			return new SynchronizationContextScheduler(current, alwaysPost: false);
		}
		return SchedulerDefaults.ConstantTimeOperations;
	}

	public virtual IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TResult>(IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TResult> resultSelector)
	{
		return new CombineLatest<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TResult>(source1, source2, source3, source4, source5, source6, resultSelector);
	}

	public virtual IObservable<TSource> Catch<TSource, TException>(IObservable<TSource> source, Func<TException, IObservable<TSource>> handler) where TException : Exception
	{
		return new Catch<TSource, TException>(source, handler);
	}

	public virtual IObservable<TSource> Catch<TSource>(IObservable<TSource> first, IObservable<TSource> second)
	{
		return Catch_(new IObservable<TSource>[2] { first, second });
	}

	public virtual IObservable<TSource> Catch<TSource>(IEnumerable<IObservable<TSource>> sources)
	{
		return Catch_(sources);
	}

	private static IObservable<TSource> Catch_<TSource>(IEnumerable<IObservable<TSource>> sources)
	{
		return new Catch<TSource>(sources);
	}

	public virtual IObservable<TSource> Concat<TSource>(IObservable<TSource> first, IObservable<TSource> second)
	{
		return Concat_(new IObservable<TSource>[2] { first, second });
	}

	private static IObservable<TSource> Concat_<TSource>(IEnumerable<IObservable<TSource>> sources)
	{
		return new Concat<TSource>(sources);
	}

	public virtual IObservable<TSource> Concat<TSource>(IObservable<IObservable<TSource>> sources)
	{
		return Concat_(sources);
	}

	private static IObservable<TSource> Concat_<TSource>(IObservable<IObservable<TSource>> sources)
	{
		return new ConcatMany<TSource>(sources);
	}

	public virtual IObservable<TSource> Merge<TSource>(IObservable<IObservable<TSource>> sources)
	{
		return Merge_(sources);
	}

	public virtual IObservable<TSource> Merge<TSource>(IEnumerable<IObservable<TSource>> sources)
	{
		return Merge_(sources.ToObservable(SchedulerDefaults.ConstantTimeOperations));
	}

	private static IObservable<TSource> Merge_<TSource>(IObservable<IObservable<TSource>> sources)
	{
		return new Merge<TSource>.Observables(sources);
	}

	public virtual IObservable<TSource> AsObservable<TSource>(IObservable<TSource> source)
	{
		if (source is AsObservable<TSource> result)
		{
			return result;
		}
		return new AsObservable<TSource>(source);
	}

	public virtual IObservable<TSource> DistinctUntilChanged<TSource>(IObservable<TSource> source)
	{
		return DistinctUntilChanged_(source, (TSource x) => x, EqualityComparer<TSource>.Default);
	}

	private static IObservable<TSource> DistinctUntilChanged_<TSource, TKey>(IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
	{
		return new DistinctUntilChanged<TSource, TKey>(source, keySelector, comparer);
	}

	public virtual IObservable<TSource> Do<TSource>(IObservable<TSource> source, Action<TSource> onNext)
	{
		return new Do<TSource>.OnNext(source, onNext);
	}

	public virtual IObservable<TSource> Finally<TSource>(IObservable<TSource> source, Action finallyAction)
	{
		return new Finally<TSource>(source, finallyAction);
	}

	public virtual IObservable<TSource> IgnoreElements<TSource>(IObservable<TSource> source)
	{
		if (source is IgnoreElements<TSource> result)
		{
			return result;
		}
		return new IgnoreElements<TSource>(source);
	}

	public virtual IObservable<Notification<TSource>> Materialize<TSource>(IObservable<TSource> source)
	{
		return new Materialize<TSource>(source);
	}

	public virtual IObservable<TSource> Retry<TSource>(IObservable<TSource> source, int retryCount)
	{
		return Enumerable.Repeat(source, retryCount).Catch();
	}

	public virtual IObservable<TSource> StartWith<TSource>(IObservable<TSource> source, params TSource[] values)
	{
		return StartWith_(source, SchedulerDefaults.ConstantTimeOperations, values);
	}

	private static IObservable<TSource> StartWith_<TSource>(IObservable<TSource> source, IScheduler scheduler, params TSource[] values)
	{
		return values.ToObservable(scheduler).Concat(source);
	}

	public virtual IObservable<TSource> TakeLast<TSource>(IObservable<TSource> source, int count)
	{
		return TakeLast_(source, count, SchedulerDefaults.Iteration);
	}

	private static IObservable<TSource> TakeLast_<TSource>(IObservable<TSource> source, int count, IScheduler scheduler)
	{
		return new TakeLast<TSource>.Count(source, count, scheduler);
	}

	public virtual IObservable<TResult> Cast<TResult>(IObservable<object> source)
	{
		return new Cast<object, TResult>(source);
	}

	public virtual IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(IObservable<TSource> source, Func<TSource, TKey> keySelector)
	{
		return GroupBy_(source, keySelector, (TSource x) => x, null, EqualityComparer<TKey>.Default);
	}

	private static IObservable<IGroupedObservable<TKey, TElement>> GroupBy_<TSource, TKey, TElement>(IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, int? capacity, IEqualityComparer<TKey> comparer)
	{
		return new GroupBy<TSource, TKey, TElement>(source, keySelector, elementSelector, capacity, comparer);
	}

	public virtual IObservable<TResult> Select<TSource, TResult>(IObservable<TSource> source, Func<TSource, TResult> selector)
	{
		return new Select<TSource, TResult>.Selector(source, selector);
	}

	public virtual IObservable<TResult> SelectMany<TSource, TResult>(IObservable<TSource> source, Func<TSource, IObservable<TResult>> selector)
	{
		return SelectMany_(source, selector);
	}

	private static IObservable<TResult> SelectMany_<TSource, TResult>(IObservable<TSource> source, Func<TSource, IObservable<TResult>> selector)
	{
		return new SelectMany<TSource, TResult>.ObservableSelector(source, selector);
	}

	public virtual IObservable<TResult> SelectMany<TSource, TResult>(IObservable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
	{
		return new SelectMany<TSource, TResult>.EnumerableSelector(source, selector);
	}

	public virtual IObservable<TSource> Skip<TSource>(IObservable<TSource> source, int count)
	{
		if (source is Skip<TSource>.Count count2)
		{
			return count2.Combine(count);
		}
		return new Skip<TSource>.Count(source, count);
	}

	public virtual IObservable<TSource> Take<TSource>(IObservable<TSource> source, int count)
	{
		if (count == 0)
		{
			return Empty<TSource>();
		}
		return Take_(source, count);
	}

	private static IObservable<TSource> Take_<TSource>(IObservable<TSource> source, int count)
	{
		if (source is Take<TSource>.Count count2)
		{
			return count2.Combine(count);
		}
		return new Take<TSource>.Count(source, count);
	}

	public virtual IObservable<TSource> Where<TSource>(IObservable<TSource> source, Func<TSource, bool> predicate)
	{
		if (source is Where<TSource>.Predicate predicate2)
		{
			return predicate2.Combine(predicate);
		}
		return new Where<TSource>.Predicate(source, predicate);
	}

	public virtual IObservable<TSource> Delay<TSource>(IObservable<TSource> source, TimeSpan dueTime)
	{
		return Delay_(source, dueTime, SchedulerDefaults.TimeBasedOperations);
	}

	private static IObservable<TSource> Delay_<TSource>(IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler)
	{
		return new Delay<TSource>.Relative(source, dueTime, scheduler);
	}

	public virtual IObservable<long> Interval(TimeSpan period)
	{
		return Timer_(period, period, SchedulerDefaults.TimeBasedOperations);
	}

	public virtual IObservable<TSource> Sample<TSource>(IObservable<TSource> source, TimeSpan interval)
	{
		return Sample_(source, interval, SchedulerDefaults.TimeBasedOperations);
	}

	private static IObservable<TSource> Sample_<TSource>(IObservable<TSource> source, TimeSpan interval, IScheduler scheduler)
	{
		return new Sample<TSource>(source, interval, scheduler);
	}

	public virtual IObservable<TSource> Throttle<TSource>(IObservable<TSource> source, TimeSpan dueTime)
	{
		return Throttle_(source, dueTime, SchedulerDefaults.TimeBasedOperations);
	}

	private static IObservable<TSource> Throttle_<TSource>(IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler)
	{
		return new Throttle<TSource>(source, dueTime, scheduler);
	}

	public virtual IObservable<TSource> Timeout<TSource>(IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler)
	{
		return Timeout_(source, dueTime, Observable.Throw<TSource>(new TimeoutException()), scheduler);
	}

	private static IObservable<TSource> Timeout_<TSource>(IObservable<TSource> source, TimeSpan dueTime, IObservable<TSource> other, IScheduler scheduler)
	{
		return new Timeout<TSource>.Relative(source, dueTime, other, scheduler);
	}

	public virtual IObservable<long> Timer(TimeSpan dueTime)
	{
		return Timer_(dueTime, SchedulerDefaults.TimeBasedOperations);
	}

	private static IObservable<long> Timer_(TimeSpan dueTime, IScheduler scheduler)
	{
		return new System.Reactive.Linq.ObservableImpl.Timer.Single.Relative(dueTime, scheduler);
	}

	private static IObservable<long> Timer_(TimeSpan dueTime, TimeSpan period, IScheduler scheduler)
	{
		return new System.Reactive.Linq.ObservableImpl.Timer.Periodic.Relative(dueTime, period, scheduler);
	}
}
