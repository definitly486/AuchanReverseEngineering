using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace Com.Yandex.Runtime.View;

[Register("com/yandex/runtime/view/PlatformView", "", "Com.Yandex.Runtime.View.IPlatformViewInvoker")]
public interface IPlatformView : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsDebugModeEnabled
	{
		[Register("isDebugModeEnabled", "()Z", "GetIsDebugModeEnabledHandler:Com.Yandex.Runtime.View.IPlatformViewInvoker, Yandex.MapKit.Lite")]
		get;
	}

	NativeObject? NativePlatformView
	{
		[Register("getNativePlatformView", "()Lcom/yandex/runtime/NativeObject;", "GetGetNativePlatformViewHandler:Com.Yandex.Runtime.View.IPlatformViewInvoker, Yandex.MapKit.Lite")]
		get;
	}

	Android.Views.View? View
	{
		[Register("getView", "()Landroid/view/View;", "GetGetViewHandler:Com.Yandex.Runtime.View.IPlatformViewInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("destroyNativePlatformView", "()V", "GetDestroyNativePlatformViewHandler:Com.Yandex.Runtime.View.IPlatformViewInvoker, Yandex.MapKit.Lite")]
	void DestroyNativePlatformView();

	[Register("onMemoryWarning", "()V", "GetOnMemoryWarningHandler:Com.Yandex.Runtime.View.IPlatformViewInvoker, Yandex.MapKit.Lite")]
	void OnMemoryWarning();

	[Register("pause", "()V", "GetPauseHandler:Com.Yandex.Runtime.View.IPlatformViewInvoker, Yandex.MapKit.Lite")]
	void Pause();

	[Register("resume", "()V", "GetResumeHandler:Com.Yandex.Runtime.View.IPlatformViewInvoker, Yandex.MapKit.Lite")]
	void Resume();

	[Register("setNoninteractive", "(Z)V", "GetSetNoninteractive_ZHandler:Com.Yandex.Runtime.View.IPlatformViewInvoker, Yandex.MapKit.Lite")]
	void SetNoninteractive(bool p0);

	[Register("start", "()V", "GetStartHandler:Com.Yandex.Runtime.View.IPlatformViewInvoker, Yandex.MapKit.Lite")]
	void Start();

	[Register("stop", "()V", "GetStopHandler:Com.Yandex.Runtime.View.IPlatformViewInvoker, Yandex.MapKit.Lite")]
	void Stop();
}
