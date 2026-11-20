using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Hardware.Camera2;

[Register("android/hardware/camera2/CameraMetadata", DoNotGenerateAcw = true)]
internal class CameraMetadataInvoker : CameraMetadata
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/hardware/camera2/CameraMetadata", typeof(CameraMetadataInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public CameraMetadataInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
