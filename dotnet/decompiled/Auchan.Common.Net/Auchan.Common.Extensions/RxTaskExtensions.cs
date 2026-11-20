using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auchan.Common.Extensions;

public static class RxTaskExtensions
{
	public static IObservable<Unit> PerformSamplingTask<T>(this IObservable<T> source, Func<T, Task> onNextAsync, IScheduler? scheduler = null)
	{
		if (onNextAsync == null)
		{
			throw new ArgumentNullException("onNextAsync");
		}
		if (scheduler == null)
		{
			scheduler = CurrentContextScheduler();
		}
		Func<Task> nextTask = null;
		return (from _ in source.Where(delegate(T x)
			{
				bool result = nextTask == null;
				nextTask = delegate
				{
					nextTask = null;
					return onNextAsync(x);
				};
				return result;
			})
			select Observable.FromAsync(() => nextTask?.Invoke(), scheduler)).Concat();
	}

	public static IObservable<Unit> PerformSamplingTask<T>(this IObservable<T> source, Func<Task> onNextAsync, IScheduler? scheduler = null)
	{
		return source.PerformSamplingTask((T _) => onNextAsync(), scheduler);
	}

	public static IObservable<TResult> PerformSamplingTask<T, TResult>(this IObservable<T> source, Func<T, Task<TResult>> onNextAsync, IScheduler? scheduler = null)
	{
		if (onNextAsync == null)
		{
			throw new ArgumentNullException("onNextAsync");
		}
		if (scheduler == null)
		{
			scheduler = CurrentContextScheduler();
		}
		Func<Task<TResult>> nextTask = null;
		return (from _ in source.Where(delegate(T x)
			{
				bool result = nextTask == null;
				nextTask = delegate
				{
					nextTask = null;
					return onNextAsync(x);
				};
				return result;
			})
			select Observable.FromAsync(nextTask, scheduler)).Concat();
	}

	public static IObservable<TResult> PerformSamplingTask<T, TResult>(this IObservable<T> source, Func<Task<TResult>> onNextAsync, IScheduler? scheduler = null)
	{
		return source.PerformSamplingTask((T _) => onNextAsync(), scheduler);
	}

	public static IObservable<Unit> PerformDebouncingTask<T>(this IObservable<T> source, Func<T, Task> onNextAsync, IScheduler? scheduler = null)
	{
		if (onNextAsync == null)
		{
			throw new ArgumentNullException("onNextAsync");
		}
		if (scheduler == null)
		{
			scheduler = CurrentContextScheduler();
		}
		IObservable<Unit> activeTaskObservable = null;
		return (from x in source
			where activeTaskObservable == null
			select activeTaskObservable = Observable.FromAsync(() => onNextAsync(x), scheduler).Finally(delegate
			{
				activeTaskObservable = null;
			})).Concat();
	}

	public static IObservable<Unit> PerformDebouncingTask<T>(this IObservable<T> source, Func<Task> onNextAsync, IScheduler? scheduler = null)
	{
		return source.PerformDebouncingTask((T _) => onNextAsync(), scheduler);
	}

	public static IObservable<TResult> PerformDebouncingTask<T, TResult>(this IObservable<T> source, Func<T, Task<TResult>> onNextAsync, IScheduler? scheduler = null)
	{
		if (onNextAsync == null)
		{
			throw new ArgumentNullException("onNextAsync");
		}
		if (scheduler == null)
		{
			scheduler = CurrentContextScheduler();
		}
		IObservable<TResult> activeTaskObservable = null;
		return (from x in source
			where activeTaskObservable == null
			select activeTaskObservable = Observable.FromAsync(() => onNextAsync(x), scheduler).Finally(delegate
			{
				activeTaskObservable = null;
			})).Concat();
	}

	public static IObservable<TResult> PerformDebouncingTask<T, TResult>(this IObservable<T> source, Func<Task<TResult>> onNextAsync, IScheduler? scheduler = null)
	{
		return source.PerformDebouncingTask((T _) => onNextAsync(), scheduler);
	}

	public static IObservable<Unit> PerformTask<T>(this IObservable<T> source, Func<T, Task> onNextAsync, IScheduler? scheduler = null)
	{
		if (onNextAsync == null)
		{
			throw new ArgumentNullException("onNextAsync");
		}
		if (scheduler == null)
		{
			scheduler = CurrentContextScheduler();
		}
		return source.Select((T x) => Observable.FromAsync(() => onNextAsync(x), scheduler)).Concat();
	}

	public static IObservable<Unit> PerformTask<T>(this IObservable<T> source, Func<Task> onNextAsync, IScheduler? scheduler = null)
	{
		return source.PerformTask((T _) => onNextAsync(), scheduler);
	}

	public static IObservable<TResult> PerformTask<T, TResult>(this IObservable<T> source, Func<T, Task<TResult>> onNextAsync, IScheduler? scheduler = null)
	{
		if (onNextAsync == null)
		{
			throw new ArgumentNullException("onNextAsync");
		}
		if (scheduler == null)
		{
			scheduler = CurrentContextScheduler();
		}
		return source.Select((T x) => Observable.FromAsync(() => onNextAsync(x), scheduler)).Concat();
	}

	public static IObservable<TResult> PerformTask<T, TResult>(this IObservable<T> source, Func<Task<TResult>> onNextAsync, IScheduler? scheduler = null)
	{
		return source.PerformTask((T _) => onNextAsync(), scheduler);
	}

	public static IObservable<Unit> PerformTaskConcurrent<T>(this IObservable<T> source, Func<T, Task> onNextAsync, IScheduler? scheduler = null)
	{
		if (onNextAsync == null)
		{
			throw new ArgumentNullException("onNextAsync");
		}
		if (scheduler == null)
		{
			scheduler = CurrentContextScheduler();
		}
		return source.SelectMany((T x) => Observable.FromAsync(() => onNextAsync(x), scheduler));
	}

	public static IObservable<Unit> PerformTaskConcurrent<T>(this IObservable<T> source, Func<Task> onNextAsync, IScheduler? scheduler = null)
	{
		return source.PerformTaskConcurrent((T _) => onNextAsync(), scheduler);
	}

	public static IObservable<TResult> PerformTaskConcurrent<T, TResult>(this IObservable<T> source, Func<T, Task<TResult>> onNextAsync, IScheduler? scheduler = null)
	{
		if (onNextAsync == null)
		{
			throw new ArgumentNullException("onNextAsync");
		}
		if (scheduler == null)
		{
			scheduler = CurrentContextScheduler();
		}
		return source.SelectMany((T x) => Observable.FromAsync(() => onNextAsync(x), scheduler));
	}

	public static IObservable<TResult> PerformTaskConcurrent<T, TResult>(this IObservable<T> source, Func<Task<TResult>> onNextAsync, IScheduler? scheduler = null)
	{
		return source.PerformTaskConcurrent((T _) => onNextAsync(), scheduler);
	}

	public static IObservable<T> StartWithDefault<T>(this IObservable<T> source, uint count = 1u)
	{
		return source.StartWith(new T[count]);
	}

	private static IScheduler CurrentContextScheduler()
	{
		if (SynchronizationContext.Current != null)
		{
			return new SynchronizationContextScheduler(SynchronizationContext.Current);
		}
		return TaskPoolScheduler.Default;
	}
}
