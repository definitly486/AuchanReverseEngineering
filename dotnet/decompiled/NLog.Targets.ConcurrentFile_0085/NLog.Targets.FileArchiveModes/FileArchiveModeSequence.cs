using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using NLog.Internal;
using NLog.Time;

namespace NLog.Targets.FileArchiveModes;

internal sealed class FileArchiveModeSequence : FileArchiveModeBase
{
	private readonly string _archiveDateFormat;

	public FileArchiveModeSequence(string archiveDateFormat, bool isArchiveCleanupEnabled)
		: base(isArchiveCleanupEnabled)
	{
		_archiveDateFormat = archiveDateFormat;
	}

	public override bool AttemptCleanupOnInitializeFile(string archiveFilePath, int maxArchiveFiles, int maxArchiveDays)
	{
		return false;
	}

	protected override DateAndSequenceArchive GenerateArchiveFileInfo(FileInfo archiveFile, FileNameTemplate fileTemplate)
	{
		string text = Path.GetFileName(archiveFile.FullName) ?? string.Empty;
		int num = fileTemplate.Template.Length - fileTemplate.EndAt;
		string value = text.Substring(fileTemplate.BeginAt, text.Length - num - fileTemplate.BeginAt);
		int sequence;
		try
		{
			sequence = Convert.ToInt32(value, CultureInfo.InvariantCulture);
		}
		catch (FormatException)
		{
			return null;
		}
		DateTime dateTime = archiveFile.LookupValidFileCreationTimeUtc();
		DateTime date = ((dateTime > DateTime.MinValue) ? TimeSource.Current.FromSystemTime(dateTime) : DateTime.MinValue);
		return new DateAndSequenceArchive(archiveFile.FullName, date, string.Empty, sequence);
	}

	public override DateAndSequenceArchive GenerateArchiveFileName(string archiveFilePath, DateTime archiveDate, List<DateAndSequenceArchive> existingArchiveFiles)
	{
		int num = 0;
		FileNameTemplate fileNameTemplate = GenerateFileNameTemplate(archiveFilePath);
		foreach (DateAndSequenceArchive existingArchiveFile in existingArchiveFiles)
		{
			num = Math.Max(num, existingArchiveFile.Sequence + 1);
		}
		int totalWidth = fileNameTemplate.EndAt - fileNameTemplate.BeginAt - 2;
		string newValue = num.ToString(CultureInfo.InvariantCulture).PadLeft(totalWidth, '0');
		archiveFilePath = Path.Combine(Path.GetDirectoryName(archiveFilePath), fileNameTemplate.ReplacePattern("*").Replace("*", newValue));
		archiveFilePath = Path.GetFullPath(archiveFilePath);
		return new DateAndSequenceArchive(archiveFilePath, archiveDate, _archiveDateFormat, num);
	}
}
