using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace AndroidX.Core.View;

[Register("androidx/core/view/OnReceiveContentListener", "", "AndroidX.Core.View.IOnReceiveContentListenerInvoker")]
public interface IOnReceiveContentListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onReceiveContent", "(Landroid/view/View;Landroidx/core/view/ContentInfoCompat;)Landroidx/core/view/ContentInfoCompat;", "GetOnReceiveContent_Landroid_view_View_Landroidx_core_view_ContentInfoCompat_Handler:AndroidX.Core.View.IOnReceiveContentListenerInvoker, Xamarin.AndroidX.Core")]
	ContentInfoCompat? OnReceiveContent(Android.Views.View? view, ContentInfoCompat? payload);
}
