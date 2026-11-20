using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/BaseMapObjectCollection", "", "Com.Yandex.Mapkit.Map.IBaseMapObjectCollectionInvoker")]
public interface IBaseMapObjectCollection : IMapObject, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("addListener", "(Lcom/yandex/mapkit/map/MapObjectCollectionListener;)V", "GetAddListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener_Handler:Com.Yandex.Mapkit.Map.IBaseMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	void AddListener(IMapObjectCollectionListener p0);

	[Register("clear", "()V", "GetClearHandler:Com.Yandex.Mapkit.Map.IBaseMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	void Clear();

	[Register("remove", "(Lcom/yandex/mapkit/map/MapObject;)V", "GetRemove_Lcom_yandex_mapkit_map_MapObject_Handler:Com.Yandex.Mapkit.Map.IBaseMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	void Remove(IMapObject p0);

	[Register("removeListener", "(Lcom/yandex/mapkit/map/MapObjectCollectionListener;)V", "GetRemoveListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener_Handler:Com.Yandex.Mapkit.Map.IBaseMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	void RemoveListener(IMapObjectCollectionListener p0);

	[Register("traverse", "(Lcom/yandex/mapkit/map/MapObjectVisitor;)V", "GetTraverse_Lcom_yandex_mapkit_map_MapObjectVisitor_Handler:Com.Yandex.Mapkit.Map.IBaseMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
	void Traverse(IMapObjectVisitor p0);
}
