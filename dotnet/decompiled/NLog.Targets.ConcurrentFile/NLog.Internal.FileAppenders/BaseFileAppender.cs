using System;
using System.IO;
using System.Threading;
using NLog.Common;
using NLog.Time;

namespace NLog.Internal.FileAppenders;

internal abstract class BaseFileAppender : IDisposable
{
	private readonly Random _random = new Random();

	private DateTime _creationTimeUtc;

	public string FileName { get; }

	public DateTime CreationTimeUtc
	{
		get
		{
			return _creationTimeUtc;
		}
		internal set
		{
			_creationTimeUtc = value;
			CreationTimeSource = TimeSource.Current.FromSystemTime(value);
		}
	}

	public DateTime CreationTimeSource { get; private set; }

	public DateTime OpenTimeUtc { get; private set; }

	public ICreateFileParameters CreateFileParameters { get; private set; }

	protected BaseFileAppender(string fileName, ICreateFileParameters createParameters)
	{
		CreateFileParameters = createParameters;
		FileName = fileName;
		OpenTimeUtc = DateTime.UtcNow;
	}

	public abstract void Write(byte[] bytes, int offset, int count);

	public abstract void Flush();

	public abstract void Close();

	public abstract DateTime? GetFileCreationTimeUtc();

	public abstract long? GetFileLength();

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			Close();
		}
	}

	protected FileStream CreateFileStream(bool allowFileSharedWriting, int overrideBufferSize = 0)
	{
		int num = CreateFileParameters.FileOpenRetryDelay;
		InternalLogger.Trace("{0}: Opening {1} with allowFileSharedWriting={2}", CreateFileParameters, FileName, allowFileSharedWriting);
		for (int i = 0; i <= CreateFileParameters.FileOpenRetryCount; i++)
		{
			try
			{
				return TryCreateDirectoryFileStream(allowFileSharedWriting, overrideBufferSize);
			}
			catch (IOException ex)
			{
				if (i + 1 >= CreateFileParameters.FileOpenRetryCount)
				{
					throw;
				}
				int num2 = _random.Next(num);
				InternalLogger.Warn("{0}: Attempt #{1} to open {2} failed - {3} {4}. Sleeping for {5}ms", CreateFileParameters, i, FileName, ex.GetType(), ex.Message, num2);
				num *= 2;
				Thread.Sleep(TimeSpan.FromMilliseconds((double)num2));
			}
		}
		throw new InvalidOperationException("Should not be reached.");
	}

	private FileStream TryCreateDirectoryFileStream(bool allowFileSharedWriting, int overrideBufferSize)
	{
		try
		{
			RefreshFileCreationTime();
			return TryCreateFileStream(allowFileSharedWriting, overrideBufferSize);
		}
		catch (DirectoryNotFoundException)
		{
			if (!CreateFileParameters.CreateDirs)
			{
				throw;
			}
			InternalLogger.Debug("{0}: DirectoryNotFoundException - Attempting to create directory for FileName: {1}", CreateFileParameters, FileName);
			string directoryName = Path.GetDirectoryName(FileName);
			try
			{
				Directory.CreateDirectory(directoryName);
			}
			catch (DirectoryNotFoundException innerException)
			{
				throw new NLogRuntimeException("Could not create directory " + directoryName, innerException);
			}
			return TryCreateFileStream(allowFileSharedWriting, overrideBufferSize);
		}
	}

	private FileStream TryCreateFileStream(bool allowFileSharedWriting, int overrideBufferSize)
	{
		int bufferSize = ((overrideBufferSize > 0) ? overrideBufferSize : CreateFileParameters.BufferSize);
		FileShare fileShare = ((!allowFileSharedWriting) ? FileShare.Read : FileShare.ReadWrite);
		if (CreateFileParameters.EnableFileDelete)
		{
			fileShare |= FileShare.Delete;
		}
		return new FileStream(FileName, FileMode.Append, FileAccess.Write, fileShare, bufferSize);
	}

	private void RefreshFileCreationTime()
	{
		CreationTimeUtc = DateTime.UtcNow;
		try
		{
			FileInfo fileInfo = new FileInfo(FileName);
			if (fileInfo.Exists)
			{
				CreationTimeUtc = fileInfo.LookupValidFileCreationTimeUtc();
			}
			else if (CreateFileParameters.IsArchivingEnabled || NLog.Internal.PlatformDetector.IsWin32)
			{
				File.Create(FileName).Dispose();
				File.SetCreationTimeUtc(FileName, CreationTimeUtc);
			}
		}
		catch (DirectoryNotFoundException)
		{
			throw;
		}
		catch (Exception ex2)
		{
			InternalLogger.Debug(ex2, "{0}: Failed to refresh CreationTimeUtc for FileName: {1}", CreateFileParameters, FileName);
		}
	}

	protected static void CloseFileSafe(ref FileStream fileStream, string fileName)
	{
		if (fileStream == null)
		{
			return;
		}
		InternalLogger.Trace("FileTarget: Closing '{0}'", fileName);
		try
		{
			fileStream.Close();
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "FileTarget: Failed to close file '{0}'", fileName);
			Thread.Sleep(TimeSpan.FromMilliseconds(1.0));
		}
		finally
		{
			fileStream = null;
		}
	}

	protected static bool MonitorForEnableFileDeleteEvent(string fileName, ref int lastSimpleMonitorCheckTickCount)
	{
		int num = Environment.TickCount - lastSimpleMonitorCheckTickCount;
		if (num > 1000 || num < -1000)
		{
			lastSimpleMonitorCheckTickCount = Environment.TickCount;
			try
			{
				if (!File.Exists(fileName))
				{
					return true;
				}
			}
			catch (Exception ex)
			{
				InternalLogger.Error(ex, "FileTarget: Failed to check if File.Exists: '{0}'", fileName);
				return true;
			}
		}
		return false;
	}
}
