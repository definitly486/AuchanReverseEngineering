using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/LifecycleOwner", DoNotGenerateAcw = true)]
internal class ILifecycleOwnerInvoker : Java.Lang.Object, ILifecycleOwner, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_lifecycle_LifecycleOwner = new XAPeerMembers("androidx/lifecycle/LifecycleOwner", typeof(ILifecycleOwnerInvoker));

	private static Delegate? cb_getLifecycle_GetLifecycle_Landroidx_lifecycle_Lifecycle_;

	private static nint java_class_ref => _members_androidx_lifecycle_LifecycleOwner.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_lifecycle_LifecycleOwner;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_lifecycle_LifecycleOwner.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_lifecycle_LifecycleOwner.ManagedPeerType;

	public unsafe Lifecycle Lifecycle => Java.Lang.Object.GetObject<Lifecycle>(_members_androidx_lifecycle_LifecycleOwner.InstanceMethods.InvokeAbstractObjectMethod("getLifecycle.()Landroidx/lifecycle/Lifecycle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public ILifecycleOwnerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetLifecycleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetLifecycle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLifecycle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ILifecycleOwner>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Lifecycle);
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
