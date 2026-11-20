using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/GetChars", DoNotGenerateAcw = true)]
internal class IGetCharsInvoker : Java.Lang.Object, IGetChars, ICharSequence, IEnumerable<char>, IEnumerable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_text_GetChars = new XAPeerMembers("android/text/GetChars", typeof(IGetCharsInvoker));

	private static readonly JniPeerMembers _members_java_lang_CharSequence = new XAPeerMembers("java/lang/CharSequence", typeof(IGetCharsInvoker));

	private static Delegate? cb_getChars_GetChars_IIarrayCI_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_text_GetChars;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_text_GetChars.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_text_GetChars.ManagedPeerType;

	public IGetCharsInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetChars_IIarrayCIHandler()
	{
		return new _JniMarshal_PPIILI_V(n_GetChars_IIarrayCI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetChars_IIarrayCI(nint jnienv, nint native__this, int start, int end, nint native_dest, int destoff)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGetChars? getChars = Java.Lang.Object.GetObject<IGetChars>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char[] array = (char[])JNIEnv.GetArray(native_dest, JniHandleOwnership.DoNotTransfer, typeof(char));
			getChars.GetChars(start, end, array, destoff);
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

	public unsafe void GetChars(int start, int end, char[]? dest, int destoff)
	{
		nint num = JNIEnv.NewArray(dest);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(end);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(destoff);
			_members_android_text_GetChars.InstanceMethods.InvokeAbstractVoidMethod("getChars.(II[CI)V", this, ptr);
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
