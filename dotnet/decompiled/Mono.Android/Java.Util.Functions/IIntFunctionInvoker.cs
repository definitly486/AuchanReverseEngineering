using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Functions;

[Register("java/util/function/IntFunction", DoNotGenerateAcw = true, ApiSince = 24)]
internal class IIntFunctionInvoker : Java.Lang.Object, IIntFunction, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_util_function_IntFunction = new XAPeerMembers("java/util/function/IntFunction", typeof(IIntFunctionInvoker));

	private static Delegate? cb_apply_Apply_I_Ljava_lang_Object_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_function_IntFunction;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_function_IntFunction.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_function_IntFunction.ManagedPeerType;

	public IIntFunctionInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetApply_IHandler()
	{
		return new _JniMarshal_PPI_L(n_Apply_I);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Apply_I(nint jnienv, nint native__this, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IIntFunction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Apply(value));
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
	public unsafe Java.Lang.Object? Apply(int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_java_util_function_IntFunction.InstanceMethods.InvokeAbstractObjectMethod("apply.(I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
