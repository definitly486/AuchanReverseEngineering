using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace AndroidX.Core.View;

[Register("androidx/core/view/OnApplyWindowInsetsListener", "", "AndroidX.Core.View.IOnApplyWindowInsetsListenerInvoker")]
public interface IOnApplyWindowInsetsListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onApplyWindowInsets", "(Landroid/view/View;Landroidx/core/view/WindowInsetsCompat;)Landroidx/core/view/WindowInsetsCompat;", "GetOnApplyWindowInsets_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_Handler:AndroidX.Core.View.IOnApplyWindowInsetsListenerInvoker, Xamarin.AndroidX.Core")]
	WindowInsetsCompat? OnApplyWindowInsets(Android.Views.View? v, WindowInsetsCompat? insets);
}
