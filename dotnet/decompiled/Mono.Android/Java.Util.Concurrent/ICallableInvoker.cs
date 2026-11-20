using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Concurrent;

[Register("java/util/concurrent/Callable", DoNotGenerateAcw = true)]
internal class ICallableInvoker : Java.Lang.Object, ICallable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_util_concurrent_Callable = new XAPeerMembers("java/util/concurrent/Callable", typeof(ICallableInvoker));

	private static Delegate? cb_call_Call_Ljava_lang_Object_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_concurrent_Callable;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_concurrent_Callable.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_concurrent_Callable.ManagedPeerType;

	public ICallableInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetCallHandler()
	{
		return new _JniMarshal_PP_L(n_Call);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Call(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICallable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Call());
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

	public unsafe Java.Lang.Object? Call()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_java_util_concurrent_Callable.InstanceMethods.InvokeAbstractObjectMethod("call.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
