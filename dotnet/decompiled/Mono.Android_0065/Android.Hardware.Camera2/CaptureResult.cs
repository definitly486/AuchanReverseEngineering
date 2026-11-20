using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Hardware.Camera2;

[Register("android/hardware/camera2/CaptureResult", DoNotGenerateAcw = true)]
public class CaptureResult : CameraMetadata
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/hardware/camera2/CaptureResult", typeof(CaptureResult));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected CaptureResult(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
