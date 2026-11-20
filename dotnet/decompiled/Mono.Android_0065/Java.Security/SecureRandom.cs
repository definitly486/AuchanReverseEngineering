using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Util;

namespace Java.Security;

[Register("java/security/SecureRandom", DoNotGenerateAcw = true)]
public class SecureRandom : Java.Util.Random
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/security/SecureRandom", typeof(SecureRandom));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected SecureRandom(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
