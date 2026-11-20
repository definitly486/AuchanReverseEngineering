using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util.Functions;

namespace Java.Util;

[Register("java/util/Spliterator", "", "Java.Util.ISpliteratorInvoker", ApiSince = 24)]
[JavaTypeParameters(new string[] { "T" })]
public interface ISpliterator : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/Spliterator", typeof(ISpliterator), isInterface: true);

	private static Delegate? cb_getComparator_GetComparator_Ljava_util_Comparator_;

	private static Delegate? cb_getExactSizeIfKnown_GetExactSizeIfKnown_J;

	private static Delegate? cb_forEachRemaining_ForEachRemaining_Ljava_util_function_Consumer__V;

	private static Delegate? cb_hasCharacteristics_HasCharacteristics_I_Z;

	[SupportedOSPlatform("android24.0")]
	unsafe IComparator? Comparator
	{
		[Register("getComparator", "()Ljava/util/Comparator;", "GetGetComparatorHandler:Java.Util.ISpliterator, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
		get
		{
			return Java.Lang.Object.GetObject<IComparator>(_members.InstanceMethods.InvokeVirtualObjectMethod("getComparator.()Ljava/util/Comparator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[SupportedOSPlatform("android24.0")]
	unsafe long ExactSizeIfKnown
	{
		[Register("getExactSizeIfKnown", "()J", "GetGetExactSizeIfKnownHandler:Java.Util.ISpliterator, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getExactSizeIfKnown.()J", this, null);
		}
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetGetComparatorHandler()
	{
		return new _JniMarshal_PP_L(n_GetComparator);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetComparator(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISpliterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Comparator);
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
	private static Delegate GetGetExactSizeIfKnownHandler()
	{
		return new _JniMarshal_PP_J(n_GetExactSizeIfKnown);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetExactSizeIfKnown(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<ISpliterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExactSizeIfKnown;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[Register("characteristics", "()I", "GetCharacteristicsHandler:Java.Util.ISpliteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	SpliteratorCharacteristics Characteristics();

	[SupportedOSPlatform("android24.0")]
	[Register("estimateSize", "()J", "GetEstimateSizeHandler:Java.Util.ISpliteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	long EstimateSize();

	[SupportedOSPlatform("android24.0")]
	[Register("tryAdvance", "(Ljava/util/function/Consumer;)Z", "GetTryAdvance_Ljava_util_function_Consumer_Handler:Java.Util.ISpliteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	bool TryAdvance(IConsumer? action);

	[SupportedOSPlatform("android24.0")]
	[Register("trySplit", "()Ljava/util/Spliterator;", "GetTrySplitHandler:Java.Util.ISpliteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	ISpliterator? TrySplit();

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
			ISpliterator? spliterator = Java.Lang.Object.GetObject<ISpliterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConsumer action = Java.Lang.Object.GetObject<IConsumer>(native_action, JniHandleOwnership.DoNotTransfer);
			spliterator.ForEachRemaining(action);
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
	[Register("forEachRemaining", "(Ljava/util/function/Consumer;)V", "GetForEachRemaining_Ljava_util_function_Consumer_Handler:Java.Util.ISpliterator, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	unsafe void ForEachRemaining(IConsumer? action)
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

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetHasCharacteristics_IHandler()
	{
		return new _JniMarshal_PPI_B(n_HasCharacteristics_I);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasCharacteristics_I(nint jnienv, nint native__this, int characteristics)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ISpliterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasCharacteristics(characteristics) ? ((sbyte)1) : ((sbyte)0);
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
	[Register("hasCharacteristics", "(I)Z", "GetHasCharacteristics_IHandler:Java.Util.ISpliterator, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	unsafe bool HasCharacteristics(int characteristics)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(characteristics);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasCharacteristics.(I)Z", this, ptr);
	}
}
