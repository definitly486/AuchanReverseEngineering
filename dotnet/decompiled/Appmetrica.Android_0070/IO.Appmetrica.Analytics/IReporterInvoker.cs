using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using IO.Appmetrica.Analytics.Ecommerce;
using IO.Appmetrica.Analytics.Plugins;
using IO.Appmetrica.Analytics.Profile;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/IReporter", DoNotGenerateAcw = true)]
internal class IReporterInvoker : Java.Lang.Object, IReporter, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_io_appmetrica_analytics_IReporter = new XAPeerMembers("io/appmetrica/analytics/IReporter", typeof(IReporterInvoker));

	private static Delegate? cb_getPluginExtension_GetPluginExtension_Lio_appmetrica_analytics_plugins_IPluginReporter_;

	private static Delegate? cb_clearAppEnvironment_ClearAppEnvironment_V;

	private static Delegate? cb_pauseSession_PauseSession_V;

	private static Delegate? cb_putAppEnvironmentValue_PutAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String__V;

	private static Delegate? cb_reportAdRevenue_ReportAdRevenue_Lio_appmetrica_analytics_AdRevenue__V;

	private static Delegate? cb_reportAnr_ReportAnr_Ljava_util_Map__V;

	private static Delegate? cb_reportECommerce_ReportECommerce_Lio_appmetrica_analytics_ecommerce_ECommerceEvent__V;

	private static Delegate? cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_String__V;

	private static Delegate? cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Throwable__V;

	private static Delegate? cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_Throwable__V;

	private static Delegate? cb_reportEvent_ReportEvent_Ljava_lang_String__V;

	private static Delegate? cb_reportEvent_ReportEvent_Ljava_lang_String_Ljava_lang_String__V;

	private static Delegate? cb_reportEvent_ReportEvent_Ljava_lang_String_Ljava_util_Map__V;

	private static Delegate? cb_reportRevenue_ReportRevenue_Lio_appmetrica_analytics_Revenue__V;

	private static Delegate? cb_reportUnhandledException_ReportUnhandledException_Ljava_lang_Throwable__V;

	private static Delegate? cb_reportUserProfile_ReportUserProfile_Lio_appmetrica_analytics_profile_UserProfile__V;

	private static Delegate? cb_resumeSession_ResumeSession_V;

	private static Delegate? cb_sendEventsBuffer_SendEventsBuffer_V;

	private static Delegate? cb_setDataSendingEnabled_SetDataSendingEnabled_Z_V;

	private static Delegate? cb_setUserProfileID_SetUserProfileID_Ljava_lang_String__V;

	private static nint java_class_ref => _members_io_appmetrica_analytics_IReporter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_io_appmetrica_analytics_IReporter;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_io_appmetrica_analytics_IReporter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_io_appmetrica_analytics_IReporter.ManagedPeerType;

	public unsafe IPluginReporter PluginExtension => Java.Lang.Object.GetObject<IPluginReporter>(_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractObjectMethod("getPluginExtension.()Lio/appmetrica/analytics/plugins/IPluginReporter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IReporterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetPluginExtensionHandler()
	{
		if ((object)cb_getPluginExtension_GetPluginExtension_Lio_appmetrica_analytics_plugins_IPluginReporter_ == null)
		{
			cb_getPluginExtension_GetPluginExtension_Lio_appmetrica_analytics_plugins_IPluginReporter_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPluginExtension));
		}
		return cb_getPluginExtension_GetPluginExtension_Lio_appmetrica_analytics_plugins_IPluginReporter_;
	}

	private static nint n_GetPluginExtension(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PluginExtension);
	}

	private static Delegate GetClearAppEnvironmentHandler()
	{
		if ((object)cb_clearAppEnvironment_ClearAppEnvironment_V == null)
		{
			cb_clearAppEnvironment_ClearAppEnvironment_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ClearAppEnvironment));
		}
		return cb_clearAppEnvironment_ClearAppEnvironment_V;
	}

	private static void n_ClearAppEnvironment(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearAppEnvironment();
	}

	public unsafe void ClearAppEnvironment()
	{
		_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("clearAppEnvironment.()V", this, null);
	}

	private static Delegate GetPauseSessionHandler()
	{
		if ((object)cb_pauseSession_PauseSession_V == null)
		{
			cb_pauseSession_PauseSession_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_PauseSession));
		}
		return cb_pauseSession_PauseSession_V;
	}

	private static void n_PauseSession(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PauseSession();
	}

	public unsafe void PauseSession()
	{
		_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("pauseSession.()V", this, null);
	}

	private static Delegate GetPutAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		if ((object)cb_putAppEnvironmentValue_PutAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String__V == null)
		{
			cb_putAppEnvironmentValue_PutAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_PutAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String_));
		}
		return cb_putAppEnvironmentValue_PutAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String__V;
	}

	private static void n_PutAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IReporter? reporter = Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
		reporter.PutAppEnvironmentValue(p, p2);
	}

	public unsafe void PutAppEnvironmentValue(string p0, string? p1)
	{
		nint num = JNIEnv.NewString(p0);
		nint num2 = JNIEnv.NewString(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("putAppEnvironmentValue.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetReportAdRevenue_Lio_appmetrica_analytics_AdRevenue_Handler()
	{
		if ((object)cb_reportAdRevenue_ReportAdRevenue_Lio_appmetrica_analytics_AdRevenue__V == null)
		{
			cb_reportAdRevenue_ReportAdRevenue_Lio_appmetrica_analytics_AdRevenue__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ReportAdRevenue_Lio_appmetrica_analytics_AdRevenue_));
		}
		return cb_reportAdRevenue_ReportAdRevenue_Lio_appmetrica_analytics_AdRevenue__V;
	}

	private static void n_ReportAdRevenue_Lio_appmetrica_analytics_AdRevenue_(nint jnienv, nint native__this, nint native_p0)
	{
		IReporter? reporter = Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		AdRevenue p = Java.Lang.Object.GetObject<AdRevenue>(native_p0, JniHandleOwnership.DoNotTransfer);
		reporter.ReportAdRevenue(p);
	}

	public unsafe void ReportAdRevenue(AdRevenue p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("reportAdRevenue.(Lio/appmetrica/analytics/AdRevenue;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetReportAnr_Ljava_util_Map_Handler()
	{
		if ((object)cb_reportAnr_ReportAnr_Ljava_util_Map__V == null)
		{
			cb_reportAnr_ReportAnr_Ljava_util_Map__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ReportAnr_Ljava_util_Map_));
		}
		return cb_reportAnr_ReportAnr_Ljava_util_Map__V;
	}

	private static void n_ReportAnr_Ljava_util_Map_(nint jnienv, nint native__this, nint native_p0)
	{
		IReporter? reporter = Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IDictionary<Thread, StackTraceElement[]> p = JavaDictionary<Thread, StackTraceElement[]>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		reporter.ReportAnr(p);
	}

	public unsafe void ReportAnr(IDictionary<Thread, StackTraceElement[]> p0)
	{
		nint num = JavaDictionary<Thread, StackTraceElement[]>.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("reportAnr.(Ljava/util/Map;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetReportECommerce_Lio_appmetrica_analytics_ecommerce_ECommerceEvent_Handler()
	{
		if ((object)cb_reportECommerce_ReportECommerce_Lio_appmetrica_analytics_ecommerce_ECommerceEvent__V == null)
		{
			cb_reportECommerce_ReportECommerce_Lio_appmetrica_analytics_ecommerce_ECommerceEvent__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ReportECommerce_Lio_appmetrica_analytics_ecommerce_ECommerceEvent_));
		}
		return cb_reportECommerce_ReportECommerce_Lio_appmetrica_analytics_ecommerce_ECommerceEvent__V;
	}

	private static void n_ReportECommerce_Lio_appmetrica_analytics_ecommerce_ECommerceEvent_(nint jnienv, nint native__this, nint native_p0)
	{
		IReporter? reporter = Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ECommerceEvent p = Java.Lang.Object.GetObject<ECommerceEvent>(native_p0, JniHandleOwnership.DoNotTransfer);
		reporter.ReportECommerce(p);
	}

	public unsafe void ReportECommerce(ECommerceEvent p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("reportECommerce.(Lio/appmetrica/analytics/ecommerce/ECommerceEvent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetReportError_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		if ((object)cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_String__V == null)
		{
			cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ReportError_Ljava_lang_String_Ljava_lang_String_));
		}
		return cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_String__V;
	}

	private static void n_ReportError_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IReporter? reporter = Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
		reporter.ReportError(p, p2);
	}

	public unsafe void ReportError(string p0, string? p1)
	{
		nint num = JNIEnv.NewString(p0);
		nint num2 = JNIEnv.NewString(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("reportError.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetReportError_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_Handler()
	{
		if ((object)cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Throwable__V == null)
		{
			cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Throwable__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_ReportError_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_));
		}
		return cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Throwable__V;
	}

	private static void n_ReportError_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		IReporter? reporter = Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
		Throwable p3 = Java.Lang.Object.GetObject<Throwable>(native_p2, JniHandleOwnership.DoNotTransfer);
		reporter.ReportError(p, p2, p3);
	}

	public unsafe void ReportError(string p0, string? p1, Throwable? p2)
	{
		nint num = JNIEnv.NewString(p0);
		nint num2 = JNIEnv.NewString(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
			_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("reportError.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(p2);
		}
	}

	private static Delegate GetReportError_Ljava_lang_String_Ljava_lang_Throwable_Handler()
	{
		if ((object)cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_Throwable__V == null)
		{
			cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_Throwable__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ReportError_Ljava_lang_String_Ljava_lang_Throwable_));
		}
		return cb_reportError_ReportError_Ljava_lang_String_Ljava_lang_Throwable__V;
	}

	private static void n_ReportError_Ljava_lang_String_Ljava_lang_Throwable_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IReporter? reporter = Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		Throwable p2 = Java.Lang.Object.GetObject<Throwable>(native_p1, JniHandleOwnership.DoNotTransfer);
		reporter.ReportError(p, p2);
	}

	public unsafe void ReportError(string p0, Throwable? p1)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("reportError.(Ljava/lang/String;Ljava/lang/Throwable;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetReportEvent_Ljava_lang_String_Handler()
	{
		if ((object)cb_reportEvent_ReportEvent_Ljava_lang_String__V == null)
		{
			cb_reportEvent_ReportEvent_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ReportEvent_Ljava_lang_String_));
		}
		return cb_reportEvent_ReportEvent_Ljava_lang_String__V;
	}

	private static void n_ReportEvent_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		IReporter? reporter = Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		reporter.ReportEvent(p);
	}

	public unsafe void ReportEvent(string p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("reportEvent.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetReportEvent_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		if ((object)cb_reportEvent_ReportEvent_Ljava_lang_String_Ljava_lang_String__V == null)
		{
			cb_reportEvent_ReportEvent_Ljava_lang_String_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ReportEvent_Ljava_lang_String_Ljava_lang_String_));
		}
		return cb_reportEvent_ReportEvent_Ljava_lang_String_Ljava_lang_String__V;
	}

	private static void n_ReportEvent_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IReporter? reporter = Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
		reporter.ReportEvent(p, p2);
	}

	public unsafe void ReportEvent(string p0, string? p1)
	{
		nint num = JNIEnv.NewString(p0);
		nint num2 = JNIEnv.NewString(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("reportEvent.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetReportEvent_Ljava_lang_String_Ljava_util_Map_Handler()
	{
		if ((object)cb_reportEvent_ReportEvent_Ljava_lang_String_Ljava_util_Map__V == null)
		{
			cb_reportEvent_ReportEvent_Ljava_lang_String_Ljava_util_Map__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ReportEvent_Ljava_lang_String_Ljava_util_Map_));
		}
		return cb_reportEvent_ReportEvent_Ljava_lang_String_Ljava_util_Map__V;
	}

	private static void n_ReportEvent_Ljava_lang_String_Ljava_util_Map_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IReporter? reporter = Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		IDictionary<string, Java.Lang.Object> p2 = JavaDictionary<string, Java.Lang.Object>.FromJniHandle(native_p1, JniHandleOwnership.DoNotTransfer);
		reporter.ReportEvent(p, p2);
	}

	public unsafe void ReportEvent(string p0, IDictionary<string, Java.Lang.Object>? p1)
	{
		nint num = JNIEnv.NewString(p0);
		nint num2 = JavaDictionary<string, Java.Lang.Object>.ToLocalJniHandle(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("reportEvent.(Ljava/lang/String;Ljava/util/Map;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetReportRevenue_Lio_appmetrica_analytics_Revenue_Handler()
	{
		if ((object)cb_reportRevenue_ReportRevenue_Lio_appmetrica_analytics_Revenue__V == null)
		{
			cb_reportRevenue_ReportRevenue_Lio_appmetrica_analytics_Revenue__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ReportRevenue_Lio_appmetrica_analytics_Revenue_));
		}
		return cb_reportRevenue_ReportRevenue_Lio_appmetrica_analytics_Revenue__V;
	}

	private static void n_ReportRevenue_Lio_appmetrica_analytics_Revenue_(nint jnienv, nint native__this, nint native_p0)
	{
		IReporter? reporter = Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Revenue p = Java.Lang.Object.GetObject<Revenue>(native_p0, JniHandleOwnership.DoNotTransfer);
		reporter.ReportRevenue(p);
	}

	public unsafe void ReportRevenue(Revenue p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("reportRevenue.(Lio/appmetrica/analytics/Revenue;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetReportUnhandledException_Ljava_lang_Throwable_Handler()
	{
		if ((object)cb_reportUnhandledException_ReportUnhandledException_Ljava_lang_Throwable__V == null)
		{
			cb_reportUnhandledException_ReportUnhandledException_Ljava_lang_Throwable__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ReportUnhandledException_Ljava_lang_Throwable_));
		}
		return cb_reportUnhandledException_ReportUnhandledException_Ljava_lang_Throwable__V;
	}

	private static void n_ReportUnhandledException_Ljava_lang_Throwable_(nint jnienv, nint native__this, nint native_p0)
	{
		IReporter? reporter = Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
		reporter.ReportUnhandledException(p);
	}

	public unsafe void ReportUnhandledException(Throwable p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("reportUnhandledException.(Ljava/lang/Throwable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetReportUserProfile_Lio_appmetrica_analytics_profile_UserProfile_Handler()
	{
		if ((object)cb_reportUserProfile_ReportUserProfile_Lio_appmetrica_analytics_profile_UserProfile__V == null)
		{
			cb_reportUserProfile_ReportUserProfile_Lio_appmetrica_analytics_profile_UserProfile__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ReportUserProfile_Lio_appmetrica_analytics_profile_UserProfile_));
		}
		return cb_reportUserProfile_ReportUserProfile_Lio_appmetrica_analytics_profile_UserProfile__V;
	}

	private static void n_ReportUserProfile_Lio_appmetrica_analytics_profile_UserProfile_(nint jnienv, nint native__this, nint native_p0)
	{
		IReporter? reporter = Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		UserProfile p = Java.Lang.Object.GetObject<UserProfile>(native_p0, JniHandleOwnership.DoNotTransfer);
		reporter.ReportUserProfile(p);
	}

	public unsafe void ReportUserProfile(UserProfile p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("reportUserProfile.(Lio/appmetrica/analytics/profile/UserProfile;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetResumeSessionHandler()
	{
		if ((object)cb_resumeSession_ResumeSession_V == null)
		{
			cb_resumeSession_ResumeSession_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ResumeSession));
		}
		return cb_resumeSession_ResumeSession_V;
	}

	private static void n_ResumeSession(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResumeSession();
	}

	public unsafe void ResumeSession()
	{
		_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("resumeSession.()V", this, null);
	}

	private static Delegate GetSendEventsBufferHandler()
	{
		if ((object)cb_sendEventsBuffer_SendEventsBuffer_V == null)
		{
			cb_sendEventsBuffer_SendEventsBuffer_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SendEventsBuffer));
		}
		return cb_sendEventsBuffer_SendEventsBuffer_V;
	}

	private static void n_SendEventsBuffer(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SendEventsBuffer();
	}

	public unsafe void SendEventsBuffer()
	{
		_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("sendEventsBuffer.()V", this, null);
	}

	private static Delegate GetSetDataSendingEnabled_ZHandler()
	{
		if ((object)cb_setDataSendingEnabled_SetDataSendingEnabled_Z_V == null)
		{
			cb_setDataSendingEnabled_SetDataSendingEnabled_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetDataSendingEnabled_Z));
		}
		return cb_setDataSendingEnabled_SetDataSendingEnabled_Z_V;
	}

	private static void n_SetDataSendingEnabled_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDataSendingEnabled(p0);
	}

	public unsafe void SetDataSendingEnabled(bool p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("setDataSendingEnabled.(Z)V", this, ptr);
	}

	private static Delegate GetSetUserProfileID_Ljava_lang_String_Handler()
	{
		if ((object)cb_setUserProfileID_SetUserProfileID_Ljava_lang_String__V == null)
		{
			cb_setUserProfileID_SetUserProfileID_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetUserProfileID_Ljava_lang_String_));
		}
		return cb_setUserProfileID_SetUserProfileID_Ljava_lang_String__V;
	}

	private static void n_SetUserProfileID_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		IReporter? reporter = Java.Lang.Object.GetObject<IReporter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string userProfileID = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		reporter.SetUserProfileID(userProfileID);
	}

	public unsafe void SetUserProfileID(string? p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_io_appmetrica_analytics_IReporter.InstanceMethods.InvokeAbstractVoidMethod("setUserProfileID.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
