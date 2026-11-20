using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapLoadedListener", "", "Com.Yandex.Mapkit.Map.IMapLoadedListenerInvoker")]
public interface IMapLoadedListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onMapLoaded", "(Lcom/yandex/mapkit/map/MapLoadStatistics;)V", "GetOnMapLoaded_Lcom_yandex_mapkit_map_MapLoadStatistics_Handler:Com.Yandex.Mapkit.Map.IMapLoadedListenerInvoker, Yandex.MapKit.Lite")]
	void OnMapLoaded(MapLoadStatistics p0);
}
