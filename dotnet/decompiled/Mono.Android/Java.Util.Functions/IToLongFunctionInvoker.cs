using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Functions;

[Register("java/util/function/ToLongFunction", DoNotGenerateAcw = true, ApiSince = 24)]
internal class IToLongFunctionInvoker : Java.Lang.Object, IToLongFunction, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_util_function_ToLongFunction = new XAPeerMembers("java/util/function/ToLongFunction", typeof(IToLongFunctionInvoker));

	private static Delegate? cb_applyAsLong_ApplyAsLong_Ljava_lang_Object__J;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_function_ToLongFunction;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_function_ToLongFunction.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_function_ToLongFunction.ManagedPeerType;

	public IToLongFunctionInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetApplyAsLong_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_J(n_ApplyAsLong_Ljava_lang_Object_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static long n_ApplyAsLong_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			IToLongFunction? toLongFunction = Java.Lang.Object.GetObject<IToLongFunction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			return toLongFunction.ApplyAsLong(value);
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
	public unsafe long ApplyAsLong(Java.Lang.Object? value)
	{
		nint num = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_java_util_function_ToLongFunction.InstanceMethods.InvokeAbstractInt64Method("applyAsLong.(Ljava/lang/Object;)J", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
		}
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
