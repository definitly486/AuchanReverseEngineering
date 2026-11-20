using System;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Mapkit.UI;
using Com.Yandex.Runtime.View;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapWindow", "", "Com.Yandex.Mapkit.Map.IMapWindowInvoker")]
public interface IMapWindow : IJavaObject, IDisposable, IJavaPeerable
{
	ScreenPoint? FocusPoint
	{
		[Register("getFocusPoint", "()Lcom/yandex/mapkit/ScreenPoint;", "GetGetFocusPointHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setFocusPoint", "(Lcom/yandex/mapkit/ScreenPoint;)V", "GetSetFocusPoint_Lcom_yandex_mapkit_ScreenPoint_Handler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
		set;
	}

	ScreenRect? FocusRect
	{
		[Register("getFocusRect", "()Lcom/yandex/mapkit/ScreenRect;", "GetGetFocusRectHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setFocusRect", "(Lcom/yandex/mapkit/ScreenRect;)V", "GetSetFocusRect_Lcom_yandex_mapkit_ScreenRect_Handler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
		set;
	}

	VisibleRegion FocusRegion
	{
		[Register("getFocusRegion", "()Lcom/yandex/mapkit/map/VisibleRegion;", "GetGetFocusRegionHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
		get;
	}

	ScreenPoint? GestureFocusPoint
	{
		[Register("getGestureFocusPoint", "()Lcom/yandex/mapkit/ScreenPoint;", "GetGetGestureFocusPointHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setGestureFocusPoint", "(Lcom/yandex/mapkit/ScreenPoint;)V", "GetSetGestureFocusPoint_Lcom_yandex_mapkit_ScreenPoint_Handler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
		set;
	}

	GestureFocusPointMode GestureFocusPointMode
	{
		[Register("getGestureFocusPointMode", "()Lcom/yandex/mapkit/map/GestureFocusPointMode;", "GetGetGestureFocusPointModeHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setGestureFocusPointMode", "(Lcom/yandex/mapkit/map/GestureFocusPointMode;)V", "GetSetGestureFocusPointMode_Lcom_yandex_mapkit_map_GestureFocusPointMode_Handler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
		get;
	}

	IMap Map
	{
		[Register("getMap", "()Lcom/yandex/mapkit/map/Map;", "GetGetMapHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
		get;
	}

	PointOfView PointOfView
	{
		[Register("getPointOfView", "()Lcom/yandex/mapkit/map/PointOfView;", "GetGetPointOfViewHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setPointOfView", "(Lcom/yandex/mapkit/map/PointOfView;)V", "GetSetPointOfView_Lcom_yandex_mapkit_map_PointOfView_Handler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
		set;
	}

	float ScaleFactor
	{
		[Register("getScaleFactor", "()F", "GetGetScaleFactorHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setScaleFactor", "(F)V", "GetSetScaleFactor_FHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
		set;
	}

	[Register("addRasterScreenOverlay", "()Lcom/yandex/mapkit/ui/Overlay;", "GetAddRasterScreenOverlayHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
	IOverlay AddRasterScreenOverlay();

	[Register("addSizeChangedListener", "(Lcom/yandex/mapkit/map/SizeChangedListener;)V", "GetAddSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener_Handler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
	void AddSizeChangedListener(ISizeChangedListener p0);

	[Register("addSurface", "(Lcom/yandex/runtime/view/Surface;)V", "GetAddSurface_Lcom_yandex_runtime_view_Surface_Handler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
	void AddSurface(ISurface p0);

	[Register("height", "()I", "GetHeightHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
	int Height();

	[Register("removeSizeChangedListener", "(Lcom/yandex/mapkit/map/SizeChangedListener;)V", "GetRemoveSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener_Handler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
	void RemoveSizeChangedListener(ISizeChangedListener p0);

	[Register("removeSurface", "(Lcom/yandex/runtime/view/Surface;)V", "GetRemoveSurface_Lcom_yandex_runtime_view_Surface_Handler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
	void RemoveSurface(ISurface p0);

	[Register("screenToWorld", "(Lcom/yandex/mapkit/ScreenPoint;)Lcom/yandex/mapkit/geometry/Point;", "GetScreenToWorld_Lcom_yandex_mapkit_ScreenPoint_Handler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
	Point? ScreenToWorld(ScreenPoint p0);

	[Register("setMaxFps", "(F)V", "GetSetMaxFps_FHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
	void SetMaxFps(float p0);

	[Register("startMemoryMetricsCapture", "()V", "GetStartMemoryMetricsCaptureHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
	void StartMemoryMetricsCapture();

	[Register("startPerformanceMetricsCapture", "()V", "GetStartPerformanceMetricsCaptureHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
	void StartPerformanceMetricsCapture();

	[Register("stopMemoryMetricsCapture", "()Ljava/lang/String;", "GetStopMemoryMetricsCaptureHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
	string StopMemoryMetricsCapture();

	[Register("stopPerformanceMetricsCapture", "()Ljava/lang/String;", "GetStopPerformanceMetricsCaptureHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
	string StopPerformanceMetricsCapture();

	[Register("width", "()I", "GetWidthHandler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
	int Width();

	[Register("worldToScreen", "(Lcom/yandex/mapkit/geometry/Point;)Lcom/yandex/mapkit/ScreenPoint;", "GetWorldToScreen_Lcom_yandex_mapkit_geometry_Point_Handler:Com.Yandex.Mapkit.Map.IMapWindowInvoker, Yandex.MapKit.Lite")]
	ScreenPoint? WorldToScreen(Point p0);
}
