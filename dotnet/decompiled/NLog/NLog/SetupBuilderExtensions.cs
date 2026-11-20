using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog;

public static class SetupBuilderExtensions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Logger GetCurrentClassLogger(this ISetupBuilder setupBuilder)
	{
		string classFullName = StackTraceUsageUtils.GetClassFullName(new StackFrame(1, needFileInfo: false));
		return setupBuilder.LogFactory.GetLogger(classFullName);
	}

	public static Logger GetLogger(this ISetupBuilder setupBuilder, string name)
	{
		return setupBuilder.LogFactory.GetLogger(name);
	}

	public static ISetupBuilder SetupLogFactory(this ISetupBuilder setupBuilder, Action<ISetupLogFactoryBuilder> logfactoryBuilder)
	{
		logfactoryBuilder(new SetupLogFactoryBuilder(setupBuilder.LogFactory));
		return setupBuilder;
	}

	public static ISetupBuilder SetupExtensions(this ISetupBuilder setupBuilder, Action<ISetupExtensionsBuilder> extensionsBuilder)
	{
		extensionsBuilder(new SetupExtensionsBuilder(setupBuilder.LogFactory));
		return setupBuilder;
	}

	public static ISetupBuilder SetupInternalLogger(this ISetupBuilder setupBuilder, Action<ISetupInternalLoggerBuilder> internalLoggerBuilder)
	{
		internalLoggerBuilder(new SetupInternalLoggerBuilder(setupBuilder.LogFactory));
		return setupBuilder;
	}

	public static ISetupBuilder SetupSerialization(this ISetupBuilder setupBuilder, Action<ISetupSerializationBuilder> serializationBuilder)
	{
		serializationBuilder(new SetupSerializationBuilder(setupBuilder.LogFactory));
		return setupBuilder;
	}

	public static ISetupBuilder LoadConfiguration(this ISetupBuilder setupBuilder, Action<ISetupLoadConfigurationBuilder> configBuilder)
	{
		LoggingConfiguration config = setupBuilder.LogFactory._config;
		SetupLoadConfigurationBuilder setupLoadConfigurationBuilder = new SetupLoadConfigurationBuilder(setupBuilder.LogFactory, config);
		configBuilder(setupLoadConfigurationBuilder);
		LoggingConfiguration configuration = setupLoadConfigurationBuilder._configuration;
		bool flag = config != setupBuilder.LogFactory._config;
		if (configuration == setupBuilder.LogFactory._config)
		{
			if (config != configuration || configuration != null)
			{
				setupBuilder.LogFactory.ReconfigExistingLoggers();
			}
		}
		else if (!flag || config != configuration)
		{
			setupBuilder.LogFactory.Configuration = configuration;
		}
		return setupBuilder;
	}

	public static ISetupBuilder LoadConfiguration(this ISetupBuilder setupBuilder, LoggingConfiguration loggingConfiguration)
	{
		setupBuilder.LogFactory.Configuration = loggingConfiguration;
		return setupBuilder;
	}

	public static ISetupBuilder LoadConfigurationFromFile(this ISetupBuilder setupBuilder, string? configFile = null, bool optional = true)
	{
		setupBuilder.LogFactory.LoadConfiguration(configFile, optional);
		return setupBuilder;
	}

	public static ISetupBuilder LoadConfigurationFromFile(this ISetupBuilder setupBuilder, IEnumerable<string> candidateFilePaths, bool optional = true)
	{
		if (candidateFilePaths == null)
		{
			setupBuilder.LogFactory.ResetCandidateConfigFilePath();
		}
		else if (optional)
		{
			IEnumerable<string> candidateConfigFilePaths = setupBuilder.LogFactory.GetCandidateConfigFilePaths();
			List<string> list = new List<string>(candidateFilePaths);
			HashSet<string> hashSet = new HashSet<string>(list, StringComparer.OrdinalIgnoreCase);
			foreach (string item in candidateConfigFilePaths)
			{
				if (hashSet.Add(item))
				{
					list.Add(item);
				}
			}
			setupBuilder.LogFactory.SetCandidateConfigFilePaths(list);
		}
		else
		{
			setupBuilder.LogFactory.SetCandidateConfigFilePaths(candidateFilePaths);
		}
		return setupBuilder.LoadConfigurationFromFile((string?)null, optional);
	}

	public static ISetupBuilder LoadConfigurationFromXml(this ISetupBuilder setupBuilder, string configXml)
	{
		setupBuilder.LogFactory.Configuration = XmlLoggingConfiguration.CreateFromXmlString(configXml, setupBuilder.LogFactory);
		return setupBuilder;
	}

	public static ISetupBuilder LoadConfigurationFromAssemblyResource(this ISetupBuilder setupBuilder, Assembly applicationAssembly, string resourceName = "NLog.config")
	{
		Guard.ThrowIfNull(applicationAssembly, "applicationAssembly");
		Guard.ThrowIfNullOrEmpty(resourceName, "resourceName");
		List<string> list = (from x in applicationAssembly.GetManifestResourceNames()
			where x.EndsWith(resourceName, StringComparison.OrdinalIgnoreCase)
			select x).ToList();
		if (list.Count == 1)
		{
			Stream manifestResourceStream = applicationAssembly.GetManifestResourceStream(list[0]);
			if (manifestResourceStream != null && manifestResourceStream.Length > 0)
			{
				InternalLogger.Info("Loading NLog XML config from assembly embedded resource '{0}'", resourceName);
				using StreamReader xmlSource = new StreamReader(manifestResourceStream);
				setupBuilder.LoadConfiguration(new XmlLoggingConfiguration(xmlSource, null, setupBuilder.LogFactory));
			}
			else
			{
				InternalLogger.Debug("No NLog config loaded. Empty Embedded resource '{0}' found in assembly: {1}", resourceName, applicationAssembly.FullName);
			}
		}
		else if (list.Count == 0)
		{
			InternalLogger.Debug("No NLog config loaded. No matching embedded resource '{0}' found in assembly: {1}", resourceName, applicationAssembly.FullName);
		}
		else
		{
			InternalLogger.Error("No NLog config loaded. Multiple matching embedded resource '{0}' found in assembly: {1}", resourceName, applicationAssembly.FullName);
		}
		return setupBuilder;
	}

	public static ISetupBuilder ReloadConfiguration(this ISetupBuilder setupBuilder)
	{
		try
		{
			InternalLogger.Debug("Reloading NLog LoggingConfiguration");
			LoggingConfiguration loggingConfiguration = setupBuilder.LogFactory._config?.Reload();
			if (loggingConfiguration == null)
			{
				return setupBuilder;
			}
			setupBuilder.LogFactory.Configuration = loggingConfiguration;
			return setupBuilder;
		}
		catch (NLogConfigurationException ex)
		{
			InternalLogger.Error(ex, "Failed to reload NLog LoggingConfiguration");
			if (ex.MustBeRethrown() || (setupBuilder.LogFactory.ThrowConfigExceptions ?? setupBuilder.LogFactory.ThrowExceptions))
			{
				throw;
			}
			return setupBuilder;
		}
		catch (Exception ex2)
		{
			InternalLogger.Error(ex2, "Failed to reload NLog LoggingConfiguration");
			if (ex2.MustBeRethrownImmediately())
			{
				throw;
			}
			return setupBuilder;
		}
	}
}
