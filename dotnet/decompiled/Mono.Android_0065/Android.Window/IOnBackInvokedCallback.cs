using System;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Android.Window;

[Register("android/window/OnBackInvokedCallback", "", "Android.Window.IOnBackInvokedCallbackInvoker", ApiSince = 33)]
public interface IOnBackInvokedCallback : IJavaObject, IDisposable, IJavaPeerable
{
	[SupportedOSPlatform("android33.0")]
	void OnBackInvoked();
}
