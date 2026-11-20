using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace AndroidX.Core.View;

[Register("androidx/core/view/ViewPropertyAnimatorListener", "", "AndroidX.Core.View.IViewPropertyAnimatorListenerInvoker")]
public interface IViewPropertyAnimatorListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onAnimationCancel", "(Landroid/view/View;)V", "GetOnAnimationCancel_Landroid_view_View_Handler:AndroidX.Core.View.IViewPropertyAnimatorListenerInvoker, Xamarin.AndroidX.Core")]
	void OnAnimationCancel(Android.Views.View? view);

	[Register("onAnimationEnd", "(Landroid/view/View;)V", "GetOnAnimationEnd_Landroid_view_View_Handler:AndroidX.Core.View.IViewPropertyAnimatorListenerInvoker, Xamarin.AndroidX.Core")]
	void OnAnimationEnd(Android.Views.View? view);

	[Register("onAnimationStart", "(Landroid/view/View;)V", "GetOnAnimationStart_Landroid_view_View_Handler:AndroidX.Core.View.IViewPropertyAnimatorListenerInvoker, Xamarin.AndroidX.Core")]
	void OnAnimationStart(Android.Views.View? view);
}
