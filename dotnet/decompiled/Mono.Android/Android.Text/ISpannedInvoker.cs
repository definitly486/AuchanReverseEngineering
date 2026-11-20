using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/Spanned", DoNotGenerateAcw = true)]
internal class ISpannedInvoker : Java.Lang.Object, ISpanned, ICharSequence, IEnumerable<char>, IEnumerable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_text_Spanned = new XAPeerMembers("android/text/Spanned", typeof(ISpannedInvoker));

	private static readonly JniPeerMembers _members_java_lang_CharSequence = new XAPeerMembers("java/lang/CharSequence", typeof(ISpannedInvoker));

	private static Delegate? cb_getSpanEnd_GetSpanEnd_Ljava_lang_Object__I;

	private static Delegate? cb_getSpanFlags_GetSpanFlags_Ljava_lang_Object__I;

	private static Delegate? cb_getSpans_GetSpans_IILjava_lang_Class__arrayLjava_lang_Object_;

	private static Delegate? cb_getSpanStart_GetSpanStart_Ljava_lang_Object__I;

	private static Delegate? cb_nextSpanTransition_NextSpanTransition_IILjava_lang_Class__I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_text_Spanned;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_text_Spanned.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_text_Spanned.ManagedPeerType;

	public ISpannedInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetSpanEnd_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_I(n_GetSpanEnd_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSpanEnd_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_tag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISpanned? spanned = Java.Lang.Object.GetObject<ISpanned>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object tag = Java.Lang.Object.GetObject<Java.Lang.Object>(native_tag, JniHandleOwnership.DoNotTransfer);
			return spanned.GetSpanEnd(tag);
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

	public unsafe int GetSpanEnd(Java.Lang.Object? tag)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
			return _members_android_text_Spanned.InstanceMethods.InvokeAbstractInt32Method("getSpanEnd.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tag);
		}
	}

	private static Delegate GetGetSpanFlags_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_I(n_GetSpanFlags_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSpanFlags_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_tag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISpanned? spanned = Java.Lang.Object.GetObject<ISpanned>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object tag = Java.Lang.Object.GetObject<Java.Lang.Object>(native_tag, JniHandleOwnership.DoNotTransfer);
			return (int)spanned.GetSpanFlags(tag);
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

	public unsafe SpanTypes GetSpanFlags(Java.Lang.Object? tag)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
			return (SpanTypes)_members_android_text_Spanned.InstanceMethods.InvokeAbstractInt32Method("getSpanFlags.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tag);
		}
	}

	private static Delegate GetGetSpans_IILjava_lang_Class_Handler()
	{
		return new _JniMarshal_PPIIL_L(n_GetSpans_IILjava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSpans_IILjava_lang_Class_(nint jnienv, nint native__this, int start, int end, nint native_type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISpanned? spanned = Java.Lang.Object.GetObject<ISpanned>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class type = Java.Lang.Object.GetObject<Class>(native_type, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(spanned.GetSpans(start, end, type));
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

	public unsafe Java.Lang.Object[]? GetSpans(int start, int end, Class? type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(end);
			ptr[2] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			return (Java.Lang.Object[])JNIEnv.GetArray(_members_android_text_Spanned.InstanceMethods.InvokeAbstractObjectMethod("getSpans.(IILjava/lang/Class;)[Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Object));
		}
		finally
		{
			GC.KeepAlive(type);
		}
	}

	private static Delegate GetGetSpanStart_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_I(n_GetSpanStart_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSpanStart_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_tag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISpanned? spanned = Java.Lang.Object.GetObject<ISpanned>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object tag = Java.Lang.Object.GetObject<Java.Lang.Object>(native_tag, JniHandleOwnership.DoNotTransfer);
			return spanned.GetSpanStart(tag);
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

	public unsafe int GetSpanStart(Java.Lang.Object? tag)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
			return _members_android_text_Spanned.InstanceMethods.InvokeAbstractInt32Method("getSpanStart.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tag);
		}
	}

	private static Delegate GetNextSpanTransition_IILjava_lang_Class_Handler()
	{
		return new _JniMarshal_PPIIL_I(n_NextSpanTransition_IILjava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_NextSpanTransition_IILjava_lang_Class_(nint jnienv, nint native__this, int start, int limit, nint native_type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISpanned? spanned = Java.Lang.Object.GetObject<ISpanned>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class type = Java.Lang.Object.GetObject<Class>(native_type, JniHandleOwnership.DoNotTransfer);
			return spanned.NextSpanTransition(start, limit, type);
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

	public unsafe int NextSpanTransition(int start, int limit, Class? type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(limit);
			ptr[2] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			return _members_android_text_Spanned.InstanceMethods.InvokeAbstractInt32Method("nextSpanTransition.(IILjava/lang/Class;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(type);
		}
	}

	public unsafe char CharAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members_java_lang_CharSequence.InstanceMethods.InvokeAbstractCharMethod("charAt.(I)C", this, ptr);
	}

	public unsafe int Length()
	{
		return _members_java_lang_CharSequence.InstanceMethods.InvokeAbstractInt32Method("length.()I", this, null);
	}

	public unsafe ICharSequence SubSequenceFormatted(int start, int end)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(end);
		return Java.Lang.Object.GetObject<ICharSequence>(_members_java_lang_CharSequence.InstanceMethods.InvokeAbstractObjectMethod("subSequence.(II)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public new unsafe string ToString()
	{
		return JNIEnv.GetString(_members_java_lang_CharSequence.InstanceMethods.InvokeAbstractObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
