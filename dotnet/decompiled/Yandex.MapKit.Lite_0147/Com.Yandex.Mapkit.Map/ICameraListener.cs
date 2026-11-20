using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/CameraListener", "", "Com.Yandex.Mapkit.Map.ICameraListenerInvoker")]
public interface ICameraListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onCameraPositionChanged", "(Lcom/yandex/mapkit/map/Map;Lcom/yandex/mapkit/map/CameraPosition;Lcom/yandex/mapkit/map/CameraUpdateReason;Z)V", "GetOnCameraPositionChanged_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_map_CameraUpdateReason_ZHandler:Com.Yandex.Mapkit.Map.ICameraListenerInvoker, Yandex.MapKit.Lite")]
	void OnCameraPositionChanged(IMap p0, CameraPosition p1, CameraUpdateReason p2, bool p3);
}
