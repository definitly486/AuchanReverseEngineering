using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Video;

[Register("androidx/camera/video/OutputOptions", DoNotGenerateAcw = true)]
internal class OutputOptionsInvoker : OutputOptions
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/video/OutputOptions", typeof(OutputOptionsInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public OutputOptionsInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
