using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/ClusterListener", "", "Com.Yandex.Mapkit.Map.IClusterListenerInvoker")]
public interface IClusterListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onClusterAdded", "(Lcom/yandex/mapkit/map/Cluster;)V", "GetOnClusterAdded_Lcom_yandex_mapkit_map_Cluster_Handler:Com.Yandex.Mapkit.Map.IClusterListenerInvoker, Yandex.MapKit.Lite")]
	void OnClusterAdded(ICluster p0);
}
