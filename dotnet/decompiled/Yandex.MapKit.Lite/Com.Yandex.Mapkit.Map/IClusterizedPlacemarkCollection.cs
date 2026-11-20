using System;
using System.Collections.Generic;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Runtime.Image;
using Com.Yandex.Runtime.Ui_view;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/ClusterizedPlacemarkCollection", "", "Com.Yandex.Mapkit.Map.IClusterizedPlacemarkCollectionInvoker")]
public interface IClusterizedPlacemarkCollection : IBaseMapObjectCollection, IMapObject, IJavaObject, IDisposable, IJavaPeerable
{
	[Obsolete("deprecated")]
	[Register("addEmptyPlacemark", "(Lcom/yandex/mapkit/geometry/Point;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddEmptyPlacemark_Lcom_yandex_mapkit_geometry_Point_Handler:Com.Yandex.Mapkit.Map.IClusterizedPlacemarkCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddEmptyPlacemark(Point p0);

	[Register("addEmptyPlacemarks", "(Ljava/util/List;)Ljava/util/List;", "GetAddEmptyPlacemarks_Ljava_util_List_Handler:Com.Yandex.Mapkit.Map.IClusterizedPlacemarkCollectionInvoker, Yandex.MapKit.Lite")]
	IList<IPlacemarkMapObject> AddEmptyPlacemarks(IList<Point> p0);

	[Register("addPlacemark", "()Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemarkHandler:Com.Yandex.Mapkit.Map.IClusterizedPlacemarkCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark();

	[Obsolete("deprecated")]
	[Register("addPlacemark", "(Lcom/yandex/mapkit/geometry/Point;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Handler:Com.Yandex.Mapkit.Map.IClusterizedPlacemarkCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark(Point p0);

	[Obsolete("deprecated")]
	[Register("addPlacemark", "(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/runtime/image/AnimatedImageProvider;Lcom/yandex/mapkit/map/IconStyle;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IClusterizedPlacemarkCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark(Point p0, AnimatedImageProvider p1, IconStyle p2);

	[Obsolete("deprecated")]
	[Register("addPlacemark", "(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/runtime/image/ImageProvider;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider_Handler:Com.Yandex.Mapkit.Map.IClusterizedPlacemarkCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark(Point p0, ImageProvider p1);

	[Obsolete("deprecated")]
	[Register("addPlacemark", "(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IClusterizedPlacemarkCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark(Point p0, ImageProvider p1, IconStyle p2);

	[Obsolete("deprecated")]
	[Register("addPlacemark", "(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/runtime/ui_view/ViewProvider;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider_Handler:Com.Yandex.Mapkit.Map.IClusterizedPlacemarkCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark(Point p0, ViewProvider p1);

	[Obsolete("deprecated")]
	[Register("addPlacemark", "(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/runtime/ui_view/ViewProvider;Lcom/yandex/mapkit/map/IconStyle;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IClusterizedPlacemarkCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark(Point p0, ViewProvider p1, IconStyle p2);

	[Register("addPlacemark", "(Lcom/yandex/mapkit/map/PlacemarkCreatedCallback;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetAddPlacemark_Lcom_yandex_mapkit_map_PlacemarkCreatedCallback_Handler:Com.Yandex.Mapkit.Map.IClusterizedPlacemarkCollectionInvoker, Yandex.MapKit.Lite")]
	IPlacemarkMapObject AddPlacemark(IPlacemarkCreatedCallback p0);

	[Register("addPlacemarks", "(Ljava/util/List;Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;)Ljava/util/List;", "GetAddPlacemarks_Ljava_util_List_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IClusterizedPlacemarkCollectionInvoker, Yandex.MapKit.Lite")]
	IList<IPlacemarkMapObject> AddPlacemarks(IList<Point> p0, ImageProvider p1, IconStyle p2);

	[Register("clusterPlacemarks", "(DI)V", "GetClusterPlacemarks_DIHandler:Com.Yandex.Mapkit.Map.IClusterizedPlacemarkCollectionInvoker, Yandex.MapKit.Lite")]
	void ClusterPlacemarks(double p0, int p1);
}
