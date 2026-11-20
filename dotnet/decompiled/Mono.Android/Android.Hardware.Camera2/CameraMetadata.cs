using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Hardware.Camera2;

[Register("android/hardware/camera2/CameraMetadata", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "TKey" })]
public abstract class CameraMetadata : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/hardware/camera2/CameraMetadata", typeof(CameraMetadata));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected CameraMetadata(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
