using System;
using System.Globalization;
using System.Reflection;
using NLog.Config;
using NLog.Internal;
using NLog.Time;

namespace NLog;

public static class SetupLogFactoryBuilderExtensions
{
	public static ISetupLogFactoryBuilder SetTimeSource(this ISetupLogFactoryBuilder configBuilder, TimeSource timeSource)
	{
		TimeSource.Current = timeSource;
		return configBuilder;
	}

	public static ISetupLogFactoryBuilder SetTimeSourcAccurateUtc(this ISetupLogFactoryBuilder configBuilder)
	{
		return configBuilder.SetTimeSource(TimeSource.Current);
	}

	public static ISetupLogFactoryBuilder SetTimeSourcAccurateLocal(this ISetupLogFactoryBuilder configBuilder)
	{
		return configBuilder.SetTimeSource(TimeSource.Current);
	}

	public static ISetupLogFactoryBuilder SetGlobalContextProperty(this ISetupLogFactoryBuilder configBuilder, string name, object value)
	{
		GlobalDiagnosticsContext.Set(name, value);
		return configBuilder;
	}

	public static ISetupLogFactoryBuilder SetAutoShutdown(this ISetupLogFactoryBuilder configBuilder, bool enabled)
	{
		configBuilder.LogFactory.AutoShutdown = enabled;
		return configBuilder;
	}

	public static ISetupLogFactoryBuilder SetDefaultCultureInfo(this ISetupLogFactoryBuilder configBuilder, CultureInfo cultureInfo)
	{
		configBuilder.LogFactory.DefaultCultureInfo = cultureInfo;
		return configBuilder;
	}

	public static ISetupLogFactoryBuilder SetGlobalThreshold(this ISetupLogFactoryBuilder configBuilder, LogLevel logLevel)
	{
		configBuilder.LogFactory.GlobalThreshold = logLevel;
		return configBuilder;
	}

	public static ISetupLogFactoryBuilder SetThrowConfigExceptions(this ISetupLogFactoryBuilder configBuilder, bool enabled)
	{
		configBuilder.LogFactory.ThrowConfigExceptions = enabled;
		return configBuilder;
	}

	public static ISetupLogFactoryBuilder AddCallSiteHiddenAssembly(this ISetupLogFactoryBuilder configBuilder, Assembly assembly)
	{
		CallSiteInformation.AddCallSiteHiddenAssembly(assembly);
		return configBuilder;
	}

	public static ISetupLogFactoryBuilder AddCallSiteHiddenClassType(this ISetupLogFactoryBuilder configBuilder, Type type)
	{
		CallSiteInformation.AddCallSiteHiddenClassType(type);
		return configBuilder;
	}
}
