using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/StartupParamsCallback", DoNotGenerateAcw = true)]
internal class IStartupParamsCallbackInvoker : Java.Lang.Object, IStartupParamsCallback, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_io_appmetrica_analytics_StartupParamsCallback = new XAPeerMembers("io/appmetrica/analytics/StartupParamsCallback", typeof(IStartupParamsCallbackInvoker));

	private static Delegate? cb_onReceive_OnReceive_Lio_appmetrica_analytics_StartupParamsCallback_Result__V;

	private static Delegate? cb_onRequestError_OnRequestError_Lio_appmetrica_analytics_StartupParamsCallback_Reason_Lio_appmetrica_analytics_StartupParamsCallback_Result__V;

	private static nint java_class_ref => _members_io_appmetrica_analytics_StartupParamsCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_io_appmetrica_analytics_StartupParamsCallback;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_io_appmetrica_analytics_StartupParamsCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_io_appmetrica_analytics_StartupParamsCallback.ManagedPeerType;

	public IStartupParamsCallbackInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static void n_OnReceive_Lio_appmetrica_analytics_StartupParamsCallback_Result_(nint jnienv, nint native__this, nint native_p0)
	{
		IStartupParamsCallback? startupParamsCallback = Java.Lang.Object.GetObject<IStartupParamsCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IStartupParamsCallback.Result p = Java.Lang.Object.GetObject<IStartupParamsCallback.Result>(native_p0, JniHandleOwnership.DoNotTransfer);
		startupParamsCallback.OnReceive(p);
	}

	public unsafe void OnReceive(IStartupParamsCallback.Result? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_io_appmetrica_analytics_StartupParamsCallback.InstanceMethods.InvokeAbstractVoidMethod("onReceive.(Lio/appmetrica/analytics/StartupParamsCallback$Result;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static void n_OnRequestError_Lio_appmetrica_analytics_StartupParamsCallback_Reason_Lio_appmetrica_analytics_StartupParamsCallback_Result_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IStartupParamsCallback? startupParamsCallback = Java.Lang.Object.GetObject<IStartupParamsCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IStartupParamsCallback.Reason p = Java.Lang.Object.GetObject<IStartupParamsCallback.Reason>(native_p0, JniHandleOwnership.DoNotTransfer);
		IStartupParamsCallback.Result p2 = Java.Lang.Object.GetObject<IStartupParamsCallback.Result>(native_p1, JniHandleOwnership.DoNotTransfer);
		startupParamsCallback.OnRequestError(p, p2);
	}

	public unsafe void OnRequestError(IStartupParamsCallback.Reason p0, IStartupParamsCallback.Result? p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_io_appmetrica_analytics_StartupParamsCallback.InstanceMethods.InvokeAbstractVoidMethod("onRequestError.(Lio/appmetrica/analytics/StartupParamsCallback$Reason;Lio/appmetrica/analytics/StartupParamsCallback$Result;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnReceive_Lio_appmetrica_analytics_StartupParamsCallback_Result__mm_wrapper(nint jnienv, nint native__this, nint native_p0)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnReceive_Lio_appmetrica_analytics_StartupParamsCallback_Result_(jnienv, native__this, native_p0);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnRequestError_Lio_appmetrica_analytics_StartupParamsCallback_Reason_Lio_appmetrica_analytics_StartupParamsCallback_Result__mm_wrapper(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnRequestError_Lio_appmetrica_analytics_StartupParamsCallback_Reason_Lio_appmetrica_analytics_StartupParamsCallback_Result_(jnienv, native__this, native_p0, native_p1);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
