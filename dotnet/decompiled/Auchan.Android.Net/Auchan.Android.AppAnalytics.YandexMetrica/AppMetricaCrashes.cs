using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Android.Runtime;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Logs;
using IO.Appmetrica.Analytics;
using IO.Appmetrica.Analytics.Plugins;
using Java.Lang;

namespace Auchan.Android.AppAnalytics.YandexMetrica;

internal static class AppMetricaCrashes
{
	private static bool _initialized;

	private static System.Exception? _exception;

	private static ILogService? _logService;

	public static void Init(ILogService logService)
	{
		if (!_initialized)
		{
			_initialized = true;
			_logService = logService;
			AndroidEnvironment.UnhandledExceptionRaiser += OnUnhandledException;
			AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
		}
	}

	private static void OnUnhandledException(object? sender, RaiseThrowableEventArgs e)
	{
		OnUnhandledException(e.Exception, "AndroidEnvironment");
	}

	private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		OnUnhandledException(e.ExceptionObject as System.Exception, "AppDomain");
	}

	private static void OnUnhandledException(System.Exception? exception, string source)
	{
		try
		{
			if (_exception == null && exception != null)
			{
				PluginErrorDetails errorDetailsFor = GetErrorDetailsFor(".net unhandled exception", exception, null);
				IO.Appmetrica.Analytics.AppMetrica.PluginExtension.ReportUnhandledException(errorDetailsFor);
				_exception = exception;
				_logService?.LogUnrecoverableCrashAsync(exception).GetAwaiter().GetResult();
				Task.Delay(500).GetAwaiter().GetResult();
			}
		}
		catch (System.Exception)
		{
		}
	}

	public static PluginErrorDetails GetErrorDetailsFor(string message, System.Exception ex, IReadOnlyDictionary<string, string>? environment)
	{
		Type type = ex.GetType();
		ImmutableList<StackTraceItem> value = (from i in StackTraceParser.Parse(ex)
			select new StackTraceItem.Builder().WithClassName(i.ClassName).WithFileName(i.FileName).WithLine(Integer.ValueOf(i.LineNumber))
				.WithMethodName(i.MethodName)
				.Build()).ToImmutableList();
		return new PluginErrorDetails.Builder().WithExceptionClass(type.FullName ?? type.Name).WithMessage(message + " [" + ex.Message + "]").WithStacktrace(value)
			.WithPlatform(".net-android")
			.WithVirtualMachineVersion(Environment.Version.ToString())
			.WithPluginEnvironment((environment != null) ? new Dictionary<string, string>(environment) : null)
			.Build();
	}
}
