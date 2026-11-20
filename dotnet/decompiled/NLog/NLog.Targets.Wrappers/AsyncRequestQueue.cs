using System.Collections.Generic;
using System.Threading;
using NLog.Common;
using NLog.Internal;

namespace NLog.Targets.Wrappers;

internal sealed class AsyncRequestQueue : AsyncRequestQueueBase
{
	private readonly Queue<AsyncLogEventInfo> _logEventInfoQueue = new Queue<AsyncLogEventInfo>(1000);

	public int RequestCount
	{
		get
		{
			lock (_logEventInfoQueue)
			{
				return _logEventInfoQueue.Count;
			}
		}
	}

	public override bool IsEmpty => RequestCount == 0;

	public AsyncRequestQueue(int queueLimit, AsyncTargetWrapperOverflowAction overflowAction)
	{
		base.QueueLimit = queueLimit;
		base.OnOverflow = overflowAction;
	}

	public override bool Enqueue(AsyncLogEventInfo logEventInfo)
	{
		lock (_logEventInfoQueue)
		{
			int count = _logEventInfoQueue.Count;
			if (count >= base.QueueLimit)
			{
				switch (base.OnOverflow)
				{
				case AsyncTargetWrapperOverflowAction.Discard:
					InternalLogger.Debug("AsyncQueue - Discarding single item, because queue is full");
					OnLogEventDropped(_logEventInfoQueue.Dequeue().LogEvent);
					break;
				case AsyncTargetWrapperOverflowAction.Grow:
					InternalLogger.Debug("AsyncQueue - Growing the size of queue, because queue is full");
					base.QueueLimit *= 2;
					OnLogEventQueueGrows(count + 1);
					break;
				case AsyncTargetWrapperOverflowAction.Block:
					while (count >= base.QueueLimit)
					{
						InternalLogger.Debug("AsyncQueue - Blocking until ready, because queue is full");
						Monitor.Wait(_logEventInfoQueue);
						InternalLogger.Trace("AsyncQueue - Entered critical section.");
						count = _logEventInfoQueue.Count;
					}
					InternalLogger.Trace("AsyncQueue - Limit ok.");
					break;
				}
			}
			_logEventInfoQueue.Enqueue(logEventInfo);
			return count == 0;
		}
	}

	public override AsyncLogEventInfo[] DequeueBatch(int count)
	{
		AsyncLogEventInfo[] array;
		lock (_logEventInfoQueue)
		{
			if (_logEventInfoQueue.Count < count)
			{
				count = _logEventInfoQueue.Count;
			}
			if (count == 0)
			{
				return ArrayHelper.Empty<AsyncLogEventInfo>();
			}
			array = new AsyncLogEventInfo[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = _logEventInfoQueue.Dequeue();
			}
			if (base.OnOverflow == AsyncTargetWrapperOverflowAction.Block)
			{
				Monitor.PulseAll(_logEventInfoQueue);
			}
		}
		return array;
	}

	public override void DequeueBatch(int count, IList<AsyncLogEventInfo> result)
	{
		lock (_logEventInfoQueue)
		{
			if (_logEventInfoQueue.Count < count)
			{
				count = _logEventInfoQueue.Count;
			}
			for (int i = 0; i < count; i++)
			{
				result.Add(_logEventInfoQueue.Dequeue());
			}
			if (base.OnOverflow == AsyncTargetWrapperOverflowAction.Block)
			{
				Monitor.PulseAll(_logEventInfoQueue);
			}
		}
	}

	public override void Clear()
	{
		lock (_logEventInfoQueue)
		{
			_logEventInfoQueue.Clear();
			if (base.OnOverflow == AsyncTargetWrapperOverflowAction.Block)
			{
				Monitor.PulseAll(_logEventInfoQueue);
			}
		}
	}
}
