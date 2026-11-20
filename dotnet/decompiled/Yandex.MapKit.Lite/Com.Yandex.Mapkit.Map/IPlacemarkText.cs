using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PlacemarkText", "", "Com.Yandex.Mapkit.Map.IPlacemarkTextInvoker")]
public interface IPlacemarkText : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Map.IPlacemarkTextInvoker, Yandex.MapKit.Lite")]
		get;
	}

	TextStyle Style
	{
		[Register("getStyle", "()Lcom/yandex/mapkit/map/TextStyle;", "GetGetStyleHandler:Com.Yandex.Mapkit.Map.IPlacemarkTextInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setStyle", "(Lcom/yandex/mapkit/map/TextStyle;)V", "GetSetStyle_Lcom_yandex_mapkit_map_TextStyle_Handler:Com.Yandex.Mapkit.Map.IPlacemarkTextInvoker, Yandex.MapKit.Lite")]
		set;
	}

	string Text
	{
		[Register("getText", "()Ljava/lang/String;", "GetGetTextHandler:Com.Yandex.Mapkit.Map.IPlacemarkTextInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setText", "(Ljava/lang/String;)V", "GetSetText_Ljava_lang_String_Handler:Com.Yandex.Mapkit.Map.IPlacemarkTextInvoker, Yandex.MapKit.Lite")]
		set;
	}
}
