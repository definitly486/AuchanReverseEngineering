using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.User_location;

[Register("com/yandex/mapkit/user_location/UserLocationTapListener", DoNotGenerateAcw = true)]
internal class IUserLocationTapListenerInvoker : Java.Lang.Object, IUserLocationTapListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_user_location_UserLocationTapListener = new XAPeerMembers("com/yandex/mapkit/user_location/UserLocationTapListener", typeof(IUserLocationTapListenerInvoker));

	private static Delegate? cb_onUserLocationObjectTap_OnUserLocationObjectTap_Lcom_yandex_mapkit_geometry_Point__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_user_location_UserLocationTapListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_user_location_UserLocationTapListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_user_location_UserLocationTapListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_user_location_UserLocationTapListener.ManagedPeerType;

	public IUserLocationTapListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnUserLocationObjectTap_Lcom_yandex_mapkit_geometry_Point_Handler()
	{
		if ((object)cb_onUserLocationObjectTap_OnUserLocationObjectTap_Lcom_yandex_mapkit_geometry_Point__V == null)
		{
			cb_onUserLocationObjectTap_OnUserLocationObjectTap_Lcom_yandex_mapkit_geometry_Point__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnUserLocationObjectTap_Lcom_yandex_mapkit_geometry_Point_));
		}
		return cb_onUserLocationObjectTap_OnUserLocationObjectTap_Lcom_yandex_mapkit_geometry_Point__V;
	}

	private static void n_OnUserLocationObjectTap_Lcom_yandex_mapkit_geometry_Point_(nint jnienv, nint native__this, nint native_p0)
	{
		IUserLocationTapListener? userLocationTapListener = Java.Lang.Object.GetObject<IUserLocationTapListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Point p = Java.Lang.Object.GetObject<Point>(native_p0, JniHandleOwnership.DoNotTransfer);
		userLocationTapListener.OnUserLocationObjectTap(p);
	}

	public unsafe void OnUserLocationObjectTap(Point p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_user_location_UserLocationTapListener.InstanceMethods.InvokeAbstractVoidMethod("onUserLocationObjectTap.(Lcom/yandex/mapkit/geometry/Point;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
