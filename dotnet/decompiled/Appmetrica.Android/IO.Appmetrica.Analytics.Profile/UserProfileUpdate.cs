using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Profile;

[Register("io/appmetrica/analytics/profile/UserProfileUpdate", DoNotGenerateAcw = true)]
public class UserProfileUpdate : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/profile/UserProfileUpdate", typeof(UserProfileUpdate));

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected UserProfileUpdate(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
