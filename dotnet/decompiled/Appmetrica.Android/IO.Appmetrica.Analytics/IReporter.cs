using System;
using System.Collections.Generic;
using Android.Runtime;
using IO.Appmetrica.Analytics.Ecommerce;
using IO.Appmetrica.Analytics.Plugins;
using IO.Appmetrica.Analytics.Profile;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/IReporter", "", "IO.Appmetrica.Analytics.IReporterInvoker")]
public interface IReporter : IJavaObject, IDisposable, IJavaPeerable
{
	IPluginReporter PluginExtension
	{
		[Register("getPluginExtension", "()Lio/appmetrica/analytics/plugins/IPluginReporter;", "GetGetPluginExtensionHandler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
		get;
	}

	[Register("clearAppEnvironment", "()V", "GetClearAppEnvironmentHandler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void ClearAppEnvironment();

	[Register("pauseSession", "()V", "GetPauseSessionHandler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void PauseSession();

	[Register("putAppEnvironmentValue", "(Ljava/lang/String;Ljava/lang/String;)V", "GetPutAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String_Handler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void PutAppEnvironmentValue(string p0, string? p1);

	[Register("reportAdRevenue", "(Lio/appmetrica/analytics/AdRevenue;)V", "GetReportAdRevenue_Lio_appmetrica_analytics_AdRevenue_Handler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void ReportAdRevenue(AdRevenue p0);

	[Register("reportAnr", "(Ljava/util/Map;)V", "GetReportAnr_Ljava_util_Map_Handler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void ReportAnr(IDictionary<Thread, StackTraceElement[]> p0);

	[Register("reportECommerce", "(Lio/appmetrica/analytics/ecommerce/ECommerceEvent;)V", "GetReportECommerce_Lio_appmetrica_analytics_ecommerce_ECommerceEvent_Handler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void ReportECommerce(ECommerceEvent p0);

	[Register("reportError", "(Ljava/lang/String;Ljava/lang/String;)V", "GetReportError_Ljava_lang_String_Ljava_lang_String_Handler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void ReportError(string p0, string? p1);

	[Register("reportError", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)V", "GetReportError_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_Handler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void ReportError(string p0, string? p1, Throwable? p2);

	[Register("reportError", "(Ljava/lang/String;Ljava/lang/Throwable;)V", "GetReportError_Ljava_lang_String_Ljava_lang_Throwable_Handler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void ReportError(string p0, Throwable? p1);

	[Register("reportEvent", "(Ljava/lang/String;)V", "GetReportEvent_Ljava_lang_String_Handler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void ReportEvent(string p0);

	[Register("reportEvent", "(Ljava/lang/String;Ljava/lang/String;)V", "GetReportEvent_Ljava_lang_String_Ljava_lang_String_Handler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void ReportEvent(string p0, string? p1);

	[Register("reportEvent", "(Ljava/lang/String;Ljava/util/Map;)V", "GetReportEvent_Ljava_lang_String_Ljava_util_Map_Handler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void ReportEvent(string p0, IDictionary<string, Java.Lang.Object>? p1);

	[Register("reportRevenue", "(Lio/appmetrica/analytics/Revenue;)V", "GetReportRevenue_Lio_appmetrica_analytics_Revenue_Handler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void ReportRevenue(Revenue p0);

	[Register("reportUnhandledException", "(Ljava/lang/Throwable;)V", "GetReportUnhandledException_Ljava_lang_Throwable_Handler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void ReportUnhandledException(Throwable p0);

	[Register("reportUserProfile", "(Lio/appmetrica/analytics/profile/UserProfile;)V", "GetReportUserProfile_Lio_appmetrica_analytics_profile_UserProfile_Handler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void ReportUserProfile(UserProfile p0);

	[Register("resumeSession", "()V", "GetResumeSessionHandler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void ResumeSession();

	[Register("sendEventsBuffer", "()V", "GetSendEventsBufferHandler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void SendEventsBuffer();

	[Register("setDataSendingEnabled", "(Z)V", "GetSetDataSendingEnabled_ZHandler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void SetDataSendingEnabled(bool p0);

	[Register("setUserProfileID", "(Ljava/lang/String;)V", "GetSetUserProfileID_Ljava_lang_String_Handler:IO.Appmetrica.Analytics.IReporterInvoker, Appmetrica.Android")]
	void SetUserProfileID(string? p0);
}
