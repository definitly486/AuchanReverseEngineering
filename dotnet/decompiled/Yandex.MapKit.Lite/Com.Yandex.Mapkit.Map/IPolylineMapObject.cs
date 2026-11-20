using System;
using System.Collections.Generic;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PolylineMapObject", "", "Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker")]
public interface IPolylineMapObject : IMapObject, IJavaObject, IDisposable, IJavaPeerable
{
	float ArcApproximationStep
	{
		[Register("getArcApproximationStep", "()F", "GetGetArcApproximationStepHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setArcApproximationStep", "(F)V", "GetSetArcApproximationStep_FHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	float DashLength
	{
		[Register("getDashLength", "()F", "GetGetDashLengthHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setDashLength", "(F)V", "GetSetDashLength_FHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	float DashOffset
	{
		[Register("getDashOffset", "()F", "GetGetDashOffsetHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setDashOffset", "(F)V", "GetSetDashOffset_FHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	float GapLength
	{
		[Register("getGapLength", "()F", "GetGetGapLengthHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setGapLength", "(F)V", "GetSetGapLength_FHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	Polyline Geometry
	{
		[Register("getGeometry", "()Lcom/yandex/mapkit/geometry/Polyline;", "GetGetGeometryHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setGeometry", "(Lcom/yandex/mapkit/geometry/Polyline;)V", "GetSetGeometry_Lcom_yandex_mapkit_geometry_Polyline_Handler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	float GradientLength
	{
		[Register("getGradientLength", "()F", "GetGetGradientLengthHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setGradientLength", "(F)V", "GetSetGradientLength_FHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool InnerOutlineEnabled
	{
		[Register("isInnerOutlineEnabled", "()Z", "GetIsInnerOutlineEnabledHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setInnerOutlineEnabled", "(Z)V", "GetSetInnerOutlineEnabled_ZHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	int OutlineColor
	{
		[Register("getOutlineColor", "()I", "GetGetOutlineColorHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setOutlineColor", "(I)V", "GetSetOutlineColor_IHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	float OutlineWidth
	{
		[Register("getOutlineWidth", "()F", "GetGetOutlineWidthHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setOutlineWidth", "(F)V", "GetSetOutlineWidth_FHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	float StrokeWidth
	{
		[Register("getStrokeWidth", "()F", "GetGetStrokeWidthHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setStrokeWidth", "(F)V", "GetSetStrokeWidth_FHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	LineStyle Style
	{
		[Register("getStyle", "()Lcom/yandex/mapkit/map/LineStyle;", "GetGetStyleHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setStyle", "(Lcom/yandex/mapkit/map/LineStyle;)V", "GetSetStyle_Lcom_yandex_mapkit_map_LineStyle_Handler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	float TurnRadius
	{
		[Register("getTurnRadius", "()F", "GetGetTurnRadiusHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setTurnRadius", "(F)V", "GetSetTurnRadius_FHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	[Register("addArrow", "(Lcom/yandex/mapkit/geometry/PolylinePosition;FI)Lcom/yandex/mapkit/map/Arrow;", "GetAddArrow_Lcom_yandex_mapkit_geometry_PolylinePosition_FIHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
	IArrow AddArrow(PolylinePosition p0, float p1, int p2);

	[Register("arrows", "()Ljava/util/List;", "GetArrowsHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
	IList<IArrow> Arrows();

	[Register("getPaletteColor", "(I)I", "GetGetPaletteColor_IHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
	int GetPaletteColor(int p0);

	[Register("getStrokeColor", "(I)I", "GetGetStrokeColor_IHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
	int GetStrokeColor(int p0);

	[Register("hide", "(Lcom/yandex/mapkit/geometry/Subpolyline;)V", "GetHide_Lcom_yandex_mapkit_geometry_Subpolyline_Handler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
	void Hide(Subpolyline p0);

	[Register("hide", "(Ljava/util/List;)V", "GetHide_Ljava_util_List_Handler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
	void Hide(IList<Subpolyline> p0);

	[Register("select", "(ILcom/yandex/mapkit/geometry/Subpolyline;)V", "GetSelect_ILcom_yandex_mapkit_geometry_Subpolyline_Handler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
	void Select(int p0, Subpolyline p1);

	[Register("setPaletteColor", "(II)V", "GetSetPaletteColor_IIHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetPaletteColor(int p0, int p1);

	[Register("setStrokeColor", "(I)V", "GetSetStrokeColor_IHandler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetStrokeColor(int p0);

	[Register("setStrokeColors", "(Ljava/util/List;)V", "GetSetStrokeColors_Ljava_util_List_Handler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetStrokeColors(IList<Integer> p0);

	[Register("setStrokeColors", "(Ljava/util/List;Ljava/util/List;)V", "GetSetStrokeColors_Ljava_util_List_Ljava_util_List_Handler:Com.Yandex.Mapkit.Map.IPolylineMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetStrokeColors(IList<Integer> p0, IList<Java.Lang.Double> p1);
}
