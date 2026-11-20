using System;

namespace NLog.Targets.Wrappers;

public class LogEventDroppedEventArgs : EventArgs
{
	public LogEventInfo DroppedLogEventInfo { get; }

	public LogEventDroppedEventArgs(LogEventInfo logEventInfo)
	{
		DroppedLogEventInfo = logEventInfo;
	}
}
