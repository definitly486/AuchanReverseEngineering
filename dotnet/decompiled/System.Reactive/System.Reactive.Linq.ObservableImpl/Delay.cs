using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Threading;

namespace System.Reactive.Linq.ObservableImpl;

internal static class Delay<TSource>
{
	internal abstract class Base<TParent> : Producer<TSource, Base<TParent>._> where TParent : Base<TParent>
	{
		internal abstract class @_ : IdentitySink<TSource>
		{
			protected readonly IScheduler _scheduler;

			private IStopwatch? _watch;

			protected TimeSpan Elapsed => _watch.Elapsed;

			protected _(TParent parent, IObserver<TSource> observer)
				: base(observer)
			{
				_scheduler = parent._scheduler;
			}

			public void Run(TParent parent)
			{
				_watch = _scheduler.StartStopwatch();
				RunCore(parent);
				base.Run(parent._source);
			}

			protected abstract void RunCore(TParent parent);
		}

		internal abstract class S : @_
		{
			protected readonly object _gate = new object();

			protected SerialDisposableValue _cancelable;

			protected TimeSpan _delay;

			protected bool _ready;

			protected bool _active;

			protected bool _running;

			protected Queue<TimeInterval<TSource>> _queue = new Queue<TimeInterval<TSource>>();

			private bool _hasCompleted;

			private TimeSpan _completeAt;

			private bool _hasFailed;

			private Exception? _exception;

			protected S(TParent parent, IObserver<TSource> observer)
				: base(parent, observer)
			{
			}

			protected override void Dispose(bool disposing)
			{
				base.Dispose(disposing);
				if (disposing)
				{
					_cancelable.Dispose();
				}
			}

			public override void OnNext(TSource value)
			{
				bool flag = false;
				lock (_gate)
				{
					TimeSpan interval = base.Elapsed.Add(_delay);
					_queue.Enqueue(new TimeInterval<TSource>(value, interval));
					flag = _ready && !_active;
					_active = true;
				}
				if (flag)
				{
					DrainQueue(_delay);
				}
			}

			public override void OnError(Exception error)
			{
				DisposeUpstream();
				bool flag = false;
				lock (_gate)
				{
					_queue.Clear();
					_exception = error;
					_hasFailed = true;
					flag = !_running;
				}
				if (flag)
				{
					ForwardOnError(error);
				}
			}

			public override void OnCompleted()
			{
				DisposeUpstream();
				bool flag = false;
				lock (_gate)
				{
					TimeSpan completeAt = base.Elapsed.Add(_delay);
					_completeAt = completeAt;
					_hasCompleted = true;
					flag = _ready && !_active;
					_active = true;
				}
				if (flag)
				{
					DrainQueue(_delay);
				}
			}

			protected void DrainQueue(TimeSpan next)
			{
				_cancelable.Disposable = _scheduler.Schedule(this, next, delegate(S @this, Action<S, TimeSpan> a)
				{
					@this.DrainQueue(a);
				});
			}

			private void DrainQueue(Action<S, TimeSpan> recurse)
			{
				lock (_gate)
				{
					if (_hasFailed)
					{
						return;
					}
					_running = true;
				}
				bool flag = false;
				bool flag2;
				Exception error;
				bool flag4;
				bool flag5;
				TimeSpan arg;
				while (true)
				{
					flag2 = false;
					error = null;
					bool flag3 = false;
					TSource value = default(TSource);
					flag4 = false;
					flag5 = false;
					arg = default(TimeSpan);
					lock (_gate)
					{
						if (_hasFailed)
						{
							error = _exception;
							flag2 = true;
							_running = false;
						}
						else
						{
							TimeSpan elapsed = base.Elapsed;
							if (_queue.Count > 0)
							{
								TimeSpan interval = _queue.Peek().Interval;
								if (interval.CompareTo(elapsed) <= 0 && !flag)
								{
									value = _queue.Dequeue().Value;
									flag3 = true;
								}
								else
								{
									flag5 = true;
									arg = Scheduler.Normalize(interval.Subtract(elapsed));
									_running = false;
								}
							}
							else if (_hasCompleted)
							{
								if (_completeAt.CompareTo(elapsed) <= 0 && !flag)
								{
									flag4 = true;
								}
								else
								{
									flag5 = true;
									arg = Scheduler.Normalize(_completeAt.Subtract(elapsed));
									_running = false;
								}
							}
							else
							{
								_running = false;
								_active = false;
							}
						}
					}
					if (!flag3)
					{
						break;
					}
					ForwardOnNext(value);
					flag = true;
				}
				if (flag4)
				{
					ForwardOnCompleted();
				}
				else if (flag2)
				{
					ForwardOnError(error);
				}
				else if (flag5)
				{
					recurse(this, arg);
				}
			}
		}

		protected abstract class L : @_
		{
			protected readonly object _gate = new object();

			private readonly SemaphoreSlim _evt = new SemaphoreSlim(0);

			protected Queue<TimeInterval<TSource>> _queue = new Queue<TimeInterval<TSource>>();

			protected SerialDisposableValue _cancelable;

			protected TimeSpan _delay;

			private bool _hasCompleted;

			private TimeSpan _completeAt;

			private bool _hasFailed;

			private Exception? _exception;

			protected L(TParent parent, IObserver<TSource> observer)
				: base(parent, observer)
			{
			}

			protected override void Dispose(bool disposing)
			{
				base.Dispose(disposing);
				if (disposing)
				{
					_cancelable.Dispose();
				}
			}

			protected void ScheduleDrain()
			{
				CancellationDisposable cancellationDisposable = new CancellationDisposable();
				_cancelable.Disposable = cancellationDisposable;
				_scheduler.AsLongRunning().ScheduleLongRunning(cancellationDisposable.Token, DrainQueue);
			}

			public override void OnNext(TSource value)
			{
				lock (_gate)
				{
					TimeSpan interval = base.Elapsed.Add(_delay);
					_queue.Enqueue(new TimeInterval<TSource>(value, interval));
					_evt.Release();
				}
			}

			public override void OnError(Exception error)
			{
				DisposeUpstream();
				lock (_gate)
				{
					_queue.Clear();
					_exception = error;
					_hasFailed = true;
					_evt.Release();
				}
			}

			public override void OnCompleted()
			{
				DisposeUpstream();
				lock (_gate)
				{
					TimeSpan completeAt = base.Elapsed.Add(_delay);
					_completeAt = completeAt;
					_hasCompleted = true;
					_evt.Release();
				}
			}

			private void DrainQueue(CancellationToken token, ICancelable cancel)
			{
				bool flag;
				Exception error;
				bool flag3;
				while (true)
				{
					try
					{
						_evt.Wait(token);
					}
					catch (OperationCanceledException)
					{
						return;
					}
					flag = false;
					error = null;
					bool flag2 = false;
					TSource value = default(TSource);
					flag3 = false;
					bool flag4 = false;
					TimeSpan dueTime = default(TimeSpan);
					lock (_gate)
					{
						if (_hasFailed)
						{
							error = _exception;
							flag = true;
						}
						else
						{
							TimeSpan elapsed = base.Elapsed;
							if (_queue.Count > 0)
							{
								TimeInterval<TSource> timeInterval = _queue.Dequeue();
								flag2 = true;
								value = timeInterval.Value;
								TimeSpan interval = timeInterval.Interval;
								if (interval.CompareTo(elapsed) > 0)
								{
									flag4 = true;
									dueTime = Scheduler.Normalize(interval.Subtract(elapsed));
								}
							}
							else if (_hasCompleted)
							{
								flag3 = true;
								if (_completeAt.CompareTo(elapsed) > 0)
								{
									flag4 = true;
									dueTime = Scheduler.Normalize(_completeAt.Subtract(elapsed));
								}
							}
						}
					}
					if (flag4)
					{
						ManualResetEventSlim manualResetEventSlim = new ManualResetEventSlim();
						_scheduler.ScheduleAction(manualResetEventSlim, dueTime, delegate(ManualResetEventSlim slimTimer)
						{
							slimTimer.Set();
						});
						try
						{
							manualResetEventSlim.Wait(token);
						}
						catch (OperationCanceledException)
						{
							return;
						}
					}
					if (!flag2)
					{
						break;
					}
					ForwardOnNext(value);
				}
				if (flag3)
				{
					ForwardOnCompleted();
				}
				else if (flag)
				{
					ForwardOnError(error);
				}
			}
		}

		protected readonly IObservable<TSource> _source;

		protected readonly IScheduler _scheduler;

		protected Base(IObservable<TSource> source, IScheduler scheduler)
		{
			_source = source;
			_scheduler = scheduler;
		}
	}

	internal sealed class Relative : Base<Relative>
	{
		private new sealed class S : Base<Relative>.S
		{
			public S(Relative parent, IObserver<TSource> observer)
				: base(parent, observer)
			{
			}

			protected override void RunCore(Relative parent)
			{
				_ready = true;
				_delay = Scheduler.Normalize(parent._dueTime);
			}
		}

		private new sealed class L : Base<Relative>.L
		{
			public L(Relative parent, IObserver<TSource> observer)
				: base(parent, observer)
			{
			}

			protected override void RunCore(Relative parent)
			{
				_delay = Scheduler.Normalize(parent._dueTime);
				ScheduleDrain();
			}
		}

		private readonly TimeSpan _dueTime;

		public Relative(IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler)
			: base(source, scheduler)
		{
			_dueTime = dueTime;
		}

		protected override @_ CreateSink(IObserver<TSource> observer)
		{
			if (_scheduler.AsLongRunning() == null)
			{
				return new S(this, observer);
			}
			return new L(this, observer);
		}

		protected override void Run(@_ sink)
		{
			sink.Run(this);
		}
	}
}
