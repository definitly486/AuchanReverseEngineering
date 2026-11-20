using System;
using System.Collections.Generic;
using System.IO;
using NLog.Common;
using NLog.Time;

namespace NLog.Targets.FileArchiveModes;

internal abstract class FileArchiveModeBase : IFileArchiveMode
{
	internal sealed class FileNameTemplate
	{
		public string Template { get; }

		public int BeginAt { get; }

		public int EndAt { get; }

		private bool FoundPattern
		{
			get
			{
				if (BeginAt != -1)
				{
					return EndAt != -1;
				}
				return false;
			}
		}

		public FileNameTemplate(string template)
		{
			Template = template;
			BeginAt = template.IndexOf("{#", StringComparison.Ordinal);
			EndAt = ((BeginAt != -1) ? (template.IndexOf("#}", StringComparison.Ordinal) + "#}".Length) : (-1));
		}

		public string ReplacePattern(string replacementValue)
		{
			if (FoundPattern && !string.IsNullOrEmpty(replacementValue))
			{
				return Template.Substring(0, BeginAt) + replacementValue + Template.Substring(EndAt);
			}
			return Template;
		}
	}

	private static readonly DateTime MaxAgeArchiveFileDate = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	private int _lastArchiveFileCount = 65534;

	private DateTime _oldestArchiveFileDate = MaxAgeArchiveFileDate.Date;

	public bool IsArchiveCleanupEnabled { get; }

	protected FileArchiveModeBase(bool isArchiveCleanupEnabled)
	{
		IsArchiveCleanupEnabled = isArchiveCleanupEnabled;
	}

	public virtual bool AttemptCleanupOnInitializeFile(string archiveFilePath, int maxArchiveFiles, int maxArchiveDays)
	{
		if (maxArchiveFiles > 0 && _lastArchiveFileCount++ > maxArchiveFiles)
		{
			return true;
		}
		if (maxArchiveDays > 0 && (TimeSource.Current.Time.Date.ToUniversalTime() - _oldestArchiveFileDate).TotalDays > (double)maxArchiveDays)
		{
			return true;
		}
		return false;
	}

	public string GenerateFileNameMask(string archiveFilePath)
	{
		int lastArchiveFileCount = _lastArchiveFileCount;
		DateTime oldestArchiveFileDate = _oldestArchiveFileDate;
		string result = GenerateFileNameMask(archiveFilePath, GenerateFileNameTemplate(archiveFilePath));
		_lastArchiveFileCount = lastArchiveFileCount;
		_oldestArchiveFileDate = oldestArchiveFileDate;
		return result;
	}

	public virtual List<DateAndSequenceArchive> GetExistingArchiveFiles(string archiveFilePath)
	{
		_lastArchiveFileCount = 65534;
		DateTime maxAgeArchiveFileDate = MaxAgeArchiveFileDate;
		_oldestArchiveFileDate = maxAgeArchiveFileDate.Date;
		string directoryName = Path.GetDirectoryName(archiveFilePath);
		FileNameTemplate fileTemplate = GenerateFileNameTemplate(archiveFilePath);
		string text = GenerateFileNameMask(archiveFilePath, fileTemplate);
		List<DateAndSequenceArchive> list = new List<DateAndSequenceArchive>();
		if (string.IsNullOrEmpty(text))
		{
			return list;
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
		if (!directoryInfo.Exists)
		{
			return list;
		}
		FileInfo[] files = directoryInfo.GetFiles(text);
		foreach (FileInfo fileInfo in files)
		{
			DateAndSequenceArchive dateAndSequenceArchive = GenerateArchiveFileInfo(fileInfo, fileTemplate);
			if (dateAndSequenceArchive != null)
			{
				InternalLogger.Trace("FileTarget: Found existing archive file: {0} [SeqNo={1} and FileTimeUtc={2:u}]", dateAndSequenceArchive.FileName, dateAndSequenceArchive.Sequence, dateAndSequenceArchive.Date);
				list.Add(dateAndSequenceArchive);
			}
			else
			{
				InternalLogger.Trace("FileTarget: Ignored existing archive file: {0}", fileInfo.FullName);
			}
		}
		if (list.Count > 1)
		{
			list.Sort((DateAndSequenceArchive x, DateAndSequenceArchive y) => FileSortOrderComparison(x, y));
		}
		UpdateMaxArchiveState(list);
		return list;
	}

	protected void UpdateMaxArchiveState(List<DateAndSequenceArchive> existingArchiveFiles)
	{
		_lastArchiveFileCount = existingArchiveFiles.Count;
		_oldestArchiveFileDate = ((existingArchiveFiles.Count == 0) ? TimeSource.Current.Time.Date.ToUniversalTime() : existingArchiveFiles[0].Date.Date.ToUniversalTime());
	}

	private static int FileSortOrderComparison(DateAndSequenceArchive x, DateAndSequenceArchive y)
	{
		if (x.Date != y.Date && !x.HasSameFormattedDate(y.Date))
		{
			return x.Date.CompareTo(y.Date);
		}
		if (x.Sequence.CompareTo(y.Sequence) != 0)
		{
			return x.Sequence.CompareTo(y.Sequence);
		}
		return StringComparer.OrdinalIgnoreCase.Compare(x.FileName, y.FileName);
	}

	protected virtual FileNameTemplate GenerateFileNameTemplate(string archiveFilePath)
	{
		_lastArchiveFileCount++;
		return new FileNameTemplate(Path.GetFileName(archiveFilePath));
	}

	protected virtual string GenerateFileNameMask(string archiveFilePath, FileNameTemplate fileTemplate)
	{
		return fileTemplate?.ReplacePattern("*") ?? string.Empty;
	}

	protected abstract DateAndSequenceArchive GenerateArchiveFileInfo(FileInfo archiveFile, FileNameTemplate fileTemplate);

	public abstract DateAndSequenceArchive GenerateArchiveFileName(string archiveFilePath, DateTime archiveDate, List<DateAndSequenceArchive> existingArchiveFiles);

	public virtual IEnumerable<DateAndSequenceArchive> CheckArchiveCleanup(string archiveFilePath, List<DateAndSequenceArchive> existingArchiveFiles, int maxArchiveFiles, int maxArchiveDays)
	{
		if (maxArchiveFiles <= 0 && maxArchiveDays <= 0)
		{
			yield break;
		}
		UpdateMaxArchiveState(existingArchiveFiles);
		if (existingArchiveFiles.Count == 0 || (maxArchiveFiles > 0 && existingArchiveFiles.Count <= maxArchiveFiles && maxArchiveDays <= 0))
		{
			yield break;
		}
		for (int i = 0; i < existingArchiveFiles.Count; i++)
		{
			if (ShouldDeleteFile(existingArchiveFiles[i], existingArchiveFiles.Count - i, maxArchiveFiles, maxArchiveDays))
			{
				if (_lastArchiveFileCount > 0)
				{
					_lastArchiveFileCount--;
				}
				yield return existingArchiveFiles[i];
				continue;
			}
			_oldestArchiveFileDate = existingArchiveFiles[i].Date.Date.ToUniversalTime();
			break;
		}
	}

	private static bool ShouldDeleteFile(DateAndSequenceArchive existingArchiveFile, int remainingFileCount, int maxArchiveFiles, int maxArchiveDays)
	{
		if (maxArchiveFiles > 0 && remainingFileCount > maxArchiveFiles)
		{
			return true;
		}
		if (maxArchiveDays > 0)
		{
			DateTime dateTime = existingArchiveFile.Date.Date.ToUniversalTime();
			if (dateTime > MaxAgeArchiveFileDate)
			{
				DateTime dateTime2 = TimeSource.Current.Time.Date.ToUniversalTime();
				double totalDays = (dateTime2 - dateTime).TotalDays;
				if (totalDays > (double)maxArchiveDays)
				{
					InternalLogger.Debug("FileTarget: Detected old file in archive. FileName={0}, FileDate={1:u}, FileDateUtc={2:u}, CurrentDateUtc={3:u}, Age={4} days", existingArchiveFile.FileName, existingArchiveFile.Date, dateTime, dateTime2, Math.Round(totalDays, 1));
					return true;
				}
			}
		}
		return false;
	}
}
