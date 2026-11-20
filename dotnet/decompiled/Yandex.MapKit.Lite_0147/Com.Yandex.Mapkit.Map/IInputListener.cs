using System;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/InputListener", "", "Com.Yandex.Mapkit.Map.IInputListenerInvoker")]
public interface IInputListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onMapLongTap", "(Lcom/yandex/mapkit/map/Map;Lcom/yandex/mapkit/geometry/Point;)V", "GetOnMapLongTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point_Handler:Com.Yandex.Mapkit.Map.IInputListenerInvoker, Yandex.MapKit.Lite")]
	void OnMapLongTap(IMap p0, Point p1);

	[Register("onMapTap", "(Lcom/yandex/mapkit/map/Map;Lcom/yandex/mapkit/geometry/Point;)V", "GetOnMapTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point_Handler:Com.Yandex.Mapkit.Map.IInputListenerInvoker, Yandex.MapKit.Lite")]
	void OnMapTap(IMap p0, Point p1);
}
