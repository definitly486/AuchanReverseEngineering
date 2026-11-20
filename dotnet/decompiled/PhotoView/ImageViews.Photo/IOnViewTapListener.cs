using System;
using Android.Runtime;
using Android.Views;

namespace ImageViews.Photo;

[Register("com/github/chrisbanes/photoview/OnViewTapListener", "", "ImageViews.Photo.IOnViewTapListenerInvoker")]
public interface IOnViewTapListener : IJavaObject, IDisposable
{
	[Register("onViewTap", "(Landroid/view/View;FF)V", "GetOnViewTap_Landroid_view_View_FFHandler:ImageViews.Photo.IOnViewTapListenerInvoker, PhotoView")]
	void OnViewTap(View view, float x, float y);
}
