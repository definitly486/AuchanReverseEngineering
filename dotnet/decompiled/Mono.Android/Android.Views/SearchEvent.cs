using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[SupportedOSPlatform("android23.0")]
[Register("android/view/SearchEvent", DoNotGenerateAcw = true, ApiSince = 23)]
public class SearchEvent : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/SearchEvent", typeof(SearchEvent));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected SearchEvent(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
