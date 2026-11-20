using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Security;

[Register("java/security/MessageDigest", DoNotGenerateAcw = true)]
internal class MessageDigestInvoker : MessageDigest
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/security/MessageDigest", typeof(MessageDigestInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public MessageDigestInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
