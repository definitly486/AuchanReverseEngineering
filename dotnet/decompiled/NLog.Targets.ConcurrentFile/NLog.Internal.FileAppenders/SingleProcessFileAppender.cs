using System;
using System.IO;
using NLog.Common;

namespace NLog.Internal.FileAppenders;

internal sealed class SingleProcessFileAppender : BaseFileAppender
{
	private sealed class Factory : IFileAppenderFactory
	{
		BaseFileAppender IFileAppenderFactory.Open(string fileName, ICreateFileParameters parameters)
		{
			return new SingleProcessFileAppender(fileName, parameters);
		}
	}

	public static readonly IFileAppenderFactory TheFactory = new Factory();

	private FileStream _file;

	private readonly bool _enableFileDeleteSimpleMonitor;

	private int _lastSimpleMonitorCheckTickCount;

	public SingleProcessFileAppender(string fileName, ICreateFileParameters parameters)
		: base(fileName, parameters)
	{
		_file = CreateFileStream(allowFileSharedWriting: false);
		_enableFileDeleteSimpleMonitor = parameters.EnableFileDeleteSimpleMonitor;
		_lastSimpleMonitorCheckTickCount = Environment.TickCount;
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
			}
			_file.Write(bytes, offset, count);
		}
	}

	public override void Flush()
	{
		_file?.Flush();
	}

	public override void Close()
	{
		BaseFileAppender.CloseFileSafe(ref _file, base.FileName);
	}

	public override DateTime? GetFileCreationTimeUtc()
	{
		return base.CreationTimeUtc;
	}

	public override long? GetFileLength()
	{
		return _file?.Length;
	}
}
