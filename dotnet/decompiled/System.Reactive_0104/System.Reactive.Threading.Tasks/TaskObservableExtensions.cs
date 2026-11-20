using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq.ObservableImpl;
using System.Threading;
using System.Threading.Tasks;

namespace System.Reactive.Threading.Tasks;

public static class TaskObservableExtensions
{
	private sealed class SlowTaskObservable : IObservable<Unit>
	{
		private readonly Task _task;

		private readonly IScheduler? _scheduler;

		private readonly bool _ignoreExceptionsAfterUnsubscribe;

		public SlowTaskObservable(Task task, IScheduler? scheduler, bool ignoreExceptionsAfterUnsubscribe)
		{
			_task = task;
			_scheduler = scheduler;
			_ignoreExceptionsAfterUnsubscribe = ignoreExceptionsAfterUnsubscribe;
		}

		public IDisposable Subscribe(IObserver<Unit> observer)
		{
			if (observer == null)
			{
				throw new ArgumentNullException("observer");
			}
			CancellationDisposable cancellationDisposable = new CancellationDisposable();
			TaskContinuationOptions taskContinuationOptions = GetTaskContinuationOptions(_scheduler);
			if (_scheduler == null)
			{
				_task.ContinueWith(delegate(Task t, object? subjectObject)
				{
					t.EmitTaskResult((IObserver<Unit>)subjectObject);
				}, observer, cancellationDisposable.Token, taskContinuationOptions, TaskScheduler.Current);
			}
			else
			{
				_task.ContinueWithState(delegate(Task task, (IScheduler scheduler, IObserver<Unit> observer) tuple)
				{
					tuple.scheduler.ScheduleAction((task, tuple.observer), delegate((Task task, IObserver<Unit> observer) tuple2)
					{
						tuple2.task.EmitTaskResult(tuple2.observer);
					});
				}, (_scheduler, observer), taskContinuationOptions, cancellationDisposable.Token);
			}
			if (_ignoreExceptionsAfterUnsubscribe)
			{
				_task.ContinueWith((Task t) => t.Exception, TaskContinuationOptions.OnlyOnFaulted);
			}
			return cancellationDisposable;
		}
	}

	private sealed class SlowTaskObservable<TResult> : IObservable<TResult>
	{
		private readonly Task<TResult> _task;

		private readonly IScheduler? _scheduler;

		private readonly bool _ignoreExceptionsAfterUnsubscribe;

		public SlowTaskObservable(Task<TResult> task, IScheduler? scheduler, bool ignoreExceptionsAfterUnsubscribe)
		{
			_task = task;
			_scheduler = scheduler;
			_ignoreExceptionsAfterUnsubscribe = ignoreExceptionsAfterUnsubscribe;
		}

		public IDisposable Subscribe(IObserver<TResult> observer)
		{
			if (observer == null)
			{
				throw new ArgumentNullException("observer");
			}
			CancellationDisposable cancellationDisposable = new CancellationDisposable();
			TaskContinuationOptions taskContinuationOptions = GetTaskContinuationOptions(_scheduler);
			if (_scheduler == null)
			{
				_task.ContinueWith(delegate(Task<TResult> t, object? subjectObject)
				{
					t.EmitTaskResult((IObserver<TResult>)subjectObject);
				}, observer, cancellationDisposable.Token, taskContinuationOptions, TaskScheduler.Current);
			}
			else
			{
				_task.ContinueWithState(delegate(Task<TResult> task, (IScheduler scheduler, IObserver<TResult> observer) tuple)
				{
					tuple.scheduler.ScheduleAction((task, tuple.observer), delegate((Task<TResult> task, IObserver<TResult> observer) tuple2)
					{
						tuple2.task.EmitTaskResult(tuple2.observer);
					});
				}, (_scheduler, observer), taskContinuationOptions, cancellationDisposable.Token);
			}
			if (_ignoreExceptionsAfterUnsubscribe)
			{
				_task.ContinueWith((Task<TResult> t) => t.Exception, TaskContinuationOptions.OnlyOnFaulted);
			}
			return cancellationDisposable;
		}
	}

	private sealed class ToTaskObserver<TResult> : SafeObserver<TResult>
	{
		private readonly CancellationToken _ct;

		private readonly TaskCompletionSource<TResult> _tcs;

		private readonly CancellationTokenRegistration _ctr;

		private bool _hasValue;

		private TResult? _lastValue;

		public ToTaskObserver(TaskCompletionSource<TResult> tcs, CancellationToken ct)
		{
			_ct = ct;
			_tcs = tcs;
			if (ct.CanBeCanceled)
			{
				_ctr = ct.Register(delegate(object? @this)
				{
					((ToTaskObserver<TResult>)@this).Cancel();
				}, this);
			}
		}

		public override void OnNext(TResult value)
		{
			_hasValue = true;
			_lastValue = value;
		}

		public override void OnError(Exception error)
		{
			_tcs.TrySetException(error);
			_ctr.Dispose();
			Dispose();
		}

		public override void OnCompleted()
		{
			if (_hasValue)
			{
				_tcs.TrySetResult(_lastValue);
			}
			else
			{
				try
				{
					throw new InvalidOperationException(Strings_Linq.NO_ELEMENTS);
				}
				catch (Exception exception)
				{
					_tcs.TrySetException(exception);
				}
			}
			_ctr.Dispose();
			Dispose();
		}

		private void Cancel()
		{
			Dispose();
			_tcs.TrySetCanceled(_ct);
		}
	}

	public static IObservable<Unit> ToObservable(this Task task)
	{
		if (task == null)
		{
			throw new ArgumentNullException("task");
		}
		return ToObservableImpl(task, null, ignoreExceptionsAfterUnsubscribe: false);
	}

	internal static IObservable<Unit> ToObservable(this Task task, TaskObservationOptions.Value options)
	{
		if (task == null)
		{
			throw new ArgumentNullException("task");
		}
		return ToObservableImpl(task, options.Scheduler, options.IgnoreExceptionsAfterUnsubscribe);
	}

	private static IObservable<Unit> ToObservableImpl(Task task, IScheduler? scheduler, bool ignoreExceptionsAfterUnsubscribe)
	{
		if (task.IsCompleted)
		{
			if (scheduler == null)
			{
				scheduler = ImmediateScheduler.Instance;
			}
			return task.Status switch
			{
				TaskStatus.Faulted => new Throw<Unit>(task.GetSingleException(), scheduler), 
				TaskStatus.Canceled => new Throw<Unit>(new TaskCanceledException(task), scheduler), 
				_ => new Return<Unit>(Unit.Default, scheduler), 
			};
		}
		return new SlowTaskObservable(task, scheduler, ignoreExceptionsAfterUnsubscribe);
	}

	private static void EmitTaskResult(this Task task, IObserver<Unit> subject)
	{
		switch (task.Status)
		{
		case TaskStatus.RanToCompletion:
			subject.OnNext(Unit.Default);
			subject.OnCompleted();
			break;
		case TaskStatus.Faulted:
			subject.OnError(task.GetSingleException());
			break;
		case TaskStatus.Canceled:
			subject.OnError(new TaskCanceledException(task));
			break;
		}
	}

	public static IObservable<TResult> ToObservable<TResult>(this Task<TResult> task)
	{
		if (task == null)
		{
			throw new ArgumentNullException("task");
		}
		return ToObservableImpl(task, null, ignoreExceptionsAfterUnsubscribe: false);
	}

	internal static IObservable<TResult> ToObservable<TResult>(this Task<TResult> task, TaskObservationOptions.Value options)
	{
		if (task == null)
		{
			throw new ArgumentNullException("task");
		}
		return ToObservableImpl(task, options.Scheduler, options.IgnoreExceptionsAfterUnsubscribe);
	}

	private static IObservable<TResult> ToObservableImpl<TResult>(Task<TResult> task, IScheduler? scheduler, bool ignoreExceptionsAfterUnsubscribe)
	{
		if (task.IsCompleted)
		{
			if (scheduler == null)
			{
				scheduler = ImmediateScheduler.Instance;
			}
			return task.Status switch
			{
				TaskStatus.Faulted => new Throw<TResult>(task.GetSingleException(), scheduler), 
				TaskStatus.Canceled => new Throw<TResult>(new TaskCanceledException(task), scheduler), 
				_ => new Return<TResult>(task.Result, scheduler), 
			};
		}
		return new SlowTaskObservable<TResult>(task, scheduler, ignoreExceptionsAfterUnsubscribe);
	}

	private static void EmitTaskResult<TResult>(this Task<TResult> task, IObserver<TResult> subject)
	{
		switch (task.Status)
		{
		case TaskStatus.RanToCompletion:
			subject.OnNext(task.Result);
			subject.OnCompleted();
			break;
		case TaskStatus.Faulted:
			subject.OnError(task.GetSingleException());
			break;
		case TaskStatus.Canceled:
			subject.OnError(new TaskCanceledException(task));
			break;
		}
	}

	private static TaskContinuationOptions GetTaskContinuationOptions(IScheduler? scheduler)
	{
		TaskContinuationOptions taskContinuationOptions = TaskContinuationOptions.None;
		if (scheduler != null)
		{
			taskContinuationOptions |= TaskContinuationOptions.ExecuteSynchronously;
		}
		return taskContinuationOptions;
	}

	public static Task<TResult> ToTask<TResult>(this IObservable<TResult> observable)
	{
		if (observable == null)
		{
			throw new ArgumentNullException("observable");
		}
		return observable.ToTask(default(CancellationToken), null);
	}

	public static Task<TResult> ToTask<TResult>(this IObservable<TResult> observable, CancellationToken cancellationToken, object? state)
	{
		if (observable == null)
		{
			throw new ArgumentNullException("observable");
		}
		TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>(state);
		ToTaskObserver<TResult> toTaskObserver = new ToTaskObserver<TResult>(taskCompletionSource, cancellationToken);
		try
		{
			toTaskObserver.SetResource(observable.Subscribe(toTaskObserver));
		}
		catch (Exception exception)
		{
			taskCompletionSource.TrySetException(exception);
		}
		return taskCompletionSource.Task;
	}
}
