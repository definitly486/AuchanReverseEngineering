using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/ClusterTapListener", "", "Com.Yandex.Mapkit.Map.IClusterTapListenerInvoker")]
public interface IClusterTapListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onClusterTap", "(Lcom/yandex/mapkit/map/Cluster;)Z", "GetOnClusterTap_Lcom_yandex_mapkit_map_Cluster_Handler:Com.Yandex.Mapkit.Map.IClusterTapListenerInvoker, Yandex.MapKit.Lite")]
	bool OnClusterTap(ICluster p0);
}
