using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/LocationManager", DoNotGenerateAcw = true)]
internal class ILocationManagerInvoker : Java.Lang.Object, ILocationManager, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_location_LocationManager = new XAPeerMembers("com/yandex/mapkit/location/LocationManager", typeof(ILocationManagerInvoker));

	private static Delegate? cb_requestSingleUpdate_RequestSingleUpdate_Lcom_yandex_mapkit_location_LocationListener__V;

	private static Delegate? cb_resume_Resume_V;

	private static Delegate? cb_subscribeForLocationUpdates_SubscribeForLocationUpdates_Lcom_yandex_mapkit_location_SubscriptionSettings_Lcom_yandex_mapkit_location_LocationListener__V;

	private static Delegate? cb_suspend_Suspend_V;

	private static Delegate? cb_unsubscribe_Unsubscribe_Lcom_yandex_mapkit_location_LocationListener__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_location_LocationManager.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_location_LocationManager;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_location_LocationManager.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_location_LocationManager.ManagedPeerType;

	public ILocationManagerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetRequestSingleUpdate_Lcom_yandex_mapkit_location_LocationListener_Handler()
	{
		if ((object)cb_requestSingleUpdate_RequestSingleUpdate_Lcom_yandex_mapkit_location_LocationListener__V == null)
		{
			cb_requestSingleUpdate_RequestSingleUpdate_Lcom_yandex_mapkit_location_LocationListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RequestSingleUpdate_Lcom_yandex_mapkit_location_LocationListener_));
		}
		return cb_requestSingleUpdate_RequestSingleUpdate_Lcom_yandex_mapkit_location_LocationListener__V;
	}

	private static void n_RequestSingleUpdate_Lcom_yandex_mapkit_location_LocationListener_(nint jnienv, nint native__this, nint native_p0)
	{
		ILocationManager? locationManager = Java.Lang.Object.GetObject<ILocationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ILocationListener p = Java.Lang.Object.GetObject<ILocationListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		locationManager.RequestSingleUpdate(p);
	}

	public unsafe void RequestSingleUpdate(ILocationListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_location_LocationManager.InstanceMethods.InvokeAbstractVoidMethod("requestSingleUpdate.(Lcom/yandex/mapkit/location/LocationListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetResumeHandler()
	{
		if ((object)cb_resume_Resume_V == null)
		{
			cb_resume_Resume_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Resume));
		}
		return cb_resume_Resume_V;
	}

	private static void n_Resume(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ILocationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Resume();
	}

	public unsafe void Resume()
	{
		_members_com_yandex_mapkit_location_LocationManager.InstanceMethods.InvokeAbstractVoidMethod("resume.()V", this, null);
	}

	private static Delegate GetSubscribeForLocationUpdates_Lcom_yandex_mapkit_location_SubscriptionSettings_Lcom_yandex_mapkit_location_LocationListener_Handler()
	{
		if ((object)cb_subscribeForLocationUpdates_SubscribeForLocationUpdates_Lcom_yandex_mapkit_location_SubscriptionSettings_Lcom_yandex_mapkit_location_LocationListener__V == null)
		{
			cb_subscribeForLocationUpdates_SubscribeForLocationUpdates_Lcom_yandex_mapkit_location_SubscriptionSettings_Lcom_yandex_mapkit_location_LocationListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SubscribeForLocationUpdates_Lcom_yandex_mapkit_location_SubscriptionSettings_Lcom_yandex_mapkit_location_LocationListener_));
		}
		return cb_subscribeForLocationUpdates_SubscribeForLocationUpdates_Lcom_yandex_mapkit_location_SubscriptionSettings_Lcom_yandex_mapkit_location_LocationListener__V;
	}

	private static void n_SubscribeForLocationUpdates_Lcom_yandex_mapkit_location_SubscriptionSettings_Lcom_yandex_mapkit_location_LocationListener_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		ILocationManager? locationManager = Java.Lang.Object.GetObject<ILocationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SubscriptionSettings p = Java.Lang.Object.GetObject<SubscriptionSettings>(native_p0, JniHandleOwnership.DoNotTransfer);
		ILocationListener p2 = Java.Lang.Object.GetObject<ILocationListener>(native_p1, JniHandleOwnership.DoNotTransfer);
		locationManager.SubscribeForLocationUpdates(p, p2);
	}

	public unsafe void SubscribeForLocationUpdates(SubscriptionSettings p0, ILocationListener p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_com_yandex_mapkit_location_LocationManager.InstanceMethods.InvokeAbstractVoidMethod("subscribeForLocationUpdates.(Lcom/yandex/mapkit/location/SubscriptionSettings;Lcom/yandex/mapkit/location/LocationListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSuspendHandler()
	{
		if ((object)cb_suspend_Suspend_V == null)
		{
			cb_suspend_Suspend_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Suspend));
		}
		return cb_suspend_Suspend_V;
	}

	private static void n_Suspend(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ILocationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Suspend();
	}

	public unsafe void Suspend()
	{
		_members_com_yandex_mapkit_location_LocationManager.InstanceMethods.InvokeAbstractVoidMethod("suspend.()V", this, null);
	}

	private static Delegate GetUnsubscribe_Lcom_yandex_mapkit_location_LocationListener_Handler()
	{
		if ((object)cb_unsubscribe_Unsubscribe_Lcom_yandex_mapkit_location_LocationListener__V == null)
		{
			cb_unsubscribe_Unsubscribe_Lcom_yandex_mapkit_location_LocationListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Unsubscribe_Lcom_yandex_mapkit_location_LocationListener_));
		}
		return cb_unsubscribe_Unsubscribe_Lcom_yandex_mapkit_location_LocationListener__V;
	}

	private static void n_Unsubscribe_Lcom_yandex_mapkit_location_LocationListener_(nint jnienv, nint native__this, nint native_p0)
	{
		ILocationManager? locationManager = Java.Lang.Object.GetObject<ILocationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ILocationListener p = Java.Lang.Object.GetObject<ILocationListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		locationManager.Unsubscribe(p);
	}

	public unsafe void Unsubscribe(ILocationListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_location_LocationManager.InstanceMethods.InvokeAbstractVoidMethod("unsubscribe.(Lcom/yandex/mapkit/location/LocationListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
