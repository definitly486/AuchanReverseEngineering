using System;
using System.Collections.Generic;
using NLog.Common;

namespace NLog.Targets.Wrappers;

internal abstract class AsyncRequestQueueBase
{
	public abstract bool IsEmpty { get; }

	public int QueueLimit { get; set; }

	public AsyncTargetWrapperOverflowAction OnOverflow { get; set; }

	public event EventHandler<LogEventDroppedEventArgs>? LogEventDropped;

	public event EventHandler<LogEventQueueGrowEventArgs>? LogEventQueueGrow;

	public abstract bool Enqueue(AsyncLogEventInfo logEventInfo);

	public abstract AsyncLogEventInfo[] DequeueBatch(int count);

	public abstract void DequeueBatch(int count, IList<AsyncLogEventInfo> result);

	public abstract void Clear();

	protected void OnLogEventDropped(LogEventInfo logEventInfo)
	{
		this.LogEventDropped?.Invoke(this, new LogEventDroppedEventArgs(logEventInfo));
	}

	protected void OnLogEventQueueGrows(long requestsCount)
	{
		this.LogEventQueueGrow?.Invoke(this, new LogEventQueueGrowEventArgs(QueueLimit, requestsCount));
	}
}
