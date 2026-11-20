using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Security;

[Register("java/security/SignatureSpi", DoNotGenerateAcw = true)]
internal class SignatureSpiInvoker : SignatureSpi
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/security/SignatureSpi", typeof(SignatureSpiInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public SignatureSpiInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
