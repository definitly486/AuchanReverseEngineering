using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PlacemarksStyler", "", "Com.Yandex.Mapkit.Map.IPlacemarksStylerInvoker")]
public interface IPlacemarksStyler : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Map.IPlacemarksStylerInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("setScaleFunction", "(Ljava/util/List;)V", "GetSetScaleFunction_Ljava_util_List_Handler:Com.Yandex.Mapkit.Map.IPlacemarksStylerInvoker, Yandex.MapKit.Lite")]
	void SetScaleFunction(IList<PointF> p0);
}
