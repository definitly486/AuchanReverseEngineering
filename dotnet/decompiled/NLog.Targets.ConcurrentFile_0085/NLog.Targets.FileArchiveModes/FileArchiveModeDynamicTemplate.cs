using System;
using System.Collections.Generic;
using System.IO;

namespace NLog.Targets.FileArchiveModes;

internal sealed class FileArchiveModeDynamicTemplate : IFileArchiveMode
{
	private readonly IFileArchiveMode _archiveHelper;

	public bool IsArchiveCleanupEnabled => _archiveHelper.IsArchiveCleanupEnabled;

	private static string CreateDynamicTemplate(string archiveFilePath)
	{
		string extension = Path.GetExtension(archiveFilePath);
		return Path.ChangeExtension(archiveFilePath, ".{#}" + extension);
	}

	public FileArchiveModeDynamicTemplate(IFileArchiveMode archiveHelper)
	{
		_archiveHelper = archiveHelper;
	}

	public bool AttemptCleanupOnInitializeFile(string archiveFilePath, int maxArchiveFiles, int maxArchiveDays)
	{
		return _archiveHelper.AttemptCleanupOnInitializeFile(archiveFilePath, maxArchiveFiles, maxArchiveDays);
	}

	public IEnumerable<DateAndSequenceArchive> CheckArchiveCleanup(string archiveFilePath, List<DateAndSequenceArchive> existingArchiveFiles, int maxArchiveFiles, int maxArchiveDays)
	{
		return _archiveHelper.CheckArchiveCleanup(CreateDynamicTemplate(archiveFilePath), existingArchiveFiles, maxArchiveFiles, maxArchiveDays);
	}

	public DateAndSequenceArchive GenerateArchiveFileName(string archiveFilePath, DateTime archiveDate, List<DateAndSequenceArchive> existingArchiveFiles)
	{
		return _archiveHelper.GenerateArchiveFileName(CreateDynamicTemplate(archiveFilePath), archiveDate, existingArchiveFiles);
	}

	public string GenerateFileNameMask(string archiveFilePath)
	{
		return _archiveHelper.GenerateFileNameMask(CreateDynamicTemplate(archiveFilePath));
	}

	public List<DateAndSequenceArchive> GetExistingArchiveFiles(string archiveFilePath)
	{
		return _archiveHelper.GetExistingArchiveFiles(CreateDynamicTemplate(archiveFilePath));
	}
}
