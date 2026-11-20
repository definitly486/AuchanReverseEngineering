using System;
using Android.Runtime;
using AndroidX.Camera.Core.Impl;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Internal;

[Register("androidx/camera/core/internal/TargetConfig", "", "AndroidX.Camera.Core.Internal.ITargetConfigInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface ITargetConfig : IReadableConfig, IConfig, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/internal/TargetConfig", typeof(ITargetConfig), isInterface: true);

	private static Delegate? cb_getTargetClass;

	private static Delegate? cb_getTargetName;

	private static Delegate? cb_getTargetClass_Ljava_lang_Class_;

	private static Delegate? cb_getTargetName_Ljava_lang_String_;

	[Register("OPTION_TARGET_CLASS")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	static ConfigOption OptionTargetClass => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_TARGET_CLASS.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_TARGET_NAME")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	static ConfigOption OptionTargetName => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_TARGET_NAME.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	unsafe Class TargetClass
	{
		[Register("getTargetClass", "()Ljava/lang/Class;", "GetGetTargetClassHandler:AndroidX.Camera.Core.Internal.ITargetConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<Class>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTargetClass.()Ljava/lang/Class;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	unsafe string TargetName
	{
		[Register("getTargetName", "()Ljava/lang/String;", "GetGetTargetNameHandler:AndroidX.Camera.Core.Internal.ITargetConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getTargetName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static Delegate GetGetTargetClassHandler()
	{
		if ((object)cb_getTargetClass == null)
		{
			cb_getTargetClass = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTargetClass));
		}
		return cb_getTargetClass;
	}

	private static nint n_GetTargetClass(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ITargetConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetClass);
	}

	private static Delegate GetGetTargetNameHandler()
	{
		if ((object)cb_getTargetName == null)
		{
			cb_getTargetName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTargetName));
		}
		return cb_getTargetName;
	}

	private static nint n_GetTargetName(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ITargetConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetName);
	}

	private static Delegate GetGetTargetClass_Ljava_lang_Class_Handler()
	{
		if ((object)cb_getTargetClass_Ljava_lang_Class_ == null)
		{
			cb_getTargetClass_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetTargetClass_Ljava_lang_Class_));
		}
		return cb_getTargetClass_Ljava_lang_Class_;
	}

	private static nint n_GetTargetClass_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_valueIfMissing)
	{
		ITargetConfig? targetConfig = Java.Lang.Object.GetObject<ITargetConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Class valueIfMissing = Java.Lang.Object.GetObject<Class>(native_valueIfMissing, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(targetConfig.GetTargetClass(valueIfMissing));
	}

	[Register("getTargetClass", "(Ljava/lang/Class;)Ljava/lang/Class;", "GetGetTargetClass_Ljava_lang_Class_Handler:AndroidX.Camera.Core.Internal.ITargetConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe Class? GetTargetClass(Class? valueIfMissing)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(valueIfMissing?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Class>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTargetClass.(Ljava/lang/Class;)Ljava/lang/Class;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(valueIfMissing);
		}
	}

	private static Delegate GetGetTargetName_Ljava_lang_String_Handler()
	{
		if ((object)cb_getTargetName_Ljava_lang_String_ == null)
		{
			cb_getTargetName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetTargetName_Ljava_lang_String_));
		}
		return cb_getTargetName_Ljava_lang_String_;
	}

	private static nint n_GetTargetName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_valueIfMissing)
	{
		ITargetConfig? targetConfig = Java.Lang.Object.GetObject<ITargetConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string valueIfMissing = JNIEnv.GetString(native_valueIfMissing, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.NewString(targetConfig.GetTargetName(valueIfMissing));
	}

	[Register("getTargetName", "(Ljava/lang/String;)Ljava/lang/String;", "GetGetTargetName_Ljava_lang_String_Handler:AndroidX.Camera.Core.Internal.ITargetConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe string? GetTargetName(string? valueIfMissing)
	{
		nint num = JNIEnv.NewString(valueIfMissing);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getTargetName.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
