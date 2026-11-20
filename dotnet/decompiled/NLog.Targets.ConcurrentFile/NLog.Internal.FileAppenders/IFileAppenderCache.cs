using System;

namespace NLog.Internal.FileAppenders;

internal interface IFileAppenderCache : IDisposable
{
	string ArchiveFilePatternToWatch { set; }

	event EventHandler CheckCloseAppenders;

	BaseFileAppender AllocateAppender(string fileName);

	void CloseAppenders(string reason);

	void CloseExpiredAppenders(DateTime expireTimeUtc);

	void FlushAppenders();

	DateTime? GetFileCreationTimeSource(string filePath, DateTime? fallbackTimeSource = null);

	DateTime? GetFileLastWriteTimeUtc(string filePath);

	long? GetFileLength(string filePath);

	BaseFileAppender InvalidateAppender(string filePath);

	void InvalidateAppendersForArchivedFiles();
}
