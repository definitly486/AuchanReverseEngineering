using System;
using Android.Runtime;
using Com.Yandex.Mapkit.Layers;
using Java.Interop;

namespace Com.Yandex.Mapkit.User_location;

[Register("com/yandex/mapkit/user_location/UserLocationObjectListener", "", "Com.Yandex.Mapkit.User_location.IUserLocationObjectListenerInvoker")]
public interface IUserLocationObjectListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onObjectAdded", "(Lcom/yandex/mapkit/user_location/UserLocationView;)V", "GetOnObjectAdded_Lcom_yandex_mapkit_user_location_UserLocationView_Handler:Com.Yandex.Mapkit.User_location.IUserLocationObjectListenerInvoker, Yandex.MapKit.Lite")]
	void OnObjectAdded(IUserLocationView p0);

	[Register("onObjectRemoved", "(Lcom/yandex/mapkit/user_location/UserLocationView;)V", "GetOnObjectRemoved_Lcom_yandex_mapkit_user_location_UserLocationView_Handler:Com.Yandex.Mapkit.User_location.IUserLocationObjectListenerInvoker, Yandex.MapKit.Lite")]
	void OnObjectRemoved(IUserLocationView p0);

	[Register("onObjectUpdated", "(Lcom/yandex/mapkit/user_location/UserLocationView;Lcom/yandex/mapkit/layers/ObjectEvent;)V", "GetOnObjectUpdated_Lcom_yandex_mapkit_user_location_UserLocationView_Lcom_yandex_mapkit_layers_ObjectEvent_Handler:Com.Yandex.Mapkit.User_location.IUserLocationObjectListenerInvoker, Yandex.MapKit.Lite")]
	void OnObjectUpdated(IUserLocationView p0, IObjectEvent p1);
}
