using System;
using Android.Runtime;
using Com.Yandex.Mapkit.Images;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/BaseDataSourceBuilder", "", "Com.Yandex.Mapkit.Map.IBaseDataSourceBuilderInvoker")]
public interface IBaseDataSourceBuilder : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Map.IBaseDataSourceBuilderInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("setImageUrlProvider", "(Lcom/yandex/mapkit/images/ImageUrlProvider;)V", "GetSetImageUrlProvider_Lcom_yandex_mapkit_images_ImageUrlProvider_Handler:Com.Yandex.Mapkit.Map.IBaseDataSourceBuilderInvoker, Yandex.MapKit.Lite")]
	void SetImageUrlProvider(IImageUrlProvider p0);
}
