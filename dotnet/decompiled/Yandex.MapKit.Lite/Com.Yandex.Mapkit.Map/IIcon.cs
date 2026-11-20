using System;
using Android.Runtime;
using Com.Yandex.Runtime.Image;
using Com.Yandex.Runtime.Ui_view;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/Icon", "", "Com.Yandex.Mapkit.Map.IIconInvoker")]
public interface IIcon : IPlacemarkPresentation, IJavaObject, IDisposable, IJavaPeerable
{
	IconStyle Style
	{
		[Register("getStyle", "()Lcom/yandex/mapkit/map/IconStyle;", "GetGetStyleHandler:Com.Yandex.Mapkit.Map.IIconInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setStyle", "(Lcom/yandex/mapkit/map/IconStyle;)V", "GetSetStyle_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IIconInvoker, Yandex.MapKit.Lite")]
		set;
	}

	[Register("setImage", "(Lcom/yandex/runtime/image/ImageProvider;)V", "GetSetImage_Lcom_yandex_runtime_image_ImageProvider_Handler:Com.Yandex.Mapkit.Map.IIconInvoker, Yandex.MapKit.Lite")]
	void SetImage(ImageProvider p0);

	[Register("setImage", "(Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;)V", "GetSetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IIconInvoker, Yandex.MapKit.Lite")]
	void SetImage(ImageProvider p0, IconStyle p1);

	[Register("setImage", "(Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;Lcom/yandex/mapkit/map/Callback;)V", "GetSetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_Handler:Com.Yandex.Mapkit.Map.IIconInvoker, Yandex.MapKit.Lite")]
	void SetImage(ImageProvider p0, IconStyle p1, ICallback p2);

	[Register("setView", "(Lcom/yandex/runtime/ui_view/ViewProvider;)V", "GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Handler:Com.Yandex.Mapkit.Map.IIconInvoker, Yandex.MapKit.Lite")]
	void SetView(ViewProvider p0);

	[Register("setView", "(Lcom/yandex/runtime/ui_view/ViewProvider;Lcom/yandex/mapkit/map/IconStyle;)V", "GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IIconInvoker, Yandex.MapKit.Lite")]
	void SetView(ViewProvider p0, IconStyle p1);

	[Register("setView", "(Lcom/yandex/runtime/ui_view/ViewProvider;Lcom/yandex/mapkit/map/IconStyle;Lcom/yandex/mapkit/map/Callback;)V", "GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_Handler:Com.Yandex.Mapkit.Map.IIconInvoker, Yandex.MapKit.Lite")]
	void SetView(ViewProvider p0, IconStyle p1, ICallback p2);
}
