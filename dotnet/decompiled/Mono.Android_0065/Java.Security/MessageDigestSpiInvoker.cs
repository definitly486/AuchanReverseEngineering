using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Security;

[Register("java/security/MessageDigestSpi", DoNotGenerateAcw = true)]
internal class MessageDigestSpiInvoker : MessageDigestSpi
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/security/MessageDigestSpi", typeof(MessageDigestSpiInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public MessageDigestSpiInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
