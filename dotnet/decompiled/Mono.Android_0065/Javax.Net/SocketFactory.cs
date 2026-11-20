using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Javax.Net;

[Register("javax/net/SocketFactory", DoNotGenerateAcw = true)]
public abstract class SocketFactory : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/net/SocketFactory", typeof(SocketFactory));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected SocketFactory(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
