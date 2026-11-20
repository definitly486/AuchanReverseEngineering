using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapObjectCollectionListener", "", "Com.Yandex.Mapkit.Map.IMapObjectCollectionListenerInvoker")]
public interface IMapObjectCollectionListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onMapObjectAdded", "(Lcom/yandex/mapkit/map/MapObject;)V", "GetOnMapObjectAdded_Lcom_yandex_mapkit_map_MapObject_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionListenerInvoker, Yandex.MapKit.Lite")]
	void OnMapObjectAdded(IMapObject p0);

	[Register("onMapObjectRemoved", "(Lcom/yandex/mapkit/map/MapObject;)V", "GetOnMapObjectRemoved_Lcom_yandex_mapkit_map_MapObject_Handler:Com.Yandex.Mapkit.Map.IMapObjectCollectionListenerInvoker, Yandex.MapKit.Lite")]
	void OnMapObjectRemoved(IMapObject p0);
}
