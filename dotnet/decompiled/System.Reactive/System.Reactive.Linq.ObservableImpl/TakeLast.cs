using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;

namespace System.Reactive.Linq.ObservableImpl;

internal static class TakeLast<TSource>
{
	internal sealed class Count : Producer<TSource, Count._>
	{
		internal sealed class @_ : IdentitySink<TSource>
		{
			private readonly int _count;

			private readonly IScheduler _loopScheduler;

			private readonly Queue<TSource> _queue;

			private MultipleAssignmentDisposableValue _loopDisposable;

			public _(Count parent, IObserver<TSource> observer)
				: base(observer)
			{
				_count = parent._count;
				_loopScheduler = parent._loopScheduler;
				_queue = new Queue<TSource>();
			}

			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					_loopDisposable.Dispose();
				}
				base.Dispose(disposing);
			}

			public override void OnNext(TSource value)
			{
				_queue.Enqueue(value);
				if (_queue.Count > _count)
				{
					_queue.Dequeue();
				}
			}

			public override void OnCompleted()
			{
				DisposeUpstream();
				ISchedulerLongRunning schedulerLongRunning = _loopScheduler.AsLongRunning();
				if (schedulerLongRunning != null)
				{
					_loopDisposable.TrySetFirst(schedulerLongRunning.ScheduleLongRunning(this, delegate(@_ @this, ICancelable c)
					{
						@this.Loop(c);
					}));
					return;
				}
				IDisposable disposable = _loopScheduler.Schedule(this, (IScheduler innerScheduler, @_ @this) => @this.LoopRec(innerScheduler));
				_loopDisposable.TrySetFirst(disposable);
			}

			private IDisposable LoopRec(IScheduler scheduler)
			{
				if (_queue.Count > 0)
				{
					ForwardOnNext(_queue.Dequeue());
					IDisposable disposable = scheduler.Schedule(this, (IScheduler innerScheduler, @_ @this) => @this.LoopRec(innerScheduler));
					_loopDisposable.Disposable = disposable;
				}
				else
				{
					ForwardOnCompleted();
				}
				return Disposable.Empty;
			}

			private void Loop(ICancelable cancel)
			{
				int num = _queue.Count;
				while (!cancel.IsDisposed)
				{
					if (num == 0)
					{
						ForwardOnCompleted();
						break;
					}
					ForwardOnNext(_queue.Dequeue());
					num--;
				}
				Dispose();
			}
		}

		private readonly IObservable<TSource> _source;

		private readonly int _count;

		private readonly IScheduler _loopScheduler;

		public Count(IObservable<TSource> source, int count, IScheduler loopScheduler)
		{
			_source = source;
			_count = count;
			_loopScheduler = loopScheduler;
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
