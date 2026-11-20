using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Functions;

[Register("java/util/function/Consumer", "", "Java.Util.Functions.IConsumerInvoker", ApiSince = 24)]
[JavaTypeParameters(new string[] { "T" })]
public interface IConsumer : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/function/Consumer", typeof(IConsumer), isInterface: true);

	private static Delegate? cb_andThen_AndThen_Ljava_util_function_Consumer__Ljava_util_function_Consumer_;

	[SupportedOSPlatform("android24.0")]
	void Accept(Java.Lang.Object? t);

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetAndThen_Ljava_util_function_Consumer_Handler()
	{
		return new _JniMarshal_PPL_L(n_AndThen_Ljava_util_function_Consumer_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AndThen_Ljava_util_function_Consumer_(nint jnienv, nint native__this, nint native_after)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IConsumer? consumer = Java.Lang.Object.GetObject<IConsumer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConsumer after = Java.Lang.Object.GetObject<IConsumer>(native_after, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(consumer.AndThen(after));
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

	[SupportedOSPlatform("android24.0")]
	unsafe IConsumer? AndThen(IConsumer? after)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((after == null) ? IntPtr.Zero : ((Java.Lang.Object)after).Handle);
			return Java.Lang.Object.GetObject<IConsumer>(_members.InstanceMethods.InvokeVirtualObjectMethod("andThen.(Ljava/util/function/Consumer;)Ljava/util/function/Consumer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(after);
		}
	}
}
