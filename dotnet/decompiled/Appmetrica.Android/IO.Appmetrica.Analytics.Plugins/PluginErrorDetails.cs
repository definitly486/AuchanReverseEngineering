using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Plugins;

[Register("io/appmetrica/analytics/plugins/PluginErrorDetails", DoNotGenerateAcw = true)]
public class PluginErrorDetails : Java.Lang.Object
{
	[Register("io/appmetrica/analytics/plugins/PluginErrorDetails$Builder", DoNotGenerateAcw = true)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/plugins/PluginErrorDetails$Builder", typeof(Builder));

		private static Delegate? cb_build_Build_Lio_appmetrica_analytics_plugins_PluginErrorDetails_;

		private static Delegate? cb_withExceptionClass_WithExceptionClass_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_;

		private static Delegate? cb_withMessage_WithMessage_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_;

		private static Delegate? cb_withPlatform_WithPlatform_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_;

		private static Delegate? cb_withPluginEnvironment_WithPluginEnvironment_Ljava_util_Map__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_;

		private static Delegate? cb_withStacktrace_WithStacktrace_Ljava_util_List__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_;

		private static Delegate? cb_withVirtualMachineVersion_WithVirtualMachineVersion_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_;

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

		[Register(".ctor", "()V", "")]
		public unsafe Builder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetBuildHandler()
		{
			if ((object)cb_build_Build_Lio_appmetrica_analytics_plugins_PluginErrorDetails_ == null)
			{
				cb_build_Build_Lio_appmetrica_analytics_plugins_PluginErrorDetails_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
			}
			return cb_build_Build_Lio_appmetrica_analytics_plugins_PluginErrorDetails_;
		}

		private static nint n_Build(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
		}

		[Register("build", "()Lio/appmetrica/analytics/plugins/PluginErrorDetails;", "GetBuildHandler")]
		public unsafe virtual PluginErrorDetails Build()
		{
			return Java.Lang.Object.GetObject<PluginErrorDetails>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lio/appmetrica/analytics/plugins/PluginErrorDetails;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithExceptionClass_Ljava_lang_String_Handler()
		{
			if ((object)cb_withExceptionClass_WithExceptionClass_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_ == null)
			{
				cb_withExceptionClass_WithExceptionClass_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithExceptionClass_Ljava_lang_String_));
			}
			return cb_withExceptionClass_WithExceptionClass_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_;
		}

		private static nint n_WithExceptionClass_Ljava_lang_String_(nint jnienv, nint native__this, nint native_value)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithExceptionClass(value));
		}

		[Register("withExceptionClass", "(Ljava/lang/String;)Lio/appmetrica/analytics/plugins/PluginErrorDetails$Builder;", "GetWithExceptionClass_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithExceptionClass(string? value)
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withExceptionClass.(Ljava/lang/String;)Lio/appmetrica/analytics/plugins/PluginErrorDetails$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetWithMessage_Ljava_lang_String_Handler()
		{
			if ((object)cb_withMessage_WithMessage_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_ == null)
			{
				cb_withMessage_WithMessage_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithMessage_Ljava_lang_String_));
			}
			return cb_withMessage_WithMessage_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_;
		}

		private static nint n_WithMessage_Ljava_lang_String_(nint jnienv, nint native__this, nint native_value)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithMessage(value));
		}

		[Register("withMessage", "(Ljava/lang/String;)Lio/appmetrica/analytics/plugins/PluginErrorDetails$Builder;", "GetWithMessage_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithMessage(string? value)
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withMessage.(Ljava/lang/String;)Lio/appmetrica/analytics/plugins/PluginErrorDetails$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetWithPlatform_Ljava_lang_String_Handler()
		{
			if ((object)cb_withPlatform_WithPlatform_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_ == null)
			{
				cb_withPlatform_WithPlatform_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithPlatform_Ljava_lang_String_));
			}
			return cb_withPlatform_WithPlatform_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_;
		}

		private static nint n_WithPlatform_Ljava_lang_String_(nint jnienv, nint native__this, nint native_value)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithPlatform(value));
		}

		[Register("withPlatform", "(Ljava/lang/String;)Lio/appmetrica/analytics/plugins/PluginErrorDetails$Builder;", "GetWithPlatform_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithPlatform(string? value)
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withPlatform.(Ljava/lang/String;)Lio/appmetrica/analytics/plugins/PluginErrorDetails$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetWithPluginEnvironment_Ljava_util_Map_Handler()
		{
			if ((object)cb_withPluginEnvironment_WithPluginEnvironment_Ljava_util_Map__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_ == null)
			{
				cb_withPluginEnvironment_WithPluginEnvironment_Ljava_util_Map__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithPluginEnvironment_Ljava_util_Map_));
			}
			return cb_withPluginEnvironment_WithPluginEnvironment_Ljava_util_Map__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_;
		}

		private static nint n_WithPluginEnvironment_Ljava_util_Map_(nint jnienv, nint native__this, nint native_value)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDictionary<string, string> value = JavaDictionary<string, string>.FromJniHandle(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithPluginEnvironment(value));
		}

		[Register("withPluginEnvironment", "(Ljava/util/Map;)Lio/appmetrica/analytics/plugins/PluginErrorDetails$Builder;", "GetWithPluginEnvironment_Ljava_util_Map_Handler")]
		public unsafe virtual Builder WithPluginEnvironment(IDictionary<string, string>? value)
		{
			nint num = JavaDictionary<string, string>.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withPluginEnvironment.(Ljava/util/Map;)Lio/appmetrica/analytics/plugins/PluginErrorDetails$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetWithStacktrace_Ljava_util_List_Handler()
		{
			if ((object)cb_withStacktrace_WithStacktrace_Ljava_util_List__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_ == null)
			{
				cb_withStacktrace_WithStacktrace_Ljava_util_List__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithStacktrace_Ljava_util_List_));
			}
			return cb_withStacktrace_WithStacktrace_Ljava_util_List__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_;
		}

		private static nint n_WithStacktrace_Ljava_util_List_(nint jnienv, nint native__this, nint native_value)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<StackTraceItem> value = JavaList<StackTraceItem>.FromJniHandle(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithStacktrace(value));
		}

		[Register("withStacktrace", "(Ljava/util/List;)Lio/appmetrica/analytics/plugins/PluginErrorDetails$Builder;", "GetWithStacktrace_Ljava_util_List_Handler")]
		public unsafe virtual Builder WithStacktrace(IList<StackTraceItem>? value)
		{
			nint num = JavaList<StackTraceItem>.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withStacktrace.(Ljava/util/List;)Lio/appmetrica/analytics/plugins/PluginErrorDetails$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetWithVirtualMachineVersion_Ljava_lang_String_Handler()
		{
			if ((object)cb_withVirtualMachineVersion_WithVirtualMachineVersion_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_ == null)
			{
				cb_withVirtualMachineVersion_WithVirtualMachineVersion_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithVirtualMachineVersion_Ljava_lang_String_));
			}
			return cb_withVirtualMachineVersion_WithVirtualMachineVersion_Ljava_lang_String__Lio_appmetrica_analytics_plugins_PluginErrorDetails_Builder_;
		}

		private static nint n_WithVirtualMachineVersion_Ljava_lang_String_(nint jnienv, nint native__this, nint native_value)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithVirtualMachineVersion(value));
		}

		[Register("withVirtualMachineVersion", "(Ljava/lang/String;)Lio/appmetrica/analytics/plugins/PluginErrorDetails$Builder;", "GetWithVirtualMachineVersion_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithVirtualMachineVersion(string? value)
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withVirtualMachineVersion.(Ljava/lang/String;)Lio/appmetrica/analytics/plugins/PluginErrorDetails$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/plugins/PluginErrorDetails", typeof(PluginErrorDetails));

	private static Delegate? cb_getExceptionClass_GetExceptionClass_Ljava_lang_String_;

	private static Delegate? cb_getMessage_GetMessage_Ljava_lang_String_;

	private static Delegate? cb_getPluginEnvironment_GetPluginEnvironment_Ljava_util_Map_;

	private static Delegate? cb_getStacktrace_GetStacktrace_Ljava_util_List_;

	private static Delegate? cb_getVirtualMachineVersion_GetVirtualMachineVersion_Ljava_lang_String_;

	private static Delegate? cb_getPlatform_GetPlatform_Ljava_lang_String_;

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

	public unsafe virtual string? ExceptionClass
	{
		[Register("getExceptionClass", "()Ljava/lang/String;", "GetGetExceptionClassHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getExceptionClass.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? Message
	{
		[Register("getMessage", "()Ljava/lang/String;", "GetGetMessageHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IDictionary<string, string> PluginEnvironment
	{
		[Register("getPluginEnvironment", "()Ljava/util/Map;", "GetGetPluginEnvironmentHandler")]
		get
		{
			return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getPluginEnvironment.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IList<StackTraceItem> Stacktrace
	{
		[Register("getStacktrace", "()Ljava/util/List;", "GetGetStacktraceHandler")]
		get
		{
			return JavaList<StackTraceItem>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getStacktrace.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? VirtualMachineVersion
	{
		[Register("getVirtualMachineVersion", "()Ljava/lang/String;", "GetGetVirtualMachineVersionHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getVirtualMachineVersion.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected PluginErrorDetails(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetExceptionClassHandler()
	{
		if ((object)cb_getExceptionClass_GetExceptionClass_Ljava_lang_String_ == null)
		{
			cb_getExceptionClass_GetExceptionClass_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExceptionClass));
		}
		return cb_getExceptionClass_GetExceptionClass_Ljava_lang_String_;
	}

	private static nint n_GetExceptionClass(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<PluginErrorDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExceptionClass);
	}

	private static Delegate GetGetMessageHandler()
	{
		if ((object)cb_getMessage_GetMessage_Ljava_lang_String_ == null)
		{
			cb_getMessage_GetMessage_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMessage));
		}
		return cb_getMessage_GetMessage_Ljava_lang_String_;
	}

	private static nint n_GetMessage(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<PluginErrorDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Message);
	}

	private static Delegate GetGetPluginEnvironmentHandler()
	{
		if ((object)cb_getPluginEnvironment_GetPluginEnvironment_Ljava_util_Map_ == null)
		{
			cb_getPluginEnvironment_GetPluginEnvironment_Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPluginEnvironment));
		}
		return cb_getPluginEnvironment_GetPluginEnvironment_Ljava_util_Map_;
	}

	private static nint n_GetPluginEnvironment(nint jnienv, nint native__this)
	{
		return JavaDictionary<string, string>.ToLocalJniHandle(Java.Lang.Object.GetObject<PluginErrorDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PluginEnvironment);
	}

	private static Delegate GetGetStacktraceHandler()
	{
		if ((object)cb_getStacktrace_GetStacktrace_Ljava_util_List_ == null)
		{
			cb_getStacktrace_GetStacktrace_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetStacktrace));
		}
		return cb_getStacktrace_GetStacktrace_Ljava_util_List_;
	}

	private static nint n_GetStacktrace(nint jnienv, nint native__this)
	{
		return JavaList<StackTraceItem>.ToLocalJniHandle(Java.Lang.Object.GetObject<PluginErrorDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Stacktrace);
	}

	private static Delegate GetGetVirtualMachineVersionHandler()
	{
		if ((object)cb_getVirtualMachineVersion_GetVirtualMachineVersion_Ljava_lang_String_ == null)
		{
			cb_getVirtualMachineVersion_GetVirtualMachineVersion_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetVirtualMachineVersion));
		}
		return cb_getVirtualMachineVersion_GetVirtualMachineVersion_Ljava_lang_String_;
	}

	private static nint n_GetVirtualMachineVersion(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<PluginErrorDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VirtualMachineVersion);
	}

	private static Delegate GetGetPlatformHandler()
	{
		if ((object)cb_getPlatform_GetPlatform_Ljava_lang_String_ == null)
		{
			cb_getPlatform_GetPlatform_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPlatform));
		}
		return cb_getPlatform_GetPlatform_Ljava_lang_String_;
	}

	private static nint n_GetPlatform(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<PluginErrorDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPlatform());
	}

	[Register("getPlatform", "()Ljava/lang/String;", "GetGetPlatformHandler")]
	public unsafe virtual string? GetPlatform()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getPlatform.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
