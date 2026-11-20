using System;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapObjectDragListener", "", "Com.Yandex.Mapkit.Map.IMapObjectDragListenerInvoker")]
public interface IMapObjectDragListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onMapObjectDrag", "(Lcom/yandex/mapkit/map/MapObject;Lcom/yandex/mapkit/geometry/Point;)V", "GetOnMapObjectDrag_Lcom_yandex_mapkit_map_MapObject_Lcom_yandex_mapkit_geometry_Point_Handler:Com.Yandex.Mapkit.Map.IMapObjectDragListenerInvoker, Yandex.MapKit.Lite")]
	void OnMapObjectDrag(IMapObject p0, Point p1);

	[Register("onMapObjectDragEnd", "(Lcom/yandex/mapkit/map/MapObject;)V", "GetOnMapObjectDragEnd_Lcom_yandex_mapkit_map_MapObject_Handler:Com.Yandex.Mapkit.Map.IMapObjectDragListenerInvoker, Yandex.MapKit.Lite")]
	void OnMapObjectDragEnd(IMapObject p0);

	[Register("onMapObjectDragStart", "(Lcom/yandex/mapkit/map/MapObject;)V", "GetOnMapObjectDragStart_Lcom_yandex_mapkit_map_MapObject_Handler:Com.Yandex.Mapkit.Map.IMapObjectDragListenerInvoker, Yandex.MapKit.Lite")]
	void OnMapObjectDragStart(IMapObject p0);
}
