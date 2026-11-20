using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Android.Security.Identity;

[Register("android/security/identity/IdentityCredential", DoNotGenerateAcw = true, ApiSince = 30)]
[SupportedOSPlatform("android30.0")]
internal class IdentityCredentialInvoker : IdentityCredential
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/security/identity/IdentityCredential", typeof(IdentityCredentialInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public IdentityCredentialInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
