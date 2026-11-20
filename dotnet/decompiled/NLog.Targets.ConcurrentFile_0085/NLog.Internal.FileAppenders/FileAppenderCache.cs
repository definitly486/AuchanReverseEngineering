using System;
using System.IO;
using System.Threading;
using NLog.Common;
using NLog.Time;

namespace NLog.Internal.FileAppenders;

internal sealed class FileAppenderCache : IFileAppenderCache, IDisposable
{
	private readonly BaseFileAppender[] _appenders;

	private Timer _autoClosingTimer;

	private string _archiveFilePatternToWatch;

	private readonly NLog.Internal.MultiFileWatcher _externalFileArchivingWatcher = new NLog.Internal.MultiFileWatcher(NotifyFilters.FileName | NotifyFilters.DirectoryName);

	private bool _logFileWasArchived;

	public static readonly FileAppenderCache Empty = new FileAppenderCache();

	public string ArchiveFilePatternToWatch
	{
		set
		{
			if (_archiveFilePatternToWatch != value)
			{
				if (!string.IsNullOrEmpty(_archiveFilePatternToWatch))
				{
					_externalFileArchivingWatcher.StopWatching(_archiveFilePatternToWatch);
				}
				_archiveFilePatternToWatch = value;
				_logFileWasArchived = false;
			}
		}
	}

	public ICreateFileParameters CreateFileParameters { get; private set; }

	public IFileAppenderFactory Factory { get; private set; }

	public int Size { get; private set; }

	public event EventHandler CheckCloseAppenders;

	private FileAppenderCache()
		: this(0, null, null)
	{
	}

	public FileAppenderCache(int size, IFileAppenderFactory appenderFactory, ICreateFileParameters createFileParams)
	{
		Size = size;
		Factory = appenderFactory;
		CreateFileParameters = createFileParams;
		_appenders = new BaseFileAppender[Size];
		_autoClosingTimer = new Timer(AutoClosingTimerCallback, null, -1, -1);
		_externalFileArchivingWatcher.FileChanged += ExternalFileArchivingWatcher_OnFileChanged;
	}

	private void ExternalFileArchivingWatcher_OnFileChanged(object sender, FileSystemEventArgs e)
	{
		if (!_logFileWasArchived && this.CheckCloseAppenders != null && _autoClosingTimer != null)
		{
			if ((e.ChangeType & (WatcherChangeTypes.Deleted | WatcherChangeTypes.Renamed)) != 0)
			{
				_logFileWasArchived = true;
			}
			else if ((e.ChangeType & WatcherChangeTypes.Created) != 0 && FileArchiveFolderChanged(e.FullPath))
			{
				_logFileWasArchived = true;
			}
			if (_logFileWasArchived)
			{
				_autoClosingTimer?.Change(50, -1);
			}
		}
	}

	private bool FileArchiveFolderChanged(string fullPath)
	{
		if (!string.IsNullOrEmpty(_archiveFilePatternToWatch) && !string.IsNullOrEmpty(fullPath))
		{
			string directoryName = Path.GetDirectoryName(_archiveFilePatternToWatch);
			string directoryName2 = Path.GetDirectoryName(fullPath);
			if (!string.IsNullOrEmpty(directoryName) && !string.IsNullOrEmpty(directoryName2))
			{
				return string.Equals(Path.GetFullPath(directoryName), Path.GetFullPath(directoryName2), StringComparison.OrdinalIgnoreCase);
			}
		}
		return false;
	}

	public void InvalidateAppendersForArchivedFiles()
	{
		if (_logFileWasArchived)
		{
			_logFileWasArchived = false;
			InternalLogger.Trace("{0}: Invalidate archived files", CreateFileParameters);
			CloseAppenders("Cleanup Archive");
		}
	}

	private void AutoClosingTimerCallback(object state)
	{
		this.CheckCloseAppenders?.Invoke(this, EventArgs.Empty);
	}

	public BaseFileAppender AllocateAppender(string fileName)
	{
		BaseFileAppender baseFileAppender = null;
		int freeSpot = _appenders.Length - 1;
		for (int i = 0; i < _appenders.Length; i++)
		{
			if (_appenders[i] == null)
			{
				freeSpot = i;
				break;
			}
			if (!string.Equals(_appenders[i].FileName, fileName, StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			BaseFileAppender baseFileAppender2 = _appenders[i];
			if (i > 0)
			{
				for (int num = i; num > 0; num--)
				{
					_appenders[num] = _appenders[num - 1];
				}
				_appenders[0] = baseFileAppender2;
			}
			baseFileAppender = baseFileAppender2;
			break;
		}
		if (baseFileAppender == null)
		{
			baseFileAppender = CreateAppender(fileName, freeSpot);
		}
		return baseFileAppender;
	}

	private BaseFileAppender CreateAppender(string fileName, int freeSpot)
	{
		BaseFileAppender baseFileAppender2;
		try
		{
			InternalLogger.Debug("{0}: Creating file appender: '{1}'", CreateFileParameters, fileName);
			BaseFileAppender baseFileAppender = Factory.Open(fileName, CreateFileParameters);
			if (_appenders[freeSpot] != null)
			{
				CloseAppender(_appenders[freeSpot], "Stale", lastAppender: false);
				_appenders[freeSpot] = null;
			}
			for (int num = freeSpot; num > 0; num--)
			{
				_appenders[num] = _appenders[num - 1];
			}
			_appenders[0] = baseFileAppender;
			baseFileAppender2 = baseFileAppender;
			if (this.CheckCloseAppenders != null)
			{
				if (freeSpot == 0)
				{
					_logFileWasArchived = false;
				}
				if (!string.IsNullOrEmpty(_archiveFilePatternToWatch))
				{
					string directoryName = Path.GetDirectoryName(_archiveFilePatternToWatch);
					if (!string.IsNullOrEmpty(directoryName))
					{
						if (!Directory.Exists(directoryName))
						{
							Directory.CreateDirectory(directoryName);
						}
						_externalFileArchivingWatcher.Watch(_archiveFilePatternToWatch);
					}
				}
				_externalFileArchivingWatcher.Watch(baseFileAppender2.FileName);
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "{0}: Failed to create file appender: {1}", CreateFileParameters, fileName);
			throw;
		}
		return baseFileAppender2;
	}

	public void CloseAppenders(string reason)
	{
		CloseAllAppenders(0, reason);
	}

	private void CloseAllAppenders(int startIndex, string reason)
	{
		for (int i = startIndex; i < _appenders.Length; i++)
		{
			BaseFileAppender baseFileAppender = _appenders[i];
			if (baseFileAppender != null)
			{
				CloseAppender(baseFileAppender, reason, i == 0);
				_appenders[i] = null;
				baseFileAppender.Dispose();
				continue;
			}
			break;
		}
	}

	public void CloseExpiredAppenders(DateTime expireTimeUtc)
	{
		if (_logFileWasArchived)
		{
			_logFileWasArchived = false;
			CloseAppenders("Cleanup Timer");
		}
		else
		{
			if (!(expireTimeUtc != DateTime.MinValue))
			{
				return;
			}
			for (int i = 0; i < _appenders.Length && _appenders[i] != null; i++)
			{
				if (_appenders[i].OpenTimeUtc < expireTimeUtc)
				{
					CloseAllAppenders(i, "Expired");
					break;
				}
			}
		}
	}

	public void FlushAppenders()
	{
		BaseFileAppender[] appenders = _appenders;
		foreach (BaseFileAppender baseFileAppender in appenders)
		{
			if (baseFileAppender != null)
			{
				try
				{
					baseFileAppender.Flush();
				}
				catch (Exception ex)
				{
					InternalLogger.Error(ex, "{0}: Failed to flush file '{1}'.", CreateFileParameters, baseFileAppender.FileName);
					InvalidateAppender(baseFileAppender.FileName)?.Dispose();
					throw;
				}
				continue;
			}
			break;
		}
	}

	private BaseFileAppender GetAppender(string fileName)
	{
		for (int i = 0; i < _appenders.Length; i++)
		{
			BaseFileAppender baseFileAppender = _appenders[i];
			if (baseFileAppender == null)
			{
				break;
			}
			if (string.Equals(baseFileAppender.FileName, fileName, StringComparison.OrdinalIgnoreCase))
			{
				return baseFileAppender;
			}
		}
		return null;
	}

	public DateTime? GetFileCreationTimeSource(string filePath, DateTime? fallbackTimeSource = null)
	{
		BaseFileAppender appender = GetAppender(filePath);
		DateTime? result = null;
		if (appender != null)
		{
			try
			{
				result = appender.GetFileCreationTimeUtc();
				if (result.HasValue)
				{
					DateTime creationTimeUtc = appender.CreationTimeUtc;
					if (result.Value != creationTimeUtc)
					{
						appender.CreationTimeUtc = result.Value;
					}
					return appender.CreationTimeSource;
				}
			}
			catch (Exception ex)
			{
				InternalLogger.Error(ex, "{0}: Failed to get file creation time for file '{1}'.", CreateFileParameters, appender.FileName);
				InvalidateAppender(appender.FileName)?.Dispose();
				throw;
			}
		}
		FileInfo fileInfo = new FileInfo(filePath);
		if (fileInfo.Exists)
		{
			result = fileInfo.LookupValidFileCreationTimeUtc(fallbackTimeSource);
			return TimeSource.Current.FromSystemTime(result.Value);
		}
		return result;
	}

	public DateTime? GetFileLastWriteTimeUtc(string filePath)
	{
		FileInfo fileInfo = new FileInfo(filePath);
		if (fileInfo.Exists)
		{
			return fileInfo.GetLastWriteTimeUtc();
		}
		return null;
	}

	public long? GetFileLength(string filePath)
	{
		BaseFileAppender appender = GetAppender(filePath);
		if (appender != null)
		{
			try
			{
				long? fileLength = appender.GetFileLength();
				if (fileLength.HasValue)
				{
					return fileLength;
				}
			}
			catch (IOException ex)
			{
				InternalLogger.Error(ex, "{0}: Failed to get length for file '{1}'.", CreateFileParameters, appender.FileName);
				InvalidateAppender(appender.FileName)?.Dispose();
			}
			catch (Exception ex2)
			{
				InternalLogger.Error(ex2, "{0}: Failed to get length for file '{1}'.", CreateFileParameters, appender.FileName);
				InvalidateAppender(appender.FileName)?.Dispose();
				throw;
			}
		}
		FileInfo fileInfo = new FileInfo(filePath);
		if (fileInfo.Exists)
		{
			return fileInfo.Length;
		}
		return null;
	}

	public BaseFileAppender InvalidateAppender(string filePath)
	{
		for (int i = 0; i < _appenders.Length; i++)
		{
			BaseFileAppender baseFileAppender = _appenders[i];
			if (baseFileAppender == null)
			{
				break;
			}
			if (string.Equals(baseFileAppender.FileName, filePath, StringComparison.OrdinalIgnoreCase))
			{
				for (int j = i; j < _appenders.Length - 1; j++)
				{
					_appenders[j] = _appenders[j + 1];
				}
				_appenders[_appenders.Length - 1] = null;
				CloseAppender(baseFileAppender, "Invalidate", _appenders[0] == null);
				return baseFileAppender;
			}
		}
		return null;
	}

	private void CloseAppender(BaseFileAppender appender, string reason, bool lastAppender)
	{
		InternalLogger.Debug("{0}: FileAppender {1} Closing File: '{2}'", CreateFileParameters, reason, appender.FileName);
		if (lastAppender)
		{
			_autoClosingTimer.Change(-1, -1);
			_externalFileArchivingWatcher.StopWatching();
			_logFileWasArchived = false;
		}
		else
		{
			_externalFileArchivingWatcher.StopWatching(appender.FileName);
		}
		appender.Close();
	}

	public void Dispose()
	{
		this.CheckCloseAppenders = null;
		_externalFileArchivingWatcher.Dispose();
		_logFileWasArchived = false;
		Timer autoClosingTimer = _autoClosingTimer;
		if (autoClosingTimer != null)
		{
			_autoClosingTimer = null;
			autoClosingTimer.Dispose();
		}
	}
}
