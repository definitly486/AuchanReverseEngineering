using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Manager;

[Register("com/bumptech/glide/manager/ConnectivityMonitor$ConnectivityListener", DoNotGenerateAcw = true)]
internal class IConnectivityMonitorConnectivityListenerInvoker : Java.Lang.Object, IConnectivityMonitorConnectivityListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_manager_ConnectivityMonitor_ConnectivityListener = new XAPeerMembers("com/bumptech/glide/manager/ConnectivityMonitor$ConnectivityListener", typeof(IConnectivityMonitorConnectivityListenerInvoker));

	private static Delegate? cb_onConnectivityChanged_OnConnectivityChanged_Z_V;

	private static nint java_class_ref => _members_com_bumptech_glide_manager_ConnectivityMonitor_ConnectivityListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_manager_ConnectivityMonitor_ConnectivityListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_manager_ConnectivityMonitor_ConnectivityListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_manager_ConnectivityMonitor_ConnectivityListener.ManagedPeerType;

	public IConnectivityMonitorConnectivityListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnConnectivityChanged_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_OnConnectivityChanged_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnConnectivityChanged_Z(nint jnienv, nint native__this, sbyte native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IConnectivityMonitorConnectivityListener? connectivityMonitorConnectivityListener = Java.Lang.Object.GetObject<IConnectivityMonitorConnectivityListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool p = native_p0 != 0;
			connectivityMonitorConnectivityListener.OnConnectivityChanged(p);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void OnConnectivityChanged(bool p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0 ? ((sbyte)1) : ((sbyte)0));
		_members_com_bumptech_glide_manager_ConnectivityMonitor_ConnectivityListener.InstanceMethods.InvokeAbstractVoidMethod("onConnectivityChanged.(Z)V", this, ptr);
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
