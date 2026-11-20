using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Security;

[Register("java/security/Signature", DoNotGenerateAcw = true)]
public abstract class Signature : SignatureSpi
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/security/Signature", typeof(Signature));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Signature(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
