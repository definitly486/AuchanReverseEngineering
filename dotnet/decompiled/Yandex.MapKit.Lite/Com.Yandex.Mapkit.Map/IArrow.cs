using System;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/Arrow", "", "Com.Yandex.Mapkit.Map.IArrowInvoker")]
public interface IArrow : IJavaObject, IDisposable, IJavaPeerable
{
	int FillColor
	{
		[Register("getFillColor", "()I", "GetGetFillColorHandler:Com.Yandex.Mapkit.Map.IArrowInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setFillColor", "(I)V", "GetSetFillColor_IHandler:Com.Yandex.Mapkit.Map.IArrowInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Map.IArrowInvoker, Yandex.MapKit.Lite")]
		get;
	}

	float Length
	{
		[Register("getLength", "()F", "GetGetLengthHandler:Com.Yandex.Mapkit.Map.IArrowInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setLength", "(F)V", "GetSetLength_FHandler:Com.Yandex.Mapkit.Map.IArrowInvoker, Yandex.MapKit.Lite")]
		set;
	}

	int OutlineColor
	{
		[Register("getOutlineColor", "()I", "GetGetOutlineColorHandler:Com.Yandex.Mapkit.Map.IArrowInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setOutlineColor", "(I)V", "GetSetOutlineColor_IHandler:Com.Yandex.Mapkit.Map.IArrowInvoker, Yandex.MapKit.Lite")]
		set;
	}

	float OutlineWidth
	{
		[Register("getOutlineWidth", "()F", "GetGetOutlineWidthHandler:Com.Yandex.Mapkit.Map.IArrowInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setOutlineWidth", "(F)V", "GetSetOutlineWidth_FHandler:Com.Yandex.Mapkit.Map.IArrowInvoker, Yandex.MapKit.Lite")]
		set;
	}

	PolylinePosition Position
	{
		[Register("getPosition", "()Lcom/yandex/mapkit/geometry/PolylinePosition;", "GetGetPositionHandler:Com.Yandex.Mapkit.Map.IArrowInvoker, Yandex.MapKit.Lite")]
		get;
	}

	float TriangleHeight
	{
		[Register("getTriangleHeight", "()F", "GetGetTriangleHeightHandler:Com.Yandex.Mapkit.Map.IArrowInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setTriangleHeight", "(F)V", "GetSetTriangleHeight_FHandler:Com.Yandex.Mapkit.Map.IArrowInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool Visible
	{
		[Register("isVisible", "()Z", "GetIsVisibleHandler:Com.Yandex.Mapkit.Map.IArrowInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setVisible", "(Z)V", "GetSetVisible_ZHandler:Com.Yandex.Mapkit.Map.IArrowInvoker, Yandex.MapKit.Lite")]
		set;
	}
}
