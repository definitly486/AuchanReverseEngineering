using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Runtime.Image;
using Com.Yandex.Runtime.Ui_view;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PlacemarkMapObject", "", "Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker")]
public interface IPlacemarkMapObject : IMapObject, IJavaObject, IDisposable, IJavaPeerable
{
	float Direction
	{
		[Register("getDirection", "()F", "GetGetDirectionHandler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setDirection", "(F)V", "GetSetDirection_FHandler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	Com.Yandex.Mapkit.Geometry.Point Geometry
	{
		[Register("getGeometry", "()Lcom/yandex/mapkit/geometry/Point;", "GetGetGeometryHandler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setGeometry", "(Lcom/yandex/mapkit/geometry/Point;)V", "GetSetGeometry_Lcom_yandex_mapkit_geometry_Point_Handler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	float Opacity
	{
		[Register("getOpacity", "()F", "GetGetOpacityHandler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setOpacity", "(F)V", "GetSetOpacity_FHandler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	IPlacemarkText Text
	{
		[Register("getText", "()Lcom/yandex/mapkit/map/PlacemarkText;", "GetGetTextHandler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("setIcon", "(Lcom/yandex/runtime/image/ImageProvider;)V", "GetSetIcon_Lcom_yandex_runtime_image_ImageProvider_Handler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetIcon(ImageProvider p0);

	[Register("setIcon", "(Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/Callback;)V", "GetSetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_Callback_Handler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetIcon(ImageProvider p0, ICallback p1);

	[Register("setIcon", "(Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;)V", "GetSetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetIcon(ImageProvider p0, IconStyle p1);

	[Register("setIcon", "(Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;Lcom/yandex/mapkit/map/Callback;)V", "GetSetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_Handler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetIcon(ImageProvider p0, IconStyle p1, ICallback p2);

	[Register("setIconStyle", "(Lcom/yandex/mapkit/map/IconStyle;)V", "GetSetIconStyle_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetIconStyle(IconStyle p0);

	[Register("setScaleFunction", "(Ljava/util/List;)V", "GetSetScaleFunction_Ljava_util_List_Handler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetScaleFunction(IList<PointF> p0);

	[Register("setText", "(Ljava/lang/String;)V", "GetSetText_Ljava_lang_String_Handler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetText(string p0);

	[Register("setText", "(Ljava/lang/String;Lcom/yandex/mapkit/map/TextStyle;)V", "GetSetText_Ljava_lang_String_Lcom_yandex_mapkit_map_TextStyle_Handler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetText(string p0, TextStyle p1);

	[Register("setTextStyle", "(Lcom/yandex/mapkit/map/TextStyle;)V", "GetSetTextStyle_Lcom_yandex_mapkit_map_TextStyle_Handler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetTextStyle(TextStyle p0);

	[Register("setView", "(Lcom/yandex/runtime/ui_view/ViewProvider;)V", "GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Handler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetView(ViewProvider p0);

	[Register("setView", "(Lcom/yandex/runtime/ui_view/ViewProvider;Lcom/yandex/mapkit/map/Callback;)V", "GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_Callback_Handler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetView(ViewProvider p0, ICallback p1);

	[Register("setView", "(Lcom/yandex/runtime/ui_view/ViewProvider;Lcom/yandex/mapkit/map/IconStyle;)V", "GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetView(ViewProvider p0, IconStyle p1);

	[Register("setView", "(Lcom/yandex/runtime/ui_view/ViewProvider;Lcom/yandex/mapkit/map/IconStyle;Lcom/yandex/mapkit/map/Callback;)V", "GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_Handler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetView(ViewProvider p0, IconStyle p1, ICallback p2);

	[Register("useAnimation", "()Lcom/yandex/mapkit/map/PlacemarkAnimation;", "GetUseAnimationHandler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	IPlacemarkAnimation UseAnimation();

	[Register("useCompositeIcon", "()Lcom/yandex/mapkit/map/CompositeIcon;", "GetUseCompositeIconHandler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	ICompositeIcon UseCompositeIcon();

	[Register("useIcon", "()Lcom/yandex/mapkit/map/Icon;", "GetUseIconHandler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	IIcon UseIcon();

	[Register("useModel", "()Lcom/yandex/mapkit/map/Model;", "GetUseModelHandler:Com.Yandex.Mapkit.Map.IPlacemarkMapObjectInvoker, Yandex.MapKit.Lite")]
	IModel UseModel();
}
