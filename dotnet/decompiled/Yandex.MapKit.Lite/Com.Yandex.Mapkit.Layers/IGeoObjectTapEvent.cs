using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/GeoObjectTapEvent", "", "Com.Yandex.Mapkit.Layers.IGeoObjectTapEventInvoker")]
public interface IGeoObjectTapEvent : IJavaObject, IDisposable, IJavaPeerable
{
	GeoObject GeoObject
	{
		[Register("getGeoObject", "()Lcom/yandex/mapkit/GeoObject;", "GetGetGeoObjectHandler:Com.Yandex.Mapkit.Layers.IGeoObjectTapEventInvoker, Yandex.MapKit.Lite")]
		get;
	}

	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Layers.IGeoObjectTapEventInvoker, Yandex.MapKit.Lite")]
		get;
	}
}
