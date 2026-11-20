using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Functions;

[Register("java/util/function/IntConsumer", "", "Java.Util.Functions.IIntConsumerInvoker", ApiSince = 24)]
public interface IIntConsumer : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/function/IntConsumer", typeof(IIntConsumer), isInterface: true);

	private static Delegate? cb_andThen_AndThen_Ljava_util_function_IntConsumer__Ljava_util_function_IntConsumer_;

	[SupportedOSPlatform("android24.0")]
	[Register("accept", "(I)V", "GetAccept_IHandler:Java.Util.Functions.IIntConsumerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	void Accept(int value);

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetAndThen_Ljava_util_function_IntConsumer_Handler()
	{
		return new _JniMarshal_PPL_L(n_AndThen_Ljava_util_function_IntConsumer_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AndThen_Ljava_util_function_IntConsumer_(nint jnienv, nint native__this, nint native_after)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IIntConsumer? intConsumer = Java.Lang.Object.GetObject<IIntConsumer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IIntConsumer after = Java.Lang.Object.GetObject<IIntConsumer>(native_after, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intConsumer.AndThen(after));
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
	[Register("andThen", "(Ljava/util/function/IntConsumer;)Ljava/util/function/IntConsumer;", "GetAndThen_Ljava_util_function_IntConsumer_Handler:Java.Util.Functions.IIntConsumer, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	unsafe IIntConsumer? AndThen(IIntConsumer? after)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((after == null) ? IntPtr.Zero : ((Java.Lang.Object)after).Handle);
			return Java.Lang.Object.GetObject<IIntConsumer>(_members.InstanceMethods.InvokeVirtualObjectMethod("andThen.(Ljava/util/function/IntConsumer;)Ljava/util/function/IntConsumer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(after);
		}
	}
}
