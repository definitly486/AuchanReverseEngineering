using System;
using NLog.Common;
using NLog.Conditions;
using NLog.Internal;

namespace NLog.Targets.Wrappers;

[Target("AutoFlushWrapper", IsWrapper = true)]
public class AutoFlushTargetWrapper : WrapperTargetBase
{
	private bool? _asyncFlush;

	private readonly AsyncOperationCounter _pendingManualFlushList = new AsyncOperationCounter();

	private readonly AsyncContinuation _flushCompletedContinuation;

	public ConditionExpression? Condition { get; set; }

	public bool AsyncFlush
	{
		get
		{
			return _asyncFlush ?? true;
		}
		set
		{
			_asyncFlush = value;
		}
	}

	public bool FlushOnConditionOnly { get; set; }

	public AutoFlushTargetWrapper()
	{
		_flushCompletedContinuation = delegate(Exception? ex)
		{
			_pendingManualFlushList.CompleteOperation(ex);
		};
	}

	public AutoFlushTargetWrapper(string name, Target wrappedTarget)
		: this(wrappedTarget)
	{
		base.Name = name ?? base.Name;
	}

	public AutoFlushTargetWrapper(Target wrappedTarget)
		: this()
	{
		base.Name = ((wrappedTarget == null || string.IsNullOrEmpty(wrappedTarget.Name)) ? base.Name : (wrappedTarget.Name + "_wrapper"));
		base.WrappedTarget = wrappedTarget;
	}

	protected override void InitializeTarget()
	{
		base.InitializeTarget();
		if (!_asyncFlush.HasValue && !TargetSupportsAsyncFlush())
		{
			AsyncFlush = false;
		}
	}

	private bool TargetSupportsAsyncFlush()
	{
		if (base.WrappedTarget is BufferingTargetWrapper)
		{
			return false;
		}
		if (base.WrappedTarget is AsyncTaskTarget)
		{
			return false;
		}
		return true;
	}

	protected override void Write(AsyncLogEventInfo logEvent)
	{
		if (Condition == null || ConditionExpression.BoxedTrue.Equals(Condition.Evaluate(logEvent.LogEvent)))
		{
			if (AsyncFlush)
			{
				AsyncContinuation currentContinuation = logEvent.Continuation;
				AsyncContinuation asyncContinuation = delegate(Exception? ex)
				{
					_pendingManualFlushList.CompleteOperation(ex);
					if (ex == null)
					{
						AsyncContinuation asyncContinuation2 = _pendingManualFlushList.RegisterCompletionNotification(delegate
						{
						});
						FlushWrappedTarget(asyncContinuation2);
					}
					currentContinuation(ex);
				};
				_pendingManualFlushList.BeginOperation();
				base.WrappedTarget?.WriteAsyncLogEvent(logEvent.LogEvent.WithContinuation(asyncContinuation));
			}
			else
			{
				_pendingManualFlushList.BeginOperation();
				base.WrappedTarget?.WriteAsyncLogEvent(logEvent);
				FlushWrappedTarget(_flushCompletedContinuation);
			}
		}
		else
		{
			base.WrappedTarget?.WriteAsyncLogEvent(logEvent);
		}
	}

	protected override void FlushAsync(AsyncContinuation asyncContinuation)
	{
		AsyncContinuation asyncContinuation2 = _pendingManualFlushList.RegisterCompletionNotification(asyncContinuation);
		if (FlushOnConditionOnly)
		{
			asyncContinuation2(null);
		}
		else
		{
			FlushWrappedTarget(asyncContinuation2);
		}
	}

	private void FlushWrappedTarget(AsyncContinuation asyncContinuation)
	{
		base.WrappedTarget?.Flush(asyncContinuation);
	}

	protected override void CloseTarget()
	{
		_pendingManualFlushList.Clear();
		base.CloseTarget();
	}
}
