using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/OptionsBundle", DoNotGenerateAcw = true)]
public class OptionsBundle : Java.Lang.Object, IConfig, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/OptionsBundle", typeof(OptionsBundle));

	private static Delegate? cb_containsOption_Landroidx_camera_core_impl_Config_Option_;

	private static Delegate? cb_findOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_;

	private static Delegate? cb_getOptionPriority_Landroidx_camera_core_impl_Config_Option_;

	private static Delegate? cb_getPriorities_Landroidx_camera_core_impl_Config_Option_;

	private static Delegate? cb_listOptions;

	private static Delegate? cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_;

	private static Delegate? cb_retrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_;

	private static Delegate? cb_retrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_;

	[Register("ID_COMPARE")]
	protected static IComparator? IdCompare => Java.Lang.Object.GetObject<IComparator>(_members.StaticFields.GetObjectValue("ID_COMPARE.Ljava/util/Comparator;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("mOptions")]
	protected TreeMap? MOptions
	{
		get
		{
			return Java.Lang.Object.GetObject<TreeMap>(_members.InstanceFields.GetObjectValue("mOptions.Ljava/util/TreeMap;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mOptions.Ljava/util/TreeMap;", this, new JniObjectReference(num));
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

	protected OptionsBundle(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
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
		OptionsBundle? optionsBundle = Java.Lang.Object.GetObject<OptionsBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption id = Java.Lang.Object.GetObject<ConfigOption>(native_id, JniHandleOwnership.DoNotTransfer);
		return optionsBundle.ContainsOption(id);
	}

	[Register("containsOption", "(Landroidx/camera/core/impl/Config$Option;)Z", "GetContainsOption_Landroidx_camera_core_impl_Config_Option_Handler")]
	public unsafe virtual bool ContainsOption(ConfigOption id)
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

	[Register("emptyBundle", "()Landroidx/camera/core/impl/OptionsBundle;", "")]
	public unsafe static OptionsBundle EmptyBundle()
	{
		return Java.Lang.Object.GetObject<OptionsBundle>(_members.StaticMethods.InvokeObjectMethod("emptyBundle.()Landroidx/camera/core/impl/OptionsBundle;", null).Handle, JniHandleOwnership.TransferLocalRef);
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
		OptionsBundle? optionsBundle = Java.Lang.Object.GetObject<OptionsBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string idSearchString = JNIEnv.GetString(native_idSearchString, JniHandleOwnership.DoNotTransfer);
		IConfigOptionMatcher matcher = Java.Lang.Object.GetObject<IConfigOptionMatcher>(native_matcher, JniHandleOwnership.DoNotTransfer);
		optionsBundle.FindOptions(idSearchString, matcher);
	}

	[Register("findOptions", "(Ljava/lang/String;Landroidx/camera/core/impl/Config$OptionMatcher;)V", "GetFindOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_Handler")]
	public unsafe virtual void FindOptions(string idSearchString, IConfigOptionMatcher matcher)
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

	[Register("from", "(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/OptionsBundle;", "")]
	public unsafe static OptionsBundle From(IConfig otherConfig)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((otherConfig == null) ? IntPtr.Zero : ((Java.Lang.Object)otherConfig).Handle);
			return Java.Lang.Object.GetObject<OptionsBundle>(_members.StaticMethods.InvokeObjectMethod("from.(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/OptionsBundle;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(otherConfig);
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
		OptionsBundle? optionsBundle = Java.Lang.Object.GetObject<OptionsBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption opt = Java.Lang.Object.GetObject<ConfigOption>(native_opt, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(optionsBundle.GetOptionPriority(opt));
	}

	[Register("getOptionPriority", "(Landroidx/camera/core/impl/Config$Option;)Landroidx/camera/core/impl/Config$OptionPriority;", "GetGetOptionPriority_Landroidx_camera_core_impl_Config_Option_Handler")]
	public unsafe virtual ConfigOptionPriority GetOptionPriority(ConfigOption opt)
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

	private static nint n_GetPriorities_Landroidx_camera_core_impl_Config_Option_(nint jnienv, nint native__this, nint native_opt)
	{
		OptionsBundle? optionsBundle = Java.Lang.Object.GetObject<OptionsBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption opt = Java.Lang.Object.GetObject<ConfigOption>(native_opt, JniHandleOwnership.DoNotTransfer);
		return JavaSet<ConfigOptionPriority>.ToLocalJniHandle(optionsBundle.GetPriorities(opt));
	}

	[Register("getPriorities", "(Landroidx/camera/core/impl/Config$Option;)Ljava/util/Set;", "GetGetPriorities_Landroidx_camera_core_impl_Config_Option_Handler")]
	public unsafe virtual ICollection<ConfigOptionPriority> GetPriorities(ConfigOption opt)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(opt?.Handle ?? IntPtr.Zero);
			return JavaSet<ConfigOptionPriority>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getPriorities.(Landroidx/camera/core/impl/Config$Option;)Ljava/util/Set;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(opt);
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
		return JavaSet<ConfigOption>.ToLocalJniHandle(Java.Lang.Object.GetObject<OptionsBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ListOptions());
	}

	[Register("listOptions", "()Ljava/util/Set;", "GetListOptionsHandler")]
	public unsafe virtual ICollection<ConfigOption> ListOptions()
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
		OptionsBundle? optionsBundle = Java.Lang.Object.GetObject<OptionsBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption id = Java.Lang.Object.GetObject<ConfigOption>(native_id, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(optionsBundle.RetrieveOption(id));
	}

	[Register("retrieveOption", "(Landroidx/camera/core/impl/Config$Option;)Ljava/lang/Object;", "GetRetrieveOption_Landroidx_camera_core_impl_Config_Option_Handler")]
	[JavaTypeParameters(new string[] { "ValueT" })]
	public unsafe virtual Java.Lang.Object? RetrieveOption(ConfigOption id)
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
		OptionsBundle? optionsBundle = Java.Lang.Object.GetObject<OptionsBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption id = Java.Lang.Object.GetObject<ConfigOption>(native_id, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object valueIfMissing = Java.Lang.Object.GetObject<Java.Lang.Object>(native_valueIfMissing, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(optionsBundle.RetrieveOption(id, valueIfMissing));
	}

	[Register("retrieveOption", "(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)Ljava/lang/Object;", "GetRetrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_Handler")]
	[JavaTypeParameters(new string[] { "ValueT" })]
	public unsafe virtual Java.Lang.Object? RetrieveOption(ConfigOption id, Java.Lang.Object? valueIfMissing)
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
		OptionsBundle? optionsBundle = Java.Lang.Object.GetObject<OptionsBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption id = Java.Lang.Object.GetObject<ConfigOption>(native_id, JniHandleOwnership.DoNotTransfer);
		ConfigOptionPriority priority = Java.Lang.Object.GetObject<ConfigOptionPriority>(native_priority, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(optionsBundle.RetrieveOptionWithPriority(id, priority));
	}

	[Register("retrieveOptionWithPriority", "(Landroidx/camera/core/impl/Config$Option;Landroidx/camera/core/impl/Config$OptionPriority;)Ljava/lang/Object;", "GetRetrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_Handler")]
	[JavaTypeParameters(new string[] { "ValueT" })]
	public unsafe virtual Java.Lang.Object? RetrieveOptionWithPriority(ConfigOption id, ConfigOptionPriority priority)
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
