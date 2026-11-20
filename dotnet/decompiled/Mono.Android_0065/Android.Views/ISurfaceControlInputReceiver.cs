using System;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/SurfaceControlInputReceiver", "", "Android.Views.ISurfaceControlInputReceiverInvoker", ApiSince = 35)]
public interface ISurfaceControlInputReceiver : IJavaObject, IDisposable, IJavaPeerable
{
	[SupportedOSPlatform("android35.0")]
	bool OnInputEvent(InputEvent e);
}
