using System;
using System.Collections.Generic;

namespace NLog.Targets;

internal interface IFileArchiveMode
{
	bool IsArchiveCleanupEnabled { get; }

	bool AttemptCleanupOnInitializeFile(string archiveFilePath, int maxArchiveFiles, int maxArchiveDays);

	string GenerateFileNameMask(string archiveFilePath);

	List<DateAndSequenceArchive> GetExistingArchiveFiles(string archiveFilePath);

	DateAndSequenceArchive GenerateArchiveFileName(string archiveFilePath, DateTime archiveDate, List<DateAndSequenceArchive> existingArchiveFiles);

	IEnumerable<DateAndSequenceArchive> CheckArchiveCleanup(string archiveFilePath, List<DateAndSequenceArchive> existingArchiveFiles, int maxArchiveFiles, int maxArchiveDays);
}
