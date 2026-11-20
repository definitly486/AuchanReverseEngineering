using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.ConstraintLayout.Motion.Utils;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Motion.Widget;

[Register("androidx/constraintlayout/motion/widget/Key", DoNotGenerateAcw = true)]
public abstract class Key : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/Key", typeof(Key));

	private static Delegate? cb_getFramePosition_GetFramePosition_I;

	private static Delegate? cb_setFramePosition_SetFramePosition_I_V;

	private static Delegate? cb_addValues_AddValues_Ljava_util_HashMap__V;

	private static Delegate? cb_clone_Clone_Landroidx_constraintlayout_motion_widget_Key_;

	private static Delegate? cb_copy_Copy_Landroidx_constraintlayout_motion_widget_Key__Landroidx_constraintlayout_motion_widget_Key_;

	private static Delegate? cb_setInterpolation_SetInterpolation_Ljava_util_HashMap__V;

	private static Delegate? cb_setValue_SetValue_Ljava_lang_String_Ljava_lang_Object__V;

	private static Delegate? cb_setViewId_SetViewId_I_Landroidx_constraintlayout_motion_widget_Key_;

	[Register("mType")]
	protected int MType
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mType.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mType.I", this, value);
		}
	}

	[Register("UNSET")]
	public static int Unset
	{
		get
		{
			return _members.StaticFields.GetInt32Value("UNSET.I");
		}
		set
		{
			_members.StaticFields.SetValue("UNSET.I", value);
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

	public unsafe virtual int FramePosition
	{
		[Register("getFramePosition", "()I", "GetGetFramePositionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getFramePosition.()I", this, null);
		}
		[Register("setFramePosition", "(I)V", "GetSetFramePosition_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFramePosition.(I)V", this, ptr);
		}
	}

	protected Key(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Key()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetFramePositionHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetFramePosition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetFramePosition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Key>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FramePosition;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetFramePosition_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetFramePosition_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFramePosition_I(nint jnienv, nint native__this, int pos)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Key>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FramePosition = pos;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetAddValues_Ljava_util_HashMap_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddValues_Ljava_util_HashMap_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddValues_Ljava_util_HashMap_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Key? key = Java.Lang.Object.GetObject<Key>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDictionary<string, ViewSpline> p = JavaDictionary<string, ViewSpline>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
			key.AddValues(p);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addValues", "(Ljava/util/HashMap;)V", "GetAddValues_Ljava_util_HashMap_Handler")]
	public abstract void AddValues(IDictionary<string, ViewSpline>? p0);

	private static Delegate GetCloneHandler()
	{
		return new global::_JniMarshal_PP_L(n_Clone);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Clone(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Key>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("clone", "()Landroidx/constraintlayout/motion/widget/Key;", "GetCloneHandler")]
	public new abstract Key? Clone();

	private static Delegate GetCopy_Landroidx_constraintlayout_motion_widget_Key_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Copy_Landroidx_constraintlayout_motion_widget_Key_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Copy_Landroidx_constraintlayout_motion_widget_Key_(nint jnienv, nint native__this, nint native_src)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Key? key = Java.Lang.Object.GetObject<Key>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Key src = Java.Lang.Object.GetObject<Key>(native_src, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(key.Copy(src));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("copy", "(Landroidx/constraintlayout/motion/widget/Key;)Landroidx/constraintlayout/motion/widget/Key;", "GetCopy_Landroidx_constraintlayout_motion_widget_Key_Handler")]
	public unsafe virtual Key? Copy(Key? src)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Key>(_members.InstanceMethods.InvokeVirtualObjectMethod("copy.(Landroidx/constraintlayout/motion/widget/Key;)Landroidx/constraintlayout/motion/widget/Key;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(src);
		}
	}

	private static Delegate GetSetInterpolation_Ljava_util_HashMap_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetInterpolation_Ljava_util_HashMap_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInterpolation_Ljava_util_HashMap_(nint jnienv, nint native__this, nint native_interpolation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Key? key = Java.Lang.Object.GetObject<Key>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDictionary<string, Integer> interpolation = JavaDictionary<string, Integer>.FromJniHandle(native_interpolation, JniHandleOwnership.DoNotTransfer);
			key.SetInterpolation(interpolation);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setInterpolation", "(Ljava/util/HashMap;)V", "GetSetInterpolation_Ljava_util_HashMap_Handler")]
	public unsafe virtual void SetInterpolation(IDictionary<string, Integer>? interpolation)
	{
		nint num = JavaDictionary<string, Integer>.ToLocalJniHandle(interpolation);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInterpolation.(Ljava/util/HashMap;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(interpolation);
		}
	}

	private static Delegate GetSetValue_Ljava_lang_String_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetValue_Ljava_lang_String_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetValue_Ljava_lang_String_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Key? key = Java.Lang.Object.GetObject<Key>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
			key.SetValue(p, p2);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setValue", "(Ljava/lang/String;Ljava/lang/Object;)V", "GetSetValue_Ljava_lang_String_Ljava_lang_Object_Handler")]
	public abstract void SetValue(string? p0, Java.Lang.Object? p1);

	private static Delegate GetSetViewId_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetViewId_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetViewId_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Key>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetViewId(id));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setViewId", "(I)Landroidx/constraintlayout/motion/widget/Key;", "GetSetViewId_IHandler")]
	public unsafe virtual Key? SetViewId(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<Key>(_members.InstanceMethods.InvokeVirtualObjectMethod("setViewId.(I)Landroidx/constraintlayout/motion/widget/Key;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
