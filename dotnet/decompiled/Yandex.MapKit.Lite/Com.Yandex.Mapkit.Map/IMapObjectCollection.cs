using System;
using System.Collections.Generic;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Runtime.Image;
using Com.Yandex.Runtime.Ui_view;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapObjectCollection", "", "Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker")]
public interface IMapObjectCollection : IBaseMapObjectCollection, IMapObject, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("addCircle", "(Lcom/yandex/mapkit/geometry/Circle;)Lcom/yandex/mapkit/map/CircleMapObject;", "GetAddCircle_Lcom_yandex_mapkit_geometry_Circle_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	ICircleMapObject AddCircle(Circle p0);

	[Register("addClusterizedPlacemarkCollection", "(Lcom/yandex/mapkit/map/ClusterListener;)Lcom/yandex/mapkit/map/ClusterizedPlacemarkCollection;", "GetAddClusterizedPlacemarkCollection_Lcom_yandex_mapkit_map_ClusterListener_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IClusterizedPlacemarkCollection AddClusterizedPlacemarkCollection(IClusterListener p0);

	[Register("addCollection", "()Lcom/yandex/mapkit/map/MapObjectCollection;", "GetAddCollectionHandler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IMapObjectCollection AddCollection();

	[Obsolete("deprecated")]
	[Register("addEmptyPlacemark", "(Lcom/yandex/mapkit/geometry/Point;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddEmptyPlacemark_Lcom_yandex_mapkit_geometry_Point_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddEmptyPlacemark(Point p0);

	[Obsolete("deprecated")]
	[Register("addEmptyPlacemarks", "(Ljava/util/List;)Ljava/util/List;", "GetAddEmptyPlacemarks_Ljava_util_List_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IList<IPlacemarkMapObject> AddEmptyPlacemarks(IList<Point> p0);

	[Register("addPlacemark", "()Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemarkHandler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark();

	[Obsolete("deprecated")]
	[Register("addPlacemark", "(Lcom/yandex/mapkit/geometry/Point;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark(Point p0);

	[Obsolete("deprecated")]
	[Register("addPlacemark", "(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/runtime/image/AnimatedImageProvider;Lcom/yandex/mapkit/map/IconStyle;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark(Point p0, AnimatedImageProvider p1, IconStyle p2);

	[Obsolete("deprecated")]
	[Register("addPlacemark", "(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/runtime/image/ImageProvider;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark(Point p0, ImageProvider p1);

	[Obsolete("deprecated")]
	[Register("addPlacemark", "(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark(Point p0, ImageProvider p1, IconStyle p2);

	[Obsolete("deprecated")]
	[Register("addPlacemark", "(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/runtime/ui_view/ViewProvider;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark(Point p0, ViewProvider p1);

	[Obsolete("deprecated")]
	[Register("addPlacemark", "(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/runtime/ui_view/ViewProvider;Lcom/yandex/mapkit/map/IconStyle;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark(Point p0, ViewProvider p1, IconStyle p2);

	[Register("addPlacemark", "(Lcom/yandex/mapkit/map/PlacemarkCreatedCallback;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemark_Lcom_yandex_mapkit_map_PlacemarkCreatedCallback_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark(IPlacemarkCreatedCallback p0);

	[Obsolete("deprecated")]
	[Register("addPlacemarks", "(Ljava/util/List;Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;)Ljava/util/List;", "GetAddPlacemarks_Ljava_util_List_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IList<IPlacemarkMapObject> AddPlacemarks(IList<Point> p0, ImageProvider p1, IconStyle p2);

	[Register("addPolygon", "(Lcom/yandex/mapkit/geometry/Polygon;)Lcom/yandex/mapkit/map/PolygonMapObject;", "GetAddPolygon_Lcom_yandex_mapkit_geometry_Polygon_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IPolygonMapObject AddPolygon(Polygon p0);

	[Register("addPolyline", "()Lcom/yandex/mapkit/map/PolylineMapObject;", "GetAddPolylineHandler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IPolylineMapObject AddPolyline();

	[Register("addPolyline", "(Lcom/yandex/mapkit/geometry/Polyline;)Lcom/yandex/mapkit/map/PolylineMapObject;", "GetAddPolyline_Lcom_yandex_mapkit_geometry_Polyline_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IPolylineMapObject AddPolyline(Polyline p0);

	[Register("placemarksStyler", "()Lcom/yandex/mapkit/map/PlacemarksStyler;", "GetPlacemarksStylerHandler:Com.Yandex.Mapkit.Map.IMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarksStyler PlacemarksStyler();
}
