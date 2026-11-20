using System.Reactive.Disposables;
using System.Reactive.PlatformServices;
using System.Threading;

namespace System.Reactive.Concurrency;

public static class Scheduler
{
	private abstract class InvokeRecBaseState : IDisposable
	{
		protected readonly IScheduler Scheduler;

		protected readonly CompositeDisposable Group = new CompositeDisposable();

		protected InvokeRecBaseState(IScheduler scheduler)
		{
			Scheduler = scheduler;
		}

		public void Dispose()
		{
			Group.Dispose();
		}
	}

	private sealed class InvokeRec1State<TState> : InvokeRecBaseState
	{
		private readonly Action<TState, Action<TState>> _action;

		private readonly Action<TState> _recurseCallback;

		public InvokeRec1State(IScheduler scheduler, Action<TState, Action<TState>> action)
			: base(scheduler)
		{
			_action = action;
			_recurseCallback = delegate(TState state)
			{
				InvokeNext(state);
			};
		}

		private void InvokeNext(TState state)
		{
			SingleAssignmentDisposable singleAssignmentDisposable = new SingleAssignmentDisposable();
			Group.Add(singleAssignmentDisposable);
			singleAssignmentDisposable.Disposable = Scheduler.ScheduleAction((state, singleAssignmentDisposable, this), delegate((TState state, SingleAssignmentDisposable sad, InvokeRec1State<TState> @this) nextState)
			{
				nextState.@this.Group.Remove(nextState.sad);
				nextState.@this.InvokeFirst(nextState.state);
			});
		}

		internal void InvokeFirst(TState state)
		{
			_action(state, _recurseCallback);
		}
	}

	private sealed class InvokeRec2State<TState> : InvokeRecBaseState
	{
		private readonly Action<TState, Action<TState, TimeSpan>> _action;

		private readonly Action<TState, TimeSpan> _recurseCallback;

		public InvokeRec2State(IScheduler scheduler, Action<TState, Action<TState, TimeSpan>> action)
			: base(scheduler)
		{
			_action = action;
			_recurseCallback = delegate(TState state, TimeSpan time)
			{
				InvokeNext(state, time);
			};
		}

		private void InvokeNext(TState state, TimeSpan time)
		{
			SingleAssignmentDisposable singleAssignmentDisposable = new SingleAssignmentDisposable();
			Group.Add(singleAssignmentDisposable);
			singleAssignmentDisposable.Disposable = Scheduler.ScheduleAction((state, singleAssignmentDisposable, this), time, delegate((TState state, SingleAssignmentDisposable sad, InvokeRec2State<TState> @this) nextState)
			{
				nextState.@this.Group.Remove(nextState.sad);
				nextState.@this.InvokeFirst(nextState.state);
			});
		}

		internal void InvokeFirst(TState state)
		{
			_action(state, _recurseCallback);
		}
	}

	private sealed class SchedulePeriodicStopwatch<TState> : IDisposable
	{
		private readonly IScheduler _scheduler;

		private readonly TimeSpan _period;

		private readonly Func<TState, TState> _action;

		private readonly IStopwatchProvider _stopwatchProvider;

		private TState _state;

		private readonly object _gate = new object();

		private readonly AutoResetEvent _resumeEvent = new AutoResetEvent(initialState: false);

		private volatile int _runState;

		private IStopwatch? _stopwatch;

		private TimeSpan _nextDue;

		private TimeSpan _suspendedAt;

		private TimeSpan _inactiveTime;

		private SingleAssignmentDisposableValue _task;

		public SchedulePeriodicStopwatch(IScheduler scheduler, TState state, TimeSpan period, Func<TState, TState> action, IStopwatchProvider stopwatchProvider)
		{
			_scheduler = scheduler;
			_period = period;
			_action = action;
			_stopwatchProvider = stopwatchProvider;
			_state = state;
			_runState = 0;
		}

		public IDisposable Start()
		{
			RegisterHostLifecycleEventHandlers();
			_stopwatch = _stopwatchProvider.StartStopwatch();
			_nextDue = _period;
			_runState = 1;
			_task.Disposable = _scheduler.Schedule(this, _nextDue, delegate(SchedulePeriodicStopwatch<TState> @this, Action<SchedulePeriodicStopwatch<TState>, TimeSpan> a)
			{
				@this.Tick(a);
			});
			return this;
		}

		void IDisposable.Dispose()
		{
			_task.Dispose();
			Cancel();
		}

		private void Tick(Action<SchedulePeriodicStopwatch<TState>, TimeSpan> recurse)
		{
			_nextDue += _period;
			_state = _action(_state);
			TimeSpan arg = default(TimeSpan);
			while (true)
			{
				lock (_gate)
				{
					if (_runState == 1)
					{
						arg = Normalize(_nextDue - (_stopwatch.Elapsed - _inactiveTime));
						break;
					}
					if (_runState == 3)
					{
						return;
					}
				}
				_resumeEvent.WaitOne();
			}
			recurse(this, arg);
		}

		private void Cancel()
		{
			UnregisterHostLifecycleEventHandlers();
			lock (_gate)
			{
				_runState = 3;
				_ = 0;
				_resumeEvent.Set();
			}
		}

		private void Suspending(object? sender, HostSuspendingEventArgs args)
		{
			lock (_gate)
			{
				if (_runState == 1)
				{
					_suspendedAt = _stopwatch.Elapsed;
					_runState = 2;
					_ = 0;
					_resumeEvent.Reset();
				}
			}
		}

		private void Resuming(object? sender, HostResumingEventArgs args)
		{
			lock (_gate)
			{
				if (_runState == 2)
				{
					_inactiveTime += _stopwatch.Elapsed - _suspendedAt;
					_runState = 1;
					_ = 0;
					_resumeEvent.Set();
				}
			}
		}

		private void RegisterHostLifecycleEventHandlers()
		{
			HostLifecycleService.Suspending += Suspending;
			HostLifecycleService.Resuming += Resuming;
			HostLifecycleService.AddRef();
		}

		private void UnregisterHostLifecycleEventHandlers()
		{
			HostLifecycleService.Suspending -= Suspending;
			HostLifecycleService.Resuming -= Resuming;
			HostLifecycleService.Release();
		}
	}

	private sealed class SchedulePeriodicRecursive<TState>
	{
		private readonly IScheduler _scheduler;

		private readonly TimeSpan _period;

		private readonly Func<TState, TState> _action;

		private TState _state;

		private int _pendingTickCount;

		private IDisposable? _cancel;

		public SchedulePeriodicRecursive(IScheduler scheduler, TState state, TimeSpan period, Func<TState, TState> action)
		{
			_scheduler = scheduler;
			_period = period;
			_action = action;
			_state = state;
		}

		public IDisposable Start()
		{
			_pendingTickCount = 0;
			SingleAssignmentDisposable singleAssignmentDisposable = (SingleAssignmentDisposable)(_cancel = new SingleAssignmentDisposable());
			singleAssignmentDisposable.Disposable = _scheduler.Schedule(0, _period, Tick);
			return singleAssignmentDisposable;
		}

		private void Tick(int command, Action<int, TimeSpan> recurse)
		{
			switch (command)
			{
			case 0:
				recurse(0, _period);
				if (Interlocked.Increment(ref _pendingTickCount) != 1)
				{
					break;
				}
				goto case 1;
			case 1:
				try
				{
					_state = _action(_state);
				}
				catch (Exception exception)
				{
					_cancel.Dispose();
					exception.Throw();
				}
				recurse(2, TimeSpan.Zero);
				break;
			case 2:
				if (Interlocked.Decrement(ref _pendingTickCount) > 0)
				{
					recurse(1, TimeSpan.Zero);
				}
				break;
			}
		}
	}

	private sealed class EmulatedStopwatch : IStopwatch
	{
		private readonly IScheduler _scheduler;

		private readonly DateTimeOffset _start;

		public TimeSpan Elapsed => Normalize(_scheduler.Now - _start);

		public EmulatedStopwatch(IScheduler scheduler)
		{
			_scheduler = scheduler;
			_start = _scheduler.Now;
		}
	}

	public static DateTimeOffset Now => SystemClock.UtcNow;

	public static ImmediateScheduler Immediate => ImmediateScheduler.Instance;

	public static DefaultScheduler Default => DefaultScheduler.Instance;

	public static TimeSpan Normalize(TimeSpan timeSpan)
	{
		if (timeSpan.Ticks >= 0)
		{
			return timeSpan;
		}
		return TimeSpan.Zero;
	}

	public static IDisposable Schedule<TState>(this IScheduler scheduler, TState state, Action<TState, Action<TState>> action)
	{
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return scheduler.Schedule((state, action), (IScheduler s, (TState state, Action<TState, Action<TState>> action) p) => InvokeRec1(s, p));
	}

	private static IDisposable InvokeRec1<TState>(IScheduler scheduler, (TState state, Action<TState, Action<TState>> action) tuple)
	{
		InvokeRec1State<TState> invokeRec1State = new InvokeRec1State<TState>(scheduler, tuple.action);
		invokeRec1State.InvokeFirst(tuple.state);
		return invokeRec1State;
	}

	public static IDisposable Schedule<TState>(this IScheduler scheduler, TState state, TimeSpan dueTime, Action<TState, Action<TState, TimeSpan>> action)
	{
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return scheduler.Schedule((state, action), dueTime, (IScheduler s, (TState state, Action<TState, Action<TState, TimeSpan>> action) p) => InvokeRec2(s, p));
	}

	private static IDisposable InvokeRec2<TState>(IScheduler scheduler, (TState state, Action<TState, Action<TState, TimeSpan>> action) tuple)
	{
		InvokeRec2State<TState> invokeRec2State = new InvokeRec2State<TState>(scheduler, tuple.action);
		invokeRec2State.InvokeFirst(tuple.state);
		return invokeRec2State;
	}

	public static ISchedulerLongRunning? AsLongRunning(this IScheduler scheduler)
	{
		return As<ISchedulerLongRunning>(scheduler);
	}

	public static IStopwatchProvider? AsStopwatchProvider(this IScheduler scheduler)
	{
		return As<IStopwatchProvider>(scheduler);
	}

	public static ISchedulerPeriodic? AsPeriodic(this IScheduler scheduler)
	{
		return As<ISchedulerPeriodic>(scheduler);
	}

	private static T? As<T>(IScheduler scheduler) where T : class
	{
		if (scheduler is IServiceProvider serviceProvider)
		{
			return (T)serviceProvider.GetService(typeof(T));
		}
		return null;
	}

	public static IDisposable SchedulePeriodic<TState>(this IScheduler scheduler, TState state, TimeSpan period, Action<TState> action)
	{
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		if (period < TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("period");
		}
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return SchedulePeriodic_(scheduler, (state, action), period, delegate((TState state, Action<TState> action) t)
		{
			t.action(t.state);
			return t;
		});
	}

	public static IDisposable SchedulePeriodic(this IScheduler scheduler, TimeSpan period, Action action)
	{
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		if (period < TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("period");
		}
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return SchedulePeriodic_(scheduler, action, period, delegate(Action a)
		{
			a();
			return a;
		});
	}

	public static IStopwatch StartStopwatch(this IScheduler scheduler)
	{
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		IStopwatchProvider stopwatchProvider = scheduler.AsStopwatchProvider();
		if (stopwatchProvider != null)
		{
			return stopwatchProvider.StartStopwatch();
		}
		return new EmulatedStopwatch(scheduler);
	}

	private static IDisposable SchedulePeriodic_<TState>(IScheduler scheduler, TState state, TimeSpan period, Func<TState, TState> action)
	{
		ISchedulerPeriodic schedulerPeriodic = scheduler.AsPeriodic();
		if (schedulerPeriodic != null)
		{
			return schedulerPeriodic.SchedulePeriodic(state, period, action);
		}
		IStopwatchProvider stopwatchProvider = scheduler.AsStopwatchProvider();
		if (stopwatchProvider != null)
		{
			return new SchedulePeriodicStopwatch<TState>(scheduler, state, period, action, stopwatchProvider).Start();
		}
		return new SchedulePeriodicRecursive<TState>(scheduler, state, period, action).Start();
	}

	public static IDisposable Schedule(this IScheduler scheduler, Action action)
	{
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return scheduler.Schedule(action, (IScheduler _, Action a) => Invoke(a));
	}

	internal static IDisposable ScheduleAction<TState>(this IScheduler scheduler, TState state, Action<TState> action)
	{
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return scheduler.Schedule((action, state), delegate(IScheduler _, (Action<TState> action, TState state) tuple)
		{
			tuple.action(tuple.state);
			return Disposable.Empty;
		});
	}

	internal static IDisposable ScheduleAction<TState>(this IScheduler scheduler, TState state, Func<TState, IDisposable> action)
	{
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return scheduler.Schedule((action, state), (IScheduler _, (Func<TState, IDisposable> action, TState state) tuple) => tuple.action(tuple.state));
	}

	internal static IDisposable ScheduleAction<TState>(this IScheduler scheduler, TState state, TimeSpan dueTime, Action<TState> action)
	{
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return scheduler.Schedule((state, action), dueTime, (IScheduler _, (TState state, Action<TState> action) tuple) => Invoke(tuple));
	}

	private static IDisposable Invoke(Action action)
	{
		action();
		return Disposable.Empty;
	}

	private static IDisposable Invoke<TState>((TState state, Action<TState> action) tuple)
	{
		tuple.action(tuple.state);
		return Disposable.Empty;
	}
}
