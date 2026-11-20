using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using NLog.Common;
using NLog.Time;

namespace NLog.Targets.FileArchiveModes;

internal sealed class FileArchiveModeDateAndSequence : FileArchiveModeBase
{
	private readonly string _archiveDateFormat;

	public FileArchiveModeDateAndSequence(string archiveDateFormat, bool archiveCleanupEnabled)
		: base(archiveCleanupEnabled)
	{
		_archiveDateFormat = archiveDateFormat;
	}

	public override bool AttemptCleanupOnInitializeFile(string archiveFilePath, int maxArchiveFiles, int maxArchiveDays)
	{
		return false;
	}

	protected override DateAndSequenceArchive GenerateArchiveFileInfo(FileInfo archiveFile, FileNameTemplate fileTemplate)
	{
		if (!TryParseDateAndSequence(Path.GetFileName(archiveFile.FullName) ?? string.Empty, _archiveDateFormat, fileTemplate, out var date, out var sequence))
		{
			return null;
		}
		date = DateTime.SpecifyKind(date, TimeSource.Current.Time.Kind);
		return new DateAndSequenceArchive(archiveFile.FullName, date, _archiveDateFormat, sequence);
	}

	public override DateAndSequenceArchive GenerateArchiveFileName(string archiveFilePath, DateTime archiveDate, List<DateAndSequenceArchive> existingArchiveFiles)
	{
		int num = 0;
		FileNameTemplate fileNameTemplate = GenerateFileNameTemplate(archiveFilePath);
		foreach (DateAndSequenceArchive existingArchiveFile in existingArchiveFiles)
		{
			if (existingArchiveFile.HasSameFormattedDate(archiveDate))
			{
				num = Math.Max(num, existingArchiveFile.Sequence + 1);
			}
		}
		int totalWidth = fileNameTemplate.EndAt - fileNameTemplate.BeginAt - 2;
		string text = num.ToString(CultureInfo.InvariantCulture).PadLeft(totalWidth, '0');
		string path = fileNameTemplate.ReplacePattern("*").Replace("*", archiveDate.ToString(_archiveDateFormat) + "." + text);
		archiveFilePath = Path.Combine(Path.GetDirectoryName(archiveFilePath), path);
		archiveFilePath = Path.GetFullPath(archiveFilePath);
		return new DateAndSequenceArchive(archiveFilePath, archiveDate, _archiveDateFormat, num);
	}

	private static bool TryParseDateAndSequence(string archiveFileNameWithoutPath, string dateFormat, FileNameTemplate fileTemplate, out DateTime date, out int sequence)
	{
		int num = fileTemplate.Template.Length - fileTemplate.EndAt;
		int beginAt = fileTemplate.BeginAt;
		int num2 = archiveFileNameWithoutPath.Length - num - beginAt;
		if (num2 < 0)
		{
			date = default(DateTime);
			sequence = 0;
			return false;
		}
		string text = archiveFileNameWithoutPath.Substring(beginAt, num2);
		int startIndex = text.LastIndexOf('.') + 1;
		string text2 = text.Substring(startIndex);
		if (!int.TryParse(text2, NumberStyles.None, CultureInfo.CurrentCulture, out sequence))
		{
			date = default(DateTime);
			return false;
		}
		int num3 = text.Length - text2.Length - 1;
		if (num3 < 0)
		{
			date = default(DateTime);
			return false;
		}
		string text3 = text.Substring(0, num3);
		if (!DateTime.TryParseExact(text3, dateFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out date))
		{
			return false;
		}
		InternalLogger.Trace("FileTarget: parsed date '{0}' from file-template '{1}'", text3, fileTemplate.Template);
		return true;
	}
}
