using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/KeyManager", DoNotGenerateAcw = true)]
internal class IKeyManagerInvoker : Java.Lang.Object, IKeyManager, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_javax_net_ssl_KeyManager = new XAPeerMembers("javax/net/ssl/KeyManager", typeof(IKeyManagerInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_javax_net_ssl_KeyManager;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_javax_net_ssl_KeyManager.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_javax_net_ssl_KeyManager.ManagedPeerType;

	public IKeyManagerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
