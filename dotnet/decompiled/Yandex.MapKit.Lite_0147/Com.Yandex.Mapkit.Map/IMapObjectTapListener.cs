using System;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapObjectTapListener", "", "Com.Yandex.Mapkit.Map.IMapObjectTapListenerInvoker")]
public interface IMapObjectTapListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onMapObjectTap", "(Lcom/yandex/mapkit/map/MapObject;Lcom/yandex/mapkit/geometry/Point;)Z", "GetOnMapObjectTap_Lcom_yandex_mapkit_map_MapObject_Lcom_yandex_mapkit_geometry_Point_Handler:Com.Yandex.Mapkit.Map.IMapObjectTapListenerInvoker, Yandex.MapKit.Lite")]
	bool OnMapObjectTap(IMapObject p0, Point p1);
}
