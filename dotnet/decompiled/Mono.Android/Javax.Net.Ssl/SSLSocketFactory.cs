using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/SSLSocketFactory", DoNotGenerateAcw = true)]
public abstract class SSLSocketFactory : SocketFactory
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/net/ssl/SSLSocketFactory", typeof(SSLSocketFactory));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected SSLSocketFactory(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
