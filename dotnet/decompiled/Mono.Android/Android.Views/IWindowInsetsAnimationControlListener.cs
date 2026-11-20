using System;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/WindowInsetsAnimationControlListener", "", "Android.Views.IWindowInsetsAnimationControlListenerInvoker", ApiSince = 30)]
public interface IWindowInsetsAnimationControlListener : IJavaObject, IDisposable, IJavaPeerable
{
	[SupportedOSPlatform("android30.0")]
	[Register("onCancelled", "(Landroid/view/WindowInsetsAnimationController;)V", "GetOnCancelled_Landroid_view_WindowInsetsAnimationController_Handler:Android.Views.IWindowInsetsAnimationControlListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 30)]
	void OnCancelled(IWindowInsetsAnimationController? controller);

	[SupportedOSPlatform("android30.0")]
	[Register("onFinished", "(Landroid/view/WindowInsetsAnimationController;)V", "GetOnFinished_Landroid_view_WindowInsetsAnimationController_Handler:Android.Views.IWindowInsetsAnimationControlListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 30)]
	void OnFinished(IWindowInsetsAnimationController controller);

	[SupportedOSPlatform("android30.0")]
	[Register("onReady", "(Landroid/view/WindowInsetsAnimationController;I)V", "GetOnReady_Landroid_view_WindowInsetsAnimationController_IHandler:Android.Views.IWindowInsetsAnimationControlListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 30)]
	void OnReady(IWindowInsetsAnimationController controller, int types);
}
