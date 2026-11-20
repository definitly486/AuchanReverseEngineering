using System;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/SurfaceControlInputReceiver", "", "Android.Views.ISurfaceControlInputReceiverInvoker", ApiSince = 35)]
public interface ISurfaceControlInputReceiver : IJavaObject, IDisposable, IJavaPeerable
{
	[SupportedOSPlatform("android35.0")]
	[Register("onInputEvent", "(Landroid/view/InputEvent;)Z", "GetOnInputEvent_Landroid_view_InputEvent_Handler:Android.Views.ISurfaceControlInputReceiverInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	bool OnInputEvent(InputEvent e);
}
