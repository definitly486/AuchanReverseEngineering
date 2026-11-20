using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Camera.Core.Internal;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/UseCaseConfig", DoNotGenerateAcw = true)]
internal class IUseCaseConfigInvoker : Java.Lang.Object, IUseCaseConfig, IImageInputConfig, IReadableConfig, IConfig, IJavaObject, IDisposable, IJavaPeerable, ITargetConfig
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/UseCaseConfig", typeof(IUseCaseConfigInvoker));

	private nint class_ref;

	private static Delegate? cb_getConfig;

	private nint id_getConfig;

	private static Delegate? cb_containsOption_Landroidx_camera_core_impl_Config_Option_;

	private nint id_containsOption_Landroidx_camera_core_impl_Config_Option_;

	private static Delegate? cb_findOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_;

	private nint id_findOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_;

	private static Delegate? cb_getOptionPriority_Landroidx_camera_core_impl_Config_Option_;

	private nint id_getOptionPriority_Landroidx_camera_core_impl_Config_Option_;

	private static Delegate? cb_getPriorities_Landroidx_camera_core_impl_Config_Option_;

	private nint id_getPriorities_Landroidx_camera_core_impl_Config_Option_;

	private static Delegate? cb_listOptions;

	private nint id_listOptions;

	private static Delegate? cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_;

	private nint id_retrieveOption_Landroidx_camera_core_impl_Config_Option_;

	private static Delegate? cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_;

	private nint id_retrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_;

	private static Delegate? cb_retrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_;

	private nint id_retrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_;

	private static nint java_class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => class_ref;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public IConfig Config
	{
		get
		{
			if (id_getConfig == IntPtr.Zero)
			{
				id_getConfig = JNIEnv.GetMethodID(class_ref, "getConfig", "()Landroidx/camera/core/impl/Config;");
			}
			return Java.Lang.Object.GetObject<IConfig>(JNIEnv.CallObjectMethod(base.Handle, id_getConfig), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static IUseCaseConfig? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IUseCaseConfig>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.UseCaseConfig'.");
		}
		return handle;
	}

	protected override void Dispose(bool disposing)
	{
		if (class_ref != IntPtr.Zero)
		{
			JNIEnv.DeleteGlobalRef(class_ref);
		}
		class_ref = IntPtr.Zero;
		base.Dispose(disposing);
	}

	public IUseCaseConfigInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetConfigHandler()
	{
		if ((object)cb_getConfig == null)
		{
			cb_getConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetConfig));
		}
		return cb_getConfig;
	}

	private static nint n_GetConfig(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Config);
	}

	private static Delegate GetContainsOption_Landroidx_camera_core_impl_Config_Option_Handler()
	{
		if ((object)cb_containsOption_Landroidx_camera_core_impl_Config_Option_ == null)
		{
			cb_containsOption_Landroidx_camera_core_impl_Config_Option_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_ContainsOption_Landroidx_camera_core_impl_Config_Option_));
		}
		return cb_containsOption_Landroidx_camera_core_impl_Config_Option_;
	}

	private static bool n_ContainsOption_Landroidx_camera_core_impl_Config_Option_(nint jnienv, nint native__this, nint native_p0)
	{
		IUseCaseConfig? useCaseConfig = Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption p = Java.Lang.Object.GetObject<ConfigOption>(native_p0, JniHandleOwnership.DoNotTransfer);
		return useCaseConfig.ContainsOption(p);
	}

	public unsafe bool ContainsOption(ConfigOption p0)
	{
		if (id_containsOption_Landroidx_camera_core_impl_Config_Option_ == IntPtr.Zero)
		{
			id_containsOption_Landroidx_camera_core_impl_Config_Option_ = JNIEnv.GetMethodID(class_ref, "containsOption", "(Landroidx/camera/core/impl/Config$Option;)Z");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		return JNIEnv.CallBooleanMethod(base.Handle, id_containsOption_Landroidx_camera_core_impl_Config_Option_, ptr);
	}

	private static Delegate GetFindOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_Handler()
	{
		if ((object)cb_findOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_ == null)
		{
			cb_findOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_FindOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_));
		}
		return cb_findOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_;
	}

	private static void n_FindOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IUseCaseConfig? useCaseConfig = Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		IConfigOptionMatcher p2 = Java.Lang.Object.GetObject<IConfigOptionMatcher>(native_p1, JniHandleOwnership.DoNotTransfer);
		useCaseConfig.FindOptions(p, p2);
	}

	public unsafe void FindOptions(string p0, IConfigOptionMatcher p1)
	{
		if (id_findOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_ == IntPtr.Zero)
		{
			id_findOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_ = JNIEnv.GetMethodID(class_ref, "findOptions", "(Ljava/lang/String;Landroidx/camera/core/impl/Config$OptionMatcher;)V");
		}
		nint num = JNIEnv.NewString(p0);
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(num);
		ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
		JNIEnv.CallVoidMethod(base.Handle, id_findOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_, ptr);
		JNIEnv.DeleteLocalRef(num);
	}

	private static Delegate GetGetOptionPriority_Landroidx_camera_core_impl_Config_Option_Handler()
	{
		if ((object)cb_getOptionPriority_Landroidx_camera_core_impl_Config_Option_ == null)
		{
			cb_getOptionPriority_Landroidx_camera_core_impl_Config_Option_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetOptionPriority_Landroidx_camera_core_impl_Config_Option_));
		}
		return cb_getOptionPriority_Landroidx_camera_core_impl_Config_Option_;
	}

	private static nint n_GetOptionPriority_Landroidx_camera_core_impl_Config_Option_(nint jnienv, nint native__this, nint native_p0)
	{
		IUseCaseConfig? useCaseConfig = Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption p = Java.Lang.Object.GetObject<ConfigOption>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfig.GetOptionPriority(p));
	}

	public unsafe ConfigOptionPriority GetOptionPriority(ConfigOption p0)
	{
		if (id_getOptionPriority_Landroidx_camera_core_impl_Config_Option_ == IntPtr.Zero)
		{
			id_getOptionPriority_Landroidx_camera_core_impl_Config_Option_ = JNIEnv.GetMethodID(class_ref, "getOptionPriority", "(Landroidx/camera/core/impl/Config$Option;)Landroidx/camera/core/impl/Config$OptionPriority;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<ConfigOptionPriority>(JNIEnv.CallObjectMethod(base.Handle, id_getOptionPriority_Landroidx_camera_core_impl_Config_Option_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetPriorities_Landroidx_camera_core_impl_Config_Option_Handler()
	{
		if ((object)cb_getPriorities_Landroidx_camera_core_impl_Config_Option_ == null)
		{
			cb_getPriorities_Landroidx_camera_core_impl_Config_Option_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetPriorities_Landroidx_camera_core_impl_Config_Option_));
		}
		return cb_getPriorities_Landroidx_camera_core_impl_Config_Option_;
	}

	private static nint n_GetPriorities_Landroidx_camera_core_impl_Config_Option_(nint jnienv, nint native__this, nint native_p0)
	{
		IUseCaseConfig? useCaseConfig = Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption p = Java.Lang.Object.GetObject<ConfigOption>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JavaSet<ConfigOptionPriority>.ToLocalJniHandle(useCaseConfig.GetPriorities(p));
	}

	public unsafe ICollection<ConfigOptionPriority> GetPriorities(ConfigOption p0)
	{
		if (id_getPriorities_Landroidx_camera_core_impl_Config_Option_ == IntPtr.Zero)
		{
			id_getPriorities_Landroidx_camera_core_impl_Config_Option_ = JNIEnv.GetMethodID(class_ref, "getPriorities", "(Landroidx/camera/core/impl/Config$Option;)Ljava/util/Set;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		return JavaSet<ConfigOptionPriority>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getPriorities_Landroidx_camera_core_impl_Config_Option_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetListOptionsHandler()
	{
		if ((object)cb_listOptions == null)
		{
			cb_listOptions = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ListOptions));
		}
		return cb_listOptions;
	}

	private static nint n_ListOptions(nint jnienv, nint native__this)
	{
		return JavaSet<ConfigOption>.ToLocalJniHandle(Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ListOptions());
	}

	public ICollection<ConfigOption> ListOptions()
	{
		if (id_listOptions == IntPtr.Zero)
		{
			id_listOptions = JNIEnv.GetMethodID(class_ref, "listOptions", "()Ljava/util/Set;");
		}
		return JavaSet<ConfigOption>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_listOptions), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRetrieveOption_Landroidx_camera_core_impl_Config_Option_Handler()
	{
		if ((object)cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_ == null)
		{
			cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RetrieveOption_Landroidx_camera_core_impl_Config_Option_));
		}
		return cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_;
	}

	private static nint n_RetrieveOption_Landroidx_camera_core_impl_Config_Option_(nint jnienv, nint native__this, nint native_p0)
	{
		IUseCaseConfig? useCaseConfig = Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption p = Java.Lang.Object.GetObject<ConfigOption>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfig.RetrieveOption(p));
	}

	public unsafe Java.Lang.Object? RetrieveOption(ConfigOption p0)
	{
		if (id_retrieveOption_Landroidx_camera_core_impl_Config_Option_ == IntPtr.Zero)
		{
			id_retrieveOption_Landroidx_camera_core_impl_Config_Option_ = JNIEnv.GetMethodID(class_ref, "retrieveOption", "(Landroidx/camera/core/impl/Config$Option;)Ljava/lang/Object;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_retrieveOption_Landroidx_camera_core_impl_Config_Option_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRetrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_Handler()
	{
		if ((object)cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_ == null)
		{
			cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_RetrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_));
		}
		return cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_;
	}

	private static nint n_RetrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IUseCaseConfig? useCaseConfig = Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption p = Java.Lang.Object.GetObject<ConfigOption>(native_p0, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfig.RetrieveOption(p, p2));
	}

	public unsafe Java.Lang.Object? RetrieveOption(ConfigOption p0, Java.Lang.Object? p1)
	{
		if (id_retrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_ == IntPtr.Zero)
		{
			id_retrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "retrieveOption", "(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)Ljava/lang/Object;");
		}
		nint num = JNIEnv.ToLocalJniHandle(p1);
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(num);
		Java.Lang.Object? result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_retrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_, ptr), JniHandleOwnership.TransferLocalRef);
		JNIEnv.DeleteLocalRef(num);
		return result;
	}

	private static Delegate GetRetrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_Handler()
	{
		if ((object)cb_retrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_ == null)
		{
			cb_retrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_RetrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_));
		}
		return cb_retrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_;
	}

	private static nint n_RetrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IUseCaseConfig? useCaseConfig = Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption p = Java.Lang.Object.GetObject<ConfigOption>(native_p0, JniHandleOwnership.DoNotTransfer);
		ConfigOptionPriority p2 = Java.Lang.Object.GetObject<ConfigOptionPriority>(native_p1, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfig.RetrieveOptionWithPriority(p, p2));
	}

	public unsafe Java.Lang.Object? RetrieveOptionWithPriority(ConfigOption p0, ConfigOptionPriority p1)
	{
		if (id_retrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_ == IntPtr.Zero)
		{
			id_retrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_ = JNIEnv.GetMethodID(class_ref, "retrieveOptionWithPriority", "(Landroidx/camera/core/impl/Config$Option;Landroidx/camera/core/impl/Config$OptionPriority;)Ljava/lang/Object;");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_retrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_, ptr), JniHandleOwnership.TransferLocalRef);
	}
}
