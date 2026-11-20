using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/BaseDataSource", "", "Com.Yandex.Mapkit.Layers.IBaseDataSourceInvoker")]
public interface IBaseDataSource : IJavaObject, IDisposable, IJavaPeerable
{
	string Id
	{
		[Register("getId", "()Ljava/lang/String;", "GetGetIdHandler:Com.Yandex.Mapkit.Layers.IBaseDataSourceInvoker, Yandex.MapKit.Lite")]
		get;
	}

	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Layers.IBaseDataSourceInvoker, Yandex.MapKit.Lite")]
		get;
	}
}
