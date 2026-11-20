using System;
using Android.Runtime;
using Com.Yandex.Mapkit.Map;
using Java.Interop;

namespace Com.Yandex.Mapkit.User_location;

[Register("com/yandex/mapkit/user_location/UserLocationView", "", "Com.Yandex.Mapkit.User_location.IUserLocationViewInvoker")]
public interface IUserLocationView : IJavaObject, IDisposable, IJavaPeerable
{
	ICircleMapObject AccuracyCircle
	{
		[Register("getAccuracyCircle", "()Lcom/yandex/mapkit/map/CircleMapObject;", "GetGetAccuracyCircleHandler:Com.Yandex.Mapkit.User_location.IUserLocationViewInvoker, Yandex.MapKit.Lite")]
		get;
	}

	IPlacemarkMapObject Arrow
	{
		[Register("getArrow", "()Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetGetArrowHandler:Com.Yandex.Mapkit.User_location.IUserLocationViewInvoker, Yandex.MapKit.Lite")]
		get;
	}

	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.User_location.IUserLocationViewInvoker, Yandex.MapKit.Lite")]
		get;
	}

	IPlacemarkMapObject Pin
	{
		[Register("getPin", "()Lcom/yandex/mapkit/map/PlacemarkMapObject;", "GetGetPinHandler:Com.Yandex.Mapkit.User_location.IUserLocationViewInvoker, Yandex.MapKit.Lite")]
		get;
	}
}
