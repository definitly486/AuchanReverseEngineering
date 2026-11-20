using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.View;

[Register("androidx/camera/view/CameraController", DoNotGenerateAcw = true)]
internal class CameraControllerInvoker : CameraController
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/view/CameraController", typeof(CameraControllerInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public CameraControllerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
