using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace System.Net.Http;

internal static class GlobalHttpSettings
{
	internal static class DiagnosticsHandler
	{
		[CompilerGenerated]
		private static readonly bool _003CEnableActivityPropagation_003Ek__BackingField;

		[FeatureSwitchDefinition("System.Net.Http.EnableActivityPropagation")]
		public static bool EnableActivityPropagation
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
		} = RuntimeSettingParser.QueryRuntimeSettingSwitch("System.Net.Http.EnableActivityPropagation", "DOTNET_SYSTEM_NET_HTTP_ENABLEACTIVITYPROPAGATION", defaultValue: true);
	}

	internal static class MetricsHandler
	{
		[CompilerGenerated]
		private static readonly bool _003CIsGloballyEnabled_003Ek__BackingField;

		[FeatureSwitchDefinition("System.Diagnostics.Metrics.Meter.IsSupported")]
		public static bool IsGloballyEnabled
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
		} = RuntimeSettingParser.QueryRuntimeSettingSwitch("System.Diagnostics.Metrics.Meter.IsSupported", defaultValue: true);
	}

	internal static class SocketsHttpHandler
	{
		[CompilerGenerated]
		private static readonly bool _003CAllowHttp3_003Ek__BackingField;

		public static bool AllowHttp2 { get; } = RuntimeSettingParser.QueryRuntimeSettingSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", "DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_HTTP2SUPPORT", defaultValue: true);

		[SupportedOSPlatformGuard("linux")]
		[SupportedOSPlatformGuard("macOS")]
		[SupportedOSPlatformGuard("windows")]
		[FeatureSwitchDefinition("System.Net.SocketsHttpHandler.Http3Support")]
		public static bool AllowHttp3
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
		}

		public static bool DisableDynamicHttp2WindowSizing { get; }

		public static int MaxHttp2StreamWindowSize { get; }

		public static double Http2StreamWindowScaleThresholdMultiplier { get; }

		public static int PendingConnectionTimeoutOnRequestCompletion { get; }

		public static int MaxConnectionsPerServer { get; }

		private static int GetMaxHttp2StreamWindowSize()
		{
			int num = RuntimeSettingParser.ParseInt32EnvironmentVariableValue("DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_FLOWCONTROL_MAXSTREAMWINDOWSIZE", 16777216);
			if (num < 65535)
			{
				num = 65535;
			}
			return num;
		}

		private static double GetHttp2StreamWindowScaleThresholdMultiplier()
		{
			double num = RuntimeSettingParser.ParseDoubleEnvironmentVariableValue("DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_FLOWCONTROL_STREAMWINDOWSCALETHRESHOLDMULTIPLIER", 1.0);
			if (num < 0.0)
			{
				num = 1.0;
			}
			return num;
		}

		private static int GetMaxConnectionsPerServer()
		{
			int num = RuntimeSettingParser.QueryRuntimeSettingInt32("System.Net.SocketsHttpHandler.MaxConnectionsPerServer", "DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_MAXCONNECTIONSPERSERVER", int.MaxValue);
			if (num < 1)
			{
				num = int.MaxValue;
			}
			return num;
		}

		static SocketsHttpHandler()
		{
			if (false)
			{
			}
			_ = 0;
			AllowHttp3 = RuntimeSettingParser.QueryRuntimeSettingSwitch("System.Net.SocketsHttpHandler.Http3Support", "DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_HTTP3SUPPORT", defaultValue: false);
			DisableDynamicHttp2WindowSizing = RuntimeSettingParser.QueryRuntimeSettingSwitch("System.Net.SocketsHttpHandler.Http2FlowControl.DisableDynamicWindowSizing", "DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_HTTP2FLOWCONTROL_DISABLEDYNAMICWINDOWSIZING", defaultValue: false);
			MaxHttp2StreamWindowSize = GetMaxHttp2StreamWindowSize();
			Http2StreamWindowScaleThresholdMultiplier = GetHttp2StreamWindowScaleThresholdMultiplier();
			PendingConnectionTimeoutOnRequestCompletion = RuntimeSettingParser.QueryRuntimeSettingInt32("System.Net.SocketsHttpHandler.PendingConnectionTimeoutOnRequestCompletion", "DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_PENDINGCONNECTIONTIMEOUTONREQUESTCOMPLETION", 5000);
			MaxConnectionsPerServer = GetMaxConnectionsPerServer();
		}
	}
}
