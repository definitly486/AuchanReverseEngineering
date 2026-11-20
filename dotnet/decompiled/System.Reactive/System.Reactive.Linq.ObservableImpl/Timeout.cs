using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Threading;

namespace System.Reactive.Linq.ObservableImpl;

internal static class Timeout<TSource>
{
	internal sealed class Relative : Producer<TSource, Relative._>
	{
		internal sealed class @_ : IdentitySink<TSource>
		{
			private readonly TimeSpan _dueTime;

			private readonly IObservable<TSource> _other;

			private readonly IScheduler _scheduler;

			private long _index;

			private SingleAssignmentDisposableValue _mainDisposable;

			private SingleAssignmentDisposableValue _otherDisposable;

			private IDisposable? _timerDisposable;

			public _(Relative parent, IObserver<TSource> observer)
				: base(observer)
			{
				_dueTime = parent._dueTime;
				_other = parent._other;
				_scheduler = parent._scheduler;
			}

			public override void Run(IObservable<TSource> source)
			{
				CreateTimer(0L);
				_mainDisposable.Disposable = source.SubscribeSafe(this);
			}

			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					_mainDisposable.Dispose();
					_otherDisposable.Dispose();
					Disposable.Dispose(ref _timerDisposable);
				}
				base.Dispose(disposing);
			}

			private void CreateTimer(long idx)
			{
				if (Disposable.TrySetMultiple(ref _timerDisposable, null))
				{
					IDisposable value = _scheduler.ScheduleAction((idx, this), _dueTime, delegate((long idx, @_ instance) state)
					{
						state.instance.Timeout(state.idx);
					});
					Disposable.TrySetMultiple(ref _timerDisposable, value);
				}
			}

			private void Timeout(long idx)
			{
				if (Volatile.Read(in _index) == idx && Interlocked.CompareExchange(ref _index, long.MaxValue, idx) == idx)
				{
					_mainDisposable.Dispose();
					IDisposable disposable = _other.Subscribe(GetForwarder());
					_otherDisposable.Disposable = disposable;
				}
			}

			public override void OnNext(TSource value)
			{
				long num = Volatile.Read(in _index);
				if (num != long.MaxValue && Interlocked.CompareExchange(ref _index, num + 1, num) == num)
				{
					Volatile.Read(in _timerDisposable)?.Dispose();
					ForwardOnNext(value);
					CreateTimer(num + 1);
				}
			}

			public override void OnError(Exception error)
			{
				if (Interlocked.Exchange(ref _index, long.MaxValue) != long.MaxValue)
				{
					Disposable.Dispose(ref _timerDisposable);
					ForwardOnError(error);
				}
			}

			public override void OnCompleted()
			{
				if (Interlocked.Exchange(ref _index, long.MaxValue) != long.MaxValue)
				{
					Disposable.Dispose(ref _timerDisposable);
					ForwardOnCompleted();
				}
			}
		}

		private readonly IObservable<TSource> _source;

		private readonly TimeSpan _dueTime;

		private readonly IObservable<TSource> _other;

		private readonly IScheduler _scheduler;

		public Relative(IObservable<TSource> source, TimeSpan dueTime, IObservable<TSource> other, IScheduler scheduler)
		{
			_source = source;
			_dueTime = dueTime;
			_other = other;
			_scheduler = scheduler;
		}

		protected override @_ CreateSink(IObserver<TSource> observer)
		{
			return new @_(this, observer);
		}

		protected override void Run(@_ sink)
		{
			sink.Run(_source);
		}
	}
}
