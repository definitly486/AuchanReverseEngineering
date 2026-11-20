using System;
using System.IO;
using NLog.Common;

namespace NLog.Internal.FileAppenders;

internal class CountingSingleProcessFileAppender : BaseFileAppender
{
	private sealed class Factory : IFileAppenderFactory
	{
		BaseFileAppender IFileAppenderFactory.Open(string fileName, ICreateFileParameters parameters)
		{
			return new CountingSingleProcessFileAppender(fileName, parameters);
		}
	}

	public static readonly IFileAppenderFactory TheFactory = new Factory();

	private FileStream _file;

	private long _currentFileLength;

	private readonly bool _enableFileDeleteSimpleMonitor;

	private int _lastSimpleMonitorCheckTickCount;

	public CountingSingleProcessFileAppender(string fileName, ICreateFileParameters parameters)
		: base(fileName, parameters)
	{
		FileInfo fileInfo = new FileInfo(fileName);
		_currentFileLength = (fileInfo.Exists ? fileInfo.Length : 0);
		_file = CreateFileStream(allowFileSharedWriting: false);
		_enableFileDeleteSimpleMonitor = parameters.EnableFileDeleteSimpleMonitor;
		_lastSimpleMonitorCheckTickCount = Environment.TickCount;
	}

	public override void Close()
	{
		BaseFileAppender.CloseFileSafe(ref _file, base.FileName);
	}

	public override void Flush()
	{
		_file?.Flush();
	}

	public override DateTime? GetFileCreationTimeUtc()
	{
		return base.CreationTimeUtc;
	}

	public override long? GetFileLength()
	{
		return _currentFileLength;
	}

	public override void Write(byte[] bytes, int offset, int count)
	{
		if (_file != null)
		{
			if (_enableFileDeleteSimpleMonitor && BaseFileAppender.MonitorForEnableFileDeleteEvent(base.FileName, ref _lastSimpleMonitorCheckTickCount))
			{
				InternalLogger.Debug("{0}: Recreating FileStream because no longer File.Exists: '{1}'", base.CreateFileParameters, base.FileName);
				BaseFileAppender.CloseFileSafe(ref _file, base.FileName);
				_file = CreateFileStream(allowFileSharedWriting: false);
				_currentFileLength = _file.Length;
			}
			_currentFileLength += count;
			_file.Write(bytes, offset, count);
		}
	}
}
