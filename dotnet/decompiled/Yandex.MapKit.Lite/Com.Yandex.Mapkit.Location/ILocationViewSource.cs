using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/LocationViewSource", "", "Com.Yandex.Mapkit.Location.ILocationViewSourceInvoker")]
public interface ILocationViewSource : IJavaObject, IDisposable, IJavaPeerable
{
}
