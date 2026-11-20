using System;
using System.Collections.Generic;
using System.Reflection;

namespace NLog.Internal.Fakeables;

internal interface IAppEnvironment : IFileSystem
{
	string AppDomainBaseDirectory { get; }

	string AppDomainConfigurationFile { get; }

	string AppDomainFriendlyName { get; }

	int AppDomainId { get; }

	IEnumerable<string> AppDomainPrivateBinPath { get; }

	string CurrentProcessFilePath { get; }

	string CurrentProcessBaseName { get; }

	int CurrentProcessId { get; }

	string EntryAssemblyLocation { get; }

	string EntryAssemblyFileName { get; }

	string UserTempFilePath { get; }

	event EventHandler ProcessExit;

	IEnumerable<Assembly> GetAppDomainRuntimeAssemblies();
}
