using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using NLog.Common;
using NLog.Internal;
using NLog.Internal.FileAppenders;
using NLog.Layouts;
using NLog.Targets.FileArchiveModes;
using NLog.Time;

namespace NLog.Targets;

[Target("File")]
public class ConcurrentFileTarget : TargetWithLayoutHeaderAndFooter, ICreateFileParameters
{
	private readonly Dictionary<string, DateTime> _initializedFiles = new Dictionary<string, DateTime>(StringComparer.OrdinalIgnoreCase);

	private IFileAppenderCache _fileAppenderCache;

	private IFileArchiveMode _fileArchiveHelper;

	private Timer _autoClosingTimer;

	private int _initializedFilesCounter;

	private int _maxArchiveFiles;

	private int _maxArchiveDays;

	private FilePathLayout _fullFileName;

	private FilePathLayout _fullArchiveFileName;

	private FileArchiveEveryPeriod _archiveEvery;

	private long _archiveAboveSize;

	private bool _enableArchiveFileCompression;

	private DateTime? _previousLogEventTimestamp;

	private string _previousLogFileName;

	private bool _concurrentWrites;

	private bool _cleanupFileName;

	private FilePathKind _fileNameKind;

	private bool _keepFileOpen = true;

	private Win32FileAttributes _fileAttributes = Win32FileAttributes.Normal;

	private Encoding _encoding = Encoding.UTF8;

	private bool? _writeBom;

	private int? _concurrentWriteAttempts;

	private bool? _archiveOldFileOnStartup;

	private string _archiveDateFormat = string.Empty;

	private ArchiveNumberingMode _archiveNumbering;

	[CompilerGenerated]
	private bool _003CForceManaged_003Ek__BackingField = true;

	private readonly NLog.Internal.ReusableBuilderCreator _reusableLayoutBuilder = new NLog.Internal.ReusableBuilderCreator();

	private readonly NLog.Internal.ReusableStreamCreator _reusableFileWriteStream = new NLog.Internal.ReusableStreamCreator();

	private readonly NLog.Internal.ReusableStreamCreator _reusableBatchFileWriteStream = new NLog.Internal.ReusableStreamCreator(batchStream: true);

	private readonly NLog.Internal.ReusableBufferCreator _reusableEncodingBuffer = new NLog.Internal.ReusableBufferCreator(1024);

	private NLog.Internal.SortHelpers.KeySelector<AsyncLogEventInfo, string> _getFullFileNameDelegate;

	public Layout FileName
	{
		get
		{
			return _fullFileName?.GetLayout() ?? NLog.Layouts.Layout.Empty;
		}
		set
		{
			_fullFileName = CreateFileNameLayout(value);
			ResetFileAppenders("FileName Changed");
		}
	}

	public bool CleanupFileName => _cleanupFileName;

	public FilePathKind FileNameKind => _fileNameKind;

	public bool CreateDirs { get; } = true;

	public bool DeleteOldFileOnStartup { get; }

	public bool ReplaceFileContentsOnEachWrite { get; }

	public bool KeepFileOpen
	{
		get
		{
			return _keepFileOpen;
		}
		set
		{
			if (_keepFileOpen != value)
			{
				_keepFileOpen = value;
				ResetFileAppenders("KeepFileOpen Changed");
			}
		}
	}

	public bool EnableFileDelete { get; } = true;

	bool ICreateFileParameters.IsArchivingEnabled => IsArchivingEnabled;

	int ICreateFileParameters.FileOpenRetryCount
	{
		get
		{
			if (!ConcurrentWrites)
			{
				if (!KeepFileOpen)
				{
					return _concurrentWriteAttempts ?? 2;
				}
				return 0;
			}
			return ConcurrentWriteAttempts;
		}
	}

	int ICreateFileParameters.FileOpenRetryDelay => ConcurrentWriteAttemptDelay;

	public LineEndingMode LineEnding { get; } = LineEndingMode.Default;

	public bool AutoFlush { get; } = true;

	public int OpenFileCacheSize { get; } = 5;

	public int OpenFileCacheTimeout { get; }

	public int OpenFileFlushTimeout { get; }

	public int BufferSize { get; } = 32768;

	public Encoding Encoding => _encoding;

	public bool DiscardAll { get; }

	public bool ConcurrentWrites
	{
		get
		{
			return _concurrentWrites;
		}
		set
		{
			if (_concurrentWrites != value)
			{
				_concurrentWrites = value;
				ResetFileAppenders("ConcurrentWrites Changed");
			}
		}
	}

	public bool WriteBom => _writeBom == true;

	public int ConcurrentWriteAttempts => _concurrentWriteAttempts ?? 10;

	public int ConcurrentWriteAttemptDelay { get; } = 1;

	public bool WriteHeaderWhenInitialFileNotEmpty { get; }

	public long ArchiveOldFileOnStartupAboveSize { get; }

	public string ArchiveDateFormat => _archiveDateFormat;

	public long ArchiveAboveSize
	{
		get
		{
			return _archiveAboveSize;
		}
		set
		{
			long num = ((value > 0) ? value : (-1));
			if (_archiveAboveSize > 0 != num > 0)
			{
				_archiveAboveSize = num;
				ResetFileAppenders("ArchiveAboveSize Changed");
			}
			else
			{
				_archiveAboveSize = num;
			}
		}
	}

	public FileArchiveEveryPeriod ArchiveEvery
	{
		get
		{
			return _archiveEvery;
		}
		set
		{
			if (_archiveEvery != value)
			{
				_archiveEvery = value;
				ResetFileAppenders("ArchiveEvery Changed");
			}
		}
	}

	public Layout ArchiveFileName => _fullArchiveFileName?.GetLayout();

	public int MaxArchiveFiles
	{
		get
		{
			return _maxArchiveFiles;
		}
		set
		{
			if (_maxArchiveFiles != value)
			{
				_maxArchiveFiles = value;
				ResetFileAppenders("MaxArchiveFiles Changed");
			}
		}
	}

	public int MaxArchiveDays => _maxArchiveDays;

	public ArchiveNumberingMode ArchiveNumbering
	{
		get
		{
			return _archiveNumbering;
		}
		set
		{
			if (_archiveNumbering != value)
			{
				_archiveNumbering = value;
				ResetFileAppenders("ArchiveNumbering Changed");
			}
		}
	}

	public static IFileCompressor FileCompressor { get; } = new ZipArchiveFileCompressor();

	public bool EnableArchiveFileCompression
	{
		get
		{
			if (_enableArchiveFileCompression)
			{
				return FileCompressor != null;
			}
			return false;
		}
		set
		{
			if (_enableArchiveFileCompression != value)
			{
				_enableArchiveFileCompression = value;
				ResetFileAppenders("EnableArchiveFileCompression Changed");
			}
		}
	}

	public bool ForceMutexConcurrentWrites { get; }

	public bool WriteFooterOnArchivingOnly { get; }

	protected internal string NewLineChars => LineEnding.NewLineCharacters;

	private bool IsArchivingEnabled
	{
		get
		{
			if (ArchiveAboveSize == -1)
			{
				return ArchiveEvery != FileArchiveEveryPeriod.None;
			}
			return true;
		}
	}

	private bool IsSimpleKeepFileOpen
	{
		get
		{
			if (KeepFileOpen && !ConcurrentWrites)
			{
				return !ReplaceFileContentsOnEachWrite;
			}
			return false;
		}
	}

	private bool EnableFileDeleteSimpleMonitor
	{
		get
		{
			if (EnableFileDelete)
			{
				return IsSimpleKeepFileOpen;
			}
			return false;
		}
	}

	bool ICreateFileParameters.EnableFileDeleteSimpleMonitor => EnableFileDeleteSimpleMonitor;

	private IFileArchiveMode GetFileArchiveHelper(string archiveFilePattern)
	{
		return _fileArchiveHelper ?? (_fileArchiveHelper = FileArchiveModeFactory.CreateArchiveStyle(archiveFilePattern, ArchiveNumbering, GetArchiveDateFormatString(ArchiveDateFormat), ArchiveFileName != null, MaxArchiveFiles > 0 || MaxArchiveDays > 0));
	}

	public ConcurrentFileTarget()
		: this(FileAppenderCache.Empty)
	{
	}

	internal ConcurrentFileTarget(IFileAppenderCache fileAppenderCache)
	{
		ArchiveNumbering = ArchiveNumberingMode.Sequence;
		_maxArchiveFiles = 0;
		_maxArchiveDays = 0;
		ArchiveEvery = FileArchiveEveryPeriod.None;
		ArchiveAboveSize = -1L;
		_cleanupFileName = true;
		_fileAppenderCache = fileAppenderCache;
	}

	private FilePathLayout CreateFileNameLayout(Layout value)
	{
		if (value == null)
		{
			return null;
		}
		return new FilePathLayout(value, CleanupFileName, FileNameKind);
	}

	private void RefreshArchiveFilePatternToWatch(string fileName, LogEventInfo logEvent)
	{
		_fileAppenderCache.CheckCloseAppenders -= AutoCloseAppendersAfterArchive;
		bool num = IsArchivingEnabled && KeepFileOpen && ConcurrentWrites;
		bool flag = EnableFileDelete && ((KeepFileOpen && ConcurrentWrites) || (IsSimpleKeepFileOpen && !EnableFileDeleteSimpleMonitor));
		if (num || flag)
		{
			_fileAppenderCache.CheckCloseAppenders += AutoCloseAppendersAfterArchive;
		}
		if (num)
		{
			string archiveFileNamePattern = GetArchiveFileNamePattern(fileName, logEvent);
			string text = ((((!string.IsNullOrEmpty(archiveFileNamePattern)) ? GetFileArchiveHelper(archiveFileNamePattern) : null) != null) ? _fileArchiveHelper.GenerateFileNameMask(archiveFileNamePattern) : string.Empty);
			string archiveFilePatternToWatch = ((!string.IsNullOrEmpty(text)) ? Path.Combine(Path.GetDirectoryName(archiveFileNamePattern), text) : string.Empty);
			_fileAppenderCache.ArchiveFilePatternToWatch = archiveFilePatternToWatch;
		}
		else
		{
			_fileAppenderCache.ArchiveFilePatternToWatch = null;
		}
	}

	public void CleanupInitializedFiles()
	{
		try
		{
			CleanupInitializedFiles(TimeSource.Current.Time.AddDays(-2.0));
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "{0}: Exception in CleanupInitializedFiles", this);
		}
	}

	public void CleanupInitializedFiles(DateTime cleanupThreshold)
	{
		InternalLogger.Trace("{0}: CleanupInitializedFiles with cleanupThreshold {1}", this, cleanupThreshold);
		List<string> list = null;
		foreach (KeyValuePair<string, DateTime> initializedFile in _initializedFiles)
		{
			if (initializedFile.Value < cleanupThreshold)
			{
				if (list == null)
				{
					list = new List<string>();
				}
				list.Add(initializedFile.Key);
			}
		}
		if (list != null)
		{
			foreach (string item in list)
			{
				FinalizeFile(item);
			}
		}
		InternalLogger.Trace("{0}: CleanupInitializedFiles Completed and finalized {0} files", this, list?.Count ?? 0);
	}

	protected override void FlushAsync(AsyncContinuation asyncContinuation)
	{
		try
		{
			InternalLogger.Trace("{0}: FlushAsync", this);
			_fileAppenderCache.FlushAppenders();
			asyncContinuation(null);
			InternalLogger.Trace("{0}: FlushAsync Done", this);
		}
		catch (Exception exception)
		{
			if (LogManager.ThrowExceptions)
			{
				throw;
			}
			asyncContinuation(exception);
		}
	}

	private IFileAppenderFactory GetFileAppenderFactory()
	{
		if (DiscardAll)
		{
			return NullAppender.TheFactory;
		}
		if (!KeepFileOpen)
		{
			return RetryingMultiProcessFileAppender.TheFactory;
		}
		if (ConcurrentWrites)
		{
			_ = ForceMutexConcurrentWrites;
			if (MutexDetector.SupportsSharableMutex)
			{
				return MutexMultiProcessFileAppender.TheFactory;
			}
			return RetryingMultiProcessFileAppender.TheFactory;
		}
		if (IsArchivingEnabled)
		{
			return CountingSingleProcessFileAppender.TheFactory;
		}
		return SingleProcessFileAppender.TheFactory;
	}

	protected override void InitializeTarget()
	{
		base.InitializeTarget();
		if (FileName == null || FileName == NLog.Layouts.Layout.Empty)
		{
			throw new NLogConfigurationException("FileTarget FileName-property must be assigned. FileName is needed for file writing.");
		}
		IFileAppenderFactory fileAppenderFactory = GetFileAppenderFactory();
		if (InternalLogger.IsTraceEnabled)
		{
			InternalLogger.Trace("{0}: Using appenderFactory: {1}", this, fileAppenderFactory.GetType());
		}
		_fileAppenderCache = new FileAppenderCache(OpenFileCacheSize, fileAppenderFactory, this);
		if ((OpenFileCacheSize > 0 || EnableFileDelete) && (OpenFileCacheTimeout > 0 || OpenFileFlushTimeout > 0))
		{
			int num = ((OpenFileCacheTimeout > 0 && OpenFileFlushTimeout > 0) ? Math.Min(OpenFileCacheTimeout, OpenFileFlushTimeout) : Math.Max(OpenFileCacheTimeout, OpenFileFlushTimeout));
			InternalLogger.Trace("{0}: Start autoClosingTimer", this);
			_autoClosingTimer = new Timer(delegate
			{
				AutoClosingTimerCallback(this, EventArgs.Empty);
			}, null, num * 1000, num * 1000);
		}
	}

	protected override void CloseTarget()
	{
		base.CloseTarget();
		foreach (string item in new List<string>(_initializedFiles.Keys))
		{
			FinalizeFile(item);
		}
		_fileArchiveHelper = null;
		Timer autoClosingTimer = _autoClosingTimer;
		if (autoClosingTimer != null)
		{
			InternalLogger.Trace("{0}: Stop autoClosingTimer", this);
			_autoClosingTimer = null;
			autoClosingTimer.Change(-1, -1);
			autoClosingTimer.Dispose();
		}
		_fileAppenderCache.CloseAppenders("Dispose");
		_fileAppenderCache.Dispose();
	}

	private void ResetFileAppenders(string reason)
	{
		_fileArchiveHelper = null;
		if (base.IsInitialized)
		{
			_fileAppenderCache.CloseAppenders(reason);
			_initializedFiles.Clear();
		}
	}

	protected override void Write(LogEventInfo logEvent)
	{
		string fullFileName = GetFullFileName(logEvent);
		if (string.IsNullOrEmpty(fullFileName))
		{
			throw new ArgumentException("The path is not of a legal form.");
		}
		NLog.Internal.ReusableObjectCreator<MemoryStream>.LockOject lockOject = _reusableBatchFileWriteStream.Allocate();
		try
		{
			NLog.Internal.ReusableObjectCreator<StringBuilder>.LockOject lockOject2 = _reusableLayoutBuilder.Allocate();
			try
			{
				NLog.Internal.ReusableObjectCreator<char[]>.LockOject lockOject3 = _reusableEncodingBuffer.Allocate();
				try
				{
					RenderFormattedMessageToStream(logEvent, lockOject2.Result, lockOject3.Result, lockOject.Result);
				}
				finally
				{
					((IDisposable)lockOject3/*cast due to .constrained prefix*/).Dispose();
				}
			}
			finally
			{
				((IDisposable)lockOject2/*cast due to .constrained prefix*/).Dispose();
			}
			ProcessLogEvent(logEvent, fullFileName, new ArraySegment<byte>(lockOject.Result.GetBuffer(), 0, (int)lockOject.Result.Length));
		}
		finally
		{
			((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
		}
	}

	internal string GetFullFileName(LogEventInfo logEvent)
	{
		if (_fullFileName == null)
		{
			return null;
		}
		if (_fullFileName.IsFixedFilePath)
		{
			return _fullFileName.Render(logEvent);
		}
		NLog.Internal.ReusableObjectCreator<StringBuilder>.LockOject lockOject = _reusableLayoutBuilder.Allocate();
		try
		{
			return _fullFileName.RenderWithBuilder(logEvent, lockOject.Result);
		}
		finally
		{
			((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
		}
	}

	protected override void Write(IList<AsyncLogEventInfo> logEvents)
	{
		if (_getFullFileNameDelegate == null)
		{
			_getFullFileNameDelegate = (AsyncLogEventInfo c) => GetFullFileName(c.LogEvent);
		}
		NLog.Internal.SortHelpers.ReadOnlySingleBucketGroupBy<string, IList<AsyncLogEventInfo>> readOnlySingleBucketGroupBy = logEvents.BucketSort(_getFullFileNameDelegate);
		NLog.Internal.ReusableObjectCreator<MemoryStream>.LockOject lockOject = _reusableBatchFileWriteStream.Allocate();
		try
		{
			MemoryStream memoryStream = lockOject.Result ?? new MemoryStream();
			foreach (KeyValuePair<string, IList<AsyncLogEventInfo>> item in readOnlySingleBucketGroupBy)
			{
				int count = item.Value.Count;
				if (count <= 0)
				{
					continue;
				}
				string key = item.Key;
				if (string.IsNullOrEmpty(key))
				{
					InternalLogger.Warn("{0}: FileName Layout returned empty string. The path is not of a legal form.", this);
					ArgumentException exception = new ArgumentException("The path is not of a legal form.");
					for (int num = 0; num < count; num++)
					{
						item.Value[num].Continuation(exception);
					}
					continue;
				}
				int num2 = 0;
				while (num2 < count)
				{
					memoryStream.Position = 0L;
					memoryStream.SetLength(0L);
					int num3 = WriteToMemoryStream(item.Value, num2, memoryStream);
					AppendMemoryStreamToFile(key, item.Value[num2].LogEvent, memoryStream, out var lastException);
					for (int num4 = 0; num4 < num3; num4++)
					{
						item.Value[num2++].Continuation(lastException);
					}
				}
			}
		}
		finally
		{
			((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
		}
	}

	private int WriteToMemoryStream(IList<AsyncLogEventInfo> logEvents, int startIndex, MemoryStream ms)
	{
		long num = BufferSize * 100;
		NLog.Internal.ReusableObjectCreator<MemoryStream>.LockOject lockOject = _reusableFileWriteStream.Allocate();
		try
		{
			NLog.Internal.ReusableObjectCreator<StringBuilder>.LockOject lockOject2 = _reusableLayoutBuilder.Allocate();
			try
			{
				NLog.Internal.ReusableObjectCreator<char[]>.LockOject lockOject3 = _reusableEncodingBuffer.Allocate();
				try
				{
					StringBuilder result = lockOject2.Result;
					char[] result2 = lockOject3.Result;
					MemoryStream result3 = lockOject.Result;
					for (int i = startIndex; i < logEvents.Count; i++)
					{
						result3.Position = 0L;
						result3.SetLength(0L);
						result.Length = 0;
						RenderFormattedMessageToStream(logEvents[i].LogEvent, result, result2, result3);
						ms.Write(result3.GetBuffer(), 0, (int)result3.Length);
						if (ms.Length > num && !ReplaceFileContentsOnEachWrite)
						{
							return i - startIndex + 1;
						}
					}
				}
				finally
				{
					((IDisposable)lockOject3/*cast due to .constrained prefix*/).Dispose();
				}
			}
			finally
			{
				((IDisposable)lockOject2/*cast due to .constrained prefix*/).Dispose();
			}
		}
		finally
		{
			((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
		}
		return logEvents.Count - startIndex;
	}

	private void ProcessLogEvent(LogEventInfo logEvent, string fileName, ArraySegment<byte> bytesToWrite)
	{
		DateTime dateTime = InitializeFile(fileName, logEvent);
		bool flag = dateTime == DateTime.MinValue;
		if (flag && fileName == _previousLogFileName && _previousLogEventTimestamp.HasValue)
		{
			dateTime = _previousLogEventTimestamp.Value;
		}
		if (TryArchiveFile(fileName, logEvent, bytesToWrite.Count, dateTime, flag))
		{
			flag = InitializeFile(fileName, logEvent) == DateTime.MinValue || flag;
		}
		if (ReplaceFileContentsOnEachWrite)
		{
			ReplaceFileContent(fileName, bytesToWrite, firstAttempt: true);
		}
		else
		{
			WriteToFile(fileName, bytesToWrite, flag);
		}
		_previousLogFileName = fileName;
		_previousLogEventTimestamp = logEvent.TimeStamp;
	}

	protected virtual void RenderFormattedMessageToStream(LogEventInfo logEvent, StringBuilder formatBuilder, char[] transformBuffer, MemoryStream streamTarget)
	{
		RenderFormattedMessage(logEvent, formatBuilder);
		formatBuilder.Append(NewLineChars);
		TransformBuilderToStream(logEvent, formatBuilder, transformBuffer, streamTarget);
	}

	protected virtual void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
	{
		Layout.Render(logEvent, target);
	}

	private void TransformBuilderToStream(LogEventInfo logEvent, StringBuilder builder, char[] transformBuffer, MemoryStream workStream)
	{
		builder.CopyToStream(workStream, Encoding, transformBuffer);
		TransformStream(logEvent, workStream);
	}

	protected virtual void TransformStream(LogEventInfo logEvent, MemoryStream stream)
	{
	}

	private void AppendMemoryStreamToFile(string currentFileName, LogEventInfo firstLogEvent, MemoryStream ms, out Exception lastException)
	{
		try
		{
			ArraySegment<byte> bytesToWrite = new ArraySegment<byte>(ms.GetBuffer(), 0, (int)ms.Length);
			ProcessLogEvent(firstLogEvent, currentFileName, bytesToWrite);
			lastException = null;
		}
		catch (Exception ex)
		{
			if (LogManager.ThrowExceptions)
			{
				throw;
			}
			lastException = ex;
		}
	}

	private void ArchiveFile(string fileName, string archiveFileName)
	{
		string directoryName = Path.GetDirectoryName(archiveFileName);
		if (directoryName != null && !Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		if (string.Equals(fileName, archiveFileName, StringComparison.OrdinalIgnoreCase))
		{
			InternalLogger.Info("{0}: Archiving {1} skipped as ArchiveFileName equals FileName", this, fileName);
		}
		else if (EnableArchiveFileCompression)
		{
			InternalLogger.Info("{0}: Archiving {1} to compressed {2}", this, fileName, archiveFileName);
			if (File.Exists(archiveFileName))
			{
				InternalLogger.Warn("{0}: Failed archiving because compressed file already exists: {1}", this, archiveFileName);
			}
			else
			{
				ArchiveFileCompress(fileName, archiveFileName);
			}
		}
		else
		{
			InternalLogger.Info("{0}: Archiving {1} to {2}", this, fileName, archiveFileName);
			if (File.Exists(archiveFileName))
			{
				ArchiveFileAppendExisting(fileName, archiveFileName);
			}
			else
			{
				ArchiveFileMove(fileName, archiveFileName);
			}
		}
	}

	private void ArchiveFileCompress(string fileName, string archiveFileName)
	{
		int num = (ConcurrentWrites ? ConcurrentWriteAttempts : 2);
		for (int i = 1; i <= num; i++)
		{
			try
			{
				if (FileCompressor is IArchiveFileCompressor archiveFileCompressor)
				{
					string entryName = ((ArchiveNumbering != ArchiveNumberingMode.Rolling) ? (Path.GetFileNameWithoutExtension(archiveFileName) + Path.GetExtension(fileName)) : Path.GetFileName(fileName));
					archiveFileCompressor.CompressFile(fileName, archiveFileName, entryName);
				}
				else
				{
					FileCompressor.CompressFile(fileName, archiveFileName);
				}
			}
			catch (DirectoryNotFoundException)
			{
				throw;
			}
			catch (FileNotFoundException)
			{
				throw;
			}
			catch (IOException ex3)
			{
				if (i == num)
				{
					throw;
				}
				if (File.Exists(archiveFileName))
				{
					throw;
				}
				int num2 = i * 50;
				InternalLogger.Warn("{0}: Archiving Attempt #{1} to compress {2} to {3} failed - {4} {5}. Sleeping for {6}ms", this, i, fileName, archiveFileName, ex3.GetType(), ex3.Message, num2);
				Thread.Sleep(TimeSpan.FromMilliseconds((double)num2));
				continue;
			}
			break;
		}
		DeleteAndWaitForFileDelete(fileName);
	}

	private void ArchiveFileAppendExisting(string fileName, string archiveFileName)
	{
		InternalLogger.Info("{0}: Already exists, append to {1}", this, archiveFileName);
		FileShare fileShare = FileShare.ReadWrite;
		if (EnableFileDelete)
		{
			fileShare |= FileShare.Delete;
		}
		using (FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, fileShare))
		{
			using FileStream fileStream2 = File.Open(archiveFileName, FileMode.Append);
			fileStream.CopyAndSkipBom(fileStream2, Encoding);
			fileStream.SetLength(0L);
			if (EnableFileDelete && !DeleteOldArchiveFile(fileName))
			{
				fileShare &= ~FileShare.Delete;
			}
			fileStream.Close();
			fileStream2.Flush(flushToDisk: true);
		}
		if ((fileShare & FileShare.Delete) == 0)
		{
			DeleteOldArchiveFile(fileName);
		}
	}

	private void ArchiveFileMove(string fileName, string archiveFileName)
	{
		try
		{
			InternalLogger.Debug("{0}: Move file from '{1}' to '{2}'", this, fileName, archiveFileName);
			File.Move(fileName, archiveFileName);
		}
		catch (IOException ex)
		{
			if (IsSimpleKeepFileOpen)
			{
				throw;
			}
			if (!EnableFileDelete && KeepFileOpen)
			{
				throw;
			}
			if (ConcurrentWrites && !MutexDetector.SupportsSharableMutex)
			{
				throw;
			}
			InternalLogger.Warn(ex, "{0}: Archiving failed. Checking for retry move of {1} to {2}.", this, fileName, archiveFileName);
			if (!File.Exists(fileName) || File.Exists(archiveFileName))
			{
				throw;
			}
			Thread.Sleep(TimeSpan.FromMilliseconds(50.0));
			if (!File.Exists(fileName) || File.Exists(archiveFileName))
			{
				throw;
			}
			InternalLogger.Debug("{0}: Archiving retrying move of {1} to {2}.", this, fileName, archiveFileName);
			File.Move(fileName, archiveFileName);
		}
	}

	private bool DeleteOldArchiveFile(string fileName)
	{
		try
		{
			InternalLogger.Info("{0}: Deleting old archive file: '{1}'.", this, fileName);
			CloseInvalidFileHandle(fileName);
			File.Delete(fileName);
			return true;
		}
		catch (DirectoryNotFoundException ex)
		{
			InternalLogger.Debug(ex, "{0}: Failed to delete old log file '{1}' as directory is missing.", this, fileName);
			return false;
		}
		catch (Exception ex2)
		{
			InternalLogger.Warn(ex2, "{0}: Failed to delete old archive file: '{1}'.", this, fileName);
			if (LogManager.ThrowExceptions)
			{
				throw;
			}
			return false;
		}
	}

	private void DeleteAndWaitForFileDelete(string fileName)
	{
		try
		{
			InternalLogger.Trace("{0}: Waiting for file delete of '{1}' for 12 sec", this, fileName);
			DateTime creationTime = new FileInfo(fileName).CreationTime;
			if (!DeleteOldArchiveFile(fileName) || !File.Exists(fileName))
			{
				return;
			}
			for (int i = 0; i < 120; i++)
			{
				Thread.Sleep(TimeSpan.FromMilliseconds(100.0));
				FileInfo fileInfo = new FileInfo(fileName);
				if (!fileInfo.Exists || fileInfo.CreationTime != creationTime)
				{
					return;
				}
			}
			InternalLogger.Warn("{0}: Timeout while deleting old archive file: '{1}'.", this, fileName);
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "{0}: Failed to delete old archive file: '{1}'.", this, fileName);
			if (LogManager.ThrowExceptions)
			{
				throw;
			}
		}
	}

	private string GetArchiveDateFormatString(string defaultFormat)
	{
		if (!string.IsNullOrEmpty(defaultFormat))
		{
			return defaultFormat;
		}
		return ArchiveEvery switch
		{
			FileArchiveEveryPeriod.Year => "yyyy", 
			FileArchiveEveryPeriod.Month => "yyyyMM", 
			FileArchiveEveryPeriod.Hour => "yyyyMMddHH", 
			FileArchiveEveryPeriod.Minute => "yyyyMMddHHmm", 
			_ => "yyyyMMdd", 
		};
	}

	private DateTime? GetArchiveDate(string fileName, LogEventInfo logEvent, DateTime previousLogEventTimestamp)
	{
		DateTime? fileLastWriteTimeUtc = _fileAppenderCache.GetFileLastWriteTimeUtc(fileName);
		InternalLogger.Trace("{0}: Calculating archive date. File-LastModifiedUtc: {1}; Previous LogEvent-TimeStamp: {2}", this, fileLastWriteTimeUtc, previousLogEventTimestamp);
		if (!fileLastWriteTimeUtc.HasValue)
		{
			if (previousLogEventTimestamp == DateTime.MinValue)
			{
				InternalLogger.Info("{0}: Unable to acquire useful timestamp to archive file: {1}", this, fileName);
				return null;
			}
			return previousLogEventTimestamp;
		}
		DateTime dateTime = TimeSource.Current.FromSystemTime(fileLastWriteTimeUtc.Value);
		if (previousLogEventTimestamp != DateTime.MinValue)
		{
			if (previousLogEventTimestamp > dateTime)
			{
				InternalLogger.Trace("{0}: Using previous LogEvent-TimeStamp {1}, because more recent than File-LastModified {2}", this, previousLogEventTimestamp, dateTime);
				return previousLogEventTimestamp;
			}
			if (PreviousLogOverlappedPeriod(logEvent, previousLogEventTimestamp, dateTime))
			{
				InternalLogger.Trace("{0}: Using previous LogEvent-TimeStamp {1}, because archive period is overlapping with File-LastModified {2}", this, previousLogEventTimestamp, dateTime);
				return previousLogEventTimestamp;
			}
			if (!AutoFlush && IsSimpleKeepFileOpen && previousLogEventTimestamp < dateTime)
			{
				InternalLogger.Trace("{0}: Using previous LogEvent-TimeStamp {1}, because AutoFlush=false affects File-LastModified {2}", this, previousLogEventTimestamp, dateTime);
				return previousLogEventTimestamp;
			}
		}
		InternalLogger.Trace("{0}: Using last write time: {1}", this, dateTime);
		return dateTime;
	}

	private bool PreviousLogOverlappedPeriod(LogEventInfo logEvent, DateTime previousLogEventTimestamp, DateTime lastFileWrite)
	{
		string archiveDateFormatString = GetArchiveDateFormatString(string.Empty);
		string text = lastFileWrite.ToString(archiveDateFormatString, CultureInfo.InvariantCulture);
		string text2 = logEvent.TimeStamp.ToString(archiveDateFormatString, CultureInfo.InvariantCulture);
		if (text != text2)
		{
			return false;
		}
		DateTime? dateTime = CalculateNextArchiveEventTime(previousLogEventTimestamp);
		if (!dateTime.HasValue)
		{
			return false;
		}
		string text3 = dateTime.Value.ToString(archiveDateFormatString, CultureInfo.InvariantCulture);
		return text == text3;
	}

	private DateTime? CalculateNextArchiveEventTime(DateTime timestamp)
	{
		return ArchiveEvery switch
		{
			FileArchiveEveryPeriod.Year => timestamp.AddYears(1), 
			FileArchiveEveryPeriod.Month => timestamp.AddMonths(1), 
			FileArchiveEveryPeriod.Day => timestamp.AddDays(1.0), 
			FileArchiveEveryPeriod.Hour => timestamp.AddHours(1.0), 
			FileArchiveEveryPeriod.Minute => timestamp.AddMinutes(1.0), 
			FileArchiveEveryPeriod.Sunday => CalculateNextWeekday(timestamp, DayOfWeek.Sunday), 
			FileArchiveEveryPeriod.Monday => CalculateNextWeekday(timestamp, DayOfWeek.Monday), 
			FileArchiveEveryPeriod.Tuesday => CalculateNextWeekday(timestamp, DayOfWeek.Tuesday), 
			FileArchiveEveryPeriod.Wednesday => CalculateNextWeekday(timestamp, DayOfWeek.Wednesday), 
			FileArchiveEveryPeriod.Thursday => CalculateNextWeekday(timestamp, DayOfWeek.Thursday), 
			FileArchiveEveryPeriod.Friday => CalculateNextWeekday(timestamp, DayOfWeek.Friday), 
			FileArchiveEveryPeriod.Saturday => CalculateNextWeekday(timestamp, DayOfWeek.Saturday), 
			_ => null, 
		};
	}

	public static DateTime CalculateNextWeekday(DateTime previousLogEventTimestamp, DayOfWeek dayOfWeek)
	{
		int dayOfWeek2 = (int)previousLogEventTimestamp.DayOfWeek;
		int num = (int)dayOfWeek;
		if (num <= dayOfWeek2)
		{
			num += 7;
		}
		return previousLogEventTimestamp.AddDays(num - dayOfWeek2);
	}

	private void DoAutoArchive(string fileName, LogEventInfo eventInfo, DateTime previousLogEventTimestamp, bool initializedNewFile)
	{
		InternalLogger.Debug("{0}: Do archive file: '{1}'", this, fileName);
		FileInfo fileInfo = new FileInfo(fileName);
		if (!fileInfo.Exists)
		{
			CloseInvalidFileHandle(fileName);
			return;
		}
		string archiveFileNamePattern = GetArchiveFileNamePattern(fileName, eventInfo);
		if (string.IsNullOrEmpty(archiveFileNamePattern))
		{
			InternalLogger.Warn("{0}: Skip auto archive because archiveFilePattern is blank", this);
			return;
		}
		DateTime? archiveDate = GetArchiveDate(fileName, eventInfo, previousLogEventTimestamp);
		string text = GenerateArchiveFileNameAfterCleanup(fileName, fileInfo, archiveFileNamePattern, archiveDate, initializedNewFile);
		if (!string.IsNullOrEmpty(text))
		{
			ArchiveFile(fileInfo.FullName, text);
		}
	}

	private string GenerateArchiveFileNameAfterCleanup(string fileName, FileInfo fileInfo, string archiveFilePattern, DateTime? archiveDate, bool initializedNewFile)
	{
		InternalLogger.Trace("{0}: Archive pattern '{1}'", this, archiveFilePattern);
		IFileArchiveMode fileArchiveHelper = GetFileArchiveHelper(archiveFilePattern);
		List<DateAndSequenceArchive> existingArchiveFiles = fileArchiveHelper.GetExistingArchiveFiles(archiveFilePattern);
		if (MaxArchiveFiles == 1)
		{
			InternalLogger.Trace("{0}: MaxArchiveFiles = 1", this);
			for (int num = existingArchiveFiles.Count - 1; num >= 0; num--)
			{
				DateAndSequenceArchive dateAndSequenceArchive = existingArchiveFiles[num];
				if (!string.Equals(dateAndSequenceArchive.FileName, fileInfo.FullName, StringComparison.OrdinalIgnoreCase))
				{
					DeleteOldArchiveFile(dateAndSequenceArchive.FileName);
					existingArchiveFiles.RemoveAt(num);
				}
			}
			if (initializedNewFile && string.Equals(Path.GetDirectoryName(archiveFilePattern), fileInfo.DirectoryName, StringComparison.OrdinalIgnoreCase))
			{
				DeleteOldArchiveFile(fileName);
				return null;
			}
		}
		DateAndSequenceArchive dateAndSequenceArchive2 = (archiveDate.HasValue ? fileArchiveHelper.GenerateArchiveFileName(archiveFilePattern, archiveDate.Value, existingArchiveFiles) : null);
		if (dateAndSequenceArchive2 == null)
		{
			return null;
		}
		if (!initializedNewFile)
		{
			FinalizeFile(fileName, isArchiving: true);
		}
		if (existingArchiveFiles.Count > 0)
		{
			CleanupOldArchiveFiles(fileInfo, archiveFilePattern, existingArchiveFiles, dateAndSequenceArchive2);
		}
		return dateAndSequenceArchive2.FileName;
	}

	private void CleanupOldArchiveFiles(FileInfo currentFile, string archiveFilePattern, List<DateAndSequenceArchive> existingArchiveFiles, DateAndSequenceArchive newArchiveFile = null)
	{
		IFileArchiveMode fileArchiveHelper = GetFileArchiveHelper(archiveFilePattern);
		if (!fileArchiveHelper.IsArchiveCleanupEnabled)
		{
			return;
		}
		if (currentFile != null)
		{
			ExcludeActiveFileFromOldArchiveFiles(currentFile, existingArchiveFiles);
		}
		if (newArchiveFile != null)
		{
			existingArchiveFiles.Add(newArchiveFile);
		}
		foreach (DateAndSequenceArchive item in fileArchiveHelper.CheckArchiveCleanup(archiveFilePattern, existingArchiveFiles, MaxArchiveFiles, MaxArchiveDays))
		{
			DeleteOldArchiveFile(item.FileName);
		}
	}

	private static void ExcludeActiveFileFromOldArchiveFiles(FileInfo currentFile, List<DateAndSequenceArchive> existingArchiveFiles)
	{
		if (existingArchiveFiles.Count <= 0 || !string.Equals(Path.GetDirectoryName(existingArchiveFiles[0].FileName), currentFile.DirectoryName, StringComparison.OrdinalIgnoreCase))
		{
			return;
		}
		for (int i = 0; i < existingArchiveFiles.Count; i++)
		{
			if (string.Equals(existingArchiveFiles[i].FileName, currentFile.FullName, StringComparison.OrdinalIgnoreCase))
			{
				existingArchiveFiles.RemoveAt(i);
				break;
			}
		}
	}

	private string GetArchiveFileNamePattern(string fileName, LogEventInfo eventInfo)
	{
		if (_fullArchiveFileName == null)
		{
			if (EnableArchiveFileCompression)
			{
				return Path.ChangeExtension(fileName, ".zip");
			}
			return fileName;
		}
		return _fullArchiveFileName.Render(eventInfo);
	}

	private bool TryArchiveFile(string fileName, LogEventInfo ev, int upcomingWriteSize, DateTime previousLogEventTimestamp, bool initializedNewFile)
	{
		if (!IsArchivingEnabled)
		{
			return false;
		}
		string text = string.Empty;
		BaseFileAppender baseFileAppender = null;
		try
		{
			text = GetArchiveFileName(fileName, ev, upcomingWriteSize, previousLogEventTimestamp, initializedNewFile);
			if (!string.IsNullOrEmpty(text))
			{
				baseFileAppender = TryCloseFileAppenderBeforeArchive(fileName, text);
			}
			_fileAppenderCache.InvalidateAppendersForArchivedFiles();
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "{0}: Failed to check archive for file '{1}'.", this, fileName);
			if (LogManager.ThrowExceptions)
			{
				throw;
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			return false;
		}
		try
		{
			try
			{
				if (baseFileAppender is BaseMutexFileAppender { ArchiveMutex: not null } baseMutexFileAppender)
				{
					baseMutexFileAppender.ArchiveMutex.WaitOne();
				}
				else if (!IsSimpleKeepFileOpen)
				{
					InternalLogger.Debug("{0}: Archive mutex not available for file '{1}'", this, text);
				}
			}
			catch (AbandonedMutexException)
			{
			}
			ArchiveFileAfterCloseFileAppender(baseFileAppender, text, ev, upcomingWriteSize, previousLogEventTimestamp);
			return true;
		}
		finally
		{
			if (baseFileAppender is BaseMutexFileAppender baseMutexFileAppender2)
			{
				baseMutexFileAppender2.ArchiveMutex?.ReleaseMutex();
			}
			baseFileAppender?.Dispose();
		}
	}

	private BaseFileAppender TryCloseFileAppenderBeforeArchive(string fileName, string archiveFile)
	{
		InternalLogger.Trace("{0}: Archive attempt for file '{1}'", this, archiveFile);
		BaseFileAppender baseFileAppender = _fileAppenderCache.InvalidateAppender(fileName);
		if (fileName != archiveFile)
		{
			BaseFileAppender baseFileAppender2 = _fileAppenderCache.InvalidateAppender(archiveFile);
			baseFileAppender = baseFileAppender ?? baseFileAppender2;
		}
		if (!string.IsNullOrEmpty(_previousLogFileName) && _previousLogFileName != archiveFile && _previousLogFileName != fileName)
		{
			BaseFileAppender baseFileAppender3 = _fileAppenderCache.InvalidateAppender(_previousLogFileName);
			baseFileAppender = baseFileAppender ?? baseFileAppender3;
		}
		return baseFileAppender;
	}

	private void ArchiveFileAfterCloseFileAppender(BaseFileAppender archivedAppender, string archiveFile, LogEventInfo ev, int upcomingWriteSize, DateTime previousLogEventTimestamp)
	{
		try
		{
			DateTime dateTime = previousLogEventTimestamp;
			if (archivedAppender != null && IsSimpleKeepFileOpen)
			{
				DateTime? fileCreationTimeUtc = archivedAppender.GetFileCreationTimeUtc();
				if (fileCreationTimeUtc > DateTime.MinValue)
				{
					DateTime dateTime2 = TimeSource.Current.FromSystemTime(fileCreationTimeUtc.Value);
					if (dateTime2 < dateTime || dateTime == DateTime.MinValue)
					{
						dateTime = dateTime2;
					}
				}
			}
			string archiveFileName = GetArchiveFileName(archiveFile, ev, upcomingWriteSize, dateTime, initializedNewFile: false);
			if (string.IsNullOrEmpty(archiveFileName))
			{
				InternalLogger.Debug("{0}: Skip archiving '{1}' because no longer necessary", this, archiveFile);
				_initializedFiles.Remove(archiveFile);
			}
			else
			{
				if (archiveFile != archiveFileName)
				{
					_initializedFiles.Remove(archiveFile);
					archiveFile = archiveFileName;
				}
				_initializedFiles.Remove(archiveFile);
				DoAutoArchive(archiveFile, ev, previousLogEventTimestamp, initializedNewFile: false);
			}
			if (_previousLogFileName == archiveFile)
			{
				_previousLogFileName = null;
				_previousLogEventTimestamp = null;
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "{0}: Failed to archive file '{1}'.", this, archiveFile);
			if (LogManager.ThrowExceptions)
			{
				throw;
			}
		}
	}

	private string GetArchiveFileName(string fileName, LogEventInfo ev, int upcomingWriteSize, DateTime previousLogEventTimestamp, bool initializedNewFile)
	{
		fileName = fileName ?? _previousLogFileName;
		if (!string.IsNullOrEmpty(fileName))
		{
			return GetArchiveFileNameBasedOnFileSize(fileName, upcomingWriteSize, initializedNewFile) ?? GetArchiveFileNameBasedOnTime(fileName, ev, previousLogEventTimestamp, initializedNewFile);
		}
		return null;
	}

	private string GetPotentialFileForArchiving(string fileName)
	{
		if (!string.IsNullOrEmpty(fileName))
		{
			return fileName;
		}
		if (!string.IsNullOrEmpty(_previousLogFileName))
		{
			return _previousLogFileName;
		}
		return fileName;
	}

	private string GetArchiveFileNameBasedOnFileSize(string fileName, int upcomingWriteSize, bool initializedNewFile)
	{
		if (ArchiveAboveSize == -1)
		{
			return null;
		}
		string potentialFileForArchiving = GetPotentialFileForArchiving(fileName);
		if (string.IsNullOrEmpty(potentialFileForArchiving))
		{
			return null;
		}
		long? fileLength = _fileAppenderCache.GetFileLength(potentialFileForArchiving);
		if (!fileLength.HasValue)
		{
			potentialFileForArchiving = TryFallbackToPreviousLogFileName(potentialFileForArchiving, initializedNewFile);
			if (!string.IsNullOrEmpty(potentialFileForArchiving))
			{
				upcomingWriteSize = 0;
				return GetArchiveFileNameBasedOnFileSize(potentialFileForArchiving, upcomingWriteSize, initializedNewFile: false);
			}
			return null;
		}
		if (potentialFileForArchiving != fileName)
		{
			upcomingWriteSize = 0;
		}
		if (fileLength.Value + upcomingWriteSize > ArchiveAboveSize)
		{
			InternalLogger.Debug("{0}: Start archiving '{1}' because FileSize={2} + {3} is larger than ArchiveAboveSize={4}", this, potentialFileForArchiving, fileLength.Value, upcomingWriteSize, ArchiveAboveSize);
			return potentialFileForArchiving;
		}
		return null;
	}

	private string TryFallbackToPreviousLogFileName(string archiveFileName, bool initializedNewFile)
	{
		if (!initializedNewFile && _initializedFiles.Remove(archiveFileName))
		{
			InternalLogger.Debug("{0}: Invalidate appender as archive file no longer exists: '{1}'", this, archiveFileName);
			_fileAppenderCache.InvalidateAppender(archiveFileName)?.Dispose();
		}
		if (!string.IsNullOrEmpty(_previousLogFileName) && !string.Equals(archiveFileName, _previousLogFileName, StringComparison.OrdinalIgnoreCase))
		{
			return _previousLogFileName;
		}
		return string.Empty;
	}

	private string GetArchiveFileNameBasedOnTime(string fileName, LogEventInfo logEvent, DateTime previousLogEventTimestamp, bool initializedNewFile)
	{
		if (ArchiveEvery == FileArchiveEveryPeriod.None)
		{
			return null;
		}
		string potentialFileForArchiving = GetPotentialFileForArchiving(fileName);
		if (string.IsNullOrEmpty(potentialFileForArchiving))
		{
			return null;
		}
		DateTime? dateTime = TryGetArchiveFileCreationTimeSource(potentialFileForArchiving, previousLogEventTimestamp);
		if (!dateTime.HasValue)
		{
			potentialFileForArchiving = TryFallbackToPreviousLogFileName(potentialFileForArchiving, initializedNewFile);
			if (!string.IsNullOrEmpty(potentialFileForArchiving))
			{
				return GetArchiveFileNameBasedOnTime(potentialFileForArchiving, logEvent, previousLogEventTimestamp, initializedNewFile: false);
			}
			return null;
		}
		DateTime dateTime2 = TruncateArchiveTime(dateTime.Value, ArchiveEvery);
		DateTime dateTime3 = TruncateArchiveTime(logEvent.TimeStamp, ArchiveEvery);
		if (dateTime2 != dateTime3)
		{
			string archiveDateFormatString = GetArchiveDateFormatString(string.Empty);
			DateTime dateTime4 = EnsureValidLogEventTimeStamp(logEvent.TimeStamp, dateTime.Value);
			string text = dateTime.Value.ToString(archiveDateFormatString, CultureInfo.InvariantCulture);
			string text2 = dateTime4.ToString(archiveDateFormatString, CultureInfo.InvariantCulture);
			if (text != text2)
			{
				InternalLogger.Debug("{0}: Start archiving '{1}' because FileCreatedTime='{2}' is older than now '{3}' using ArchiveEvery='{4}'", this, potentialFileForArchiving, text, text2, archiveDateFormatString);
				return potentialFileForArchiving;
			}
		}
		return null;
	}

	private DateTime? TryGetArchiveFileCreationTimeSource(string fileName, DateTime previousLogEventTimestamp)
	{
		DateTime? fallbackTimeSource = ((previousLogEventTimestamp != DateTime.MinValue && IsSimpleKeepFileOpen) ? new DateTime?(previousLogEventTimestamp) : ((DateTime?)null));
		DateTime? dateTime = _fileAppenderCache.GetFileCreationTimeSource(fileName, fallbackTimeSource);
		if (!dateTime.HasValue)
		{
			return null;
		}
		if (previousLogEventTimestamp > DateTime.MinValue)
		{
			DateTime? dateTime2 = dateTime;
			if (dateTime2.HasValue && previousLogEventTimestamp < dateTime2.GetValueOrDefault() && TruncateArchiveTime(previousLogEventTimestamp, FileArchiveEveryPeriod.Minute) < TruncateArchiveTime(dateTime.Value, FileArchiveEveryPeriod.Minute) && NLog.Internal.PlatformDetector.IsUnix)
			{
				if (IsSimpleKeepFileOpen)
				{
					InternalLogger.Debug("{0}: Adjusted file creation time from {1} to {2}. Linux FileSystem probably don't support file birthtime.", this, dateTime, previousLogEventTimestamp);
					dateTime = previousLogEventTimestamp;
				}
				else
				{
					InternalLogger.Debug("{0}: File creation time {1} newer than previous file write time {2}. Linux FileSystem probably don't support file birthtime, unless multiple applications are writing to the same file. Configure ConcurrentFileTarget.KeepFileOpen=true AND ConcurrentFileTarget.ConcurrentWrites=false, so NLog can fix this.", this, dateTime, previousLogEventTimestamp);
				}
			}
		}
		return dateTime;
	}

	private static DateTime TruncateArchiveTime(DateTime input, FileArchiveEveryPeriod resolution)
	{
		return resolution switch
		{
			FileArchiveEveryPeriod.Year => new DateTime(input.Year, 1, 1, 0, 0, 0, 0, input.Kind), 
			FileArchiveEveryPeriod.Month => new DateTime(input.Year, input.Month, 1, 0, 0, 0, input.Kind), 
			FileArchiveEveryPeriod.Day => input.Date, 
			FileArchiveEveryPeriod.Hour => input.AddTicks(-(input.Ticks % 36000000000L)), 
			FileArchiveEveryPeriod.Minute => input.AddTicks(-(input.Ticks % 600000000)), 
			FileArchiveEveryPeriod.Sunday => CalculateNextWeekday(input.Date, DayOfWeek.Sunday), 
			FileArchiveEveryPeriod.Monday => CalculateNextWeekday(input.Date, DayOfWeek.Monday), 
			FileArchiveEveryPeriod.Tuesday => CalculateNextWeekday(input.Date, DayOfWeek.Tuesday), 
			FileArchiveEveryPeriod.Wednesday => CalculateNextWeekday(input.Date, DayOfWeek.Wednesday), 
			FileArchiveEveryPeriod.Thursday => CalculateNextWeekday(input.Date, DayOfWeek.Thursday), 
			FileArchiveEveryPeriod.Friday => CalculateNextWeekday(input.Date, DayOfWeek.Friday), 
			FileArchiveEveryPeriod.Saturday => CalculateNextWeekday(input.Date, DayOfWeek.Saturday), 
			_ => input, 
		};
	}

	private void AutoCloseAppendersAfterArchive(object sender, EventArgs state)
	{
		if (!Monitor.TryEnter(base.SyncRoot, TimeSpan.FromSeconds(2.0)))
		{
			return;
		}
		try
		{
			if (base.IsInitialized)
			{
				InternalLogger.Trace("{0}: Auto Close FileAppenders after archive", this);
				_fileAppenderCache.CloseExpiredAppenders(DateTime.MinValue);
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "{0}: Exception in AutoCloseAppendersAfterArchive", this);
		}
		finally
		{
			Monitor.Exit(base.SyncRoot);
		}
	}

	private void AutoClosingTimerCallback(object sender, EventArgs state)
	{
		if (!Monitor.TryEnter(base.SyncRoot, TimeSpan.FromSeconds(0.5)))
		{
			return;
		}
		try
		{
			if (base.IsInitialized)
			{
				if (OpenFileCacheTimeout > 0)
				{
					DateTime expireTimeUtc = DateTime.UtcNow.AddSeconds(-OpenFileCacheTimeout);
					InternalLogger.Trace("{0}: Auto Close FileAppenders", this);
					_fileAppenderCache.CloseExpiredAppenders(expireTimeUtc);
				}
				if (OpenFileFlushTimeout > 0 && !AutoFlush)
				{
					ConditionalFlushOpenFileAppenders();
				}
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "{0}: Exception in AutoClosingTimerCallback", this);
		}
		finally
		{
			Monitor.Exit(base.SyncRoot);
		}
	}

	private void ConditionalFlushOpenFileAppenders()
	{
		DateTime dateTime = TimeSource.Current.Time.AddSeconds(-Math.Max(OpenFileFlushTimeout, 5) * 2);
		bool flag = false;
		foreach (KeyValuePair<string, DateTime> initializedFile in _initializedFiles)
		{
			if (initializedFile.Value > dateTime)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			InternalLogger.Trace("{0}: Auto Flush FileAppenders", this);
			_fileAppenderCache.FlushAppenders();
		}
	}

	private void WriteToFile(string fileName, ArraySegment<byte> bytes, bool initializedNewFile)
	{
		BaseFileAppender baseFileAppender = _fileAppenderCache.AllocateAppender(fileName);
		try
		{
			if (initializedNewFile)
			{
				WriteHeaderAndBom(baseFileAppender);
			}
			baseFileAppender.Write(bytes.Array, bytes.Offset, bytes.Count);
			if (AutoFlush)
			{
				baseFileAppender.Flush();
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "{0}: Failed write to file '{1}'.", this, fileName);
			_fileAppenderCache.InvalidateAppender(fileName)?.Dispose();
			throw;
		}
	}

	private DateTime InitializeFile(string fileName, LogEventInfo logEvent)
	{
		if (_initializedFiles.Count != 0)
		{
			DateTime timeStamp = logEvent.TimeStamp;
			DateTime? previousLogEventTimestamp = _previousLogEventTimestamp;
			if (previousLogEventTimestamp.HasValue && timeStamp == previousLogEventTimestamp.GetValueOrDefault() && _previousLogFileName == fileName)
			{
				return logEvent.TimeStamp;
			}
		}
		DateTime timeStamp2 = logEvent.TimeStamp;
		if (!_initializedFiles.TryGetValue(fileName, out var value))
		{
			PrepareForNewFile(fileName, logEvent);
			_initializedFilesCounter++;
			if (_initializedFilesCounter > OpenFileCacheSize)
			{
				_initializedFilesCounter = 0;
				CleanupInitializedFiles();
				_initializedFilesCounter = Math.Min(_initializedFiles.Count, OpenFileCacheSize / 2);
			}
			_initializedFiles[fileName] = timeStamp2;
			return DateTime.MinValue;
		}
		if (value != timeStamp2)
		{
			timeStamp2 = EnsureValidLogEventTimeStamp(timeStamp2, value);
			_initializedFiles[fileName] = timeStamp2;
		}
		return value;
	}

	private static DateTime EnsureValidLogEventTimeStamp(DateTime logEventTimeStamp, DateTime previousTimeStamp)
	{
		if (logEventTimeStamp < previousTimeStamp && logEventTimeStamp.Date < previousTimeStamp.Date)
		{
			DateTime time = TimeSource.Current.Time;
			if (logEventTimeStamp.Date < time.AddMinutes(-1.0).Date)
			{
				if (time.Date < previousTimeStamp.Date)
				{
					return time;
				}
				return previousTimeStamp;
			}
		}
		return logEventTimeStamp;
	}

	private void CloseInvalidFileHandle(string fileName)
	{
		try
		{
			_fileAppenderCache.InvalidateAppender(fileName)?.Dispose();
		}
		finally
		{
			_initializedFiles.Remove(fileName);
		}
	}

	private void FinalizeFile(string fileName, bool isArchiving = false)
	{
		try
		{
			InternalLogger.Trace("{0}: FinalizeFile '{1}, isArchiving: {2}'", this, fileName, isArchiving);
			if (isArchiving || !WriteFooterOnArchivingOnly)
			{
				WriteFooter(fileName);
			}
		}
		finally
		{
			CloseInvalidFileHandle(fileName);
		}
	}

	private void WriteFooter(string fileName)
	{
		ArraySegment<byte> layoutBytes = GetLayoutBytes(base.Footer);
		if (layoutBytes.Count > 0 && File.Exists(fileName))
		{
			WriteToFile(fileName, layoutBytes, initializedNewFile: false);
		}
	}

	internal bool ShouldArchiveOldFileOnStartup(string fileName)
	{
		if (_archiveOldFileOnStartup == false)
		{
			return false;
		}
		if (ArchiveOldFileOnStartupAboveSize > 0)
		{
			long? fileLength = _fileAppenderCache.GetFileLength(fileName);
			if (fileLength.HasValue)
			{
				return fileLength.Value > ArchiveOldFileOnStartupAboveSize;
			}
			return false;
		}
		return _archiveOldFileOnStartup == true;
	}

	private void PrepareForNewFile(string fileName, LogEventInfo logEvent)
	{
		InternalLogger.Debug("{0}: Preparing for new file: '{1}'", this, fileName);
		RefreshArchiveFilePatternToWatch(fileName, logEvent);
		try
		{
			if (ShouldArchiveOldFileOnStartup(fileName))
			{
				DoAutoArchive(fileName, logEvent, DateTime.MinValue, initializedNewFile: true);
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "{0}: Unable to archive old log file '{1}'.", this, fileName);
			if (LogManager.ThrowExceptions)
			{
				throw;
			}
		}
		if (DeleteOldFileOnStartup)
		{
			DeleteOldArchiveFile(fileName);
		}
		try
		{
			string archiveFileNamePattern = GetArchiveFileNamePattern(fileName, logEvent);
			if (string.IsNullOrEmpty(archiveFileNamePattern))
			{
				return;
			}
			IFileArchiveMode fileArchiveHelper = GetFileArchiveHelper(archiveFileNamePattern);
			if (fileArchiveHelper.AttemptCleanupOnInitializeFile(archiveFileNamePattern, MaxArchiveFiles, MaxArchiveDays))
			{
				List<DateAndSequenceArchive> existingArchiveFiles = fileArchiveHelper.GetExistingArchiveFiles(archiveFileNamePattern);
				if (existingArchiveFiles.Count > 0)
				{
					CleanupOldArchiveFiles(new FileInfo(fileName), archiveFileNamePattern, existingArchiveFiles);
				}
			}
		}
		catch (Exception ex2)
		{
			InternalLogger.Warn(ex2, "FileTarget(Name={0}): Failed to cleanup old archive files when starting on new file: '{1}'", base.Name, fileName);
			if (LogManager.ThrowExceptions)
			{
				throw;
			}
		}
	}

	private void ReplaceFileContent(string fileName, ArraySegment<byte> bytes, bool firstAttempt)
	{
		try
		{
			using FileStream fileStream = File.Create(fileName);
			ArraySegment<byte> layoutBytes = GetLayoutBytes(base.Header);
			if (layoutBytes.Count > 0)
			{
				fileStream.Write(layoutBytes.Array, layoutBytes.Offset, layoutBytes.Count);
			}
			fileStream.Write(bytes.Array, bytes.Offset, bytes.Count);
			ArraySegment<byte> layoutBytes2 = GetLayoutBytes(base.Footer);
			if (layoutBytes2.Count > 0)
			{
				fileStream.Write(layoutBytes2.Array, layoutBytes2.Offset, layoutBytes2.Count);
			}
		}
		catch (DirectoryNotFoundException)
		{
			if (!CreateDirs || !firstAttempt)
			{
				throw;
			}
			Directory.CreateDirectory(Path.GetDirectoryName(fileName));
			ReplaceFileContent(fileName, bytes, firstAttempt: false);
		}
	}

	private void WriteHeaderAndBom(BaseFileAppender appender)
	{
		if (base.Header == null && !WriteBom)
		{
			return;
		}
		long? fileLength = appender.GetFileLength();
		bool flag = !fileLength.HasValue || fileLength == 0;
		if (flag && WriteBom)
		{
			InternalLogger.Trace("{0}: Write byte order mark from encoding={1}", this, Encoding);
			byte[] preamble = Encoding.GetPreamble();
			if (preamble.Length != 0)
			{
				appender.Write(preamble, 0, preamble.Length);
			}
		}
		if (base.Header != null && (flag || WriteHeaderWhenInitialFileNotEmpty))
		{
			InternalLogger.Trace("{0}: Write header", this);
			ArraySegment<byte> layoutBytes = GetLayoutBytes(base.Header);
			if (layoutBytes.Count > 0)
			{
				appender.Write(layoutBytes.Array, layoutBytes.Offset, layoutBytes.Count);
			}
		}
	}

	private ArraySegment<byte> GetLayoutBytes(Layout layout)
	{
		if (layout == null)
		{
			return default(ArraySegment<byte>);
		}
		NLog.Internal.ReusableObjectCreator<StringBuilder>.LockOject lockOject = _reusableLayoutBuilder.Allocate();
		try
		{
			NLog.Internal.ReusableObjectCreator<char[]>.LockOject lockOject2 = _reusableEncodingBuffer.Allocate();
			try
			{
				LogEventInfo logEvent = LogEventInfo.CreateNullEvent();
				layout.Render(logEvent, lockOject.Result);
				lockOject.Result.Append(NewLineChars);
				using MemoryStream memoryStream = new MemoryStream(lockOject.Result.Length);
				TransformBuilderToStream(logEvent, lockOject.Result, lockOject2.Result, memoryStream);
				return new ArraySegment<byte>(memoryStream.ToArray());
			}
			finally
			{
				((IDisposable)lockOject2/*cast due to .constrained prefix*/).Dispose();
			}
		}
		finally
		{
			((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
		}
	}
}
