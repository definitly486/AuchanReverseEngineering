using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Offline_cache;

[Register("com/yandex/mapkit/offline_cache/RegionListUpdatesListener", "", "Com.Yandex.Mapkit.Offline_cache.IRegionListUpdatesListenerInvoker")]
public interface IRegionListUpdatesListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onListUpdated", "()V", "GetOnListUpdatedHandler:Com.Yandex.Mapkit.Offline_cache.IRegionListUpdatesListenerInvoker, Yandex.MapKit.Lite")]
	void OnListUpdated();
}
