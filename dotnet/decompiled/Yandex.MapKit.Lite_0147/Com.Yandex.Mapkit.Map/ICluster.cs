using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/Cluster", "", "Com.Yandex.Mapkit.Map.IClusterInvoker")]
public interface ICluster : IJavaObject, IDisposable, IJavaPeerable
{
	IPlacemarkMapObject Appearance
	{
		[Register("getAppearance", "()Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetGetAppearanceHandler:Com.Yandex.Mapkit.Map.IClusterInvoker, Yandex.MapKit.Lite")]
		get;
	}

	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Map.IClusterInvoker, Yandex.MapKit.Lite")]
		get;
	}

	IList<IPlacemarkMapObject> Placemarks
	{
		[Register("getPlacemarks", "()Ljava/util/List;", "GetGetPlacemarksHandler:Com.Yandex.Mapkit.Map.IClusterInvoker, Yandex.MapKit.Lite")]
		get;
	}

	int Size
	{
		[Register("getSize", "()I", "GetGetSizeHandler:Com.Yandex.Mapkit.Map.IClusterInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("addClusterTapListener", "(Lcom/yandex/mapkit/map/ClusterTapListener;)V", "GetAddClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener_Handler:Com.Yandex.Mapkit.Map.IClusterInvoker, Yandex.MapKit.Lite")]
	void AddClusterTapListener(IClusterTapListener p0);

	[Register("removeClusterTapListener", "(Lcom/yandex/mapkit/map/ClusterTapListener;)V", "GetRemoveClusterTapListener_Lcom_yandex_mapkit_map_ClusterTapListener_Handler:Com.Yandex.Mapkit.Map.IClusterInvoker, Yandex.MapKit.Lite")]
	void RemoveClusterTapListener(IClusterTapListener p0);
}
