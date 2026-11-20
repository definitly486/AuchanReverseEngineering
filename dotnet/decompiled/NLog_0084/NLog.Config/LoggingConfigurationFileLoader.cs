using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using NLog.Common;
using NLog.Internal;
using NLog.Internal.Fakeables;

namespace NLog.Config;

internal class LoggingConfigurationFileLoader : ILoggingConfigurationLoader, IDisposable
{
	private readonly IAppEnvironment _appEnvironment;

	public LoggingConfigurationFileLoader(IAppEnvironment appEnvironment)
	{
		_appEnvironment = appEnvironment;
	}

	public LoggingConfiguration? Load(LogFactory logFactory, string? filename = null)
	{
		if (filename == null || StringHelpers.IsNullOrWhiteSpace(filename) || FileInfoHelper.IsRelativeFilePath(filename))
		{
			return TryLoadFromFilePaths(logFactory, filename);
		}
		if (TryLoadLoggingConfiguration(logFactory, filename, out LoggingConfiguration config))
		{
			return config;
		}
		return null;
	}

	private LoggingConfiguration? TryLoadFromFilePaths(LogFactory logFactory, string? filename)
	{
		foreach (string candidateConfigFilePath in logFactory.GetCandidateConfigFilePaths(filename))
		{
			if (TryLoadLoggingConfiguration(logFactory, candidateConfigFilePath, out LoggingConfiguration config))
			{
				return config;
			}
		}
		return null;
	}

	private bool TryLoadLoggingConfiguration(LogFactory logFactory, string configFile, out LoggingConfiguration? config)
	{
		try
		{
			if (_appEnvironment.FileExists(configFile))
			{
				config = LoadXmlLoggingConfigurationFile(logFactory, configFile);
				return true;
			}
			InternalLogger.Debug("No file exists at candidate config file location: {0}", configFile);
		}
		catch (IOException ex)
		{
			InternalLogger.Warn(ex, "Skipping invalid config file location: {0}", new ReadOnlySpan<object>(new object[1] { configFile }));
		}
		catch (UnauthorizedAccessException ex2)
		{
			InternalLogger.Warn(ex2, "Skipping inaccessible config file location: {0}", new ReadOnlySpan<object>(new object[1] { configFile }));
		}
		catch (SecurityException ex3)
		{
			InternalLogger.Warn(ex3, "Skipping inaccessible config file location: {0}", new ReadOnlySpan<object>(new object[1] { configFile }));
		}
		catch (Exception ex4)
		{
			InternalLogger.Error(ex4, "Failed loading from config file location: {0}", new ReadOnlySpan<object>(new object[1] { configFile }));
			if ((logFactory.ThrowConfigExceptions ?? logFactory.ThrowExceptions) || ex4.MustBeRethrown())
			{
				throw;
			}
		}
		config = null;
		return false;
	}

	private LoggingConfiguration LoadXmlLoggingConfigurationFile(LogFactory logFactory, string configFile)
	{
		InternalLogger.Debug("Reading config from XML file: {0}", configFile);
		using TextReader xmlSource = _appEnvironment.LoadTextFile(configFile);
		try
		{
			return new XmlLoggingConfiguration(xmlSource, configFile, logFactory);
		}
		catch (Exception ex)
		{
			if (ex.MustBeRethrown() || (logFactory.ThrowConfigExceptions ?? logFactory.ThrowExceptions))
			{
				throw;
			}
			if (ThrowXmlConfigExceptions(configFile, ex is XmlParserException, logFactory, out var autoReload))
			{
				throw;
			}
			return CreateEmptyDefaultConfig(configFile, logFactory, autoReload);
		}
	}

	private static LoggingConfiguration CreateEmptyDefaultConfig(string configFile, LogFactory logFactory, bool autoReload)
	{
		return new XmlLoggingConfiguration($"<nlog autoReload='{autoReload}'></nlog>", configFile, logFactory);
	}

	private static bool ThrowXmlConfigExceptions(string configFile, bool invalidXml, LogFactory logFactory, out bool autoReload)
	{
		autoReload = false;
		try
		{
			if (string.IsNullOrEmpty(configFile))
			{
				return false;
			}
			string fileContent = File.ReadAllText(configFile);
			if (invalidXml)
			{
				if (ScanForBooleanParameter(fileContent, "throwExceptions", parameterValue: true))
				{
					logFactory.ThrowExceptions = true;
					return true;
				}
				if (ScanForBooleanParameter(fileContent, "throwConfigExceptions", parameterValue: true))
				{
					logFactory.ThrowConfigExceptions = true;
					return true;
				}
			}
			if (ScanForBooleanParameter(fileContent, "autoReload", parameterValue: true))
			{
				autoReload = true;
			}
			return false;
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "Failed to scan content of config file: {0}", new ReadOnlySpan<object>(new object[1] { configFile }));
			return false;
		}
	}

	private static bool ScanForBooleanParameter(string fileContent, string parameterName, bool parameterValue)
	{
		if (fileContent.IndexOf($"{parameterName}=\"{parameterValue}", StringComparison.OrdinalIgnoreCase) < 0)
		{
			return fileContent.IndexOf($"{parameterName}='{parameterValue}", StringComparison.OrdinalIgnoreCase) >= 0;
		}
		return true;
	}

	public IEnumerable<string> GetDefaultCandidateConfigFilePaths(string? filename = null)
	{
		string baseDirectory = PathHelpers.TrimDirectorySeparators(_appEnvironment.AppDomainBaseDirectory);
		string entryAssemblyLocation = PathHelpers.TrimDirectorySeparators(_appEnvironment.EntryAssemblyLocation);
		if (filename == null)
		{
			foreach (string appSpecificNLogLocation in GetAppSpecificNLogLocations(baseDirectory, entryAssemblyLocation))
			{
				yield return appSpecificNLogLocation;
			}
		}
		string nlogConfigFile = filename ?? "NLog.config";
		if (!string.IsNullOrEmpty(baseDirectory))
		{
			yield return Path.Combine(baseDirectory, nlogConfigFile);
		}
		string nLogConfigFileLowerCase = nlogConfigFile.ToLower();
		bool platformFileSystemCaseInsensitive = nlogConfigFile == nLogConfigFileLowerCase || PlatformDetector.IsWin32;
		if (!platformFileSystemCaseInsensitive && !string.IsNullOrEmpty(baseDirectory))
		{
			yield return Path.Combine(baseDirectory, nLogConfigFileLowerCase);
		}
		if (!string.IsNullOrEmpty(entryAssemblyLocation) && !string.Equals(entryAssemblyLocation, baseDirectory, StringComparison.OrdinalIgnoreCase))
		{
			yield return Path.Combine(entryAssemblyLocation, nlogConfigFile);
			if (!platformFileSystemCaseInsensitive)
			{
				yield return Path.Combine(entryAssemblyLocation, nLogConfigFileLowerCase);
			}
		}
		if (string.IsNullOrEmpty(baseDirectory))
		{
			yield return nlogConfigFile;
			if (!platformFileSystemCaseInsensitive)
			{
				yield return nLogConfigFileLowerCase;
			}
		}
		foreach (string privateBinPathNLogLocation in GetPrivateBinPathNLogLocations(baseDirectory, nlogConfigFile, platformFileSystemCaseInsensitive ? nLogConfigFileLowerCase : string.Empty))
		{
			yield return privateBinPathNLogLocation;
		}
		string text = ((filename == null) ? LookupNLogAssemblyLocation() : null);
		if (!string.IsNullOrEmpty(text))
		{
			yield return text + ".nlog";
		}
	}

	private static string? LookupNLogAssemblyLocation()
	{
		string assemblyFileLocation = AssemblyHelpers.GetAssemblyFileLocation(typeof(LogFactory).Assembly);
		if (!string.IsNullOrEmpty(assemblyFileLocation))
		{
			return assemblyFileLocation;
		}
		return null;
	}

	public IEnumerable<string> GetAppSpecificNLogLocations(string baseDirectory, string entryAssemblyLocation)
	{
		string configurationFile = _appEnvironment.AppDomainConfigurationFile;
		if (!StringHelpers.IsNullOrWhiteSpace(configurationFile))
		{
			yield return Path.ChangeExtension(configurationFile, ".nlog");
			if (configurationFile.Contains(".vshost."))
			{
				yield return Path.ChangeExtension(configurationFile.Replace(".vshost.", "."), ".nlog");
			}
			yield break;
		}
		if (string.IsNullOrEmpty(entryAssemblyLocation))
		{
			entryAssemblyLocation = baseDirectory;
		}
		if (PathHelpers.IsTempDir(entryAssemblyLocation, _appEnvironment.UserTempFilePath))
		{
			string currentProcessFilePath = _appEnvironment.CurrentProcessFilePath;
			if (!string.IsNullOrEmpty(currentProcessFilePath))
			{
				yield return currentProcessFilePath + ".nlog";
			}
		}
		if (string.IsNullOrEmpty(entryAssemblyLocation))
		{
			yield break;
		}
		string assemblyFileName = _appEnvironment.EntryAssemblyFileName;
		if (!string.IsNullOrEmpty(assemblyFileName))
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(assemblyFileName);
			if (!string.IsNullOrEmpty(fileNameWithoutExtension))
			{
				yield return Path.Combine(entryAssemblyLocation, fileNameWithoutExtension + ".exe.nlog");
			}
			yield return Path.Combine(entryAssemblyLocation, assemblyFileName + ".nlog");
		}
	}

	private IEnumerable<string> GetPrivateBinPathNLogLocations(string baseDirectory, string nlogConfigFile, string nLogConfigFileLowerCase)
	{
		IEnumerable<string> appDomainPrivateBinPath = _appEnvironment.AppDomainPrivateBinPath;
		if (appDomainPrivateBinPath == null)
		{
			yield break;
		}
		foreach (string item in appDomainPrivateBinPath)
		{
			string path = PathHelpers.TrimDirectorySeparators(item);
			if (!StringHelpers.IsNullOrWhiteSpace(path) && !string.Equals(path, baseDirectory, StringComparison.OrdinalIgnoreCase))
			{
				yield return Path.Combine(path, nlogConfigFile);
				if (!string.IsNullOrEmpty(nLogConfigFileLowerCase))
				{
					yield return Path.Combine(path, nLogConfigFileLowerCase);
				}
			}
		}
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
