using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Javax.Security.Cert;

[Register("javax/security/cert/X509Certificate", DoNotGenerateAcw = true)]
public abstract class X509Certificate : Certificate
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/security/cert/X509Certificate", typeof(X509Certificate));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected X509Certificate(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
