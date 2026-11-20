using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/DataSourceLayer", "", "Com.Yandex.Mapkit.Layers.IDataSourceLayerInvoker")]
public interface IDataSourceLayer : IJavaObject, IDisposable, IJavaPeerable
{
	bool Active
	{
		[Register("isActive", "()Z", "GetIsActiveHandler:Com.Yandex.Mapkit.Layers.IDataSourceLayerInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setActive", "(Z)V", "GetSetActive_ZHandler:Com.Yandex.Mapkit.Layers.IDataSourceLayerInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Layers.IDataSourceLayerInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("clear", "()V", "GetClearHandler:Com.Yandex.Mapkit.Layers.IDataSourceLayerInvoker, Yandex.MapKit.Lite")]
	void Clear();

	[Register("remove", "()V", "GetRemoveHandler:Com.Yandex.Mapkit.Layers.IDataSourceLayerInvoker, Yandex.MapKit.Lite")]
	void Remove();

	[Register("resetStyles", "()V", "GetResetStylesHandler:Com.Yandex.Mapkit.Layers.IDataSourceLayerInvoker, Yandex.MapKit.Lite")]
	void ResetStyles();

	[Register("setDataSourceListener", "(Lcom/yandex/mapkit/layers/DataSourceListener;)V", "GetSetDataSourceListener_Lcom_yandex_mapkit_layers_DataSourceListener_Handler:Com.Yandex.Mapkit.Layers.IDataSourceLayerInvoker, Yandex.MapKit.Lite")]
	void SetDataSourceListener(IDataSourceListener? p0);

	[Register("setLayerLoadedListener", "(Lcom/yandex/mapkit/layers/LayerLoadedListener;)V", "GetSetLayerLoadedListener_Lcom_yandex_mapkit_layers_LayerLoadedListener_Handler:Com.Yandex.Mapkit.Layers.IDataSourceLayerInvoker, Yandex.MapKit.Lite")]
	void SetLayerLoadedListener(ILayerLoadedListener? p0);

	[Register("setStyle", "(ILjava/lang/String;)Z", "GetSetStyle_ILjava_lang_String_Handler:Com.Yandex.Mapkit.Layers.IDataSourceLayerInvoker, Yandex.MapKit.Lite")]
	bool SetStyle(int p0, string p1);
}
