using System;
using System.Collections.Generic;
using System.IO;
using NLog.Common;

namespace NLog.Targets.FileArchiveModes;

internal sealed class FileArchiveModeRolling : IFileArchiveMode
{
	public bool IsArchiveCleanupEnabled => true;

	public bool AttemptCleanupOnInitializeFile(string archiveFilePath, int maxArchiveFiles, int maxArchiveDays)
	{
		return false;
	}

	public string GenerateFileNameMask(string archiveFilePath)
	{
		return new FileArchiveModeBase.FileNameTemplate(Path.GetFileName(archiveFilePath)).ReplacePattern("*");
	}

	public List<DateAndSequenceArchive> GetExistingArchiveFiles(string archiveFilePath)
	{
		List<DateAndSequenceArchive> list = new List<DateAndSequenceArchive>();
		for (int i = 0; i < int.MaxValue; i++)
		{
			FileInfo fileInfo = new FileInfo(ReplaceNumberPattern(archiveFilePath, i));
			if (!fileInfo.Exists)
			{
				break;
			}
			list.Add(new DateAndSequenceArchive(fileInfo.FullName, DateTime.MinValue, string.Empty, i));
		}
		return list;
	}

	private static string ReplaceNumberPattern(string pattern, int value)
	{
		int num = pattern.IndexOf("{#", StringComparison.Ordinal);
		int num2 = pattern.IndexOf("#}", StringComparison.Ordinal) + 2;
		int totalWidth = num2 - num - 2;
		return pattern.Substring(0, num) + Convert.ToString(value, 10).PadLeft(totalWidth, '0') + pattern.Substring(num2);
	}

	public DateAndSequenceArchive GenerateArchiveFileName(string archiveFilePath, DateTime archiveDate, List<DateAndSequenceArchive> existingArchiveFiles)
	{
		if (existingArchiveFiles.Count > 0)
		{
			int value = existingArchiveFiles[existingArchiveFiles.Count - 1].Sequence + 1;
			string fileName = ReplaceNumberPattern(archiveFilePath, value);
			existingArchiveFiles.Add(new DateAndSequenceArchive(fileName, DateTime.MinValue, string.Empty, int.MaxValue));
		}
		return new DateAndSequenceArchive(Path.GetFullPath(ReplaceNumberPattern(archiveFilePath, 0)), DateTime.MinValue, string.Empty, int.MinValue);
	}

	public IEnumerable<DateAndSequenceArchive> CheckArchiveCleanup(string archiveFilePath, List<DateAndSequenceArchive> existingArchiveFiles, int maxArchiveFiles, int maxArchiveDays)
	{
		if (existingArchiveFiles.Count <= 1)
		{
			yield break;
		}
		existingArchiveFiles.Sort((DateAndSequenceArchive x, DateAndSequenceArchive y) => x.Sequence.CompareTo(y.Sequence));
		if (maxArchiveFiles > 0 && existingArchiveFiles.Count > maxArchiveFiles)
		{
			for (int i = 0; i < existingArchiveFiles.Count; i++)
			{
				if (i >= maxArchiveFiles && existingArchiveFiles[i].HasValidSequence)
				{
					yield return existingArchiveFiles[i];
				}
			}
		}
		if (existingArchiveFiles.Count <= 1 || existingArchiveFiles[0].Sequence != int.MinValue)
		{
			yield break;
		}
		string text = string.Empty;
		int num = existingArchiveFiles.Count - 1;
		num = ((maxArchiveFiles > 0) ? Math.Min(num, maxArchiveFiles) : num);
		for (int num2 = num; num2 >= 1; num2--)
		{
			string fileName = existingArchiveFiles[num2].FileName;
			if (!string.IsNullOrEmpty(text))
			{
				InternalLogger.Info("Roll archive {0} to {1}", fileName, text);
				File.Move(fileName, text);
			}
			text = fileName;
		}
	}
}
