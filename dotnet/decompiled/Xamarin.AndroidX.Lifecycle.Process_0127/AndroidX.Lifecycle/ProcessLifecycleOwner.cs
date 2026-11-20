using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/ProcessLifecycleOwner", DoNotGenerateAcw = true)]
public sealed class ProcessLifecycleOwner : Java.Lang.Object, ILifecycleOwner, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/ProcessLifecycleOwner", typeof(ProcessLifecycleOwner));

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe Lifecycle Lifecycle
	{
		[Register("getLifecycle", "()Landroidx/lifecycle/Lifecycle;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Lifecycle>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLifecycle.()Landroidx/lifecycle/Lifecycle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal ProcessLifecycleOwner(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("get", "()Landroidx/lifecycle/LifecycleOwner;", "")]
	public unsafe static ILifecycleOwner Get()
	{
		return Java.Lang.Object.GetObject<ILifecycleOwner>(_members.StaticMethods.InvokeObjectMethod("get.()Landroidx/lifecycle/LifecycleOwner;", null).Handle, JniHandleOwnership.TransferLocalRef);
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
