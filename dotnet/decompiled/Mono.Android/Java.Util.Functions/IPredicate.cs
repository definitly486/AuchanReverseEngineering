using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Functions;

[Register("java/util/function/Predicate", "", "Java.Util.Functions.IPredicateInvoker", ApiSince = 24)]
[JavaTypeParameters(new string[] { "T" })]
public interface IPredicate : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/function/Predicate", typeof(IPredicate), isInterface: true);

	private static Delegate? cb_and_And_Ljava_util_function_Predicate__Ljava_util_function_Predicate_;

	private static Delegate? cb_negate_Negate_Ljava_util_function_Predicate_;

	private static Delegate? cb_or_Or_Ljava_util_function_Predicate__Ljava_util_function_Predicate_;

	[SupportedOSPlatform("android24.0")]
	[Register("test", "(Ljava/lang/Object;)Z", "GetTest_Ljava_lang_Object_Handler:Java.Util.Functions.IPredicateInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	bool Test(Java.Lang.Object? t);

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetAnd_Ljava_util_function_Predicate_Handler()
	{
		return new _JniMarshal_PPL_L(n_And_Ljava_util_function_Predicate_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_And_Ljava_util_function_Predicate_(nint jnienv, nint native__this, nint native_other)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IPredicate? predicate = Java.Lang.Object.GetObject<IPredicate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IPredicate other = Java.Lang.Object.GetObject<IPredicate>(native_other, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(predicate.And(other));
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
	[Register("and", "(Ljava/util/function/Predicate;)Ljava/util/function/Predicate;", "GetAnd_Ljava_util_function_Predicate_Handler:Java.Util.Functions.IPredicate, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	unsafe IPredicate? And(IPredicate? other)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((other == null) ? IntPtr.Zero : ((Java.Lang.Object)other).Handle);
			return Java.Lang.Object.GetObject<IPredicate>(_members.InstanceMethods.InvokeVirtualObjectMethod("and.(Ljava/util/function/Predicate;)Ljava/util/function/Predicate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(other);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[Register("isEqual", "(Ljava/lang/Object;)Ljava/util/function/Predicate;", "", ApiSince = 24)]
	[JavaTypeParameters(new string[] { "T" })]
	static unsafe IPredicate? IsEqual(Java.Lang.Object? targetRef)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(targetRef?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IPredicate>(_members.StaticMethods.InvokeObjectMethod("isEqual.(Ljava/lang/Object;)Ljava/util/function/Predicate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(targetRef);
		}
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetNegateHandler()
	{
		return new _JniMarshal_PP_L(n_Negate);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Negate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPredicate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Negate());
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
	[Register("negate", "()Ljava/util/function/Predicate;", "GetNegateHandler:Java.Util.Functions.IPredicate, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	unsafe IPredicate? Negate()
	{
		return Java.Lang.Object.GetObject<IPredicate>(_members.InstanceMethods.InvokeVirtualObjectMethod("negate.()Ljava/util/function/Predicate;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android33.0")]
	[Register("not", "(Ljava/util/function/Predicate;)Ljava/util/function/Predicate;", "", ApiSince = 33)]
	[JavaTypeParameters(new string[] { "T" })]
	static unsafe IPredicate? Not(IPredicate? target)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((target == null) ? IntPtr.Zero : ((Java.Lang.Object)target).Handle);
			return Java.Lang.Object.GetObject<IPredicate>(_members.StaticMethods.InvokeObjectMethod("not.(Ljava/util/function/Predicate;)Ljava/util/function/Predicate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(target);
		}
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetOr_Ljava_util_function_Predicate_Handler()
	{
		return new _JniMarshal_PPL_L(n_Or_Ljava_util_function_Predicate_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Or_Ljava_util_function_Predicate_(nint jnienv, nint native__this, nint native_other)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IPredicate? predicate = Java.Lang.Object.GetObject<IPredicate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IPredicate other = Java.Lang.Object.GetObject<IPredicate>(native_other, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(predicate.Or(other));
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
	[Register("or", "(Ljava/util/function/Predicate;)Ljava/util/function/Predicate;", "GetOr_Ljava_util_function_Predicate_Handler:Java.Util.Functions.IPredicate, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	unsafe IPredicate? Or(IPredicate? other)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((other == null) ? IntPtr.Zero : ((Java.Lang.Object)other).Handle);
			return Java.Lang.Object.GetObject<IPredicate>(_members.InstanceMethods.InvokeVirtualObjectMethod("or.(Ljava/util/function/Predicate;)Ljava/util/function/Predicate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(other);
		}
	}
}
