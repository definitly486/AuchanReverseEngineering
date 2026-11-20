using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util.Functions;

namespace Java.Util;

[Register("java/util/Spliterator", DoNotGenerateAcw = true, ApiSince = 24)]
internal class ISpliteratorInvoker : Java.Lang.Object, ISpliterator, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_util_Spliterator = new XAPeerMembers("java/util/Spliterator", typeof(ISpliteratorInvoker));

	private static Delegate? cb_characteristics_Characteristics_I;

	private static Delegate? cb_estimateSize_EstimateSize_J;

	private static Delegate? cb_tryAdvance_TryAdvance_Ljava_util_function_Consumer__Z;

	private static Delegate? cb_trySplit_TrySplit_Ljava_util_Spliterator_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_Spliterator;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_Spliterator.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_Spliterator.ManagedPeerType;

	public ISpliteratorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetCharacteristicsHandler()
	{
		return new _JniMarshal_PP_I(n_Characteristics);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Characteristics(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<ISpliterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Characteristics();
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
	public unsafe SpliteratorCharacteristics Characteristics()
	{
		return (SpliteratorCharacteristics)_members_java_util_Spliterator.InstanceMethods.InvokeAbstractInt32Method("characteristics.()I", this, null);
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetEstimateSizeHandler()
	{
		return new _JniMarshal_PP_J(n_EstimateSize);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static long n_EstimateSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<ISpliterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EstimateSize();
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
	public unsafe long EstimateSize()
	{
		return _members_java_util_Spliterator.InstanceMethods.InvokeAbstractInt64Method("estimateSize.()J", this, null);
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetTryAdvance_Ljava_util_function_Consumer_Handler()
	{
		return new _JniMarshal_PPL_B(n_TryAdvance_Ljava_util_function_Consumer_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_TryAdvance_Ljava_util_function_Consumer_(nint jnienv, nint native__this, nint native_action)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISpliterator? spliterator = Java.Lang.Object.GetObject<ISpliterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConsumer action = Java.Lang.Object.GetObject<IConsumer>(native_action, JniHandleOwnership.DoNotTransfer);
			return spliterator.TryAdvance(action) ? ((sbyte)1) : ((sbyte)0);
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
	public unsafe bool TryAdvance(IConsumer? action)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
			return _members_java_util_Spliterator.InstanceMethods.InvokeAbstractBooleanMethod("tryAdvance.(Ljava/util/function/Consumer;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(action);
		}
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetTrySplitHandler()
	{
		return new _JniMarshal_PP_L(n_TrySplit);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_TrySplit(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISpliterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrySplit());
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
	public unsafe ISpliterator? TrySplit()
	{
		return Java.Lang.Object.GetObject<ISpliterator>(_members_java_util_Spliterator.InstanceMethods.InvokeAbstractObjectMethod("trySplit.()Ljava/util/Spliterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
