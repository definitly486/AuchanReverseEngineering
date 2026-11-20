using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Motion.Utils;

[Register("androidx/constraintlayout/core/motion/utils/KeyCache", DoNotGenerateAcw = true)]
public class KeyCache : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/utils/KeyCache", typeof(KeyCache));

	private static Delegate? cb_getFloatValue_GetFloatValue_Ljava_lang_Object_Ljava_lang_String_I_F;

	private static Delegate? cb_setFloatValue_SetFloatValue_Ljava_lang_Object_Ljava_lang_String_IF_V;

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

	protected KeyCache(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe KeyCache()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetFloatValue_Ljava_lang_Object_Ljava_lang_String_IHandler()
	{
		return new _JniMarshal_PPLLI_F(n_GetFloatValue_Ljava_lang_Object_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetFloatValue_Ljava_lang_Object_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_view, nint native_type, int element)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			KeyCache? keyCache = Java.Lang.Object.GetObject<KeyCache>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			string type = JNIEnv.GetString(native_type, JniHandleOwnership.DoNotTransfer);
			return keyCache.GetFloatValue(view, type, element);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getFloatValue", "(Ljava/lang/Object;Ljava/lang/String;I)F", "GetGetFloatValue_Ljava_lang_Object_Ljava_lang_String_IHandler")]
	public unsafe virtual float GetFloatValue(Java.Lang.Object? view, string? type, int element)
	{
		nint num = JNIEnv.NewString(type);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(element);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getFloatValue.(Ljava/lang/Object;Ljava/lang/String;I)F", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetSetFloatValue_Ljava_lang_Object_Ljava_lang_String_IFHandler()
	{
		return new _JniMarshal_PPLLIF_V(n_SetFloatValue_Ljava_lang_Object_Ljava_lang_String_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFloatValue_Ljava_lang_Object_Ljava_lang_String_IF(nint jnienv, nint native__this, nint native_view, nint native_type, int element, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			KeyCache? keyCache = Java.Lang.Object.GetObject<KeyCache>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			string type = JNIEnv.GetString(native_type, JniHandleOwnership.DoNotTransfer);
			keyCache.SetFloatValue(view, type, element, value);
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

	[Register("setFloatValue", "(Ljava/lang/Object;Ljava/lang/String;IF)V", "GetSetFloatValue_Ljava_lang_Object_Ljava_lang_String_IFHandler")]
	public unsafe virtual void SetFloatValue(Java.Lang.Object? view, string? type, int element, float value)
	{
		nint num = JNIEnv.NewString(type);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(element);
			ptr[3] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFloatValue.(Ljava/lang/Object;Ljava/lang/String;IF)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
		}
	}
}
