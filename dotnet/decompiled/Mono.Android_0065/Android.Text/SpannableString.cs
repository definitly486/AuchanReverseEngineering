using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/SpannableString", DoNotGenerateAcw = true)]
public class SpannableString : SpannableStringInternal, IGetChars, ICharSequence, IEnumerable<char>, IEnumerable, IJavaObject, IDisposable, IJavaPeerable, ISpannable, ISpanned
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/SpannableString", typeof(SpannableString));

	private static Delegate? cb_equals_Equals_Ljava_lang_Object__Z;

	private static Delegate? cb_getSpanEnd_GetSpanEnd_Ljava_lang_Object__I;

	private static Delegate? cb_getSpanFlags_GetSpanFlags_Ljava_lang_Object__I;

	private static Delegate? cb_getSpans_GetSpans_IILjava_lang_Class__arrayLjava_lang_Object_;

	private static Delegate? cb_getSpanStart_GetSpanStart_Ljava_lang_Object__I;

	private static Delegate? cb_hashCode_GetHashCode_I;

	private static Delegate? cb_nextSpanTransition_NextSpanTransition_IILjava_lang_Class__I;

	private static Delegate? cb_removeSpan_RemoveSpan_Ljava_lang_Object__V;

	private static Delegate? cb_setSpan_SetSpan_Ljava_lang_Object_III_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected SpannableString(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe SpannableString(string? source)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = CharSequence.ToLocalJniHandle(source);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/CharSequence;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(source);
		}
	}

	public unsafe sealed override char CharAt(int i)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(i);
		return _members.InstanceMethods.InvokeNonvirtualCharMethod("charAt.(I)C", this, ptr);
	}

	private static Delegate GetEquals_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_B(n_Equals_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Equals_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_o)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SpannableString? spannableString = Java.Lang.Object.GetObject<SpannableString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_o, JniHandleOwnership.DoNotTransfer);
			return spannableString.Equals(obj) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe override bool Equals(Java.Lang.Object? o)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	public unsafe sealed override void GetChars(int start, int end, char[]? dest, int off)
	{
		nint num = JNIEnv.NewArray(dest);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(end);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(off);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("getChars.(II[CI)V", this, ptr);
		}
		finally
		{
			if (dest != null)
			{
				JNIEnv.CopyArray(num, dest);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(dest);
		}
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
			SpannableString? spannableString = Java.Lang.Object.GetObject<SpannableString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			return spannableString.GetSpanEnd(what);
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

	public unsafe override int GetSpanEnd(Java.Lang.Object? what)
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
			SpannableString? spannableString = Java.Lang.Object.GetObject<SpannableString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			return (int)spannableString.GetSpanFlags(what);
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

	public unsafe override SpanTypes GetSpanFlags(Java.Lang.Object? what)
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
			SpannableString? spannableString = Java.Lang.Object.GetObject<SpannableString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class kind = Java.Lang.Object.GetObject<Class>(native_kind, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(spannableString.GetSpans(queryStart, queryEnd, kind));
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
	public unsafe override Java.Lang.Object[]? GetSpans(int queryStart, int queryEnd, Class? kind)
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
			SpannableString? spannableString = Java.Lang.Object.GetObject<SpannableString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			return spannableString.GetSpanStart(what);
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

	public unsafe override int GetSpanStart(Java.Lang.Object? what)
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

	private static Delegate GetGetHashCodeHandler()
	{
		return new _JniMarshal_PP_I(n_GetHashCode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHashCode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SpannableString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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

	public unsafe override int GetHashCode()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("hashCode.()I", this, null);
	}

	public unsafe sealed override int Length()
	{
		return _members.InstanceMethods.InvokeNonvirtualInt32Method("length.()I", this, null);
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
			SpannableString? spannableString = Java.Lang.Object.GetObject<SpannableString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class kind = Java.Lang.Object.GetObject<Class>(native_kind, JniHandleOwnership.DoNotTransfer);
			return spannableString.NextSpanTransition(start, limit, kind);
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

	public unsafe override int NextSpanTransition(int start, int limit, Class? kind)
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

	private static Delegate GetRemoveSpan_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_V(n_RemoveSpan_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveSpan_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_what)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SpannableString? spannableString = Java.Lang.Object.GetObject<SpannableString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			spannableString.RemoveSpan(what);
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

	public unsafe virtual void RemoveSpan(Java.Lang.Object? what)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(what?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeSpan.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(what);
		}
	}

	private static Delegate GetSetSpan_Ljava_lang_Object_IIIHandler()
	{
		return new _JniMarshal_PPLIII_V(n_SetSpan_Ljava_lang_Object_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSpan_Ljava_lang_Object_III(nint jnienv, nint native__this, nint native_what, int start, int end, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SpannableString? spannableString = Java.Lang.Object.GetObject<SpannableString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			spannableString.SetSpan(what, start, end, (SpanTypes)native_flags);
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

	public unsafe virtual void SetSpan(Java.Lang.Object? what, int start, int end, SpanTypes flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(what?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(end);
			ptr[3] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSpan.(Ljava/lang/Object;III)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(what);
		}
	}

	public unsafe ICharSequence? SubSequenceFormatted(int start, int end)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(end);
		return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("subSequence.(II)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe sealed override string? ToString()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe static SpannableString? ValueOf(ICharSequence? source)
	{
		nint num = CharSequence.ToLocalJniHandle(source);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<SpannableString>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/CharSequence;)Landroid/text/SpannableString;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(source);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerator<char> GetEnumerator()
	{
		for (int i = 0; i < Length(); i++)
		{
			yield return CharAt(i);
		}
	}

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
