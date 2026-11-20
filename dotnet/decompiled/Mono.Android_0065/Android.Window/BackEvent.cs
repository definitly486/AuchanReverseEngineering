using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Window;

[SupportedOSPlatform("android34.0")]
[Register("android/window/BackEvent", DoNotGenerateAcw = true, ApiSince = 34)]
public sealed class BackEvent : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/window/BackEvent", typeof(BackEvent));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal BackEvent(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
