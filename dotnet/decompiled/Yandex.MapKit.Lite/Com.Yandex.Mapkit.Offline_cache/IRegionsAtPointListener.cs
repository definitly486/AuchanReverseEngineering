using System;
using System.Collections.Generic;
using Android.Runtime;
using Com.Yandex.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Offline_cache;

[Register("com/yandex/mapkit/offline_cache/RegionsAtPointListener", "", "Com.Yandex.Mapkit.Offline_cache.IRegionsAtPointListenerInvoker")]
public interface IRegionsAtPointListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onError", "(Lcom/yandex/runtime/Error;)V", "GetOnError_Lcom_yandex_runtime_Error_Handler:Com.Yandex.Mapkit.Offline_cache.IRegionsAtPointListenerInvoker, Yandex.MapKit.Lite")]
	void OnError(IError p0);

	[Register("onRegions", "(Ljava/util/List;)V", "GetOnRegions_Ljava_util_List_Handler:Com.Yandex.Mapkit.Offline_cache.IRegionsAtPointListenerInvoker, Yandex.MapKit.Lite")]
	void OnRegions(IList<Integer> p0);
}
