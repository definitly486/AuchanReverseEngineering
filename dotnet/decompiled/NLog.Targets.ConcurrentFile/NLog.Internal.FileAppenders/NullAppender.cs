using System;

namespace NLog.Internal.FileAppenders;

internal sealed class NullAppender : BaseFileAppender
{
	private sealed class Factory : IFileAppenderFactory
	{
		BaseFileAppender IFileAppenderFactory.Open(string fileName, ICreateFileParameters parameters)
		{
			return new NullAppender(fileName, parameters);
		}
	}

	public static readonly IFileAppenderFactory TheFactory = new Factory();

	public NullAppender(string fileName, ICreateFileParameters createParameters)
		: base(fileName, createParameters)
	{
	}

	public override void Close()
	{
	}

	public override void Flush()
	{
	}

	public override DateTime? GetFileCreationTimeUtc()
	{
		return DateTime.UtcNow;
	}

	public override long? GetFileLength()
	{
		return 0L;
	}

	public override void Write(byte[] bytes, int offset, int count)
	{
	}
}
