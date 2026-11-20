using System;

namespace NLog.Targets.FileAppenders;

internal interface IFileAppender : IDisposable
{
	string FilePath { get; }

	long FileSize { get; }

	DateTime OpenStreamTime { get; }

	DateTime FileLastModified { get; }

	DateTime NextArchiveTime { get; }

	void Write(byte[] buffer, int offset, int count);

	void Flush();

	bool VerifyFileExists();
}
