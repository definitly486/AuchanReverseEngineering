using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace AndroidX.Core.View;

[Register("androidx/core/view/ViewPropertyAnimatorUpdateListener", "", "AndroidX.Core.View.IViewPropertyAnimatorUpdateListenerInvoker")]
public interface IViewPropertyAnimatorUpdateListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onAnimationUpdate", "(Landroid/view/View;)V", "GetOnAnimationUpdate_Landroid_view_View_Handler:AndroidX.Core.View.IViewPropertyAnimatorUpdateListenerInvoker, Xamarin.AndroidX.Core")]
	void OnAnimationUpdate(Android.Views.View? view);
}
