using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Offline_cache;

[Register("com/yandex/mapkit/offline_cache/RegionListener", "", "Com.Yandex.Mapkit.Offline_cache.IRegionListenerInvoker")]
public interface IRegionListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onRegionProgress", "(I)V", "GetOnRegionProgress_IHandler:Com.Yandex.Mapkit.Offline_cache.IRegionListenerInvoker, Yandex.MapKit.Lite")]
	void OnRegionProgress(int p0);

	[Register("onRegionStateChanged", "(I)V", "GetOnRegionStateChanged_IHandler:Com.Yandex.Mapkit.Offline_cache.IRegionListenerInvoker, Yandex.MapKit.Lite")]
	void OnRegionStateChanged(int p0);
}
