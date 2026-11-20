using System;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Runtime.Image;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PolygonMapObject", "", "Com.Yandex.Mapkit.Map.IPolygonMapObjectInvoker")]
public interface IPolygonMapObject : IMapObject, IJavaObject, IDisposable, IJavaPeerable
{
	int FillColor
	{
		[Register("getFillColor", "()I", "GetGetFillColorHandler:Com.Yandex.Mapkit.Map.IPolygonMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setFillColor", "(I)V", "GetSetFillColor_IHandler:Com.Yandex.Mapkit.Map.IPolygonMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool Geodesic
	{
		[Register("isGeodesic", "()Z", "GetIsGeodesicHandler:Com.Yandex.Mapkit.Map.IPolygonMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setGeodesic", "(Z)V", "GetSetGeodesic_ZHandler:Com.Yandex.Mapkit.Map.IPolygonMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	Polygon Geometry
	{
		[Register("getGeometry", "()Lcom/yandex/mapkit/geometry/Polygon;", "GetGetGeometryHandler:Com.Yandex.Mapkit.Map.IPolygonMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setGeometry", "(Lcom/yandex/mapkit/geometry/Polygon;)V", "GetSetGeometry_Lcom_yandex_mapkit_geometry_Polygon_Handler:Com.Yandex.Mapkit.Map.IPolygonMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	int StrokeColor
	{
		[Register("getStrokeColor", "()I", "GetGetStrokeColorHandler:Com.Yandex.Mapkit.Map.IPolygonMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setStrokeColor", "(I)V", "GetSetStrokeColor_IHandler:Com.Yandex.Mapkit.Map.IPolygonMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	float StrokeWidth
	{
		[Register("getStrokeWidth", "()F", "GetGetStrokeWidthHandler:Com.Yandex.Mapkit.Map.IPolygonMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setStrokeWidth", "(F)V", "GetSetStrokeWidth_FHandler:Com.Yandex.Mapkit.Map.IPolygonMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	[Register("resetPattern", "()V", "GetResetPatternHandler:Com.Yandex.Mapkit.Map.IPolygonMapObjectInvoker, Yandex.MapKit.Lite")]
	void ResetPattern();

	[Register("setPattern", "(Lcom/yandex/runtime/image/AnimatedImageProvider;F)V", "GetSetPattern_Lcom_yandex_runtime_image_AnimatedImageProvider_FHandler:Com.Yandex.Mapkit.Map.IPolygonMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetPattern(AnimatedImageProvider p0, float p1);

	[Register("setPattern", "(Lcom/yandex/runtime/image/ImageProvider;F)V", "GetSetPattern_Lcom_yandex_runtime_image_ImageProvider_FHandler:Com.Yandex.Mapkit.Map.IPolygonMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetPattern(ImageProvider p0, float p1);
}
