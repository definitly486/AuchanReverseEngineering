using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/LocationListener", DoNotGenerateAcw = true)]
internal class ILocationListenerInvoker : Java.Lang.Object, ILocationListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_location_LocationListener = new XAPeerMembers("com/yandex/mapkit/location/LocationListener", typeof(ILocationListenerInvoker));

	private static Delegate? cb_onLocationStatusUpdated_OnLocationStatusUpdated_Lcom_yandex_mapkit_location_LocationStatus__V;

	private static Delegate? cb_onLocationUpdated_OnLocationUpdated_Lcom_yandex_mapkit_location_Location__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_location_LocationListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_location_LocationListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_location_LocationListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_location_LocationListener.ManagedPeerType;

	public ILocationListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnLocationStatusUpdated_Lcom_yandex_mapkit_location_LocationStatus_Handler()
	{
		if ((object)cb_onLocationStatusUpdated_OnLocationStatusUpdated_Lcom_yandex_mapkit_location_LocationStatus__V == null)
		{
			cb_onLocationStatusUpdated_OnLocationStatusUpdated_Lcom_yandex_mapkit_location_LocationStatus__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnLocationStatusUpdated_Lcom_yandex_mapkit_location_LocationStatus_));
		}
		return cb_onLocationStatusUpdated_OnLocationStatusUpdated_Lcom_yandex_mapkit_location_LocationStatus__V;
	}

	private static void n_OnLocationStatusUpdated_Lcom_yandex_mapkit_location_LocationStatus_(nint jnienv, nint native__this, nint native_p0)
	{
		ILocationListener? locationListener = Java.Lang.Object.GetObject<ILocationListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		LocationStatus p = Java.Lang.Object.GetObject<LocationStatus>(native_p0, JniHandleOwnership.DoNotTransfer);
		locationListener.OnLocationStatusUpdated(p);
	}

	public unsafe void OnLocationStatusUpdated(LocationStatus p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_location_LocationListener.InstanceMethods.InvokeAbstractVoidMethod("onLocationStatusUpdated.(Lcom/yandex/mapkit/location/LocationStatus;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnLocationUpdated_Lcom_yandex_mapkit_location_Location_Handler()
	{
		if ((object)cb_onLocationUpdated_OnLocationUpdated_Lcom_yandex_mapkit_location_Location__V == null)
		{
			cb_onLocationUpdated_OnLocationUpdated_Lcom_yandex_mapkit_location_Location__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnLocationUpdated_Lcom_yandex_mapkit_location_Location_));
		}
		return cb_onLocationUpdated_OnLocationUpdated_Lcom_yandex_mapkit_location_Location__V;
	}

	private static void n_OnLocationUpdated_Lcom_yandex_mapkit_location_Location_(nint jnienv, nint native__this, nint native_p0)
	{
		ILocationListener? locationListener = Java.Lang.Object.GetObject<ILocationListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Location p = Java.Lang.Object.GetObject<Location>(native_p0, JniHandleOwnership.DoNotTransfer);
		locationListener.OnLocationUpdated(p);
	}

	public unsafe void OnLocationUpdated(Location p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_location_LocationListener.InstanceMethods.InvokeAbstractVoidMethod("onLocationUpdated.(Lcom/yandex/mapkit/location/Location;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
