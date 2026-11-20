using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Traffic;

[Register("com/yandex/mapkit/traffic/TrafficListener", DoNotGenerateAcw = true)]
internal class ITrafficListenerInvoker : Java.Lang.Object, ITrafficListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_traffic_TrafficListener = new XAPeerMembers("com/yandex/mapkit/traffic/TrafficListener", typeof(ITrafficListenerInvoker));

	private static Delegate? cb_onTrafficChanged_OnTrafficChanged_Lcom_yandex_mapkit_traffic_TrafficLevel__V;

	private static Delegate? cb_onTrafficExpired_OnTrafficExpired_V;

	private static Delegate? cb_onTrafficLoading_OnTrafficLoading_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_traffic_TrafficListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_traffic_TrafficListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_traffic_TrafficListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_traffic_TrafficListener.ManagedPeerType;

	public ITrafficListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnTrafficChanged_Lcom_yandex_mapkit_traffic_TrafficLevel_Handler()
	{
		if ((object)cb_onTrafficChanged_OnTrafficChanged_Lcom_yandex_mapkit_traffic_TrafficLevel__V == null)
		{
			cb_onTrafficChanged_OnTrafficChanged_Lcom_yandex_mapkit_traffic_TrafficLevel__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnTrafficChanged_Lcom_yandex_mapkit_traffic_TrafficLevel_));
		}
		return cb_onTrafficChanged_OnTrafficChanged_Lcom_yandex_mapkit_traffic_TrafficLevel__V;
	}

	private static void n_OnTrafficChanged_Lcom_yandex_mapkit_traffic_TrafficLevel_(nint jnienv, nint native__this, nint native_p0)
	{
		ITrafficListener? trafficListener = Java.Lang.Object.GetObject<ITrafficListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		TrafficLevel p = Java.Lang.Object.GetObject<TrafficLevel>(native_p0, JniHandleOwnership.DoNotTransfer);
		trafficListener.OnTrafficChanged(p);
	}

	public unsafe void OnTrafficChanged(TrafficLevel? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_traffic_TrafficListener.InstanceMethods.InvokeAbstractVoidMethod("onTrafficChanged.(Lcom/yandex/mapkit/traffic/TrafficLevel;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnTrafficExpiredHandler()
	{
		if ((object)cb_onTrafficExpired_OnTrafficExpired_V == null)
		{
			cb_onTrafficExpired_OnTrafficExpired_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnTrafficExpired));
		}
		return cb_onTrafficExpired_OnTrafficExpired_V;
	}

	private static void n_OnTrafficExpired(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ITrafficListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnTrafficExpired();
	}

	public unsafe void OnTrafficExpired()
	{
		_members_com_yandex_mapkit_traffic_TrafficListener.InstanceMethods.InvokeAbstractVoidMethod("onTrafficExpired.()V", this, null);
	}

	private static Delegate GetOnTrafficLoadingHandler()
	{
		if ((object)cb_onTrafficLoading_OnTrafficLoading_V == null)
		{
			cb_onTrafficLoading_OnTrafficLoading_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnTrafficLoading));
		}
		return cb_onTrafficLoading_OnTrafficLoading_V;
	}

	private static void n_OnTrafficLoading(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ITrafficListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnTrafficLoading();
	}

	public unsafe void OnTrafficLoading()
	{
		_members_com_yandex_mapkit_traffic_TrafficListener.InstanceMethods.InvokeAbstractVoidMethod("onTrafficLoading.()V", this, null);
	}
}
