using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/DefaultLifecycleObserver", DoNotGenerateAcw = true)]
internal class IDefaultLifecycleObserverInvoker : Java.Lang.Object, IDefaultLifecycleObserver, ILifecycleObserver, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_lifecycle_DefaultLifecycleObserver = new XAPeerMembers("androidx/lifecycle/DefaultLifecycleObserver", typeof(IDefaultLifecycleObserverInvoker));

	private static readonly JniPeerMembers _members_androidx_lifecycle_LifecycleObserver = new XAPeerMembers("androidx/lifecycle/LifecycleObserver", typeof(IDefaultLifecycleObserverInvoker));

	private static nint java_class_ref => _members_androidx_lifecycle_DefaultLifecycleObserver.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_lifecycle_DefaultLifecycleObserver;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_lifecycle_DefaultLifecycleObserver.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_lifecycle_DefaultLifecycleObserver.ManagedPeerType;

	public IDefaultLifecycleObserverInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
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
