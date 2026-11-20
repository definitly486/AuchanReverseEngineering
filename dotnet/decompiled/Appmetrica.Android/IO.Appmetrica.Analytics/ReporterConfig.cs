using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/ReporterConfig", DoNotGenerateAcw = true)]
public class ReporterConfig : Java.Lang.Object
{
	[Register("io/appmetrica/analytics/ReporterConfig$Builder", DoNotGenerateAcw = true)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/ReporterConfig$Builder", typeof(Builder));

		private static Delegate? cb_build_Build_Lio_appmetrica_analytics_ReporterConfig_;

		private static Delegate? cb_withAdditionalConfig_WithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object__Lio_appmetrica_analytics_ReporterConfig_Builder_;

		private static Delegate? cb_withAppEnvironmentValue_WithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_ReporterConfig_Builder_;

		private static Delegate? cb_withDataSendingEnabled_WithDataSendingEnabled_Z_Lio_appmetrica_analytics_ReporterConfig_Builder_;

		private static Delegate? cb_withDispatchPeriodSeconds_WithDispatchPeriodSeconds_I_Lio_appmetrica_analytics_ReporterConfig_Builder_;

		private static Delegate? cb_withLogs_WithLogs_Lio_appmetrica_analytics_ReporterConfig_Builder_;

		private static Delegate? cb_withMaxReportsCount_WithMaxReportsCount_I_Lio_appmetrica_analytics_ReporterConfig_Builder_;

		private static Delegate? cb_withMaxReportsInDatabaseCount_WithMaxReportsInDatabaseCount_I_Lio_appmetrica_analytics_ReporterConfig_Builder_;

		private static Delegate? cb_withSessionTimeout_WithSessionTimeout_I_Lio_appmetrica_analytics_ReporterConfig_Builder_;

		private static Delegate? cb_withUserProfileID_WithUserProfileID_Ljava_lang_String__Lio_appmetrica_analytics_ReporterConfig_Builder_;

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
			if ((object)cb_build_Build_Lio_appmetrica_analytics_ReporterConfig_ == null)
			{
				cb_build_Build_Lio_appmetrica_analytics_ReporterConfig_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
			}
			return cb_build_Build_Lio_appmetrica_analytics_ReporterConfig_;
		}

		private static nint n_Build(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
		}

		[Register("build", "()Lio/appmetrica/analytics/ReporterConfig;", "GetBuildHandler")]
		public unsafe virtual ReporterConfig Build()
		{
			return Java.Lang.Object.GetObject<ReporterConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lio/appmetrica/analytics/ReporterConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object_Handler()
		{
			if ((object)cb_withAdditionalConfig_WithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object__Lio_appmetrica_analytics_ReporterConfig_Builder_ == null)
			{
				cb_withAdditionalConfig_WithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object__Lio_appmetrica_analytics_ReporterConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_WithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object_));
			}
			return cb_withAdditionalConfig_WithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object__Lio_appmetrica_analytics_ReporterConfig_Builder_;
		}

		private static nint n_WithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_key, nint native_config)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object config = Java.Lang.Object.GetObject<Java.Lang.Object>(native_config, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithAdditionalConfig(key, config));
		}

		[Register("withAdditionalConfig", "(Ljava/lang/String;Ljava/lang/Object;)Lio/appmetrica/analytics/ReporterConfig$Builder;", "GetWithAdditionalConfig_Ljava_lang_String_Ljava_lang_Object_Handler")]
		public unsafe virtual Builder WithAdditionalConfig(string key, Java.Lang.Object? config)
		{
			nint num = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAdditionalConfig.(Ljava/lang/String;Ljava/lang/Object;)Lio/appmetrica/analytics/ReporterConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(config);
			}
		}

		private static Delegate GetWithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_withAppEnvironmentValue_WithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_ReporterConfig_Builder_ == null)
			{
				cb_withAppEnvironmentValue_WithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_ReporterConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_WithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_withAppEnvironmentValue_WithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_ReporterConfig_Builder_;
		}

		private static nint n_WithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key, nint native_value)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithAppEnvironmentValue(key, value));
		}

		[Register("withAppEnvironmentValue", "(Ljava/lang/String;Ljava/lang/String;)Lio/appmetrica/analytics/ReporterConfig$Builder;", "GetWithAppEnvironmentValue_Ljava_lang_String_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithAppEnvironmentValue(string? key, string? value)
		{
			nint num = JNIEnv.NewString(key);
			nint num2 = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAppEnvironmentValue.(Ljava/lang/String;Ljava/lang/String;)Lio/appmetrica/analytics/ReporterConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
			}
		}

		private static Delegate GetWithDataSendingEnabled_ZHandler()
		{
			if ((object)cb_withDataSendingEnabled_WithDataSendingEnabled_Z_Lio_appmetrica_analytics_ReporterConfig_Builder_ == null)
			{
				cb_withDataSendingEnabled_WithDataSendingEnabled_Z_Lio_appmetrica_analytics_ReporterConfig_Builder_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_WithDataSendingEnabled_Z));
			}
			return cb_withDataSendingEnabled_WithDataSendingEnabled_Z_Lio_appmetrica_analytics_ReporterConfig_Builder_;
		}

		private static nint n_WithDataSendingEnabled_Z(nint jnienv, nint native__this, bool enabled)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithDataSendingEnabled(enabled));
		}

		[Register("withDataSendingEnabled", "(Z)Lio/appmetrica/analytics/ReporterConfig$Builder;", "GetWithDataSendingEnabled_ZHandler")]
		public unsafe virtual Builder WithDataSendingEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withDataSendingEnabled.(Z)Lio/appmetrica/analytics/ReporterConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithDispatchPeriodSeconds_IHandler()
		{
			if ((object)cb_withDispatchPeriodSeconds_WithDispatchPeriodSeconds_I_Lio_appmetrica_analytics_ReporterConfig_Builder_ == null)
			{
				cb_withDispatchPeriodSeconds_WithDispatchPeriodSeconds_I_Lio_appmetrica_analytics_ReporterConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WithDispatchPeriodSeconds_I));
			}
			return cb_withDispatchPeriodSeconds_WithDispatchPeriodSeconds_I_Lio_appmetrica_analytics_ReporterConfig_Builder_;
		}

		private static nint n_WithDispatchPeriodSeconds_I(nint jnienv, nint native__this, int dispatchPeriodSeconds)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithDispatchPeriodSeconds(dispatchPeriodSeconds));
		}

		[Register("withDispatchPeriodSeconds", "(I)Lio/appmetrica/analytics/ReporterConfig$Builder;", "GetWithDispatchPeriodSeconds_IHandler")]
		public unsafe virtual Builder WithDispatchPeriodSeconds(int dispatchPeriodSeconds)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(dispatchPeriodSeconds);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withDispatchPeriodSeconds.(I)Lio/appmetrica/analytics/ReporterConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithLogsHandler()
		{
			if ((object)cb_withLogs_WithLogs_Lio_appmetrica_analytics_ReporterConfig_Builder_ == null)
			{
				cb_withLogs_WithLogs_Lio_appmetrica_analytics_ReporterConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_WithLogs));
			}
			return cb_withLogs_WithLogs_Lio_appmetrica_analytics_ReporterConfig_Builder_;
		}

		private static nint n_WithLogs(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithLogs());
		}

		[Register("withLogs", "()Lio/appmetrica/analytics/ReporterConfig$Builder;", "GetWithLogsHandler")]
		public unsafe virtual Builder WithLogs()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withLogs.()Lio/appmetrica/analytics/ReporterConfig$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithMaxReportsCount_IHandler()
		{
			if ((object)cb_withMaxReportsCount_WithMaxReportsCount_I_Lio_appmetrica_analytics_ReporterConfig_Builder_ == null)
			{
				cb_withMaxReportsCount_WithMaxReportsCount_I_Lio_appmetrica_analytics_ReporterConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WithMaxReportsCount_I));
			}
			return cb_withMaxReportsCount_WithMaxReportsCount_I_Lio_appmetrica_analytics_ReporterConfig_Builder_;
		}

		private static nint n_WithMaxReportsCount_I(nint jnienv, nint native__this, int maxReportsCount)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithMaxReportsCount(maxReportsCount));
		}

		[Register("withMaxReportsCount", "(I)Lio/appmetrica/analytics/ReporterConfig$Builder;", "GetWithMaxReportsCount_IHandler")]
		public unsafe virtual Builder WithMaxReportsCount(int maxReportsCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(maxReportsCount);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withMaxReportsCount.(I)Lio/appmetrica/analytics/ReporterConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithMaxReportsInDatabaseCount_IHandler()
		{
			if ((object)cb_withMaxReportsInDatabaseCount_WithMaxReportsInDatabaseCount_I_Lio_appmetrica_analytics_ReporterConfig_Builder_ == null)
			{
				cb_withMaxReportsInDatabaseCount_WithMaxReportsInDatabaseCount_I_Lio_appmetrica_analytics_ReporterConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WithMaxReportsInDatabaseCount_I));
			}
			return cb_withMaxReportsInDatabaseCount_WithMaxReportsInDatabaseCount_I_Lio_appmetrica_analytics_ReporterConfig_Builder_;
		}

		private static nint n_WithMaxReportsInDatabaseCount_I(nint jnienv, nint native__this, int maxReportsInDatabaseCount)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithMaxReportsInDatabaseCount(maxReportsInDatabaseCount));
		}

		[Register("withMaxReportsInDatabaseCount", "(I)Lio/appmetrica/analytics/ReporterConfig$Builder;", "GetWithMaxReportsInDatabaseCount_IHandler")]
		public unsafe virtual Builder WithMaxReportsInDatabaseCount(int maxReportsInDatabaseCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(maxReportsInDatabaseCount);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withMaxReportsInDatabaseCount.(I)Lio/appmetrica/analytics/ReporterConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithSessionTimeout_IHandler()
		{
			if ((object)cb_withSessionTimeout_WithSessionTimeout_I_Lio_appmetrica_analytics_ReporterConfig_Builder_ == null)
			{
				cb_withSessionTimeout_WithSessionTimeout_I_Lio_appmetrica_analytics_ReporterConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WithSessionTimeout_I));
			}
			return cb_withSessionTimeout_WithSessionTimeout_I_Lio_appmetrica_analytics_ReporterConfig_Builder_;
		}

		private static nint n_WithSessionTimeout_I(nint jnienv, nint native__this, int sessionTimeout)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithSessionTimeout(sessionTimeout));
		}

		[Register("withSessionTimeout", "(I)Lio/appmetrica/analytics/ReporterConfig$Builder;", "GetWithSessionTimeout_IHandler")]
		public unsafe virtual Builder WithSessionTimeout(int sessionTimeout)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(sessionTimeout);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withSessionTimeout.(I)Lio/appmetrica/analytics/ReporterConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithUserProfileID_Ljava_lang_String_Handler()
		{
			if ((object)cb_withUserProfileID_WithUserProfileID_Ljava_lang_String__Lio_appmetrica_analytics_ReporterConfig_Builder_ == null)
			{
				cb_withUserProfileID_WithUserProfileID_Ljava_lang_String__Lio_appmetrica_analytics_ReporterConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithUserProfileID_Ljava_lang_String_));
			}
			return cb_withUserProfileID_WithUserProfileID_Ljava_lang_String__Lio_appmetrica_analytics_ReporterConfig_Builder_;
		}

		private static nint n_WithUserProfileID_Ljava_lang_String_(nint jnienv, nint native__this, nint native_userProfileID)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string userProfileID = JNIEnv.GetString(native_userProfileID, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithUserProfileID(userProfileID));
		}

		[Register("withUserProfileID", "(Ljava/lang/String;)Lio/appmetrica/analytics/ReporterConfig$Builder;", "GetWithUserProfileID_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithUserProfileID(string? userProfileID)
		{
			nint num = JNIEnv.NewString(userProfileID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withUserProfileID.(Ljava/lang/String;)Lio/appmetrica/analytics/ReporterConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/ReporterConfig", typeof(ReporterConfig));

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

	protected ReporterConfig(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("newConfigBuilder", "(Ljava/lang/String;)Lio/appmetrica/analytics/ReporterConfig$Builder;", "")]
	public unsafe static Builder NewConfigBuilder(string apiKey)
	{
		nint num = JNIEnv.NewString(apiKey);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newConfigBuilder.(Ljava/lang/String;)Lio/appmetrica/analytics/ReporterConfig$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
