using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Manager;

[Register("com/bumptech/glide/manager/ConnectivityMonitor", DoNotGenerateAcw = true)]
internal class IConnectivityMonitorInvoker : Java.Lang.Object, IConnectivityMonitor, ILifecycleListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_manager_ConnectivityMonitor = new XAPeerMembers("com/bumptech/glide/manager/ConnectivityMonitor", typeof(IConnectivityMonitorInvoker));

	private static readonly JniPeerMembers _members_com_bumptech_glide_manager_LifecycleListener = new XAPeerMembers("com/bumptech/glide/manager/LifecycleListener", typeof(IConnectivityMonitorInvoker));

	private static Delegate? cb_onDestroy_OnDestroy_V;

	private static Delegate? cb_onStart_OnStart_V;

	private static Delegate? cb_onStop_OnStop_V;

	private static nint java_class_ref => _members_com_bumptech_glide_manager_ConnectivityMonitor.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_manager_ConnectivityMonitor;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_manager_ConnectivityMonitor.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_manager_ConnectivityMonitor.ManagedPeerType;

	public IConnectivityMonitorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnDestroyHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnDestroy);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDestroy(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IConnectivityMonitor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDestroy();
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

	public unsafe void OnDestroy()
	{
		_members_com_bumptech_glide_manager_LifecycleListener.InstanceMethods.InvokeAbstractVoidMethod("onDestroy.()V", this, null);
	}

	private static Delegate GetOnStartHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnStart);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStart(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IConnectivityMonitor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStart();
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

	public unsafe void OnStart()
	{
		_members_com_bumptech_glide_manager_LifecycleListener.InstanceMethods.InvokeAbstractVoidMethod("onStart.()V", this, null);
	}

	private static Delegate GetOnStopHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnStop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IConnectivityMonitor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStop();
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

	public unsafe void OnStop()
	{
		_members_com_bumptech_glide_manager_LifecycleListener.InstanceMethods.InvokeAbstractVoidMethod("onStop.()V", this, null);
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
