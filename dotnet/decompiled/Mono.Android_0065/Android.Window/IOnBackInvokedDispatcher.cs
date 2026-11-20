using System;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Android.Window;

[Register("android/window/OnBackInvokedDispatcher", "", "Android.Window.IOnBackInvokedDispatcherInvoker", ApiSince = 33)]
public interface IOnBackInvokedDispatcher : IJavaObject, IDisposable, IJavaPeerable
{
	[SupportedOSPlatform("android33.0")]
	void RegisterOnBackInvokedCallback([IntDef(Type = "Android.Window.IOnBackInvokedDispatcher", Fields = new string[] { "PriorityDefault", "PriorityOverlay", "PrioritySystemNavigationObserver" })] int priority, IOnBackInvokedCallback callback);

	[SupportedOSPlatform("android33.0")]
	void UnregisterOnBackInvokedCallback(IOnBackInvokedCallback callback);
}
