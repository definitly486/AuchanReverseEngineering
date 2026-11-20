using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Net;

[Register("java/net/SocketAddress", DoNotGenerateAcw = true)]
internal class SocketAddressInvoker : SocketAddress
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/net/SocketAddress", typeof(SocketAddressInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public SocketAddressInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
