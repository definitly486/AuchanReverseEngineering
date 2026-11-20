using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/Callback", "", "Com.Yandex.Mapkit.Map.ICallbackInvoker")]
public interface ICallback : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onTaskFinished", "()V", "GetOnTaskFinishedHandler:Com.Yandex.Mapkit.Map.ICallbackInvoker, Yandex.MapKit.Lite")]
	void OnTaskFinished();
}
