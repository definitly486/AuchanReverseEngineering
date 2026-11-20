using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using NLog.Common;
using NLog.Internal;
using NLog.Time;

namespace NLog.Targets.FileArchiveHandlers;

internal class BaseFileArchiveHandler
{
	private readonly struct FileInfoDateTime : IComparer<FileInfoDateTime>
	{
		public FileInfo FileInfo { get; }

		public DateTime FileCreatedTimeUtc { get; }

		public int? ArchiveSequenceNumber { get; }

		public FileInfoDateTime(FileInfo fileInfo, DateTime fileCreatedTimeUtc, int? archiveSequenceNumber = null)
		{
			FileInfo = fileInfo;
			ArchiveSequenceNumber = archiveSequenceNumber;
			FileCreatedTimeUtc = fileCreatedTimeUtc;
		}

		public int Compare(FileInfoDateTime x, FileInfoDateTime y)
		{
			if (x.ArchiveSequenceNumber.HasValue && y.ArchiveSequenceNumber.HasValue)
			{
				return x.ArchiveSequenceNumber.Value.CompareTo(y.ArchiveSequenceNumber.Value);
			}
			if (x.FileCreatedTimeUtc == y.FileCreatedTimeUtc)
			{
				return StringComparer.OrdinalIgnoreCase.Compare(x.FileInfo.Name, y.FileInfo.Name);
			}
			return x.FileCreatedTimeUtc.CompareTo(y.FileCreatedTimeUtc);
		}

		public override string ToString()
		{
			return FileInfo.Name;
		}

		public static int? ScanFileNamesForMaxSequenceNo(FileInfo[] fileInfos, int fileWildcardStartIndex, int fileWildcardEndIndex)
		{
			int? result = null;
			for (int i = 0; i < fileInfos.Length; i++)
			{
				string name = fileInfos[i].Name;
				if (!ExcludeFileName(name, fileWildcardStartIndex, fileWildcardEndIndex, null) && TryParseStartSequenceNumber(name, fileWildcardStartIndex, out var archiveSequenceNo) && (!result.HasValue || archiveSequenceNo > result.Value))
				{
					result = archiveSequenceNo;
				}
			}
			return result;
		}

		public static IEnumerable<FileInfo> CleanupFiles(FileInfo[] fileInfos, int maxArchiveFiles, int maxArchiveDays, int fileWildcardStartIndex, int fileWildcardEndIndex, string? excludeFileName = null, bool wildCardContainsSeqNo = false)
		{
			if (fileInfos.Length <= 1)
			{
				if (maxArchiveFiles == 0 && fileInfos.Length == 1 && !ExcludeFileName(fileInfos[0].Name, fileWildcardStartIndex, fileWildcardEndIndex, excludeFileName))
				{
					yield return fileInfos[0];
				}
			}
			else
			{
				if (maxArchiveFiles >= fileInfos.Length && maxArchiveDays <= 0)
				{
					yield break;
				}
				List<FileInfoDateTime> fileInfoDates = new List<FileInfoDateTime>(fileInfos.Length);
				foreach (FileInfo fileInfo in fileInfos)
				{
					string name = fileInfo.Name;
					if (!ExcludeFileName(name, fileWildcardStartIndex, fileWildcardEndIndex, excludeFileName))
					{
						DateTime date = (fileInfo.LookupValidFileCreationTimeUtc() ?? TimeSource.Current.Time).Date;
						if (wildCardContainsSeqNo && TryParseStartSequenceNumber(name, fileWildcardStartIndex, out var archiveSequenceNo))
						{
							fileInfoDates.Add(new FileInfoDateTime(fileInfo, date, archiveSequenceNo));
						}
						else
						{
							fileInfoDates.Add(new FileInfoDateTime(fileInfo, date));
						}
					}
				}
				fileInfoDates.Sort((FileInfoDateTime x, FileInfoDateTime y) => x.Compare(x, y));
				for (int i2 = 0; i2 < fileInfoDates.Count && ShouldDeleteFile(fileInfoDates[i2], fileInfoDates.Count - i2, maxArchiveFiles, maxArchiveDays); i2++)
				{
					yield return fileInfoDates[i2].FileInfo;
				}
			}
		}

		private static bool ExcludeFileName(string fileName, int fileWildcardStartIndex, int fileWildcardEndIndex, string? excludeFileName)
		{
			if (fileWildcardStartIndex >= 0 && fileWildcardEndIndex >= 0 && fileName.Length > fileWildcardEndIndex)
			{
				for (int i = fileWildcardStartIndex; i < fileName.Length - fileWildcardEndIndex; i++)
				{
					if (char.IsLetter(fileName[i]))
					{
						return true;
					}
				}
			}
			if (excludeFileName == null)
			{
				return false;
			}
			return string.Equals(fileName, excludeFileName, StringComparison.OrdinalIgnoreCase);
		}

		private static bool ShouldDeleteFile(FileInfoDateTime existingArchiveFile, int remainingFileCount, int maxArchiveFiles, int maxArchiveDays)
		{
			if (maxArchiveFiles >= 0 && remainingFileCount > maxArchiveFiles)
			{
				return true;
			}
			if (maxArchiveDays > 0)
			{
				DateTime date = TimeSource.Current.Time.Date;
				double totalDays = (date - TimeSource.Current.FromSystemTime(existingArchiveFile.FileCreatedTimeUtc).Date).TotalDays;
				if (totalDays > (double)maxArchiveDays)
				{
					InternalLogger.Debug("FileTarget: Detected old file in archive. FileName={0}, FileDateUtc={1:u}, CurrentDateUtc={2:u}, Age={3} days", new ReadOnlySpan<object>(new object[4]
					{
						existingArchiveFile.FileInfo.FullName,
						existingArchiveFile.FileCreatedTimeUtc,
						date,
						Math.Round(totalDays, 1)
					}));
					return true;
				}
			}
			return false;
		}

		private static bool TryParseStartSequenceNumber(string archiveFileName, int seqStartIndex, out int archiveSequenceNo)
		{
			int? num = null;
			for (int i = seqStartIndex; i < archiveFileName.Length; i++)
			{
				char c = archiveFileName[i];
				if (!char.IsNumber(c))
				{
					break;
				}
				num = ((num > 0) ? (num * 10) : new int?(0)) + (c - 48);
			}
			archiveSequenceNo = num.GetValueOrDefault();
			return num.HasValue;
		}
	}

	protected readonly FileTarget _fileTarget;

	public BaseFileArchiveHandler(FileTarget fileTarget)
	{
		_fileTarget = fileTarget;
	}

	protected bool DeleteOldFilesBeforeArchive(string filePath, bool initialFileOpen, string? excludeFileName = null)
	{
		string directoryName = Path.GetDirectoryName(filePath);
		string fileNameWildcard = GetFileNameWildcard(filePath);
		return DeleteOldFilesBeforeArchive(directoryName, fileNameWildcard, initialFileOpen, excludeFileName);
	}

	protected bool DeleteOldFilesBeforeArchive(string fileDirectory, string fileWildcard, bool initialFileOpen, string? excludeFileName = null, bool wildCardContainsSeqNo = false)
	{
		try
		{
			if (string.IsNullOrEmpty(fileWildcard))
			{
				return false;
			}
			if (string.IsNullOrEmpty(fileDirectory))
			{
				return false;
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(fileDirectory);
			if (!directoryInfo.Exists)
			{
				return false;
			}
			FileInfo[] files = directoryInfo.GetFiles(fileWildcard);
			InternalLogger.Debug("{0}: Archive Cleanup found {1} files matching wildcard {2} in directory: {3}", new ReadOnlySpan<object>(new object[4] { _fileTarget, files.Length, fileWildcard, fileDirectory }));
			if (files.Length != 0)
			{
				int num = fileWildcard.IndexOf('*');
				int fileWildcardEndIndex = fileWildcard.Length - num;
				int num2 = _fileTarget.MaxArchiveFiles;
				if (initialFileOpen && (!_fileTarget.ArchiveOldFileOnStartup || _fileTarget.DeleteOldFileOnStartup))
				{
					num2 = ((!_fileTarget.DeleteOldFileOnStartup) ? num2 : 0);
				}
				else if (num2 > 0)
				{
					num2--;
				}
				bool result = false;
				foreach (FileInfo item in FileInfoDateTime.CleanupFiles(files, num2, _fileTarget.MaxArchiveDays, num, fileWildcardEndIndex, excludeFileName, wildCardContainsSeqNo))
				{
					result = true;
					DeleteOldArchiveFile(item.FullName);
				}
				return result;
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "{0}: Failed to cleanup archive folder: {1}  {2}", new ReadOnlySpan<object>(new object[3]
			{
				_fileTarget,
				fileDirectory,
				fileWildcard ?? ""
			}));
			if (ex.MustBeRethrown(_fileTarget))
			{
				throw;
			}
		}
		return false;
	}

	protected static int? GetMaxArchiveSequenceNo(FileInfo[] fileInfos, int fileWildcardStartIndex, int fileWildcardEndIndex)
	{
		return FileInfoDateTime.ScanFileNamesForMaxSequenceNo(fileInfos, fileWildcardStartIndex, fileWildcardEndIndex);
	}

	private static string GetFileNameWildcard(string filepath)
	{
		string text = Path.GetFileNameWithoutExtension(filepath) ?? string.Empty;
		string text2 = Path.GetExtension(filepath) ?? string.Empty;
		if (string.IsNullOrEmpty(text) && string.IsNullOrEmpty(text2))
		{
			return string.Empty;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		for (int i = 0; i < text.Length; i++)
		{
			if (!char.IsLetter(text[i]))
			{
				if (num3 == 0)
				{
					num4 = i;
				}
				num3++;
			}
			else if (num3 != 0)
			{
				if (num2 <= num3)
				{
					num = num4;
					num2 = num3;
				}
				num3 = 0;
			}
		}
		if (num2 < num3)
		{
			num = num4;
			num2 = num3;
		}
		if (num2 > 0)
		{
			string text3 = text.Substring(0, num);
			string text4 = text.Substring(num + num2, text.Length - num - num2);
			if (!string.IsNullOrEmpty(text4))
			{
				return text3 + "*" + text4 + "*" + text2;
			}
			return text3 + "*" + text2;
		}
		return text + "*" + text2;
	}

	protected bool DeleteOldArchiveFile(string filepath)
	{
		for (int i = 1; i <= 3; i++)
		{
			try
			{
				InternalLogger.Info("{0}: Deleting old archive file: '{1}'.", _fileTarget, filepath);
				_fileTarget.CloseOpenFileBeforeArchiveCleanup(filepath);
				File.Delete(filepath);
				return true;
			}
			catch (DirectoryNotFoundException ex)
			{
				InternalLogger.Debug(ex, "{0}: Failed to delete old file as directory not found: '{1}'", new ReadOnlySpan<object>(new object[2] { _fileTarget, filepath }));
				return true;
			}
			catch (FileNotFoundException ex2)
			{
				InternalLogger.Debug(ex2, "{0}: Failed to delete old file as file not found: '{1}'", new ReadOnlySpan<object>(new object[2] { _fileTarget, filepath }));
				return true;
			}
			catch (IOException ex3)
			{
				InternalLogger.Debug(ex3, "{0}: Failed to delete old file, maybe file is locked: '{1}'", new ReadOnlySpan<object>(new object[2] { _fileTarget, filepath }));
				if (!File.Exists(filepath))
				{
					return true;
				}
				if (i >= 3 && ex3.MustBeRethrown(_fileTarget))
				{
					throw;
				}
			}
			catch (Exception ex4)
			{
				InternalLogger.Warn(ex4, "{0}: Failed to delete old archive file: '{1}'.", new ReadOnlySpan<object>(new object[2] { _fileTarget, filepath }));
				if (ex4.MustBeRethrown(_fileTarget))
				{
					throw;
				}
				return false;
			}
			Thread.Sleep(i * 10);
		}
		return false;
	}

	protected void FixWindowsFileSystemTunneling(string newFilePath)
	{
		try
		{
			if (PlatformDetector.IsWin32 && !File.Exists(newFilePath))
			{
				File.Create(newFilePath).Dispose();
				File.SetCreationTimeUtc(newFilePath, DateTime.UtcNow);
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Debug(ex, "{0}: Failed to refresh CreationTimeUtc for FileName: {1}", new ReadOnlySpan<object>(new object[2] { _fileTarget, newFilePath }));
		}
	}
}
