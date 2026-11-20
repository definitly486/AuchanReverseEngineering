using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using JetBrains.Annotations;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog;

public static class LogManager
{
	private static LogFactory? _logFactory;

	public static LogFactory LogFactory => _logFactory ?? CreateLogFactorySingleton();

	public static bool ThrowExceptions
	{
		get
		{
			return LogFactory.ThrowExceptions;
		}
		set
		{
			LogFactory.ThrowExceptions = value;
		}
	}

	public static bool? ThrowConfigExceptions
	{
		get
		{
			return LogFactory.ThrowConfigExceptions;
		}
		set
		{
			LogFactory.ThrowConfigExceptions = value;
		}
	}

	public static bool KeepVariablesOnReload
	{
		get
		{
			return LogFactory.KeepVariablesOnReload;
		}
		set
		{
			LogFactory.KeepVariablesOnReload = value;
		}
	}

	public static bool AutoShutdown
	{
		get
		{
			return LogFactory.AutoShutdown;
		}
		set
		{
			LogFactory.AutoShutdown = value;
		}
	}

	[CanBeNull]
	public static LoggingConfiguration? Configuration
	{
		get
		{
			return LogFactory.Configuration;
		}
		set
		{
			LogFactory.Configuration = value;
		}
	}

	public static LogLevel GlobalThreshold
	{
		get
		{
			return LogFactory.GlobalThreshold;
		}
		set
		{
			LogFactory.GlobalThreshold = value;
		}
	}

	public static event EventHandler<LoggingConfigurationChangedEventArgs> ConfigurationChanged
	{
		add
		{
			LogFactory.ConfigurationChanged += value;
		}
		remove
		{
			LogFactory.ConfigurationChanged -= value;
		}
	}

	private static LogFactory CreateLogFactorySingleton()
	{
		LogFactory logFactory = new LogFactory();
		if (Interlocked.CompareExchange(ref _logFactory, logFactory, null) != null)
		{
			logFactory.Dispose();
		}
		return _logFactory;
	}

	public static ISetupBuilder Setup()
	{
		return LogFactory.Setup();
	}

	public static LogFactory Setup(Action<ISetupBuilder> setupBuilder)
	{
		return LogFactory.Setup(setupBuilder);
	}

	[Obsolete("Replaced by LogManager.Setup().LoadConfigurationFromFile(). Marked obsolete on NLog 5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static LogFactory LoadConfiguration(string configFile)
	{
		return LogFactory.LoadConfiguration(configFile);
	}

	[Obsolete("Replaced by LogManager.Setup().SetupLogFactory(setup => setup.AddCallSiteHiddenAssembly(assembly)). Marked obsolete on NLog 5.3")]
	public static void AddHiddenAssembly(Assembly assembly)
	{
		CallSiteInformation.AddCallSiteHiddenAssembly(assembly);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CLSCompliant(false)]
	public static Logger GetCurrentClassLogger()
	{
		string classFullName = StackTraceUsageUtils.GetClassFullName(new StackFrame(1, needFileInfo: false));
		return LogFactory.GetLogger(classFullName);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CLSCompliant(false)]
	[Obsolete("Replaced by LogFactory.GetCurrentClassLogger<T>(). Marked obsolete on NLog 5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Logger GetCurrentClassLogger([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] Type loggerType)
	{
		string classFullName = StackTraceUsageUtils.GetClassFullName(new StackFrame(1, needFileInfo: false));
		return LogFactory.GetLogger(classFullName, loggerType);
	}

	public static Logger CreateNullLogger()
	{
		return LogFactory.CreateNullLogger();
	}

	public static Logger GetLogger(string name)
	{
		return LogFactory.GetLogger(name);
	}

	[Obsolete("Replaced by LogFactory.GetLogger<T>(). Marked obsolete on NLog 5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Logger GetLogger(string name, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] Type loggerType)
	{
		return LogFactory.GetLogger(name, loggerType);
	}

	public static void ReconfigExistingLoggers()
	{
		LogFactory.ReconfigExistingLoggers();
	}

	public static void ReconfigExistingLoggers(bool purgeObsoleteLoggers)
	{
		LogFactory.ReconfigExistingLoggers(purgeObsoleteLoggers);
	}

	public static void Flush()
	{
		LogFactory.Flush();
	}

	public static void Flush(TimeSpan timeout)
	{
		LogFactory.Flush(timeout);
	}

	public static void Flush(int timeoutMilliseconds)
	{
		LogFactory.Flush(timeoutMilliseconds);
	}

	public static void Flush(AsyncContinuation asyncContinuation)
	{
		LogFactory.Flush(asyncContinuation);
	}

	public static void Flush(AsyncContinuation asyncContinuation, TimeSpan timeout)
	{
		LogFactory.Flush(asyncContinuation, timeout);
	}

	public static void Flush(AsyncContinuation asyncContinuation, int timeoutMilliseconds)
	{
		LogFactory.Flush(asyncContinuation, timeoutMilliseconds);
	}

	[Obsolete("Use SuspendLogging() instead. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IDisposable DisableLogging()
	{
		return LogFactory.SuspendLogging();
	}

	[Obsolete("Use ResumeLogging() instead. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void EnableLogging()
	{
		LogFactory.ResumeLogging();
	}

	public static IDisposable SuspendLogging()
	{
		return LogFactory.SuspendLogging();
	}

	public static void ResumeLogging()
	{
		LogFactory.ResumeLogging();
	}

	public static bool IsLoggingEnabled()
	{
		return LogFactory.IsLoggingEnabled();
	}

	public static void Shutdown()
	{
		LogFactory.Shutdown();
	}
}
