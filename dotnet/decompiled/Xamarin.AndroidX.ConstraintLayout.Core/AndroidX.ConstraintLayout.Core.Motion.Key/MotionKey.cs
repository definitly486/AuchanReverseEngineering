using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.ConstraintLayout.Core.Motion.Utils;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace AndroidX.ConstraintLayout.Core.Motion.Key;

[Register("androidx/constraintlayout/core/motion/key/MotionKey", DoNotGenerateAcw = true)]
public abstract class MotionKey : Java.Lang.Object, ITypedValues, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/key/MotionKey", typeof(MotionKey));

	private static Delegate? cb_getFramePosition_GetFramePosition_I;

	private static Delegate? cb_setFramePosition_SetFramePosition_I_V;

	private static Delegate? cb_addValues_AddValues_Ljava_util_HashMap__V;

	private static Delegate? cb_clone_Clone_Landroidx_constraintlayout_core_motion_key_MotionKey_;

	private static Delegate? cb_copy_Copy_Landroidx_constraintlayout_core_motion_key_MotionKey__Landroidx_constraintlayout_core_motion_key_MotionKey_;

	private static Delegate? cb_getAttributeNames_GetAttributeNames_Ljava_util_HashSet__V;

	private static Delegate? cb_setCustomAttribute_SetCustomAttribute_Ljava_lang_String_IZ_V;

	private static Delegate? cb_setCustomAttribute_SetCustomAttribute_Ljava_lang_String_IF_V;

	private static Delegate? cb_setCustomAttribute_SetCustomAttribute_Ljava_lang_String_II_V;

	private static Delegate? cb_setCustomAttribute_SetCustomAttribute_Ljava_lang_String_ILjava_lang_String__V;

	private static Delegate? cb_setInterpolation_SetInterpolation_Ljava_util_HashMap__V;

	private static Delegate? cb_setValue_SetValue_IZ_Z;

	private static Delegate? cb_setValue_SetValue_IF_Z;

	private static Delegate? cb_setValue_SetValue_II_Z;

	private static Delegate? cb_setValue_SetValue_ILjava_lang_String__Z;

	private static Delegate? cb_setViewId_SetViewId_I_Landroidx_constraintlayout_core_motion_key_MotionKey_;

	private static Delegate? cb_getId_GetId_Ljava_lang_String__I;

	[Register("mCustom")]
	public IDictionary? MCustom
	{
		get
		{
			return JavaDictionary.FromJniHandle(_members.InstanceFields.GetObjectValue("mCustom.Ljava/util/HashMap;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JavaDictionary.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mCustom.Ljava/util/HashMap;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mFramePosition")]
	public int MFramePosition
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mFramePosition.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mFramePosition.I", this, value);
		}
	}

	[Register("mType")]
	public int MType
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

	protected MotionKey(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe MotionKey()
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
			return Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FramePosition;
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
			Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FramePosition = pos;
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
			MotionKey? motionKey = Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDictionary<string, SplineSet> p = JavaDictionary<string, SplineSet>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
			motionKey.AddValues(p);
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
	public abstract void AddValues(IDictionary<string, SplineSet>? p0);

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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
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

	[Register("clone", "()Landroidx/constraintlayout/core/motion/key/MotionKey;", "GetCloneHandler")]
	public new abstract MotionKey? Clone();

	private static Delegate GetCopy_Landroidx_constraintlayout_core_motion_key_MotionKey_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Copy_Landroidx_constraintlayout_core_motion_key_MotionKey_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Copy_Landroidx_constraintlayout_core_motion_key_MotionKey_(nint jnienv, nint native__this, nint native_src)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionKey? motionKey = Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionKey src = Java.Lang.Object.GetObject<MotionKey>(native_src, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(motionKey.Copy(src));
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

	[Register("copy", "(Landroidx/constraintlayout/core/motion/key/MotionKey;)Landroidx/constraintlayout/core/motion/key/MotionKey;", "GetCopy_Landroidx_constraintlayout_core_motion_key_MotionKey_Handler")]
	public unsafe virtual MotionKey? Copy(MotionKey? src)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<MotionKey>(_members.InstanceMethods.InvokeVirtualObjectMethod("copy.(Landroidx/constraintlayout/core/motion/key/MotionKey;)Landroidx/constraintlayout/core/motion/key/MotionKey;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(src);
		}
	}

	private static Delegate GetGetAttributeNames_Ljava_util_HashSet_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_GetAttributeNames_Ljava_util_HashSet_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetAttributeNames_Ljava_util_HashSet_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionKey? motionKey = Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			HashSet p = Java.Lang.Object.GetObject<HashSet>(native_p0, JniHandleOwnership.DoNotTransfer);
			motionKey.GetAttributeNames(p);
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

	[Register("getAttributeNames", "(Ljava/util/HashSet;)V", "GetGetAttributeNames_Ljava_util_HashSet_Handler")]
	public abstract void GetAttributeNames(HashSet? p0);

	private static Delegate GetSetCustomAttribute_Ljava_lang_String_IZHandler()
	{
		return new global::_JniMarshal_PPLIB_V(n_SetCustomAttribute_Ljava_lang_String_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomAttribute_Ljava_lang_String_IZ(nint jnienv, nint native__this, nint native_name, int type, sbyte native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionKey? motionKey = Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			bool value = native_value != 0;
			motionKey.SetCustomAttribute(name, type, value);
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

	[Register("setCustomAttribute", "(Ljava/lang/String;IZ)V", "GetSetCustomAttribute_Ljava_lang_String_IZHandler")]
	public unsafe virtual void SetCustomAttribute(string? name, int type, bool value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCustomAttribute.(Ljava/lang/String;IZ)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetCustomAttribute_Ljava_lang_String_IFHandler()
	{
		return new _JniMarshal_PPLIF_V(n_SetCustomAttribute_Ljava_lang_String_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomAttribute_Ljava_lang_String_IF(nint jnienv, nint native__this, nint native_name, int type, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionKey? motionKey = Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			motionKey.SetCustomAttribute(name, type, value);
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

	[Register("setCustomAttribute", "(Ljava/lang/String;IF)V", "GetSetCustomAttribute_Ljava_lang_String_IFHandler")]
	public unsafe virtual void SetCustomAttribute(string? name, int type, float value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCustomAttribute.(Ljava/lang/String;IF)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetCustomAttribute_Ljava_lang_String_IIHandler()
	{
		return new global::_JniMarshal_PPLII_V(n_SetCustomAttribute_Ljava_lang_String_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomAttribute_Ljava_lang_String_II(nint jnienv, nint native__this, nint native_name, int type, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionKey? motionKey = Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			motionKey.SetCustomAttribute(name, type, value);
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

	[Register("setCustomAttribute", "(Ljava/lang/String;II)V", "GetSetCustomAttribute_Ljava_lang_String_IIHandler")]
	public unsafe virtual void SetCustomAttribute(string? name, int type, int value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCustomAttribute.(Ljava/lang/String;II)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetCustomAttribute_Ljava_lang_String_ILjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLIL_V(n_SetCustomAttribute_Ljava_lang_String_ILjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomAttribute_Ljava_lang_String_ILjava_lang_String_(nint jnienv, nint native__this, nint native_name, int type, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionKey? motionKey = Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			motionKey.SetCustomAttribute(name, type, value);
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

	[Register("setCustomAttribute", "(Ljava/lang/String;ILjava/lang/String;)V", "GetSetCustomAttribute_Ljava_lang_String_ILjava_lang_String_Handler")]
	public unsafe virtual void SetCustomAttribute(string? name, int type, string? value)
	{
		nint num = JNIEnv.NewString(name);
		nint num2 = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCustomAttribute.(Ljava/lang/String;ILjava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
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
			MotionKey? motionKey = Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDictionary<string, Integer> interpolation = JavaDictionary<string, Integer>.FromJniHandle(native_interpolation, JniHandleOwnership.DoNotTransfer);
			motionKey.SetInterpolation(interpolation);
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

	private static Delegate GetSetValue_IZHandler()
	{
		return new global::_JniMarshal_PPIB_B(n_SetValue_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_IZ(nint jnienv, nint native__this, int type, sbyte native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionKey? motionKey = Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool value = native_value != 0;
			return motionKey.SetValue(type, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValue", "(IZ)Z", "GetSetValue_IZHandler")]
	public unsafe virtual bool SetValue(int type, bool value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(type);
		ptr[1] = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValue.(IZ)Z", this, ptr);
	}

	private static Delegate GetSetValue_IFHandler()
	{
		return new _JniMarshal_PPIF_B(n_SetValue_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_IF(nint jnienv, nint native__this, int type, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetValue(type, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValue", "(IF)Z", "GetSetValue_IFHandler")]
	public unsafe virtual bool SetValue(int type, float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(type);
		ptr[1] = new JniArgumentValue(value);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValue.(IF)Z", this, ptr);
	}

	private static Delegate GetSetValue_IIHandler()
	{
		return new global::_JniMarshal_PPII_B(n_SetValue_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_II(nint jnienv, nint native__this, int type, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetValue(type, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValue", "(II)Z", "GetSetValue_IIHandler")]
	public unsafe virtual bool SetValue(int type, int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(type);
		ptr[1] = new JniArgumentValue(value);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValue.(II)Z", this, ptr);
	}

	private static Delegate GetSetValue_ILjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPIL_B(n_SetValue_ILjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_ILjava_lang_String_(nint jnienv, nint native__this, int type, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionKey? motionKey = Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return motionKey.SetValue(type, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValue", "(ILjava/lang/String;)Z", "GetSetValue_ILjava_lang_String_Handler")]
	public unsafe virtual bool SetValue(int type, string? value)
	{
		nint num = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(type);
			ptr[1] = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValue.(ILjava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetViewId(id));
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

	[Register("setViewId", "(I)Landroidx/constraintlayout/core/motion/key/MotionKey;", "GetSetViewId_IHandler")]
	public unsafe virtual MotionKey? SetViewId(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<MotionKey>(_members.InstanceMethods.InvokeVirtualObjectMethod("setViewId.(I)Landroidx/constraintlayout/core/motion/key/MotionKey;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetId_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetId_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetId_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionKey? motionKey = Java.Lang.Object.GetObject<MotionKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return motionKey.GetId(p);
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

	[Register("getId", "(Ljava/lang/String;)I", "GetGetId_Ljava_lang_String_Handler")]
	public abstract int GetId(string? p0);

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
