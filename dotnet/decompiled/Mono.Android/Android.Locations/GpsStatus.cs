using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Locations;

[ObsoletedOSPlatform("android24.0", "This class is obsoleted in this android platform")]
[Register("android/location/GpsStatus", DoNotGenerateAcw = true)]
public sealed class GpsStatus : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/location/GpsStatus", typeof(GpsStatus));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal GpsStatus(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
