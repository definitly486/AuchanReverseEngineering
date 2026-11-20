using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/DataSourceListener", "", "Com.Yandex.Mapkit.Layers.IDataSourceListenerInvoker")]
public interface IDataSourceListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onDataSourceUpdated", "(Lcom/yandex/mapkit/layers/BaseDataSource;)V", "GetOnDataSourceUpdated_Lcom_yandex_mapkit_layers_BaseDataSource_Handler:Com.Yandex.Mapkit.Layers.IDataSourceListenerInvoker, Yandex.MapKit.Lite")]
	void OnDataSourceUpdated(IBaseDataSource p0);
}
