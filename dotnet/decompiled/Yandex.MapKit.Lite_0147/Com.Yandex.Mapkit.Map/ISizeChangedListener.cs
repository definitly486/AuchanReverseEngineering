using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/SizeChangedListener", "", "Com.Yandex.Mapkit.Map.ISizeChangedListenerInvoker")]
public interface ISizeChangedListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onMapWindowSizeChanged", "(Lcom/yandex/mapkit/map/MapWindow;II)V", "GetOnMapWindowSizeChanged_Lcom_yandex_mapkit_map_MapWindow_IIHandler:Com.Yandex.Mapkit.Map.ISizeChangedListenerInvoker, Yandex.MapKit.Lite")]
	void OnMapWindowSizeChanged(IMapWindow p0, int p1, int p2);
}
