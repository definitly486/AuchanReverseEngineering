using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/LocationSimulatorListener", "", "Com.Yandex.Mapkit.Location.ILocationSimulatorListenerInvoker")]
public interface ILocationSimulatorListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onSimulationFinished", "()V", "GetOnSimulationFinishedHandler:Com.Yandex.Mapkit.Location.ILocationSimulatorListenerInvoker, Yandex.MapKit.Lite")]
	void OnSimulationFinished();
}
