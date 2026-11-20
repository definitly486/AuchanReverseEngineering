using System;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;

namespace Com.Yandex.Mapkit.User_location;

[Register("com/yandex/mapkit/user_location/UserLocationTapListener", "", "Com.Yandex.Mapkit.User_location.IUserLocationTapListenerInvoker")]
public interface IUserLocationTapListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onUserLocationObjectTap", "(Lcom/yandex/mapkit/geometry/Point;)V", "GetOnUserLocationObjectTap_Lcom_yandex_mapkit_geometry_Point_Handler:Com.Yandex.Mapkit.User_location.IUserLocationTapListenerInvoker, Yandex.MapKit.Lite")]
	void OnUserLocationObjectTap(Point p0);
}
