using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Locations;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/AppMetricaConfig", DoNotGenerateAcw = true)]
public class AppMetricaConfig : Java.Lang.Object
{
	[Register("io/appmetrica/analytics/AppMetricaConfig$Builder", DoNotGenerateAcw = true)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/AppMetricaConfig$Builder", typeof(Builder));

		private static Delegate? cb_build_Build_Lio_appmetrica_analytics_AppMetricaConfig_;

		private static Delegate? cb_handleFirstActivationAsUpdate_HandleFirstActivationAsUpdate_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withAdditionalConfig_WithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withAdvIdentifiersTracking_WithAdvIdentifiersTracking_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withAnrMonitoring_WithAnrMonitoring_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withAnrMonitoringTimeout_WithAnrMonitoringTimeout_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withAppBuildNumber_WithAppBuildNumber_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withAppEnvironmentValue_WithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withAppOpenTrackingEnabled_WithAppOpenTrackingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withAppVersion_WithAppVersion_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withCrashReporting_WithCrashReporting_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withCrashTransformer_WithCrashTransformer_Lio_appmetrica_analytics_ICrashTransformer__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withCustomHosts_WithCustomHosts_Ljava_util_List__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withDataSendingEnabled_WithDataSendingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withDeviceType_WithDeviceType_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withDispatchPeriodSeconds_WithDispatchPeriodSeconds_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withErrorEnvironmentValue_WithErrorEnvironmentValue_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withLocation_WithLocation_Landroid_location_Location__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withLocationTracking_WithLocationTracking_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withLogs_WithLogs_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withMaxReportsCount_WithMaxReportsCount_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withMaxReportsInDatabaseCount_WithMaxReportsInDatabaseCount_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withNativeCrashReporting_WithNativeCrashReporting_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withPreloadInfo_WithPreloadInfo_Lio_appmetrica_analytics_PreloadInfo__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withRevenueAutoTrackingEnabled_WithRevenueAutoTrackingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withSessionTimeout_WithSessionTimeout_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withSessionsAutoTrackingEnabled_WithSessionsAutoTrackingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

		private static Delegate? cb_withUserProfileID_WithUserProfileID_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;

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

		protected Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetBuildHandler()
		{
			if ((object)cb_build_Build_Lio_appmetrica_analytics_AppMetricaConfig_ == null)
			{
				cb_build_Build_Lio_appmetrica_analytics_AppMetricaConfig_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
			}
			return cb_build_Build_Lio_appmetrica_analytics_AppMetricaConfig_;
		}

		private static nint n_Build(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
		}

		[Register("build", "()Lio/appmetrica/analytics/AppMetricaConfig;", "GetBuildHandler")]
		public unsafe virtual AppMetricaConfig Build()
		{
			return Java.Lang.Object.GetObject<AppMetricaConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lio/appmetrica/analytics/AppMetricaConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetHandleFirstActivationAsUpdate_ZHandler()
		{
			if ((object)cb_handleFirstActivationAsUpdate_HandleFirstActivationAsUpdate_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_handleFirstActivationAsUpdate_HandleFirstActivationAsUpdate_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_HandleFirstActivationAsUpdate_Z));
			}
			return cb_handleFirstActivationAsUpdate_HandleFirstActivationAsUpdate_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_HandleFirstActivationAsUpdate_Z(nint jnienv, nint native__this, bool value)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HandleFirstActivationAsUpdate(value));
		}

		[Register("handleFirstActivationAsUpdate", "(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetHandleFirstActivationAsUpdate_ZHandler")]
		public unsafe virtual Builder HandleFirstActivationAsUpdate(bool value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("handleFirstActivationAsUpdate.(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object_Handler()
		{
			if ((object)cb_withAdditionalConfig_WithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withAdditionalConfig_WithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_WithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object_));
			}
			return cb_withAdditionalConfig_WithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_key, nint native_config)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object config = Java.Lang.Object.GetObject<Java.Lang.Object>(native_config, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithAdditionalConfig(key, config));
		}

		[Register("withAdditionalConfig", "(Ljava/lang/String;Ljava/lang/Object;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object_Handler")]
		public unsafe virtual Builder WithAdditionalConfig(string key, Java.Lang.Object? config)
		{
			nint num = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAdditionalConfig.(Ljava/lang/String;Ljava/lang/Object;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(config);
			}
		}

		private static Delegate GetWithAdvIdentifiersTracking_ZHandler()
		{
			if ((object)cb_withAdvIdentifiersTracking_WithAdvIdentifiersTracking_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withAdvIdentifiersTracking_WithAdvIdentifiersTracking_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_WithAdvIdentifiersTracking_Z));
			}
			return cb_withAdvIdentifiersTracking_WithAdvIdentifiersTracking_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithAdvIdentifiersTracking_Z(nint jnienv, nint native__this, bool enabled)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithAdvIdentifiersTracking(enabled));
		}

		[Register("withAdvIdentifiersTracking", "(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithAdvIdentifiersTracking_ZHandler")]
		public unsafe virtual Builder WithAdvIdentifiersTracking(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAdvIdentifiersTracking.(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithAnrMonitoring_ZHandler()
		{
			if ((object)cb_withAnrMonitoring_WithAnrMonitoring_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withAnrMonitoring_WithAnrMonitoring_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_WithAnrMonitoring_Z));
			}
			return cb_withAnrMonitoring_WithAnrMonitoring_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithAnrMonitoring_Z(nint jnienv, nint native__this, bool enabled)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithAnrMonitoring(enabled));
		}

		[Register("withAnrMonitoring", "(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithAnrMonitoring_ZHandler")]
		public unsafe virtual Builder WithAnrMonitoring(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAnrMonitoring.(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithAnrMonitoringTimeout_IHandler()
		{
			if ((object)cb_withAnrMonitoringTimeout_WithAnrMonitoringTimeout_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withAnrMonitoringTimeout_WithAnrMonitoringTimeout_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WithAnrMonitoringTimeout_I));
			}
			return cb_withAnrMonitoringTimeout_WithAnrMonitoringTimeout_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithAnrMonitoringTimeout_I(nint jnienv, nint native__this, int timeout)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithAnrMonitoringTimeout(timeout));
		}

		[Register("withAnrMonitoringTimeout", "(I)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithAnrMonitoringTimeout_IHandler")]
		public unsafe virtual Builder WithAnrMonitoringTimeout(int timeout)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(timeout);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAnrMonitoringTimeout.(I)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithAppBuildNumber_IHandler()
		{
			if ((object)cb_withAppBuildNumber_WithAppBuildNumber_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withAppBuildNumber_WithAppBuildNumber_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WithAppBuildNumber_I));
			}
			return cb_withAppBuildNumber_WithAppBuildNumber_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithAppBuildNumber_I(nint jnienv, nint native__this, int appBuildNumber)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithAppBuildNumber(appBuildNumber));
		}

		[Register("withAppBuildNumber", "(I)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithAppBuildNumber_IHandler")]
		public unsafe virtual Builder WithAppBuildNumber(int appBuildNumber)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(appBuildNumber);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAppBuildNumber.(I)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_withAppEnvironmentValue_WithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withAppEnvironmentValue_WithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_WithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_withAppEnvironmentValue_WithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key, nint native_value)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithAppEnvironmentValue(key, value));
		}

		[Register("withAppEnvironmentValue", "(Ljava/lang/String;Ljava/lang/String;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithAppEnvironmentValue(string key, string? value)
		{
			nint num = JNIEnv.NewString(key);
			nint num2 = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAppEnvironmentValue.(Ljava/lang/String;Ljava/lang/String;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
			}
		}

		private static Delegate GetWithAppOpenTrackingEnabled_ZHandler()
		{
			if ((object)cb_withAppOpenTrackingEnabled_WithAppOpenTrackingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withAppOpenTrackingEnabled_WithAppOpenTrackingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_WithAppOpenTrackingEnabled_Z));
			}
			return cb_withAppOpenTrackingEnabled_WithAppOpenTrackingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithAppOpenTrackingEnabled_Z(nint jnienv, nint native__this, bool enabled)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithAppOpenTrackingEnabled(enabled));
		}

		[Register("withAppOpenTrackingEnabled", "(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithAppOpenTrackingEnabled_ZHandler")]
		public unsafe virtual Builder WithAppOpenTrackingEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAppOpenTrackingEnabled.(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithAppVersion_Ljava_lang_String_Handler()
		{
			if ((object)cb_withAppVersion_WithAppVersion_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withAppVersion_WithAppVersion_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithAppVersion_Ljava_lang_String_));
			}
			return cb_withAppVersion_WithAppVersion_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithAppVersion_Ljava_lang_String_(nint jnienv, nint native__this, nint native_appVersion)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string appVersion = JNIEnv.GetString(native_appVersion, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithAppVersion(appVersion));
		}

		[Register("withAppVersion", "(Ljava/lang/String;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithAppVersion_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithAppVersion(string? appVersion)
		{
			nint num = JNIEnv.NewString(appVersion);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAppVersion.(Ljava/lang/String;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetWithCrashReporting_ZHandler()
		{
			if ((object)cb_withCrashReporting_WithCrashReporting_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withCrashReporting_WithCrashReporting_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_WithCrashReporting_Z));
			}
			return cb_withCrashReporting_WithCrashReporting_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithCrashReporting_Z(nint jnienv, nint native__this, bool enabled)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithCrashReporting(enabled));
		}

		[Register("withCrashReporting", "(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithCrashReporting_ZHandler")]
		public unsafe virtual Builder WithCrashReporting(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withCrashReporting.(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithCrashTransformer_Lio_appmetrica_analytics_ICrashTransformer_Handler()
		{
			if ((object)cb_withCrashTransformer_WithCrashTransformer_Lio_appmetrica_analytics_ICrashTransformer__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withCrashTransformer_WithCrashTransformer_Lio_appmetrica_analytics_ICrashTransformer__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithCrashTransformer_Lio_appmetrica_analytics_ICrashTransformer_));
			}
			return cb_withCrashTransformer_WithCrashTransformer_Lio_appmetrica_analytics_ICrashTransformer__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithCrashTransformer_Lio_appmetrica_analytics_ICrashTransformer_(nint jnienv, nint native__this, nint native_crashTransformer)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICrashTransformer crashTransformer = Java.Lang.Object.GetObject<ICrashTransformer>(native_crashTransformer, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithCrashTransformer(crashTransformer));
		}

		[Register("withCrashTransformer", "(Lio/appmetrica/analytics/ICrashTransformer;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithCrashTransformer_Lio_appmetrica_analytics_ICrashTransformer_Handler")]
		public unsafe virtual Builder WithCrashTransformer(ICrashTransformer? crashTransformer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((crashTransformer == null) ? IntPtr.Zero : ((Java.Lang.Object)crashTransformer).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withCrashTransformer.(Lio/appmetrica/analytics/ICrashTransformer;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(crashTransformer);
			}
		}

		private static Delegate GetWithCustomHosts_Ljava_util_List_Handler()
		{
			if ((object)cb_withCustomHosts_WithCustomHosts_Ljava_util_List__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withCustomHosts_WithCustomHosts_Ljava_util_List__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithCustomHosts_Ljava_util_List_));
			}
			return cb_withCustomHosts_WithCustomHosts_Ljava_util_List__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithCustomHosts_Ljava_util_List_(nint jnienv, nint native__this, nint native_hosts)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<string> hosts = JavaList<string>.FromJniHandle(native_hosts, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithCustomHosts(hosts));
		}

		[Register("withCustomHosts", "(Ljava/util/List;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithCustomHosts_Ljava_util_List_Handler")]
		public unsafe virtual Builder WithCustomHosts(IList<string> hosts)
		{
			nint num = JavaList<string>.ToLocalJniHandle(hosts);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withCustomHosts.(Ljava/util/List;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(hosts);
			}
		}

		private static Delegate GetWithDataSendingEnabled_ZHandler()
		{
			if ((object)cb_withDataSendingEnabled_WithDataSendingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withDataSendingEnabled_WithDataSendingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_WithDataSendingEnabled_Z));
			}
			return cb_withDataSendingEnabled_WithDataSendingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithDataSendingEnabled_Z(nint jnienv, nint native__this, bool value)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithDataSendingEnabled(value));
		}

		[Register("withDataSendingEnabled", "(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithDataSendingEnabled_ZHandler")]
		public unsafe virtual Builder WithDataSendingEnabled(bool value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withDataSendingEnabled.(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithDeviceType_Ljava_lang_String_Handler()
		{
			if ((object)cb_withDeviceType_WithDeviceType_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withDeviceType_WithDeviceType_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithDeviceType_Ljava_lang_String_));
			}
			return cb_withDeviceType_WithDeviceType_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithDeviceType_Ljava_lang_String_(nint jnienv, nint native__this, nint native_deviceType)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string deviceType = JNIEnv.GetString(native_deviceType, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithDeviceType(deviceType));
		}

		[Register("withDeviceType", "(Ljava/lang/String;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithDeviceType_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithDeviceType(string? deviceType)
		{
			nint num = JNIEnv.NewString(deviceType);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withDeviceType.(Ljava/lang/String;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetWithDispatchPeriodSeconds_IHandler()
		{
			if ((object)cb_withDispatchPeriodSeconds_WithDispatchPeriodSeconds_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withDispatchPeriodSeconds_WithDispatchPeriodSeconds_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WithDispatchPeriodSeconds_I));
			}
			return cb_withDispatchPeriodSeconds_WithDispatchPeriodSeconds_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithDispatchPeriodSeconds_I(nint jnienv, nint native__this, int dispatchPeriodSeconds)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithDispatchPeriodSeconds(dispatchPeriodSeconds));
		}

		[Register("withDispatchPeriodSeconds", "(I)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithDispatchPeriodSeconds_IHandler")]
		public unsafe virtual Builder WithDispatchPeriodSeconds(int dispatchPeriodSeconds)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(dispatchPeriodSeconds);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withDispatchPeriodSeconds.(I)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithErrorEnvironmentValue_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_withErrorEnvironmentValue_WithErrorEnvironmentValue_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withErrorEnvironmentValue_WithErrorEnvironmentValue_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_WithErrorEnvironmentValue_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_withErrorEnvironmentValue_WithErrorEnvironmentValue_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithErrorEnvironmentValue_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key, nint native_value)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithErrorEnvironmentValue(key, value));
		}

		[Register("withErrorEnvironmentValue", "(Ljava/lang/String;Ljava/lang/String;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithErrorEnvironmentValue_Ljava_lang_String_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithErrorEnvironmentValue(string key, string? value)
		{
			nint num = JNIEnv.NewString(key);
			nint num2 = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withErrorEnvironmentValue.(Ljava/lang/String;Ljava/lang/String;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
			}
		}

		private static Delegate GetWithLocation_Landroid_location_Location_Handler()
		{
			if ((object)cb_withLocation_WithLocation_Landroid_location_Location__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withLocation_WithLocation_Landroid_location_Location__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithLocation_Landroid_location_Location_));
			}
			return cb_withLocation_WithLocation_Landroid_location_Location__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithLocation_Landroid_location_Location_(nint jnienv, nint native__this, nint native_location)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Location location = Java.Lang.Object.GetObject<Location>(native_location, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithLocation(location));
		}

		[Register("withLocation", "(Landroid/location/Location;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithLocation_Landroid_location_Location_Handler")]
		public unsafe virtual Builder WithLocation(Location? location)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(location?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withLocation.(Landroid/location/Location;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(location);
			}
		}

		private static Delegate GetWithLocationTracking_ZHandler()
		{
			if ((object)cb_withLocationTracking_WithLocationTracking_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withLocationTracking_WithLocationTracking_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_WithLocationTracking_Z));
			}
			return cb_withLocationTracking_WithLocationTracking_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithLocationTracking_Z(nint jnienv, nint native__this, bool enabled)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithLocationTracking(enabled));
		}

		[Register("withLocationTracking", "(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithLocationTracking_ZHandler")]
		public unsafe virtual Builder WithLocationTracking(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withLocationTracking.(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithLogsHandler()
		{
			if ((object)cb_withLogs_WithLogs_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withLogs_WithLogs_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_WithLogs));
			}
			return cb_withLogs_WithLogs_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithLogs(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithLogs());
		}

		[Register("withLogs", "()Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithLogsHandler")]
		public unsafe virtual Builder WithLogs()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withLogs.()Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithMaxReportsCount_IHandler()
		{
			if ((object)cb_withMaxReportsCount_WithMaxReportsCount_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withMaxReportsCount_WithMaxReportsCount_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WithMaxReportsCount_I));
			}
			return cb_withMaxReportsCount_WithMaxReportsCount_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithMaxReportsCount_I(nint jnienv, nint native__this, int maxReportsCount)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithMaxReportsCount(maxReportsCount));
		}

		[Register("withMaxReportsCount", "(I)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithMaxReportsCount_IHandler")]
		public unsafe virtual Builder WithMaxReportsCount(int maxReportsCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(maxReportsCount);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withMaxReportsCount.(I)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithMaxReportsInDatabaseCount_IHandler()
		{
			if ((object)cb_withMaxReportsInDatabaseCount_WithMaxReportsInDatabaseCount_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withMaxReportsInDatabaseCount_WithMaxReportsInDatabaseCount_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WithMaxReportsInDatabaseCount_I));
			}
			return cb_withMaxReportsInDatabaseCount_WithMaxReportsInDatabaseCount_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithMaxReportsInDatabaseCount_I(nint jnienv, nint native__this, int value)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithMaxReportsInDatabaseCount(value));
		}

		[Register("withMaxReportsInDatabaseCount", "(I)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithMaxReportsInDatabaseCount_IHandler")]
		public unsafe virtual Builder WithMaxReportsInDatabaseCount(int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withMaxReportsInDatabaseCount.(I)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithNativeCrashReporting_ZHandler()
		{
			if ((object)cb_withNativeCrashReporting_WithNativeCrashReporting_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withNativeCrashReporting_WithNativeCrashReporting_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_WithNativeCrashReporting_Z));
			}
			return cb_withNativeCrashReporting_WithNativeCrashReporting_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithNativeCrashReporting_Z(nint jnienv, nint native__this, bool enabled)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithNativeCrashReporting(enabled));
		}

		[Register("withNativeCrashReporting", "(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithNativeCrashReporting_ZHandler")]
		public unsafe virtual Builder WithNativeCrashReporting(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withNativeCrashReporting.(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithPreloadInfo_Lio_appmetrica_analytics_PreloadInfo_Handler()
		{
			if ((object)cb_withPreloadInfo_WithPreloadInfo_Lio_appmetrica_analytics_PreloadInfo__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withPreloadInfo_WithPreloadInfo_Lio_appmetrica_analytics_PreloadInfo__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithPreloadInfo_Lio_appmetrica_analytics_PreloadInfo_));
			}
			return cb_withPreloadInfo_WithPreloadInfo_Lio_appmetrica_analytics_PreloadInfo__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithPreloadInfo_Lio_appmetrica_analytics_PreloadInfo_(nint jnienv, nint native__this, nint native_preloadInfo)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PreloadInfo preloadInfo = Java.Lang.Object.GetObject<PreloadInfo>(native_preloadInfo, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithPreloadInfo(preloadInfo));
		}

		[Register("withPreloadInfo", "(Lio/appmetrica/analytics/PreloadInfo;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithPreloadInfo_Lio_appmetrica_analytics_PreloadInfo_Handler")]
		public unsafe virtual Builder WithPreloadInfo(PreloadInfo? preloadInfo)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(preloadInfo?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withPreloadInfo.(Lio/appmetrica/analytics/PreloadInfo;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(preloadInfo);
			}
		}

		private static Delegate GetWithRevenueAutoTrackingEnabled_ZHandler()
		{
			if ((object)cb_withRevenueAutoTrackingEnabled_WithRevenueAutoTrackingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withRevenueAutoTrackingEnabled_WithRevenueAutoTrackingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_WithRevenueAutoTrackingEnabled_Z));
			}
			return cb_withRevenueAutoTrackingEnabled_WithRevenueAutoTrackingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithRevenueAutoTrackingEnabled_Z(nint jnienv, nint native__this, bool enabled)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithRevenueAutoTrackingEnabled(enabled));
		}

		[Register("withRevenueAutoTrackingEnabled", "(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithRevenueAutoTrackingEnabled_ZHandler")]
		public unsafe virtual Builder WithRevenueAutoTrackingEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withRevenueAutoTrackingEnabled.(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithSessionTimeout_IHandler()
		{
			if ((object)cb_withSessionTimeout_WithSessionTimeout_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withSessionTimeout_WithSessionTimeout_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WithSessionTimeout_I));
			}
			return cb_withSessionTimeout_WithSessionTimeout_I_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithSessionTimeout_I(nint jnienv, nint native__this, int sessionTimeout)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithSessionTimeout(sessionTimeout));
		}

		[Register("withSessionTimeout", "(I)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithSessionTimeout_IHandler")]
		public unsafe virtual Builder WithSessionTimeout(int sessionTimeout)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(sessionTimeout);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withSessionTimeout.(I)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithSessionsAutoTrackingEnabled_ZHandler()
		{
			if ((object)cb_withSessionsAutoTrackingEnabled_WithSessionsAutoTrackingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withSessionsAutoTrackingEnabled_WithSessionsAutoTrackingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_WithSessionsAutoTrackingEnabled_Z));
			}
			return cb_withSessionsAutoTrackingEnabled_WithSessionsAutoTrackingEnabled_Z_Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithSessionsAutoTrackingEnabled_Z(nint jnienv, nint native__this, bool enabled)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithSessionsAutoTrackingEnabled(enabled));
		}

		[Register("withSessionsAutoTrackingEnabled", "(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithSessionsAutoTrackingEnabled_ZHandler")]
		public unsafe virtual Builder WithSessionsAutoTrackingEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withSessionsAutoTrackingEnabled.(Z)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithUserProfileID_Ljava_lang_String_Handler()
		{
			if ((object)cb_withUserProfileID_WithUserProfileID_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ == null)
			{
				cb_withUserProfileID_WithUserProfileID_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithUserProfileID_Ljava_lang_String_));
			}
			return cb_withUserProfileID_WithUserProfileID_Ljava_lang_String__Lio_appmetrica_analytics_AppMetricaConfig_Builder_;
		}

		private static nint n_WithUserProfileID_Ljava_lang_String_(nint jnienv, nint native__this, nint native_userProfileID)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string userProfileID = JNIEnv.GetString(native_userProfileID, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithUserProfileID(userProfileID));
		}

		[Register("withUserProfileID", "(Ljava/lang/String;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "GetWithUserProfileID_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithUserProfileID(string? userProfileID)
		{
			nint num = JNIEnv.NewString(userProfileID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withUserProfileID.(Ljava/lang/String;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/AppMetricaConfig", typeof(AppMetricaConfig));

	private static Delegate? cb_toJson_ToJson_Ljava_lang_String_;

	[Register("additionalConfig")]
	public IDictionary AdditionalConfig
	{
		get
		{
			return JavaDictionary.FromJniHandle(_members.InstanceFields.GetObjectValue("additionalConfig.Ljava/util/Map;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JavaDictionary.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("additionalConfig.Ljava/util/Map;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("advIdentifiersTracking")]
	public Java.Lang.Boolean? AdvIdentifiersTracking
	{
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceFields.GetObjectValue("advIdentifiersTracking.Ljava/lang/Boolean;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("advIdentifiersTracking.Ljava/lang/Boolean;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("anrMonitoring")]
	public Java.Lang.Boolean? AnrMonitoring
	{
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceFields.GetObjectValue("anrMonitoring.Ljava/lang/Boolean;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("anrMonitoring.Ljava/lang/Boolean;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("anrMonitoringTimeout")]
	public Integer? AnrMonitoringTimeout
	{
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceFields.GetObjectValue("anrMonitoringTimeout.Ljava/lang/Integer;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("anrMonitoringTimeout.Ljava/lang/Integer;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("apiKey")]
	public string ApiKey
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("apiKey.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("apiKey.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("appBuildNumber")]
	public Integer? AppBuildNumber
	{
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceFields.GetObjectValue("appBuildNumber.Ljava/lang/Integer;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("appBuildNumber.Ljava/lang/Integer;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("appEnvironment")]
	public IDictionary? AppEnvironment
	{
		get
		{
			return JavaDictionary.FromJniHandle(_members.InstanceFields.GetObjectValue("appEnvironment.Ljava/util/Map;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JavaDictionary.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("appEnvironment.Ljava/util/Map;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("appOpenTrackingEnabled")]
	public Java.Lang.Boolean? AppOpenTrackingEnabled
	{
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceFields.GetObjectValue("appOpenTrackingEnabled.Ljava/lang/Boolean;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("appOpenTrackingEnabled.Ljava/lang/Boolean;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("appVersion")]
	public string? AppVersion
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("appVersion.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("appVersion.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("crashReporting")]
	public Java.Lang.Boolean? CrashReporting
	{
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceFields.GetObjectValue("crashReporting.Ljava/lang/Boolean;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("crashReporting.Ljava/lang/Boolean;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("crashTransformer")]
	public ICrashTransformer? CrashTransformer
	{
		get
		{
			return Java.Lang.Object.GetObject<ICrashTransformer>(_members.InstanceFields.GetObjectValue("crashTransformer.Lio/appmetrica/analytics/ICrashTransformer;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("crashTransformer.Lio/appmetrica/analytics/ICrashTransformer;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("customHosts")]
	public IList? CustomHosts
	{
		get
		{
			return JavaList.FromJniHandle(_members.InstanceFields.GetObjectValue("customHosts.Ljava/util/List;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JavaList.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("customHosts.Ljava/util/List;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("dataSendingEnabled")]
	public Java.Lang.Boolean? DataSendingEnabled
	{
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceFields.GetObjectValue("dataSendingEnabled.Ljava/lang/Boolean;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("dataSendingEnabled.Ljava/lang/Boolean;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("deviceType")]
	public string? DeviceType
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("deviceType.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("deviceType.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("dispatchPeriodSeconds")]
	public Integer? DispatchPeriodSeconds
	{
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceFields.GetObjectValue("dispatchPeriodSeconds.Ljava/lang/Integer;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("dispatchPeriodSeconds.Ljava/lang/Integer;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("errorEnvironment")]
	public IDictionary? ErrorEnvironment
	{
		get
		{
			return JavaDictionary.FromJniHandle(_members.InstanceFields.GetObjectValue("errorEnvironment.Ljava/util/Map;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JavaDictionary.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("errorEnvironment.Ljava/util/Map;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("firstActivationAsUpdate")]
	public Java.Lang.Boolean? FirstActivationAsUpdate
	{
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceFields.GetObjectValue("firstActivationAsUpdate.Ljava/lang/Boolean;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("firstActivationAsUpdate.Ljava/lang/Boolean;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("location")]
	public Location? Location
	{
		get
		{
			return Java.Lang.Object.GetObject<Location>(_members.InstanceFields.GetObjectValue("location.Landroid/location/Location;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("location.Landroid/location/Location;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("locationTracking")]
	public Java.Lang.Boolean? LocationTracking
	{
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceFields.GetObjectValue("locationTracking.Ljava/lang/Boolean;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("locationTracking.Ljava/lang/Boolean;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("logs")]
	public Java.Lang.Boolean? Logs
	{
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceFields.GetObjectValue("logs.Ljava/lang/Boolean;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("logs.Ljava/lang/Boolean;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("maxReportsCount")]
	public Integer? MaxReportsCount
	{
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceFields.GetObjectValue("maxReportsCount.Ljava/lang/Integer;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("maxReportsCount.Ljava/lang/Integer;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("maxReportsInDatabaseCount")]
	public Integer? MaxReportsInDatabaseCount
	{
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceFields.GetObjectValue("maxReportsInDatabaseCount.Ljava/lang/Integer;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("maxReportsInDatabaseCount.Ljava/lang/Integer;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("nativeCrashReporting")]
	public Java.Lang.Boolean? NativeCrashReporting
	{
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceFields.GetObjectValue("nativeCrashReporting.Ljava/lang/Boolean;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("nativeCrashReporting.Ljava/lang/Boolean;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("preloadInfo")]
	public PreloadInfo? PreloadInfo
	{
		get
		{
			return Java.Lang.Object.GetObject<PreloadInfo>(_members.InstanceFields.GetObjectValue("preloadInfo.Lio/appmetrica/analytics/PreloadInfo;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("preloadInfo.Lio/appmetrica/analytics/PreloadInfo;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("revenueAutoTrackingEnabled")]
	public Java.Lang.Boolean? RevenueAutoTrackingEnabled
	{
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceFields.GetObjectValue("revenueAutoTrackingEnabled.Ljava/lang/Boolean;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("revenueAutoTrackingEnabled.Ljava/lang/Boolean;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("sessionsAutoTrackingEnabled")]
	public Java.Lang.Boolean? SessionsAutoTrackingEnabled
	{
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceFields.GetObjectValue("sessionsAutoTrackingEnabled.Ljava/lang/Boolean;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("sessionsAutoTrackingEnabled.Ljava/lang/Boolean;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("sessionTimeout")]
	public Integer? SessionTimeout
	{
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceFields.GetObjectValue("sessionTimeout.Ljava/lang/Integer;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("sessionTimeout.Ljava/lang/Integer;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("userProfileID")]
	public string? UserProfileID
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("userProfileID.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("userProfileID.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

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

	protected AppMetricaConfig(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Lio/appmetrica/analytics/AppMetricaConfig;)V", "")]
	protected unsafe AppMetricaConfig(AppMetricaConfig source)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lio/appmetrica/analytics/AppMetricaConfig;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lio/appmetrica/analytics/AppMetricaConfig;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(source);
		}
	}

	[Register("fromJson", "(Ljava/lang/String;)Lio/appmetrica/analytics/AppMetricaConfig;", "")]
	public unsafe static AppMetricaConfig? FromJson(string? json)
	{
		nint num = JNIEnv.NewString(json);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<AppMetricaConfig>(_members.StaticMethods.InvokeObjectMethod("fromJson.(Ljava/lang/String;)Lio/appmetrica/analytics/AppMetricaConfig;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("newConfigBuilder", "(Ljava/lang/String;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", "")]
	public unsafe static Builder NewConfigBuilder(string apiKey)
	{
		nint num = JNIEnv.NewString(apiKey);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newConfigBuilder.(Ljava/lang/String;)Lio/appmetrica/analytics/AppMetricaConfig$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetToJsonHandler()
	{
		if ((object)cb_toJson_ToJson_Ljava_lang_String_ == null)
		{
			cb_toJson_ToJson_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJson));
		}
		return cb_toJson_ToJson_Ljava_lang_String_;
	}

	private static nint n_ToJson(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<AppMetricaConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToJson());
	}

	[Register("toJson", "()Ljava/lang/String;", "GetToJsonHandler")]
	public unsafe virtual string? ToJson()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("toJson.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
