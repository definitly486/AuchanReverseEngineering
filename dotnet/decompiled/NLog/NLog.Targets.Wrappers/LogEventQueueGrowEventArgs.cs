using System;

namespace NLog.Targets.Wrappers;

public class LogEventQueueGrowEventArgs : EventArgs
{
	public long NewQueueSize { get; }

	public long RequestsCount { get; }

	public LogEventQueueGrowEventArgs(long newQueueSize, long requestsCount)
	{
		NewQueueSize = newQueueSize;
		RequestsCount = requestsCount;
	}
}
