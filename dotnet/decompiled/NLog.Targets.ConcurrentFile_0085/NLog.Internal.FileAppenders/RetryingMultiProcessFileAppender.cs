using System;
using System.IO;

namespace NLog.Internal.FileAppenders;

internal sealed class RetryingMultiProcessFileAppender : BaseMutexFileAppender
{
	private sealed class Factory : IFileAppenderFactory
	{
		BaseFileAppender IFileAppenderFactory.Open(string fileName, ICreateFileParameters parameters)
		{
			return new RetryingMultiProcessFileAppender(fileName, parameters);
		}
	}

	public static readonly IFileAppenderFactory TheFactory = new Factory();

	public RetryingMultiProcessFileAppender(string fileName, ICreateFileParameters parameters)
		: base(fileName, parameters)
	{
	}

	public override void Write(byte[] bytes, int offset, int count)
	{
		int overrideBufferSize = Math.Min((count / 4096 + 1) * 4096, base.CreateFileParameters.BufferSize);
		using FileStream fileStream = CreateFileStream(allowFileSharedWriting: false, overrideBufferSize);
		fileStream.Write(bytes, offset, count);
	}

	public override void Flush()
	{
	}

	public override void Close()
	{
	}

	public override DateTime? GetFileCreationTimeUtc()
	{
		FileInfo fileInfo = new FileInfo(base.FileName);
		if (fileInfo.Exists)
		{
			return fileInfo.LookupValidFileCreationTimeUtc();
		}
		return null;
	}

	public override long? GetFileLength()
	{
		FileInfo fileInfo = new FileInfo(base.FileName);
		if (fileInfo.Exists)
		{
			return fileInfo.Length;
		}
		return null;
	}
}
