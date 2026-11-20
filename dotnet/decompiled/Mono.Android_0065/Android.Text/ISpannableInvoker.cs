using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/Spannable", DoNotGenerateAcw = true)]
internal class ISpannableInvoker : Java.Lang.Object, ISpannable, ISpanned, ICharSequence, IEnumerable<char>, IEnumerable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_text_Spannable = new XAPeerMembers("android/text/Spannable", typeof(ISpannableInvoker));

	private static readonly JniPeerMembers _members_android_text_Spanned = new XAPeerMembers("android/text/Spanned", typeof(ISpannableInvoker));

	private static readonly JniPeerMembers _members_java_lang_CharSequence = new XAPeerMembers("java/lang/CharSequence", typeof(ISpannableInvoker));

	private static Delegate? cb_removeSpan_RemoveSpan_Ljava_lang_Object__V;

	private static Delegate? cb_setSpan_SetSpan_Ljava_lang_Object_III_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_text_Spannable;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_text_Spannable.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_text_Spannable.ManagedPeerType;

	public ISpannableInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
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
			ISpannable? spannable = Java.Lang.Object.GetObject<ISpannable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			spannable.RemoveSpan(what);
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

	public unsafe void RemoveSpan(Java.Lang.Object? what)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(what?.Handle ?? IntPtr.Zero);
			_members_android_text_Spannable.InstanceMethods.InvokeAbstractVoidMethod("removeSpan.(Ljava/lang/Object;)V", this, ptr);
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
			ISpannable? spannable = Java.Lang.Object.GetObject<ISpannable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			spannable.SetSpan(what, start, end, (SpanTypes)native_flags);
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

	public unsafe void SetSpan(Java.Lang.Object? what, int start, int end, SpanTypes flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(what?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(end);
			ptr[3] = new JniArgumentValue((int)flags);
			_members_android_text_Spannable.InstanceMethods.InvokeAbstractVoidMethod("setSpan.(Ljava/lang/Object;III)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(what);
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
