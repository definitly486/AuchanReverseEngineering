using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Traffic;

[Register("com/yandex/mapkit/traffic/TrafficListener", "", "Com.Yandex.Mapkit.Traffic.ITrafficListenerInvoker")]
public interface ITrafficListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onTrafficChanged", "(Lcom/yandex/mapkit/traffic/TrafficLevel;)V", "GetOnTrafficChanged_Lcom_yandex_mapkit_traffic_TrafficLevel_Handler:Com.Yandex.Mapkit.Traffic.ITrafficListenerInvoker, Yandex.MapKit.Lite")]
	void OnTrafficChanged(TrafficLevel? p0);

	[Register("onTrafficExpired", "()V", "GetOnTrafficExpiredHandler:Com.Yandex.Mapkit.Traffic.ITrafficListenerInvoker, Yandex.MapKit.Lite")]
	void OnTrafficExpired();

	[Register("onTrafficLoading", "()V", "GetOnTrafficLoadingHandler:Com.Yandex.Mapkit.Traffic.ITrafficListenerInvoker, Yandex.MapKit.Lite")]
	void OnTrafficLoading();
}
