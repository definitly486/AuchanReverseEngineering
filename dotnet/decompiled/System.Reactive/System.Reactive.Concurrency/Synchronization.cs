using System.ComponentModel;
using System.Reactive.Disposables;

namespace System.Reactive.Concurrency;

[EditorBrowsable(EditorBrowsableState.Advanced)]
public static class Synchronization
{
	private sealed class SubscribeOnObservable<TSource> : ObservableBase<TSource>
	{
		private sealed class Subscription : IDisposable
		{
			private SerialDisposableValue _cancel;

			public Subscription(IObservable<TSource> source, IScheduler scheduler, IObserver<TSource> observer)
			{
				_cancel.TrySetFirst(scheduler.Schedule((this, source, observer), delegate(IScheduler closureScheduler, (Subscription @this, IObservable<TSource> source, IObserver<TSource> observer) state)
				{
					state.@this._cancel.Disposable = new ScheduledDisposable(closureScheduler, state.source.SubscribeSafe(state.observer));
					return Disposable.Empty;
				}));
			}

			public void Dispose()
			{
				_cancel.Dispose();
			}
		}

		private readonly IObservable<TSource> _source;

		private readonly IScheduler _scheduler;

		public SubscribeOnObservable(IObservable<TSource> source, IScheduler scheduler)
		{
			_source = source;
			_scheduler = scheduler;
		}

		protected override IDisposable SubscribeCore(IObserver<TSource> observer)
		{
			return new Subscription(_source, _scheduler, observer);
		}
	}

	public static IObservable<TSource> SubscribeOn<TSource>(IObservable<TSource> source, IScheduler scheduler)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		return new SubscribeOnObservable<TSource>(source, scheduler);
	}

	public static IObservable<TSource> ObserveOn<TSource>(IObservable<TSource> source, IScheduler scheduler)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		ISchedulerLongRunning schedulerLongRunning = scheduler.AsLongRunning();
		if (schedulerLongRunning != null)
		{
			return new ObserveOn<TSource>.SchedulerLongRunning(source, schedulerLongRunning);
		}
		return new ObserveOn<TSource>.Scheduler(source, scheduler);
	}
}
