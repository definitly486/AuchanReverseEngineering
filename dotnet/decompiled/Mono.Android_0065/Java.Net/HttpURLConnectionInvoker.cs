using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Net;

[Register("java/net/HttpURLConnection", DoNotGenerateAcw = true)]
internal class HttpURLConnectionInvoker : HttpURLConnection
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/net/HttpURLConnection", typeof(HttpURLConnectionInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public HttpURLConnectionInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public unsafe override void Disconnect()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("disconnect.()V", this, null);
	}

	public unsafe override void Connect()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("connect.()V", this, null);
	}
}
