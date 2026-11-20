using System;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Android.Window;

[Register("android/window/OnBackInvokedDispatcher", "", "Android.Window.IOnBackInvokedDispatcherInvoker", ApiSince = 33)]
public interface IOnBackInvokedDispatcher : IJavaObject, IDisposable, IJavaPeerable
{
	[SupportedOSPlatform("android33.0")]
	[Register("registerOnBackInvokedCallback", "(ILandroid/window/OnBackInvokedCallback;)V", "GetRegisterOnBackInvokedCallback_ILandroid_window_OnBackInvokedCallback_Handler:Android.Window.IOnBackInvokedDispatcherInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 33)]
	void RegisterOnBackInvokedCallback([IntDef(Type = "Android.Window.IOnBackInvokedDispatcher", Fields = new string[] { "PriorityDefault", "PriorityOverlay", "PrioritySystemNavigationObserver" })] int priority, IOnBackInvokedCallback callback);

	[SupportedOSPlatform("android33.0")]
	[Register("unregisterOnBackInvokedCallback", "(Landroid/window/OnBackInvokedCallback;)V", "GetUnregisterOnBackInvokedCallback_Landroid_window_OnBackInvokedCallback_Handler:Android.Window.IOnBackInvokedDispatcherInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 33)]
	void UnregisterOnBackInvokedCallback(IOnBackInvokedCallback callback);
}
