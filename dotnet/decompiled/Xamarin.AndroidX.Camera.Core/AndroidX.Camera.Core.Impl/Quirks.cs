using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/Quirks", DoNotGenerateAcw = true)]
public class Quirks : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/Quirks", typeof(Quirks));

	private static Delegate? cb_addQuirkForTesting_Landroidx_camera_core_impl_Quirk_;

	private static Delegate? cb_contains_Ljava_lang_Class_;

	private static Delegate? cb_get_Ljava_lang_Class_;

	private static Delegate? cb_getAll_Ljava_lang_Class_;

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

	protected Quirks(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/util/List;)V", "")]
	public unsafe Quirks(IList<IQuirk> quirks)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JavaList<IQuirk>.ToLocalJniHandle(quirks);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/List;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(quirks);
		}
	}

	private static Delegate GetAddQuirkForTesting_Landroidx_camera_core_impl_Quirk_Handler()
	{
		if ((object)cb_addQuirkForTesting_Landroidx_camera_core_impl_Quirk_ == null)
		{
			cb_addQuirkForTesting_Landroidx_camera_core_impl_Quirk_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddQuirkForTesting_Landroidx_camera_core_impl_Quirk_));
		}
		return cb_addQuirkForTesting_Landroidx_camera_core_impl_Quirk_;
	}

	private static void n_AddQuirkForTesting_Landroidx_camera_core_impl_Quirk_(nint jnienv, nint native__this, nint native_quirk)
	{
		Quirks? quirks = Java.Lang.Object.GetObject<Quirks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IQuirk quirk = Java.Lang.Object.GetObject<IQuirk>(native_quirk, JniHandleOwnership.DoNotTransfer);
		quirks.AddQuirkForTesting(quirk);
	}

	[Register("addQuirkForTesting", "(Landroidx/camera/core/impl/Quirk;)V", "GetAddQuirkForTesting_Landroidx_camera_core_impl_Quirk_Handler")]
	public unsafe virtual void AddQuirkForTesting(IQuirk quirk)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((quirk == null) ? IntPtr.Zero : ((Java.Lang.Object)quirk).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addQuirkForTesting.(Landroidx/camera/core/impl/Quirk;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(quirk);
		}
	}

	private static Delegate GetContains_Ljava_lang_Class_Handler()
	{
		if ((object)cb_contains_Ljava_lang_Class_ == null)
		{
			cb_contains_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Contains_Ljava_lang_Class_));
		}
		return cb_contains_Ljava_lang_Class_;
	}

	private static bool n_Contains_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_quirkClass)
	{
		Quirks? quirks = Java.Lang.Object.GetObject<Quirks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Class quirkClass = Java.Lang.Object.GetObject<Class>(native_quirkClass, JniHandleOwnership.DoNotTransfer);
		return quirks.Contains(quirkClass);
	}

	[Register("contains", "(Ljava/lang/Class;)Z", "GetContains_Ljava_lang_Class_Handler")]
	public unsafe virtual bool Contains(Class quirkClass)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(quirkClass?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("contains.(Ljava/lang/Class;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(quirkClass);
		}
	}

	private static Delegate GetGet_Ljava_lang_Class_Handler()
	{
		if ((object)cb_get_Ljava_lang_Class_ == null)
		{
			cb_get_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Get_Ljava_lang_Class_));
		}
		return cb_get_Ljava_lang_Class_;
	}

	private static nint n_Get_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_quirkClass)
	{
		Quirks? quirks = Java.Lang.Object.GetObject<Quirks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Class quirkClass = Java.Lang.Object.GetObject<Class>(native_quirkClass, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(quirks.Get(quirkClass));
	}

	[Register("get", "(Ljava/lang/Class;)Landroidx/camera/core/impl/Quirk;", "GetGet_Ljava_lang_Class_Handler")]
	[JavaTypeParameters(new string[] { "T extends androidx.camera.core.impl.Quirk" })]
	public unsafe virtual Java.Lang.Object? Get(Class quirkClass)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(quirkClass?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Ljava/lang/Class;)Landroidx/camera/core/impl/Quirk;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(quirkClass);
		}
	}

	private static Delegate GetGetAll_Ljava_lang_Class_Handler()
	{
		if ((object)cb_getAll_Ljava_lang_Class_ == null)
		{
			cb_getAll_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetAll_Ljava_lang_Class_));
		}
		return cb_getAll_Ljava_lang_Class_;
	}

	private static nint n_GetAll_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_quirkClass)
	{
		Quirks? quirks = Java.Lang.Object.GetObject<Quirks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Class quirkClass = Java.Lang.Object.GetObject<Class>(native_quirkClass, JniHandleOwnership.DoNotTransfer);
		return JavaList.ToLocalJniHandle(quirks.GetAll(quirkClass));
	}

	[Register("getAll", "(Ljava/lang/Class;)Ljava/util/List;", "GetGetAll_Ljava_lang_Class_Handler")]
	[JavaTypeParameters(new string[] { "T extends androidx.camera.core.impl.Quirk" })]
	public unsafe virtual IList GetAll(Class quirkClass)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(quirkClass?.Handle ?? IntPtr.Zero);
			return JavaList.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getAll.(Ljava/lang/Class;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(quirkClass);
		}
	}

	[Register("toString", "(Landroidx/camera/core/impl/Quirks;)Ljava/lang/String;", "")]
	public unsafe static string ToString(Quirks quirks)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(quirks?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("toString.(Landroidx/camera/core/impl/Quirks;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(quirks);
		}
	}
}
