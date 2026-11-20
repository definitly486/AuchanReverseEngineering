using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PlacemarkPresentation", "", "Com.Yandex.Mapkit.Map.IPlacemarkPresentationInvoker")]
public interface IPlacemarkPresentation : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Map.IPlacemarkPresentationInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("remove", "()V", "GetRemoveHandler:Com.Yandex.Mapkit.Map.IPlacemarkPresentationInvoker, Yandex.MapKit.Lite")]
	void Remove();
}
