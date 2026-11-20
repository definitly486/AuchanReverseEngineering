using System;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Util;

[Register("androidx/core/util/Predicate", "", "AndroidX.Core.Util.IPredicateInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IPredicate : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/util/Predicate", typeof(IPredicate), isInterface: true);

	private static Delegate? cb_and_And_Landroidx_core_util_Predicate__Landroidx_core_util_Predicate_;

	private static Delegate? cb_negate_Negate_Landroidx_core_util_Predicate_;

	private static Delegate? cb_or_Or_Landroidx_core_util_Predicate__Landroidx_core_util_Predicate_;

	[Register("test", "(Ljava/lang/Object;)Z", "GetTest_Ljava_lang_Object_Handler:AndroidX.Core.Util.IPredicateInvoker, Xamarin.AndroidX.Core")]
	bool Test(Java.Lang.Object? t);

	private static Delegate GetAnd_Landroidx_core_util_Predicate_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_And_Landroidx_core_util_Predicate_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_And_Landroidx_core_util_Predicate_(nint jnienv, nint native__this, nint native_other)
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

	[Register("and", "(Landroidx/core/util/Predicate;)Landroidx/core/util/Predicate;", "GetAnd_Landroidx_core_util_Predicate_Handler:AndroidX.Core.Util.IPredicate, Xamarin.AndroidX.Core")]
	unsafe IPredicate? And(IPredicate? other)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((other == null) ? IntPtr.Zero : ((Java.Lang.Object)other).Handle);
			return Java.Lang.Object.GetObject<IPredicate>(_members.InstanceMethods.InvokeVirtualObjectMethod("and.(Landroidx/core/util/Predicate;)Landroidx/core/util/Predicate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(other);
		}
	}

	[Register("isEqual", "(Ljava/lang/Object;)Landroidx/core/util/Predicate;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	static unsafe IPredicate? IsEqual(Java.Lang.Object? targetRef)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(targetRef?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IPredicate>(_members.StaticMethods.InvokeObjectMethod("isEqual.(Ljava/lang/Object;)Landroidx/core/util/Predicate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(targetRef);
		}
	}

	private static Delegate GetNegateHandler()
	{
		return new global::_JniMarshal_PP_L(n_Negate);
	}

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

	[Register("negate", "()Landroidx/core/util/Predicate;", "GetNegateHandler:AndroidX.Core.Util.IPredicate, Xamarin.AndroidX.Core")]
	unsafe IPredicate? Negate()
	{
		return Java.Lang.Object.GetObject<IPredicate>(_members.InstanceMethods.InvokeVirtualObjectMethod("negate.()Landroidx/core/util/Predicate;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("not", "(Landroidx/core/util/Predicate;)Landroidx/core/util/Predicate;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	static unsafe IPredicate? Not(IPredicate? target)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((target == null) ? IntPtr.Zero : ((Java.Lang.Object)target).Handle);
			return Java.Lang.Object.GetObject<IPredicate>(_members.StaticMethods.InvokeObjectMethod("not.(Landroidx/core/util/Predicate;)Landroidx/core/util/Predicate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetOr_Landroidx_core_util_Predicate_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Or_Landroidx_core_util_Predicate_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Or_Landroidx_core_util_Predicate_(nint jnienv, nint native__this, nint native_other)
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

	[Register("or", "(Landroidx/core/util/Predicate;)Landroidx/core/util/Predicate;", "GetOr_Landroidx_core_util_Predicate_Handler:AndroidX.Core.Util.IPredicate, Xamarin.AndroidX.Core")]
	unsafe IPredicate? Or(IPredicate? other)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((other == null) ? IntPtr.Zero : ((Java.Lang.Object)other).Handle);
			return Java.Lang.Object.GetObject<IPredicate>(_members.InstanceMethods.InvokeVirtualObjectMethod("or.(Landroidx/core/util/Predicate;)Landroidx/core/util/Predicate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(other);
		}
	}
}
