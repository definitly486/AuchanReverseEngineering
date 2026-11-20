using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Functions;

[Register("java/util/function/Function", "", "Java.Util.Functions.IFunctionInvoker", ApiSince = 24)]
[JavaTypeParameters(new string[] { "T", "R" })]
public interface IFunction : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/function/Function", typeof(IFunction), isInterface: true);

	private static Delegate? cb_andThen_AndThen_Ljava_util_function_Function__Ljava_util_function_Function_;

	private static Delegate? cb_compose_Compose_Ljava_util_function_Function__Ljava_util_function_Function_;

	[SupportedOSPlatform("android24.0")]
	[Register("apply", "(Ljava/lang/Object;)Ljava/lang/Object;", "GetApply_Ljava_lang_Object_Handler:Java.Util.Functions.IFunctionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	Java.Lang.Object? Apply(Java.Lang.Object? t);

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetAndThen_Ljava_util_function_Function_Handler()
	{
		return new _JniMarshal_PPL_L(n_AndThen_Ljava_util_function_Function_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AndThen_Ljava_util_function_Function_(nint jnienv, nint native__this, nint native_after)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IFunction? function = Java.Lang.Object.GetObject<IFunction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFunction after = Java.Lang.Object.GetObject<IFunction>(native_after, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(function.AndThen(after));
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
	[Register("andThen", "(Ljava/util/function/Function;)Ljava/util/function/Function;", "GetAndThen_Ljava_util_function_Function_Handler:Java.Util.Functions.IFunction, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	[JavaTypeParameters(new string[] { "V" })]
	unsafe IFunction? AndThen(IFunction? after)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((after == null) ? IntPtr.Zero : ((Java.Lang.Object)after).Handle);
			return Java.Lang.Object.GetObject<IFunction>(_members.InstanceMethods.InvokeVirtualObjectMethod("andThen.(Ljava/util/function/Function;)Ljava/util/function/Function;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(after);
		}
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetCompose_Ljava_util_function_Function_Handler()
	{
		return new _JniMarshal_PPL_L(n_Compose_Ljava_util_function_Function_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Compose_Ljava_util_function_Function_(nint jnienv, nint native__this, nint native_before)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IFunction? function = Java.Lang.Object.GetObject<IFunction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFunction before = Java.Lang.Object.GetObject<IFunction>(native_before, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(function.Compose(before));
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
	[Register("compose", "(Ljava/util/function/Function;)Ljava/util/function/Function;", "GetCompose_Ljava_util_function_Function_Handler:Java.Util.Functions.IFunction, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	[JavaTypeParameters(new string[] { "V" })]
	unsafe IFunction? Compose(IFunction? before)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((before == null) ? IntPtr.Zero : ((Java.Lang.Object)before).Handle);
			return Java.Lang.Object.GetObject<IFunction>(_members.InstanceMethods.InvokeVirtualObjectMethod("compose.(Ljava/util/function/Function;)Ljava/util/function/Function;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(before);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[Register("identity", "()Ljava/util/function/Function;", "", ApiSince = 24)]
	[JavaTypeParameters(new string[] { "T" })]
	static unsafe IFunction? Identity()
	{
		return Java.Lang.Object.GetObject<IFunction>(_members.StaticMethods.InvokeObjectMethod("identity.()Ljava/util/function/Function;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
