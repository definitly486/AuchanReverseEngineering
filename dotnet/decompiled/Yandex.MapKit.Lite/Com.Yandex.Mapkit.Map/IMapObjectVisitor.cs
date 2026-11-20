using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapObjectVisitor", "", "Com.Yandex.Mapkit.Map.IMapObjectVisitorInvoker")]
public interface IMapObjectVisitor : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onCircleVisited", "(Lcom/yandex/mapkit/map/CircleMapObject;)V", "GetOnCircleVisited_Lcom_yandex_mapkit_map_CircleMapObject_Handler:Com.Yandex.Mapkit.Map.IMapObjectVisitorInvoker, Yandex.MapKit.Lite")]
	void OnCircleVisited(ICircleMapObject p0);

	[Register("onClusterizedCollectionVisitEnd", "(Lcom/yandex/mapkit/map/ClusterizedPlacemarkCollection;)V", "GetOnClusterizedCollectionVisitEnd_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection_Handler:Com.Yandex.Mapkit.Map.IMapObjectVisitorInvoker, Yandex.MapKit.Lite")]
	void OnClusterizedCollectionVisitEnd(IClusterizedPlacemarkCollection p0);

	[Register("onClusterizedCollectionVisitStart", "(Lcom/yandex/mapkit/map/ClusterizedPlacemarkCollection;)Z", "GetOnClusterizedCollectionVisitStart_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection_Handler:Com.Yandex.Mapkit.Map.IMapObjectVisitorInvoker, Yandex.MapKit.Lite")]
	bool OnClusterizedCollectionVisitStart(IClusterizedPlacemarkCollection p0);

	[Register("onCollectionVisitEnd", "(Lcom/yandex/mapkit/map/MapObjectCollection;)V", "GetOnCollectionVisitEnd_Lcom_yandex_mapkit_map_MapObjectCollection_Handler:Com.Yandex.Mapkit.Map.IMapObjectVisitorInvoker, Yandex.MapKit.Lite")]
	void OnCollectionVisitEnd(IMapObjectCollection p0);

	[Register("onCollectionVisitStart", "(Lcom/yandex/mapkit/map/MapObjectCollection;)Z", "GetOnCollectionVisitStart_Lcom_yandex_mapkit_map_MapObjectCollection_Handler:Com.Yandex.Mapkit.Map.IMapObjectVisitorInvoker, Yandex.MapKit.Lite")]
	bool OnCollectionVisitStart(IMapObjectCollection p0);

	[Register("onPlacemarkVisited", "(Lcom/yandex/mapkit/map/PlacemarkMapObject;)V", "GetOnPlacemarkVisited_Lcom_yandex_mapkit_map_PlacemarkMapObject_Handler:Com.Yandex.Mapkit.Map.IMapObjectVisitorInvoker, Yandex.MapKit.Lite")]
	void OnPlacemarkVisited(IPlacemarkMapObject p0);

	[Register("onPolygonVisited", "(Lcom/yandex/mapkit/map/PolygonMapObject;)V", "GetOnPolygonVisited_Lcom_yandex_mapkit_map_PolygonMapObject_Handler:Com.Yandex.Mapkit.Map.IMapObjectVisitorInvoker, Yandex.MapKit.Lite")]
	void OnPolygonVisited(IPolygonMapObject p0);

	[Register("onPolylineVisited", "(Lcom/yandex/mapkit/map/PolylineMapObject;)V", "GetOnPolylineVisited_Lcom_yandex_mapkit_map_PolylineMapObject_Handler:Com.Yandex.Mapkit.Map.IMapObjectVisitorInvoker, Yandex.MapKit.Lite")]
	void OnPolylineVisited(IPolylineMapObject p0);
}
