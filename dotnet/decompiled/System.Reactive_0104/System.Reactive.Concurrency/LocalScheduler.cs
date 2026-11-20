using System.Collections.Generic;
using System.Reactive.PlatformServices;
using System.Runtime.CompilerServices;

namespace System.Reactive.Concurrency;

public abstract class LocalScheduler : IScheduler, IStopwatchProvider, IServiceProvider
{
	private abstract class WorkItem : IComparable<WorkItem>, IDisposable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int CompareTo(WorkItem? other)
		{
			throw new NotSupportedException("Linked away");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Dispose()
		{
			throw new NotSupportedException("Linked away");
		}
	}

	private readonly PriorityQueue<WorkItem> _shortTerm = new PriorityQueue<WorkItem>();

	private readonly HashSet<IDisposable> _shortTermWork = new HashSet<IDisposable>();

	public virtual DateTimeOffset Now => Scheduler.Now;

	public virtual IDisposable Schedule<TState>(TState state, Func<IScheduler, TState, IDisposable> action)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return Schedule(state, TimeSpan.Zero, action);
	}

	public abstract IDisposable Schedule<TState>(TState state, TimeSpan dueTime, Func<IScheduler, TState, IDisposable> action);

	public virtual IStopwatch StartStopwatch()
	{
		return ConcurrencyAbstractionLayer.Current.StartStopwatch();
	}

	object? IServiceProvider.GetService(Type serviceType)
	{
		return GetService(serviceType);
	}

	protected virtual object? GetService(Type serviceType)
	{
		if (serviceType == typeof(IStopwatchProvider))
		{
			return this;
		}
		if (serviceType == typeof(ISchedulerLongRunning))
		{
			return this as ISchedulerLongRunning;
		}
		if (serviceType == typeof(ISchedulerPeriodic))
		{
			return this as ISchedulerPeriodic;
		}
		return null;
	}

	protected LocalScheduler()
	{
		SystemClock.Register(this);
	}
}
