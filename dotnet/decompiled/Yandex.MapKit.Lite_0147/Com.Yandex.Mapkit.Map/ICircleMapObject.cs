using System;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/CircleMapObject", "", "Com.Yandex.Mapkit.Map.ICircleMapObjectInvoker")]
public interface ICircleMapObject : IMapObject, IJavaObject, IDisposable, IJavaPeerable
{
	int FillColor
	{
		[Register("getFillColor", "()I", "GetGetFillColorHandler:Com.Yandex.Mapkit.Map.ICircleMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setFillColor", "(I)V", "GetSetFillColor_IHandler:Com.Yandex.Mapkit.Map.ICircleMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool Geodesic
	{
		[Register("isGeodesic", "()Z", "GetIsGeodesicHandler:Com.Yandex.Mapkit.Map.ICircleMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setGeodesic", "(Z)V", "GetSetGeodesic_ZHandler:Com.Yandex.Mapkit.Map.ICircleMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	Circle Geometry
	{
		[Register("getGeometry", "()Lcom/yandex/mapkit/geometry/Circle;", "GetGetGeometryHandler:Com.Yandex.Mapkit.Map.ICircleMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setGeometry", "(Lcom/yandex/mapkit/geometry/Circle;)V", "GetSetGeometry_Lcom_yandex_mapkit_geometry_Circle_Handler:Com.Yandex.Mapkit.Map.ICircleMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	int StrokeColor
	{
		[Register("getStrokeColor", "()I", "GetGetStrokeColorHandler:Com.Yandex.Mapkit.Map.ICircleMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setStrokeColor", "(I)V", "GetSetStrokeColor_IHandler:Com.Yandex.Mapkit.Map.ICircleMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	float StrokeWidth
	{
		[Register("getStrokeWidth", "()F", "GetGetStrokeWidthHandler:Com.Yandex.Mapkit.Map.ICircleMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setStrokeWidth", "(F)V", "GetSetStrokeWidth_FHandler:Com.Yandex.Mapkit.Map.ICircleMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}
}
