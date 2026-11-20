using System;
using Android.Runtime;
using Com.Yandex.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Offline_cache;

[Register("com/yandex/mapkit/offline_cache/DataMoveListener", "", "Com.Yandex.Mapkit.Offline_cache.IDataMoveListenerInvoker")]
public interface IDataMoveListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onDataMoveCompleted", "()V", "GetOnDataMoveCompletedHandler:Com.Yandex.Mapkit.Offline_cache.IDataMoveListenerInvoker, Yandex.MapKit.Lite")]
	void OnDataMoveCompleted();

	[Register("onDataMoveError", "(Lcom/yandex/runtime/Error;)V", "GetOnDataMoveError_Lcom_yandex_runtime_Error_Handler:Com.Yandex.Mapkit.Offline_cache.IDataMoveListenerInvoker, Yandex.MapKit.Lite")]
	void OnDataMoveError(IError p0);

	[Register("onDataMoveProgress", "(I)V", "GetOnDataMoveProgress_IHandler:Com.Yandex.Mapkit.Offline_cache.IDataMoveListenerInvoker, Yandex.MapKit.Lite")]
	void OnDataMoveProgress(int p0);
}
