using System;
using Android.Graphics;
using Android.Runtime;
using Com.Yandex.Mapkit.Location;
using Com.Yandex.Mapkit.Map;
using Java.Interop;

namespace Com.Yandex.Mapkit.User_location;

[Register("com/yandex/mapkit/user_location/UserLocationLayer", "", "Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker")]
public interface IUserLocationLayer : IJavaObject, IDisposable, IJavaPeerable
{
	bool AutoZoomEnabled
	{
		[Register("isAutoZoomEnabled", "()Z", "GetIsAutoZoomEnabledHandler:Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setAutoZoomEnabled", "(Z)V", "GetSetAutoZoomEnabled_ZHandler:Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool HeadingModeActive
	{
		[Register("isHeadingModeActive", "()Z", "GetIsHeadingModeActiveHandler:Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setHeadingModeActive", "(Z)V", "GetSetHeadingModeActive_ZHandler:Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool IsAnchorEnabled
	{
		[Register("isAnchorEnabled", "()Z", "GetIsAnchorEnabledHandler:Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker, Yandex.MapKit.Lite")]
		get;
	}

	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker, Yandex.MapKit.Lite")]
		get;
	}

	bool Visible
	{
		[Register("isVisible", "()Z", "GetIsVisibleHandler:Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setVisible", "(Z)V", "GetSetVisible_ZHandler:Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker, Yandex.MapKit.Lite")]
		set;
	}

	[Register("cameraPosition", "()Lcom/yandex/mapkit/map/CameraPosition;", "GetCameraPositionHandler:Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker, Yandex.MapKit.Lite")]
	CameraPosition? CameraPosition();

	[Register("resetAnchor", "()V", "GetResetAnchorHandler:Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker, Yandex.MapKit.Lite")]
	void ResetAnchor();

	[Register("setAnchor", "(Landroid/graphics/PointF;Landroid/graphics/PointF;)V", "GetSetAnchor_Landroid_graphics_PointF_Landroid_graphics_PointF_Handler:Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker, Yandex.MapKit.Lite")]
	void SetAnchor(PointF p0, PointF p1);

	[Register("setDefaultSource", "()V", "GetSetDefaultSourceHandler:Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker, Yandex.MapKit.Lite")]
	void SetDefaultSource();

	[Register("setObjectListener", "(Lcom/yandex/mapkit/user_location/UserLocationObjectListener;)V", "GetSetObjectListener_Lcom_yandex_mapkit_user_location_UserLocationObjectListener_Handler:Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker, Yandex.MapKit.Lite")]
	void SetObjectListener(IUserLocationObjectListener? p0);

	[Register("setSource", "(Lcom/yandex/mapkit/location/LocationViewSource;)V", "GetSetSource_Lcom_yandex_mapkit_location_LocationViewSource_Handler:Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker, Yandex.MapKit.Lite")]
	void SetSource(ILocationViewSource? p0);

	[Register("setTapListener", "(Lcom/yandex/mapkit/user_location/UserLocationTapListener;)V", "GetSetTapListener_Lcom_yandex_mapkit_user_location_UserLocationTapListener_Handler:Com.Yandex.Mapkit.User_location.IUserLocationLayerInvoker, Yandex.MapKit.Lite")]
	void SetTapListener(IUserLocationTapListener? p0);
}
