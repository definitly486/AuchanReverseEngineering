using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Images;

[Register("com/yandex/mapkit/images/ImageUrlProvider", "", "Com.Yandex.Mapkit.Images.IImageUrlProviderInvoker")]
public interface IImageUrlProvider : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("formatUrl", "(Lcom/yandex/mapkit/images/ImageDataDescriptor;)Ljava/lang/String;", "GetFormatUrl_Lcom_yandex_mapkit_images_ImageDataDescriptor_Handler:Com.Yandex.Mapkit.Images.IImageUrlProviderInvoker, Yandex.MapKit.Lite")]
	string FormatUrl(ImageDataDescriptor p0);
}
