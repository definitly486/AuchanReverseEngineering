using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/SSLEngine", DoNotGenerateAcw = true)]
internal class SSLEngineInvoker : SSLEngine
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/net/ssl/SSLEngine", typeof(SSLEngineInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public SSLEngineInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
