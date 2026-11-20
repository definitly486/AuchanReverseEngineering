namespace System.Reactive.Concurrency;

internal static class ObserveOn<TSource>
{
	internal sealed class Scheduler : Producer<TSource, ObserveOnObserverNew<TSource>>
	{
		private readonly IObservable<TSource> _source;

		private readonly IScheduler _scheduler;

		public Scheduler(IObservable<TSource> source, IScheduler scheduler)
		{
			_source = source;
			_scheduler = scheduler;
		}

		protected override ObserveOnObserverNew<TSource> CreateSink(IObserver<TSource> observer)
		{
			return new ObserveOnObserverNew<TSource>(_scheduler, observer);
		}

		protected override void Run(ObserveOnObserverNew<TSource> sink)
		{
			sink.Run(_source);
		}
	}

	internal sealed class SchedulerLongRunning : Producer<TSource, ObserveOnObserverLongRunning<TSource>>
	{
		private readonly IObservable<TSource> _source;

		private readonly ISchedulerLongRunning _scheduler;

		public SchedulerLongRunning(IObservable<TSource> source, ISchedulerLongRunning scheduler)
		{
			_source = source;
			_scheduler = scheduler;
		}

		protected override ObserveOnObserverLongRunning<TSource> CreateSink(IObserver<TSource> observer)
		{
			return new ObserveOnObserverLongRunning<TSource>(_scheduler, observer);
		}

		protected override void Run(ObserveOnObserverLongRunning<TSource> sink)
		{
			sink.Run(_source);
		}
	}
}
