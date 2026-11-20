using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace IO.Appmetrica.Analytics.Profile;

[Register("io/appmetrica/analytics/profile/NameAttribute", DoNotGenerateAcw = true)]
public class NameAttribute : StringAttribute
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/profile/NameAttribute", typeof(NameAttribute));

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected NameAttribute(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
