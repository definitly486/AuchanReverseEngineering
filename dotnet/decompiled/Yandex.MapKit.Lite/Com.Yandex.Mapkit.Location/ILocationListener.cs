using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/LocationListener", "", "Com.Yandex.Mapkit.Location.ILocationListenerInvoker")]
public interface ILocationListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onLocationStatusUpdated", "(Lcom/yandex/mapkit/location/LocationStatus;)V", "GetOnLocationStatusUpdated_Lcom_yandex_mapkit_location_LocationStatus_Handler:Com.Yandex.Mapkit.Location.ILocationListenerInvoker, Yandex.MapKit.Lite")]
	void OnLocationStatusUpdated(LocationStatus p0);

	[Register("onLocationUpdated", "(Lcom/yandex/mapkit/location/Location;)V", "GetOnLocationUpdated_Lcom_yandex_mapkit_location_Location_Handler:Com.Yandex.Mapkit.Location.ILocationListenerInvoker, Yandex.MapKit.Lite")]
	void OnLocationUpdated(Location p0);
}
