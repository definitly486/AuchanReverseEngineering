using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Geometry.Geo;

[Register("com/yandex/mapkit/geometry/geo/Projection", "", "Com.Yandex.Mapkit.Geometry.Geo.IProjectionInvoker")]
public interface IProjection : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Geometry.Geo.IProjectionInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("worldToXY", "(Lcom/yandex/mapkit/geometry/Point;I)Lcom/yandex/mapkit/geometry/geo/XYPoint;", "GetWorldToXY_Lcom_yandex_mapkit_geometry_Point_IHandler:Com.Yandex.Mapkit.Geometry.Geo.IProjectionInvoker, Yandex.MapKit.Lite")]
	XYPoint WorldToXY(Point p0, int p1);

	[Register("xyToWorld", "(Lcom/yandex/mapkit/geometry/geo/XYPoint;I)Lcom/yandex/mapkit/geometry/Point;", "GetXyToWorld_Lcom_yandex_mapkit_geometry_geo_XYPoint_IHandler:Com.Yandex.Mapkit.Geometry.Geo.IProjectionInvoker, Yandex.MapKit.Lite")]
	Point XyToWorld(XYPoint p0, int p1);
}
