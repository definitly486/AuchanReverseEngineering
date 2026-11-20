using System.Reactive.Concurrency;
using System.Reactive.Disposables;

namespace System.Reactive.Linq.ObservableImpl;

internal sealed class Sample<TSource> : Producer<TSource, Sample<TSource>._>
{
	internal sealed class @_ : IdentitySink<TSource>
	{
		private readonly object _gate = new object();

		private SingleAssignmentDisposableValue _sourceDisposable;

		private bool _hasValue;

		private TSource? _value;

		private bool _atEnd;

		public _(IObserver<TSource> observer)
			: base(observer)
		{
		}

		public void Run(Sample<TSource> parent)
		{
			_sourceDisposable.Disposable = parent._source.SubscribeSafe(this);
			SetUpstream(parent._scheduler.SchedulePeriodic(parent._interval, Tick));
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_sourceDisposable.Dispose();
			}
			base.Dispose(disposing);
		}

		private void Tick()
		{
			lock (_gate)
			{
				if (_hasValue)
				{
					_hasValue = false;
					ForwardOnNext(_value);
				}
				if (_atEnd)
				{
					ForwardOnCompleted();
				}
			}
		}

		public override void OnNext(TSource value)
		{
			lock (_gate)
			{
				_hasValue = true;
				_value = value;
			}
		}

		public override void OnError(Exception error)
		{
			lock (_gate)
			{
				ForwardOnError(error);
			}
		}

		public override void OnCompleted()
		{
			lock (_gate)
			{
				_atEnd = true;
				_sourceDisposable.Dispose();
			}
		}
	}

	private readonly IObservable<TSource> _source;

	private readonly TimeSpan _interval;

	private readonly IScheduler _scheduler;

	public Sample(IObservable<TSource> source, TimeSpan interval, IScheduler scheduler)
	{
		_source = source;
		_interval = interval;
		_scheduler = scheduler;
	}

	protected override @_ CreateSink(IObserver<TSource> observer)
	{
		return new @_(observer);
	}

	protected override void Run(@_ sink)
	{
		sink.Run(this);
	}
}
