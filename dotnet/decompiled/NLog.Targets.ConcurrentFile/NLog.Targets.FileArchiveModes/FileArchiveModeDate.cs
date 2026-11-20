using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using NLog.Time;

namespace NLog.Targets.FileArchiveModes;

internal sealed class FileArchiveModeDate : FileArchiveModeBase
{
	private readonly string _archiveDateFormat;

	public FileArchiveModeDate(string archiveDateFormat, bool isArchiveCleanupEnabled)
		: base(isArchiveCleanupEnabled)
	{
		_archiveDateFormat = archiveDateFormat;
	}

	public override List<DateAndSequenceArchive> GetExistingArchiveFiles(string archiveFilePath)
	{
		if (base.IsArchiveCleanupEnabled)
		{
			return base.GetExistingArchiveFiles(archiveFilePath);
		}
		return new List<DateAndSequenceArchive>();
	}

	protected override DateAndSequenceArchive GenerateArchiveFileInfo(FileInfo archiveFile, FileNameTemplate fileTemplate)
	{
		string text = Path.GetFileName(archiveFile.FullName) ?? string.Empty;
		int num = fileTemplate.ReplacePattern("*").LastIndexOf('*');
		if (num + _archiveDateFormat.Length <= text.Length && DateTime.TryParseExact(text.Substring(num, _archiveDateFormat.Length), _archiveDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
		{
			result = DateTime.SpecifyKind(result, TimeSource.Current.Time.Kind);
			return new DateAndSequenceArchive(archiveFile.FullName, result, _archiveDateFormat, -1);
		}
		return null;
	}

	public override DateAndSequenceArchive GenerateArchiveFileName(string archiveFilePath, DateTime archiveDate, List<DateAndSequenceArchive> existingArchiveFiles)
	{
		FileNameTemplate fileNameTemplate = GenerateFileNameTemplate(archiveFilePath);
		archiveFilePath = Path.Combine(Path.GetDirectoryName(archiveFilePath), fileNameTemplate.ReplacePattern("*").Replace("*", archiveDate.ToString(_archiveDateFormat)));
		archiveFilePath = Path.GetFullPath(archiveFilePath);
		return new DateAndSequenceArchive(archiveFilePath, archiveDate, _archiveDateFormat, 0);
	}
}
