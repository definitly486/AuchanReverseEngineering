using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PlacemarkCreatedCallback", "", "Com.Yandex.Mapkit.Map.IPlacemarkCreatedCallbackInvoker")]
public interface IPlacemarkCreatedCallback : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onPlacemarkCreated", "(Lcom/yandex/mapkit/map/PlacemarkMapObject;)V", "GetOnPlacemarkCreated_Lcom_yandex_mapkit_map_PlacemarkMapObject_Handler:Com.Yandex.Mapkit.Map.IPlacemarkCreatedCallbackInvoker, Yandex.MapKit.Lite")]
	void OnPlacemarkCreated(IPlacemarkMapObject p0);
}
