using System;
using System.IO;
using System.Threading;
using NLog.Common;

namespace NLog.Internal.FileAppenders;

internal sealed class MutexMultiProcessFileAppender : BaseMutexFileAppender
{
	private sealed class Factory : IFileAppenderFactory
	{
		BaseFileAppender IFileAppenderFactory.Open(string fileName, ICreateFileParameters parameters)
		{
			return new MutexMultiProcessFileAppender(fileName, parameters);
		}
	}

	public static readonly IFileAppenderFactory TheFactory = new Factory();

	private FileStream _fileStream;

	private Mutex _mutex;

	public MutexMultiProcessFileAppender(string fileName, ICreateFileParameters parameters)
		: base(fileName, parameters)
	{
		try
		{
			_mutex = CreateSharableMutex("FileLock");
			_fileStream = CreateFileStream(allowFileSharedWriting: true);
		}
		catch
		{
			_mutex?.Close();
			_mutex = null;
			_fileStream?.Close();
			_fileStream = null;
			throw;
		}
	}

	public override void Write(byte[] bytes, int offset, int count)
	{
		if (_mutex == null || _fileStream == null)
		{
			return;
		}
		try
		{
			_mutex.WaitOne();
		}
		catch (AbandonedMutexException)
		{
		}
		try
		{
			_fileStream.Seek(0L, SeekOrigin.End);
			_fileStream.Write(bytes, offset, count);
			_fileStream.Flush();
		}
		finally
		{
			_mutex.ReleaseMutex();
		}
	}

	public override void Close()
	{
		BaseFileAppender.CloseFileSafe(ref _fileStream, base.FileName);
		try
		{
			_mutex?.Close();
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "{0}: Failed to close mutex: '{1}'", base.CreateFileParameters, base.FileName);
		}
		finally
		{
			_mutex = null;
		}
	}

	public override void Flush()
	{
	}

	public override DateTime? GetFileCreationTimeUtc()
	{
		return base.CreationTimeUtc;
	}

	public override long? GetFileLength()
	{
		return _fileStream?.Length;
	}
}
