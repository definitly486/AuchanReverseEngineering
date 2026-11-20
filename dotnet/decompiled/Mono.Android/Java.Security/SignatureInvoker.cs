using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Security;

[Register("java/security/Signature", DoNotGenerateAcw = true)]
internal class SignatureInvoker : Signature
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/security/Signature", typeof(SignatureInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public SignatureInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
