using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Security.Identity;

[SupportedOSPlatform("android30.0")]
[Register("android/security/identity/IdentityCredential", DoNotGenerateAcw = true, ApiSince = 30)]
public abstract class IdentityCredential : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/security/identity/IdentityCredential", typeof(IdentityCredential));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected IdentityCredential(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
