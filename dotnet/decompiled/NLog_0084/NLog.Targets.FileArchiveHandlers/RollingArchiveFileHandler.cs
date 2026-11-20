using System;
using System.IO;
using NLog.Common;
using NLog.Internal;

namespace NLog.Targets.FileArchiveHandlers;

internal class RollingArchiveFileHandler : BaseFileArchiveHandler, IFileArchiveHandler
{
	public RollingArchiveFileHandler(FileTarget fileTarget)
		: base(fileTarget)
	{
	}

	public virtual int ArchiveBeforeOpenFile(string newFileName, LogEventInfo firstLogEvent, DateTime? previousFileLastModified, int newSequenceNumber)
	{
		bool flag = newSequenceNumber == 0;
		if (_fileTarget.MaxArchiveFiles >= 0 || _fileTarget.MaxArchiveDays > 0 || (flag && _fileTarget.DeleteOldFileOnStartup))
		{
			string text = FileTarget.CleanFullFilePath(newFileName);
			bool flag2 = DeleteOldFilesBeforeArchive(text, flag);
			if (_fileTarget.MaxArchiveFiles == 0 || _fileTarget.MaxArchiveFiles == 1 || (flag && _fileTarget.DeleteOldFileOnStartup))
			{
				if (flag2)
				{
					FixWindowsFileSystemTunneling(text);
				}
				return 0;
			}
		}
		if (flag && (_fileTarget.ArchiveOldFileOnStartup || _fileTarget.ArchiveAboveSize != 0L || _fileTarget.ArchiveEvery != FileArchivePeriod.None))
		{
			string newFilePath = FileTarget.CleanFullFilePath(newFileName);
			return RollToInitialSequenceNumber(newFilePath);
		}
		return newSequenceNumber;
	}

	private int RollToInitialSequenceNumber(string newFilePath)
	{
		int num = 0;
		try
		{
			string directoryName = Path.GetDirectoryName(newFilePath);
			if (string.IsNullOrEmpty(directoryName))
			{
				return 0;
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
			if (!directoryInfo.Exists)
			{
				return 0;
			}
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(newFilePath);
			string extension = Path.GetExtension(newFilePath);
			string text = fileNameWithoutExtension + "*" + extension;
			FileInfo[] files = directoryInfo.GetFiles(text);
			InternalLogger.Debug("{0}: Archive Sequence Rolling found {1} files matching wildcard {2} in directory: {3}", new ReadOnlySpan<object>(new object[4] { _fileTarget, files.Length, text, directoryName }));
			if (files.Length == 0)
			{
				return 0;
			}
			if (_fileTarget.DeleteOldFileOnStartup)
			{
				FileInfo[] array = files;
				foreach (FileInfo fileInfo in array)
				{
					DeleteOldArchiveFile(fileInfo.FullName);
				}
				return 0;
			}
			string fileName = Path.GetFileName(_fileTarget.BuildFullFilePath(newFilePath, int.MaxValue, DateTime.MinValue).Replace(int.MaxValue.ToString(), "*"));
			int num2 = fileName.IndexOf('*');
			int fileWildcardEndIndex = ((num2 >= 0) ? (fileName.Length - num2) : fileNameWithoutExtension.Length);
			num = BaseFileArchiveHandler.GetMaxArchiveSequenceNo(files, num2, fileWildcardEndIndex).GetValueOrDefault();
			if (_fileTarget.ArchiveOldFileOnStartup)
			{
				num++;
			}
			return num;
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "{0}: Failed to resolve initial archive sequence number for file: {1}", new ReadOnlySpan<object>(new object[2] { _fileTarget, newFilePath }));
			if (ex.MustBeRethrown(_fileTarget))
			{
				throw;
			}
			return num;
		}
	}
}
