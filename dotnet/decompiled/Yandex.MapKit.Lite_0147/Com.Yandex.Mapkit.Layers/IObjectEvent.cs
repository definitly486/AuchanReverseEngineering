using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/ObjectEvent", "", "Com.Yandex.Mapkit.Layers.IObjectEventInvoker")]
public interface IObjectEvent : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Layers.IObjectEventInvoker, Yandex.MapKit.Lite")]
		get;
	}
}
