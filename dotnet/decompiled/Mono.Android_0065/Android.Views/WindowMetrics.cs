using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[SupportedOSPlatform("android30.0")]
[Register("android/view/WindowMetrics", DoNotGenerateAcw = true, ApiSince = 30)]
public sealed class WindowMetrics : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/WindowMetrics", typeof(WindowMetrics));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	[SupportedOSPlatform("android30.0")]
	public unsafe Rect Bounds => Java.Lang.Object.GetObject<Rect>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBounds.()Landroid/graphics/Rect;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	internal WindowMetrics(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
