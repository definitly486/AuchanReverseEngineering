using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Plugins;

[Register("io/appmetrica/analytics/plugins/StackTraceItem", DoNotGenerateAcw = true)]
public class StackTraceItem : Java.Lang.Object
{
	[Register("io/appmetrica/analytics/plugins/StackTraceItem$Builder", DoNotGenerateAcw = true)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/plugins/StackTraceItem$Builder", typeof(Builder));

		private static Delegate? cb_build_Build_Lio_appmetrica_analytics_plugins_StackTraceItem_;

		private static Delegate? cb_withClassName_WithClassName_Ljava_lang_String__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_;

		private static Delegate? cb_withColumn_WithColumn_Ljava_lang_Integer__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_;

		private static Delegate? cb_withFileName_WithFileName_Ljava_lang_String__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_;

		private static Delegate? cb_withLine_WithLine_Ljava_lang_Integer__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_;

		private static Delegate? cb_withMethodName_WithMethodName_Ljava_lang_String__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_;

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
			if ((object)cb_build_Build_Lio_appmetrica_analytics_plugins_StackTraceItem_ == null)
			{
				cb_build_Build_Lio_appmetrica_analytics_plugins_StackTraceItem_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
			}
			return cb_build_Build_Lio_appmetrica_analytics_plugins_StackTraceItem_;
		}

		private static nint n_Build(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
		}

		[Register("build", "()Lio/appmetrica/analytics/plugins/StackTraceItem;", "GetBuildHandler")]
		public unsafe virtual StackTraceItem Build()
		{
			return Java.Lang.Object.GetObject<StackTraceItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lio/appmetrica/analytics/plugins/StackTraceItem;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithClassName_Ljava_lang_String_Handler()
		{
			if ((object)cb_withClassName_WithClassName_Ljava_lang_String__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_ == null)
			{
				cb_withClassName_WithClassName_Ljava_lang_String__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithClassName_Ljava_lang_String_));
			}
			return cb_withClassName_WithClassName_Ljava_lang_String__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_;
		}

		private static nint n_WithClassName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_value)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithClassName(value));
		}

		[Register("withClassName", "(Ljava/lang/String;)Lio/appmetrica/analytics/plugins/StackTraceItem$Builder;", "GetWithClassName_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithClassName(string? value)
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withClassName.(Ljava/lang/String;)Lio/appmetrica/analytics/plugins/StackTraceItem$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetWithColumn_Ljava_lang_Integer_Handler()
		{
			if ((object)cb_withColumn_WithColumn_Ljava_lang_Integer__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_ == null)
			{
				cb_withColumn_WithColumn_Ljava_lang_Integer__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithColumn_Ljava_lang_Integer_));
			}
			return cb_withColumn_WithColumn_Ljava_lang_Integer__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_;
		}

		private static nint n_WithColumn_Ljava_lang_Integer_(nint jnienv, nint native__this, nint native_value)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Integer value = Java.Lang.Object.GetObject<Integer>(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithColumn(value));
		}

		[Register("withColumn", "(Ljava/lang/Integer;)Lio/appmetrica/analytics/plugins/StackTraceItem$Builder;", "GetWithColumn_Ljava_lang_Integer_Handler")]
		public unsafe virtual Builder WithColumn(Integer? value)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withColumn.(Ljava/lang/Integer;)Lio/appmetrica/analytics/plugins/StackTraceItem$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetWithFileName_Ljava_lang_String_Handler()
		{
			if ((object)cb_withFileName_WithFileName_Ljava_lang_String__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_ == null)
			{
				cb_withFileName_WithFileName_Ljava_lang_String__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithFileName_Ljava_lang_String_));
			}
			return cb_withFileName_WithFileName_Ljava_lang_String__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_;
		}

		private static nint n_WithFileName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_value)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithFileName(value));
		}

		[Register("withFileName", "(Ljava/lang/String;)Lio/appmetrica/analytics/plugins/StackTraceItem$Builder;", "GetWithFileName_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithFileName(string? value)
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withFileName.(Ljava/lang/String;)Lio/appmetrica/analytics/plugins/StackTraceItem$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetWithLine_Ljava_lang_Integer_Handler()
		{
			if ((object)cb_withLine_WithLine_Ljava_lang_Integer__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_ == null)
			{
				cb_withLine_WithLine_Ljava_lang_Integer__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithLine_Ljava_lang_Integer_));
			}
			return cb_withLine_WithLine_Ljava_lang_Integer__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_;
		}

		private static nint n_WithLine_Ljava_lang_Integer_(nint jnienv, nint native__this, nint native_value)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Integer value = Java.Lang.Object.GetObject<Integer>(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithLine(value));
		}

		[Register("withLine", "(Ljava/lang/Integer;)Lio/appmetrica/analytics/plugins/StackTraceItem$Builder;", "GetWithLine_Ljava_lang_Integer_Handler")]
		public unsafe virtual Builder WithLine(Integer? value)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withLine.(Ljava/lang/Integer;)Lio/appmetrica/analytics/plugins/StackTraceItem$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetWithMethodName_Ljava_lang_String_Handler()
		{
			if ((object)cb_withMethodName_WithMethodName_Ljava_lang_String__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_ == null)
			{
				cb_withMethodName_WithMethodName_Ljava_lang_String__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithMethodName_Ljava_lang_String_));
			}
			return cb_withMethodName_WithMethodName_Ljava_lang_String__Lio_appmetrica_analytics_plugins_StackTraceItem_Builder_;
		}

		private static nint n_WithMethodName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_value)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithMethodName(value));
		}

		[Register("withMethodName", "(Ljava/lang/String;)Lio/appmetrica/analytics/plugins/StackTraceItem$Builder;", "GetWithMethodName_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithMethodName(string? value)
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withMethodName.(Ljava/lang/String;)Lio/appmetrica/analytics/plugins/StackTraceItem$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/plugins/StackTraceItem", typeof(StackTraceItem));

	private static Delegate? cb_getClassName_GetClassName_Ljava_lang_String_;

	private static Delegate? cb_getColumn_GetColumn_Ljava_lang_Integer_;

	private static Delegate? cb_getFileName_GetFileName_Ljava_lang_String_;

	private static Delegate? cb_getLine_GetLine_Ljava_lang_Integer_;

	private static Delegate? cb_getMethodName_GetMethodName_Ljava_lang_String_;

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

	public unsafe virtual string? ClassName
	{
		[Register("getClassName", "()Ljava/lang/String;", "GetGetClassNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getClassName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Integer? Column
	{
		[Register("getColumn", "()Ljava/lang/Integer;", "GetGetColumnHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getColumn.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? FileName
	{
		[Register("getFileName", "()Ljava/lang/String;", "GetGetFileNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getFileName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Integer? Line
	{
		[Register("getLine", "()Ljava/lang/Integer;", "GetGetLineHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLine.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? MethodName
	{
		[Register("getMethodName", "()Ljava/lang/String;", "GetGetMethodNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMethodName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected StackTraceItem(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetClassNameHandler()
	{
		if ((object)cb_getClassName_GetClassName_Ljava_lang_String_ == null)
		{
			cb_getClassName_GetClassName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetClassName));
		}
		return cb_getClassName_GetClassName_Ljava_lang_String_;
	}

	private static nint n_GetClassName(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<StackTraceItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClassName);
	}

	private static Delegate GetGetColumnHandler()
	{
		if ((object)cb_getColumn_GetColumn_Ljava_lang_Integer_ == null)
		{
			cb_getColumn_GetColumn_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetColumn));
		}
		return cb_getColumn_GetColumn_Ljava_lang_Integer_;
	}

	private static nint n_GetColumn(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<StackTraceItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Column);
	}

	private static Delegate GetGetFileNameHandler()
	{
		if ((object)cb_getFileName_GetFileName_Ljava_lang_String_ == null)
		{
			cb_getFileName_GetFileName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFileName));
		}
		return cb_getFileName_GetFileName_Ljava_lang_String_;
	}

	private static nint n_GetFileName(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<StackTraceItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FileName);
	}

	private static Delegate GetGetLineHandler()
	{
		if ((object)cb_getLine_GetLine_Ljava_lang_Integer_ == null)
		{
			cb_getLine_GetLine_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLine));
		}
		return cb_getLine_GetLine_Ljava_lang_Integer_;
	}

	private static nint n_GetLine(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<StackTraceItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Line);
	}

	private static Delegate GetGetMethodNameHandler()
	{
		if ((object)cb_getMethodName_GetMethodName_Ljava_lang_String_ == null)
		{
			cb_getMethodName_GetMethodName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMethodName));
		}
		return cb_getMethodName_GetMethodName_Ljava_lang_String_;
	}

	private static nint n_GetMethodName(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<StackTraceItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MethodName);
	}
}
