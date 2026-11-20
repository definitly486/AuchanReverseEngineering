using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/CharSequence", "", "Java.Lang.ICharSequenceInvoker")]
public interface ICharSequence : IEnumerable<char>, IEnumerable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/CharSequence", typeof(ICharSequence), isInterface: true);

	private static Delegate? cb_isEmpty_IsEmpty_Z;

	[SupportedOSPlatform("android35.0")]
	unsafe bool IsEmpty => _members.InstanceMethods.InvokeVirtualBooleanMethod("isEmpty.()Z", this, null);

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetIsEmptyHandler()
	{
		return new _JniMarshal_PP_B(n_IsEmpty);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsEmpty(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Object.GetObject<ICharSequence>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEmpty ? ((sbyte)1) : ((sbyte)0);
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

	char CharAt(int index);

	int Length();

	ICharSequence SubSequenceFormatted(int start, int end);

	new string ToString();

	[SupportedOSPlatform("android34.0")]
	static unsafe int Compare(ICharSequence cs1, ICharSequence cs2)
	{
		nint num = CharSequence.ToLocalJniHandle(cs1);
		nint num2 = CharSequence.ToLocalJniHandle(cs2);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return _members.StaticMethods.InvokeInt32Method("compare.(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)I", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(cs1);
			GC.KeepAlive(cs2);
		}
	}

	[SupportedOSPlatform("android34.0")]
	static int Compare(string cs1, string cs2)
	{
		String obj = ((cs1 == null) ? null : new String(cs1));
		String obj2 = ((cs2 == null) ? null : new String(cs2));
		int result = Compare(obj, obj2);
		obj?.Dispose();
		obj2?.Dispose();
		return result;
	}
}
