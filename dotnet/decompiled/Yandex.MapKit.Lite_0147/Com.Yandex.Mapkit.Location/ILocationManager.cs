using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/LocationManager", "", "Com.Yandex.Mapkit.Location.ILocationManagerInvoker")]
public interface ILocationManager : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("requestSingleUpdate", "(Lcom/yandex/mapkit/location/LocationListener;)V", "GetRequestSingleUpdate_Lcom_yandex_mapkit_location_LocationListener_Handler:Com.Yandex.Mapkit.Location.ILocationManagerInvoker, Yandex.MapKit.Lite")]
	void RequestSingleUpdate(ILocationListener p0);

	[Register("resume", "()V", "GetResumeHandler:Com.Yandex.Mapkit.Location.ILocationManagerInvoker, Yandex.MapKit.Lite")]
	void Resume();

	[Register("subscribeForLocationUpdates", "(Lcom/yandex/mapkit/location/SubscriptionSettings;Lcom/yandex/mapkit/location/LocationListener;)V", "GetSubscribeForLocationUpdates_Lcom_yandex_mapkit_location_SubscriptionSettings_Lcom_yandex_mapkit_location_LocationListener_Handler:Com.Yandex.Mapkit.Location.ILocationManagerInvoker, Yandex.MapKit.Lite")]
	void SubscribeForLocationUpdates(SubscriptionSettings p0, ILocationListener p1);

	[Register("suspend", "()V", "GetSuspendHandler:Com.Yandex.Mapkit.Location.ILocationManagerInvoker, Yandex.MapKit.Lite")]
	void Suspend();

	[Register("unsubscribe", "(Lcom/yandex/mapkit/location/LocationListener;)V", "GetUnsubscribe_Lcom_yandex_mapkit_location_LocationListener_Handler:Com.Yandex.Mapkit.Location.ILocationManagerInvoker, Yandex.MapKit.Lite")]
	void Unsubscribe(ILocationListener p0);
}
