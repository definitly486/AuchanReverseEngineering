using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/CameraEffect", DoNotGenerateAcw = true)]
internal class CameraEffectInvoker : CameraEffect
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/CameraEffect", typeof(CameraEffectInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public CameraEffectInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
