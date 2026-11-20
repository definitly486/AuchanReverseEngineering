using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/RootMapObjectCollection", "", "Com.Yandex.Mapkit.Map.IRootMapObjectCollectionInvoker")]
public interface IRootMapObjectCollection : IMapObjectCollection, IBaseMapObjectCollection, IMapObject, IJavaObject, IDisposable, IJavaPeerable
{
	ConflictResolutionMode ConflictResolutionMode
	{
		[Register("getConflictResolutionMode", "()Lcom/yandex/mapkit/ConflictResolutionMode;", "GetGetConflictResolutionModeHandler:Com.Yandex.Mapkit.Map.IRootMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setConflictResolutionMode", "(Lcom/yandex/mapkit/ConflictResolutionMode;)V", "GetSetConflictResolutionMode_Lcom_yandex_mapkit_ConflictResolutionMode_Handler:Com.Yandex.Mapkit.Map.IRootMapObjectCollectionInvoker, Yandex.MapKit.Lite")]
		set;
	}
}
