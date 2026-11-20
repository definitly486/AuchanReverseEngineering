using System;
using Android.Runtime;
using Com.Yandex.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/Model", "", "Com.Yandex.Mapkit.Map.IModelInvoker")]
public interface IModel : IPlacemarkPresentation, IJavaObject, IDisposable, IJavaPeerable
{
	ModelStyle ModelStyle
	{
		[Register("getModelStyle", "()Lcom/yandex/mapkit/map/ModelStyle;", "GetGetModelStyleHandler:Com.Yandex.Mapkit.Map.IModelInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setModelStyle", "(Lcom/yandex/mapkit/map/ModelStyle;)V", "GetSetModelStyle_Lcom_yandex_mapkit_map_ModelStyle_Handler:Com.Yandex.Mapkit.Map.IModelInvoker, Yandex.MapKit.Lite")]
		set;
	}

	[Register("setData", "(Lcom/yandex/runtime/DataProviderWithId;Lcom/yandex/mapkit/map/Callback;)V", "GetSetData_Lcom_yandex_runtime_DataProviderWithId_Lcom_yandex_mapkit_map_Callback_Handler:Com.Yandex.Mapkit.Map.IModelInvoker, Yandex.MapKit.Lite")]
	void SetData(IDataProviderWithId p0, ICallback p1);
}
