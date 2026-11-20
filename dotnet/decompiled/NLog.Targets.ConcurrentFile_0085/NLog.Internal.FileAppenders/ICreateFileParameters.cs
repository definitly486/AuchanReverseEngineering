namespace NLog.Internal.FileAppenders;

internal interface ICreateFileParameters
{
	int FileOpenRetryCount { get; }

	int FileOpenRetryDelay { get; }

	bool ConcurrentWrites { get; }

	bool CreateDirs { get; }

	bool EnableFileDelete { get; }

	int BufferSize { get; }

	bool IsArchivingEnabled { get; }

	bool EnableFileDeleteSimpleMonitor { get; }
}
