using System;
using System.Collections.Generic;
using System.Threading;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog.Targets.Wrappers;

[Target("AsyncWrapper", IsWrapper = true)]
public class AsyncTargetWrapper : WrapperTargetBase
{
	private readonly object _writeLockObject = new object();

	private readonly object _timerLockObject = new object();

	private Timer? _lazyWriterTimer;

	private readonly ReusableAsyncLogEventList _reusableAsyncLogEventList = new ReusableAsyncLogEventList(200);

	private readonly WaitCallback _flushEventsInQueueDelegate;

	private bool _missingServiceTypes;

	private bool? _forceLockingQueue;

	private AsyncRequestQueueBase _requestQueue;

	public int BatchSize { get; set; } = 200;

	public int TimeToSleepBetweenBatches { get; set; } = 1;

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

	public int FullBatchSizeWriteLimit { get; set; } = 5;

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

	private event EventHandler<LogEventDroppedEventArgs>? _logEventDroppedEvent;

	private event EventHandler<LogEventQueueGrowEventArgs>? _eventQueueGrowEvent;

	public event EventHandler<LogEventDroppedEventArgs> LogEventDropped
	{
		add
		{
			if (this._logEventDroppedEvent == null)
			{
				_requestQueue.LogEventDropped += OnRequestQueueDropItem;
			}
			_logEventDroppedEvent += value;
		}
		remove
		{
			_logEventDroppedEvent -= value;
			if (this._logEventDroppedEvent == null)
			{
				_requestQueue.LogEventDropped -= OnRequestQueueDropItem;
			}
		}
	}

	public event EventHandler<LogEventQueueGrowEventArgs> EventQueueGrow
	{
		add
		{
			if (this._eventQueueGrowEvent == null)
			{
				_requestQueue.LogEventQueueGrow += OnRequestQueueGrow;
			}
			_eventQueueGrowEvent += value;
		}
		remove
		{
			_eventQueueGrowEvent -= value;
			if (this._eventQueueGrowEvent == null)
			{
				_requestQueue.LogEventQueueGrow -= OnRequestQueueGrow;
			}
		}
	}

	public AsyncTargetWrapper()
	{
		_requestQueue = new ConcurrentRequestQueue(10000, AsyncTargetWrapperOverflowAction.Discard);
		_flushEventsInQueueDelegate = FlushEventsInQueue;
	}

	public AsyncTargetWrapper(string name, Target wrappedTarget)
		: this(wrappedTarget)
	{
		base.Name = name ?? base.Name;
	}

	public AsyncTargetWrapper(Target wrappedTarget)
		: this(wrappedTarget, 10000, AsyncTargetWrapperOverflowAction.Discard)
	{
	}

	public AsyncTargetWrapper(Target wrappedTarget, int queueLimit, AsyncTargetWrapperOverflowAction overflowAction)
		: this()
	{
		base.Name = ((wrappedTarget == null || string.IsNullOrEmpty(wrappedTarget.Name)) ? base.Name : (wrappedTarget.Name + "_wrapper"));
		base.WrappedTarget = wrappedTarget;
		QueueLimit = queueLimit;
		OverflowAction = overflowAction;
	}

	protected override void FlushAsync(AsyncContinuation asyncContinuation)
	{
		AsyncHelpers.StartAsyncTask(_flushEventsInQueueDelegate, asyncContinuation);
	}

	protected override void InitializeTarget()
	{
		base.InitializeTarget();
		if (!ForceLockingQueue && OverflowAction == AsyncTargetWrapperOverflowAction.Block && (decimal)BatchSize * 1.5m > (decimal)QueueLimit)
		{
			ForceLockingQueue = true;
		}
		if (_forceLockingQueue.HasValue && _forceLockingQueue.Value != _requestQueue is AsyncRequestQueue)
		{
			_requestQueue = (ForceLockingQueue ? ((AsyncRequestQueueBase)new AsyncRequestQueue(QueueLimit, OverflowAction)) : ((AsyncRequestQueueBase)new ConcurrentRequestQueue(QueueLimit, OverflowAction)));
		}
		if (BatchSize > QueueLimit && TimeToSleepBetweenBatches <= 1)
		{
			BatchSize = QueueLimit;
		}
		_layoutWithLock = _layoutWithLock ?? base.WrappedTarget?._layoutWithLock;
		if (base.WrappedTarget != null && base.WrappedTarget.InitializeException is NLogDependencyResolveException && OverflowAction == AsyncTargetWrapperOverflowAction.Discard)
		{
			_missingServiceTypes = true;
			InternalLogger.Debug("{0} WrappedTarget has unresolved missing dependencies.", this);
		}
		_requestQueue.Clear();
		InternalLogger.Trace("{0}: Start Timer", this);
		_lazyWriterTimer = new Timer(ProcessPendingEvents, null, -1, -1);
		StartLazyWriterTimer();
	}

	protected override void CloseTarget()
	{
		StopLazyWriterThread();
		int millisecondsTimeout = ((OverflowAction == AsyncTargetWrapperOverflowAction.Discard) ? 500 : 1500);
		if (Monitor.TryEnter(_writeLockObject, millisecondsTimeout))
		{
			try
			{
				WriteLogEventsInQueue(int.MaxValue, "Closing Target");
			}
			finally
			{
				Monitor.Exit(_writeLockObject);
			}
		}
		else
		{
			InternalLogger.Debug("{0}: Failed to flush after lock timeout", this);
		}
		if (OverflowAction == AsyncTargetWrapperOverflowAction.Block)
		{
			_requestQueue.Clear();
		}
		base.CloseTarget();
	}

	protected virtual void StartLazyWriterTimer()
	{
		if (TimeToSleepBetweenBatches <= 1)
		{
			StartTimerUnlessWriterActive(instant: false);
			return;
		}
		lock (_timerLockObject)
		{
			_lazyWriterTimer?.Change(TimeToSleepBetweenBatches, -1);
		}
	}

	protected virtual bool StartInstantWriterTimer()
	{
		return StartLazyWriterThread(instant: true);
	}

	private void StartTimerUnlessWriterActive(bool instant)
	{
		bool flag = false;
		try
		{
			flag = Monitor.TryEnter(_writeLockObject);
			if (flag)
			{
				if (instant)
				{
					StartInstantWriterTimer();
				}
				else
				{
					StartLazyWriterThread(instant: false);
				}
			}
			else
			{
				InternalLogger.Trace("{0}: Timer not scheduled, since already active", this);
			}
		}
		finally
		{
			if (flag)
			{
				Monitor.Exit(_writeLockObject);
			}
		}
	}

	private bool StartLazyWriterThread(bool instant)
	{
		lock (_timerLockObject)
		{
			if (_lazyWriterTimer != null)
			{
				if (instant)
				{
					InternalLogger.Trace("{0}: Timer scheduled instantly", this);
					_lazyWriterTimer.Change(0, -1);
				}
				else
				{
					InternalLogger.Trace("{0}: Timer scheduled throttled", this);
					_lazyWriterTimer.Change(1, -1);
				}
				return true;
			}
		}
		return false;
	}

	protected virtual void StopLazyWriterThread()
	{
		lock (_timerLockObject)
		{
			Timer lazyWriterTimer = _lazyWriterTimer;
			if (lazyWriterTimer != null)
			{
				_lazyWriterTimer = null;
				lazyWriterTimer.WaitForDispose(TimeSpan.FromSeconds(1.0));
			}
		}
	}

	protected override void Write(AsyncLogEventInfo logEvent)
	{
		PrecalculateVolatileLayouts(logEvent.LogEvent);
		if (_requestQueue.Enqueue(logEvent))
		{
			if (TimeToSleepBetweenBatches == 0)
			{
				StartTimerUnlessWriterActive(instant: true);
			}
			else if (TimeToSleepBetweenBatches <= 1)
			{
				StartLazyWriterTimer();
			}
		}
	}

	protected override void WriteAsyncThreadSafe(AsyncLogEventInfo logEvent)
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

	private void ProcessPendingEvents(object state)
	{
		if (_lazyWriterTimer == null)
		{
			return;
		}
		bool flag = false;
		try
		{
			lock (_writeLockObject)
			{
				flag = WriteLogEventsInQueue(BatchSize, "Timer") == BatchSize;
				if (flag && TimeToSleepBetweenBatches <= 1)
				{
					StartInstantWriterTimer();
				}
			}
		}
		catch (Exception ex)
		{
			flag = false;
			InternalLogger.Error(ex, "{0}: Error in lazy writer timer procedure.", new ReadOnlySpan<object>(new object[1] { this }));
		}
		finally
		{
			if (TimeToSleepBetweenBatches <= 1)
			{
				if (!flag)
				{
					if (!_requestQueue.IsEmpty)
					{
						StartLazyWriterTimer();
					}
					else
					{
						InternalLogger.Trace("{0}: Timer not scheduled, since queue empty", this);
					}
				}
			}
			else
			{
				StartLazyWriterTimer();
			}
		}
	}

	private void FlushEventsInQueue(object state)
	{
		AsyncContinuation asyncContinuation = state as AsyncContinuation;
		if (Monitor.TryEnter(_writeLockObject, 1500))
		{
			try
			{
				WriteLogEventsInQueue(int.MaxValue, "Flush Async");
				if (asyncContinuation != null)
				{
					base.FlushAsync(asyncContinuation);
				}
				return;
			}
			catch (Exception ex)
			{
				InternalLogger.Error(ex, "{0}: Error in flush procedure.", new ReadOnlySpan<object>(new object[1] { this }));
				return;
			}
			finally
			{
				Monitor.Exit(_writeLockObject);
				if (TimeToSleepBetweenBatches <= 1 && !_requestQueue.IsEmpty)
				{
					StartLazyWriterTimer();
				}
			}
		}
		asyncContinuation?.Invoke(new NLogRuntimeException($"Target {this} failed to flush after lock timeout."));
	}

	private int WriteLogEventsInQueue(int batchSize, string reason)
	{
		if (base.WrappedTarget == null)
		{
			InternalLogger.Error("{0}: WrappedTarget is NULL", this);
			return 0;
		}
		if (_missingServiceTypes)
		{
			if (base.WrappedTarget.InitializeException is NLogDependencyResolveException)
			{
				return 0;
			}
			_missingServiceTypes = false;
			InternalLogger.Debug("{0}: WrappedTarget has resolved missing dependency", this);
		}
		if (batchSize == int.MaxValue)
		{
			AsyncLogEventInfo[] logEvents = _requestQueue.DequeueBatch(int.MaxValue);
			return WriteLogEventsToTarget(logEvents, reason);
		}
		int num = 0;
		for (int i = 0; i < FullBatchSizeWriteLimit; i++)
		{
			ReusableObjectCreator<IList<AsyncLogEventInfo>>.LockOject lockOject = _reusableAsyncLogEventList.Allocate();
			try
			{
				IList<AsyncLogEventInfo> result = lockOject.Result;
				_requestQueue.DequeueBatch(batchSize, result);
				num = WriteLogEventsToTarget(result, reason);
			}
			finally
			{
				((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
			}
			if (num < batchSize)
			{
				break;
			}
		}
		return num;
	}

	private int WriteLogEventsToTarget(IList<AsyncLogEventInfo> logEvents, string reason)
	{
		int count = logEvents.Count;
		if (count > 0)
		{
			if (reason != null)
			{
				InternalLogger.Trace("{0}: Writing {1} events ({2})", this, count, reason);
			}
			base.WrappedTarget?.WriteAsyncLogEvents(logEvents);
		}
		return count;
	}

	private void OnRequestQueueDropItem(object sender, LogEventDroppedEventArgs logEventDroppedEventArgs)
	{
		this._logEventDroppedEvent?.Invoke(this, logEventDroppedEventArgs);
	}

	private void OnRequestQueueGrow(object sender, LogEventQueueGrowEventArgs logEventQueueGrowEventArgs)
	{
		this._eventQueueGrowEvent?.Invoke(this, logEventQueueGrowEventArgs);
	}
}
