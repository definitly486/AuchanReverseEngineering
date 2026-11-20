using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Android.Views.ContentCaptures;

[Register("android/view/contentcapture/ContentCaptureSession", DoNotGenerateAcw = true, ApiSince = 29)]
[SupportedOSPlatform("android29.0")]
internal class ContentCaptureSessionInvoker : ContentCaptureSession
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/contentcapture/ContentCaptureSession", typeof(ContentCaptureSessionInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ContentCaptureSessionInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
