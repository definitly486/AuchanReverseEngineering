using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util.Functions;

namespace Java.Util;

[Register("java/util/Iterator", "", "Java.Util.IIteratorInvoker")]
[JavaTypeParameters(new string[] { "E" })]
public interface IIterator : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/Iterator", typeof(IIterator), isInterface: true);

	private static Delegate? cb_forEachRemaining_ForEachRemaining_Ljava_util_function_Consumer__V;

	bool HasNext
	{
		[Register("hasNext", "()Z", "GetHasNextHandler:Java.Util.IIteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("next", "()Ljava/lang/Object;", "GetNextHandler:Java.Util.IIteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Java.Lang.Object? Next();

	[Register("remove", "()V", "GetRemoveHandler:Java.Util.IIteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Remove();

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetForEachRemaining_Ljava_util_function_Consumer_Handler()
	{
		return new _JniMarshal_PPL_V(n_ForEachRemaining_Ljava_util_function_Consumer_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ForEachRemaining_Ljava_util_function_Consumer_(nint jnienv, nint native__this, nint native_action)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IIterator? iterator = Java.Lang.Object.GetObject<IIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConsumer action = Java.Lang.Object.GetObject<IConsumer>(native_action, JniHandleOwnership.DoNotTransfer);
			iterator.ForEachRemaining(action);
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

	[SupportedOSPlatform("android24.0")]
	[Register("forEachRemaining", "(Ljava/util/function/Consumer;)V", "GetForEachRemaining_Ljava_util_function_Consumer_Handler:Java.Util.IIterator, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	unsafe void ForEachRemaining(IConsumer action)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("forEachRemaining.(Ljava/util/function/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(action);
		}
	}
}
