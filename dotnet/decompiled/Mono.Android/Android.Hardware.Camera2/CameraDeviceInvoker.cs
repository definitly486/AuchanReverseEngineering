using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Hardware.Camera2;

[Register("android/hardware/camera2/CameraDevice", DoNotGenerateAcw = true)]
internal class CameraDeviceInvoker : CameraDevice
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/hardware/camera2/CameraDevice", typeof(CameraDeviceInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public CameraDeviceInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("close", "()V", "GetCloseHandler")]
	public unsafe override void Close()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
	}
}
