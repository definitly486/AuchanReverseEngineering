using System;

namespace NLog.Targets.FileArchiveHandlers;

internal interface IFileArchiveHandler
{
	int ArchiveBeforeOpenFile(string newFileName, LogEventInfo firstLogEvent, DateTime? previousFileLastModified, int newSequenceNumber);
}
