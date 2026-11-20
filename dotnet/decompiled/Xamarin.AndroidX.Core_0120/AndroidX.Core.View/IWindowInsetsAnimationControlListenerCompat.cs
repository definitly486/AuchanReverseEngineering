using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Core.View;

[Register("androidx/core/view/WindowInsetsAnimationControlListenerCompat", "", "AndroidX.Core.View.IWindowInsetsAnimationControlListenerCompatInvoker")]
public interface IWindowInsetsAnimationControlListenerCompat : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onCancelled", "(Landroidx/core/view/WindowInsetsAnimationControllerCompat;)V", "GetOnCancelled_Landroidx_core_view_WindowInsetsAnimationControllerCompat_Handler:AndroidX.Core.View.IWindowInsetsAnimationControlListenerCompatInvoker, Xamarin.AndroidX.Core")]
	void OnCancelled(WindowInsetsAnimationControllerCompat? controller);

	[Register("onFinished", "(Landroidx/core/view/WindowInsetsAnimationControllerCompat;)V", "GetOnFinished_Landroidx_core_view_WindowInsetsAnimationControllerCompat_Handler:AndroidX.Core.View.IWindowInsetsAnimationControlListenerCompatInvoker, Xamarin.AndroidX.Core")]
	void OnFinished(WindowInsetsAnimationControllerCompat? controller);

	[Register("onReady", "(Landroidx/core/view/WindowInsetsAnimationControllerCompat;I)V", "GetOnReady_Landroidx_core_view_WindowInsetsAnimationControllerCompat_IHandler:AndroidX.Core.View.IWindowInsetsAnimationControlListenerCompatInvoker, Xamarin.AndroidX.Core")]
	void OnReady(WindowInsetsAnimationControllerCompat? controller, int types);
}
