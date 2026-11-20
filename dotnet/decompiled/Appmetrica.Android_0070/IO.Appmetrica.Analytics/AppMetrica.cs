using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.Runtime;
using Android.Webkit;
using IO.Appmetrica.Analytics.Ecommerce;
using IO.Appmetrica.Analytics.Plugins;
using IO.Appmetrica.Analytics.Profile;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/AppMetrica", DoNotGenerateAcw = true)]
public sealed class AppMetrica : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/AppMetrica", typeof(AppMetrica));

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe static int LibraryApiLevel
	{
		[Register("getLibraryApiLevel", "()I", "")]
		get
		{
			return _members.StaticMethods.InvokeInt32Method("getLibraryApiLevel.()I", null);
		}
	}

	public unsafe static string LibraryVersion
	{
		[Register("getLibraryVersion", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getLibraryVersion.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe static IAppMetricaPlugins PluginExtension
	{
		[Register("getPluginExtension", "()Lio/appmetrica/analytics/plugins/AppMetricaPlugins;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IAppMetricaPlugins>(_members.StaticMethods.InvokeObjectMethod("getPluginExtension.()Lio/appmetrica/analytics/plugins/AppMetricaPlugins;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal AppMetrica(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("activate", "(Landroid/content/Context;Lio/appmetrica/analytics/AppMetricaConfig;)V", "")]
	public unsafe static void Activate(Context context, AppMetricaConfig config)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("activate.(Landroid/content/Context;Lio/appmetrica/analytics/AppMetricaConfig;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(config);
		}
	}

	[Register("activateReporter", "(Landroid/content/Context;Lio/appmetrica/analytics/ReporterConfig;)V", "")]
	public unsafe static void ActivateReporter(Context context, ReporterConfig config)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("activateReporter.(Landroid/content/Context;Lio/appmetrica/analytics/ReporterConfig;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(config);
		}
	}

	[Register("clearAppEnvironment", "()V", "")]
	public unsafe static void ClearAppEnvironment()
	{
		_members.StaticMethods.InvokeVoidMethod("clearAppEnvironment.()V", null);
	}

	[Register("enableActivityAutoTracking", "(Landroid/app/Application;)V", "")]
	public unsafe static void EnableActivityAutoTracking(Application application)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(application?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("enableActivityAutoTracking.(Landroid/app/Application;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(application);
		}
	}

	[Register("getDeviceId", "(Landroid/content/Context;)Ljava/lang/String;", "")]
	public unsafe static string? GetDeviceId(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getDeviceId.(Landroid/content/Context;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getReporter", "(Landroid/content/Context;Ljava/lang/String;)Lio/appmetrica/analytics/IReporter;", "")]
	public unsafe static IReporter GetReporter(Context context, string apiKey)
	{
		nint num = JNIEnv.NewString(apiKey);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IReporter>(_members.StaticMethods.InvokeObjectMethod("getReporter.(Landroid/content/Context;Ljava/lang/String;)Lio/appmetrica/analytics/IReporter;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
		}
	}

	[Register("getUuid", "(Landroid/content/Context;)Ljava/lang/String;", "")]
	public unsafe static string? GetUuid(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getUuid.(Landroid/content/Context;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("initWebViewReporting", "(Landroid/webkit/WebView;)V", "")]
	public unsafe static void InitWebViewReporting(WebView webView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(webView?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("initWebViewReporting.(Landroid/webkit/WebView;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(webView);
		}
	}

	[Register("pauseSession", "(Landroid/app/Activity;)V", "")]
	public unsafe static void PauseSession(Activity? activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("pauseSession.(Landroid/app/Activity;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Register("putAppEnvironmentValue", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
	public unsafe static void PutAppEnvironmentValue(string key, string? value)
	{
		nint num = JNIEnv.NewString(key);
		nint num2 = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.StaticMethods.InvokeVoidMethod("putAppEnvironmentValue.(Ljava/lang/String;Ljava/lang/String;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	[Register("putErrorEnvironmentValue", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
	public unsafe static void PutErrorEnvironmentValue(string key, string? value)
	{
		nint num = JNIEnv.NewString(key);
		nint num2 = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.StaticMethods.InvokeVoidMethod("putErrorEnvironmentValue.(Ljava/lang/String;Ljava/lang/String;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	[Register("registerAnrListener", "(Lio/appmetrica/analytics/AnrListener;)V", "")]
	public unsafe static void RegisterAnrListener(IAnrListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.StaticMethods.InvokeVoidMethod("registerAnrListener.(Lio/appmetrica/analytics/AnrListener;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("reportAdRevenue", "(Lio/appmetrica/analytics/AdRevenue;)V", "")]
	public unsafe static void ReportAdRevenue(AdRevenue adRevenue)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(adRevenue?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("reportAdRevenue.(Lio/appmetrica/analytics/AdRevenue;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(adRevenue);
		}
	}

	[Register("reportAnr", "(Ljava/util/Map;)V", "")]
	public unsafe static void ReportAnr(IDictionary<Thread, StackTraceElement[]> allThreads)
	{
		nint num = JavaDictionary<Thread, StackTraceElement[]>.ToLocalJniHandle(allThreads);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("reportAnr.(Ljava/util/Map;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(allThreads);
		}
	}

	[Register("reportAppOpen", "(Landroid/app/Activity;)V", "")]
	public unsafe static void ReportAppOpen(Activity activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("reportAppOpen.(Landroid/app/Activity;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Register("reportAppOpen", "(Landroid/content/Intent;)V", "")]
	public unsafe static void ReportAppOpen(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("reportAppOpen.(Landroid/content/Intent;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("reportAppOpen", "(Ljava/lang/String;)V", "")]
	public unsafe static void ReportAppOpen(string deeplink)
	{
		nint num = JNIEnv.NewString(deeplink);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("reportAppOpen.(Ljava/lang/String;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("reportECommerce", "(Lio/appmetrica/analytics/ecommerce/ECommerceEvent;)V", "")]
	public unsafe static void ReportECommerce(ECommerceEvent e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("reportECommerce.(Lio/appmetrica/analytics/ecommerce/ECommerceEvent;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	[Register("reportError", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
	public unsafe static void ReportError(string identifier, string? message)
	{
		nint num = JNIEnv.NewString(identifier);
		nint num2 = JNIEnv.NewString(message);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.StaticMethods.InvokeVoidMethod("reportError.(Ljava/lang/String;Ljava/lang/String;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	[Register("reportError", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
	public unsafe static void ReportError(string identifier, string? message, Throwable? error)
	{
		nint num = JNIEnv.NewString(identifier);
		nint num2 = JNIEnv.NewString(message);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(error?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("reportError.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(error);
		}
	}

	[Register("reportError", "(Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
	public unsafe static void ReportError(string message, Throwable? error)
	{
		nint num = JNIEnv.NewString(message);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(error?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("reportError.(Ljava/lang/String;Ljava/lang/Throwable;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(error);
		}
	}

	[Register("reportEvent", "(Ljava/lang/String;)V", "")]
	public unsafe static void ReportEvent(string eventName)
	{
		nint num = JNIEnv.NewString(eventName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("reportEvent.(Ljava/lang/String;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("reportEvent", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
	public unsafe static void ReportEvent(string eventName, string? jsonValue)
	{
		nint num = JNIEnv.NewString(eventName);
		nint num2 = JNIEnv.NewString(jsonValue);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.StaticMethods.InvokeVoidMethod("reportEvent.(Ljava/lang/String;Ljava/lang/String;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	[Register("reportEvent", "(Ljava/lang/String;Ljava/util/Map;)V", "")]
	public unsafe static void ReportEvent(string eventName, IDictionary<string, Java.Lang.Object>? attributes)
	{
		nint num = JNIEnv.NewString(eventName);
		nint num2 = JavaDictionary<string, Java.Lang.Object>.ToLocalJniHandle(attributes);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.StaticMethods.InvokeVoidMethod("reportEvent.(Ljava/lang/String;Ljava/util/Map;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(attributes);
		}
	}

	[Register("reportExternalAdRevenue", "([Ljava/lang/Object;)V", "")]
	public unsafe static void ReportExternalAdRevenue(params Java.Lang.Object[] values)
	{
		nint num = JNIEnv.NewArray(values);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("reportExternalAdRevenue.([Ljava/lang/Object;)V", ptr);
		}
		finally
		{
			if (values != null)
			{
				JNIEnv.CopyArray(num, values);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(values);
		}
	}

	[Register("reportExternalAttribution", "(Lio/appmetrica/analytics/ExternalAttribution;)V", "")]
	public unsafe static void ReportExternalAttribution(IExternalAttribution value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
			_members.StaticMethods.InvokeVoidMethod("reportExternalAttribution.(Lio/appmetrica/analytics/ExternalAttribution;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(value);
		}
	}

	[Register("reportRevenue", "(Lio/appmetrica/analytics/Revenue;)V", "")]
	public unsafe static void ReportRevenue(Revenue revenue)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(revenue?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("reportRevenue.(Lio/appmetrica/analytics/Revenue;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(revenue);
		}
	}

	[Register("reportUnhandledException", "(Ljava/lang/Throwable;)V", "")]
	public unsafe static void ReportUnhandledException(Throwable exception)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(exception?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("reportUnhandledException.(Ljava/lang/Throwable;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(exception);
		}
	}

	[Register("reportUserProfile", "(Lio/appmetrica/analytics/profile/UserProfile;)V", "")]
	public unsafe static void ReportUserProfile(UserProfile profile)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(profile?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("reportUserProfile.(Lio/appmetrica/analytics/profile/UserProfile;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(profile);
		}
	}

	[Register("requestDeferredDeeplink", "(Lio/appmetrica/analytics/DeferredDeeplinkListener;)V", "")]
	public unsafe static void RequestDeferredDeeplink(IDeferredDeeplinkListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.StaticMethods.InvokeVoidMethod("requestDeferredDeeplink.(Lio/appmetrica/analytics/DeferredDeeplinkListener;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("requestDeferredDeeplinkParameters", "(Lio/appmetrica/analytics/DeferredDeeplinkParametersListener;)V", "")]
	public unsafe static void RequestDeferredDeeplinkParameters(IDeferredDeeplinkParametersListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.StaticMethods.InvokeVoidMethod("requestDeferredDeeplinkParameters.(Lio/appmetrica/analytics/DeferredDeeplinkParametersListener;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("requestStartupParams", "(Landroid/content/Context;Lio/appmetrica/analytics/StartupParamsCallback;Ljava/util/List;)V", "")]
	public unsafe static void RequestStartupParams(Context context, IStartupParamsCallback callback, IList<string> @params)
	{
		nint num = JavaList<string>.ToLocalJniHandle(@params);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			ptr[2] = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("requestStartupParams.(Landroid/content/Context;Lio/appmetrica/analytics/StartupParamsCallback;Ljava/util/List;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
			GC.KeepAlive(callback);
			GC.KeepAlive(@params);
		}
	}

	[Register("resumeSession", "(Landroid/app/Activity;)V", "")]
	public unsafe static void ResumeSession(Activity? activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("resumeSession.(Landroid/app/Activity;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Register("sendEventsBuffer", "()V", "")]
	public unsafe static void SendEventsBuffer()
	{
		_members.StaticMethods.InvokeVoidMethod("sendEventsBuffer.()V", null);
	}

	[Register("setAdvIdentifiersTracking", "(Z)V", "")]
	public unsafe static void SetAdvIdentifiersTracking(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled);
		_members.StaticMethods.InvokeVoidMethod("setAdvIdentifiersTracking.(Z)V", ptr);
	}

	[Register("setDataSendingEnabled", "(Z)V", "")]
	public unsafe static void SetDataSendingEnabled(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled);
		_members.StaticMethods.InvokeVoidMethod("setDataSendingEnabled.(Z)V", ptr);
	}

	[Register("setLocation", "(Landroid/location/Location;)V", "")]
	public unsafe static void SetLocation(Location? location)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(location?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setLocation.(Landroid/location/Location;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(location);
		}
	}

	[Register("setLocationTracking", "(Z)V", "")]
	public unsafe static void SetLocationTracking(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled);
		_members.StaticMethods.InvokeVoidMethod("setLocationTracking.(Z)V", ptr);
	}

	[Register("setUserProfileID", "(Ljava/lang/String;)V", "")]
	public unsafe static void SetUserProfileID(string? userProfileID)
	{
		nint num = JNIEnv.NewString(userProfileID);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("setUserProfileID.(Ljava/lang/String;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
