using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/DummyLocationManager", "", "Com.Yandex.Mapkit.Location.IDummyLocationManagerInvoker")]
public interface IDummyLocationManager : ILocationManager, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("setLocation", "(Lcom/yandex/mapkit/location/Location;Lcom/yandex/mapkit/location/DummyLocationQuality;)V", "GetSetLocation_Lcom_yandex_mapkit_location_Location_Lcom_yandex_mapkit_location_DummyLocationQuality_Handler:Com.Yandex.Mapkit.Location.IDummyLocationManagerInvoker, Yandex.MapKit.Lite")]
	void SetLocation(Location p0, DummyLocationQuality p1);
}
