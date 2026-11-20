using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/CharSequence", DoNotGenerateAcw = true)]
internal class ICharSequenceInvoker : Object, ICharSequence, IEnumerable<char>, IEnumerable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_lang_CharSequence = new XAPeerMembers("java/lang/CharSequence", typeof(ICharSequenceInvoker));

	private static Delegate? cb_charAt_CharAt_I_C;

	private static Delegate? cb_length_Length_I;

	private static Delegate? cb_subSequence_SubSequence_II_Ljava_lang_CharSequence_;

	private static Delegate? cb_toString_ToString_Ljava_lang_String_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_lang_CharSequence;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_lang_CharSequence.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_lang_CharSequence.ManagedPeerType;

	public ICharSequenceInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
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
			return Object.GetObject<ICharSequence>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CharAt(index);
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

	public unsafe char CharAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members_java_lang_CharSequence.InstanceMethods.InvokeAbstractCharMethod("charAt.(I)C", this, ptr);
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
			return Object.GetObject<ICharSequence>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Length();
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

	public unsafe int Length()
	{
		return _members_java_lang_CharSequence.InstanceMethods.InvokeAbstractInt32Method("length.()I", this, null);
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
			return CharSequence.ToLocalJniHandle(Object.GetObject<ICharSequence>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SubSequenceFormatted(start, end));
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

	public unsafe ICharSequence SubSequenceFormatted(int start, int end)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(end);
		return Object.GetObject<ICharSequence>(_members_java_lang_CharSequence.InstanceMethods.InvokeAbstractObjectMethod("subSequence.(II)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

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
			return JNIEnv.NewString(Object.GetObject<ICharSequence>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
