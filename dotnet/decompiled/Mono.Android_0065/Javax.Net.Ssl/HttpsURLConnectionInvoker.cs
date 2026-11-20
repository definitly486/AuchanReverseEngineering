using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/HttpsURLConnection", DoNotGenerateAcw = true)]
internal class HttpsURLConnectionInvoker : HttpsURLConnection
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/net/ssl/HttpsURLConnection", typeof(HttpsURLConnectionInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public HttpsURLConnectionInvoker(nint handle, JniHandleOwnership transfer)
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
