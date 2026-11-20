using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/AbstractStringBuilder", DoNotGenerateAcw = true)]
public abstract class AbstractStringBuilder : Object, IAppendable, IJavaObject, IDisposable, IJavaPeerable, ICharSequence, IEnumerable<char>, IEnumerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/AbstractStringBuilder", typeof(AbstractStringBuilder));

	private static Delegate? cb_append_Append_C_Ljava_lang_Object_;

	private static Delegate? cb_append_Append_Ljava_lang_CharSequence_II_Ljava_lang_Object_;

	private static Delegate? cb_append_Append_Ljava_lang_CharSequence__Ljava_lang_Object_;

	private static Delegate? cb_charAt_CharAt_I_C;

	private static Delegate? cb_length_Length_I;

	private static Delegate? cb_subSequence_SubSequence_II_Ljava_lang_CharSequence_;

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

	protected AbstractStringBuilder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetAppend_CHandler()
	{
		return new _JniMarshal_PPs_L(n_Append_C);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Append_C(nint jnienv, nint native__this, ushort native_c)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AbstractStringBuilder? abstractStringBuilder = Object.GetObject<AbstractStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char c = (char)native_c;
			return JNIEnv.ToLocalJniHandle(abstractStringBuilder.Append(c));
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

	[SupportedOSPlatform("android26.0")]
	[Register("append", "(C)Ljava/lang/Object;", "GetAppend_CHandler", ApiSince = 26)]
	public unsafe virtual IAppendable? Append(char c)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((ushort)c);
		return Object.GetObject<IAppendable>(_members.InstanceMethods.InvokeVirtualObjectMethod("append.(C)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetAppend_Ljava_lang_CharSequence_IIHandler()
	{
		return new _JniMarshal_PPLII_L(n_Append_Ljava_lang_CharSequence_II);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Append_Ljava_lang_CharSequence_II(nint jnienv, nint native__this, nint native_s, int start, int end)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AbstractStringBuilder? abstractStringBuilder = Object.GetObject<AbstractStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence s = Object.GetObject<ICharSequence>(native_s, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(abstractStringBuilder.Append(s, start, end));
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

	[SupportedOSPlatform("android26.0")]
	[Register("append", "(Ljava/lang/CharSequence;II)Ljava/lang/Object;", "GetAppend_Ljava_lang_CharSequence_IIHandler", ApiSince = 26)]
	public unsafe virtual IAppendable? Append(ICharSequence? s, int start, int end)
	{
		nint num = CharSequence.ToLocalJniHandle(s);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(end);
			return Object.GetObject<IAppendable>(_members.InstanceMethods.InvokeVirtualObjectMethod("append.(Ljava/lang/CharSequence;II)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(s);
		}
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetAppend_Ljava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPL_L(n_Append_Ljava_lang_CharSequence_);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Append_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_s)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AbstractStringBuilder? abstractStringBuilder = Object.GetObject<AbstractStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence s = Object.GetObject<ICharSequence>(native_s, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(abstractStringBuilder.Append(s));
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

	[SupportedOSPlatform("android26.0")]
	[Register("append", "(Ljava/lang/CharSequence;)Ljava/lang/Object;", "GetAppend_Ljava_lang_CharSequence_Handler", ApiSince = 26)]
	public unsafe virtual IAppendable? Append(ICharSequence? s)
	{
		nint num = CharSequence.ToLocalJniHandle(s);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Object.GetObject<IAppendable>(_members.InstanceMethods.InvokeVirtualObjectMethod("append.(Ljava/lang/CharSequence;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(s);
		}
	}

	private static Delegate GetCharAt_IHandler()
	{
		return new _JniMarshal_PPI_s(n_CharAt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static ushort n_CharAt_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Object.GetObject<AbstractStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CharAt(index);
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

	[Register("charAt", "(I)C", "GetCharAt_IHandler")]
	public unsafe virtual char CharAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members.InstanceMethods.InvokeVirtualCharMethod("charAt.(I)C", this, ptr);
	}

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
			return Object.GetObject<AbstractStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Length();
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

	[Register("length", "()I", "GetLengthHandler")]
	public unsafe virtual int Length()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("length.()I", this, null);
	}

	private static Delegate GetSubSequence_IIHandler()
	{
		return new _JniMarshal_PPII_L(n_SubSequence_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SubSequence_II(nint jnienv, nint native__this, int start, int end)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Object.GetObject<AbstractStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SubSequenceFormatted(start, end));
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

	[Register("subSequence", "(II)Ljava/lang/CharSequence;", "GetSubSequence_IIHandler")]
	public unsafe virtual ICharSequence? SubSequenceFormatted(int start, int end)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(end);
		return Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("subSequence.(II)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetToStringHandler()
	{
		return new _JniMarshal_PP_L(n_ToString);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToString(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Object.GetObject<AbstractStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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

	[SupportedOSPlatform("android26.0")]
	[Register("toString", "()Ljava/lang/String;", "GetToStringHandler", ApiSince = 26)]
	public new abstract string? ToString();

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
