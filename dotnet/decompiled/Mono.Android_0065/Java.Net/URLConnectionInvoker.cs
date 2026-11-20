using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Net;

[Register("java/net/URLConnection", DoNotGenerateAcw = true)]
internal class URLConnectionInvoker : URLConnection
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/net/URLConnection", typeof(URLConnectionInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public URLConnectionInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public unsafe override void Connect()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("connect.()V", this, null);
	}
}
