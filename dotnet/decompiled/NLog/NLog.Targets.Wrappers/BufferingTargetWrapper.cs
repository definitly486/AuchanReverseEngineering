using System;
using System.Threading;
using NLog.Common;
using NLog.Layouts;

namespace NLog.Targets.Wrappers;

[Target("BufferingWrapper", IsWrapper = true)]
public class BufferingTargetWrapper : WrapperTargetBase
{
	private AsyncRequestQueue _buffer = new AsyncRequestQueue(100, AsyncTargetWrapperOverflowAction.Discard);

	private Timer? _flushTimer;

	private readonly object _lockObject = new object();

	public Layout<int> BufferSize { get; set; }

	public Layout<int> FlushTimeout { get; set; }

	public bool SlidingTimeout { get; set; } = true;

	public BufferingTargetWrapperOverflowAction OverflowAction { get; set; }

	public BufferingTargetWrapper()
	{
		BufferSize = 100;
		FlushTimeout = -1;
	}

	public BufferingTargetWrapper(string name, Target wrappedTarget)
		: this(wrappedTarget)
	{
		base.Name = name ?? base.Name;
	}

	public BufferingTargetWrapper(Target wrappedTarget)
		: this(wrappedTarget, 100)
	{
	}

	public BufferingTargetWrapper(Target wrappedTarget, int bufferSize)
		: this(wrappedTarget, bufferSize, -1)
	{
	}

	public BufferingTargetWrapper(Target wrappedTarget, int bufferSize, int flushTimeout)
		: this(wrappedTarget, bufferSize, flushTimeout, BufferingTargetWrapperOverflowAction.Flush)
	{
	}

	public BufferingTargetWrapper(Target wrappedTarget, int bufferSize, int flushTimeout, BufferingTargetWrapperOverflowAction overflowAction)
	{
		base.Name = ((wrappedTarget == null || string.IsNullOrEmpty(wrappedTarget.Name)) ? base.Name : (wrappedTarget.Name + "_wrapper"));
		base.WrappedTarget = wrappedTarget;
		BufferSize = bufferSize;
		FlushTimeout = flushTimeout;
		OverflowAction = overflowAction;
	}

	protected override void FlushAsync(AsyncContinuation asyncContinuation)
	{
		if (Monitor.TryEnter(_lockObject, 1500))
		{
			try
			{
				WriteEventsInBuffer("Flush Async");
				base.FlushAsync(asyncContinuation);
				return;
			}
			finally
			{
				Monitor.Exit(_lockObject);
			}
		}
		asyncContinuation(new NLogRuntimeException($"Target {this} failed to flush after lock timeout."));
	}

	protected override void InitializeTarget()
	{
		base.InitializeTarget();
		int queueLimit = RenderLogEvent(BufferSize, LogEventInfo.CreateNullEvent(), 0);
		_buffer = new AsyncRequestQueue(queueLimit, AsyncTargetWrapperOverflowAction.Discard);
		InternalLogger.Trace("{0}: Create Timer", this);
		int num = RenderLogEvent(FlushTimeout, LogEventInfo.CreateNullEvent(), 0);
		_flushTimer = new Timer(FlushCallback, num, -1, -1);
	}

	protected override void CloseTarget()
	{
		Timer flushTimer = _flushTimer;
		if (flushTimer != null)
		{
			_flushTimer = null;
			if (flushTimer.WaitForDispose(TimeSpan.FromSeconds(1.0)))
			{
				if (OverflowAction == BufferingTargetWrapperOverflowAction.Discard)
				{
					_buffer.Clear();
				}
				else
				{
					int millisecondsTimeout = ((OverflowAction == BufferingTargetWrapperOverflowAction.Discard) ? 500 : 1500);
					if (Monitor.TryEnter(_lockObject, millisecondsTimeout))
					{
						try
						{
							WriteEventsInBuffer("Closing Target");
						}
						finally
						{
							Monitor.Exit(_lockObject);
						}
					}
					else
					{
						InternalLogger.Debug("{0}: Failed to flush after lock timeout", this);
					}
				}
			}
		}
		base.CloseTarget();
	}

	protected override void Write(AsyncLogEventInfo logEvent)
	{
		PrecalculateVolatileLayouts(logEvent.LogEvent);
		bool flag = _buffer.Enqueue(logEvent);
		if (_buffer.RequestCount >= _buffer.QueueLimit)
		{
			if (OverflowAction == BufferingTargetWrapperOverflowAction.Flush)
			{
				lock (_lockObject)
				{
					WriteEventsInBuffer("Exceeding BufferSize");
				}
			}
		}
		else if (SlidingTimeout || flag)
		{
			int num = RenderLogEvent(FlushTimeout, logEvent.LogEvent, 0);
			if (num > 0)
			{
				_flushTimer?.Change(num, -1);
			}
		}
	}

	private void FlushCallback(object state)
	{
		bool flag = false;
		try
		{
			int num = Math.Min((state as int?).GetValueOrDefault() / 2, 100);
			flag = Monitor.TryEnter(_lockObject, num);
			if (flag)
			{
				if (_flushTimer != null)
				{
					WriteEventsInBuffer(string.Empty);
				}
			}
			else if (!_buffer.IsEmpty)
			{
				_flushTimer?.Change(num, -1);
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "{0}: Error in flush procedure.", new ReadOnlySpan<object>(new object[1] { this }));
		}
		finally
		{
			if (flag)
			{
				Monitor.Exit(_lockObject);
			}
		}
	}

	private void WriteEventsInBuffer(string reason)
	{
		if (base.WrappedTarget == null)
		{
			InternalLogger.Error("{0}: WrappedTarget is NULL", this);
			return;
		}
		AsyncLogEventInfo[] array = _buffer.DequeueBatch(int.MaxValue);
		if (array.Length != 0)
		{
			if (!string.IsNullOrEmpty(reason))
			{
				InternalLogger.Trace("{0}: Writing {1} events ({2})", this, array.Length, reason);
			}
			base.WrappedTarget.WriteAsyncLogEvents(array);
		}
	}
}
