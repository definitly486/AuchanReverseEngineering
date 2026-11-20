using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Motion.Utils;

[Register("androidx/constraintlayout/core/motion/utils/TypedBundle", DoNotGenerateAcw = true)]
public class TypedBundle : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/utils/TypedBundle", typeof(TypedBundle));

	private static Delegate? cb_add_Add_IZ_V;

	private static Delegate? cb_add_Add_IF_V;

	private static Delegate? cb_add_Add_II_V;

	private static Delegate? cb_add_Add_ILjava_lang_String__V;

	private static Delegate? cb_addIfNotNull_AddIfNotNull_ILjava_lang_String__V;

	private static Delegate? cb_applyDelta_ApplyDelta_Landroidx_constraintlayout_core_motion_utils_TypedBundle__V;

	private static Delegate? cb_applyDelta_ApplyDelta_Landroidx_constraintlayout_core_motion_utils_TypedValues__V;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_getInteger_GetInteger_I_I;

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

	protected TypedBundle(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe TypedBundle()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetAdd_IZHandler()
	{
		return new global::_JniMarshal_PPIB_V(n_Add_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Add_IZ(nint jnienv, nint native__this, int type, sbyte native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TypedBundle? typedBundle = Java.Lang.Object.GetObject<TypedBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool value = native_value != 0;
			typedBundle.Add(type, value);
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

	[Register("add", "(IZ)V", "GetAdd_IZHandler")]
	public unsafe virtual void Add(int type, bool value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(type);
		ptr[1] = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("add.(IZ)V", this, ptr);
	}

	private static Delegate GetAdd_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_Add_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Add_IF(nint jnienv, nint native__this, int type, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TypedBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Add(type, value);
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

	[Register("add", "(IF)V", "GetAdd_IFHandler")]
	public unsafe virtual void Add(int type, float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(type);
		ptr[1] = new JniArgumentValue(value);
		_members.InstanceMethods.InvokeVirtualVoidMethod("add.(IF)V", this, ptr);
	}

	private static Delegate GetAdd_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_Add_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Add_II(nint jnienv, nint native__this, int type, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TypedBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Add(type, value);
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

	[Register("add", "(II)V", "GetAdd_IIHandler")]
	public unsafe virtual void Add(int type, int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(type);
		ptr[1] = new JniArgumentValue(value);
		_members.InstanceMethods.InvokeVirtualVoidMethod("add.(II)V", this, ptr);
	}

	private static Delegate GetAdd_ILjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_Add_ILjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Add_ILjava_lang_String_(nint jnienv, nint native__this, int type, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TypedBundle? typedBundle = Java.Lang.Object.GetObject<TypedBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			typedBundle.Add(type, value);
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

	[Register("add", "(ILjava/lang/String;)V", "GetAdd_ILjava_lang_String_Handler")]
	public unsafe virtual void Add(int type, string? value)
	{
		nint num = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(type);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("add.(ILjava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetAddIfNotNull_ILjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_AddIfNotNull_ILjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddIfNotNull_ILjava_lang_String_(nint jnienv, nint native__this, int type, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TypedBundle? typedBundle = Java.Lang.Object.GetObject<TypedBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			typedBundle.AddIfNotNull(type, value);
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

	[Register("addIfNotNull", "(ILjava/lang/String;)V", "GetAddIfNotNull_ILjava_lang_String_Handler")]
	public unsafe virtual void AddIfNotNull(int type, string? value)
	{
		nint num = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(type);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addIfNotNull.(ILjava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetApplyDelta_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ApplyDelta_Landroidx_constraintlayout_core_motion_utils_TypedBundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyDelta_Landroidx_constraintlayout_core_motion_utils_TypedBundle_(nint jnienv, nint native__this, nint native_values)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TypedBundle? typedBundle = Java.Lang.Object.GetObject<TypedBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TypedBundle values = Java.Lang.Object.GetObject<TypedBundle>(native_values, JniHandleOwnership.DoNotTransfer);
			typedBundle.ApplyDelta(values);
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

	[Register("applyDelta", "(Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", "GetApplyDelta_Landroidx_constraintlayout_core_motion_utils_TypedBundle_Handler")]
	public unsafe virtual void ApplyDelta(TypedBundle? values)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(values?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyDelta.(Landroidx/constraintlayout/core/motion/utils/TypedBundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(values);
		}
	}

	private static Delegate GetApplyDelta_Landroidx_constraintlayout_core_motion_utils_TypedValues_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ApplyDelta_Landroidx_constraintlayout_core_motion_utils_TypedValues_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyDelta_Landroidx_constraintlayout_core_motion_utils_TypedValues_(nint jnienv, nint native__this, nint native_values)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TypedBundle? typedBundle = Java.Lang.Object.GetObject<TypedBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITypedValues values = Java.Lang.Object.GetObject<ITypedValues>(native_values, JniHandleOwnership.DoNotTransfer);
			typedBundle.ApplyDelta(values);
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

	[Register("applyDelta", "(Landroidx/constraintlayout/core/motion/utils/TypedValues;)V", "GetApplyDelta_Landroidx_constraintlayout_core_motion_utils_TypedValues_Handler")]
	public unsafe virtual void ApplyDelta(ITypedValues? values)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((values == null) ? IntPtr.Zero : ((Java.Lang.Object)values).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyDelta.(Landroidx/constraintlayout/core/motion/utils/TypedValues;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(values);
		}
	}

	private static Delegate GetClearHandler()
	{
		return new global::_JniMarshal_PP_V(n_Clear);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clear(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TypedBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

	[Register("clear", "()V", "GetClearHandler")]
	public unsafe virtual void Clear()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clear.()V", this, null);
	}

	private static Delegate GetGetInteger_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_GetInteger_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInteger_I(nint jnienv, nint native__this, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TypedBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetInteger(type);
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

	[Register("getInteger", "(I)I", "GetGetInteger_IHandler")]
	public unsafe virtual int GetInteger(int type)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(type);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getInteger.(I)I", this, ptr);
	}
}
