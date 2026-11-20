using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Coroutines;

namespace Xamarin.KotlinX.Coroutines;

[Register("kotlinx/coroutines/CoroutineScope", DoNotGenerateAcw = true)]
internal class ICoroutineScopeInvoker : Java.Lang.Object, ICoroutineScope, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlinx_coroutines_CoroutineScope = new XAPeerMembers("kotlinx/coroutines/CoroutineScope", typeof(ICoroutineScopeInvoker));

	private static Delegate? cb_getCoroutineContext_GetCoroutineContext_Lkotlin_coroutines_CoroutineContext_;

	private static nint java_class_ref => _members_kotlinx_coroutines_CoroutineScope.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlinx_coroutines_CoroutineScope;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlinx_coroutines_CoroutineScope.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlinx_coroutines_CoroutineScope.ManagedPeerType;

	public unsafe ICoroutineContext CoroutineContext => Java.Lang.Object.GetObject<ICoroutineContext>(_members_kotlinx_coroutines_CoroutineScope.InstanceMethods.InvokeAbstractObjectMethod("getCoroutineContext.()Lkotlin/coroutines/CoroutineContext;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public ICoroutineScopeInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetCoroutineContextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCoroutineContext);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCoroutineContext(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICoroutineScope>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CoroutineContext);
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
