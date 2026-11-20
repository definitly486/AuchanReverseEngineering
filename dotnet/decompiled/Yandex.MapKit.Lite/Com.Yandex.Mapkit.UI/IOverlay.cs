using System;
using Android.Runtime;
using Com.Yandex.Runtime.Image;
using Com.Yandex.Runtime.Ui_view;
using Java.Interop;

namespace Com.Yandex.Mapkit.UI;

[Register("com/yandex/mapkit/ui/Overlay", "", "Com.Yandex.Mapkit.UI.IOverlayInvoker")]
public interface IOverlay : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.UI.IOverlayInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("remove", "()V", "GetRemoveHandler:Com.Yandex.Mapkit.UI.IOverlayInvoker, Yandex.MapKit.Lite")]
	void Remove();

	[Register("setImage", "(Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/ScreenRect;)V", "GetSetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_ScreenRect_Handler:Com.Yandex.Mapkit.UI.IOverlayInvoker, Yandex.MapKit.Lite")]
	void SetImage(ImageProvider p0, ScreenRect p1);

	[Register("setView", "(Lcom/yandex/runtime/ui_view/ViewProvider;Lcom/yandex/mapkit/ScreenRect;)V", "GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_ScreenRect_Handler:Com.Yandex.Mapkit.UI.IOverlayInvoker, Yandex.MapKit.Lite")]
	void SetView(ViewProvider p0, ScreenRect p1);
}
