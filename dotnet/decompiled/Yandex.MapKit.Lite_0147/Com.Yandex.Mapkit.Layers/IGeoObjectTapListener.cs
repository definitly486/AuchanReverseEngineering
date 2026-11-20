using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/GeoObjectTapListener", "", "Com.Yandex.Mapkit.Layers.IGeoObjectTapListenerInvoker")]
public interface IGeoObjectTapListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onObjectTap", "(Lcom/yandex/mapkit/layers/GeoObjectTapEvent;)Z", "GetOnObjectTap_Lcom_yandex_mapkit_layers_GeoObjectTapEvent_Handler:Com.Yandex.Mapkit.Layers.IGeoObjectTapListenerInvoker, Yandex.MapKit.Lite")]
	bool OnObjectTap(IGeoObjectTapEvent p0);
}
