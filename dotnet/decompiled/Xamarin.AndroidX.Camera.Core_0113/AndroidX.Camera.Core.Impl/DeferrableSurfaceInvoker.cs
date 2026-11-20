using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Google.Common.Util.Concurrent;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/DeferrableSurface", DoNotGenerateAcw = true)]
internal class DeferrableSurfaceInvoker : DeferrableSurface
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/DeferrableSurface", typeof(DeferrableSurfaceInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public DeferrableSurfaceInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("provideSurface", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetProvideSurfaceHandler")]
	protected unsafe override IListenableFuture ProvideSurface()
	{
		return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeAbstractObjectMethod("provideSurface.()Lcom/google/common/util/concurrent/ListenableFuture;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
