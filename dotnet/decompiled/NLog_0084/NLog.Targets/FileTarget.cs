using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using NLog.Common;
using NLog.Internal;
using NLog.Internal.Fakeables;
using NLog.Layouts;
using NLog.Targets.FileAppenders;
using NLog.Targets.FileArchiveHandlers;
using NLog.Time;

namespace NLog.Targets;

[Target("File")]
public class FileTarget : TargetWithLayoutHeaderAndFooter
{
	private readonly struct OpenFileAppender
	{
		public IFileAppender FileAppender { get; }

		public int SequenceNumber { get; }

		public OpenFileAppender(IFileAppender fileAppender, int sequenceNumber)
		{
			FileAppender = fileAppender;
			SequenceNumber = sequenceNumber;
		}
	}

	private Layout _fileName = NLog.Layouts.Layout.Empty;

	private string? _fixedFileName;

	private Encoding _encoding = System.Text.Encoding.UTF8;

	private bool? _writeBom;

	private string? _archiveDateFormat;

	private long _archiveAboveSize;

	private FileArchivePeriod _archiveEvery;

	private Layout? _archiveFileName;

	private static readonly string _legacyDateArchiveSuffixFormat = "_{1:yyyyMMdd}_{0:00}";

	private static readonly string _legacySequenceArchiveSuffixFormat = "_{0:00}";

	private int _maxArchiveFiles = -1;

	private int _maxArchiveDays;

	private string? _archiveNumbering;

	private string? _archiveSuffixFormat;

	private IFileArchiveHandler? _fileArchiveHandler;

	private readonly Dictionary<string, OpenFileAppender> _openFileCache = new Dictionary<string, OpenFileAppender>(StringComparer.OrdinalIgnoreCase);

	private readonly ReusableStreamCreator _reusableFileWriteStream = new ReusableStreamCreator();

	private readonly ReusableStreamCreator _reusableBatchFileWriteStream = new ReusableStreamCreator(batchStream: true);

	private readonly ReusableBufferCreator _reusableEncodingBuffer = new ReusableBufferCreator(1024);

	private readonly SortHelpers.KeySelector<AsyncLogEventInfo, string> _getFileNameFromLayout;

	private DateTime _lastWriteTime;

	private Timer? _openFileMonitorTimer;

	private string _lastFileNameFromLayout = string.Empty;

	private static readonly char[] DirectorySeparatorChars = new char[2]
	{
		Path.DirectorySeparatorChar,
		Path.AltDirectorySeparatorChar
	};

	private static readonly HashSet<char> InvalidFileNameChars = new HashSet<char>(Path.GetInvalidFileNameChars());

	public Layout FileName
	{
		get
		{
			return _fileName;
		}
		set
		{
			_fileName = value;
			_fixedFileName = ((value is SimpleLayout { IsFixedText: not false } simpleLayout) ? simpleLayout.FixedText : null);
		}
	}

	public bool CreateDirs { get; set; } = true;

	public bool DeleteOldFileOnStartup { get; set; }

	public bool ReplaceFileContentsOnEachWrite { get; set; }

	public bool KeepFileOpen { get; set; } = true;

	public bool EnableFileDelete { get; set; } = true;

	public LineEndingMode LineEnding { get; set; } = LineEndingMode.Default;

	public bool AutoFlush { get; set; } = true;

	public int OpenFileCacheSize { get; set; } = 5;

	public int OpenFileCacheTimeout { get; set; }

	public int OpenFileFlushTimeout { get; set; }

	public int BufferSize { get; set; } = 32768;

	public Encoding Encoding
	{
		get
		{
			return _encoding;
		}
		set
		{
			_encoding = value;
			if (!_writeBom.HasValue && InitialValueBom(value))
			{
				_writeBom = true;
			}
		}
	}

	public bool DiscardAll { get; set; }

	public bool WriteBom
	{
		get
		{
			return _writeBom == true;
		}
		set
		{
			_writeBom = value;
		}
	}

	public bool ArchiveOldFileOnStartup { get; set; }

	public bool WriteHeaderWhenInitialFileNotEmpty { get; set; }

	[Obsolete("Instead use ArchiveSuffixFormat. Marked obsolete with NLog 6.0")]
	public string? ArchiveDateFormat
	{
		get
		{
			return _archiveDateFormat;
		}
		set
		{
			if (!string.Equals(value, _archiveDateFormat))
			{
				if (!string.IsNullOrEmpty(value))
				{
					ArchiveSuffixFormat = "_{1:" + value + "}_{0:00}";
				}
				_archiveDateFormat = value;
			}
		}
	}

	public long ArchiveAboveSize
	{
		get
		{
			return _archiveAboveSize;
		}
		set
		{
			_archiveAboveSize = ((value > 0) ? value : 0);
			_fileArchiveHandler = null;
		}
	}

	public FileArchivePeriod ArchiveEvery
	{
		get
		{
			return _archiveEvery;
		}
		set
		{
			_archiveEvery = value;
			_fileArchiveHandler = null;
		}
	}

	public Layout? ArchiveFileName
	{
		get
		{
			return _archiveFileName;
		}
		set
		{
			string text = _archiveSuffixFormat;
			if (value is SimpleLayout simpleLayout)
			{
				if ((simpleLayout.OriginalText.IndexOf("${date", StringComparison.OrdinalIgnoreCase) >= 0 || simpleLayout.OriginalText.IndexOf("${shortdate", StringComparison.OrdinalIgnoreCase) >= 0) && (_archiveSuffixFormat == null || (object)_legacySequenceArchiveSuffixFormat == _archiveSuffixFormat || (object)_legacyDateArchiveSuffixFormat == _archiveSuffixFormat))
				{
					text = "_{0}";
				}
				if (simpleLayout.OriginalText.Contains('#'))
				{
					string txt = simpleLayout.OriginalText.Replace(".{#}", string.Empty).Replace("_{#}", "").Replace("-{#}", "")
						.Replace("{#}", "")
						.Replace(".{#", "")
						.Replace("_{#", "")
						.Replace("-{#", "")
						.Replace("{#", "")
						.Replace("#}", "")
						.Replace("#", "");
					text = _archiveSuffixFormat ?? _legacySequenceArchiveSuffixFormat;
					value = new SimpleLayout(txt);
				}
			}
			_archiveFileName = value;
			if ((object)_archiveSuffixFormat != text && text != null)
			{
				ArchiveSuffixFormat = text;
			}
			_fileArchiveHandler = null;
		}
	}

	public int MaxArchiveFiles
	{
		get
		{
			return _maxArchiveFiles;
		}
		set
		{
			_maxArchiveFiles = value;
			_fileArchiveHandler = null;
		}
	}

	public int MaxArchiveDays
	{
		get
		{
			return _maxArchiveDays;
		}
		set
		{
			_maxArchiveDays = ((value > 0) ? value : 0);
			_fileArchiveHandler = null;
		}
	}

	[Obsolete("Instead use ArchiveSuffixFormat. Marked obsolete with NLog 6.0")]
	public string ArchiveNumbering
	{
		get
		{
			return _archiveNumbering ?? "Sequence";
		}
		set
		{
			if (!string.Equals(value, _archiveNumbering))
			{
				_archiveNumbering = (string.IsNullOrEmpty(value) ? null : value.Trim());
				if (_archiveNumbering != null && !string.IsNullOrEmpty(_archiveNumbering) && (_archiveSuffixFormat == null || (object)_archiveSuffixFormat == _legacyDateArchiveSuffixFormat || (object)_archiveSuffixFormat == _legacySequenceArchiveSuffixFormat))
				{
					ArchiveSuffixFormat = ((_archiveNumbering.IndexOf("date", StringComparison.OrdinalIgnoreCase) >= 0) ? _legacyDateArchiveSuffixFormat : _legacySequenceArchiveSuffixFormat);
				}
			}
		}
	}

	public string ArchiveSuffixFormat
	{
		get
		{
			if (ArchiveEvery != FileArchivePeriod.None && (_archiveSuffixFormat == null || (object)_legacyDateArchiveSuffixFormat == _archiveSuffixFormat || (object)_legacySequenceArchiveSuffixFormat == _archiveSuffixFormat) && ArchiveFileName != null)
			{
				return ArchiveEvery switch
				{
					FileArchivePeriod.Year => "_{1:yyyy}_{0:00}", 
					FileArchivePeriod.Month => "_{1:yyyyMM}_{0:00}", 
					FileArchivePeriod.Hour => "_{1:yyyyMMddHH}_{0:00}", 
					FileArchivePeriod.Minute => "_{1:yyyyMMddHHmm}_{0:00}", 
					_ => _legacyDateArchiveSuffixFormat, 
				};
			}
			return _archiveSuffixFormat ?? _legacySequenceArchiveSuffixFormat;
		}
		set
		{
			if (!string.IsNullOrEmpty(value) && ArchiveFileName is SimpleLayout simpleLayout && StringHelpers.IsNullOrWhiteSpace(Path.GetFileNameWithoutExtension(simpleLayout.OriginalText)) && value.IndexOf('_') == 0)
			{
				value = value.Substring(1);
			}
			_archiveSuffixFormat = value;
		}
	}

	public bool WriteFooterOnArchivingOnly { get; set; }

	private int OpenFileMonitorTimerInterval
	{
		get
		{
			if (OpenFileFlushTimeout <= 0 || AutoFlush || !KeepFileOpen)
			{
				return OpenFileCacheTimeout;
			}
			if (OpenFileCacheTimeout <= 0)
			{
				return OpenFileFlushTimeout;
			}
			return Math.Min(OpenFileFlushTimeout, OpenFileCacheTimeout);
		}
	}

	private IFileArchiveHandler FileAchiveHandler => _fileArchiveHandler ?? (_fileArchiveHandler = CreateFileArchiveHandler());

	public FileTarget()
	{
		_getFileNameFromLayout = (AsyncLogEventInfo l) => GetFileNameFromLayout(l.LogEvent);
	}

	public FileTarget(string name)
		: this()
	{
		base.Name = name;
	}

	protected override void FlushAsync(AsyncContinuation asyncContinuation)
	{
		try
		{
			InternalLogger.Trace("{0}: FlushAsync", this);
			if (_openFileCache.Count > 0)
			{
				foreach (KeyValuePair<string, OpenFileAppender> item in _openFileCache)
				{
					item.Value.FileAppender.Flush();
				}
			}
			asyncContinuation(null);
			InternalLogger.Trace("{0}: FlushAsync Done", this);
		}
		catch (Exception exception)
		{
			if (ExceptionMustBeRethrown(exception, "FlushAsync"))
			{
				throw;
			}
			asyncContinuation(exception);
		}
	}

	protected override void InitializeTarget()
	{
		if (FileName == null || FileName == NLog.Layouts.Layout.Empty)
		{
			throw new NLogConfigurationException("FileTarget FileName-property must be assigned. FileName is needed for file writing.");
		}
		if (OpenFileMonitorTimerInterval > 0)
		{
			_openFileMonitorTimer = new Timer(OpenFileMonitorTimer);
		}
		base.InitializeTarget();
	}

	protected override void CloseTarget()
	{
		Timer? openFileMonitorTimer = _openFileMonitorTimer;
		_openFileMonitorTimer = null;
		openFileMonitorTimer?.Change(-1, -1);
		openFileMonitorTimer?.Dispose();
		if (_openFileCache.Count > 0)
		{
			foreach (KeyValuePair<string, OpenFileAppender> item in _openFileCache.ToList())
			{
				CloseFileWithFooter(item.Key, item.Value, archiveFile: false);
			}
			_openFileCache.Clear();
		}
		base.CloseTarget();
	}

	protected override void Write(LogEventInfo logEvent)
	{
		string fileNameFromLayout = GetFileNameFromLayout(logEvent);
		if (string.IsNullOrEmpty(fileNameFromLayout))
		{
			throw new ArgumentException("The path is not of a legal form.");
		}
		try
		{
			ReusableObjectCreator<MemoryStream>.LockOject lockOject = _reusableBatchFileWriteStream.Allocate();
			try
			{
				ReusableObjectCreator<StringBuilder>.LockOject lockOject2 = ReusableLayoutBuilder.Allocate();
				try
				{
					ReusableObjectCreator<char[]>.LockOject lockOject3 = _reusableEncodingBuffer.Allocate();
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
				WriteBytesToFile(fileNameFromLayout, logEvent, lockOject.Result);
			}
			finally
			{
				((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "{0}: Failed writing to FileName: '{1}'", new ReadOnlySpan<object>(new object[2] { this, fileNameFromLayout }));
			throw;
		}
	}

	protected override void Write(IList<AsyncLogEventInfo> logEvents)
	{
		foreach (KeyValuePair<string, IList<AsyncLogEventInfo>> item in logEvents.BucketSort(_getFileNameFromLayout))
		{
			if (string.IsNullOrEmpty(item.Key))
			{
				InternalLogger.Warn("{0}: FileName Layout returned empty string. The path is not of a legal form.", this);
				ArgumentException exception = new ArgumentException("The path is not of a legal form.");
				for (int i = 0; i < logEvents.Count; i++)
				{
					logEvents[i].Continuation(exception);
				}
				continue;
			}
			try
			{
				WriteLogEventsToFile(item.Key, item.Value);
			}
			catch (Exception ex)
			{
				InternalLogger.Error(ex, "{0}: Failed writing to FileName: '{1}'", new ReadOnlySpan<object>(new object[2] { this, item.Key }));
				if (ExceptionMustBeRethrown(ex, "Write"))
				{
					throw;
				}
				for (int j = 0; j < item.Value.Count; j++)
				{
					item.Value[j].Continuation(ex);
				}
			}
		}
	}

	private void WriteLogEventsToFile(string filename, IList<AsyncLogEventInfo> logEvents)
	{
		ReusableObjectCreator<MemoryStream>.LockOject lockOject = _reusableBatchFileWriteStream.Allocate();
		try
		{
			MemoryStream memoryStream = lockOject.Result ?? new MemoryStream();
			int num = 0;
			while (num < logEvents.Count)
			{
				memoryStream.Position = 0L;
				memoryStream.SetLength(0L);
				int num2 = WriteToMemoryStream(logEvents, num, memoryStream);
				WriteBytesToFile(filename, logEvents[num].LogEvent, memoryStream);
				for (int i = 0; i < num2; i++)
				{
					logEvents[num++].Continuation(null);
				}
			}
		}
		finally
		{
			((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
		}
	}

	private string GetFileNameFromLayout(LogEventInfo logEvent)
	{
		if (_fixedFileName != null)
		{
			return _fixedFileName;
		}
		string text = _lastFileNameFromLayout;
		ReusableObjectCreator<StringBuilder>.LockOject lockOject = ReusableLayoutBuilder.Allocate();
		try
		{
			FileName.Render(logEvent, lockOject.Result);
			if (lockOject.Result.EqualTo(text))
			{
				return _lastFileNameFromLayout;
			}
			text = lockOject.Result.ToString();
		}
		finally
		{
			((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
		}
		_lastFileNameFromLayout = text;
		return text;
	}

	private int WriteToMemoryStream(IList<AsyncLogEventInfo> logEvents, int startIndex, MemoryStream ms)
	{
		long num = BufferSize * 100;
		ReusableObjectCreator<MemoryStream>.LockOject lockOject = _reusableFileWriteStream.Allocate();
		try
		{
			ReusableObjectCreator<StringBuilder>.LockOject lockOject2 = ReusableLayoutBuilder.Allocate();
			try
			{
				ReusableObjectCreator<char[]>.LockOject lockOject3 = _reusableEncodingBuffer.Allocate();
				try
				{
					StringBuilder result = lockOject2.Result;
					char[] result2 = lockOject3.Result;
					MemoryStream result3 = lockOject.Result;
					for (int i = startIndex; i < logEvents.Count; i++)
					{
						result3.Position = 0L;
						result3.SetLength(0L);
						result.ClearBuilder();
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

	private void RenderFormattedMessageToStream(LogEventInfo logEvent, StringBuilder formatBuilder, char[] transformBuffer, MemoryStream streamTarget)
	{
		RenderFormattedMessage(logEvent, formatBuilder);
		formatBuilder.Append(LineEnding.NewLineCharacters);
		formatBuilder.CopyToStream(streamTarget, Encoding, transformBuffer);
	}

	protected virtual void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
	{
		Layout.Render(logEvent, target);
	}

	private void WriteBytesToFile(string filename, LogEventInfo firstLogEvent, MemoryStream ms)
	{
		bool hasWritten = true;
		if (!_openFileCache.TryGetValue(filename, out var value))
		{
			hasWritten = false;
			value = OpenFile(filename, firstLogEvent, null);
		}
		try
		{
			if (ArchiveAboveSize != 0L || ArchiveEvery != FileArchivePeriod.None)
			{
				value = RollArchiveFile(filename, value, firstLogEvent, hasWritten);
			}
			value.FileAppender.Write(ms.GetBuffer(), 0, (int)ms.Length);
			if (AutoFlush)
			{
				value.FileAppender.Flush();
			}
		}
		catch
		{
			_openFileCache.Remove(filename);
			value.FileAppender.Dispose();
			throw;
		}
		finally
		{
			_lastWriteTime = firstLogEvent.TimeStamp;
		}
	}

	private OpenFileAppender RollArchiveFile(string filename, OpenFileAppender openFile, LogEventInfo firstLogEvent, bool hasWritten)
	{
		int num = -1;
		bool flag = ArchiveFileName == null;
		while (num != openFile.SequenceNumber && MustArchiveFile(openFile.FileAppender, firstLogEvent))
		{
			num = openFile.SequenceNumber;
			DateTime? dateTime = (flag ? ((DateTime?)null) : new DateTime?(openFile.FileAppender.FileLastModified));
			if (_lastWriteTime > DateTime.MinValue && dateTime > _lastWriteTime)
			{
				if (!(dateTime == openFile.FileAppender.OpenStreamTime))
				{
					DateTime date = firstLogEvent.TimeStamp.Date;
					DateTime? obj = dateTime?.Date;
					if (!(date == obj))
					{
						goto IL_0108;
					}
				}
				dateTime = _lastWriteTime;
			}
			goto IL_0108;
			IL_0108:
			if (hasWritten)
			{
				CloseFileWithFooter(filename, openFile, archiveFile: true);
			}
			else
			{
				CloseFile(filename, openFile);
			}
			hasWritten = false;
			openFile = OpenFile(filename, firstLogEvent, dateTime, openFile.SequenceNumber + 1);
		}
		return openFile;
	}

	private bool MustArchiveFile(IFileAppender fileAppender, LogEventInfo firstLogEvent)
	{
		if (ArchiveAboveSize != 0L && MustArchiveBySize(fileAppender))
		{
			return true;
		}
		if (ArchiveEvery != FileArchivePeriod.None && MustArchiveEveryTimePeriod(fileAppender, firstLogEvent))
		{
			return true;
		}
		return false;
	}

	private bool MustArchiveBySize(IFileAppender fileAppender)
	{
		long fileSize = fileAppender.FileSize;
		if (fileSize == 0L || fileSize + 1 < ArchiveAboveSize)
		{
			return false;
		}
		InternalLogger.Debug("{0}: Archive because of filesize={1} of file: {2}", this, fileSize, fileAppender.FilePath);
		return true;
	}

	private bool MustArchiveEveryTimePeriod(IFileAppender fileAppender, LogEventInfo firstLogEvent)
	{
		if (fileAppender.NextArchiveTime >= firstLogEvent.TimeStamp)
		{
			return false;
		}
		InternalLogger.Debug("{0}: Archive because of filetime of file: {1}", this, fileAppender.FilePath);
		return true;
	}

	internal static DateTime CalculateNextArchiveEventTime(FileArchivePeriod archiveEvery, DateTime fileBirthTime)
	{
		return archiveEvery switch
		{
			FileArchivePeriod.Year => new DateTime(fileBirthTime.Year, 1, 1, 0, 0, 0, fileBirthTime.Kind).AddYears(1), 
			FileArchivePeriod.Month => new DateTime(fileBirthTime.Year, fileBirthTime.Month, 1, 0, 0, 0, fileBirthTime.Kind).AddMonths(1), 
			FileArchivePeriod.Day => new DateTime(fileBirthTime.Year, fileBirthTime.Month, fileBirthTime.Day, 0, 0, 0, fileBirthTime.Kind).AddDays(1.0), 
			FileArchivePeriod.Hour => new DateTime(fileBirthTime.Year, fileBirthTime.Month, fileBirthTime.Day, fileBirthTime.Hour, 0, 0, fileBirthTime.Kind).AddHours(1.0), 
			FileArchivePeriod.Minute => new DateTime(fileBirthTime.Year, fileBirthTime.Month, fileBirthTime.Day, fileBirthTime.Hour, fileBirthTime.Minute, 0, fileBirthTime.Kind).AddMinutes(1.0), 
			FileArchivePeriod.Monday => CalculateNextWeekday(fileBirthTime, DayOfWeek.Monday), 
			FileArchivePeriod.Tuesday => CalculateNextWeekday(fileBirthTime, DayOfWeek.Tuesday), 
			FileArchivePeriod.Wednesday => CalculateNextWeekday(fileBirthTime, DayOfWeek.Wednesday), 
			FileArchivePeriod.Thursday => CalculateNextWeekday(fileBirthTime, DayOfWeek.Thursday), 
			FileArchivePeriod.Friday => CalculateNextWeekday(fileBirthTime, DayOfWeek.Friday), 
			FileArchivePeriod.Saturday => CalculateNextWeekday(fileBirthTime, DayOfWeek.Saturday), 
			FileArchivePeriod.Sunday => CalculateNextWeekday(fileBirthTime, DayOfWeek.Sunday), 
			_ => DateTime.MaxValue, 
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
		return previousLogEventTimestamp.Date.AddDays(num - dayOfWeek2);
	}

	private OpenFileAppender OpenFile(string filename, LogEventInfo firstLogEvent, DateTime? previousFileLastModified, int sequenceNumber = 0)
	{
		bool num = sequenceNumber == 0 && CreateDirs && _openFileCache.Count == 0;
		PruneOpenFileCache();
		sequenceNumber = FileAchiveHandler.ArchiveBeforeOpenFile(filename, firstLogEvent, previousFileLastModified, sequenceNumber);
		string text = BuildFullFilePath(filename, sequenceNumber);
		if (num)
		{
			InternalLogger.Debug("{0}: Verify directory and creating writer to file: {1}", this, text);
			string directoryName = Path.GetDirectoryName(text);
			if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
		}
		else
		{
			InternalLogger.Debug("{0}: Creating writer to file: {1}", this, text);
		}
		IFileAppender fileAppender = CreateFileAppender(text);
		OpenFileAppender openFileAppender = new OpenFileAppender(fileAppender, sequenceNumber);
		_openFileCache[filename] = openFileAppender;
		if (_openFileCache.Count == 1)
		{
			_openFileMonitorTimer?.Change(OpenFileMonitorTimerInterval * 1000, -1);
		}
		return openFileAppender;
	}

	private void PruneOpenFileCache()
	{
		while (_openFileCache.Count > 0)
		{
			KeyValuePair<string, OpenFileAppender> keyValuePair = default(KeyValuePair<string, OpenFileAppender>);
			foreach (KeyValuePair<string, OpenFileAppender> item in _openFileCache)
			{
				if (!item.Value.FileAppender.VerifyFileExists())
				{
					keyValuePair = item;
					break;
				}
			}
			if (string.IsNullOrEmpty(keyValuePair.Key))
			{
				break;
			}
			CloseFile(keyValuePair.Key, keyValuePair.Value);
		}
		while (_openFileCache.Count >= OpenFileCacheSize)
		{
			DateTime maxValue = DateTime.MaxValue;
			KeyValuePair<string, OpenFileAppender> keyValuePair2 = default(KeyValuePair<string, OpenFileAppender>);
			foreach (KeyValuePair<string, OpenFileAppender> item2 in _openFileCache)
			{
				if (item2.Value.FileAppender.OpenStreamTime < maxValue)
				{
					keyValuePair2 = item2;
				}
			}
			if (string.IsNullOrEmpty(keyValuePair2.Key))
			{
				CloseFileWithFooter(keyValuePair2.Key, keyValuePair2.Value, archiveFile: false);
				continue;
			}
			break;
		}
	}

	internal void CloseOpenFileBeforeArchiveCleanup(string filepath)
	{
		string a = ((_openFileCache.Count > 0) ? Path.GetFileName(filepath) : string.Empty);
		KeyValuePair<string, OpenFileAppender> keyValuePair;
		do
		{
			keyValuePair = default(KeyValuePair<string, OpenFileAppender>);
			foreach (KeyValuePair<string, OpenFileAppender> item in _openFileCache)
			{
				string fileName = Path.GetFileName(item.Value.FileAppender.FilePath);
				if (string.Equals(a, fileName, StringComparison.OrdinalIgnoreCase))
				{
					keyValuePair = item;
					break;
				}
			}
			if (keyValuePair.Key != null)
			{
				InternalLogger.Debug("{0}: Archive cleanup closing file: {1}", this, filepath);
				CloseFile(keyValuePair.Key, keyValuePair.Value);
			}
		}
		while (keyValuePair.Key != null);
	}

	private void CloseFile(string filename, OpenFileAppender openFile)
	{
		try
		{
			_openFileCache.Remove(filename);
			if (_openFileCache.Count == 0)
			{
				_openFileMonitorTimer?.Change(-1, -1);
			}
		}
		finally
		{
			openFile.FileAppender.Dispose();
		}
	}

	private void CloseFileWithFooter(string filename, OpenFileAppender openFile, bool archiveFile)
	{
		try
		{
			if (!ReplaceFileContentsOnEachWrite && (!WriteFooterOnArchivingOnly || archiveFile))
			{
				byte[] footerLayoutBytes = GetFooterLayoutBytes();
				if (footerLayoutBytes != null && footerLayoutBytes.Length != 0)
				{
					openFile.FileAppender.Write(footerLayoutBytes, 0, footerLayoutBytes.Length);
				}
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "{0}: Failed closing file: '{1}'", new ReadOnlySpan<object>(new object[2] { this, filename }));
			if (ex.MustBeRethrownImmediately())
			{
				throw;
			}
		}
		finally
		{
			CloseFile(filename, openFile);
		}
	}

	private void OpenFileMonitorTimer(object state)
	{
		bool flag = _openFileMonitorTimer != null;
		try
		{
			lock (base.SyncRoot)
			{
				flag = _openFileCache.Count != 0 && _openFileMonitorTimer != null;
				if (OpenFileCacheTimeout > 0)
				{
					PruneOpenFileCacheUsingTimeout();
				}
				if (OpenFileFlushTimeout > 0 && !AutoFlush)
				{
					DateTime dateTime = TimeSource.Current.Time.AddSeconds((double)(-(OpenFileFlushTimeout + 1)) * 1.5);
					if (_lastWriteTime > dateTime)
					{
						foreach (KeyValuePair<string, OpenFileAppender> item in _openFileCache)
						{
							item.Value.FileAppender.Flush();
						}
					}
				}
				flag = flag && _openFileCache.Count != 0;
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "{0}: Exception in OpenFileMonitorTimer", new ReadOnlySpan<object>(new object[1] { this }));
		}
		finally
		{
			if (flag)
			{
				_openFileMonitorTimer?.Change(OpenFileMonitorTimerInterval * 1000, -1);
			}
		}
	}

	private void PruneOpenFileCacheUsingTimeout()
	{
		DateTime dateTime = TimeSource.Current.Time.AddSeconds(-OpenFileCacheTimeout);
		bool flag = false;
		foreach (KeyValuePair<string, OpenFileAppender> item in _openFileCache)
		{
			if (item.Value.FileAppender.OpenStreamTime < dateTime)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		foreach (KeyValuePair<string, OpenFileAppender> item2 in _openFileCache.ToList())
		{
			if (item2.Value.FileAppender.OpenStreamTime < dateTime)
			{
				CloseFile(item2.Key, item2.Value);
			}
		}
	}

	internal string BuildFullFilePath(string newFileName, int sequenceNumber, DateTime fileLastModified = default(DateTime))
	{
		if (sequenceNumber > 0 || fileLastModified != default(DateTime))
		{
			string text = Path.GetFileName(newFileName) ?? string.Empty;
			string text2 = Path.GetExtension(text) ?? string.Empty;
			newFileName = newFileName.Substring(0, newFileName.Length - text.Length);
			if (!string.IsNullOrEmpty(text2))
			{
				text = text.Substring(0, text.Length - text2.Length);
			}
			object arg = ((fileLastModified == default(DateTime)) ? string.Empty : ((object)fileLastModified));
			try
			{
				newFileName = newFileName + text + string.Format(ArchiveSuffixFormat, sequenceNumber, arg) + text2;
			}
			catch (Exception ex)
			{
				InternalLogger.Error(ex, "{0}: Failed to apply ArchiveSuffixFormat={1} using SequenceNumber={2} for file: '{3}'", new ReadOnlySpan<object>(new object[4] { this, ArchiveSuffixFormat, sequenceNumber, newFileName }));
				if (ExceptionMustBeRethrown(ex, "BuildFullFilePath"))
				{
					throw;
				}
				newFileName = newFileName + text + string.Format(_legacySequenceArchiveSuffixFormat, sequenceNumber) + text2;
			}
		}
		return CleanFullFilePath(newFileName);
	}

	internal static string CleanFullFilePath(string filename)
	{
		int num = filename.LastIndexOfAny(DirectorySeparatorChars);
		char[] array = null;
		for (int i = num + 1; i < filename.Length; i++)
		{
			if (InvalidFileNameChars.Contains(filename[i]))
			{
				if (array == null)
				{
					array = filename.Substring(num + 1).ToCharArray();
				}
				array[i - (num + 1)] = '_';
			}
		}
		if (array != null)
		{
			filename = Path.Combine((num > 0) ? filename.Substring(0, num + 1) : string.Empty, new string(array));
		}
		return Path.GetFullPath(FileInfoHelper.IsRelativeFilePath(filename) ? Path.Combine(AppEnvironmentWrapper.FixFilePathWithLongUNC(LogManager.LogFactory.CurrentAppEnvironment.AppDomainBaseDirectory), filename) : filename);
	}

	private static bool InitialValueBom(Encoding encoding)
	{
		int num = encoding?.CodePage ?? 0;
		if (num != 1200 && num != 1201 && num != 12000)
		{
			return num == 12001;
		}
		return true;
	}

	private byte[] GetLayoutBytes(Layout layout)
	{
		if (layout == null)
		{
			return ArrayHelper.Empty<byte>();
		}
		ReusableObjectCreator<StringBuilder>.LockOject lockOject = ReusableLayoutBuilder.Allocate();
		try
		{
			ReusableObjectCreator<char[]>.LockOject lockOject2 = _reusableEncodingBuffer.Allocate();
			try
			{
				layout.Render(LogEventInfo.CreateNullEvent(), lockOject.Result);
				lockOject.Result.Append(LineEnding.NewLineCharacters);
				using MemoryStream memoryStream = new MemoryStream(lockOject.Result.Length);
				lockOject.Result.CopyToStream(memoryStream, Encoding, lockOject2.Result);
				return memoryStream.ToArray();
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

	internal byte[] GetFooterLayoutBytes()
	{
		if (base.Footer != null)
		{
			InternalLogger.Trace("{0}: Write footer", this);
			return GetLayoutBytes(base.Footer);
		}
		return ArrayHelper.Empty<byte>();
	}

	internal Stream CreateFileStreamWithRetry(IFileAppender fileAppender, int bufferSize, bool initialFileOpen)
	{
		int num = 1;
		int num2 = ((!KeepFileOpen) ? 5 : 0);
		string filePath = fileAppender.FilePath;
		for (int i = 0; i <= num2; i++)
		{
			try
			{
				return OpenNewFileStream(filePath, bufferSize, initialFileOpen);
			}
			catch (DirectoryNotFoundException)
			{
				if (!CreateDirs)
				{
					throw;
				}
				InternalLogger.Debug("{0}: DirectoryNotFoundException - Attempting to create directory for FileName: {1}", this, filePath);
				string directoryName = Path.GetDirectoryName(filePath);
				try
				{
					Directory.CreateDirectory(directoryName);
				}
				catch (Exception innerException)
				{
					throw new NLogRuntimeException("Could not create directory " + directoryName, innerException);
				}
			}
			catch (IOException ex2)
			{
				if (i >= num2)
				{
					throw;
				}
				int num3 = ((num > 4) ? new Random().Next(4, num) : num);
				InternalLogger.Warn("{0}: Attempt #{1} to open {2} failed - {3} {4}. Sleeping for {5}ms", new ReadOnlySpan<object>(new object[6]
				{
					this,
					i,
					filePath,
					ex2.GetType(),
					ex2.Message,
					num3
				}));
				num *= 4;
				Thread.Sleep(num3);
			}
		}
		throw new InvalidOperationException("Should not be reached.");
	}

	private Stream OpenNewFileStream(string filePath, int bufferSize, bool initialFileOpen)
	{
		Stream stream = CreateFileStream(filePath, bufferSize);
		try
		{
			bool? flag = null;
			if (WriteBom)
			{
				flag = ReplaceFileContentsOnEachWrite || stream.Length == 0;
				if (flag == true)
				{
					InternalLogger.Trace("{0}: Write byte order mark from encoding={1}", this, Encoding);
					byte[] preamble = Encoding.GetPreamble();
					if (preamble.Length != 0)
					{
						stream.Write(preamble, 0, preamble.Length);
					}
				}
			}
			if (base.Header != null && ((initialFileOpen && WriteHeaderWhenInitialFileNotEmpty) || ReplaceFileContentsOnEachWrite || (flag ?? (stream.Length == 0))))
			{
				InternalLogger.Trace("{0}: Write header", this);
				byte[] layoutBytes = GetLayoutBytes(base.Header);
				stream.Write(layoutBytes, 0, layoutBytes.Length);
			}
			return stream;
		}
		catch
		{
			stream?.Dispose();
			throw;
		}
	}

	protected virtual Stream CreateFileStream(string filePath, int bufferSize)
	{
		FileShare fileShare = FileShare.Read;
		if (EnableFileDelete)
		{
			fileShare |= FileShare.Delete;
		}
		FileMode mode = FileMode.Append;
		if (ReplaceFileContentsOnEachWrite)
		{
			mode = FileMode.Create;
		}
		return new FileStream(filePath, mode, FileAccess.Write, fileShare, bufferSize);
	}

	private IFileAppender CreateFileAppender(string filePath)
	{
		if (DiscardAll)
		{
			return new DiscardAllFileAppender(filePath);
		}
		if (ReplaceFileContentsOnEachWrite)
		{
			return new MinimalFileLockingAppender(this, filePath);
		}
		if (KeepFileOpen)
		{
			return new ExclusiveFileLockingAppender(this, filePath);
		}
		return new MinimalFileLockingAppender(this, filePath);
	}

	private IFileArchiveHandler CreateFileArchiveHandler()
	{
		if (MaxArchiveFiles < 0 && MaxArchiveDays == 0 && ArchiveAboveSize == 0L && ArchiveEvery == FileArchivePeriod.None)
		{
			if (!DeleteOldFileOnStartup && !ArchiveOldFileOnStartup)
			{
				return DisabledFileArchiveHandler.Default;
			}
			if (!ArchiveOldFileOnStartup)
			{
				return new ZeroFileArchiveHandler(this);
			}
		}
		if (MaxArchiveFiles == 0)
		{
			return new ZeroFileArchiveHandler(this);
		}
		if (ArchiveFileName == null)
		{
			return new RollingArchiveFileHandler(this);
		}
		return new LegacyArchiveFileNameHandler(this);
	}
}
