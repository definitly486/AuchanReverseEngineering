using System;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/CameraBounds", "", "Com.Yandex.Mapkit.Map.ICameraBoundsInvoker")]
public interface ICameraBounds : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Map.ICameraBoundsInvoker, Yandex.MapKit.Lite")]
		get;
	}

	BoundingBox? LatLngBounds
	{
		[Register("getLatLngBounds", "()Lcom/yandex/mapkit/geometry/BoundingBox;", "GetGetLatLngBoundsHandler:Com.Yandex.Mapkit.Map.ICameraBoundsInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setLatLngBounds", "(Lcom/yandex/mapkit/geometry/BoundingBox;)V", "GetSetLatLngBounds_Lcom_yandex_mapkit_geometry_BoundingBox_Handler:Com.Yandex.Mapkit.Map.ICameraBoundsInvoker, Yandex.MapKit.Lite")]
		set;
	}

	float MaxZoom
	{
		[Register("getMaxZoom", "()F", "GetGetMaxZoomHandler:Com.Yandex.Mapkit.Map.ICameraBoundsInvoker, Yandex.MapKit.Lite")]
		get;
	}

	float MinZoom
	{
		[Register("getMinZoom", "()F", "GetGetMinZoomHandler:Com.Yandex.Mapkit.Map.ICameraBoundsInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("resetMinMaxZoomPreference", "()V", "GetResetMinMaxZoomPreferenceHandler:Com.Yandex.Mapkit.Map.ICameraBoundsInvoker, Yandex.MapKit.Lite")]
	void ResetMinMaxZoomPreference();

	[Register("setMaxZoomPreference", "(F)V", "GetSetMaxZoomPreference_FHandler:Com.Yandex.Mapkit.Map.ICameraBoundsInvoker, Yandex.MapKit.Lite")]
	void SetMaxZoomPreference(float p0);

	[Register("setMinZoomPreference", "(F)V", "GetSetMinZoomPreference_FHandler:Com.Yandex.Mapkit.Map.ICameraBoundsInvoker, Yandex.MapKit.Lite")]
	void SetMinZoomPreference(float p0);
}
