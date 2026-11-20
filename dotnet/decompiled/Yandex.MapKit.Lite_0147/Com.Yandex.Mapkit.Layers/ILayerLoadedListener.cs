using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/LayerLoadedListener", "", "Com.Yandex.Mapkit.Layers.ILayerLoadedListenerInvoker")]
public interface ILayerLoadedListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onLayerLoaded", "()V", "GetOnLayerLoadedHandler:Com.Yandex.Mapkit.Layers.ILayerLoadedListenerInvoker, Yandex.MapKit.Lite")]
	void OnLayerLoaded();
}
