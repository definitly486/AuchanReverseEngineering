using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/Layer", "", "Com.Yandex.Mapkit.Layers.ILayerInvoker")]
public interface ILayer : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Layers.ILayerInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("dataSourceLayer", "()Lcom/yandex/mapkit/layers/DataSourceLayer;", "GetDataSourceLayerHandler:Com.Yandex.Mapkit.Layers.ILayerInvoker, Yandex.MapKit.Lite")]
	IDataSourceLayer DataSourceLayer();

	[Register("remove", "()V", "GetRemoveHandler:Com.Yandex.Mapkit.Layers.ILayerInvoker, Yandex.MapKit.Lite")]
	void Remove();
}
