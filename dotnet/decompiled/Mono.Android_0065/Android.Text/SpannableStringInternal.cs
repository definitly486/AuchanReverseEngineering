using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/SpannableStringInternal", DoNotGenerateAcw = true)]
public abstract class SpannableStringInternal : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/SpannableStringInternal", typeof(SpannableStringInternal));

	private static Delegate? cb_getSpanEnd_GetSpanEnd_Ljava_lang_Object__I;

	private static Delegate? cb_getSpanFlags_GetSpanFlags_Ljava_lang_Object__I;

	private static Delegate? cb_getSpans_GetSpans_IILjava_lang_Class__arrayLjava_lang_Object_;

	private static Delegate? cb_getSpanStart_GetSpanStart_Ljava_lang_Object__I;

	private static Delegate? cb_nextSpanTransition_NextSpanTransition_IILjava_lang_Class__I;

	private static Delegate? cb_charAt_CharAt_I_C;

	private static Delegate? cb_getChars_GetChars_IIarrayCI_V;

	private static Delegate? cb_length_Length_I;

	private static Delegate? cb_toString_ToString_Ljava_lang_String_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected SpannableStringInternal(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetSpanEnd_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_I(n_GetSpanEnd_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSpanEnd_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_what)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SpannableStringInternal? spannableStringInternal = Java.Lang.Object.GetObject<SpannableStringInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			return spannableStringInternal.GetSpanEnd(what);
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

	public unsafe virtual int GetSpanEnd(Java.Lang.Object? what)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(what?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSpanEnd.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(what);
		}
	}

	private static Delegate GetGetSpanFlags_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_I(n_GetSpanFlags_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSpanFlags_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_what)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SpannableStringInternal? spannableStringInternal = Java.Lang.Object.GetObject<SpannableStringInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			return (int)spannableStringInternal.GetSpanFlags(what);
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

	public unsafe virtual SpanTypes GetSpanFlags(Java.Lang.Object? what)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(what?.Handle ?? IntPtr.Zero);
			return (SpanTypes)_members.InstanceMethods.InvokeVirtualInt32Method("getSpanFlags.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(what);
		}
	}

	private static Delegate GetGetSpans_IILjava_lang_Class_Handler()
	{
		return new _JniMarshal_PPIIL_L(n_GetSpans_IILjava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSpans_IILjava_lang_Class_(nint jnienv, nint native__this, int queryStart, int queryEnd, nint native_kind)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SpannableStringInternal? spannableStringInternal = Java.Lang.Object.GetObject<SpannableStringInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class kind = Java.Lang.Object.GetObject<Class>(native_kind, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(spannableStringInternal.GetSpans(queryStart, queryEnd, kind));
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

	[JavaTypeParameters(new string[] { "T" })]
	public unsafe virtual Java.Lang.Object[]? GetSpans(int queryStart, int queryEnd, Class? kind)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(queryStart);
			ptr[1] = new JniArgumentValue(queryEnd);
			ptr[2] = new JniArgumentValue(kind?.Handle ?? IntPtr.Zero);
			return (Java.Lang.Object[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getSpans.(IILjava/lang/Class;)[Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Object));
		}
		finally
		{
			GC.KeepAlive(kind);
		}
	}

	private static Delegate GetGetSpanStart_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_I(n_GetSpanStart_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSpanStart_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_what)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SpannableStringInternal? spannableStringInternal = Java.Lang.Object.GetObject<SpannableStringInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			return spannableStringInternal.GetSpanStart(what);
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

	public unsafe virtual int GetSpanStart(Java.Lang.Object? what)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(what?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSpanStart.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(what);
		}
	}

	private static Delegate GetNextSpanTransition_IILjava_lang_Class_Handler()
	{
		return new _JniMarshal_PPIIL_I(n_NextSpanTransition_IILjava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_NextSpanTransition_IILjava_lang_Class_(nint jnienv, nint native__this, int start, int limit, nint native_kind)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SpannableStringInternal? spannableStringInternal = Java.Lang.Object.GetObject<SpannableStringInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class kind = Java.Lang.Object.GetObject<Class>(native_kind, JniHandleOwnership.DoNotTransfer);
			return spannableStringInternal.NextSpanTransition(start, limit, kind);
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

	public unsafe virtual int NextSpanTransition(int start, int limit, Class? kind)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(limit);
			ptr[2] = new JniArgumentValue(kind?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("nextSpanTransition.(IILjava/lang/Class;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(kind);
		}
	}

	private static Delegate GetCharAt_IHandler()
	{
		return new _JniMarshal_PPI_s(n_CharAt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static ushort n_CharAt_I(nint jnienv, nint native__this, int i)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SpannableStringInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CharAt(i);
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

	public abstract char CharAt(int i);

	private static Delegate GetGetChars_IIarrayCIHandler()
	{
		return new _JniMarshal_PPIILI_V(n_GetChars_IIarrayCI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetChars_IIarrayCI(nint jnienv, nint native__this, int start, int end, nint native_dest, int off)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SpannableStringInternal? spannableStringInternal = Java.Lang.Object.GetObject<SpannableStringInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char[] array = (char[])JNIEnv.GetArray(native_dest, JniHandleOwnership.DoNotTransfer, typeof(char));
			spannableStringInternal.GetChars(start, end, array, off);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_dest);
			}
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

	public abstract void GetChars(int start, int end, char[]? dest, int off);

	private static Delegate GetLengthHandler()
	{
		return new _JniMarshal_PP_I(n_Length);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Length(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SpannableStringInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Length();
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

	public abstract int Length();

	private static Delegate GetToStringHandler()
	{
		return new _JniMarshal_PP_L(n_ToString);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToString(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SpannableStringInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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

	public new abstract string? ToString();
}
