using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.Targets.Wrappers;

namespace NLog.Targets;

public abstract class AsyncTaskTarget : TargetWithContext
{
	private readonly Timer _taskTimeoutTimer;

	private CancellationTokenSource _cancelTokenSource;

	private AsyncRequestQueueBase _requestQueue;

	private readonly Action _taskCancelledTokenReInit;

	private readonly Action<Task, object> _taskCompletion;

	private Task? _previousTask;

	private readonly Timer _lazyWriterTimer;

	private readonly LogEventInfo _flushEvent = LogEventInfo.Create(LogLevel.Off, null, "NLog Async Task Flush Event");

	private readonly ReusableAsyncLogEventList _reusableAsyncLogEventList = new ReusableAsyncLogEventList(200);

	private Tuple<List<LogEventInfo>, List<AsyncContinuation>>? _reusableLogEvents;

	private WaitCallback? _flushEventsInQueueDelegate;

	private bool _missingServiceTypes;

	private int? _retryDelayMilliseconds;

	private bool? _forceLockingQueue;

	public int TaskDelayMilliseconds { get; set; } = 1;

	public int TaskTimeoutSeconds { get; set; } = 150;

	public int RetryCount { get; set; }

	public int RetryDelayMilliseconds
	{
		get
		{
			int? retryDelayMilliseconds = _retryDelayMilliseconds;
			if (!retryDelayMilliseconds.HasValue)
			{
				if (RetryCount <= 0 && OverflowAction == AsyncTargetWrapperOverflowAction.Discard)
				{
					return 50;
				}
				return 500;
			}
			return retryDelayMilliseconds.GetValueOrDefault();
		}
		set
		{
			_retryDelayMilliseconds = value;
		}
	}

	public bool ForceLockingQueue
	{
		get
		{
			return _forceLockingQueue == true;
		}
		set
		{
			_forceLockingQueue = value;
		}
	}

	public AsyncTargetWrapperOverflowAction OverflowAction
	{
		get
		{
			return _requestQueue.OnOverflow;
		}
		set
		{
			_requestQueue.OnOverflow = value;
		}
	}

	public int QueueLimit
	{
		get
		{
			return _requestQueue.QueueLimit;
		}
		set
		{
			_requestQueue.QueueLimit = value;
		}
	}

	public int BatchSize { get; set; } = 1;

	protected virtual TaskScheduler TaskScheduler => System.Threading.Tasks.TaskScheduler.Default;

	protected AsyncTaskTarget()
	{
		_taskCompletion = TaskCompletion;
		_taskCancelledTokenReInit = delegate
		{
			TaskCancelledTokenReInit(out CancellationTokenSource _);
		};
		_taskTimeoutTimer = new Timer(TaskTimeout, null, -1, -1);
		_requestQueue = new ConcurrentRequestQueue(10000, AsyncTargetWrapperOverflowAction.Discard);
		_lazyWriterTimer = new Timer(delegate
		{
			TaskStartNext(null, fullBatchCompleted: false);
		}, null, -1, -1);
		TaskCancelledTokenReInit(out _cancelTokenSource);
	}

	protected override void InitializeTarget()
	{
		_missingServiceTypes = false;
		TaskCancelledTokenReInit(out CancellationTokenSource _);
		base.InitializeTarget();
		if (BatchSize <= 0)
		{
			BatchSize = 1;
		}
		if (!ForceLockingQueue && OverflowAction == AsyncTargetWrapperOverflowAction.Block && (decimal)BatchSize * 1.5m > (decimal)QueueLimit)
		{
			ForceLockingQueue = true;
		}
		if (_forceLockingQueue.HasValue && _forceLockingQueue.Value != _requestQueue is AsyncRequestQueue)
		{
			_requestQueue = (ForceLockingQueue ? ((AsyncRequestQueueBase)new AsyncRequestQueue(QueueLimit, OverflowAction)) : ((AsyncRequestQueueBase)new ConcurrentRequestQueue(QueueLimit, OverflowAction)));
		}
		if (BatchSize > QueueLimit)
		{
			BatchSize = QueueLimit;
		}
	}

	protected abstract Task WriteAsyncTask(LogEventInfo logEvent, CancellationToken cancellationToken);

	protected virtual Task WriteAsyncTask(IList<LogEventInfo> logEvents, CancellationToken cancellationToken)
	{
		if (logEvents.Count == 1)
		{
			return WriteAsyncTask(logEvents[0], cancellationToken);
		}
		Task task = null;
		for (int i = 0; i < logEvents.Count; i++)
		{
			LogEventInfo logEvent = logEvents[i];
			task = ((task != null) ? task.ContinueWith((Task t) => WriteAsyncTask(logEvent, cancellationToken), cancellationToken, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler).Unwrap() : WriteAsyncTask(logEvent, cancellationToken));
		}
		return task ?? Task.CompletedTask;
	}

	protected virtual bool RetryFailedAsyncTask(Exception exception, CancellationToken cancellationToken, int retryCountRemaining, out TimeSpan retryDelay)
	{
		if (cancellationToken.IsCancellationRequested || retryCountRemaining < 0)
		{
			retryDelay = TimeSpan.Zero;
			return false;
		}
		retryDelay = TimeSpan.FromMilliseconds((double)RetryDelayMilliseconds * Math.Pow(2.0, RetryCount - (1 + retryCountRemaining)));
		return true;
	}

	protected sealed override void Write(LogEventInfo logEvent)
	{
		base.Write(logEvent);
	}

	protected sealed override void Write(IList<AsyncLogEventInfo> logEvents)
	{
		base.Write(logEvents);
	}

	protected sealed override void Write(AsyncLogEventInfo logEvent)
	{
		if (_cancelTokenSource.IsCancellationRequested)
		{
			logEvent.Continuation(null);
			return;
		}
		PrecalculateVolatileLayouts(logEvent.LogEvent);
		if (!_requestQueue.Enqueue(logEvent))
		{
			return;
		}
		bool lockTaken = false;
		try
		{
			if (_previousTask == null)
			{
				Monitor.Enter(base.SyncRoot, ref lockTaken);
			}
			else
			{
				Monitor.TryEnter(base.SyncRoot, 50, ref lockTaken);
			}
			if (_previousTask == null)
			{
				_lazyWriterTimer.Change(TaskDelayMilliseconds, -1);
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(base.SyncRoot);
			}
		}
	}

	protected sealed override void WriteAsyncThreadSafe(AsyncLogEventInfo logEvent)
	{
		try
		{
			Write(logEvent);
		}
		catch (Exception exception)
		{
			if (ExceptionMustBeRethrown(exception, "WriteAsyncThreadSafe"))
			{
				throw;
			}
			logEvent.Continuation(exception);
		}
	}

	protected sealed override void WriteAsyncThreadSafe(IList<AsyncLogEventInfo> logEvents)
	{
		base.WriteAsyncThreadSafe(logEvents);
	}

	protected override void WriteFailedNotInitialized(AsyncLogEventInfo logEvent, Exception initializeException)
	{
		if (initializeException is NLogDependencyResolveException && OverflowAction == AsyncTargetWrapperOverflowAction.Discard)
		{
			_missingServiceTypes = true;
			Write(logEvent);
		}
		else
		{
			base.WriteFailedNotInitialized(logEvent, initializeException);
		}
	}

	protected override void FlushAsync(AsyncContinuation asyncContinuation)
	{
		Task? previousTask = _previousTask;
		if ((previousTask != null && !previousTask.IsCompleted) || !_requestQueue.IsEmpty)
		{
			InternalLogger.Debug("{0}: Flushing {1}", this, _requestQueue.IsEmpty ? "empty queue" : "pending queue items");
			if (_requestQueue.OnOverflow != AsyncTargetWrapperOverflowAction.Block)
			{
				_requestQueue.Enqueue(new AsyncLogEventInfo(_flushEvent, asyncContinuation));
				_lazyWriterTimer.Change(0, -1);
				return;
			}
			if (_flushEventsInQueueDelegate == null)
			{
				_flushEventsInQueueDelegate = delegate(object cont)
				{
					_requestQueue.Enqueue(new AsyncLogEventInfo(_flushEvent, (AsyncContinuation)cont));
					lock (base.SyncRoot)
					{
						_lazyWriterTimer.Change(0, -1);
					}
				};
			}
			AsyncHelpers.StartAsyncTask(_flushEventsInQueueDelegate, asyncContinuation);
			_lazyWriterTimer.Change(0, -1);
		}
		else
		{
			InternalLogger.Debug("{0}: Flushing Nothing", this);
			asyncContinuation(null);
		}
	}

	protected override void CloseTarget()
	{
		_taskTimeoutTimer.Change(-1, -1);
		_cancelTokenSource.Cancel();
		_requestQueue.Clear();
		_previousTask = null;
		base.CloseTarget();
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (disposing)
		{
			_cancelTokenSource.Dispose();
			_taskTimeoutTimer.WaitForDispose(TimeSpan.Zero);
			_lazyWriterTimer.WaitForDispose(TimeSpan.Zero);
		}
	}

	private void TaskStartNext(object? previousTask, bool fullBatchCompleted)
	{
		do
		{
			lock (base.SyncRoot)
			{
				if (CheckOtherTask(previousTask))
				{
					break;
				}
				if (_missingServiceTypes)
				{
					_previousTask = null;
					_lazyWriterTimer.Change(50, -1);
					break;
				}
				if (!base.IsInitialized)
				{
					_previousTask = null;
					break;
				}
				if (previousTask != null && !fullBatchCompleted && TaskDelayMilliseconds >= 50 && !_requestQueue.IsEmpty)
				{
					InternalLogger.Trace("{0}: Throttle to optimize batching", this);
					_previousTask = null;
					_lazyWriterTimer.Change(TaskDelayMilliseconds, -1);
					break;
				}
				ReusableObjectCreator<IList<AsyncLogEventInfo>>.LockOject lockOject = _reusableAsyncLogEventList.Allocate();
				try
				{
					IList<AsyncLogEventInfo> result = lockOject.Result;
					_requestQueue.DequeueBatch(BatchSize, result);
					if (result.Count > 0)
					{
						if (TaskCreation(result))
						{
							break;
						}
						continue;
					}
					_previousTask = null;
					break;
				}
				finally
				{
					((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
				}
			}
		}
		while (!_requestQueue.IsEmpty || previousTask != null);
	}

	private bool CheckOtherTask(object? previousTask)
	{
		if (previousTask == null)
		{
			Task? previousTask2 = _previousTask;
			if (previousTask2 != null && !previousTask2.IsCompleted)
			{
				return true;
			}
		}
		else if (_previousTask != null && previousTask != _previousTask)
		{
			return true;
		}
		return false;
	}

	internal Task WriteAsyncTaskWithRetry(Task firstTask, IList<LogEventInfo> logEvents, CancellationToken cancellationToken, int retryCount)
	{
		TaskCompletionSource<object?> tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
		return firstTask.ContinueWith(delegate(Task t)
		{
			if (t.IsFaulted || t.IsCanceled)
			{
				if (t.Exception != null)
				{
					tcs.TrySetException(t.Exception);
				}
				Exception ex = ExtractActualException(t.Exception) ?? new TaskCanceledException("Task failed without exception");
				if (RetryFailedAsyncTask(ex, cancellationToken, retryCount - 1, out var retryDelay))
				{
					InternalLogger.Warn(ex, "{0}: Write operation failed. {1} attempts left. Sleep {2} ms", new ReadOnlySpan<object>(new object[3] { this, retryCount, retryDelay.TotalMilliseconds }));
					AsyncHelpers.WaitForDelay(retryDelay);
					if (!cancellationToken.IsCancellationRequested)
					{
						Task task;
						lock (base.SyncRoot)
						{
							task = StartWriteAsyncTask(logEvents, cancellationToken);
						}
						if (task != null)
						{
							return WriteAsyncTaskWithRetry(task, logEvents, cancellationToken, retryCount - 1);
						}
					}
				}
				InternalLogger.Warn(ex, "{0}: Write operation failed after {1} retries", new ReadOnlySpan<object>(new object[2]
				{
					this,
					RetryCount - retryCount
				}));
			}
			else
			{
				tcs.SetResult(null);
			}
			return tcs.Task;
		}, cancellationToken, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler).Unwrap();
	}

	private bool TaskCreation(IList<AsyncLogEventInfo> logEvents)
	{
		Tuple<List<LogEventInfo>, List<AsyncContinuation>> tuple = null;
		try
		{
			if (_cancelTokenSource.IsCancellationRequested)
			{
				for (int i = 0; i < logEvents.Count; i++)
				{
					logEvents[i].Continuation(null);
				}
				return false;
			}
			tuple = Interlocked.CompareExchange(ref _reusableLogEvents, null, _reusableLogEvents) ?? Tuple.Create(new List<LogEventInfo>(), new List<AsyncContinuation>());
			for (int j = 0; j < logEvents.Count; j++)
			{
				if (logEvents[j].LogEvent == _flushEvent)
				{
					tuple.Item2.Add(logEvents[j].Continuation);
					continue;
				}
				tuple.Item1.Add(logEvents[j].LogEvent);
				tuple.Item2.Add(logEvents[j].Continuation);
			}
			if (tuple.Item1.Count == 0)
			{
				NotifyTaskCompletion(tuple.Item2, null);
				tuple.Item2.Clear();
				Interlocked.CompareExchange(ref _reusableLogEvents, tuple, null);
				InternalLogger.Debug("{0}: Flush Completed", this);
				return false;
			}
			Task task = StartWriteAsyncTask(tuple.Item1, _cancelTokenSource.Token);
			if (task == null)
			{
				InternalLogger.Debug("{0}: WriteAsyncTask returned null", this);
				NotifyTaskCompletion(tuple.Item2, null);
				return false;
			}
			if (RetryCount > 0)
			{
				task = WriteAsyncTaskWithRetry(task, tuple.Item1, _cancelTokenSource.Token, RetryCount);
			}
			_previousTask = task;
			if (TaskTimeoutSeconds > 0)
			{
				_taskTimeoutTimer.Change(TaskTimeoutSeconds * 1000, -1);
			}
			task.ContinueWith(_taskCompletion, tuple, TaskScheduler);
			return true;
		}
		catch (Exception ex)
		{
			_previousTask = null;
			InternalLogger.Error(ex, "{0}: WriteAsyncTask failed on creation", new ReadOnlySpan<object>(new object[1] { this }));
			IList<AsyncContinuation> list = tuple?.Item2;
			NotifyTaskCompletion(list ?? ArrayHelper.Empty<AsyncContinuation>(), ex);
		}
		return false;
	}

	private Task StartWriteAsyncTask(IList<LogEventInfo> logEvents, CancellationToken cancellationToken)
	{
		try
		{
			InternalLogger.Trace("{0}: Writing {1} events", this, logEvents.Count);
			Task task = WriteAsyncTask(logEvents, cancellationToken);
			if (task == null)
			{
				return Task.CompletedTask;
			}
			if (task.Status == TaskStatus.Created)
			{
				task.Start(TaskScheduler);
			}
			return task;
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "{0}: WriteAsyncTask failed on creation", new ReadOnlySpan<object>(new object[1] { this }));
			return Task.FromException(ex);
		}
	}

	private static void NotifyTaskCompletion(IList<AsyncContinuation> reusableContinuations, Exception? ex)
	{
		try
		{
			for (int i = 0; i < reusableContinuations.Count; i++)
			{
				reusableContinuations[i](ex);
			}
		}
		catch
		{
		}
	}

	private void TaskCompletion(Task completedTask, object continuation)
	{
		bool flag = true;
		bool fullBatchCompleted = true;
		TimeSpan retryDelay = TimeSpan.Zero;
		try
		{
			if (completedTask == _previousTask)
			{
				if (TaskTimeoutSeconds > 0)
				{
					_taskTimeoutTimer.Change(-1, -1);
				}
			}
			else
			{
				flag = false;
				if (!base.IsInitialized)
				{
					return;
				}
			}
			Exception ex = ExtractActualException(completedTask.Exception);
			if (completedTask.IsCanceled)
			{
				flag = false;
				if (completedTask.Exception != null)
				{
					InternalLogger.Warn(completedTask.Exception, "{0}: WriteAsyncTask was cancelled", new ReadOnlySpan<object>(new object[1] { this }));
				}
				else
				{
					InternalLogger.Info("{0}: WriteAsyncTask was cancelled", this);
				}
			}
			else if (ex != null)
			{
				flag = false;
				if (RetryCount <= 0)
				{
					if (RetryFailedAsyncTask(ex, CancellationToken.None, 0, out retryDelay))
					{
						InternalLogger.Warn(ex, "{0}: WriteAsyncTask failed on completion. Delay {1} ms", new ReadOnlySpan<object>(new object[2] { this, retryDelay.TotalMilliseconds }));
					}
				}
				else
				{
					InternalLogger.Warn(ex, "{0}: WriteAsyncTask failed on completion", new ReadOnlySpan<object>(new object[1] { this }));
				}
			}
			Tuple<List<LogEventInfo>, List<AsyncContinuation>> tuple = continuation as Tuple<List<LogEventInfo>, List<AsyncContinuation>>;
			if (tuple != null)
			{
				NotifyTaskCompletion(tuple.Item2, ex);
			}
			else
			{
				flag = false;
			}
			if (flag && tuple != null)
			{
				fullBatchCompleted = tuple.Item2.Count * 2 > BatchSize;
				tuple.Item1.Clear();
				tuple.Item2.Clear();
				Interlocked.CompareExchange(ref _reusableLogEvents, tuple, null);
			}
		}
		finally
		{
			if (retryDelay > TimeSpan.Zero)
			{
				_lazyWriterTimer.Change((int)retryDelay.TotalMilliseconds, -1);
			}
			else
			{
				TaskStartNext(completedTask, fullBatchCompleted);
			}
		}
	}

	private void TaskTimeout(object state)
	{
		try
		{
			if (!base.IsInitialized)
			{
				return;
			}
			InternalLogger.Warn("{0}: WriteAsyncTask had timeout. Task will be cancelled.", this);
			Task task = _previousTask;
			try
			{
				lock (base.SyncRoot)
				{
					if (task != null && task == _previousTask)
					{
						_previousTask = null;
						_cancelTokenSource.Cancel();
					}
					else
					{
						task = null;
					}
				}
				if (task != null)
				{
					if (!WaitTaskIsCompleted(task, TimeSpan.FromSeconds((double)TaskTimeoutSeconds / 10.0)))
					{
						InternalLogger.Debug("{0}: WriteAsyncTask had timeout. Task did not cancel properly: {1}.", this, task.Status);
					}
					Exception ex = ExtractActualException(task.Exception);
					RetryFailedAsyncTask(ex ?? new TimeoutException("WriteAsyncTask had timeout"), CancellationToken.None, 0, out var _);
				}
			}
			catch (Exception ex2)
			{
				InternalLogger.Debug(ex2, "{0}: WriteAsyncTask had timeout. Task failed to cancel properly.", new ReadOnlySpan<object>(new object[1] { this }));
			}
			TaskStartNext(null, fullBatchCompleted: false);
		}
		catch (Exception ex3)
		{
			InternalLogger.Error(ex3, "{0}: WriteAsyncTask failed on timeout", new ReadOnlySpan<object>(new object[1] { this }));
		}
	}

	private static bool WaitTaskIsCompleted(Task task, TimeSpan timeout)
	{
		while (!task.IsCompleted && timeout > TimeSpan.Zero)
		{
			timeout -= TimeSpan.FromMilliseconds(10.0);
			AsyncHelpers.WaitForDelay(TimeSpan.FromMilliseconds(10.0));
		}
		return task.IsCompleted;
	}

	private static Exception? ExtractActualException(AggregateException? taskException)
	{
		if (taskException != null && taskException.InnerExceptions?.Count == 1 && !(taskException.InnerExceptions[0] is AggregateException))
		{
			return taskException.InnerExceptions[0];
		}
		ReadOnlyCollection<Exception> readOnlyCollection = taskException?.Flatten()?.InnerExceptions;
		if (readOnlyCollection == null || readOnlyCollection.Count != 1)
		{
			return taskException;
		}
		return readOnlyCollection[0];
	}

	private void TaskCancelledTokenReInit(out CancellationTokenSource cancelTokenSource)
	{
		_cancelTokenSource = (cancelTokenSource = new CancellationTokenSource());
		_cancelTokenSource.Token.Register(_taskCancelledTokenReInit);
	}
}
