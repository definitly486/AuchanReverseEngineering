using System;
using Android.Runtime;
using Com.Yandex.Runtime.Image;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/CompositeIcon", "", "Com.Yandex.Mapkit.Map.ICompositeIconInvoker")]
public interface ICompositeIcon : IPlacemarkPresentation, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("icon", "(Ljava/lang/String;)Lcom/yandex/mapkit/map/Icon;", "GetIcon_Ljava_lang_String_Handler:Com.Yandex.Mapkit.Map.ICompositeIconInvoker, Yandex.MapKit.Lite")]
	IIcon Icon(string p0);

	[Register("removeAll", "()V", "GetRemoveAllHandler:Com.Yandex.Mapkit.Map.ICompositeIconInvoker, Yandex.MapKit.Lite")]
	void RemoveAll();

	[Register("removeIcon", "(Ljava/lang/String;)V", "GetRemoveIcon_Ljava_lang_String_Handler:Com.Yandex.Mapkit.Map.ICompositeIconInvoker, Yandex.MapKit.Lite")]
	void RemoveIcon(string p0);

	[Register("setIcon", "(Ljava/lang/String;Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;)V", "GetSetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.ICompositeIconInvoker, Yandex.MapKit.Lite")]
	void SetIcon(string p0, ImageProvider p1, IconStyle p2);

	[Register("setIcon", "(Ljava/lang/String;Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;Lcom/yandex/mapkit/map/Callback;)V", "GetSetIcon_Ljava_lang_String_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_Handler:Com.Yandex.Mapkit.Map.ICompositeIconInvoker, Yandex.MapKit.Lite")]
	void SetIcon(string p0, ImageProvider p1, IconStyle p2, ICallback p3);

	[Register("setIconStyle", "(Ljava/lang/String;Lcom/yandex/mapkit/map/IconStyle;)V", "GetSetIconStyle_Ljava_lang_String_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.ICompositeIconInvoker, Yandex.MapKit.Lite")]
	void SetIconStyle(string p0, IconStyle p1);
}
