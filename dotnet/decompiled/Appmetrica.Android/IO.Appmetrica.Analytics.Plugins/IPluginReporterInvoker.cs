using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Plugins;

[Register("io/appmetrica/analytics/plugins/IPluginReporter", DoNotGenerateAcw = true)]
internal class IPluginReporterInvoker : Java.Lang.Object, IPluginReporter, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_io_appmetrica_analytics_plugins_IPluginReporter = new XAPeerMembers("io/appmetrica/analytics/plugins/IPluginReporter", typeof(IPluginReporterInvoker));

	private static Delegate? cb_reportError_ReportError_Lio_appmetrica_analytics_plugins_PluginErrorDetails_Ljava_lang_String__V;

	private static Delegate? cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_String_Lio_appmetrica_analytics_plugins_PluginErrorDetails__V;

	private static Delegate? cb_reportUnhandledException_ReportUnhandledException_Lio_appmetrica_analytics_plugins_PluginErrorDetails__V;

	private static nint java_class_ref => _members_io_appmetrica_analytics_plugins_IPluginReporter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_io_appmetrica_analytics_plugins_IPluginReporter;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_io_appmetrica_analytics_plugins_IPluginReporter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_io_appmetrica_analytics_plugins_IPluginReporter.ManagedPeerType;

	public IPluginReporterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetReportError_Lio_appmetrica_analytics_plugins_PluginErrorDetails_Ljava_lang_String_Handler()
	{
		if ((object)cb_reportError_ReportError_Lio_appmetrica_analytics_plugins_PluginErrorDetails_Ljava_lang_String__V == null)
		{
			cb_reportError_ReportError_Lio_appmetrica_analytics_plugins_PluginErrorDetails_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ReportError_Lio_appmetrica_analytics_plugins_PluginErrorDetails_Ljava_lang_String_));
		}
		return cb_reportError_ReportError_Lio_appmetrica_analytics_plugins_PluginErrorDetails_Ljava_lang_String__V;
	}

	private static void n_ReportError_Lio_appmetrica_analytics_plugins_PluginErrorDetails_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IPluginReporter? pluginReporter = Java.Lang.Object.GetObject<IPluginReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		PluginErrorDetails p = Java.Lang.Object.GetObject<PluginErrorDetails>(native_p0, JniHandleOwnership.DoNotTransfer);
		string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
		pluginReporter.ReportError(p, p2);
	}

	public unsafe void ReportError(PluginErrorDetails p0, string? p1)
	{
		nint num = JNIEnv.NewString(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members_io_appmetrica_analytics_plugins_IPluginReporter.InstanceMethods.InvokeAbstractVoidMethod("reportError.(Lio/appmetrica/analytics/plugins/PluginErrorDetails;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetReportError_Ljava_lang_String_Ljava_lang_String_Lio_appmetrica_analytics_plugins_PluginErrorDetails_Handler()
	{
		if ((object)cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_String_Lio_appmetrica_analytics_plugins_PluginErrorDetails__V == null)
		{
			cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_String_Lio_appmetrica_analytics_plugins_PluginErrorDetails__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_ReportError_Ljava_lang_String_Ljava_lang_String_Lio_appmetrica_analytics_plugins_PluginErrorDetails_));
		}
		return cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_String_Lio_appmetrica_analytics_plugins_PluginErrorDetails__V;
	}

	private static void n_ReportError_Ljava_lang_String_Ljava_lang_String_Lio_appmetrica_analytics_plugins_PluginErrorDetails_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		IPluginReporter? pluginReporter = Java.Lang.Object.GetObject<IPluginReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
		PluginErrorDetails p3 = Java.Lang.Object.GetObject<PluginErrorDetails>(native_p2, JniHandleOwnership.DoNotTransfer);
		pluginReporter.ReportError(p, p2, p3);
	}

	public unsafe void ReportError(string p0, string? p1, PluginErrorDetails? p2)
	{
		nint num = JNIEnv.NewString(p0);
		nint num2 = JNIEnv.NewString(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
			_members_io_appmetrica_analytics_plugins_IPluginReporter.InstanceMethods.InvokeAbstractVoidMethod("reportError.(Ljava/lang/String;Ljava/lang/String;Lio/appmetrica/analytics/plugins/PluginErrorDetails;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(p2);
		}
	}

	private static Delegate GetReportUnhandledException_Lio_appmetrica_analytics_plugins_PluginErrorDetails_Handler()
	{
		if ((object)cb_reportUnhandledException_ReportUnhandledException_Lio_appmetrica_analytics_plugins_PluginErrorDetails__V == null)
		{
			cb_reportUnhandledException_ReportUnhandledException_Lio_appmetrica_analytics_plugins_PluginErrorDetails__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ReportUnhandledException_Lio_appmetrica_analytics_plugins_PluginErrorDetails_));
		}
		return cb_reportUnhandledException_ReportUnhandledException_Lio_appmetrica_analytics_plugins_PluginErrorDetails__V;
	}

	private static void n_ReportUnhandledException_Lio_appmetrica_analytics_plugins_PluginErrorDetails_(nint jnienv, nint native__this, nint native_p0)
	{
		IPluginReporter? pluginReporter = Java.Lang.Object.GetObject<IPluginReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		PluginErrorDetails p = Java.Lang.Object.GetObject<PluginErrorDetails>(native_p0, JniHandleOwnership.DoNotTransfer);
		pluginReporter.ReportUnhandledException(p);
	}

	public unsafe void ReportUnhandledException(PluginErrorDetails p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_io_appmetrica_analytics_plugins_IPluginReporter.InstanceMethods.InvokeAbstractVoidMethod("reportUnhandledException.(Lio/appmetrica/analytics/plugins/PluginErrorDetails;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
