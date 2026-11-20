using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Logo;

[Register("com/yandex/mapkit/logo/Logo", "", "Com.Yandex.Mapkit.Logo.ILogoInvoker")]
public interface ILogo : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Logo.ILogoInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("setAlignment", "(Lcom/yandex/mapkit/logo/Alignment;)V", "GetSetAlignment_Lcom_yandex_mapkit_logo_Alignment_Handler:Com.Yandex.Mapkit.Logo.ILogoInvoker, Yandex.MapKit.Lite")]
	void SetAlignment(Alignment p0);

	[Register("setPadding", "(Lcom/yandex/mapkit/logo/Padding;)V", "GetSetPadding_Lcom_yandex_mapkit_logo_Padding_Handler:Com.Yandex.Mapkit.Logo.ILogoInvoker, Yandex.MapKit.Lite")]
	void SetPadding(Padding p0);
}
