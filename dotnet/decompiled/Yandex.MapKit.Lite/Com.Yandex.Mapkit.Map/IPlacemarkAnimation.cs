using System;
using Android.Runtime;
using Com.Yandex.Runtime.Image;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PlacemarkAnimation", "", "Com.Yandex.Mapkit.Map.IPlacemarkAnimationInvoker")]
public interface IPlacemarkAnimation : IPlacemarkPresentation, IJavaObject, IDisposable, IJavaPeerable
{
	bool Reversed
	{
		[Register("isReversed", "()Z", "GetIsReversedHandler:Com.Yandex.Mapkit.Map.IPlacemarkAnimationInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setReversed", "(Z)V", "GetSetReversed_ZHandler:Com.Yandex.Mapkit.Map.IPlacemarkAnimationInvoker, Yandex.MapKit.Lite")]
		set;
	}

	[Register("pause", "()V", "GetPauseHandler:Com.Yandex.Mapkit.Map.IPlacemarkAnimationInvoker, Yandex.MapKit.Lite")]
	void Pause();

	[Register("play", "()V", "GetPlayHandler:Com.Yandex.Mapkit.Map.IPlacemarkAnimationInvoker, Yandex.MapKit.Lite")]
	void Play();

	[Register("play", "(Lcom/yandex/mapkit/map/Callback;)V", "GetPlay_Lcom_yandex_mapkit_map_Callback_Handler:Com.Yandex.Mapkit.Map.IPlacemarkAnimationInvoker, Yandex.MapKit.Lite")]
	void Play(ICallback p0);

	[Register("resume", "()V", "GetResumeHandler:Com.Yandex.Mapkit.Map.IPlacemarkAnimationInvoker, Yandex.MapKit.Lite")]
	void Resume();

	[Register("setIcon", "(Lcom/yandex/runtime/image/AnimatedImageProvider;Lcom/yandex/mapkit/map/IconStyle;)V", "GetSetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IPlacemarkAnimationInvoker, Yandex.MapKit.Lite")]
	void SetIcon(AnimatedImageProvider p0, IconStyle p1);

	[Register("setIcon", "(Lcom/yandex/runtime/image/AnimatedImageProvider;Lcom/yandex/mapkit/map/IconStyle;Lcom/yandex/mapkit/map/Callback;)V", "GetSetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_Handler:Com.Yandex.Mapkit.Map.IPlacemarkAnimationInvoker, Yandex.MapKit.Lite")]
	void SetIcon(AnimatedImageProvider p0, IconStyle p1, ICallback p2);

	[Register("setIconStyle", "(Lcom/yandex/mapkit/map/IconStyle;)V", "GetSetIconStyle_Lcom_yandex_mapkit_map_IconStyle_Handler:Com.Yandex.Mapkit.Map.IPlacemarkAnimationInvoker, Yandex.MapKit.Lite")]
	void SetIconStyle(IconStyle p0);

	[Register("stop", "()V", "GetStopHandler:Com.Yandex.Mapkit.Map.IPlacemarkAnimationInvoker, Yandex.MapKit.Lite")]
	void Stop();
}
