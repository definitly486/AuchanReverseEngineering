using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util.Functions;

namespace Java.Util;

[Register("java/util/Comparator", "", "Java.Util.IComparatorInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IComparator : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/Comparator", typeof(IComparator), isInterface: true);

	private static Delegate? cb_reversed_Reversed_Ljava_util_Comparator_;

	private static Delegate? cb_thenComparing_ThenComparing_Ljava_util_Comparator__Ljava_util_Comparator_;

	private static Delegate? cb_thenComparing_ThenComparing_Ljava_util_function_Function_Ljava_util_Comparator__Ljava_util_Comparator_;

	private static Delegate? cb_thenComparing_ThenComparing_Ljava_util_function_Function__Ljava_util_Comparator_;

	private static Delegate? cb_thenComparingDouble_ThenComparingDouble_Ljava_util_function_ToDoubleFunction__Ljava_util_Comparator_;

	private static Delegate? cb_thenComparingInt_ThenComparingInt_Ljava_util_function_ToIntFunction__Ljava_util_Comparator_;

	private static Delegate? cb_thenComparingLong_ThenComparingLong_Ljava_util_function_ToLongFunction__Ljava_util_Comparator_;

	int Compare(Java.Lang.Object? o1, Java.Lang.Object? o2);

	bool Equals(Java.Lang.Object? obj);

	[SupportedOSPlatform("android24.0")]
	[JavaTypeParameters(new string[] { "T", "U" })]
	static unsafe IComparator? Comparing(IFunction? keyExtractor, IComparator? keyComparator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((keyExtractor == null) ? IntPtr.Zero : ((Java.Lang.Object)keyExtractor).Handle);
			ptr[1] = new JniArgumentValue((keyComparator == null) ? IntPtr.Zero : ((Java.Lang.Object)keyComparator).Handle);
			return Java.Lang.Object.GetObject<IComparator>(_members.StaticMethods.InvokeObjectMethod("comparing.(Ljava/util/function/Function;Ljava/util/Comparator;)Ljava/util/Comparator;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(keyExtractor);
			GC.KeepAlive(keyComparator);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[JavaTypeParameters(new string[] { "T", "U extends java.lang.Comparable<? super U>" })]
	static unsafe IComparator? Comparing(IFunction? keyExtractor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((keyExtractor == null) ? IntPtr.Zero : ((Java.Lang.Object)keyExtractor).Handle);
			return Java.Lang.Object.GetObject<IComparator>(_members.StaticMethods.InvokeObjectMethod("comparing.(Ljava/util/function/Function;)Ljava/util/Comparator;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(keyExtractor);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[JavaTypeParameters(new string[] { "T" })]
	static unsafe IComparator? ComparingDouble(IToDoubleFunction? keyExtractor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((keyExtractor == null) ? IntPtr.Zero : ((Java.Lang.Object)keyExtractor).Handle);
			return Java.Lang.Object.GetObject<IComparator>(_members.StaticMethods.InvokeObjectMethod("comparingDouble.(Ljava/util/function/ToDoubleFunction;)Ljava/util/Comparator;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(keyExtractor);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[JavaTypeParameters(new string[] { "T" })]
	static unsafe IComparator? ComparingInt(IToIntFunction? keyExtractor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((keyExtractor == null) ? IntPtr.Zero : ((Java.Lang.Object)keyExtractor).Handle);
			return Java.Lang.Object.GetObject<IComparator>(_members.StaticMethods.InvokeObjectMethod("comparingInt.(Ljava/util/function/ToIntFunction;)Ljava/util/Comparator;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(keyExtractor);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[JavaTypeParameters(new string[] { "T" })]
	static unsafe IComparator? ComparingLong(IToLongFunction? keyExtractor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((keyExtractor == null) ? IntPtr.Zero : ((Java.Lang.Object)keyExtractor).Handle);
			return Java.Lang.Object.GetObject<IComparator>(_members.StaticMethods.InvokeObjectMethod("comparingLong.(Ljava/util/function/ToLongFunction;)Ljava/util/Comparator;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(keyExtractor);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[JavaTypeParameters(new string[] { "T extends java.lang.Comparable<? super T>" })]
	static unsafe IComparator? NaturalOrder()
	{
		return Java.Lang.Object.GetObject<IComparator>(_members.StaticMethods.InvokeObjectMethod("naturalOrder.()Ljava/util/Comparator;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android24.0")]
	[JavaTypeParameters(new string[] { "T" })]
	static unsafe IComparator? NullsFirst(IComparator? comparator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((comparator == null) ? IntPtr.Zero : ((Java.Lang.Object)comparator).Handle);
			return Java.Lang.Object.GetObject<IComparator>(_members.StaticMethods.InvokeObjectMethod("nullsFirst.(Ljava/util/Comparator;)Ljava/util/Comparator;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(comparator);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[JavaTypeParameters(new string[] { "T" })]
	static unsafe IComparator? NullsLast(IComparator? comparator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((comparator == null) ? IntPtr.Zero : ((Java.Lang.Object)comparator).Handle);
			return Java.Lang.Object.GetObject<IComparator>(_members.StaticMethods.InvokeObjectMethod("nullsLast.(Ljava/util/Comparator;)Ljava/util/Comparator;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(comparator);
		}
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetReversedHandler()
	{
		return new _JniMarshal_PP_L(n_Reversed);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Reversed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IComparator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reversed());
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
	unsafe IComparator? Reversed()
	{
		return Java.Lang.Object.GetObject<IComparator>(_members.InstanceMethods.InvokeVirtualObjectMethod("reversed.()Ljava/util/Comparator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android24.0")]
	[JavaTypeParameters(new string[] { "T extends java.lang.Comparable<? super T>" })]
	static unsafe IComparator? ReverseOrder()
	{
		return Java.Lang.Object.GetObject<IComparator>(_members.StaticMethods.InvokeObjectMethod("reverseOrder.()Ljava/util/Comparator;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetThenComparing_Ljava_util_Comparator_Handler()
	{
		return new _JniMarshal_PPL_L(n_ThenComparing_Ljava_util_Comparator_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ThenComparing_Ljava_util_Comparator_(nint jnienv, nint native__this, nint native_other)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IComparator? comparator = Java.Lang.Object.GetObject<IComparator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IComparator other = Java.Lang.Object.GetObject<IComparator>(native_other, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(comparator.ThenComparing(other));
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
	unsafe IComparator? ThenComparing(IComparator? other)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((other == null) ? IntPtr.Zero : ((Java.Lang.Object)other).Handle);
			return Java.Lang.Object.GetObject<IComparator>(_members.InstanceMethods.InvokeVirtualObjectMethod("thenComparing.(Ljava/util/Comparator;)Ljava/util/Comparator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(other);
		}
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetThenComparing_Ljava_util_function_Function_Ljava_util_Comparator_Handler()
	{
		return new _JniMarshal_PPLL_L(n_ThenComparing_Ljava_util_function_Function_Ljava_util_Comparator_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ThenComparing_Ljava_util_function_Function_Ljava_util_Comparator_(nint jnienv, nint native__this, nint native_keyExtractor, nint native_keyComparator)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IComparator? comparator = Java.Lang.Object.GetObject<IComparator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFunction keyExtractor = Java.Lang.Object.GetObject<IFunction>(native_keyExtractor, JniHandleOwnership.DoNotTransfer);
			IComparator keyComparator = Java.Lang.Object.GetObject<IComparator>(native_keyComparator, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(comparator.ThenComparing(keyExtractor, keyComparator));
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
	[JavaTypeParameters(new string[] { "U" })]
	unsafe IComparator? ThenComparing(IFunction? keyExtractor, IComparator? keyComparator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((keyExtractor == null) ? IntPtr.Zero : ((Java.Lang.Object)keyExtractor).Handle);
			ptr[1] = new JniArgumentValue((keyComparator == null) ? IntPtr.Zero : ((Java.Lang.Object)keyComparator).Handle);
			return Java.Lang.Object.GetObject<IComparator>(_members.InstanceMethods.InvokeVirtualObjectMethod("thenComparing.(Ljava/util/function/Function;Ljava/util/Comparator;)Ljava/util/Comparator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(keyExtractor);
			GC.KeepAlive(keyComparator);
		}
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetThenComparing_Ljava_util_function_Function_Handler()
	{
		return new _JniMarshal_PPL_L(n_ThenComparing_Ljava_util_function_Function_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ThenComparing_Ljava_util_function_Function_(nint jnienv, nint native__this, nint native_keyExtractor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IComparator? comparator = Java.Lang.Object.GetObject<IComparator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFunction keyExtractor = Java.Lang.Object.GetObject<IFunction>(native_keyExtractor, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(comparator.ThenComparing(keyExtractor));
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
	[JavaTypeParameters(new string[] { "U extends java.lang.Comparable<? super U>" })]
	unsafe IComparator? ThenComparing(IFunction? keyExtractor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((keyExtractor == null) ? IntPtr.Zero : ((Java.Lang.Object)keyExtractor).Handle);
			return Java.Lang.Object.GetObject<IComparator>(_members.InstanceMethods.InvokeVirtualObjectMethod("thenComparing.(Ljava/util/function/Function;)Ljava/util/Comparator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(keyExtractor);
		}
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetThenComparingDouble_Ljava_util_function_ToDoubleFunction_Handler()
	{
		return new _JniMarshal_PPL_L(n_ThenComparingDouble_Ljava_util_function_ToDoubleFunction_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ThenComparingDouble_Ljava_util_function_ToDoubleFunction_(nint jnienv, nint native__this, nint native_keyExtractor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IComparator? comparator = Java.Lang.Object.GetObject<IComparator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IToDoubleFunction keyExtractor = Java.Lang.Object.GetObject<IToDoubleFunction>(native_keyExtractor, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(comparator.ThenComparingDouble(keyExtractor));
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
	unsafe IComparator? ThenComparingDouble(IToDoubleFunction? keyExtractor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((keyExtractor == null) ? IntPtr.Zero : ((Java.Lang.Object)keyExtractor).Handle);
			return Java.Lang.Object.GetObject<IComparator>(_members.InstanceMethods.InvokeVirtualObjectMethod("thenComparingDouble.(Ljava/util/function/ToDoubleFunction;)Ljava/util/Comparator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(keyExtractor);
		}
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetThenComparingInt_Ljava_util_function_ToIntFunction_Handler()
	{
		return new _JniMarshal_PPL_L(n_ThenComparingInt_Ljava_util_function_ToIntFunction_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ThenComparingInt_Ljava_util_function_ToIntFunction_(nint jnienv, nint native__this, nint native_keyExtractor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IComparator? comparator = Java.Lang.Object.GetObject<IComparator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IToIntFunction keyExtractor = Java.Lang.Object.GetObject<IToIntFunction>(native_keyExtractor, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(comparator.ThenComparingInt(keyExtractor));
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
	unsafe IComparator? ThenComparingInt(IToIntFunction? keyExtractor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((keyExtractor == null) ? IntPtr.Zero : ((Java.Lang.Object)keyExtractor).Handle);
			return Java.Lang.Object.GetObject<IComparator>(_members.InstanceMethods.InvokeVirtualObjectMethod("thenComparingInt.(Ljava/util/function/ToIntFunction;)Ljava/util/Comparator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(keyExtractor);
		}
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetThenComparingLong_Ljava_util_function_ToLongFunction_Handler()
	{
		return new _JniMarshal_PPL_L(n_ThenComparingLong_Ljava_util_function_ToLongFunction_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ThenComparingLong_Ljava_util_function_ToLongFunction_(nint jnienv, nint native__this, nint native_keyExtractor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IComparator? comparator = Java.Lang.Object.GetObject<IComparator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IToLongFunction keyExtractor = Java.Lang.Object.GetObject<IToLongFunction>(native_keyExtractor, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(comparator.ThenComparingLong(keyExtractor));
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
	unsafe IComparator? ThenComparingLong(IToLongFunction? keyExtractor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((keyExtractor == null) ? IntPtr.Zero : ((Java.Lang.Object)keyExtractor).Handle);
			return Java.Lang.Object.GetObject<IComparator>(_members.InstanceMethods.InvokeVirtualObjectMethod("thenComparingLong.(Ljava/util/function/ToLongFunction;)Ljava/util/Comparator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(keyExtractor);
		}
	}
}
