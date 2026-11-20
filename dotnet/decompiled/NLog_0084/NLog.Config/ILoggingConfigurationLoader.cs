using System;
using System.Collections.Generic;

namespace NLog.Config;

internal interface ILoggingConfigurationLoader : IDisposable
{
	LoggingConfiguration? Load(LogFactory logFactory, string? filename = null);

	IEnumerable<string> GetDefaultCandidateConfigFilePaths(string? filename = null);
}
