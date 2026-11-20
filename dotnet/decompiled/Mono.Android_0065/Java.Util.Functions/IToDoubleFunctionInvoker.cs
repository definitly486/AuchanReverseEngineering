using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Functions;

[Register("java/util/function/ToDoubleFunction", DoNotGenerateAcw = true, ApiSince = 24)]
internal class IToDoubleFunctionInvoker : Java.Lang.Object, IToDoubleFunction, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_util_function_ToDoubleFunction = new XAPeerMembers("java/util/function/ToDoubleFunction", typeof(IToDoubleFunctionInvoker));

	private static Delegate? cb_applyAsDouble_ApplyAsDouble_Ljava_lang_Object__D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_function_ToDoubleFunction;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_function_ToDoubleFunction.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_function_ToDoubleFunction.ManagedPeerType;

	public IToDoubleFunctionInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetApplyAsDouble_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_D(n_ApplyAsDouble_Ljava_lang_Object_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static double n_ApplyAsDouble_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0.0;
		}
		try
		{
			IToDoubleFunction? toDoubleFunction = Java.Lang.Object.GetObject<IToDoubleFunction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			return toDoubleFunction.ApplyAsDouble(value);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0.0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[SupportedOSPlatform("android24.0")]
	public unsafe double ApplyAsDouble(Java.Lang.Object? value)
	{
		nint num = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_java_util_function_ToDoubleFunction.InstanceMethods.InvokeAbstractDoubleMethod("applyAsDouble.(Ljava/lang/Object;)D", this, ptr);
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
