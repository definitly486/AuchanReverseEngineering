using System;
using Android.Runtime;
using Com.Yandex.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Storage;

[Register("com/yandex/mapkit/storage/StorageErrorListener", "", "Com.Yandex.Mapkit.Storage.IStorageErrorListenerInvoker")]
public interface IStorageErrorListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onStorageError", "(Lcom/yandex/runtime/LocalError;)V", "GetOnStorageError_Lcom_yandex_runtime_LocalError_Handler:Com.Yandex.Mapkit.Storage.IStorageErrorListenerInvoker, Yandex.MapKit.Lite")]
	void OnStorageError(ILocalError p0);
}
