using System;
using Android.Runtime;
using Java.Interop;

namespace IO.Appmetrica.Analytics.Plugins;

[Register("io/appmetrica/analytics/plugins/AppMetricaPlugins", "", "IO.Appmetrica.Analytics.Plugins.IAppMetricaPluginsInvoker")]
public interface IAppMetricaPlugins : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("reportError", "(Lio/appmetrica/analytics/plugins/PluginErrorDetails;Ljava/lang/String;)V", "GetReportError_Lio_appmetrica_analytics_plugins_PluginErrorDetails_Ljava_lang_String_Handler:IO.Appmetrica.Analytics.Plugins.IAppMetricaPluginsInvoker, Appmetrica.Android")]
	void ReportError(PluginErrorDetails p0, string? p1);

	[Register("reportError", "(Ljava/lang/String;Ljava/lang/String;Lio/appmetrica/analytics/plugins/PluginErrorDetails;)V", "GetReportError_Ljava_lang_String_Ljava_lang_String_Lio_appmetrica_analytics_plugins_PluginErrorDetails_Handler:IO.Appmetrica.Analytics.Plugins.IAppMetricaPluginsInvoker, Appmetrica.Android")]
	void ReportError(string p0, string? p1, PluginErrorDetails? p2);

	[Register("reportUnhandledException", "(Lio/appmetrica/analytics/plugins/PluginErrorDetails;)V", "GetReportUnhandledException_Lio_appmetrica_analytics_plugins_PluginErrorDetails_Handler:IO.Appmetrica.Analytics.Plugins.IAppMetricaPluginsInvoker, Appmetrica.Android")]
	void ReportUnhandledException(PluginErrorDetails p0);
}
