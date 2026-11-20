using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Manager;

[Register("com/bumptech/glide/manager/ConnectivityMonitorFactory", DoNotGenerateAcw = true)]
internal class IConnectivityMonitorFactoryInvoker : Java.Lang.Object, IConnectivityMonitorFactory, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_manager_ConnectivityMonitorFactory = new XAPeerMembers("com/bumptech/glide/manager/ConnectivityMonitorFactory", typeof(IConnectivityMonitorFactoryInvoker));

	private static Delegate? cb_build_Build_Landroid_content_Context_Lcom_bumptech_glide_manager_ConnectivityMonitor_ConnectivityListener__Lcom_bumptech_glide_manager_ConnectivityMonitor_;

	private static nint java_class_ref => _members_com_bumptech_glide_manager_ConnectivityMonitorFactory.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_manager_ConnectivityMonitorFactory;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_manager_ConnectivityMonitorFactory.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_manager_ConnectivityMonitorFactory.ManagedPeerType;

	public IConnectivityMonitorFactoryInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetBuild_Landroid_content_Context_Lcom_bumptech_glide_manager_ConnectivityMonitor_ConnectivityListener_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Build_Landroid_content_Context_Lcom_bumptech_glide_manager_ConnectivityMonitor_ConnectivityListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Build_Landroid_content_Context_Lcom_bumptech_glide_manager_ConnectivityMonitor_ConnectivityListener_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IConnectivityMonitorFactory? connectivityMonitorFactory = Java.Lang.Object.GetObject<IConnectivityMonitorFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context p = Java.Lang.Object.GetObject<Context>(native_p0, JniHandleOwnership.DoNotTransfer);
			IConnectivityMonitorConnectivityListener p2 = Java.Lang.Object.GetObject<IConnectivityMonitorConnectivityListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(connectivityMonitorFactory.Build(p, p2));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe IConnectivityMonitor Build(Context p0, IConnectivityMonitorConnectivityListener p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<IConnectivityMonitor>(_members_com_bumptech_glide_manager_ConnectivityMonitorFactory.InstanceMethods.InvokeAbstractObjectMethod("build.(Landroid/content/Context;Lcom/bumptech/glide/manager/ConnectivityMonitor$ConnectivityListener;)Lcom/bumptech/glide/manager/ConnectivityMonitor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
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
