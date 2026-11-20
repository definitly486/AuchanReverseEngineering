using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/ReadableConfig", "", "AndroidX.Camera.Core.Impl.IReadableConfigInvoker")]
public interface IReadableConfig : IConfig, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/ReadableConfig", typeof(IReadableConfig), isInterface: true);

	private static Delegate? cb_containsOption_Landroidx_camera_core_impl_Config_Option_;

	private static Delegate? cb_findOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_;

	private static Delegate? cb_getOptionPriority_Landroidx_camera_core_impl_Config_Option_;

	private static Delegate? cb_getPriorities_Landroidx_camera_core_impl_Config_Option_;

	private static Delegate? cb_listOptions;

	private static Delegate? cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_;

	private static Delegate? cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_;

	private static Delegate? cb_retrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_;

	IConfig Config
	{
		[Register("getConfig", "()Landroidx/camera/core/impl/Config;", "GetGetConfigHandler:AndroidX.Camera.Core.Impl.IReadableConfigInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	private static Delegate GetContainsOption_Landroidx_camera_core_impl_Config_Option_Handler()
	{
		if ((object)cb_containsOption_Landroidx_camera_core_impl_Config_Option_ == null)
		{
			cb_containsOption_Landroidx_camera_core_impl_Config_Option_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_ContainsOption_Landroidx_camera_core_impl_Config_Option_));
		}
		return cb_containsOption_Landroidx_camera_core_impl_Config_Option_;
	}

	private static bool n_ContainsOption_Landroidx_camera_core_impl_Config_Option_(nint jnienv, nint native__this, nint native_id)
	{
		IReadableConfig? readableConfig = Java.Lang.Object.GetObject<IReadableConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption p = Java.Lang.Object.GetObject<ConfigOption>(native_id, JniHandleOwnership.DoNotTransfer);
		return readableConfig.ContainsOption(p);
	}

	[Register("containsOption", "(Landroidx/camera/core/impl/Config$Option;)Z", "GetContainsOption_Landroidx_camera_core_impl_Config_Option_Handler:AndroidX.Camera.Core.Impl.IReadableConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe bool IConfig.ContainsOption(ConfigOption id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("containsOption.(Landroidx/camera/core/impl/Config$Option;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(id);
		}
	}

	private static Delegate GetFindOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_Handler()
	{
		if ((object)cb_findOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_ == null)
		{
			cb_findOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_FindOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_));
		}
		return cb_findOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_;
	}

	private static void n_FindOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_(nint jnienv, nint native__this, nint native_idSearchString, nint native_matcher)
	{
		IReadableConfig? readableConfig = Java.Lang.Object.GetObject<IReadableConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_idSearchString, JniHandleOwnership.DoNotTransfer);
		IConfigOptionMatcher p2 = Java.Lang.Object.GetObject<IConfigOptionMatcher>(native_matcher, JniHandleOwnership.DoNotTransfer);
		readableConfig.FindOptions(p, p2);
	}

	[Register("findOptions", "(Ljava/lang/String;Landroidx/camera/core/impl/Config$OptionMatcher;)V", "GetFindOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_Handler:AndroidX.Camera.Core.Impl.IReadableConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe void IConfig.FindOptions(string idSearchString, IConfigOptionMatcher matcher)
	{
		nint num = JNIEnv.NewString(idSearchString);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((matcher == null) ? IntPtr.Zero : ((Java.Lang.Object)matcher).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("findOptions.(Ljava/lang/String;Landroidx/camera/core/impl/Config$OptionMatcher;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(matcher);
		}
	}

	private static Delegate GetGetOptionPriority_Landroidx_camera_core_impl_Config_Option_Handler()
	{
		if ((object)cb_getOptionPriority_Landroidx_camera_core_impl_Config_Option_ == null)
		{
			cb_getOptionPriority_Landroidx_camera_core_impl_Config_Option_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetOptionPriority_Landroidx_camera_core_impl_Config_Option_));
		}
		return cb_getOptionPriority_Landroidx_camera_core_impl_Config_Option_;
	}

	private static nint n_GetOptionPriority_Landroidx_camera_core_impl_Config_Option_(nint jnienv, nint native__this, nint native_opt)
	{
		IReadableConfig? readableConfig = Java.Lang.Object.GetObject<IReadableConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption p = Java.Lang.Object.GetObject<ConfigOption>(native_opt, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(readableConfig.GetOptionPriority(p));
	}

	[Register("getOptionPriority", "(Landroidx/camera/core/impl/Config$Option;)Landroidx/camera/core/impl/Config$OptionPriority;", "GetGetOptionPriority_Landroidx_camera_core_impl_Config_Option_Handler:AndroidX.Camera.Core.Impl.IReadableConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe ConfigOptionPriority IConfig.GetOptionPriority(ConfigOption opt)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(opt?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ConfigOptionPriority>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOptionPriority.(Landroidx/camera/core/impl/Config$Option;)Landroidx/camera/core/impl/Config$OptionPriority;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(opt);
		}
	}

	private static Delegate GetGetPriorities_Landroidx_camera_core_impl_Config_Option_Handler()
	{
		if ((object)cb_getPriorities_Landroidx_camera_core_impl_Config_Option_ == null)
		{
			cb_getPriorities_Landroidx_camera_core_impl_Config_Option_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetPriorities_Landroidx_camera_core_impl_Config_Option_));
		}
		return cb_getPriorities_Landroidx_camera_core_impl_Config_Option_;
	}

	private static nint n_GetPriorities_Landroidx_camera_core_impl_Config_Option_(nint jnienv, nint native__this, nint native_option)
	{
		IReadableConfig? readableConfig = Java.Lang.Object.GetObject<IReadableConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption p = Java.Lang.Object.GetObject<ConfigOption>(native_option, JniHandleOwnership.DoNotTransfer);
		return JavaSet<ConfigOptionPriority>.ToLocalJniHandle(readableConfig.GetPriorities(p));
	}

	[Register("getPriorities", "(Landroidx/camera/core/impl/Config$Option;)Ljava/util/Set;", "GetGetPriorities_Landroidx_camera_core_impl_Config_Option_Handler:AndroidX.Camera.Core.Impl.IReadableConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe ICollection<ConfigOptionPriority> IConfig.GetPriorities(ConfigOption option)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(option?.Handle ?? IntPtr.Zero);
			return JavaSet<ConfigOptionPriority>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getPriorities.(Landroidx/camera/core/impl/Config$Option;)Ljava/util/Set;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(option);
		}
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
		return JavaSet<ConfigOption>.ToLocalJniHandle(Java.Lang.Object.GetObject<IReadableConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ListOptions());
	}

	[Register("listOptions", "()Ljava/util/Set;", "GetListOptionsHandler:AndroidX.Camera.Core.Impl.IReadableConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe ICollection<ConfigOption> IConfig.ListOptions()
	{
		return JavaSet<ConfigOption>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("listOptions.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRetrieveOption_Landroidx_camera_core_impl_Config_Option_Handler()
	{
		if ((object)cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_ == null)
		{
			cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RetrieveOption_Landroidx_camera_core_impl_Config_Option_));
		}
		return cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_;
	}

	private static nint n_RetrieveOption_Landroidx_camera_core_impl_Config_Option_(nint jnienv, nint native__this, nint native_id)
	{
		IReadableConfig? readableConfig = Java.Lang.Object.GetObject<IReadableConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption p = Java.Lang.Object.GetObject<ConfigOption>(native_id, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(readableConfig.RetrieveOption(p));
	}

	[Register("retrieveOption", "(Landroidx/camera/core/impl/Config$Option;)Ljava/lang/Object;", "GetRetrieveOption_Landroidx_camera_core_impl_Config_Option_Handler:AndroidX.Camera.Core.Impl.IReadableConfig, Xamarin.AndroidX.Camera.Core")]
	[JavaTypeParameters(new string[] { "ValueT" })]
	unsafe Java.Lang.Object? IConfig.RetrieveOption(ConfigOption id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("retrieveOption.(Landroidx/camera/core/impl/Config$Option;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(id);
		}
	}

	private static Delegate GetRetrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_Handler()
	{
		if ((object)cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_ == null)
		{
			cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_RetrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_));
		}
		return cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_;
	}

	private static nint n_RetrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_id, nint native_valueIfMissing)
	{
		IReadableConfig? readableConfig = Java.Lang.Object.GetObject<IReadableConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption p = Java.Lang.Object.GetObject<ConfigOption>(native_id, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_valueIfMissing, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(readableConfig.RetrieveOption(p, p2));
	}

	[Register("retrieveOption", "(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)Ljava/lang/Object;", "GetRetrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_Handler:AndroidX.Camera.Core.Impl.IReadableConfig, Xamarin.AndroidX.Camera.Core")]
	[JavaTypeParameters(new string[] { "ValueT" })]
	unsafe Java.Lang.Object? IConfig.RetrieveOption(ConfigOption id, Java.Lang.Object? valueIfMissing)
	{
		nint num = JNIEnv.ToLocalJniHandle(valueIfMissing);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("retrieveOption.(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(id);
			GC.KeepAlive(valueIfMissing);
		}
	}

	private static Delegate GetRetrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_Handler()
	{
		if ((object)cb_retrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_ == null)
		{
			cb_retrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_RetrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_));
		}
		return cb_retrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_;
	}

	private static nint n_RetrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_(nint jnienv, nint native__this, nint native_id, nint native_priority)
	{
		IReadableConfig? readableConfig = Java.Lang.Object.GetObject<IReadableConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption p = Java.Lang.Object.GetObject<ConfigOption>(native_id, JniHandleOwnership.DoNotTransfer);
		ConfigOptionPriority p2 = Java.Lang.Object.GetObject<ConfigOptionPriority>(native_priority, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(readableConfig.RetrieveOptionWithPriority(p, p2));
	}

	[Register("retrieveOptionWithPriority", "(Landroidx/camera/core/impl/Config$Option;Landroidx/camera/core/impl/Config$OptionPriority;)Ljava/lang/Object;", "GetRetrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_Handler:AndroidX.Camera.Core.Impl.IReadableConfig, Xamarin.AndroidX.Camera.Core")]
	[JavaTypeParameters(new string[] { "ValueT" })]
	unsafe Java.Lang.Object? IConfig.RetrieveOptionWithPriority(ConfigOption id, ConfigOptionPriority priority)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(priority?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("retrieveOptionWithPriority.(Landroidx/camera/core/impl/Config$Option;Landroidx/camera/core/impl/Config$OptionPriority;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(id);
			GC.KeepAlive(priority);
		}
	}
}
