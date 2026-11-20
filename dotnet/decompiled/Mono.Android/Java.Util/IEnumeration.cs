using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/Enumeration", "", "Java.Util.IEnumerationInvoker")]
[JavaTypeParameters(new string[] { "E" })]
public interface IEnumeration : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/Enumeration", typeof(IEnumeration), isInterface: true);

	private static Delegate? cb_asIterator_AsIterator_Ljava_util_Iterator_;

	bool HasMoreElements
	{
		[Register("hasMoreElements", "()Z", "GetHasMoreElementsHandler:Java.Util.IEnumerationInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("nextElement", "()Ljava/lang/Object;", "GetNextElementHandler:Java.Util.IEnumerationInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Java.Lang.Object? NextElement();

	[SupportedOSPlatform("android33.0")]
	private static Delegate GetAsIteratorHandler()
	{
		return new _JniMarshal_PP_L(n_AsIterator);
	}

	[SupportedOSPlatform("android33.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AsIterator(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IEnumeration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsIterator());
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

	[SupportedOSPlatform("android33.0")]
	[Register("asIterator", "()Ljava/util/Iterator;", "GetAsIteratorHandler:Java.Util.IEnumeration, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 33)]
	unsafe IIterator? AsIterator()
	{
		return Java.Lang.Object.GetObject<IIterator>(_members.InstanceMethods.InvokeVirtualObjectMethod("asIterator.()Ljava/util/Iterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
